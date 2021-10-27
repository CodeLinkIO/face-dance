using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Custom tree view state that holds extra information about expanded rows for simulated data.
    /// This saves the expanded state of rows that will have a different ID after the simulation is recreated
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class HierarchyState
    {
        [SerializeField]
        List<Transform> m_OriginalExpandedTransforms = new List<Transform>();

        [SerializeField]
        List<Transform> m_OriginalSelectedTransforms = new List<Transform>();

        [SerializeField]
        bool m_QueryRootExpanded;

        [SerializeField]
        bool m_EnvironmentRootExpanded;

        /// <summary>
        /// Collection of the original expanded transforms
        /// </summary>
        public List<Transform> OriginalExpandedTransforms => m_OriginalExpandedTransforms;

        /// <summary>
        /// Collection of the original selected transforms
        /// </summary>
        public List<Transform> OriginalSelectedTransforms => m_OriginalSelectedTransforms;

        /// <summary>
        /// Is the query root expanded
        /// </summary>
        public bool QueryRootExpanded
        {
            get => m_QueryRootExpanded;
            internal set => m_QueryRootExpanded = value;
        }

        /// <summary>
        /// Is the environment root expanded
        /// </summary>
        public bool EnvironmentRootExpanded
        {
            get => m_EnvironmentRootExpanded;
            internal set => m_EnvironmentRootExpanded = value;
        }
    }

    /// <summary>
    /// Tree view GUI for the MARS Simulation View hierarchy
    /// Hierarchy to tree view starting code brought from
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class HierarchyTreeView : TreeView
    {
        class Styles
        {
            public readonly GUIContent emptyHierarchyContent;
            public readonly GUIStyle rowLabelStyle;

            public readonly Color defaultRowTextColor;
            public readonly int matchCountWidth;

            public Styles()
            {
                emptyHierarchyContent = new GUIContent("Hierarchy Empty");

                defaultRowTextColor = EditorStyles.label.normal.textColor;

                rowLabelStyle = new GUIStyle(GUI.skin.label);
                rowLabelStyle.wordWrap = false;

                // The match count will be centered in space for 3 digits
                matchCountWidth = (int)rowLabelStyle.CalcSize(new GUIContent("999")).x;
            }
        }

        const int k_InitialRowsCount = 32;
        const float k_RowEdgePadding = 8f;
        const float k_ColumnEdgeOffset = 12f;
        const float k_ColumnWidthFill = 11f;
        const int k_ScrollAreaPadding = 8;
        const string k_SeekingMatch = "Seeking a match";
        const string k_MatchFound = "Match found";
        const string k_NoMatch = "No match found";
        static readonly HashSet<int> k_PingedIDs = new HashSet<int>();
        static readonly HashSet<HierarchyTreeView> k_SimulatedContentHierarchies = new HashSet<HierarchyTreeView>();

        static Styles s_Styles;

        readonly Dictionary<int, Proxy> m_ProxyObjects = new Dictionary<int, Proxy>();
        readonly Dictionary<int, ProxyGroup> m_ProxyGroups = new Dictionary<int, ProxyGroup>();
        readonly Dictionary<int, Replicator> m_Replicators = new Dictionary<int, Replicator>();
        readonly Dictionary<int, IHasEditorColor> m_ColorData = new Dictionary<int, IHasEditorColor>();
        readonly List<GameObject> m_HierarchyRootGameObjects = new List<GameObject>();

        readonly HierarchyState m_SimHierarchyState;
        readonly bool m_IsEnvironmentHierarchy;

        bool m_HeightScrollbarActive;
        int m_SimEnvironmentRootID;
        GUIStyle m_AreaStyle = new GUIStyle();

        // Local method use only -- created here to reduce garbage collection
        static readonly List<int> k_PingableSelectedIDs = new List<int>();

        // Delay creation of Styles till first access
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        /// <summary>
        /// The width of the widest row currently being rendered
        /// </summary>
        float TotalWidth { get; set; }

        /// <summary>
        /// The maximum height of the tree view's scroll area
        /// </summary>
        public float MaxHeight { get; set; }

        /// <summary>
        /// Offset for tree view GUI drawing, used for horizontal scrolling
        /// </summary>
        public float horizontalOffset { get; protected set; }

        /// <summary>
        /// The height of the selected row
        /// </summary>
        public float selectedRowY { get; set; }

        /// <summary>
        /// Sets the GUIStyle name for the tree view's container
        /// </summary>
        public string StyleName { get { return m_AreaStyle.name; } set { m_AreaStyle.name = value; } }

        /// <summary>
        /// Creates the <c>HierarchyTreeView</c> for a simulation hierarchy
        /// </summary>
        /// <param name="treeViewState">The serializable state of the tree view</param>
        /// <param name="hierarchyState">State of the tree view with extra data for the simulation</param>
        /// <param name="isEnvironmentHierarchy">Is the tree view for the simulated environment</param>
        /// <param name="needsStateCached">Is the cached state being cached or restored</param>
        public HierarchyTreeView(TreeViewState treeViewState, HierarchyState hierarchyState, bool isEnvironmentHierarchy, bool needsStateCached)
            : base(treeViewState)
        {
            m_IsEnvironmentHierarchy = isEnvironmentHierarchy;
            m_SimHierarchyState = hierarchyState;
            Reload();

            if (!isEnvironmentHierarchy)
                k_SimulatedContentHierarchies.Add(this);

            EditorApplication.hierarchyChanged += OnHierarchyChange;

            if (needsStateCached)
                CacheState();
            else
                RestoreState();
        }

        ~HierarchyTreeView()
        {
            if (!m_IsEnvironmentHierarchy)
                k_SimulatedContentHierarchies.Remove(this);

            EditorApplication.hierarchyChanged -= OnHierarchyChange;
        }

        /// <summary>
        /// Cache the state based on the transform so when they IDs change on re-simulation the state can be restored
        /// </summary>
        public void CacheState()
        {
            var expanded = state.expandedIDs;
            m_SimHierarchyState.OriginalExpandedTransforms.Clear();
            m_SimHierarchyState.OriginalSelectedTransforms.Clear();
            m_SimHierarchyState.QueryRootExpanded = false;
            m_SimHierarchyState.EnvironmentRootExpanded = false;

            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager == null)
                return;

            // Expand previously expanded content objects
            foreach (var id in expanded)
            {
                var go = EditorUtility.InstanceIDToObject(id) as GameObject;
                if (go != null)
                {
                    var original = simulatedObjectsManager.GetOriginalTransform(go.transform);
                    if (original != null)
                        m_SimHierarchyState.OriginalExpandedTransforms.Add(original);
                    else if (go == simulatedObjectsManager.SimulatedContentRoot)
                        m_SimHierarchyState.QueryRootExpanded = true;
                }
            }

            var selectedTransforms = Selection.GetTransforms(SelectionMode.Unfiltered);
            foreach (var t in selectedTransforms)
            {
                var original = simulatedObjectsManager.GetOriginalTransform(t);
                if (original != null)
                    m_SimHierarchyState.OriginalSelectedTransforms.Add(original);
            }
        }

        /// <summary>
        /// Restore the previously cached state
        /// </summary>
        public void RestoreState()
        {
            var moduleLoaderCore = ModuleLoaderCore.instance;
            if (!moduleLoaderCore.ModulesAreLoaded)
                return;

            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager == null || simulatedObjectsManager.SimulatedContentRoot == null)
                return;

            var expandedOriginals = m_SimHierarchyState.OriginalExpandedTransforms;
            var expanded = new List<int>(expandedOriginals.Count);
            foreach (var originalTransform in expandedOriginals)
            {
                if (originalTransform == null)
                    continue;

                var copy = simulatedObjectsManager.GetCopiedTransform(originalTransform);
                if (copy != null)
                    expanded.Add(copy.gameObject.GetInstanceID());
            }

            if (m_SimHierarchyState.QueryRootExpanded)
                expanded.Add(simulatedObjectsManager.SimulatedContentRoot.GetInstanceID());

            if (m_SimHierarchyState.EnvironmentRootExpanded)
            {
                var environmentManager = moduleLoaderCore.GetModule<MARSEnvironmentManager>();
                expanded.Add(environmentManager.EnvironmentParent.GetInstanceID());
            }

            SetExpanded(expanded);
            var newSelection = new List<UnityObject>(Selection.objects);
            foreach (var originalTransform in m_SimHierarchyState.OriginalSelectedTransforms)
            {
                if (originalTransform == null)
                    continue;

                var copy = simulatedObjectsManager.GetCopiedTransform(originalTransform);
                if (copy != null)
                    newSelection.Add(copy.gameObject);
            }

            Selection.objects = newSelection.ToArray();
            if (Selection.instanceIDs.Length > 0)
                SetSelection(Selection.instanceIDs);

            // Content objects have been replaced, so we need to cache pinged IDs again
            if (Selection.transforms.Length > 0)
                PingObjects(Selection.transforms);
        }

        /// <summary>
        /// Creates the full tree of the <c>TreeViewItem</c>s and returns the root
        /// </summary>
        /// <returns>The root of the tree. This item can later be accessed by 'rootItem'.</returns>
        protected override TreeViewItem BuildRoot()
        {
            return new TreeViewItem {id = 0, depth = -1};
        }

        /// <summary>
        /// Generates the rows in the <c>TreeView</c>
        /// </summary>
        /// <param name="treeRoot">Root item that was created in the BuildRoot method.</param>
        /// <returns>The rows list shown in the TreeView. Can later be accessed using GetRows().</returns>
        protected override IList<TreeViewItem> BuildRows(TreeViewItem treeRoot)
        {
            var rows = GetRows () ?? new List<TreeViewItem> (k_InitialRowsCount);
            rows.Clear();
            m_HierarchyRootGameObjects.Clear();

            ClearMARSTypeDictionaries();

            var moduleLoaderCore = ModuleLoaderCore.instance;
            var simSceneModule = moduleLoaderCore.GetModule<SimulationSceneModule>();
            if (simSceneModule == null || !simSceneModule.IsSimulationReady)
                return rows;

            GameObject simRoot = null;
            if (!m_IsEnvironmentHierarchy)
            {
                if (EditorApplication.isPlaying) // In play mode take all open scenes
                {
                    for (var i = 0; i < SceneManager.sceneCount; i++)
                    {
                        var scene = SceneManager.GetSceneAt(i);
                        m_HierarchyRootGameObjects.AddRange(scene.GetRootGameObjects());
                    }
                }
                else // In edit mode just take the simulation scene objects
                {
                    m_HierarchyRootGameObjects.Clear();
                    simSceneModule.ContentRoot.GetChildGameObjects(m_HierarchyRootGameObjects);

                    var simulatedObjectsManager = moduleLoaderCore.GetModule<SimulatedObjectsManager>();
                    simRoot = simulatedObjectsManager.SimulatedContentRoot;
                }
            }
            else
            {
                m_HierarchyRootGameObjects.Clear();
                simSceneModule.EnvironmentRoot.GetChildGameObjects(m_HierarchyRootGameObjects);

                var environmentManager = moduleLoaderCore.GetModule<MARSEnvironmentManager>();
                simRoot = environmentManager.EnvironmentParent;
            }

            if (simRoot != null)
            {
                m_HierarchyRootGameObjects.Remove(simRoot);
                for (var i = 0; i < simRoot.transform.childCount; i++)
                {
                    m_HierarchyRootGameObjects.Add(simRoot.transform.GetChild(i).gameObject);
                }
            }

            // Move providers to bottom
            if (!m_IsEnvironmentHierarchy && m_HierarchyRootGameObjects.Count > 0)
            {
                var providersRoot = m_HierarchyRootGameObjects[0];
                if (providersRoot != null && providersRoot.name.Contains("Providers"))
                {
                    m_HierarchyRootGameObjects.Remove(providersRoot);
                    m_HierarchyRootGameObjects.Add(providersRoot);
                }
            }

            // Move Environment Root Prefab to the top
            if (m_IsEnvironmentHierarchy && m_HierarchyRootGameObjects.Count > 0)
            {
                var environmentPrefab = m_HierarchyRootGameObjects.FirstOrDefault(
                    f => f.name.Contains(SimulationSettings.instance.EnvironmentPrefab.name));
                if (environmentPrefab != null)
                {
                    m_HierarchyRootGameObjects.Remove(environmentPrefab);
                    m_HierarchyRootGameObjects.Insert(0, environmentPrefab);
                    m_SimEnvironmentRootID = environmentPrefab.GetInstanceID();
                }
                else
                {
                    m_SimEnvironmentRootID = 0;
                }
            }

            foreach (var gameObject in m_HierarchyRootGameObjects)
            {
                if ((gameObject.hideFlags & HideFlags.HideInHierarchy) == HideFlags.HideInHierarchy)
                    continue;

                var item = CreateTreeViewItemForGameObject (gameObject);
                CacheMARSTypesForItem(gameObject.transform, item);

                treeRoot.AddChild (item);
                rows.Add (item);
                if (gameObject.transform.childCount > 0)
                {
                    if (IsExpanded (item.id))
                    {
                        AddChildrenRecursive (gameObject, item, rows);
                    }
                    else
                    {
                        item.children = CreateChildListForCollapsedParent ();
                    }
                }
            }

            SetupDepthsFromParentsAndChildren(treeRoot);
            return rows;
        }

        /// <summary>
        /// This method is e.g. used for revealing items that are currently under a collapsed item.
        /// </summary>
        /// <param name="id">TreeViewItem ID.</param>
        /// <returns> List of all the ancestors of a given item with ID id.</returns>
        protected override IList<int> GetAncestors(int id)
        {
            var ancestors = new List<int> ();
            var obj = EditorUtility.InstanceIDToObject(id);
            if (obj == null || !(obj is GameObject))
                return ancestors;

            var transform = ((GameObject)obj).transform;

            while (transform.parent != null)
            {
                var parent = transform.parent;
                ancestors.Add (parent.gameObject.GetInstanceID ());
                transform = parent;
            }

            return ancestors;
        }

        /// <summary>
        /// Returns all descendants for the item with ID id that have children.
        /// </summary>
        /// <param name="id">TreeViewItem ID.</param>
        /// <returns>Descendants that have children.</returns>
        protected override IList<int> GetDescendantsThatHaveChildren(int id)
        {
            var stack = new Stack<Transform> ();
            var start = ((GameObject)EditorUtility.InstanceIDToObject(id)).transform;
            stack.Push (start);

            var parents = new List<int> ();
            while (stack.Count > 0)
            {
                var current = stack.Pop ();
                parents.Add (current.gameObject.GetInstanceID ());
                for (var i = 0; i < current.childCount; ++i)
                {
                    if (current.childCount > 0)
                        stack.Push (current.GetChild (i));
                }
            }

            return parents;
        }

        /// <summary>
        /// Method to get notified of selection changes.
        /// </summary>
        /// <param name="selectedIds">TreeViewItem IDs.</param>
        protected override void SelectionChanged(IList<int> selectedIds)
        {
            Selection.instanceIDs = selectedIds.ToArray();

            if (selectedIds.Count == 1)
                PingSourceObject();
        }

        /// <summary>
        /// Method to handle double click events on an item.
        /// </summary>
        /// <param name="id">ID of TreeViewItem that was double clicked.</param>
        protected override void DoubleClickedItem(int id)
        {
            base.DoubleClickedItem(id);
            var obj = EditorUtility.InstanceIDToObject(id);
            if (obj == null)
                return;

            var gameObject = obj as GameObject;
            if (gameObject == null || (SimulationView.ActiveSimulationView == null))
                return;

            SimulationView.ActiveSimulationView.Frame(BoundsUtils.GetBounds(gameObject.transform), false);
        }

        static Color GetTextColorForRow(RowGUIArgs args)
        {
            if (k_PingedIDs.Contains(args.item.id))
                return MarsUserPreferences.HighlightedSimulatedObjectColor;

            var obj = EditorUtility.InstanceIDToObject(args.item.id);
            if (obj == null)
                return styles.defaultRowTextColor;

            var gameObject = obj as GameObject;
            if (gameObject == null)
                return styles.defaultRowTextColor;

            if (args.selected && gameObject.activeInHierarchy)
                return Color.white;

            if (!gameObject.activeInHierarchy && !args.selected)
                return Color.gray;

            return styles.defaultRowTextColor;
        }

        /// <summary>
        /// Method to add GUI content for the rows in the TreeView.
        /// </summary>
        /// <param name="args">Row data.</param>
        protected override void RowGUI(RowGUIArgs args)
        {
            baseIndent = MarsEditorGUI.IndentSize - horizontalOffset;
            var rowTooltip = GetRowTooltip(args);
            var content = new GUIContent(args.label, rowTooltip);
            var contentIndent = GetContentIndent(args.item);
            var isSimEnvRootPrefab = m_IsEnvironmentHierarchy && m_SimEnvironmentRootID == args.item.id;

            styles.rowLabelStyle.normal.textColor = args.selected ? Color.white :
                isSimEnvRootPrefab ? MarsEditorGUI.Styles.BlueText : GetTextColorForRow(args);

            styles.rowLabelStyle.fontStyle = FontStyle.Normal;
            var contentSize = styles.rowLabelStyle.CalcSize(content);

            var infoRect = new Rect(args.rowRect.xMax - styles.matchCountWidth - k_RowEdgePadding + horizontalOffset,
                args.rowRect.y, styles.matchCountWidth, args.rowRect.height);

            var labelRect = new Rect(args.rowRect.xMin + contentIndent, args.rowRect.yMin, args.rowRect.width,
                args.rowRect.height);
            labelRect.xMax = infoRect.xMin - 2;

            if (args.selected)
                selectedRowY = args.rowRect.y;

            var columnRect = GetRowColumnRect(args.rowRect, false);
            var isFocus = HasFocus();
            if (Event.current.type == EventType.Repaint)
            {
                var mousePos = Event.current.mousePosition;
                var isHovered = columnRect.Contains(mousePos) || args.rowRect.Contains(mousePos);
                var internalStyles = MarsEditorGUI.InternalEditorStyles;

                // Scrolling the view does not increase the size of the selection highlight rect
                if (columnRect.x > args.rowRect.xMax)
                {
                    var overflowRect = new Rect(columnRect) { xMin = args.rowRect.xMax, xMax = columnRect.xMin };

                    isHovered = isHovered || overflowRect.Contains(mousePos);
                    if (args.selected)
                        internalStyles.TreeViewSelection.Draw(overflowRect, false, false, true, isFocus);
                    else if (isHovered)
                        internalStyles.TreeViewLine.Draw(overflowRect, true, true, false, false);
                }

                if (!args.selected && isHovered)
                    internalStyles.TreeViewLine.Draw(args.rowRect, true, true, false, isFocus);

                var backgroundColor = internalStyles.GetTreeViewItemBackgroundColor(isHovered, args.selected, isFocus);

                EditorGUI.DrawRect(columnRect, backgroundColor);
            }

            var selectionClickRect = new Rect(args.rowRect) {xMin = args.rowRect.xMax, xMax = columnRect.xMax};

            if (GUI.Button(selectionClickRect, GUIContent.none, GUIStyle.none))
                SelectionClick(args.item, Event.current.shift);

            GUI.Label(labelRect, content, styles.rowLabelStyle);

            // For rows that have an icon, need to adjust label rect and draw icon on right side
            var icon = args.item.icon;
            if (args.item.icon != null)
            {
                var colorTint = Color.white;
                if (m_ColorData.TryGetValue(args.item.id, out var colorComp))
                    colorTint = colorComp.color;

                GUI.DrawTexture(infoRect, icon, ScaleMode.ScaleToFit, true, 1f, colorTint, Vector4.zero, Vector4.zero);
            }

            if (isSimEnvRootPrefab)
            {
                if (GUI.Button(infoRect, new GUIContent(MarsEditorGUI.Styles.TabNext), GUIStyle.none))
                {
                    var moduleLoaderCore = ModuleLoaderCore.instance;
                    var environmentManager = moduleLoaderCore.GetModule<MARSEnvironmentManager>();
                    if (environmentManager.TrySaveEnvironmentModificationsDialog())
                    {
                        AssetDatabase.OpenAsset(SimulationSettings.instance.EnvironmentPrefab);
                        environmentManager.RefreshEnvironment();
                    }
                }
            }

            // Rows that are replicator have a count, need to adjust label rect
            if (m_Replicators.TryGetValue(args.item.id, out var replicator))
                GUI.Label(infoRect, new GUIContent($"{replicator.matchCount}"), styles.rowLabelStyle);

            if (Event.current.type == EventType.Layout)
                TotalWidth = Mathf.Max(TotalWidth, contentSize.x + foldoutWidth + 2);
        }

        Rect GetRowColumnRect(Rect rect, bool useScrollOffsets)
        {
            const float rowRectOverflow = 1f;

            var scrollbarWidth = GUI.skin.verticalScrollbar.fixedWidth;
            var rectX = rect.xMax - styles.matchCountWidth - k_ColumnEdgeOffset;

            if (m_HeightScrollbarActive && useScrollOffsets)
                rectX -= scrollbarWidth;
            else if (!useScrollOffsets)
                rectX += horizontalOffset;

            return new Rect(rectX, rect.y, styles.matchCountWidth + k_ColumnWidthFill + rowRectOverflow, rect.height);
        }

        string GetRowTooltip(RowGUIArgs args)
        {
            var isQuery = true;
            var queryState = QueryState.Unknown;
            if (m_ProxyObjects.TryGetValue(args.item.id, out var proxyObj))
                queryState = proxyObj.queryState;
            else if (m_ProxyGroups.TryGetValue(args.item.id, out var proxyGroup))
                queryState = proxyGroup.queryState;
            else
                isQuery = false;

            if (!isQuery)
                return string.Empty;

            switch (queryState)
            {
                case QueryState.Unknown:
                    return k_SeekingMatch;
                case QueryState.Tracking:
                    return k_MatchFound;
                default:
                    return k_NoMatch;
            }
        }

        static TreeViewItem CreateTreeViewItemForGameObject (GameObject gameObject)
        {
            // Use instance id as TreeViewItem id
            // Set depth to -1 here and then call SetupDepthsFromParentsAndChildren at the end of BuildRows to set the depths.
            var item = new TreeViewItem(gameObject.GetInstanceID(), -1, gameObject.name)
            {
                icon = MarsUIResources.instance.GetIconForGameObject(gameObject)
            };

            return item;
        }

        void AddChildrenRecursive (GameObject go, TreeViewItem item, IList<TreeViewItem> rows)
        {
            var childCount = go.transform.childCount;
            item.children = new List<TreeViewItem> (childCount);
            for (var i = 0; i < childCount; i++)
            {
                var childTransform = go.transform.GetChild (i);
                if ((childTransform.gameObject.hideFlags & HideFlags.HideInHierarchy) == HideFlags.HideInHierarchy)
                    continue;

                var childItem = CreateTreeViewItemForGameObject (childTransform.gameObject);
                CacheMARSTypesForItem(childTransform, childItem);

                item.AddChild (childItem);
                rows.Add (childItem);

                if (childTransform.childCount > 0)
                {
                    if (IsExpanded (childItem.id))
                    {
                        AddChildrenRecursive (childTransform.gameObject, childItem, rows);
                    }
                    else
                    {
                        childItem.children = CreateChildListForCollapsedParent ();
                    }
                }
            }
        }

        void ClearMARSTypeDictionaries()
        {
            m_ColorData.Clear();
            m_ProxyObjects.Clear();
            m_ProxyGroups.Clear();
            m_Replicators.Clear();
        }

        void CacheMARSTypesForItem(Transform transform, TreeViewItem item)
        {
            // Check for color data
            var color = transform.GetComponent<IHasEditorColor>();
            if (color != null)
                m_ColorData.Add(item.id, color);

            // Check MARS entities
            var realWorldObject = transform.GetComponent<Proxy>();
            if (realWorldObject)
            {
                m_ProxyObjects.Add(item.id, realWorldObject);
            }
            else
            {
                var proxyGroup = transform.GetComponent<ProxyGroup>();
                if (proxyGroup)
                {
                    m_ProxyGroups.Add(item.id, proxyGroup);
                }
                else
                {
                    var replicator = transform.GetComponent<Replicator>();
                    if (replicator)
                        m_Replicators.Add(item.id, replicator);
                }
            }
        }

        static void PingSourceObject()
        {
            var selectedTransform = Selection.activeTransform;
            // Can be nullified when sim scene is reloading
            if (!selectedTransform)
                return;

            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager != null)
                EditorGUIUtility.PingObject(simulatedObjectsManager.GetOriginalTransform(selectedTransform));
        }

        /// <summary>
        /// Ping the selected items in the hierarchy
        /// </summary>
        /// <param name="selection"></param>
        public static void PingObjects(Transform[] selection)
        {
            k_PingedIDs.Clear();

            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager != null)
            {
                k_PingableSelectedIDs.Clear();
                foreach (var item in selection)
                {
                    var simObject = simulatedObjectsManager.GetCopiedTransform(item);
                    if (simObject != null)
                        k_PingableSelectedIDs.Add(simObject.gameObject.GetInstanceID());
                }
            }

            if (k_PingableSelectedIDs.Count == 0)
                return;

            foreach (var hierarchy in k_SimulatedContentHierarchies)
            {
                if (hierarchy != null)
                    hierarchy.FrameItem(k_PingableSelectedIDs[0]);
            }

            k_PingedIDs.UnionWith(k_PingableSelectedIDs);
        }

        /// <summary>
        /// Clear the pinged items
        /// </summary>
        public static void UnsetPing()
        {
            k_PingedIDs.Clear();
        }

        /// <summary>
        /// Draw the hierarchy tree view the horizontal and vertical scrolling
        /// </summary>
        /// <param name="scrollPosition">Scrolling position</param>
        /// <param name="scrollToSelected">Scroll to the selected item in the hierarchy</param>
        /// <param name="enabled">Is the simulation active to so the hierarchy can be displayed</param>
        /// <returns></returns>
        public Vector2 DrawScrollingTreeView(Vector2 scrollPosition, ref bool scrollToSelected, bool enabled)
        {
            using (var areaScope = new EditorGUILayout.VerticalScope(m_AreaStyle, GUILayout.Height(MaxHeight)))
            {
                // Draw overflow background column
                EditorGUI.DrawRect(GetRowColumnRect(areaScope.rect, true),
                    MarsEditorGUI.InternalEditorStyles.TreeViewBackgroundColor);

                using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition, GUILayout.ExpandHeight(true),
                    GUILayout.Height(MaxHeight)))
                {
                    if (!enabled)
                        EditorGUILayout.LabelField(styles.emptyHierarchyContent);

                    scrollPosition = scrollView.scrollPosition;
                    horizontalOffset = scrollPosition.x;
                    var rect = GUILayoutUtility.GetRect(TotalWidth, totalHeight, MarsEditorGUI.Styles.AreaAlignment);
                    OnGUI(rect);

                    if (Event.current.type != EventType.Repaint)
                        return scrollPosition;

                    m_HeightScrollbarActive = areaScope.rect.height - k_ScrollAreaPadding <= rect.height;

                    // Scroll to the selected item
                    if (!scrollToSelected)
                        return scrollPosition;

                    if (selectedRowY > scrollPosition.y + areaScope.rect.height - EditorStyles.foldout.lineHeight)
                    {
                        scrollPosition.y = selectedRowY - areaScope.rect.height + EditorStyles.foldout.lineHeight;
                        Repaint();
                    }
                    if (selectedRowY < scrollPosition.y)
                    {
                        scrollPosition.y = selectedRowY;
                        Repaint();
                    }

                    scrollToSelected = false;
                }
            }

            return scrollPosition;
        }

        void OnHierarchyChange()
        {
            Reload();
            Repaint();
        }
    }
}

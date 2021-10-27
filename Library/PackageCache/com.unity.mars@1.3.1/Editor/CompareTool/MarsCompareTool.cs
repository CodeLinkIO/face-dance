using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEditor.EditorTools;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;
#if !UNITY_2020_2_OR_NEWER
using ToolManager = UnityEditor.EditorTools.EditorTools;
#endif

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Tool for comparing MARS conditions and relations to data in the Simulation View
    /// </summary>
    [EditorTool("MARS Compare Tool", typeof(Proxy))]
    [MovedFrom("Unity.MARS")]
    class MarsCompareTool : EditorTool
    {
        const string k_AreYouSureMessage = "Are you sure you want to conform all conditions to match the selected data?";
        const string k_ModifyConditionActionMessage = "Modify Condition";
        const string k_ConfirmActionMessage = "Do it!";
        const string k_CancelActionMessage = "Cancel";

        internal const string Tooltip = "Select simulated data to compare it with this Proxy's conditions";

        class Styles
        {
            public readonly GUIContent stopComparingButtonContent = new GUIContent("Stop Comparing", "Stop comparing to simulated data.");
            public readonly GUIContent startComparingButtonContent = new GUIContent("Compare in Simulation View", Tooltip);
            public readonly GUIContent includeAllButtonContent = new GUIContent("Include All", "Modify all conditions to include the simulated data.");
            public readonly GUIContent optimizeAllButtonContent = new GUIContent("Optimize All", "Modify all conditions to be optimal for the simulated data.");

            public readonly GUIContent includeButtonContent = new GUIContent("Include");
            public readonly GUIContent optimizeButtonContent = new GUIContent("Optimize");

            public GUIStyle boxStyle;
            public GUIStyle dataLabelStyle;

            public Styles()
            {
                dataLabelStyle = new GUIStyle(EditorStyles.miniLabel);
                boxStyle = new GUIStyle("box");
            }
        }

        static MarsCompareTool s_Instance;
        static Styles s_Styles;

        Editor m_CurrentEditor;

        bool m_ToolIsActive;
        CompareInfoOverlay m_InfoOverlay;

        CompareToDataModule m_CompareDataModule;
        SimulatedObjectsManager m_SimulatedObjectsManager;
        SceneViewInteractionModule m_SceneViewInteractionModule;
        GUIContent m_ToolbarIcon;

        // Delay creation of Styles till first access
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        public override GUIContent toolbarIcon => m_ToolbarIcon ?? (m_ToolbarIcon = new GUIContent(MarsUIResources.instance.CompareToolIcon.Icon, Tooltip));
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<KeyValuePair<string, float>> k_ConditionRatings = new List<KeyValuePair<string, float>>();

        public override bool IsAvailable()
        {
            return MARSSession.Instance != null;
        }

        void Awake()
        {
            s_Instance = this;
        }

        void OnEnable()
        {
            ModuleLoaderCore.instance.ModulesLoaded += TryGetModules;
            ToolManager.activeToolChanged += OnActiveToolChanged;
            SceneView.duringSceneGui += OnSceneGUI;
            Selection.selectionChanged += OnSelectionChanged;
            EditorOnlyEvents.onSimulationStart += OnSimulationStart;
            TryGetModules();
        }

        public void OnDisable()
        {
            s_Instance = null;
            ModuleLoaderCore.instance.ModulesLoaded -= TryGetModules;
            ToolManager.activeToolChanged -= OnActiveToolChanged;
            SceneView.duringSceneGui -= OnSceneGUI;
            Selection.selectionChanged -= OnSelectionChanged;
            EditorOnlyEvents.onSimulationStart -= OnSimulationStart;
        }

        void OnSimulationStart(List<IFunctionalitySubscriber> functionalitySubscribers, HashSet<TraitRequirement> traitRequirements)
        {
            EditorApplication.delayCall += OnSelectionChanged;
        }

        void TryGetModules()
        {
            m_CompareDataModule = ModuleLoaderCore.instance.GetModule<CompareToDataModule>();
            m_SimulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            m_SceneViewInteractionModule = ModuleLoaderCore.instance.GetModule<SceneViewInteractionModule>();
            OnActiveToolChanged();
        }

        /// <summary>
        /// Draw controls for starting, stopping, including, and optimizing simulation controls
        /// </summary>
        /// <param name="editor">The editor drawing the controls</param>
        public static void DrawControls(Editor editor)
        {
            if (s_Instance != null)
                s_Instance.DrawCompareControls(editor);
        }

        /// <summary>
        /// Draw comparison UI that goes after a condition's own properties
        /// </summary>
        /// <param name="condition">The condition to compare with</param>
        /// <param name="selectionIndex">The index into the selection comparison data</param>
        public static void DrawComponentControls(Condition condition, int selectionIndex = 0)
        {
            if (s_Instance != null)
                s_Instance.DrawComponentInspectorControls(condition, selectionIndex);
        }

        void DrawComponentInspectorControls(Condition condition, int selectionIndex = 0)
        {
            if (m_CompareDataModule == null || !m_CompareDataModule.IsComparing)
                return;

            var traitDataSnapshot = m_CompareDataModule.GetComparisonData(selectionIndex);

            if (traitDataSnapshot == null || !condition.enabled)
                return;

            if (!(condition is ICreateFromData createFromData))
                return;

            using (new EditorGUILayout.VerticalScope(styles.boxStyle))
            {
                var traitPassesCondition = createFromData.GetConditionRatingForData(traitDataSnapshot) > 0f;

                styles.dataLabelStyle.normal.textColor = !traitPassesCondition ? MarsUserPreferences.ConditionFailTextColor : GUI.skin.label.normal.textColor;

                var formattedLabelText = $"Selected data: {createFromData.FormatDataString(traitDataSnapshot)}";
                GUILayout.Label(formattedLabelText, styles.dataLabelStyle);
                GUILayout.FlexibleSpace();

                using (new EditorGUILayout.HorizontalScope())
                {
                    using (new EditorGUI.DisabledScope(traitPassesCondition))
                    {
                        if (GUILayout.Button(styles.includeButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                        {
                            Undo.RecordObject(condition, k_ModifyConditionActionMessage);
                            createFromData.IncludeData(traitDataSnapshot);
                        }
                    }

                    if (GUILayout.Button(styles.optimizeButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                    {
                        Undo.RecordObject(condition, k_ModifyConditionActionMessage);
                        createFromData.OptimizeForData(traitDataSnapshot);
                    }
                }
            }
        }

        /// <summary>
        /// Draws the controls for controlling the comparison module for a particular editor
        /// </summary>
        /// <param name="editor">The editor that the controls are being draw inside.</param>
        void DrawCompareControls(Editor editor)
        {
            // Comparing only works with a single data object, so don't show the compare controls unless this is a Proxy
            if (((MARSEntity)editor.target).GetComponent<Proxy>() == null)
                return;

            if (m_CompareDataModule == null)
                return;

            m_CurrentEditor = editor;

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PrefixLabel("Compare Tool");

                if (m_CompareDataModule.IsComparing)
                {
                    if (GUILayout.Button(styles.includeAllButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                    {
                        if (EditorUtility.DisplayDialog(k_ModifyConditionActionMessage, k_AreYouSureMessage, k_ConfirmActionMessage, k_CancelActionMessage))
                        {
                            m_CompareDataModule.IncludeAll();
                            Undo.IncrementCurrentGroup();
                            m_SimulatedObjectsManager.DirtySimulatableScene();
                        }
                    }

                    if (GUILayout.Button(styles.optimizeAllButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                    {
                        if (EditorUtility.DisplayDialog(k_ModifyConditionActionMessage, k_AreYouSureMessage, k_ConfirmActionMessage, k_CancelActionMessage))
                        {
                            m_CompareDataModule.OptimizeAll();
                            Undo.IncrementCurrentGroup();
                            m_SimulatedObjectsManager.DirtySimulatableScene();
                        }
                    }

                    if (GUILayout.Button(styles.stopComparingButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                    {
                        ToolManager.RestorePreviousPersistentTool();
                    }
                }
                else
                {
                    if (GUILayout.Button(styles.startComparingButtonContent, MarsEditorGUI.Styles.MiniFontButton))
                    {
                        ToolManager.SetActiveTool<MarsCompareTool>();
                    }
                }
            }
        }

        void OnSelectionChanged()
        {
            if (!m_ToolIsActive)
                return;

            Proxy proxyToCompare = null;
            Proxy proxyToModify = null;
            if (Selection.activeGameObject != null)
            {
                proxyToModify = Selection.activeGameObject.GetComponent<Proxy>();
                if (proxyToModify != null && m_SimulatedObjectsManager != null)
                {
                    var simCopy = m_SimulatedObjectsManager.GetCopiedSimulatable(proxyToModify) as Proxy;
                    proxyToCompare = simCopy != null ? simCopy : proxyToModify;
                }
            }

            if (m_CompareDataModule != null)
            {
                m_CompareDataModule.SetProxyToCompare(proxyToCompare);
                m_CompareDataModule.SetProxyToModify(proxyToModify);
            }

            UpdateOverlayUI();
        }

        void OnActiveToolChanged()
        {
            m_ToolIsActive = ToolManager.IsActiveTool(this);
            if (m_CompareDataModule != null)
            {
                if (m_ToolIsActive)
                {
                    m_CompareDataModule.StartComparing();
                    m_CompareDataModule.CompareDataChanged += UpdateOverlayUI;
                }
                else
                {
                    m_CompareDataModule.StopComparing();
                    m_CompareDataModule.CompareDataChanged -= UpdateOverlayUI;
                }

                if (m_SceneViewInteractionModule != null)
                {
                    m_SceneViewInteractionModule.RequestInteraction(this, m_ToolIsActive);
                    if (m_ToolIsActive)
                    {
                        m_SceneViewInteractionModule.SelectionLimit = 1;
                        m_SceneViewInteractionModule.HoverBegin += OnHoverBegin;
                        m_SceneViewInteractionModule.HoverEnd += OnHoverEnd;
                        m_SceneViewInteractionModule.SelectionChanged += OnDataSelectionChanged;
                    }
                    else
                    {
                        m_SceneViewInteractionModule.HoverBegin -= OnHoverBegin;
                        m_SceneViewInteractionModule.HoverEnd -= OnHoverEnd;
                        m_SceneViewInteractionModule.SelectionChanged -= OnDataSelectionChanged;
                    }
                }
            }

            if (m_ToolIsActive)
            {
                // Open simulation view if needed
                if (!SimulationSceneModule.UsingSimulation)
                {
                    EditorWindow.GetWindow<SceneView>(); // Need to make sure there is a scene view otherwise the simulation view will close immediately
                    EditorWindow.GetWindow<SimulationView>();
                }

                SimulationView.ActiveSimulationView.Focus();
            }

            UpdateOverlayUI();
            OnSelectionChanged();
        }

        void OnDataSelectionChanged(List<InteractionTarget> selection)
        {
            var dataVisualProxies = new List<Proxy>();
            foreach (var interactionTarget in selection)
            {
                if (interactionTarget != null && interactionTarget.AttachTarget != null
                    && interactionTarget.AttachTarget.GetComponent<IDataVisual>() != null)
                {
                    var proxy = interactionTarget.AttachTarget.GetComponent<Proxy>();
                    dataVisualProxies.Add(proxy);
                }
            }

            m_InfoOverlay.ShowSelectInstruction = selection.Count == 0;

            m_CompareDataModule.OnDataSelectionChanged(dataVisualProxies);
        }

        void OnHoverEnd(InteractionTarget interactionTarget)
        {
            if (m_CompareDataModule != null && m_SceneViewInteractionModule.CurrentHoverTarget == null)
                m_CompareDataModule.OnHoverEnd();
        }

        void OnHoverBegin(InteractionTarget interactionTarget)
        {

            if (interactionTarget == null || interactionTarget.AttachTarget == null)
            {
                m_CompareDataModule.OnHoverChange(null);
            }
            else if (interactionTarget.AttachTarget.GetComponent<IDataVisual>() != null)
            {
                m_CompareDataModule.OnHoverChange(interactionTarget.AttachTarget.GetComponent<Proxy>());
            }
            else
            {
                m_CompareDataModule.OnHoverEnd();
            }
        }

        void UpdateOverlayUI()
        {
            if (m_InfoOverlay == null)
                m_InfoOverlay = new CompareInfoOverlay();

            var uiDisplayStyle = new StyleEnum<DisplayStyle>(m_ToolIsActive ? DisplayStyle.Flex : DisplayStyle.None);
            m_InfoOverlay.style.display = uiDisplayStyle;

            SimulationView.AddElementToLastHoveredWindow(m_InfoOverlay);

            var compareObjName = "...";
            var dataName = "...";
            k_ConditionRatings.Clear();

            if (m_CompareDataModule != null)
            {
                m_CompareDataModule.GetConditionRatings(k_ConditionRatings);

                var proxyToCompare = m_CompareDataModule.ProxyToCompare;
                if (proxyToCompare != null)
                    compareObjName = proxyToCompare.gameObject.name;

                var comparisonData = m_CompareDataModule.GetComparisonData();
                if (comparisonData != null)
                    dataName = $"Data #{comparisonData.DataID}";
            }

            m_InfoOverlay.HeaderLabel.text = $"Comparing {compareObjName} to {dataName}";

            m_InfoOverlay.SetConditionRatings(k_ConditionRatings);
        }

        void OnSceneGUI(SceneView sceneView)
        {
            if (EditorWindow.mouseOverWindow != sceneView || !(sceneView is SimulationView))
                return;

            if (m_CurrentEditor)
                m_CurrentEditor.Repaint();
        }
    }
}

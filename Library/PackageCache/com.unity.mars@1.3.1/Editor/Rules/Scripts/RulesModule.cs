using System.Linq;
using UnityEditor.IMGUI.Controls;
using PopupWindow = UnityEditor.PopupWindow;
using System;
using System.Collections.Generic;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Landmarks;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Rules.RulesEditor
{
    enum MarsObjectType
    {
        Content,
        Action,
        Landmark
    }

    class RulesModule : IModule
    {
        public enum ReplicatorCountOption
        {
            Every,
            One,
            UpTo
        }

        static class Picker<T> where T : UnityObject
        {
            public static Action<T> PostPickCallback;

            public static void HandlePick()
            {
                // Invoke OnObjectPicked a frame after PostPickCallback to respond to changes
                if (WasPicked)
                {
                    WasPicked = false;
                    s_HandlePick = null;
                    OnObjectPicked?.Invoke();
                    return;
                }

                if (s_ShowPicker)
                {
                    s_ShowPicker = false;
                    var controlId = GUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<T>(null, false, string.Empty, controlId);
                    return;
                }

                if (PickedObject == null)
                    return;

                var specificPickedObject = PickedObject as T;
                if (specificPickedObject == null)
                {
                    PickedObject = null;
                    return;
                }

                PostPickCallback?.Invoke(specificPickedObject);
                PickedObject = null;
                PostPickCallback = null;
                WasPicked = true;
            }
        }

        const string k_LandmarkErrorMessage = "Landmarks currently only supported on individual proxies.";

        const float k_ReplicatorSceneOffset = 10f;
        const float k_GroupObjectSceneOffset = 2.5f;
        const float k_EmptyBoundsDefaultSize = 0.5f;

        const string k_SelectedClassName = "selected";
        const string k_EmptyObjectName = "Empty GameObject";

        const string k_PickProxyPresetButtonAnalyticsLabel = "Pick proxy preset button";
        const string k_ConvertToGroupAnalyticsLabel = "Convert proxy row to group";

        static ProxyActionsDropdown s_ProxyActionsDropdown;
        static ProxyGroupActionsDropdown s_ProxyGroupActionsDropdown;
        static ContentActionsDropdown s_ContentActionsDropdown;

        internal static event Action OnObjectPicked;
        internal static UnityObject PickedObject;
        internal static bool WasPicked;
        static Vector3 s_LastProxyPosition = Vector3.zero;
        static ProxyRuleSet s_ProxyRuleSetInstance;
        static ProxyRuleSet s_ParentRuleSet;
        static VisualElement s_PreviouslySelectedElement;
        static Action s_HandlePick;
        static bool s_ShowPicker;
        static bool s_LastSetChildrenVisible;

        internal static HashSet<GameObject> CollapsedNodes = new HashSet<GameObject>();

        internal static Transform NewObjectParent { get; private set; }
        internal static Transform NewObject { get; set; }
        internal static Action<Replicator, Proxy> OnRuleAdded { get; set; }
        internal static ProxyRuleSet ParentRuleSet => s_ParentRuleSet;
        internal static GameObject SelectedRuleNode { private get; set; }

        internal static ProxyRuleSet RuleSetInstanceExisting
        {
            get
            {
                var selection = Selection.activeGameObject;
                if (selection != null)
                {
                    var selectedRuleSet = selection.GetComponent<ProxyRuleSet>();
                    var group = selection.GetComponent<ProxyGroup>();
                    var newRuleSetSelected = selectedRuleSet != null && selectedRuleSet != s_ProxyRuleSetInstance;
                    // Don't change on group selection to fix behavior where selecting a group row would instantly switch to inspecting that group,
                    // and be stuck on that group until changing the selection.
                    if (newRuleSetSelected && group == null)
                    {
                        s_ProxyRuleSetInstance = selectedRuleSet;
                        return s_ProxyRuleSetInstance;
                    }
                }

                if (s_ProxyRuleSetInstance != null)
                    return s_ProxyRuleSetInstance;

                if (s_ProxyRuleSetInstance == null)
                    s_ProxyRuleSetInstance = UnityObject.FindObjectOfType<ProxyRuleSet>();

                return s_ProxyRuleSetInstance;
            }
        }

        internal static ProxyRuleSet RuleSetInstance
        {
            get
            {
                var ruleSet = RuleSetInstanceExisting;
                if (ruleSet)
                    return ruleSet;

                s_ProxyRuleSetInstance = new GameObject("Proxy Rule Set", typeof(ProxyRuleSet))
                    .GetComponent<ProxyRuleSet>();
                return s_ProxyRuleSetInstance;
            }
            set
            {
                s_ProxyRuleSetInstance = value;
                CollectRuleSceneObjects();
            }
        }

        void IModule.LoadModule()
        {
            Selection.selectionChanged += OnSelectionChanged;
            EditorSceneManager.activeSceneChangedInEditMode += OnSceneChanged;
            Undo.undoRedoPerformed += RulesDrawer.BuildReplicatorsList;

            s_ProxyActionsDropdown = new ProxyActionsDropdown(new AdvancedDropdownState());
            s_ProxyGroupActionsDropdown = new ProxyGroupActionsDropdown(new AdvancedDropdownState());
            s_ContentActionsDropdown = new ContentActionsDropdown(new AdvancedDropdownState());
        }

        void IModule.UnloadModule()
        {
            // ReSharper disable DelegateSubtraction
            Selection.selectionChanged -= OnSelectionChanged;
            Undo.undoRedoPerformed -= RulesDrawer.BuildReplicatorsList;
            // ReSharper restore DelegateSubtraction

            EditorSceneManager.activeSceneChangedInEditMode -= OnSceneChanged;
        }

        static void OnSelectionChanged()
        {
            var go = Selection.activeGameObject;
            if (go == null)
                return;

            var ruleSet = go.GetComponent<ProxyRuleSet>();
            if (ruleSet != null)
            {
                RuleSetInstance = ruleSet;
                RulesDrawer.BuildReplicatorsList();
                return;
            }

            var entity = go.GetComponent<MARSEntity>();
            if (entity == null)
                return;

            var moduleLoaderCore = ModuleLoaderCore.instance;
            var simulatedObjectsManager = moduleLoaderCore.GetModule<SimulatedObjectsManager>();
            var originalSimTransform = simulatedObjectsManager.GetOriginalTransform(go.transform);

            if (originalSimTransform == null)
                return;

            FrameObject(originalSimTransform);
        }

        static void OnSceneChanged(Scene oldScene, Scene newScene)
        {
            RulesDrawer.BuildReplicatorsList();
        }

        internal static void FrameObject(Transform transform)
        {
            var bounds = BoundsUtils.GetBounds(transform);
            if (bounds.extents == Vector3.zero)
                bounds.extents = Vector3.one * k_EmptyBoundsDefaultSize;

            if (SimulationView.NormalSceneView)
                SimulationView.NormalSceneView.Frame(bounds);
        }

        internal static void HandlePicker()
        {
            s_HandlePick?.Invoke();
        }

        internal static void Pick<T>(Action<T> postPickCallback) where T : UnityObject
        {
            Picker<T>.PostPickCallback = postPickCallback;
            s_HandlePick = Picker<T>.HandlePick;
            s_ShowPicker = true;
        }

        internal static void SetChildrenVisible(bool visible, Transform instance)
        {
            using (var undoBlock = new UndoBlock("Setting visibility"))
            {
                foreach (Transform child in instance.transform)
                {
                    undoBlock.RecordObject(child);
                    child.gameObject.hideFlags = visible ? HideFlags.None : HideFlags.HideInHierarchy;
                }
            }

            EditorApplication.DirtyHierarchyWindowSorting(); // helps editor know to update

            s_LastSetChildrenVisible = visible;
        }

        internal static bool AllChildrenVisible(Transform transform)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.hideFlags == HideFlags.HideInHierarchy)
                    return false;
            }

            return true;
        }

        internal static void CollectRuleSceneObjects()
        {
            s_ParentRuleSet = null;

            var rules = RuleSetInstanceExisting;
            var parent = rules ? rules.transform.parent : null;
            while (parent != null && s_ParentRuleSet == null)
            {
                s_ParentRuleSet = parent.GetComponent<ProxyRuleSet>();
                parent = parent.parent;
            }
        }

        internal static void ReplaceGameObject(GameObject replacement, Transform currentTransform,
            bool reParentChildren = true)
        {
            // `replacement` would be null when the user has selected 'None' from the object picker.
            // A content row represents a Transform, so setting a row to 'None' is undefined.
            // Deleting the row in this situation is the wrong move, because it would feel like broken behavior,
            // and would prevent the workflow of removing an object from the row without providing a replacement.
            // Therefore, we create an empty object.  This object has no effect and will be replaced when any other object
            // is assigned to the field via drag+drop or picker.
            if (replacement == null)
                replacement = new GameObject(k_EmptyObjectName);

            var isPrefab = PrefabUtility.IsPartOfPrefabAsset(replacement);

            var newTransform = replacement.transform;
            if (isPrefab)
                newTransform = UnityObject.Instantiate(replacement).transform;

            newTransform.parent = currentTransform.parent;
            newTransform.localPosition = Vector3.zero;

            if (reParentChildren)
                ReParentChildren(currentTransform, newTransform);
            else
                UnityObject.DestroyImmediate(currentTransform.gameObject);

            var cloneIdx = newTransform.name.IndexOf("(Clone)", StringComparison.Ordinal);
            if (cloneIdx > -1)
            {
                newTransform.name =
                    newTransform.name.Substring(0, cloneIdx);
            }

            RulesDrawer.BuildReplicatorsList();
        }

        static void ReParentChildren(Transform currentParent, Transform newParent)
        {
            var children = new List<Transform>();
            foreach (Transform child in currentParent)
            {
                var landmarkController = child.gameObject.GetComponent<LandmarkController>();
                var landmarkHasContent = landmarkController != null && child.childCount > 0;
                if (landmarkController == null || landmarkHasContent)
                    children.Add(child);
                else
                    UnityObject.DestroyImmediate(child.gameObject);
            }

            foreach (var child in children)
                child.parent = newParent;

            UnityObjectUtils.Destroy(currentParent.gameObject);
        }

        internal static void DoAddRule()
        {
            using (var undoBlock = new UndoBlock("Add Rule"))
            {
                var replicator = CreateReplicator(undoBlock).GetComponent<Replicator>();
                replicator.transform.parent = RuleSetInstance.transform;

                var surfaceGameObject = CreateHorizontalSurface(undoBlock);
                var proxy = surfaceGameObject.GetComponent<Proxy>();

                var surface = proxy.transform;
                surface.parent = replicator.transform;
                surface.localPosition = Vector3.zero;
                surface.hideFlags = HideFlags.HideInInspector;

                FrameObject(proxy.transform);

                OnRuleAdded?.Invoke(replicator, proxy);
            }
        }

        static GameObject CreateReplicator(UndoBlock undoBlock)
        {
            var count = string.Empty;

            var gameObject = new GameObject($"On Every{count}");
            undoBlock.RegisterCreatedObject(gameObject);
            gameObject.transform.position = s_LastProxyPosition;
            s_LastProxyPosition += Vector3.right * k_ReplicatorSceneOffset;
            gameObject.AddComponent<Replicator>();

            if (!s_LastSetChildrenVisible)
                gameObject.hideFlags = HideFlags.HideInHierarchy;

            return gameObject;
        }

        static GameObject CreateHorizontalSurface(UndoBlock undoBlock)
        {
            var gameObject = new GameObject("Horizontal Surface");
            undoBlock.RegisterCreatedObject(gameObject);
            gameObject.transform.parent = Selection.activeTransform;
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.AddComponent<Proxy>();
            gameObject.AddComponent<IsPlaneCondition>();
            gameObject.AddComponent<AlignmentCondition>();
            gameObject.AddComponent<SetPoseAction>();
            gameObject.AddComponent<ShowChildrenOnTrackingAction>();

            return gameObject;
        }

        internal static GameObject CreateBuildSurfaceObject(UnityObject obj = null)
        {
            var objExists = obj != null;
            var gameObject = new GameObject($"{(objExists ? obj.name : "[missing]")}");
            Undo.RegisterCreatedObjectUndo(gameObject, "Create surface");
            gameObject.transform.parent = Selection.activeTransform;
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<BuildSurfaceAction>();
            var renderer = gameObject.AddComponent<MeshRenderer>();

            if (objExists)
                renderer.material = (Material) obj;

            return gameObject;
        }

        internal static void ConvertProxyToGroup(Proxy proxy)
        {
            var proxyTransform = proxy.transform;
                // RuleSet added to group object because the RuleSet drawer only draws for RuleSet objects
            var group =
                new GameObject("New Group", typeof(ProxyRuleSet))
                    .AddComponent<ProxyGroup>();
            var groupTransform = group.transform;

            groupTransform.parent = proxyTransform.parent;
            groupTransform.position = proxyTransform.position;
            proxyTransform.parent = groupTransform;

            var newProxy = new GameObject("Surface", typeof(IsPlaneCondition)).AddComponent<Proxy>();
            newProxy.gameObject.AddComponent<SetPoseAction>();
            newProxy.gameObject.AddComponent<ShowChildrenOnTrackingAction>();

            var newProxyTransform = newProxy.transform;

            newProxyTransform.parent = groupTransform;
            newProxyTransform.localPosition = Vector3.right * k_GroupObjectSceneOffset;

            RulesDrawer.BuildReplicatorsList();

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_ConvertToGroupAnalyticsLabel
            });
        }

        internal static MarsObjectType GetMarsObjectType(Transform content)
        {
            if (content.GetComponents<MonoBehaviour>().OfType<IAction>().Any())
                return MarsObjectType.Action;

            return content.GetComponent<LandmarkController>()
                ? MarsObjectType.Landmark
                : MarsObjectType.Content;
        }

        internal static void ReParentNewObject()
        {
            if (NewObject == null)
                return;

            NewObject.parent = NewObjectParent;
            NewObject.localPosition = Vector3.zero;
            NewObject = null;
        }

        internal static void DoPickProxyPresetButton(MARSEntity childEntity, Rect rect)
        {
            PopupWindow.Show(rect, new ChangeProxyWindow(childEntity));

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_PickProxyPresetButtonAnalyticsLabel
            });
        }

        internal static void SetSelectedComponent(UnityObject obj)
        {
            Selection.objects = new[] {obj};
        }

        internal static void DisplayElementSelected(VisualElement elm)
        {
            s_PreviouslySelectedElement?.RemoveFromClassList(k_SelectedClassName);

            elm.AddToClassList(k_SelectedClassName);
            s_PreviouslySelectedElement = elm;
        }

        internal static void DeleteSelectedRuleNode()
        {
            if (SelectedRuleNode == null)
                return;

            if (ParentRuleSet != null) // Don't allow deletion within a group.
                return;

            Undo.DestroyObjectImmediate(SelectedRuleNode);
            RulesDrawer.BuildReplicatorsList();
        }

        internal static void DoAddLandmark(Transform root, Transform content, Action onLandmarkCreated = null)
        {
            var proxy = root.GetComponentInChildren<Proxy>();
            if (proxy == null)
            {
                Debug.LogError(k_LandmarkErrorMessage);
                return;
            }

            var landmarkCalculator = proxy.GetComponent<ICalculateLandmarks>()
                                     ?? proxy.gameObject.AddComponent<PlaneLandmarksAction>();

            LandmarkControllerEditor.ShowLandmarksMenu(landmarkCalculator, landmarkController =>
            {
                onLandmarkCreated?.Invoke();

                var existingLandmark = content.GetComponent<LandmarkController>();

                if (existingLandmark == null)
                {
                    content.parent = landmarkController.transform;
                }
                else
                {
                    foreach (Transform child in content)
                    {
                        child.parent = landmarkController.transform;
                    }

                    UnityObject.DestroyImmediate(existingLandmark.gameObject);
                }
            });
        }

        internal static string GetLandmarkName(Transform root)
        {
            var landmark = root.GetComponent<LandmarkController>();

            var type = LandmarkControllerEditor.TrimLandmarkOutputName(landmark.output.GetType().Name);

            var settingsDescription = string.Empty;
            if ((landmark.settings is ClosestLandmarkSettings settings) && (settings.target))
            {
                settingsDescription = $" to {settings.target.name}";
            }

            var landmarkDefinition = "Misconfigured landmark";
            if (landmark.landmarkDefinition != null)
                landmarkDefinition = landmark.landmarkDefinition.name;

            return $"{landmarkDefinition} {type}{settingsDescription}";
        }

        internal static void AddContent(Transform root, Vector2? mousePosition = null)
        {
            NewObjectParent = root;

            var marsEntity = root.GetComponent<MARSEntity>();
            var landmark = root.GetComponent<LandmarkController>();
            if (marsEntity == null && landmark == null)
                return;

            var pos = mousePosition ?? Event.current.mousePosition;
            pos.y -= EditorStyles.toolbar.fixedHeight;

            if (marsEntity is Proxy || landmark != null)
            {
                RulesWindow.GUIDispatch = () =>
                    s_ProxyActionsDropdown.Show(new Rect(pos, Vector2.zero));
            }
            else if (marsEntity is ProxyGroup)
            {
                RulesWindow.GUIDispatch = () =>
                    s_ProxyGroupActionsDropdown.Show(new Rect(pos, Vector2.zero));
            }
        }

        internal static void AddAction(Transform root, Vector2? mousePosition = null)
        {
            NewObjectParent = root;
            var pos = mousePosition ?? Event.current.mousePosition;
            s_ContentActionsDropdown.Show(new Rect(pos, Vector2.zero));
        }

        internal static void AddNode(RuleNode targetNode)
        {
            if (targetNode is ReplicatorRow repRow)
            {
                if (!repRow.IsGroup)
                    AddContent(repRow.BackingProxy.transform);
            }
            else if (targetNode is ContentRow)
            {
                AddAction(targetNode.BackingObject.transform);
            }
            else if (targetNode is ActionRow)
            {
                AddAction(targetNode.ContainerObject);
            }
        }

        internal static void PickObject(ExecuteCommandEvent evt)
        {
            if (evt.commandName != "ObjectSelectorClosed" && !WasPicked)
                return;

            var pickedObject = EditorGUIUtility.GetObjectPickerObject();
            if (pickedObject != null)
                PickedObject = pickedObject;
        }
    }
}

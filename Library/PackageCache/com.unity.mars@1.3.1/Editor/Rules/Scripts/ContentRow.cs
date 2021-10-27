using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Actions;
using Unity.MARS.Behaviors;
using Unity.MARS.Forces;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS.Rules.RulesEditor
{
    class ContentRow : RuleNode
    {
        const string k_ContentRowPath = k_Directory + "ContentRow.uxml";

        const string k_ContentObjectFieldName = "contentObjectField";
        const string k_LandmarkButtonName = "landmarkButton";
        const string k_ContentTitleName = "contentTitle";
        const string k_ObjectSetupAreaName = "objectSetupArea";

        const string k_AddActionContent = "Add Action";
        const string k_PaintContent = "Paint";

        const string k_AddButtonContentAnalyticsLabel = "Margin add button (Content row)";
        const string k_AddLandmarkButtonAnalyticsLabel = "Add landmark button";

        readonly Transform m_ContainerTransform;
        readonly Transform m_Transform;

        ObjectField m_ContentObjectField;
        ActionRow[] m_ActionRows;

        internal override Transform ContainerObject => m_Transform.parent;
        internal override GameObject BackingObject => m_Transform.gameObject;
        internal bool ContentSupportsActions { get; private set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<Transform> k_TempActions = new List<Transform>();

        public ContentRow(Transform container, Transform content)
        {
            m_ContainerTransform = container;
            m_Transform = content;

            SetupUI();
        }

        public static bool IsApplicableToTransform(Transform t)
        {
            return !ProxyForces.IsForceRegion(t);
        }

        internal bool HasChanged(Transform content)
        {
            if (content != m_Transform)
                return true;

            k_TempActions.Clear();
            GetActionCandidates(k_TempActions);
            if (m_ActionRows.Length != k_TempActions.Count)
                return true;

            for (int i = 0; i < m_ActionRows.Length; i++)
            {
                var actionRow = m_ActionRows[i];
                var child = k_TempActions[i];
                if (actionRow.HasChanged(child))
                    return true;
            }

            return false;
        }

        protected sealed override void SetupUI()
        {
            var contentRowAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_ContentRowPath);
            contentRowAsset.CloneTree(this);

            base.SetupUI();

            SetupChildren();

            m_ContentObjectField = this.Q<ObjectField>(k_ContentObjectFieldName);

            ContentSupportsActions = !m_Transform.GetComponent<BuildSurfaceAction>();
            if (ContentSupportsActions)
                SetupSpawnContent();
            else
                SetupBuildSurfaceContent();

            m_ContentObjectField.RegisterCallback<ExecuteCommandEvent>(RulesModule.PickObject);
        }

        void SetupSpawnContent()
        {
            m_ContentObjectField.objectType = typeof(Transform);
            m_ContentObjectField.RegisterValueChangedCallback(OnContentFieldChange);

            var content = m_Transform;
            var isLandmark = RulesModule.GetMarsObjectType(m_Transform) == MarsObjectType.Landmark;
            if (isLandmark)
                content = content.childCount > 0 ? content.GetChild(0) : null;

            if (content != null)
            {
                var so = new SerializedObject(content);
                so.Update();

                m_NodeContainer.Bind(so);
                m_ContentObjectField.value = content;
            }

            var landmarkButton = this.Q<Button>(k_LandmarkButtonName);
            landmarkButton.clicked += () =>
            {
                RulesModule.DoAddLandmark(m_ContainerTransform, m_Transform,
                    () => { EditorApplication.delayCall += RulesDrawer.BuildReplicatorsList; });

                EditorEvents.RulesUiUsed.Send(new RuleUiArgs
                {
                    label = k_AddLandmarkButtonAnalyticsLabel
                });
            };

            if (isLandmark)
            {
                landmarkButton.text = RulesModule.GetLandmarkName(m_Transform);
            }
        }

        void OnContentFieldChange(ChangeEvent<Object> evt)
        {
            if (evt == null)
                return;

            if (evt.previousValue == null)
            {
                var newObject = (Transform) evt.newValue;
                var isPrefab = PrefabUtility.IsPartOfPrefabAsset(newObject);
                if (isPrefab)
                    newObject = Object.Instantiate(newObject.gameObject).transform;

                newObject.parent = BackingObject.transform;
                newObject.localPosition = Vector3.zero;
            }
            else
            {
                GameObject newObject = null;
                if (evt.newValue != null)
                    newObject = ((Transform) evt.newValue).gameObject;

                RulesModule.ReplaceGameObject(newObject, (Transform) evt.previousValue, false);
            }
        }

        void SetupBuildSurfaceContent()
        {
            var contentTitle = this.Q<Label>(k_ContentTitleName);
            contentTitle.text = k_PaintContent;

            var objectSetupArea = this.Q<VisualElement>(k_ObjectSetupAreaName);
            objectSetupArea.style.display = DisplayStyle.None;
            m_Transform.GetComponent<Transform>().hideFlags = HideFlags.HideInInspector;

            var renderer = m_Transform.GetComponent<MeshRenderer>();
            var material = renderer.sharedMaterial;

            var so = new SerializedObject(material);
            so.Update();

            m_NodeContainer.Bind(so);
            m_ContentObjectField.objectType = typeof(Material);
            m_ContentObjectField.value = material;
            m_ContentObjectField.RegisterValueChangedCallback(OnMaterialFieldChange);

            m_AddButtonHoverElement.SetEnabled(false);
        }

        void OnMaterialFieldChange(ChangeEvent<Object> evt)
        {
            if (evt == null)
                return;

            var renderer = BackingObject.GetComponent<MeshRenderer>();
            if (renderer == null)
            {
                Debug.LogError("Build Surface object must contain a MeshRenderer.");
                return;
            }

            renderer.material = (Material) evt.newValue;

            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            if (querySimulationModule.simulatingTemporal)
                querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

            environmentManager.TryRefreshEnvironmentAndRestartSimulation();
        }

        void GetActionCandidates(List<Transform> actionObjects)
        {
            foreach (Transform child in m_Transform)
            {
                var contentAction = child.GetComponentsInChildren<ContentAction>();
                if (contentAction == null)
                    continue;

                actionObjects.AddRange(contentAction.Select(t => t.transform));
            }
        }

        void SetupChildren()
        {
            k_TempActions.Clear();
            GetActionCandidates(k_TempActions);

            m_ActionRows = new ActionRow[k_TempActions.Count];
            for (int i = 0; i < k_TempActions.Count; i++)
            {
                var actionRow = new ActionRow(k_TempActions[i]);
                Add(actionRow);
                m_ActionRows[i] = actionRow;
            }
        }

        internal override void Select()
        {
            var frameTarget = m_Transform;
            if (!ContentSupportsActions)
                frameTarget = m_Transform.parent;

            base.Select(m_Transform, frameTarget, m_Transform.gameObject);
        }

        protected override void OnAddButton()
        {
            RulesModule.AddAction(m_Transform);

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_AddButtonContentAnalyticsLabel
            });
        }
    }
}

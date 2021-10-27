using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Authoring;
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
    /// Tool for creating MARS proxies and proxy groups from data
    /// </summary>
    [EditorTool("MARS Create Tool")]
    [MovedFrom("Unity.MARS")]
    class MarsCreateTool : EditorTool
    {
        bool m_ToolIsActive;
        CreateFromDataWindow m_CreateWindow;
        DataInfoOverlay m_DataInfoOverlay;
        CreateButtonsOverlay m_CreateOverlay;

        DataVisualsModule m_DataVisualsModule;
        ScenePlacementModule m_ScenePlacementModule;
        SceneViewInteractionModule m_InteractionModule;
        GUIContent m_ToolbarIcon;

        public override GUIContent toolbarIcon => m_ToolbarIcon ?? (m_ToolbarIcon = new GUIContent(MarsUIResources.instance.CreateToolIcon.Icon));

        void OnEnable()
        {
            ModuleLoaderCore.instance.ModulesLoaded += TryGetModules;
            ToolManager.activeToolChanged += OnActiveToolChanged;
            TryGetModules();
        }

        public void OnDisable()
        {
            ModuleLoaderCore.instance.ModulesLoaded -= TryGetModules;
            ToolManager.activeToolChanged -= OnActiveToolChanged;
        }

        void TryGetModules()
        {
            m_InteractionModule = ModuleLoaderCore.instance.GetModule<SceneViewInteractionModule>();
            m_DataVisualsModule = ModuleLoaderCore.instance.GetModule<DataVisualsModule>();
            m_ScenePlacementModule = ModuleLoaderCore.instance.GetModule<ScenePlacementModule>();
            OnActiveToolChanged();
        }

        public override bool IsAvailable()
        {
            return MARSSession.Instance != null;
        }

        void OnActiveToolChanged()
        {
#if UNITY_2020_2_OR_NEWER
            m_ToolIsActive = ToolManager.IsActiveTool(this);
#else
            m_ToolIsActive = EditorTools.EditorTools.IsActiveTool(this);
#endif

            if (m_DataVisualsModule != null)
                m_DataVisualsModule.RequestDataVisuals(this, m_ToolIsActive);

            if (m_ScenePlacementModule != null)
            {
                if (m_ToolIsActive)
                {
                    m_ScenePlacementModule.ObjectDropped += OnObjectDropped;
                }
                else
                {
                    m_ScenePlacementModule.ObjectDropped -= OnObjectDropped;
                }
            }

            if (m_InteractionModule != null)
            {
                m_InteractionModule.RequestInteraction(this, m_ToolIsActive);
                if (m_ToolIsActive)
                {
                    m_InteractionModule.SelectionLimit = 2;
                    m_InteractionModule.HoverBegin += OnHoverBegin;
                    m_InteractionModule.HoverEnd += OnHoverEnd;
                }
                else
                {
                    m_InteractionModule.HoverBegin -= OnHoverBegin;
                    m_InteractionModule.HoverEnd -= OnHoverEnd;
                }
            }

            UpdateInfoOverlayUI();
            UpdateCreateUI();
        }

        public override void OnToolGUI(EditorWindow window)
        {
            if (Event.current.type != EventType.Layout)
                return;

            if (window != SimulationView.LastHoveredSimulationOrDeviceView)
                return;

            UpdateInfoOverlayUI();
            UpdateCreateUI();
        }

        void OnObjectDropped(GameObject droppedObject, GameObject dropTarget)
        {
            if (dropTarget != null && dropTarget.GetComponentInParent<IDataVisual>() == null)
                return;

            if (m_CreateWindow != null)
                m_CreateWindow.Close();

            var createProxyData = new CreateProxyFromData();
            createProxyData.OnObjectDropped(droppedObject, dropTarget);
            OpenCreateProxyWindow(createProxyData);
        }

        void OnHoverBegin(InteractionTarget interactionTarget)
        {
            foreach (var simView in SimulationView.SimulationViews)
            {
                simView.Repaint();
            }
        }

        void OnHoverEnd(InteractionTarget interactionTarget)
        {
            foreach (var simView in SimulationView.SimulationViews)
            {
                simView.Repaint();
            }
        }

        void OnCreateButtonClicked()
        {
            if (m_CreateWindow != null)
                m_CreateWindow.Close();

            var selection = m_InteractionModule.CurrentSelection;
            var normalSceneView = SimulationView.NormalSceneView != null ? SimulationView.NormalSceneView : SceneView.lastActiveSceneView;

            if (selection.Count == 1)
            {
                var createProxyData = new CreateProxyFromData();
                var proxy = createProxyData.CreateImmediately(selection[0].AttachTarget.GetComponent<Proxy>());
                proxy.transform.position = normalSceneView.pivot;
                OpenCreateProxyWindow(createProxyData);
            }
            else if (selection.Count > 1)
            {
                var creator = new CreateProxyGroupFromData();
                var members = new List<PotentialChild>
                {
                    GetPotentialChild(selection[0].AttachTarget.gameObject),
                    GetPotentialChild(selection[1].AttachTarget.gameObject)
                };

                var group = creator.CreateNewProxyGroup(members);
                group.transform.position = normalSceneView.pivot;
                OpenCreateProxyGroupWindow(creator);
            }
        }

        static PotentialChild GetPotentialChild(GameObject go)
        {
            var proxy = go.GetComponent<Proxy>();
            if (proxy == null)
                return null;

            // If the selected proxy is a simulated content object, we want to get the original object
            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager != null)
            {
                var original = simulatedObjectsManager.GetOriginalObject(proxy) as Proxy;
                if (original != null)
                    proxy = original;
            }

            return new PotentialChild
            {
                sourceObject = proxy
            };;
        }

        void OpenCreateProxyWindow(CreateProxyFromData createData, bool repositionWindow = true)
        {
            var createProxyUI = new CreateProxyFromDataUI();
            createProxyUI.BindData(createData);
            createProxyUI.CountChanged += x => createData.MaxCount = x;

            if (repositionWindow)
            {
                var clickPosition = EditorWindow.focusedWindow.position.position + Event.current.mousePosition;
                m_CreateWindow = EditorWindow.GetWindow<CreateFromDataWindow>(true);
                m_CreateWindow.Open(clickPosition);
            }

            m_CreateWindow.AddNewPage(createProxyUI);

            createProxyUI.StartEditingNameField();
        }

        void OpenCreateProxyGroupWindow(CreateProxyGroupFromData createGroupData)
        {
            var createProxyGroupUI = new CreateProxyGroupFromDataUI();
            createProxyGroupUI.BindData(createGroupData);
            createProxyGroupUI.OnChildModified += createData =>
            {
                createData.EditCreatedProxy();
                OpenCreateProxyWindow(createData, false);
            };

            createProxyGroupUI.CountChanged += x => createGroupData.MaxCount = x;

            var clickPosition = EditorWindow.focusedWindow.position.position + Event.current.mousePosition;
            m_CreateWindow = EditorWindow.GetWindow<CreateFromDataWindow>(true);
            m_CreateWindow.AddNewPage(createProxyGroupUI);
            m_CreateWindow.Open(clickPosition);

            createProxyGroupUI.StartEditingNameField();
        }

        void UpdateInfoOverlayUI()
        {
            if (m_DataInfoOverlay == null)
                m_DataInfoOverlay = new DataInfoOverlay();

            var uiDisplayStyle = new StyleEnum<DisplayStyle>(m_ToolIsActive ? DisplayStyle.Flex : DisplayStyle.None);
            m_DataInfoOverlay.style.display = uiDisplayStyle;
            SimulationView.AddElementToLastHoveredWindow(m_DataInfoOverlay);

            var showOverlay = false;
            if (m_InteractionModule != null && m_InteractionModule.CurrentHoverTarget != null)
            {
                var proxy = m_InteractionModule.CurrentHoverTarget.GetComponentInParent<Proxy>();
                if (proxy != null && proxy.currentData != null)
                {
                    showOverlay = true;
                    m_DataInfoOverlay.UpdateInfo(proxy.currentData);
                }
            }

            m_DataInfoOverlay.visible = showOverlay;
        }

        void UpdateCreateUI()
        {
            if (m_CreateOverlay == null)
            {
                m_CreateOverlay = new CreateButtonsOverlay();
                m_CreateOverlay.CreateButton.clickable.clicked += OnCreateButtonClicked;
            }

            var uiDisplayStyle = new StyleEnum<DisplayStyle>(m_ToolIsActive ? DisplayStyle.Flex : DisplayStyle.None);
            m_CreateOverlay.style.display = uiDisplayStyle;

            var visible = false;
            if (m_InteractionModule != null)
            {
                // Set button visibility and text based on current selection
                var currentSelection = m_InteractionModule.CurrentSelection;
                var selectionCount = currentSelection.Count;
                if (selectionCount > 0)
                {
                    visible = true;
                    m_CreateOverlay.CreateButton.text = selectionCount > 1 ? "Create Proxy Group" : "Create Proxy";
                }

                // Set button position
                SimulationView.AddElementToLastHoveredWindow(m_CreateOverlay);
                var clickPosition = m_InteractionModule.LastSimViewClickPosition;
                var view = SimulationView.LastHoveredSimulationOrDeviceView;
                if (view != null && view.camera != null)
                {
                    var buttonPosition = view.camera.WorldToViewportPoint(clickPosition);
                    m_CreateOverlay.SetButtonsPosition(buttonPosition);
                }
            }

            m_CreateOverlay.SetButtonsVisible(visible);
        }
    }
}

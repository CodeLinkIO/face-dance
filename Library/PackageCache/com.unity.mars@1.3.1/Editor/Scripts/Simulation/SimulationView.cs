using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// MARS Simulation View displays a separate 3D scene by extending SceneView.
    /// </summary>
    //[EditorWindowTitle(useTypeNameAsIconName = false)]  // TODO update when this is not an Internal attribute
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class SimulationView : SceneView, ISimulationView, ISerializationCallbackReceiver
    {
        [Serializable]
        internal class LookAtData
        {
            public float Size;
            public Vector3 Pivot;
            public Quaternion Rotation;
        }

        [Serializable]
        class ViewSettings
        {
            [SerializeField]
            bool m_DrawGizmos;

            [SerializeField]
            bool m_SceneLighting;

            [SerializeField]
            SceneViewState m_SceneViewState;

            [SerializeField]
            bool m_In2DMode;

            [SerializeField]
            bool m_IsRotationLocked;

            [SerializeField]
            bool m_AudioPlay;

            [SerializeField]
            CameraSettings m_CameraSettings;

            [SerializeField]
            bool m_Orthographic;

            public void CopyFromSceneView(SceneView view)
            {
                m_DrawGizmos = view.drawGizmos;
                m_SceneLighting = view.sceneLighting;
                m_SceneViewState = view.sceneViewState;
                m_In2DMode = view.in2DMode;
                m_IsRotationLocked = view.isRotationLocked;
                m_AudioPlay = view.audioPlay;
                m_CameraSettings = view.cameraSettings;
                m_Orthographic = view.orthographic;
            }

            public void ApplyToSceneView(SceneView view)
            {
                view.drawGizmos = m_DrawGizmos;
                view.sceneLighting = m_SceneLighting;
                view.sceneViewState = m_SceneViewState;
                view.in2DMode = m_In2DMode;
                view.isRotationLocked = m_IsRotationLocked;
                view.audioPlay = m_AudioPlay;
                view.cameraSettings = m_CameraSettings;
                view.orthographic = m_Orthographic;
            }
        }

        class Styles
        {
            public const int HelpBoxWidth = 242;
            public const int HelpBoxHeight = 50;
            public const int HelpBoxPadding = 12;
            public const int HelpBoxLabelWidth = 190;
            public const int InfoIconPadding = 6;
            public const int DismissButtonSize = 20;

            public const int HalfHelpBoxWidth = HelpBoxWidth / 2;
            public const int HalfHelpBoxHeight = HelpBoxHeight / 2;
            public const int HelpBoxVerticalOffset = HelpBoxHeight + HelpBoxPadding;
            public const int HalfDismissButtonSize = DismissButtonSize / 2;

            public readonly Texture2D InfoIcon;
            public readonly GUIStyle HelpBoxBackgroundStyle;
            public readonly GUIStyle HelpBoxLabelStyle;
            public readonly GUIStyle DismissButtonStyle;

            public Styles()
            {
                InfoIcon = EditorGUIUtility.FindTexture("console.infoicon.sml");

                HelpBoxBackgroundStyle = GUI.skin.button;

                HelpBoxLabelStyle = new GUIStyle(GUI.skin.label)
                {
                    wordWrap = true,
                    fontSize = 10,
                    padding = new RectOffset(0, 0, 0, 0)
                };

                DismissButtonStyle = GUIStyle.none;
                DismissButtonStyle.normal.textColor = Color.white;
            }
        }

        /// <summary>
        /// Title of the window when in simulation view mode
        /// </summary>
        public const string SimulationViewWindowTitle = "Simulation View";
        /// <summary>
        /// Title of the window when in device view mode
        /// </summary>
        public const string DeviceViewWindowTitle = "Device View";

        const string k_CustomMARSViewWindowTitle = "Custom MARS View";
        const string k_SceneBackgroundPrefsKey = "Scene/Background";
        const string k_DeviceControlsHelp = "Press 'Play' in the Simulation controls, then hold the right mouse button to look around, and WASD to move.";
        static readonly List<SimulationView> k_SimulationViews = new List<SimulationView>();

        static SimulationView s_ActiveSimulationView;
        static SceneView s_LastHoveredSimulationOrDeviceView;
        static Styles s_Styles;

        [SerializeField]
        ViewSceneType m_SceneType = ViewSceneType.None;

        [SerializeField]
        bool m_EnvironmentSceneActive;

        [SerializeField]
        bool m_DesaturateInactive;

        [SerializeField]
        bool m_UseXRay = true;

        [SerializeField]
        ViewSettings m_SimSceneViewSettings;

        [SerializeField]
        ViewSettings m_SimCameraViewSettings;

        [SerializeField]
        LookAtData m_DefaultLookAtData;

        [SerializeField]
        List<GameObject> m_EnvironmentPrefabs = new List<GameObject>();

        [SerializeField]
        List<LookAtData> m_LookAtDataList = new List<LookAtData>();

        readonly Dictionary<GameObject, LookAtData> m_LookAtDataPerEnvironment = new Dictionary<GameObject, LookAtData>();

        bool m_FramedOnStart;
        Bounds m_MovementBounds;

        CameraFPSModeHandler m_FPSModeHandler;
        Vector2 m_MouseDelta;
        int m_EventButton;
        bool m_UpdateEventButton;

        GUIContent m_SimulationViewTitleContent;
        GUIContent m_DeviceViewTitleContent;
        GUIContent m_CustomViewTitleContent;

        GUIContent CurrentTitleContent
        {
            get
            {
                switch (SceneType)
                {
                    case ViewSceneType.Simulation:
                        return m_SimulationViewTitleContent;
                    case ViewSceneType.Device:
                        return m_DeviceViewTitleContent;
                    default:
                        return m_CustomViewTitleContent;
                }
            }
        }

        bool UseMovementBounds => MarsUserPreferences.RestrictCameraToEnvironmentBounds && m_MovementBounds != default;

        /// <summary>
        /// The editor background color form the user's editor preferences
        /// </summary>
        public static Color EditorBackgroundColor => EditorMaterialUtils.PrefToColor(EditorPrefs.GetString(k_SceneBackgroundPrefsKey));

        /// <summary>
        /// Whether this view is in Sim or Device mode
        /// </summary>
        public ViewSceneType SceneType
        {
            get => m_SceneType;
            set => SetupSceneTypeData(value);
        }

        /// <summary>
        /// The primary scene view.  Not a Simulation View.
        /// </summary>
        public static SceneView NormalSceneView { get; private set; }

        /// <summary>
        /// List of all Simulation Views
        /// </summary>
        public static List<SimulationView> SimulationViews => k_SimulationViews;

        /// <summary>
        /// The last Simulation View the user focused
        /// </summary>
        public static SceneView ActiveSimulationView
        {
            get
            {
                if (!s_ActiveSimulationView && k_SimulationViews.Count > 0)
                    s_ActiveSimulationView = k_SimulationViews[0];

                return s_ActiveSimulationView;
            }
        }

        /// <summary>
        /// The Simulation or Device View that was most recently hovered by the mouse
        /// </summary>
        public static SceneView LastHoveredSimulationOrDeviceView
        {
            get
            {
                if (s_LastHoveredSimulationOrDeviceView == null)
                    return ActiveSimulationView;

                return s_LastHoveredSimulationOrDeviceView;
            }
            private set { s_LastHoveredSimulationOrDeviceView = value; }
        }

        /// <summary>
        /// Is the simulation environment layer the active scene in the view
        /// </summary>
        public bool EnvironmentSceneActive
        {
            get { return m_EnvironmentSceneActive; }
            set
            {
                m_EnvironmentSceneActive = value;

                if (!CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                    return;

                context.SetBackgroundSceneActive(value);
            }
        }

        /// <summary>
        /// Desaturate the inactive composite layer
        /// </summary>
        public bool DesaturateInactive
        {
            get { return m_DesaturateInactive; }
            set
            {
                m_DesaturateInactive = value;

                if (!CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                    return;

                context.DesaturateComposited = value;
            }
        }

        /// <summary>
        /// Use x-ray rendering in the view
        /// </summary>
        public bool UseXRay
        {
            get { return m_UseXRay; }
            set
            {
                m_UseXRay = value;
                if (!CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                    return;

                context.UseXRay = value;
            }
        }

        // Delay creation of Styles till first access
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        static bool useFallbackRendering => CompositeRenderModuleOptions.instance.UseFallbackCompositeRendering;

        /// <summary>
        /// Initialize the the simulation view window in simulation view mode.
        /// </summary>
        [MenuItem(MenuConstants.MenuPrefix + SimulationViewWindowTitle, priority = MenuConstants.SimulationViewPriority)]
        public static void InitWindowInSimulationView()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = SimulationViewWindowTitle, active = true});
            if (!FindNormalSceneView())
            {
                NormalSceneView = GetWindow<SceneView>();
                NormalSceneView.Show();
            }

            var window = GetWindow<SimulationView>();
            window.SceneType = ViewSceneType.Simulation;
            s_ActiveSimulationView = window;
            window.Show();
            window.ShowTab();
        }

        internal static void NewTabSimulationView(object userData)
        {
            if (!FindNormalSceneView())
            {
                NormalSceneView = MarsEditorUtils.CustomAddTabToHere(typeof(SceneView)) as SceneView;
                NormalSceneView.Show();
            }

            if (MarsEditorUtils.CustomAddTabToHere(userData) is SimulationView window)
            {
                window.SceneType = ViewSceneType.Simulation;
                s_ActiveSimulationView = window;
            }

            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = SimulationViewWindowTitle, active = true});
        }

        /// <summary>
        /// Initialize the the simulation view window in device view mode.
        /// </summary>
        [MenuItem(MenuConstants.MenuPrefix + DeviceViewWindowTitle, priority = MenuConstants.DeviceViewPriority)]
        public static void InitWindowInDeviceView()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = DeviceViewWindowTitle, active = true});
            if (!FindNormalSceneView())
            {
                NormalSceneView = GetWindow<SceneView>();
                NormalSceneView.Show();
            }

            var window = GetWindow<SimulationView>();
            window.SceneType = ViewSceneType.Device;
            window.Show();
            window.ShowTab();
        }

        internal static void NewTabDeviceView(object userData)
        {
            if (!FindNormalSceneView())
            {
                NormalSceneView = MarsEditorUtils.CustomAddTabToHere(typeof(SceneView)) as SceneView;
                NormalSceneView.Show();
            }

            if (MarsEditorUtils.CustomAddTabToHere(userData) is SimulationView window)
                window.SceneType = ViewSceneType.Device;

            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = DeviceViewWindowTitle, active = true});
        }

        internal static void EnsureDeviceViewAvailable()
        {
            foreach (var simView in SimulationViews)
            {
                if (simView.SceneType == ViewSceneType.Device)
                    return;
            }

            if (!FindNormalSceneView())
            {
                NormalSceneView = GetWindow<SceneView>();
                NormalSceneView.Show();
            }

            var window = GetWindow<SimulationView>();
            window.SceneType = ViewSceneType.Device;
            window.Show();
            window.ShowTab();
        }

        /// <summary>
        /// Scene view does not support stage handling and will not switch when stage is changed
        /// </summary>
        /// <returns><c>False</c> view will not change when the stage is changed</returns>
        protected override bool SupportsStageHandling() { return false; }

        /// <inheritdoc/>
        public override void AddItemsToMenu(GenericMenu menu)
        {
            this.MarsCustomMenuOptions(menu);
            base.AddItemsToMenu(menu);
        }

        /// <inheritdoc/>
        public override void OnEnable()
        {
            // Suppress the error message about missing scene icon. It is not an exception, but in case any other
            // exceptions happen in base.OnEnable, we use try/catch to log them re-enable logging
            var logEnabled = Debug.unityLogger.logEnabled;
            try
            {
                Debug.unityLogger.logEnabled = false;
                base.OnEnable();
            }
            catch (Exception e)
            {
                Debug.LogFormat("Exception in SimulationView.OnEnable: {0}\n{1}", e.Message, e.StackTrace);
            }
            finally
            {
                Debug.unityLogger.logEnabled = logEnabled;
            }

            m_SimulationViewTitleContent = new GUIContent(SimulationViewWindowTitle, MarsUIResources.instance.SimulationViewIcon);
            m_DeviceViewTitleContent = new GUIContent(DeviceViewWindowTitle, MarsUIResources.instance.SimulationViewIcon);
            m_CustomViewTitleContent = new GUIContent(k_CustomMARSViewWindowTitle, MarsUIResources.instance.SimulationViewIcon);

            titleContent = CurrentTitleContent;
            autoRepaintOnSceneChange = true;

            k_SimulationViews.Add(this);

            // Name our scene view camera so it is easier to track
            camera.name = $"{SimulationViewWindowTitle} Camera {GetInstanceID()}";
            camera.gameObject.hideFlags = HideFlags.HideAndDontSave;

            m_FPSModeHandler = new CameraFPSModeHandler();

            var moduleLoaderCore = ModuleLoaderCore.instance;
            // Used for one time module subscribing and setup of values from environment manager
            if (moduleLoaderCore.ModulesAreLoaded)
            {
                EditorApplication.delayCall += OnModulesLoaded;
            }

            moduleLoaderCore.ModulesLoaded += OnModulesLoaded;

            if (SceneType == ViewSceneType.None)
                SceneType = ViewSceneType.Simulation;
        }

        void OnModulesLoaded()
        {
            var moduleLoaderCore = ModuleLoaderCore.instance;
            var environmentManager = moduleLoaderCore.GetModule<MARSEnvironmentManager>();
            var compositeRenderViewModule = moduleLoaderCore.GetModule<CompositeRenderModule>();

            // These will be null in module tests
            if (environmentManager == null || compositeRenderViewModule == null)
                return;

            MARSEnvironmentManager.onEnvironmentSetup += OnEnvironmentSetup;
            if (environmentManager.EnvironmentSetup)
                OnEnvironmentSetup();
        }

        void OnEnvironmentSetup()
        {
            m_MovementBounds = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>().EnvironmentBounds;
            // Need to make sure camera is assigned to the sim scene if scene has changed.
            SetupViewAsSimUser();
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            var moduleLoaderCore = ModuleLoaderCore.instance;
            moduleLoaderCore.ModulesLoaded -= OnModulesLoaded;

            MARSEnvironmentManager.onEnvironmentSetup -= OnEnvironmentSetup;

            if (CompositeRenderModule.GetActiveCompositeRenderModule(out var renderModule))
                renderModule.RemoveView(this);

            k_SimulationViews.Remove(this);
            m_FPSModeHandler.StopMoveInput(Vector2.zero);
            m_FPSModeHandler = null;

            CheckActiveSimulationView();

            base.OnDisable();
        }

        /// <summary>
        /// OnDestroy is called to close the EditorWindow window.
        /// </summary>
        protected new virtual void OnDestroy()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = "Simulation View", active = false});
            base.OnDestroy();
        }

        void OnFocus()
        {
            if (SceneType != ViewSceneType.Simulation)
                return;

            s_ActiveSimulationView = this;
        }

        void Update()
        {
            if (maximized)
                return;

            // Check if normal scene view is closed and close simulation because otherwise Window -> Scene will focus
            // simulation view instead of reopening normal scene view
            if (NormalSceneView == null && !FindNormalSceneView())
                Close();
        }

        static bool FindNormalSceneView()
        {
            var allSceneViews = Resources.FindObjectsOfTypeAll(typeof (SceneView)) as SceneView[];
            if (allSceneViews == null)
                return false;

            foreach (var view in allSceneViews)
            {
                if (view is SimulationView)
                    continue;

                NormalSceneView = view;
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        protected override void OnGUI()
        {
            if (!MARSEntitlements.instance.EntitlementsCheckGUI(position.width))
                return;

            // Custom Scene is the target for drag and drop and is needed for Scene Placement Module
            customScene = camera.scene;

            // Called before base.OnGUI to consume input
            this.DrawSimulationViewToolbar();

            var currentEvent = Event.current;
            var type = currentEvent.type;
            if (type == EventType.MouseDrag)
                m_MouseDelta = currentEvent.delta;

            var resetEventButton = false;
            if (type == EventType.MouseDown)
            {
                m_EventButton = currentEvent.button;
                m_UpdateEventButton = true;
            }
            else if (type == EventType.MouseUp)
            {
                resetEventButton = true;
            }

            base.OnGUI();
            this.DrawSimulationViewToolbar();

            var toolbarHeightOffset = MarsEditorGUI.Styles.ToolbarHeight - 1;
            var rect = new Rect(0, toolbarHeightOffset, position.width,
                position.height - toolbarHeightOffset);

            var simulationSettings = SimulationSettings.instance;

            if (SceneType == ViewSceneType.Device)
            {
                var moduleLoader = ModuleLoaderCore.instance;
                var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
                var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();

                if (focusedWindow == this && environmentManager != null && environmentManager.IsMovementEnabled &&
                    // User has pressed "Play" on device mode to move.
                    querySimulationModule != null && querySimulationModule.simulatingTemporal)
                {
                    if (m_UpdateEventButton)
                        currentEvent.button = m_EventButton;

                    m_FPSModeHandler.MovementBounds = m_MovementBounds;
                    m_FPSModeHandler.UseMovementBounds = UseMovementBounds;
                    m_FPSModeHandler.HandleGUIInput(rect, currentEvent, type, m_MouseDelta);
                }
                else
                {
                    m_FPSModeHandler.StopMoveInput(currentEvent.mousePosition);
                }
            }

            if (resetEventButton)
                m_UpdateEventButton = false;

            if (mouseOverWindow != null && mouseOverWindow is SimulationView view)
                LastHoveredSimulationOrDeviceView = view;

            var helpMessageDisplayed = SimulationControlsGUI.DrawHelpArea(SceneType);

            if (!helpMessageDisplayed && SceneType == ViewSceneType.Device &&
                MarsHints.ShowDeviceViewControlsHint)
            {
                if (simulationSettings.EnvironmentMode == EnvironmentMode.Synthetic && !simulationSettings.UseSyntheticRecording)
                {
                    DrawDeviceViewControlsHint();
                }
            }

            UpdateCamera();
        }

        void DrawDeviceViewControlsHint()
        {
            var helpBoxPosition = new Vector2(
                position.width / 2f - Styles.HalfHelpBoxWidth,
                position.height - Styles.HelpBoxVerticalOffset);
            var helpBoxRect = new Rect(helpBoxPosition.x, helpBoxPosition.y, Styles.HelpBoxWidth, Styles.HelpBoxHeight);

            GUI.Box(helpBoxRect, string.Empty, styles.HelpBoxBackgroundStyle);

            var iconRect = new Rect(helpBoxPosition.x + Styles.InfoIconPadding + 2,
                helpBoxPosition.y + Styles.HalfHelpBoxHeight - styles.InfoIcon.height / 2f, styles.InfoIcon.width, styles.InfoIcon.height);
            GUI.DrawTexture(iconRect, styles.InfoIcon);

            var labelRect = new Rect(iconRect.x + iconRect.width + Styles.InfoIconPadding, helpBoxPosition.y,
                Styles.HelpBoxLabelWidth, Styles.HelpBoxHeight);
            GUI.Label(labelRect, k_DeviceControlsHelp, styles.HelpBoxLabelStyle);

            var dismissButtonRect = new Rect(helpBoxRect.x + Styles.HelpBoxWidth - Styles.DismissButtonSize,
                helpBoxRect.y + Styles.HalfHelpBoxHeight - Styles.HalfDismissButtonSize + 2, Styles.DismissButtonSize, Styles.DismissButtonSize);

            if (GUI.Button(dismissButtonRect, "✕", styles.DismissButtonStyle))
                MarsHints.ShowDeviceViewControlsHint = false;
        }

        internal static void AddElementToLastHoveredWindow(VisualElement element)
        {
            var view = LastHoveredSimulationOrDeviceView;
            if (view != null && element.parent != view.rootVisualElement)
            {
                view.rootVisualElement.Add(element);
                element.BringToFront();
            }
        }

        /// <summary>
        /// Cache the LookAt information for the current synthetic environment
        /// </summary>
        /// <param name="point">The position in world space to frame.</param>
        /// <param name="direction">The direction that the Scene view should view the target point from.</param>
        /// <param name="newSize">The amount of camera zoom. Sets <c>size</c>.</param>
        public void CacheLookAt(Vector3 point, Quaternion direction, float newSize)
        {
            var environment = SimulationSettings.instance.EnvironmentPrefab;
            if (environment == null)
                return;

            var lookAtData = new LookAtData { Pivot = point, Rotation = direction, Size = Mathf.Abs(newSize) };
            m_LookAtDataPerEnvironment[environment] = lookAtData;
        }

        /// <inheritdoc/>
        public void SetupViewAsSimUser(bool forceFrame = false)
        {
            switch (SceneType)
            {
                case ViewSceneType.Simulation:
                case ViewSceneType.Device:
                {
                    if (camera == null)
                        break;

                    if (CompositeRenderModule.TryGetCompositeRenderContext(this, out var context))
                    {
                        context.SetBackgroundColor(EditorBackgroundColor);
                        context.AssignCameraToSimulation();
                    }

                    if (!m_FramedOnStart || forceFrame)
                    {
                        MARSEnvironmentManager.instance.TryFrameSimViewOnEnvironment(this, true);
                        m_FramedOnStart = true;
                    }

                    break;
                }
                default:
                {
                    Debug.LogFormat("Scene type {0} not supported in Simulation View.", SceneType);
                    SceneType = ViewSceneType.Simulation;
                    break;
                }
            }
        }

        internal void UpdateCamera()
        {
            if (SceneType != ViewSceneType.Device)
                return;

            // Do not let Device View enter orthographic mode
            orthographic = false;
            in2DMode = false;
            isRotationLocked = true;

            var controllingCamera = MarsRuntimeUtils.GetActiveCamera();

            if (controllingCamera == null)
            {
                var envManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
                var devicePose = envManager == null ? Pose.identity : envManager.DeviceStartingPose;
                rotation = devicePose.rotation;
                size = 1f; // Size is locked when there is no controlling camera to prevent clip planes from changing
                pivot = devicePose.position + (devicePose.rotation * Vector3.forward) * cameraDistance;
                return;
            }

            var controllingCameraTransform = controllingCamera.transform;

            // need to set size before FOV and clip planes
            size = MARSSession.GetWorldScale();
            camera.fieldOfView = controllingCamera.fieldOfView;
            camera.nearClipPlane = controllingCamera.nearClipPlane;
            camera.farClipPlane = controllingCamera.farClipPlane;

            if (controllingCamera.usePhysicalProperties)
            {
                camera.usePhysicalProperties = true;
                camera.focalLength = controllingCamera.focalLength;
            }
            else
            {
                camera.usePhysicalProperties = false;
            }

            rotation = controllingCameraTransform.rotation;
            pivot = controllingCameraTransform.position + controllingCameraTransform.forward * cameraDistance;
        }

        void SetupSceneTypeData(ViewSceneType newType)
        {
            if (m_SceneType == newType)
                return;

            var oldType = m_SceneType;
            switch (oldType)
            {
                case ViewSceneType.Simulation:
                    if (m_SimSceneViewSettings == null)
                        m_SimSceneViewSettings = new ViewSettings();

                    m_SimSceneViewSettings.CopyFromSceneView(this);
                    SaveSceneViewLookAtData();
                    break;
                case ViewSceneType.Device:
                    if (m_SimCameraViewSettings == null)
                        m_SimCameraViewSettings = new ViewSettings();

                    m_SimCameraViewSettings.CopyFromSceneView(this);
                    break;
            }

            switch (newType)
            {
                case ViewSceneType.Simulation:
                    m_SimSceneViewSettings?.ApplyToSceneView(this);
                    ApplySavedLookAtToSceneView();
                    break;
                case ViewSceneType.Device:
                    m_SimCameraViewSettings?.ApplyToSceneView(this);
                    break;
            }

            m_SceneType = newType;
            titleContent = CurrentTitleContent;

            switch (newType)
            {
                case ViewSceneType.None:
                    CheckActiveSimulationView();
                    break;
                case ViewSceneType.Simulation:
                    s_ActiveSimulationView = this;
                    break;
                case ViewSceneType.Device:
                    CheckActiveSimulationView();
                    drawGizmos = false;
                    in2DMode = false;
                    isRotationLocked = true;
                    sceneLighting = true;
                    orthographic = false;
                    break;
            }
        }

        void CheckActiveSimulationView()
        {
            if (s_ActiveSimulationView != this)
                return;

            for (var i = k_SimulationViews.Count - 1; i >= 0; i--)
            {
                if (k_SimulationViews[i].SceneType != ViewSceneType.Simulation)
                    continue;

                s_ActiveSimulationView = k_SimulationViews[i];
                return;
            }
        }

        void SaveSceneViewLookAtData()
        {
            if (m_DefaultLookAtData == null)
                m_DefaultLookAtData = new LookAtData();

            var activeLookAtData = m_DefaultLookAtData;
            var simulationSettings = SimulationSettings.instance;
            if (simulationSettings.EnvironmentMode == EnvironmentMode.Synthetic)
            {
                var environment = simulationSettings.EnvironmentPrefab;
                if (environment != null && m_LookAtDataPerEnvironment.ContainsKey(environment))
                    activeLookAtData = m_LookAtDataPerEnvironment[environment];
            }

            CopyLookAtFromViewWithInverseWorldOffset(activeLookAtData);
        }

        void ApplySavedLookAtToSceneView()
        {
            var simulationSettings = SimulationSettings.instance;
            if (simulationSettings.EnvironmentMode == EnvironmentMode.Synthetic)
            {
                var environment = simulationSettings.EnvironmentPrefab;
                if (environment != null)
                {
                    if (m_LookAtDataPerEnvironment.TryGetValue(environment, out var lookAtData))
                        ApplyLookAtToViewWithWorldOffset(lookAtData);

                    return;
                }
            }

            if (m_DefaultLookAtData != null)
                ApplyLookAtToViewWithWorldOffset(m_DefaultLookAtData);
        }

        internal void SaveCurrentLookAtForEnvironment(GameObject environmentPrefab)
        {
            if (!m_LookAtDataPerEnvironment.TryGetValue(environmentPrefab, out var lookAtData))
            {
                lookAtData = new LookAtData();
                m_LookAtDataPerEnvironment[environmentPrefab] = lookAtData;
            }

            CopyLookAtFromViewWithInverseWorldOffset(lookAtData);
        }

        internal bool TryGetLookAtForEnvironment(GameObject environmentPrefab, out LookAtData lookAtData)
        {
            return m_LookAtDataPerEnvironment.TryGetValue(environmentPrefab, out lookAtData);
        }

        void ApplyLookAtToViewWithWorldOffset(LookAtData rawLookAtData)
        {
            var positionOffset = Vector3.zero;
            var rotationOffset = Quaternion.identity;
            var worldScale = 1f;
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            if (environmentManager != null)
            {
                var environmentParent = environmentManager.EnvironmentParent;
                if (environmentParent != null)
                {
                    var environmentParentTrans = environmentParent.transform;
                    positionOffset = environmentParentTrans.position;
                    rotationOffset = environmentParentTrans.rotation;
                    worldScale = environmentParentTrans.localScale.x;
                }
            }

            pivot = rotationOffset * rawLookAtData.Pivot * worldScale + positionOffset;
            size = rawLookAtData.Size * worldScale;
            rotation = rotationOffset * rawLookAtData.Rotation;
        }

        void CopyLookAtFromViewWithInverseWorldOffset(LookAtData lookAtData)
        {
            var inversePositionOffset = Vector3.zero;
            var inverseRotationOffset = Quaternion.identity;
            var inverseWorldScale = 1f;
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            if (environmentManager != null)
            {
                var environmentParent = environmentManager.EnvironmentParent;
                if (environmentParent != null)
                {
                    var environmentParentTrans = environmentParent.transform;
                    inversePositionOffset = -environmentParentTrans.position;
                    inverseRotationOffset = Quaternion.Inverse(environmentParentTrans.rotation);
                    inverseWorldScale = 1f / environmentParentTrans.localScale.x;
                }
            }

            lookAtData.Pivot = inverseRotationOffset * (pivot + inversePositionOffset) * inverseWorldScale;
            lookAtData.Rotation = inverseRotationOffset * rotation;
            lookAtData.Size = size * inverseWorldScale;
        }

        /// <inheritdoc />
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            m_EnvironmentPrefabs.Clear();
            m_LookAtDataList.Clear();
            foreach (var kvp in m_LookAtDataPerEnvironment)
            {
                m_EnvironmentPrefabs.Add(kvp.Key);
                m_LookAtDataList.Add(kvp.Value);
            }
        }

        /// <inheritdoc />
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            m_LookAtDataPerEnvironment.Clear();
            var prefabsCount = m_EnvironmentPrefabs.Count;
            var lookAtCount = m_LookAtDataList.Count;

            if (prefabsCount != lookAtCount)
                Debug.LogError("Environment prefabs list and look-at data list have gone out of sync");

            for (var i = 0; i < prefabsCount; ++i)
            {
                var environment = m_EnvironmentPrefabs[i];
                if (environment != null)
                    m_LookAtDataPerEnvironment[environment] = m_LookAtDataList[i];
            }
        }
    }
}

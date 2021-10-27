using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.MARS;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Describes the environment mode the simulation is in.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum EnvironmentMode
    {
        /// <summary>Environment with virtual objects loaded from a prefab.</summary>
        Synthetic,
        /// <summary>Environment from recorded session.</summary>
        Recorded,
        /// <summary>Environment from connected webcam.</summary>
        Live,
        /// <summary>Environment from <code>SimulationEnvironmentModeSettings</code>.</summary>
        Custom,
        /// <summary>.Environment for connected remote session.</summary>
        Remote
    }

    /// <summary>
    /// Module responsible for setting up and switching between simulation environments of different types.
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public partial class MARSEnvironmentManager : EditorScriptableSettings<MARSEnvironmentManager>,
        IModuleDependency<SimulationRecordingManager>, IModuleDependency<QuerySimulationModule>,
        IModuleDependency<SimulationSceneModule>, IModuleDependency<MarsWorldScaleModule>,
        IModuleDependency<FunctionalityInjectionModule>, IModuleDependency<SimulatedObjectsManager>,
        IModuleDependency<SimulationVideoContextManager>, IProvidesDeviceSimulationSettings
    {
        enum SimulatedRendererType
        {
            Environment,
            Data
        }

        /// <summary>
        /// Asset label used to collect environment prefabs
        /// </summary>
        public const string EnvironmentLabel = "Environment";

        internal const string DefaultEnvironmentLabel = "DefaultEnv";
        internal const string NoModeSettingsName = "Custom (No Settings)";

        const string k_PrefabSearchPrefix = "t:prefab l:";
        const string k_EnvironmentPrefabFilter = k_PrefabSearchPrefix + EnvironmentLabel;
        const string k_DefaultEnvironmentPrefabFilter = k_PrefabSearchPrefix + DefaultEnvironmentLabel;
        const string k_OnDestroyNotifierName = "OnDestroyNotifier";
        const string k_NoSyntheticEnvironmentsTitle = "No Synthetic Simulation Environments";
        const string k_NoSyntheticEnvironmentsMessage =
            "No synthetic simulation environments found. Create a prefab to use as an environment, and label the " +
            "asset as 'Environment'. See the MARS documentation for more detail.";

        const string k_EnvironmentModifiedDialogTitle = "Synthetic environment modified";
        const string k_EnvironmentModifiedDialogMessage = "Do you want to save the changes you made to the synthetic environment? Your changes will be lost if you don't save them.";
        const string k_EnvironmentModifiedDialogOkButton = "Save";
        const string k_EnvironmentModifiedDialogCancelButton = "Cancel";
        const string k_EnvironmentModifiedDialogAltButton = "Discard Changes";
        static readonly string[] k_RootIgnoreProperties = { "m_Layer", "m_Name", "m_LocalPosition", "m_LocalRotation",
            "m_RootOrder", "m_LocalEulerAnglesHint", "m_LocalScale", "m_AnchoredPosition3D", "MinDistance", "MaxDistance",
            "m_MinDistance", "m_MaxDistance", "m_Range", "m_Shadows.m_Bias", "m_CullingMask.m_Bits" };

        static readonly string[] k_WorldScaleIgnoreProperties = { "m_Layer", "MinDistance", "MaxDistance", "m_MinDistance",
            "m_MaxDistance", "m_Range", "m_Shadows.m_Bias", "m_CullingMask.m_Bits" };

        const string k_LayerPropertyName = "m_Layer";

        static readonly GUIContent[] k_NoModesGUIContents = { new GUIContent("No Environment Modes Loaded") };

        static OnDestroyNotifier s_OnDestroyNotifier;
        static GUIContent[] s_ModeTypes = k_NoModesGUIContents;

        /// <summary>
        /// Gui contents generated from the available <c>EnvironmentMode</c>s
        /// </summary>
        public static GUIContent[] ModeTypes => s_ModeTypes;

        [HideInInspector]
        [SerializeField]
        bool m_PackageContentImported;

#pragma warning disable 649
        [SerializeField]
        [Tooltip("The settings used for the Custom EnvironmentMode")]
        SimulationEnvironmentModeSettings m_SimulationEnvironmentModeSettings;
#pragma warning restore 649

        int m_CurrentSyntheticEnvironmentIndex = -1;

        QuerySimulationModule m_QuerySimulationModule;
        MarsWorldScaleModule m_WorldScaleModule;
        SimulationSceneModule m_SimulationSceneModule;
        FunctionalityInjectionModule m_FIModule;
        SimulatedObjectsManager m_SimulatedObjectsManager;
        SimulationRecordingManager m_SimulationRecordingManager;
        SimulationVideoContextManager m_VideoContextManager;
        GeoLocationModule m_GeoLocationModule;

        GUIContent[] m_EnvironmentGUIContents;

        GameObject m_CurrentEnvironmentPrefab;
        MARSEnvironmentSettings m_CurrentPrefabInstanceEnvironmentSettings;
        bool m_PrefabUpdatingByScriptLock;

        readonly List<string> m_EnvironmentPrefabPaths = new List<string>();
        readonly List<string> m_EnvironmentPrefabNames = new List<string>();
        readonly List<Light> m_SimulationLights = new List<Light>();

        internal GUIContent[] EnvironmentGUIContents => m_EnvironmentGUIContents;

        /// <summary>
        /// Called when the simulated environment is setup and calls <code>EditorOnlyEvents.OnEnvironmentSetup</code>
        /// </summary>
        public static event Action onEnvironmentSetup;

        /// <summary>
        /// The pose of the device when a simulation starts
        /// </summary>
        public Pose DeviceStartingPose { get; private set; }

        /// <summary>
        /// Whether there is currently a simulation environment setup
        /// </summary>
        public bool EnvironmentSetup { get; private set; }

        /// <summary>
        /// Metadata about the current synthetic environment scene
        /// </summary>
        internal MARSEnvironmentInfo SyntheticEnvironmentInfo { get; private set; }

        /// <summary>
        /// List of the synthetic environment prefab paths
        /// </summary>
        internal List<string> EnvironmentPrefabPaths => m_EnvironmentPrefabPaths;

        /// <summary>
        /// List of the synthetic environment prefab names
        /// </summary>
        internal List<string> EnvironmentPrefabNames => m_EnvironmentPrefabNames;

        /// <summary>
        /// Bounds encapsulating the whole environment
        /// </summary>
        public Bounds EnvironmentBounds => SyntheticEnvironmentInfo?.EnvironmentBounds ?? default;

        /// <summary>
        /// Is movement enabled in the current environment and mode
        /// </summary>
        public bool IsMovementEnabled => SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic
            || (SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Custom && HasCustomModeSettings
                && m_SimulationEnvironmentModeSettings.IsMovementEnabled);

        /// <summary>
        /// Is framing the simulation from a simulation view enabled in the current environment and mode
        /// </summary>
        public bool IsFramingEnabled => SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic
            || (SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Custom && HasCustomModeSettings
                && m_SimulationEnvironmentModeSettings.IsFramingEnabled);

        /// <summary>
        /// The voxel size of the <c>PlaneExtractionSettings</c> in the current environment
        /// </summary>
        public float? VoxelSizeFromEnvironment
        {
            get
            {
                if (!m_CurrentPrefabInstanceEnvironmentSettings)
                    return null;
                var planeExtractionSettings = m_CurrentPrefabInstanceEnvironmentSettings.GetComponent<PlaneExtractionSettings>();
                if (planeExtractionSettings && (planeExtractionSettings.VoxelGenerationParams!=null))
                    return planeExtractionSettings.VoxelGenerationParams.voxelSize;
                return null;
            }
        }

        /// <summary>
        /// Name of the current synthetic environment prefab
        /// </summary>
        public string SyntheticEnvironmentName
        {
            get
            {
                return currentSyntheticEnvironmentIndexIsValid
                    ? EnvironmentPrefabNames[CurrentSyntheticEnvironmentIndex]
                    : string.Empty;
            }
        }

        bool currentSyntheticEnvironmentIndexIsValid
        {
            get
            {
                return
                    SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic
                    && CurrentSyntheticEnvironmentIndex >= 0
                    && CurrentSyntheticEnvironmentIndex < EnvironmentPrefabNames.Count;
            }
        }

        /// <summary>
        /// The default device starting pose for a synthetic environment
        /// </summary>
        public Pose DefaultDeviceStartingPose
        {
            get { return SyntheticEnvironmentInfo != null ? SyntheticEnvironmentInfo.SimulationStartingPose : default(Pose); }
        }

        /// <summary>
        /// The root object that environment objects are added to
        /// </summary>
        public GameObject EnvironmentParent { get; private set; }

        /// <summary>
        /// Checks whether any synthetic environment prefab have been found
        /// </summary>
        public bool SyntheticEnvironmentsExist => m_EnvironmentPrefabPaths.Count != 0;

        /// <summary>
        /// Index of the currently active synthetic environment in the m_EnvironmentPrefabsPaths list
        /// </summary>
        public int CurrentSyntheticEnvironmentIndex => m_CurrentSyntheticEnvironmentIndex;

        /// <summary>
        /// The currently loaded synthetic environment mode prefab instance
        /// </summary>
        public GameObject CurrentLoadedPrefabInstanceEnvironment { get; private set; }

        /// <summary>
        /// Does the environment manager have a custom mode assigned
        /// </summary>
        public bool HasCustomModeSettings => m_SimulationEnvironmentModeSettings != null;

        /// <summary>
        /// The custom mode settings assigned to the environment manager
        /// </summary>
        public SimulationEnvironmentModeSettings CustomModeSettings
        {
            get => m_SimulationEnvironmentModeSettings;
            internal set => m_SimulationEnvironmentModeSettings = value;
        }

        /// <summary>
        /// Event callback for when the simulated environment has changed
        /// </summary>
        public event Action EnvironmentChanged;

        /// <summary>
        /// Callback for when the offset applied to the simulated environment has changed
        /// </summary>
        internal event Action EnvironmentOffsetChanged;

        internal bool SavingEnvironment { get; private set; }

        /// <inheritdoc />
        void IModuleDependency<QuerySimulationModule>.ConnectDependency(QuerySimulationModule dependency) { m_QuerySimulationModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulationSceneModule>.ConnectDependency(SimulationSceneModule dependency) { m_SimulationSceneModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<FunctionalityInjectionModule>.ConnectDependency(FunctionalityInjectionModule dependency) { m_FIModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<MarsWorldScaleModule>.ConnectDependency(MarsWorldScaleModule dependency) { m_WorldScaleModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulatedObjectsManager>.ConnectDependency(SimulatedObjectsManager dependency) { m_SimulatedObjectsManager = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulationRecordingManager>.ConnectDependency(SimulationRecordingManager dependency) { m_SimulationRecordingManager = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulationVideoContextManager>.ConnectDependency(SimulationVideoContextManager dependency) { m_VideoContextManager = dependency; }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            SimulationSceneModule.SimulationSceneOpened += SetupEnvironment;
            SimulationSceneModule.SimulationSceneClosing += TearDownEnvironmentNotCancelable;
            EditorOnlyDelegates.IsEnvironmentPrefab = IsEnvironmentPrefab;
            EditorOnlyDelegates.CullEnvironmentFromSceneLights = CullEnvironmentFromSceneLights;
            EditorOnlyDelegates.IsEnvironmentSetup = () => EnvironmentSetup;
            EditorOnlyDelegates.SwitchToNextEnvironment = ForceSetupNextEnvironment;
            onEnvironmentSetup += EditorOnlyEvents.OnEnvironmentSetup;
            PrefabUtility.prefabInstanceUpdated += OnPrefabInstanceUpdated;
            Undo.undoRedoPerformed += SetSimulationLightsCullingMask;

            EditorApplication.wantsToQuit += OnEditorWantsToQuit;
            QuerySimulationModule.onTemporalSimulationStart += OnTemporalSimulationStart;
            QuerySimulationModule.BeforeSimulationSetup += OnBeforeSimulationSetup;

            GetSimulatedEnvironmentCandidates();

            var marsSession = Application.isPlaying ? MARSSession.Instance : MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (marsSession != null && marsSession.requirements != null)
                SimulationSettings.instance.ApplyEnvironmentModeFromCameraFacing(marsSession.requirements.RequiredCameraFacing);
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            EditorApplication.wantsToQuit -= OnEditorWantsToQuit;

            SimulationSceneModule.SimulationSceneOpened -= SetupEnvironment;
            SimulationSceneModule.SimulationSceneClosing -= TearDownEnvironmentNotCancelable;
            Undo.undoRedoPerformed -= SetSimulationLightsCullingMask;

            EditorOnlyDelegates.IsEnvironmentPrefab = null;

            TearDownEnvironmentNotCancelable();

            EditorOnlyDelegates.CullEnvironmentFromSceneLights = null;
            EditorOnlyDelegates.IsEnvironmentSetup = null;
            EditorOnlyDelegates.SwitchToNextEnvironment = null;
            onEnvironmentSetup -= EditorOnlyEvents.OnEnvironmentSetup;
            PrefabUtility.prefabInstanceUpdated -= OnPrefabInstanceUpdated;
            QuerySimulationModule.onTemporalSimulationStart -= OnTemporalSimulationStart;
            QuerySimulationModule.BeforeSimulationSetup -= OnBeforeSimulationSetup;

            // Do not reset current environment/video index to avoid changing environments on domain reload
            m_EnvironmentPrefabPaths.Clear();
            m_EnvironmentPrefabNames.Clear();
            DeviceStartingPose = default;
            EnvironmentSetup = false;
            SyntheticEnvironmentInfo = null;
            m_EnvironmentGUIContents = null;
            m_CurrentEnvironmentPrefab = null;

            if (s_OnDestroyNotifier)
            {
                s_OnDestroyNotifier.destroyed = null;
                UnityObjectUtils.Destroy(s_OnDestroyNotifier.gameObject);
            }
        }

        bool OnEditorWantsToQuit()
        {
            if (CurrentLoadedPrefabInstanceEnvironment != null &&
                PrefabUtility.HasPrefabInstanceAnyOverrides(CurrentLoadedPrefabInstanceEnvironment, false))
            {
                return TrySaveEnvironmentModificationsDialog();
            }

            return true;
        }

        /// <inheritdoc />
        void IFunctionalityProvider.LoadProvider() { }

        /// <inheritdoc />
        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesDeviceSimulationSettings>(obj);
        }

        /// <inheritdoc />
        void IFunctionalityProvider.UnloadProvider() { }

        void OnTemporalSimulationStart()
        {
            if (m_VideoContextManager != null && m_VideoContextManager.IsUsingVideo)
                SimulationView.EnsureDeviceViewAvailable();
        }

        void OnBeforeSimulationSetup()
        {
            if (!m_SimulatedObjectsManager.IsCameraOffsetDirty)
                return;

            Vector3 translation;
            Quaternion rotation;
            Vector3 scale;
            var session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (session != null)
            {
                var sessionTrans = session.transform;
                translation = sessionTrans.position;
                rotation = sessionTrans.rotation.ConstrainYawNormalized();
                scale = Vector3.one * sessionTrans.localScale.x;
            }
            else
            {
                translation = Vector3.zero;
                rotation = Quaternion.identity;
                scale = Vector3.one;
            }

            OffsetEnvironment(translation, rotation, scale);
        }

        void OnPrefabInstanceUpdated(GameObject prefabInstance)
        {
            if (m_PrefabUpdatingByScriptLock || prefabInstance != CurrentLoadedPrefabInstanceEnvironment)
                return;

            // Need to re-check bounds of prefab if modified by editing and applying changes in simulation.
            UpdateEnvironmentInstancePrefabInfo();
        }

        static bool IsEnvironmentPrefab(GameObject prefab)
        {
            if (!PrefabUtility.IsPartOfPrefabAsset(prefab))
                return false;

            var outerPrefab = PrefabUtility.GetOutermostPrefabInstanceRoot(prefab);
            if (outerPrefab == null)
                return false;

            var path = AssetDatabase.GetAssetPath(outerPrefab);
            if (string.IsNullOrEmpty(path))
                return false;

            var labels = AssetDatabase.GetLabels(outerPrefab);
            return labels.Contains(EnvironmentLabel) || labels.Contains(DefaultEnvironmentLabel);
        }

        /// <summary>
        /// Sets the environment mode in the simulation settings. Then tears down the current environment
        /// (if there is one) and sets up a new one based on current simulation settings,
        /// and then triggers simulation restart.
        /// </summary>
        /// <param name="mode">The environment mode the simulation should be in.</param>
        /// <returns>If True, refreshing environment and simulation restart was not canceled.</returns>
        internal bool TrySetModeAndRestartSimulation(EnvironmentMode mode)
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                var simulationSettings = SimulationSettings.instance;
                simulationSettings.EnvironmentMode = mode;
                var marsSession = MarsRuntimeUtils.GetMarsSessionInActiveScene();
                if (marsSession != null)
                    simulationSettings.UpdateEnvironmentModeForCameraFacing(marsSession.requirements.RequiredCameraFacing);

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Must restart MARS lifecycle after changing environment mode
                return true;
            }

            if (!TrySaveEnvironmentModificationsDialog(mode))
                return false;

            switch (mode)
            {
                case EnvironmentMode.Synthetic:
                    m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.SingleFrameMode);
                    break;
                case EnvironmentMode.Recorded:
                case EnvironmentMode.Live:
                    m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);
                    break;
                case EnvironmentMode.Custom:
                    if (HasCustomModeSettings)
                        m_QuerySimulationModule.RequestSimulationModeSelection(CustomModeSettings.DefaultSimulationMode);
                    break;
            }

            ForceRefreshEnvironmentAndRestartSimulation();
            return true;
        }

        /// <summary>
        /// Tears down the current environment (if there is one) and sets up a new one based
        /// on current simulation settings, and then triggers simulation restart.
        /// </summary>
        /// <returns>If True, refreshing environment and simulation restart was not canceled.</returns>
        internal bool TryRefreshEnvironmentAndRestartSimulation()
        {
            if (!TrySaveEnvironmentModificationsDialog())
                return false;

            ForceRefreshEnvironmentAndRestartSimulation();
            return true;
        }

        /// <summary>
        /// Tears down the current environment (if there is one) without the option to save
        /// and sets up a new one based on current simulation settings, and then triggers simulation restart.
        /// </summary>
        internal void ForceRefreshEnvironmentAndRestartSimulation()
        {
            m_QuerySimulationModule.RestartSimulationIfNeeded(true);
            RefreshEnvironment();
            ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>().DirtySimulatableScene();
        }

        /// <summary>
        /// Tears down the current environment (if there is one) and sets up a new one based on current simulation settings
        /// </summary>
        internal void RefreshEnvironment()
        {
            TearDownEnvironment();
            SetupEnvironment();
        }

        /// <summary>
        /// Sets up an environment based on current simulation settings
        /// </summary>
        void SetupEnvironment()
        {
            if (EnvironmentSetup)
            {
                Debug.LogWarning("There is already an environment setup. Please use RefreshEnvironment if you wish to " +
                    "tear down the current environment and setup a new one.");
                return;
            }

            if (!m_SimulationSceneModule.IsSimulationReady)
                return;

            var notifiers = FindObjectsOfType<OnDestroyNotifier>();
            if (notifiers.Length > 0)
            {
                s_OnDestroyNotifier = notifiers.First(notifier => notifier.gameObject.name.Equals(k_OnDestroyNotifierName));
            }

            if (s_OnDestroyNotifier == null)
            {
                s_OnDestroyNotifier = new GameObject(k_OnDestroyNotifierName).AddComponent<OnDestroyNotifier>();
                s_OnDestroyNotifier.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }

            s_OnDestroyNotifier.destroyed = OnNotifierDestroyed;

            EnvironmentParent = new GameObject("Simulated Environment");
            EditorOnlyDelegates.GetSimulatedEnvironmentRoot = () => EnvironmentParent;
            m_SimulationSceneModule.AddEnvironmentGameObject(EnvironmentParent);

            switch (SimulationSettings.instance.EnvironmentMode)
            {
                case EnvironmentMode.Synthetic:
                    OpenSyntheticEnvironment();
                    break;
                case EnvironmentMode.Recorded:
                    var recording = SimulationSettings.instance.IndependentRecording;
                    if (recording != null && recording.HasVideo && MARSEntitlements.instance.IsEntitled(false))
                        m_VideoContextManager.SetupVideoBackground(EnvironmentParent.transform);

                    break;
                case EnvironmentMode.Live:
                    var simulationSettings = SimulationSettings.instance;
                    var deviceCount = WebCamTexture.devices.Length;
                    if (deviceCount == 0 || (!MARSEntitlements.instance.IsEntitled(false)))
                    {
                        simulationSettings.WebCamDeviceIndex = -1;
                        break;
                    }

                    m_VideoContextManager.SetupVideoBackground(EnvironmentParent.transform);
                    if (simulationSettings.WebCamDeviceIndex >= deviceCount)
                    {
                        simulationSettings.WebCamDeviceIndex = deviceCount - 1;
                        m_VideoContextManager.UpdateWebCamDeviceCandidates();
                    }
                    else if (simulationSettings.WebCamDeviceIndex < 0)
                    {
                        simulationSettings.WebCamDeviceIndex = 0;
                        m_VideoContextManager.UpdateWebCamDeviceCandidates();
                    }

                    m_VideoContextManager.PrepareForLiveVideo(simulationSettings.WebCamDeviceIndex);
                    break;
                case EnvironmentMode.Custom:
                    if (HasCustomModeSettings)
                        m_SimulationEnvironmentModeSettings.OpenSimulationEnvironment();

                    break;
            }

            FinishSetupEnvironment();
        }

        void FinishSetupEnvironment()
        {
            var simulationSettings = SimulationSettings.instance;
            SetSimEnvironmentVisibility(simulationSettings.ShowSimulatedEnvironment);
            SetSimDataVisibility(simulationSettings.ShowSimulatedData);
            EnvironmentParent.SetLayerRecursively(SimulationConstants.SimulatedEnvironmentLayerIndex);

            // Cull lighting to only simulated environment objects
            EnvironmentParent.GetComponentsInChildren(m_SimulationLights);
            SetSimulationLightsCullingMask();

            var environmentTrans = EnvironmentParent.transform;
            environmentTrans.localScale = Vector3.one * MarsWorldScaleModule.GetWorldScale();
            // Need to match the scalar values for components that have parameters
            // that are not effected by world scale.
            m_WorldScaleModule.ApplyWorldScaleToEnvironment();

            var session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (session != null)
            {
                var sessionTrans = session.transform;
                environmentTrans.position = sessionTrans.position;
                environmentTrans.rotation = sessionTrans.rotation.ConstrainYaw();
            }

            // Find all playables in the timeline and fire them off
            var directors = EnvironmentParent.GetComponentsInChildren<PlayableDirector>();
            foreach (var currentDirector in directors)
            {
                currentDirector.Play();
            }

            var marsSession = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (marsSession != null && !MARSSession.TestMode)
                simulationSettings.UpdateEnvironmentModeForCameraFacing(marsSession.requirements.RequiredCameraFacing);

            EnvironmentSetup = true;
            onEnvironmentSetup?.Invoke();

            EnvironmentChanged?.Invoke();
        }

        static void OnNotifierDestroyed(OnDestroyNotifier obj)
        {
            // If the notifier is destroyed and it is not due to switching scenes, in play mode, or building, we know we are discarding changes
            if (!(ModuleLoaderCore.isSwitchingScenes || EditorApplication.isPlaying))
            {
                // Delay call to ReloadModules so that it happens after MARSSession gets destroyed and triggers UnloadModules
                EditorApplication.delayCall += ModuleLoaderCore.instance.ReloadModules;
            }
        }

        void RevertIgnoredModifications()
        {
            if (!CurrentLoadedPrefabInstanceEnvironment || !PrefabUtility.IsPartOfPrefabInstance(CurrentLoadedPrefabInstanceEnvironment))
                return;

            var prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(CurrentLoadedPrefabInstanceEnvironment);
            var prefabAssetRoot = AssetDatabase.LoadAssetAtPath<GameObject>(PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(prefabRoot));

            // Get the root layer and revert if modified. This will be used to override any layer modifications on objects
            // We cannot revert the layer modification since applying modifications to every game object is too slow.
            var rootSerializedObject = new SerializedObject(prefabRoot);
            var rootLayerProperty = rootSerializedObject.FindProperty(k_LayerPropertyName);
            if (rootLayerProperty.prefabOverride)
            {
                rootLayerProperty.prefabOverride = false;
                rootSerializedObject.ApplyModifiedPropertiesWithoutUndo();
                rootSerializedObject.Update();
            }

            // original layer for the prefab root
            var rootLayer = rootLayerProperty.intValue;

            // Set any new game object to the root game object's layer
            foreach (var addedGameObject in PrefabUtility.GetAddedGameObjects(prefabRoot))
            {
                var addedGo = (GameObject)addedGameObject.GetAssetObject();
                addedGo.SetLayerRecursively(rootLayer);
                addedGameObject.Apply();
            }

            var overrides = PrefabUtility.GetObjectOverrides(CurrentLoadedPrefabInstanceEnvironment);
            foreach (var objOverride in overrides)
            {
                if (objOverride.instanceObject == null)
                    continue;

                var serializedObject = new SerializedObject(objOverride.instanceObject);

                // Override layer before anything else
                if (objOverride.instanceObject is GameObject go)
                {
                    var layerProperty = serializedObject.FindProperty(k_LayerPropertyName);
                    if (layerProperty.prefabOverride || layerProperty.intValue == SimulationConstants.SimulatedEnvironmentLayerIndex)
                        go.layer = rootLayer;
                }

                var needsApply = false;
                if (objOverride.instanceObject == prefabAssetRoot || objOverride.instanceObject == prefabRoot ||
                    objOverride.instanceObject == prefabAssetRoot.transform || objOverride.instanceObject == prefabRoot.transform)
                {
                    foreach (var rootIgnoreProperty in k_RootIgnoreProperties)
                    {
                        var prop = serializedObject.FindProperty(rootIgnoreProperty);
                        if (prop != null && prop.prefabOverride)
                        {
                            prop.prefabOverride = false;
                            needsApply = true;
                        }
                    }
                }

                foreach (var scaleIgnoreProperty in k_WorldScaleIgnoreProperties)
                {
                    var prop = serializedObject.FindProperty(scaleIgnoreProperty);
                    if (prop != null && prop.prefabOverride)
                    {
                        prop.prefabOverride = false;
                        needsApply = true;
                    }
                }

                if (needsApply)
                    serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }

            // To revert any changes to prefab instances in the selected prefab
            // we have to remove the Property modifications from the prefab instance object
            var instanceHandle = PrefabUtility.GetPrefabInstanceHandle(prefabRoot);
            if (instanceHandle != null)
            {
                const string propertyModificationPath = "m_Modification.m_Modifications";
                var serializedObject = new SerializedObject(instanceHandle);
                var property = serializedObject.FindProperty(propertyModificationPath);
                if (property != null)
                {
                    var size = property.arraySize;
                    for (var i = size - 1; i > -1; i--)
                    {
                        var propArray = property.GetArrayElementAtIndex(i);

                        const string targetName = "target";
                        const string propertyPathName = "propertyPath";
                        const string valueName = "value";

                        var targetProp = propArray.FindPropertyRelative(targetName);
                        var pathProp = propArray.FindPropertyRelative(propertyPathName);
                        var valueProp = propArray.FindPropertyRelative(valueName);

                        if (targetProp != null && pathProp != null && valueProp != null)
                        {
                            // Keep layer modifications that are not set to the sim env layer
                            if (pathProp.stringValue == k_LayerPropertyName && int.TryParse(valueProp.stringValue, out var layer)
                                && layer != SimulationConstants.SimulatedEnvironmentLayerIndex)
                                break;

                            var targetObject = targetProp.objectReferenceValue;
                            var rootPropertyRemoved = false;
                            if (targetObject != null && (targetObject == prefabAssetRoot || targetObject == prefabRoot ||
                                targetObject == prefabAssetRoot.transform || targetObject == prefabRoot.transform))
                            {
                                foreach (var rootIgnoreProperty in k_RootIgnoreProperties)
                                {
                                    if (pathProp.stringValue.Contains(rootIgnoreProperty))
                                    {
                                        property.DeleteArrayElementAtIndex(i);
                                        rootPropertyRemoved = true;
                                        break;
                                    }
                                }
                            }

                            if (rootPropertyRemoved)
                                break;

                            foreach (var scaleIgnoreProperty in k_WorldScaleIgnoreProperties)
                            {
                                if (pathProp.stringValue.Contains(scaleIgnoreProperty))
                                {
                                    property.DeleteArrayElementAtIndex(i);
                                    break;
                                }
                            }
                        }
                    }
                }

                serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }

        internal bool HasSaveableEnvironmentPrefabInstanceOverrides()
        {
            if (PrefabUtility.HasPrefabInstanceAnyOverrides(CurrentLoadedPrefabInstanceEnvironment, false))
            {
                if (PrefabUtility.GetAddedComponents(CurrentLoadedPrefabInstanceEnvironment).Count > 0 ||
                    PrefabUtility.GetRemovedComponents(CurrentLoadedPrefabInstanceEnvironment).Count > 0 ||
                    PrefabUtility.GetAddedGameObjects(CurrentLoadedPrefabInstanceEnvironment).Count > 0)
                    return true;

                var propertyModifications = PrefabUtility.GetPropertyModifications(CurrentLoadedPrefabInstanceEnvironment);
                var prefabRoot = PrefabUtility.GetOutermostPrefabInstanceRoot(CurrentLoadedPrefabInstanceEnvironment);
                var prefabAssetRoot = AssetDatabase.LoadAssetAtPath<GameObject>(PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(prefabRoot));
                foreach (var propertyModification in propertyModifications)
                {
                    var isIgnoreProp = false;
                    if (propertyModification.target == prefabAssetRoot || propertyModification.target == prefabRoot ||
                        propertyModification.target == prefabAssetRoot.transform || propertyModification.target == prefabRoot.transform)
                    {
                        foreach (var ignore in k_RootIgnoreProperties)
                        {
                            if (propertyModification.propertyPath.Contains(ignore))
                            {
                                isIgnoreProp = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var ignore in k_WorldScaleIgnoreProperties)
                        {
                            if (propertyModification.propertyPath.Contains(ignore))
                            {
                                isIgnoreProp = true;
                                break;
                            }
                        }
                    }

                    if (!isIgnoreProp)
                        return true;
                }
            }

            return false;
        }

        void SaveEnvironment()
        {
            SavingEnvironment = true;
            m_PrefabUpdatingByScriptLock = true;
            RevertIgnoredModifications();
            UpdateEnvironmentInstancePrefabInfo();

            // Some environments have objects that shouldn't be saved (like a spinning fan),
            // we need to set the flags when opening the environment
            // to not save while the environment is open and restore the flags when tearing down,
            // else the gameobject will get destroyed since it was set to not be saved
            var gameObjectsIgnoredForSaving =
                CurrentLoadedPrefabInstanceEnvironment.GetComponentsInChildren<IgnoreForEnvironmentPersistence>();

            foreach (var dontSaveTransform in gameObjectsIgnoredForSaving)
            {
                dontSaveTransform.RestoreHideFlags();
            }

            PrefabUtility.ApplyPrefabInstance(CurrentLoadedPrefabInstanceEnvironment, InteractionMode.AutomatedAction);
            m_PrefabUpdatingByScriptLock = false;
        }

        /// <summary>
        /// Tears down the current environment (if there is one)
        /// </summary>
        void TearDownEnvironment()
        {
            m_SimulationLights.Clear();
            if (!EnvironmentSetup)
                return;

            SaveSimViewLookAtDataForEnvironment();

            m_CurrentEnvironmentPrefab = null;
            CurrentLoadedPrefabInstanceEnvironment = null;
            m_CurrentPrefabInstanceEnvironmentSettings = null;
            EnvironmentSetup = false;

            var activeIsland = m_FIModule.activeIsland;
            if (activeIsland != null)
            {
                if (activeIsland.providers.TryGetValue(typeof(IProvidesSessionControl), out var provider))
                    ((IProvidesSessionControl)provider).ResetSession();
            }

            m_QuerySimulationModule.CleanupSimulation();

            SyntheticEnvironmentInfo = null;

            m_WorldScaleModule.ClearEnvironmentRangeScaledComponents();
            m_VideoContextManager.TearDownVideoBackground();

            if (EnvironmentParent != null)
            {
                EnvironmentParent.SetActive(false);
                UnityObjectUtils.Destroy(EnvironmentParent);
            }

            if (SimulationSceneModule.isAssemblyReloading)
                ForceRebuildInspectorsIfNeeded();

            DeviceStartingPose = default;
        }

        static void ForceRebuildInspectorsIfNeeded()
        {
            var invalidEditor = false;
            var tracker = ActiveEditorTracker.sharedTracker;
            foreach (var editor in Resources.FindObjectsOfTypeAll<Editor>())
            {
                if (editor.target == null)
                    invalidEditor = true;
            }

            if (invalidEditor)
                tracker.ForceRebuild();
        }

        void OpenSyntheticEnvironment()
        {
            SavingEnvironment = false;
            var simulationSettings = SimulationSettings.instance;
            var currentEnvironment = simulationSettings.EnvironmentPrefab;
            if (currentEnvironment == null)
            {
                if (!SyntheticEnvironmentsExist)
                    return;

                SetSyntheticEnvironment(0);
            }
            else if (AssetDatabase.GetAssetPath(currentEnvironment) != m_EnvironmentPrefabPaths[m_CurrentSyntheticEnvironmentIndex])
            {
                SetSyntheticEnvironment(m_CurrentSyntheticEnvironmentIndex);
            }

            // Copy the objects under a deactivated gameobject root. This allows all the objects to be copied before any
            // behaviour gets OnEnable called. When the root is activated again, the script with the lowest execution
            // order, MARSEnvironmentSettings, will wake up first and fire an event that injects functionality before the
            // other scripts are awake.
            EnvironmentParent.SetActive(false);

            GameObject envPrefabInstance;
            m_CurrentEnvironmentPrefab = simulationSettings.EnvironmentPrefab;
            if (MARSEntitlements.instance.IsEntitled(false))
            {
                envPrefabInstance = (GameObject)PrefabUtility.InstantiatePrefab(m_CurrentEnvironmentPrefab, EnvironmentParent.transform);
            }
            else
            {
                envPrefabInstance = new GameObject();
            }

            envPrefabInstance.name = m_CurrentEnvironmentPrefab.name; // Removes "(clone)" from the name
            m_WorldScaleModule.GetEnvironmentRangeScaledComponents(envPrefabInstance);

            // This will create a MARSEnvironmentSettings on the prefab copy if none exits
            if (!MARSEnvironmentSettings.GetOrCreateSettings(envPrefabInstance, out m_CurrentPrefabInstanceEnvironmentSettings))
            {
                Debug.LogWarning($"Environment Settings created for {envPrefabInstance.name}'s Instance." +
                    "\nYou Should create an Environment Settings on the original to use custom values!");
            }

            CurrentLoadedPrefabInstanceEnvironment = envPrefabInstance;

            EnvironmentParent.SetActive(true);
            UpdateEnvironmentInstancePrefabInfo();
            SetEnvironmentInfo(m_CurrentPrefabInstanceEnvironmentSettings.EnvironmentInfo);

            // Some environments have objects that shouldn't be saved (eg. animated objects),
            // so we need to set the flags when opening the environment
            // to not save while the environment is open and restore the flags in TearDownEnvironment(),
            // else the gameobject will get destroyed since it was set to not be saved
            var gameObjectsIgnoredForSaving =
                CurrentLoadedPrefabInstanceEnvironment.GetComponentsInChildren<IgnoreForEnvironmentPersistence>();

            foreach (var dontSaveTransform in gameObjectsIgnoredForSaving)
            {
                dontSaveTransform.SetDontSaveFlags();
            }
        }

        /// <summary>
        /// Sets the environment info in the environment manager for the synthetic environment
        /// </summary>
        /// <param name="environmentInfo">The new environment info to set in the manager</param>
        public void SetEnvironmentInfo(MARSEnvironmentInfo environmentInfo)
        {
            if (environmentInfo != null)
            {
                SyntheticEnvironmentInfo = environmentInfo;
                DeviceStartingPose = SyntheticEnvironmentInfo.SimulationStartingPose;
            }

            TryFrameAllSimViewsOnEnvironment();
        }

        void UpdateEnvironmentInstancePrefabInfo()
        {
            // Unset parent before updating prefab info so that it doesn't affect bounds calculations
            var envInstanceTrans = CurrentLoadedPrefabInstanceEnvironment.transform;
            envInstanceTrans.SetParent(null, false);
            m_CurrentPrefabInstanceEnvironmentSettings.UpdatePrefabInfo();
            envInstanceTrans.SetParent(EnvironmentParent.transform, false);
            EditorUtility.SetDirty(m_CurrentPrefabInstanceEnvironmentSettings);
        }

        internal void UpdateDeviceStartingPose()
        {
            var simulatedObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            if (simulatedObjectsManager != null)
            {
                var simulatedCamera = simulatedObjectsManager.SimulatedCamera;
                if (simulatedCamera != null)
                    DeviceStartingPose = simulatedObjectsManager.SimulatedCamera.transform.GetLocalPose();
            }
        }

        internal void ResetDeviceStartingPose()
        {
            DeviceStartingPose = DefaultDeviceStartingPose;
        }

        /// <summary>
        /// Offsets and scales the parent transform of the environment and adjusts the simulation view camera
        /// such that the environment appears to have been unchanged
        /// </summary>
        /// <param name="positionOffset">Positional offset of the environment</param>
        /// <param name="rotationOffset">Rotational offset of the environment</param>
        /// <param name="scaleOffset">Scale offset of the environment</param>
        void OffsetEnvironment(Vector3 positionOffset, Quaternion rotationOffset, Vector3 scaleOffset)
        {
            Debug.Assert(EnvironmentParent != null);

            var environmentParentTrans = EnvironmentParent.transform;
            var inversePreviousOffset = environmentParentTrans.worldToLocalMatrix;
            var previousScale = environmentParentTrans.localScale.x;
            var differenceScale = scaleOffset.x / previousScale;
            var differenceRotation = rotationOffset * inversePreviousOffset.rotation;

            environmentParentTrans.position = positionOffset;
            environmentParentTrans.rotation = rotationOffset;
            environmentParentTrans.localScale = scaleOffset;

            foreach (var simView in SimulationView.SimulationViews)
            {
                if (simView == null)
                    continue;

                var size = simView.size * differenceScale;
                var previousLocalPivot = inversePreviousOffset.MultiplyPoint3x4(simView.pivot);
                var pivot = environmentParentTrans.TransformPoint(previousLocalPivot);
                var rotation = differenceRotation * simView.rotation;
                simView.LookAt(pivot, rotation, size, simView.orthographic, true);
                simView.Repaint();
            }

            EnvironmentOffsetChanged?.Invoke();
        }

        bool GetSimulatedEnvironmentCandidates()
        {
            m_EnvironmentPrefabPaths.Clear();
            m_EnvironmentPrefabNames.Clear();

            UpdateEnvironmentModes();

            var envPrefabs = AssetDatabase.FindAssets(k_EnvironmentPrefabFilter);

            // Fall back to default environment
            if (envPrefabs.Length == 0)
            {
                // Import package content if we haven't tried once before
                if (!m_PackageContentImported)
                {
                    m_PackageContentImported = true;
                    EditorUtility.SetDirty(this);

                    // Force save in case of error on import
                    AssetDatabase.SaveAssets();

                    PackageUtils.ImportContentPackage();
                }

                envPrefabs = AssetDatabase.FindAssets(k_DefaultEnvironmentPrefabFilter);
            }

            foreach (var guid in envPrefabs)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                m_EnvironmentPrefabPaths.Add(path);
                m_EnvironmentPrefabNames.Add(Path.GetFileNameWithoutExtension(path));
            }

            m_EnvironmentGUIContents = m_EnvironmentPrefabNames.Select(prefabName => new GUIContent(prefabName)).ToArray();

            var simulationSettings = SimulationSettings.instance;
            var currentPrefabAssetPath = AssetDatabase.GetAssetPath(simulationSettings.EnvironmentPrefab);
            m_CurrentSyntheticEnvironmentIndex = Mathf.Max(m_EnvironmentPrefabPaths.IndexOf(currentPrefabAssetPath), 0);

            if (m_SimulationEnvironmentModeSettings != null)
                m_SimulationEnvironmentModeSettings.FindEnvironmentCandidates();

            if (simulationSettings.EnvironmentMode == EnvironmentMode.Custom && !HasCustomModeSettings)
                TrySetModeAndRestartSimulation(EnvironmentMode.Synthetic);

            return m_EnvironmentPrefabPaths.Count > 0;
        }

        void UpdateEnvironmentModes()
        {
            s_ModeTypes = Enum.GetNames(typeof(EnvironmentMode))
                .Where(k => !(k == EnvironmentMode.Custom.ToString() && !HasCustomModeSettings) && k != EnvironmentMode.Remote.ToString())
                .Select(k => k.Replace(EnvironmentMode.Synthetic.ToString(),"Synthetic (Room)"))
                .Select(k => k.Replace(EnvironmentMode.Recorded.ToString(), "Recorded (Face, Companion)"))
                .Select(k => k.Replace(EnvironmentMode.Live.ToString(),"Live (Face)"))
                .Select(k => k.Replace(EnvironmentMode.Custom.ToString(), HasCustomModeSettings ? m_SimulationEnvironmentModeSettings.EnvironmentModeName : NoModeSettingsName))
                .Select(k => new GUIContent(k)).ToArray();
        }

        /// <summary>
        /// Update the Simulated Environments available in Synthetic Simulation
        /// </summary>
        public void UpdateSimulatedEnvironmentCandidates()
        {
            var noSynthEnvironmentsPreviously = !SyntheticEnvironmentsExist;
            GetSimulatedEnvironmentCandidates();

            if (SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic && SyntheticEnvironmentsExist
                && noSynthEnvironmentsPreviously)
                SetSyntheticEnvironment(0);
        }

        /// <summary>
        /// Update the Simulated Environments available in Synthetic Simulation
        /// </summary>
        [MenuItem(MenuConstants.DevMenuPrefix + "Update Simulation Environments", priority = MenuConstants.UpdateSimEnvironmentsPriority)]
        public static void UpdateSimulationEnvironmentsMenuItem()
        {
            instance.UpdateSimulatedEnvironmentCandidates();
        }

        /// <summary>
        /// Sets up the next environment of the current type and then triggers simulation restart after a save dialog
        /// if there are any saveable changes in the environment.
        /// </summary>
        /// <param name="forward">Direction in which to cycle through environments</param>
        /// <returns>If True, setup of environment and restart was not canceled.</returns>
        public bool TrySetupNextEnvironmentAndRestartSimulation(bool forward)
        {
            var mode = SimulationSettings.instance.EnvironmentMode;
            if (!TrySaveEnvironmentModificationsDialog(mode))
                return false;

            UpdateSimulationSettingsToNextEnvironment(forward);
            ForceRefreshEnvironmentAndRestartSimulation();
            return true;
        }

        /// <summary>
        /// Sets up the specified environment based on index in environment list of the current type and then
        /// triggers simulation restart.
        /// </summary>
        /// <param name="index">Specified index of environment</param>
        /// <returns>If True, setup of the environment was not canceled.</returns>
        public bool TrySetupEnvironmentAndRestartSimulation(int index)
        {
            var simulationSettings = SimulationSettings.instance;
            var mode = simulationSettings.EnvironmentMode;
            if (!TrySaveEnvironmentModificationsDialog(mode))
                return false;

            switch (mode)
            {
                case EnvironmentMode.Synthetic:
                    if (!SyntheticEnvironmentsExist)
                        return false;

                    SetSyntheticEnvironment(index);
                    break;

                case EnvironmentMode.Recorded:
                    m_SimulationRecordingManager.TrySetIndependentRecording(index);
                    break;

                case EnvironmentMode.Live:
                    simulationSettings.WebCamDeviceIndex = index;
                    break;

                case EnvironmentMode.Custom:
                    if (HasCustomModeSettings)
                        m_SimulationEnvironmentModeSettings.SetActiveEnvironment(index);
                    break;
            }

            ForceRefreshEnvironmentAndRestartSimulation();
            return true;
        }

        /// <summary>
        /// Sets up the specified environment, if it is in the synthetic environment list, then
        /// triggers simulation restart.
        /// </summary>
        /// <param name="path">Path of the desired environment</param>
        /// <returns>If true, setup of environment was not canceled and able to load environment.</returns>
        internal bool TrySetupSyntheticEnvironmentAndRestartSimulation(string path)
        {
            if (!TrySaveEnvironmentModificationsDialog(EnvironmentMode.Synthetic))
                return false;

            var index = m_EnvironmentPrefabPaths.IndexOf(path);
            SetSyntheticEnvironment(index < 0 ? 0 : index);
            ForceRefreshEnvironmentAndRestartSimulation();
            return true;
        }

        /// <summary>
        /// Sets up the next environment of the current type without the option to save environment changes.
        /// </summary>
        /// <param name="forward">Direction in which to cycle through environments</param>
        public void ForceSetupNextEnvironment(bool forward)
        {
            UpdateSimulationSettingsToNextEnvironment(forward);
            RefreshEnvironment();
        }

        /// <summary>
        /// Updates simulation settings to reference the next environment of the current type
        /// </summary>
        /// <param name="forward">Direction in which to cycle through environments</param>
        void UpdateSimulationSettingsToNextEnvironment(bool forward)
        {
            var simulationSettings = SimulationSettings.instance;
            switch (simulationSettings.EnvironmentMode)
            {
                case EnvironmentMode.Synthetic:
                    if (!SyntheticEnvironmentsExist)
                    {
                        DisplayNoEnvironmentsDialog();
                        return;
                    }

                    var index = forward ? m_CurrentSyntheticEnvironmentIndex + 1 : m_CurrentSyntheticEnvironmentIndex - 1;
                    SetSyntheticEnvironment(index);
                    break;
                case EnvironmentMode.Recorded:
                    if (forward)
                        m_SimulationRecordingManager.SetNextIndependentRecording();
                    else
                        m_SimulationRecordingManager.SetPreviousIndependentRecording();

                    break;

                case EnvironmentMode.Live:
                    var deviceCount = WebCamTexture.devices.Length;
                    var deviceIndex = simulationSettings.WebCamDeviceIndex;
                    if (deviceCount == 0)
                    {
                        deviceIndex = -1;
                    }
                    else if (forward)
                    {
                        deviceIndex++;
                        if (deviceIndex >= deviceCount)
                            deviceIndex = 0;
                    }
                    else
                    {
                        deviceIndex--;
                        if (deviceIndex < 0)
                            deviceIndex = deviceCount - 1;
                    }

                    simulationSettings.WebCamDeviceIndex = deviceIndex;
                    break;
                case EnvironmentMode.Custom:
                    if (HasCustomModeSettings)
                    {
                        var customIndex = forward ? CustomModeSettings.ActiveEnvironmentIndex + 1
                            : CustomModeSettings.ActiveEnvironmentIndex - 1;
                        m_SimulationEnvironmentModeSettings.SetActiveEnvironment(customIndex);
                    }
                    break;
            }
        }

        /// <summary>
        /// Updates simulation settings to reference the synthetic environment at the given index
        /// </summary>
        /// <param name="index">Synthetic environment index</param>
        internal void SetSyntheticEnvironment(int index)
        {
            if (index < 0)
                index = m_EnvironmentPrefabPaths.Count - 1;
            else if (index >= m_EnvironmentPrefabPaths.Count)
                index = 0;

            if (!SyntheticEnvironmentsExist && !GetSimulatedEnvironmentCandidates())
            {
                DisplayNoEnvironmentsDialog();
                return;
            }

            m_CurrentSyntheticEnvironmentIndex = index;

            var environmentToLoad = AssetDatabase.LoadAssetAtPath<GameObject>(m_EnvironmentPrefabPaths[m_CurrentSyntheticEnvironmentIndex]);

            if (environmentToLoad == null)
            {
                GetSimulatedEnvironmentCandidates();
                SetSyntheticEnvironment(index);
                return;
            }

            SimulationSettings.instance.EnvironmentPrefab = environmentToLoad;
        }

        static void DisplayNoEnvironmentsDialog()
        {
            EditorUtility.DisplayDialog(k_NoSyntheticEnvironmentsTitle, k_NoSyntheticEnvironmentsMessage, "Ok");
        }

        /// <summary>
        /// Try to frame all the simulation views on the synthetic environment with the synthetic environment info
        /// </summary>
        public void TryFrameAllSimViewsOnEnvironment()
        {
            if (!IsFramingEnabled)
                return;

            if (SyntheticEnvironmentInfo == null)
            {
                Debug.LogWarning(
                    "Cannot frame sim view because the current environment does not have MARS Environment Info.");
                return;
            }

            foreach (var simView in SimulationView.SimulationViews)
            {
                FrameSimViewOnEnvironment(simView, SyntheticEnvironmentInfo, true);
            }
        }

        /// <summary>
        /// Try to frame the simulation view on the current environment, if possible
        /// </summary>
        /// <param name="simView">The simulation view which should be updated</param>
        /// <param name="instant">Whether to update the view instantly or with an animated transition</param>
        /// <returns>The rotation of the simulation view camera once the view is framed</returns>
        public Quaternion TryFrameSimViewOnEnvironment(ISimulationView simView, bool instant)
        {
            if (!IsFramingEnabled)
                return Quaternion.identity;

            if (SyntheticEnvironmentInfo == null)
            {
                Debug.LogWarning(
                    "Cannot frame sim view because the current environment does not have MARS Environment Info.");
                return Quaternion.identity;
            }

            return FrameSimViewOnEnvironment(simView, SyntheticEnvironmentInfo, instant);
        }

        Quaternion FrameSimViewOnEnvironment(ISimulationView simView, MARSEnvironmentInfo envInfo, bool instant)
        {
            Vector3 rawPivot;
            Quaternion rawRotation;
            float rawDistance;
            var simulationView = simView as SimulationView;
            if (simulationView != null && simulationView.TryGetLookAtForEnvironment(m_CurrentEnvironmentPrefab, out var lookAtData))
            {
                rawPivot = lookAtData.Pivot;
                rawRotation = lookAtData.Rotation;
                rawDistance = lookAtData.Size;
            }
            else
            {
                var cameraPose = envInfo.DefaultCameraWorldPose;
                var existingPivot = envInfo.DefaultCameraPivot;
                rawDistance = envInfo.DefaultCameraSize;
                rawPivot = existingPivot != Vector3.zero ? existingPivot : cameraPose.position + cameraPose.forward * rawDistance;
                rawRotation = cameraPose.rotation;
                if (simulationView != null)
                    simulationView.CacheLookAt(rawPivot, rawRotation, rawDistance);
            }

            var session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            float worldScale;
            Vector3 positionOffset;
            Quaternion rotationOffset;
            if (session != null)
            {
                var sessionTrans = session.transform;
                worldScale = sessionTrans.localScale.x;
                positionOffset = sessionTrans.position;
                rotationOffset = sessionTrans.rotation.ConstrainYawNormalized();
            }
            else
            {
                worldScale = 1f;
                positionOffset = Vector3.zero;
                rotationOffset = Quaternion.identity;
            }

            var pivot = rotationOffset * rawPivot * worldScale + positionOffset;
            var size = rawDistance * worldScale;
            var rotation = rotationOffset * rawRotation;

            if (simView.SceneType == ViewSceneType.Simulation)
            {
                simView.LookAt(pivot, rotation, size, simView.orthographic, instant);
                simView.isRotationLocked = false;
                simView.Repaint();
            }

            return rotation;
        }

        void SaveSimViewLookAtDataForEnvironment()
        {
            if (m_CurrentEnvironmentPrefab == null)
                return;

            foreach (var simulationView in SimulationView.SimulationViews)
            {
                if (simulationView.SceneType == ViewSceneType.Simulation)
                    simulationView.SaveCurrentLookAtForEnvironment(m_CurrentEnvironmentPrefab);
            }
        }

        static IEnumerable<Renderer> GetSimRenderers(SimulatedRendererType seeking)
        {
            var results = new List<Renderer>();
            if (instance == null || instance.EnvironmentParent == null)
                return results;

            var allRenderers = instance.EnvironmentParent.GetComponentsInChildren<Renderer>();
            foreach (var renderer in allRenderers)
            {
                // Renderers on synthesized data are visualizing invisible data,
                // and not actually seen as part of the environment
                var synthesizedRenderer = renderer.GetComponent<SynthesizedTrait>() != null
                    || renderer.GetComponent<SynthesizedTrackable>() != null;

                if (synthesizedRenderer && seeking == SimulatedRendererType.Data)
                    results.Add(renderer);
                else if (!synthesizedRenderer && seeking == SimulatedRendererType.Environment)
                    results.Add(renderer);
            }

            return results;
        }

        internal static void SetSimDataVisibility(bool enabled)
        {
            foreach (var renderer in GetSimRenderers(SimulatedRendererType.Data))
                renderer.enabled = enabled;
        }

        internal static void SetSimEnvironmentVisibility(bool enabled)
        {
            foreach (var renderer in GetSimRenderers(SimulatedRendererType.Environment))
                renderer.enabled = enabled;
        }

        static void CullEnvironmentFromSceneLights(Scene scene)
        {
            var mask = ~(SimulationConstants.SimulatedEnvironmentLayerMask);
            foreach (var root in scene.GetRootGameObjects())
            {
                foreach (var light in root.GetComponentsInChildren<Light>())
                {
                    light.cullingMask &= mask;
                }
            }
        }

        internal void TearDownEnvironmentNotCancelable()
        {
            TrySaveEnvironmentModificationsDialog(cancelable: false);
            TearDownEnvironment();
        }

        /// <summary>
        /// Brings up the save simulated environment dialog if there are changes that are not
        /// ignored due to properties that the simulation controls.
        /// </summary>
        /// <param name="cancelable">Is the operation that caused the save dialog cancelable.</param>
        /// <returns>Returns true if the dialog was completed without canceling.</returns>
        public bool TrySaveEnvironmentModificationsDialog(bool cancelable = true)
        {
            return TrySaveEnvironmentModificationsDialog(SimulationSettings.instance.EnvironmentMode, cancelable);
        }

        internal bool TrySaveEnvironmentModificationsDialog(EnvironmentMode environmentMode, bool cancelable = true)
        {
            // Prefab based environment need to check if there are modifications that need to be saved
            if (SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic && EnvironmentSetup
                && !Application.isBatchMode && !MARSSession.TestMode
                && CurrentLoadedPrefabInstanceEnvironment != null && HasSaveableEnvironmentPrefabInstanceOverrides())
            {
                if (!cancelable || SimulationSceneModule.isAssemblyReloading || EditorApplication.isPlayingOrWillChangePlaymode)
                {
                    if (EditorUtility.DisplayDialog(k_EnvironmentModifiedDialogTitle, k_EnvironmentModifiedDialogMessage,
                        k_EnvironmentModifiedDialogOkButton, k_EnvironmentModifiedDialogAltButton))
                    {
                        SaveEnvironment();
                    }
                    else
                    {
                        TearDownEnvironment();
                    }
                }
                else
                {
                    var resultPopUpSaveModifiedEnvironment = EditorUtility.DisplayDialogComplex(
                        k_EnvironmentModifiedDialogTitle, k_EnvironmentModifiedDialogMessage,
                        k_EnvironmentModifiedDialogOkButton, k_EnvironmentModifiedDialogCancelButton,
                        k_EnvironmentModifiedDialogAltButton);

                    switch (resultPopUpSaveModifiedEnvironment)
                    {
                        case 0: // User pressed Save
                        {
                            SaveEnvironment();
                            break;
                        }
                        case 1: // User Pressed Cancel
                        {
                            if(environmentMode != EnvironmentMode.Synthetic)
                                GUIUtility.ExitGUI();
                            return false;
                        }
                        case 2: // User Pressed Discard
                        {
                            TearDownEnvironment();
                            break;
                        }
                    }
                }
            }

            SimulationSettings.instance.EnvironmentMode = environmentMode;
            return true;
        }

        void SetSimulationLightsCullingMask()
        {
            // Setting the culling mask in a light is always registered in the undo system in the current undo group.
            // To not have the lighting changed if undo/redo right after the environment is set up
            // we need to always add setting the culling mask of all the lights when undo/redo is called.
            foreach (var light in m_SimulationLights)
            {
                light.cullingMask = SimulationConstants.SimulatedEnvironmentLayerMask;
            }
        }
    }
}

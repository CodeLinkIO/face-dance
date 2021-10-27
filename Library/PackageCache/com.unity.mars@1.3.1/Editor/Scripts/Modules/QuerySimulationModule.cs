using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS;
using Unity.MARS.Data;
using Unity.MARS.Data.Reasoning;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.MARS.CodeGen;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Describes the selection of single-frame vs temporal mode when starting a new simulation
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum SimulationModeSelection
    {
        /// <summary>
        /// The new simulation will run in the same mode as the previous simulation, or single-frame mode if there is no
        /// previous one, unless a different mode has been requested
        /// </summary>
        NoModePreference,

        /// <summary>
        /// The new simulation will run in single-frame mode, unless temporal mode simulation has already been requested
        /// </summary>
        SingleFrameMode,

        /// <summary>
        /// The new simulation will run in temporal mode, unless single-frame mode simulation has already been requested
        /// </summary>
        TemporalMode
    }

    /// <summary>
    /// Module responsible for simulating queries in edit mode
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public partial class QuerySimulationModule : EditorScriptableSettings<QuerySimulationModule>, IModuleDependency<MARSDatabase>,
        IModuleDependency<MARSQueryBackend>, IModuleDependency<ReasoningModule>, IModuleDependency<SlowTaskModule>,
        IModuleDependency<SimulatedObjectsManager>, IModuleDependency<MARSEnvironmentManager>,
        IModuleDependency<EvaluationSchedulerModule>, IModuleDependency<FunctionalityInjectionModule>,
        IModuleDependency<SimulationSceneModule>, IModuleDependency<SceneWatchdogModule>, IModuleDependency<QueryPipelinesModule>,
        IUsesDatabaseQuerying, IUsesCameraOffset
    {
        static readonly Action<QueryMatchID, int> k_OnQueryMatchFound = OnQueryMatchFound;
        static readonly Action<QueryMatchID, Dictionary<int, float>> k_OnQueryMatchesFound = OnQueryMatchesFound;
        static readonly Action<QueryMatchID, Dictionary<IMRObject, int>> k_OnSetQueryMatchFound = OnSetQueryMatchFound;

        [SerializeField]
        double m_SimulationPollTime = 0.25d;

#pragma warning disable 649
        [SerializeField]
        FunctionalityIsland m_SimulationIsland;

        [SerializeField]
        FunctionalityIsland m_SimulatedDiscoveryIsland;
#pragma warning restore 649

        MARSDatabase m_Database;
        MARSQueryBackend m_QueryBackend;
        QueryPipelinesModule m_QueryPipelinesModule;
        ReasoningModule m_ReasoningModule;
        SlowTaskModule m_SlowTaskModule;
        SimulatedObjectsManager m_SimulatedObjectsManager;
        MARSEnvironmentManager m_EnvironmentManager;
        SimulationSceneModule m_SimulationSceneModule;
        SceneWatchdogModule m_SceneWatchdogModule;
        FunctionalityInjectionModule m_FIModule;
        EvaluationSchedulerModule m_SchedulerModule;

        bool m_SimulationRestartNeeded;
        EditorSlowTask m_SimulationPollTask;
        FunctionalityIsland m_OriginalActiveIsland;
        readonly SimulationContext m_SimulationContext = new SimulationContext();

        readonly List<IFunctionalityProvider> m_Providers = new List<IFunctionalityProvider>();
        readonly List<MonoBehaviour> m_ProviderBehaviours = new List<MonoBehaviour>();
        readonly List<GameObject> m_ProviderGameObjects = new List<GameObject>();

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        /// <summary>
        /// Whether a simulation is currently running
        /// </summary>
        public bool simulating { get; private set; }

        /// <summary>
        /// Whether a temporal simulation is currently running
        /// </summary>
        public bool simulatingTemporal { get; private set; }

        internal FunctionalityIsland functionalityIsland { get; private set; }

        /// <summary>
        /// Root game object for functionality providers created for simulation
        /// </summary>
        public GameObject providersRoot { get; private set; }

        internal SimulationModeSelection NextSimModeSelection { get; set; }

        internal bool KeepDataBetweenSimulations { get; set; }

        internal static bool TestMode { private get; set; }

        /// <summary>
        /// Called right after a temporal simulation has started
        /// </summary>
        public static event Action onTemporalSimulationStart;

        /// <summary>
        /// Called right after a temporal simulation has stopped
        /// </summary>
        public static event Action onTemporalSimulationStop;

        /// <summary>
        /// Called right after a single-frame simulation has started
        /// </summary>
        public static event Action OnOneShotSimulationStart;

        /// <summary>
        /// Whether the active scene can be simulated
        /// </summary>
        public static bool sceneIsSimulatable
        {
            get
            {
                return SceneWatchdogModule.instance.anyEntitiesInScene ||
                    SceneWatchdogModule.instance.anySubscribersInScene;
            }
        }

        /// <summary>
        /// Called right after a single-frame simulation has stopped
        /// </summary>
        public static event Action simulationDone;

        /// <summary>
        /// Called right before a temporal simulation ends and a new one starts
        /// </summary>
        public static event Action BeforeTemporalSimulationRestart;

        /// <summary>
        /// Called right before a simulation starts setting up
        /// </summary>
        public static event Action BeforeSimulationSetup;

        /// <summary>
        /// Called right before simulation providers are destroyed
        /// </summary>
        public static event Action BeforeCleanupProviders;

        /// <summary>
        /// Called right before default providers are setup when starting simulation.
        /// The list should be filled out with providers that you want this module to add before it sets up default providers.
        /// Provider game objects created in this callback should be created using GameObjectUtils.Create so that they get
        /// added to the simulation scene.
        /// </summary>
        public static event Action<List<IFunctionalityProvider>> addCustomProviders;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<IFunctionalitySubscriber> k_FunctionalitySubscriberObjects = new List<IFunctionalitySubscriber>();
        static readonly HashSet<TraitRequirement> k_TraitRequirements = new HashSet<TraitRequirement>();

        /// <inheritdoc />
        void IModuleDependency<MARSDatabase>.ConnectDependency(MARSDatabase dependency) { m_Database = dependency; }

        /// <inheritdoc />
        void IModuleDependency<MARSQueryBackend>.ConnectDependency(MARSQueryBackend dependency) { m_QueryBackend = dependency; }

        /// <inheritdoc />
        void IModuleDependency<QueryPipelinesModule>.ConnectDependency(QueryPipelinesModule dependency) { m_QueryPipelinesModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<ReasoningModule>.ConnectDependency(ReasoningModule dependency) { m_ReasoningModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SlowTaskModule>.ConnectDependency(SlowTaskModule dependency) { m_SlowTaskModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulatedObjectsManager>.ConnectDependency(SimulatedObjectsManager dependency) { m_SimulatedObjectsManager = dependency; }

        /// <inheritdoc />
        void IModuleDependency<MARSEnvironmentManager>.ConnectDependency(MARSEnvironmentManager dependency) { m_EnvironmentManager = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulationSceneModule>.ConnectDependency(SimulationSceneModule dependency) { m_SimulationSceneModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SceneWatchdogModule>.ConnectDependency(SceneWatchdogModule dependency) { m_SceneWatchdogModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<EvaluationSchedulerModule>.ConnectDependency(EvaluationSchedulerModule dependency) { m_SchedulerModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<FunctionalityInjectionModule>.ConnectDependency(FunctionalityInjectionModule dependency)
        {
            if (!m_SimulationIsland)
            {
                Debug.LogWarning("You need to set the simulation island", this);
                return;
            }

            if (!m_SimulatedDiscoveryIsland)
            {
                Debug.LogWarning("You need to set the simulated discovery island", this);
                return;
            }

            if (EditorApplication.isPlaying)
                return;

            m_FIModule = dependency;
            m_FIModule.AddIsland(m_SimulationIsland);
            m_FIModule.AddIsland(m_SimulatedDiscoveryIsland);
        }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            functionalityIsland = m_SimulationIsland;
            EditorApplication.update += Update;
            SimulationSceneModule.SimulationSceneOpened += OnSimulationSceneOpened;
            SimulationSceneModule.SimulationSceneClosing += OnSimulationSceneClosing;
            EditorOnlyDelegates.IsSimulatingTemporal = () => simulatingTemporal;
            CacheOriginalActiveIsland();

            // do not poll for simulation if we are running tests.  It has caused
            // hard-to-debug test failures from simulation running at unexpected times.
            m_SimulationPollTask = new EditorSlowTask(CheckIfSimulationRestartNeeded, m_SimulationPollTime);

            // Start simulation if any objects are using the sim scene
            RestartSimulationIfNeeded();
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            m_SlowTaskModule.ClearTasks();
            m_SimulationPollTask = null;
            QueryObjectMapping.Map.Clear();
            EditorApplication.update -= Update;
            SimulationSceneModule.SimulationSceneOpened -= OnSimulationSceneOpened;
            SimulationSceneModule.SimulationSceneClosing -= OnSimulationSceneClosing;
            EditorOnlyDelegates.IsSimulatingTemporal = null;
            RestoreOriginalActiveIsland();

            m_SimulationRestartNeeded = false;
            NextSimModeSelection = SimulationModeSelection.NoModePreference;
            KeepDataBetweenSimulations = false;
            m_SimulationPollTask = null;
            m_OriginalActiveIsland = null;

            CleanupProviders();

            simulating = false;
            simulatingTemporal = false;
            functionalityIsland = null;
            providersRoot = null;

            m_SimulationContext.Clear();
        }

        /// <summary>
        /// Runs simulation over a single frame.
        /// This method repeatedly checks for query matches until there are no more to be found.
        /// </summary>
        public void SimulateOneShot()
        {
            if (simulatingTemporal || !TryStartSimulation())
                return;

            OnOneShotSimulationStart?.Invoke();

            // Run database processing jobs
            m_Database.OnMarsUpdate();
            m_ReasoningModule.UpdateReasoningAPIData();

            // We keep running the task loop until it doesn't find any matches.
            // This is to ensure that relations dependent on other entities have a chance to be matched.
            // Ideally we could avoid this by sorting queries based on a dependency graph.
            bool matchFoundThisIteration;
            do
            {
                matchFoundThisIteration = m_QueryBackend.RunAllQueries();
            }
            while (matchFoundThisIteration);

            StopSimulation();

            // Avoid triggering OnDisable until module unload or the next simulation, so that simulatables keep
            // their state at the end of simulation. We still need to set runInEditMode to false - this happens in
            // a double delay call so that it doesn't interfere with Start, which happens on a delay.
            EditorApplication.delayCall += DelayStopRunningOneShot;
        }

        void DelayStopRunningOneShot()
        {
            EditorApplication.delayCall += StopRunningOneShot;
        }

        void StopRunningOneShot()
        {
            m_SimulatedObjectsManager.StopRunningSimulatablesKeepState();
            if (simulationDone != null)
                simulationDone();
        }

        /// <summary>
        /// Starts query simulation that runs frame-to-frame
        /// </summary>
        public void StartTemporalSimulation()
        {
            if (simulatingTemporal)
                return;

            simulatingTemporal = true;

            if (!TryStartSimulation())
            {
                simulatingTemporal = false;
                return;
            }

            TriggerOnTemporalSimulationStart();
        }

        /// <summary>
        /// Stops query simulation that runs frame-to-frame
        /// </summary>
        internal void StopTemporalSimulationInternal()
        {
            if (!simulatingTemporal)
                return;

            // Make it so that temporal simulation starts up again if it was interrupted by module unloading or assembly reloading
            if ((ModuleLoaderCore.isUnloadingModules || SimulationSceneModule.isAssemblyReloading) && NextSimModeSelection != SimulationModeSelection.SingleFrameMode)
                NextSimModeSelection = SimulationModeSelection.TemporalMode;

            StopSimulation();
            m_SimulatedObjectsManager.StopRunningSimulatablesKeepState();
            StopRunningProviders();
            simulatingTemporal = false;
            TriggerOnTemporalSimulationStop();

            m_QueryPipelinesModule.StandalonePipeline.ClearData();
        }

        void RestartTemporalSimulation()
        {
            // We default to preserving data when restarting simulation, but this can be changed in the
            // BeforeTemporalSimulationRestart callback
            KeepDataBetweenSimulations = true;
            BeforeTemporalSimulationRestart?.Invoke();

            if (!KeepDataBetweenSimulations)
            {
                StopTemporalSimulationInternal();
                StartTemporalSimulation();
                return;
            }

            m_EnvironmentManager.UpdateDeviceStartingPose();

            StopSimulation();
            m_SimulatedObjectsManager.StopRunningSimulatables();
            TriggerOnTemporalSimulationStop();
            if (m_QueryPipelinesModule != null)
                m_QueryPipelinesModule.StandalonePipeline.ClearData();

            if (!TryStartSimulation())
            {
                simulatingTemporal = false;
                return;
            }

            TriggerOnTemporalSimulationStart();
        }

        static void TriggerOnTemporalSimulationStart()
        {
#if UNITY_EDITOR
            EditorOnlyEvents.OnTemporalSimulationStart();
#endif
            if (onTemporalSimulationStart != null)
                onTemporalSimulationStart();
        }

        static void TriggerOnTemporalSimulationStop()
        {
            if (onTemporalSimulationStop != null)
                onTemporalSimulationStop();
        }

        bool TryStartSimulation()
        {
            if (!TraitCodeGenerator.HasGenerated || EditorApplication.isPlayingOrWillChangePlaymode)
                return false;

            var useExistingData = KeepDataBetweenSimulations;
            KeepDataBetweenSimulations = false;
            m_SimulationRestartNeeded = false;
            NextSimModeSelection = SimulationModeSelection.NoModePreference;

            // Make sure the watchdog is up-to-date before we check if the scene has entities or subscribers
            m_SceneWatchdogModule.ExecutePollingTask();
            if (!sceneIsSimulatable)
            {
                CleanupSimulation();
                return false;
            }

            if (!m_SimulationSceneModule.IsSimulationReady)
                return false;

            // if this method is null, that means something has tried to start simulation when the database isn't setup
            if (IUsesQueryResultsMethods.RegisterQuery == null)
                return false;

            var simulationSettings = SimulationSettings.instance;
            if (!simulationSettings.IsSpatialContextAvailable)
                return false;

            var marsSession = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (marsSession == null)
                return false;

            ProfilerMarkers.TryStartSimulation.Begin(); // only profile after safety checks
            if (MarsDebugSettings.QuerySimulationModuleLogging)
                Debug.Log("Start simulation");

            // Cancel delay calls in case the previous simulation was one-shot. Otherwise we can end up stopping behaviors
            // in the middle of temporal simulation or doubling up on delay calls for one-shot simulation.
            EditorApplication.delayCall -= StopRunningOneShot;
            EditorApplication.delayCall -= DelayStopRunningOneShot;

            BeforeSimulationSetup?.Invoke();

            m_SlowTaskModule.ClearTasks();
            QueryObjectMapping.Map.Clear();
            k_TraitRequirements.Clear();
            k_FunctionalitySubscriberObjects.Clear();
            EditorOnlyEvents.OnSimulationStart(k_FunctionalitySubscriberObjects, k_TraitRequirements);
            m_SimulatedObjectsManager.SetupSimulatables(k_FunctionalitySubscriberObjects);

            simulating = true;

            var providersPreserved = useExistingData;
            if (!useExistingData)
            {
                if (m_SimulationContext.Update(marsSession, k_FunctionalitySubscriberObjects, simulatingTemporal))
                {
                    if (MarsDebugSettings.QuerySimulationModuleLogging)
                        Debug.Log("Simulation context changed. Recreating providers.");

                    CleanupProviders();

                    functionalityIsland = simulationSettings.EnvironmentMode == EnvironmentMode.Synthetic && simulatingTemporal ?
                        m_SimulatedDiscoveryIsland : m_SimulationIsland;

                    providersRoot = new GameObject("Providers");
                    m_SimulationSceneModule.AddContentGameObject(providersRoot);
                    GameObjectUtils.gameObjectInstantiated += OnProviderInstantiated;

                    if (addCustomProviders != null)
                    {
                        addCustomProviders(m_Providers);
                        functionalityIsland.AddProviders(m_Providers);
                    }

                    var subscriberTypes = m_SimulationContext.SceneSubscriberTypes;
                    functionalityIsland.SetupDefaultProviders(subscriberTypes, m_Providers);
                    var definitions = new HashSet<TraitDefinition>();
                    k_TraitRequirements.UnionWith(m_SimulationContext.SceneRequirements);
                    m_ReasoningModule.ExtraTraitRequirements.Clear();
                    m_ReasoningModule.ExtraTraitRequirements.UnionWith(k_TraitRequirements);
                    foreach (var requirement in k_TraitRequirements)
                    {
                        definitions.Add(requirement);
                    }

                    functionalityIsland.RequireProvidersWithDefaultProviders(definitions, m_Providers);
                    functionalityIsland.PrepareFunctionalityForSubscriberTypes(subscriberTypes, m_Providers);

                    ModuleLoaderCore.instance.InjectFunctionalityInModules(functionalityIsland);
                    GameObjectUtils.gameObjectInstantiated -= OnProviderInstantiated;
                    providersRoot.SetHideFlagsRecursively(SimulatedObjectsManager.SimulatedObjectHideFlags);

                    foreach (var provider in m_Providers)
                    {
                        var providerBehaviour = provider as MonoBehaviour;
                        if (providerBehaviour != null)
                        {
                            m_ProviderBehaviours.Add(providerBehaviour);
                        }
                    }

                    foreach (var gameObject in m_ProviderGameObjects)
                    {
                        foreach (var simulatable in gameObject.GetComponentsInChildren<ISimulatable>())
                        {
                            var providerBehaviour = simulatable as MonoBehaviour;
                            if (providerBehaviour != null)
                            {
                                m_ProviderBehaviours.Add(providerBehaviour);
                            }
                        }
                    }
                }
                else
                {
                    providersPreserved = true;
                    StopRunningProviders();
                }
            }

            // When using providers from the last simulation, ensure they stay at the bottom of the hierarchy
            if (providersPreserved)
                providersRoot.transform.SetAsLastSibling();

            this.SetCameraScale(MarsWorldScaleModule.GetWorldScale());

            // Set active island now that providers have been setup
            m_FIModule.SetActiveIsland(functionalityIsland);
            functionalityIsland.InjectFunctionalitySingle(marsSession);
            marsSession.StartRunInEditMode();

            if (!useExistingData)
            {
                // Clear the database and then run providers in edit mode so we start getting data.
                m_Database.Clear();
                foreach (var providerBehaviour in m_ProviderBehaviours)
                {
                    providerBehaviour.StartRunInEditMode();
                }
            }

            m_ReasoningModule.ResetReasoningAPIs();

            // We must also reset the backend's query management state each time, otherwise there is no guarantee that
            // the its collections will be ordered the same way each time, even if the ordering of clients in the scene
            // stays the same. This also ensures its slow tasks are registered using edit mode time rather than play mode time.
            m_QueryBackend.ResetQueryManagement();

            GameObjectUtils.gameObjectInstantiated += m_SimulatedObjectsManager.AddSpawnedObjectToSimulation;
            m_QueryBackend.onQueryMatchFound += k_OnQueryMatchFound;
            m_QueryBackend.onSetQueryMatchFound += k_OnSetQueryMatchFound;
            if (simulationSettings.FindAllMatchingDataPerQuery)
                m_QueryBackend.onQueryMatchesFound += k_OnQueryMatchesFound;

            // inject functionality on all copied functionality subscribers
            functionalityIsland.InjectPreparedFunctionality(k_FunctionalitySubscriberObjects);

            GeoLocationModule.instance.AddOrUpdateLocationTrait();

            m_SchedulerModule.ResetTime();
            m_SimulatedObjectsManager.StartRunningSimulatables();

            ProfilerMarkers.TryStartSimulation.End();
            return true;
        }

        void StopSimulation()
        {
            GameObjectUtils.gameObjectInstantiated -= m_SimulatedObjectsManager.AddSpawnedObjectToSimulation;
            m_QueryBackend.onQueryMatchFound -= k_OnQueryMatchFound;
            m_QueryBackend.onQueryMatchesFound -= k_OnQueryMatchesFound;
            m_QueryBackend.onSetQueryMatchFound -= k_OnSetQueryMatchFound;
            m_SlowTaskModule.ClearTasks();

            foreach (var simView in SimulationView.SimulationViews)
            {
                var camera = simView.camera;
                camera.ResetProjectionMatrix();
                simView.isRotationLocked = false;
            }

            var marsSession = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (marsSession != null)
                marsSession.StopRunInEditMode();

            simulating = false;
        }

        void StopRunningProviders()
        {
            foreach (var behaviour in m_ProviderBehaviours)
            {
                if (behaviour != null)
                    behaviour.StopRunInEditMode();
            }
        }

        void CleanupProviders()
        {
            BeforeCleanupProviders?.Invoke();
            StopRunningProviders();

            if (functionalityIsland)
                functionalityIsland.RemoveProviders(m_Providers);

            UnityObjectUtils.Destroy(providersRoot);

            m_Providers.Clear();
            m_ProviderBehaviours.Clear();
            m_ProviderGameObjects.Clear();
        }

        void OnProviderInstantiated(GameObject providerObject)
        {
            // test cleanup can lead to providers getting destroyed before this callback runs
            if (providersRoot == null)
                return;

            m_ProviderGameObjects.Add(providerObject);
            providerObject.transform.SetParent(providersRoot.transform);
        }

        static void OnQueryMatchFound(QueryMatchID queryMatchID, int bestDataID)
        {
            if (MarsDebugSettings.QuerySimulationModuleLogging)
            {
                const string str = "<color=lime>Query match found</color> - <b>{0}</b>, " +
                    "data ID used: <b>{1}</b>";

                Debug.LogFormat(str, queryMatchID, bestDataID);
            }
        }

        static void OnQueryMatchesFound(QueryMatchID queryMatchID, Dictionary<int, float> allDataMatches)
        {
            if (MarsDebugSettings.QuerySimulationModuleLogging)
            {
                var allMatchingDataString = allDataMatches.Aggregate(
                    "--All matching data IDs: ", (current, kvp) => current + (kvp.Key + ", "));
                Debug.Log(allMatchingDataString);
            }
        }

        static void OnSetQueryMatchFound(QueryMatchID queryMatchID, Dictionary<IMRObject, int> matchChildren)
        {
            if (MarsDebugSettings.QuerySimulationModuleLogging)
            {
                var allMatchingDataString = matchChildren.Aggregate(
                    "--Child data IDs: ", (current, kvp) => current + (kvp.Value + ", "));
                Debug.Log(allMatchingDataString);
            }
        }

        void Update()
        {
            if (Application.isPlaying || ModuleLoaderCore.isBuilding)
                return;

            m_SimulationPollTask?.Update();

            if (!simulatingTemporal)
                return;

            EditorApplication.QueuePlayerLoopUpdate();
            m_SimulatedObjectsManager.UpdateLandmarkChildren();
        }

        /// <summary>
        /// Request that the next simulation should run in either single-frame mode or temporal mode
        /// </summary>
        /// <param name="simModeSelection">The requested mode selection method</param>
        public void RequestSimulationModeSelection(SimulationModeSelection simModeSelection)
        {
            if (!SimulationSceneModule.UsingSimulation)
                return;

            if (NextSimModeSelection == SimulationModeSelection.NoModePreference)
            {
                NextSimModeSelection = simModeSelection;
            }
            else if (simModeSelection != NextSimModeSelection)
            {
                Debug.LogWarning($"Mode selection for the next simulation has already been set to {NextSimModeSelection}. " +
                    $"Cannot override with mode selection {simModeSelection}.");
            }
        }

        /// <summary>
        /// If any objects are using the simulation scene, this method sets a flag that a new simulation should happen as soon as possible
        /// </summary>
        /// <param name="stopSimulationImmediately">If true and if temporal simulation is running, this method will
        /// immediately stop simulation. If <see cref="SimulationModeSelection.TemporalMode"/> has been requested for the
        /// next simulation then this method will invoke <see cref="BeforeTemporalSimulationRestart"/> before stopping simulation.</param>
        public void RestartSimulationIfNeeded(bool stopSimulationImmediately = false)
        {
            if (SimulationSceneModule.UsingSimulation)
            {
                if (stopSimulationImmediately && simulatingTemporal)
                {
                    if (NextSimModeSelection == SimulationModeSelection.TemporalMode)
                        BeforeTemporalSimulationRestart?.Invoke();

                    StopTemporalSimulationInternal();
                }

                m_SimulationRestartNeeded = true;
                if (MarsDebugSettings.QuerySimulationModuleLogging)
                    Debug.Log("simulation restart needed");
            }
        }

        void CheckIfSimulationRestartNeeded()
        {
            if (TestMode)
                return;

            if (m_SimulationSceneModule.IsSimulationReady && m_SimulationRestartNeeded)
            {
                switch (NextSimModeSelection)
                {
                    case SimulationModeSelection.NoModePreference:
                        if (simulatingTemporal)
                            RestartTemporalSimulation();
                        else
                            SimulateOneShot();

                        break;
                    case SimulationModeSelection.SingleFrameMode:
                        if (simulatingTemporal)
                            StopTemporalSimulationInternal();

                        SimulateOneShot();
                        break;
                    case SimulationModeSelection.TemporalMode:
                        if (simulatingTemporal)
                            RestartTemporalSimulation();
                        else
                            StartTemporalSimulation();

                        break;
                }
            }
        }

        void OnSimulationSceneOpened()
        {
            CacheOriginalActiveIsland();
            RestartSimulationIfNeeded();
        }

        void OnSimulationSceneClosing()
        {
            CleanupProviders();
            RestoreOriginalActiveIsland();

            // Reset the simulation context so that it will register an update next time we start simulation
            m_SimulationContext.Clear();
        }

        internal void CleanupSimulation()
        {
            StopTemporalSimulationInternal();
            m_SimulatedObjectsManager.CleanupSimulation();
            CleanupProviders();
            m_SimulationContext.Clear();
        }

        void CacheOriginalActiveIsland()
        {
            // This module does not override the active island in play mode
            if (Application.isPlaying)
                return;

            m_OriginalActiveIsland = m_FIModule.activeIsland;
        }

        void RestoreOriginalActiveIsland()
        {
            if (m_OriginalActiveIsland != null && m_FIModule.islands.Contains(m_OriginalActiveIsland))
                m_FIModule.SetActiveIsland(m_OriginalActiveIsland);
        }
    }
}

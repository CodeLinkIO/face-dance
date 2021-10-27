using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Settings
{
    [ModuleBehaviorCallbackOrder(ModuleOrders.SceneBehaviorOrder)]
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class MARSSceneModule : ScriptableSettings<MARSSceneModule>, IModuleBehaviorCallbacks, IUsesCameraOffset,
        IModuleDependency<FunctionalityInjectionModule>
    {
        [SerializeField]
        [Tooltip("Do not automatically create a session when proxies are detected in the scene")]
        bool m_BlockEnsureSession;

        [SerializeField]
        [Tooltip("When enabled, the simulated environment will be added in play mode, and a simulation functionality island will be used.")]
        bool m_SimulateInPlayMode = true;

#pragma warning disable 649
        [SerializeField]
        [Tooltip("When SimulateInPlayMode is enabled and SimulateDiscovery is disabled, this island will be used for functionality.")]
        FunctionalityIsland m_SimulationIsland;
#pragma warning restore 649

        [SerializeField]
        [Tooltip("When enabled and SimulateInPlayMode is enabled, the simulated discovery functionality island will be used.")]
        bool m_SimulateDiscovery = true;

#pragma warning disable 649
        [SerializeField]
        [Tooltip("When SimulateInPlayMode and SimulateDiscovery are enabled, this island will be used for functionality.")]
        FunctionalityIsland m_SimulatedDiscoveryIsland;
#pragma warning restore 649

        FunctionalityInjectionModule m_FIModule;

        /// <summary>
        /// Do not automatically create a session when proxies are detected in the scene
        /// </summary>
        public bool BlockEnsureSession { get { return m_BlockEnsureSession; } set { m_BlockEnsureSession = value; } }

        /// <summary>
        /// When enabled, the simulated environment will be added in play mode, and a simulation functionality island will be used.
        /// </summary>
        public bool simulateInPlaymode { get { return m_SimulateInPlayMode; } set { m_SimulateInPlayMode = value; } }

        /// <summary>
        /// When enabled and SimulateInPlayMode is enabled, the simulated discovery functionality island will be used.
        /// </summary>
        public bool simulateDiscovery { get { return m_SimulateDiscovery; } set { m_SimulateDiscovery = value; } }

        /// <summary>
        /// When enabled and SimulateInPlayMode is enabled, the simulated discovery functionality island will be used.
        /// </summary>
        public static bool simulatedDiscoveryInPlayMode
        {
            get { return instance != null && instance.m_SimulateInPlayMode && instance.m_SimulateDiscovery; }
        }

        /// <inheritdoc />
        public IProvidesCameraOffset provider { get; set; }

        /// <summary>
        /// Objects that are not part of the active scene hierarchy but included when gathering functionality subscribers
        /// and providers from the MARS scene
        /// </summary>
        internal List<object> CustomRuntimeSceneObjects => m_CustomRuntimeSceneObjects;

        /// <summary>
        /// Called right before default providers are setup.
        /// The list should be filled out with providers that you want this module to add before it sets up default providers.
        /// </summary>
        public event Action<List<IFunctionalityProvider>> BeforeSetupDefaultProviders;

        readonly List<object> m_CustomRuntimeSceneObjects = new List<object>();

        static readonly List<MonoBehaviour> k_MonoBehaviours = new List<MonoBehaviour>();
        static readonly List<object> k_MonoBehaviourObjects = new List<object>();

        /// <inheritdoc />
        void IModule.LoadModule() { }

        /// <inheritdoc />
        void IModule.UnloadModule() { }

        /// <inheritdoc />
        void IModuleDependency<FunctionalityInjectionModule>.ConnectDependency(FunctionalityInjectionModule dependency)
        {
            m_FIModule = dependency;
            // TODO: Collect all scenes and add islands if modules persist between scene loads
#if UNITY_EDITOR
            var session = Application.isPlaying ?
                MARSSession.Instance :
                MarsRuntimeUtils.GetMarsSessionInActiveScene();
#else
            var session = MARSSession.Instance;
#endif

            // TODO: Don't load modules for non-MARS scenes
            if (session == null)
                return;

            FunctionalityIsland island = null;

            if (session.island)
                island = session.island;

#if UNITY_EDITOR
            if (Application.isPlaying && m_SimulateInPlayMode)
            {
                if (m_SimulateDiscovery)
                {
                    if (m_SimulatedDiscoveryIsland == null)
                    {
                        Debug.LogWarning("There is no simulated discovery island set in the MARSSceneModule to be used for play mode simulation");
                        return;
                    }

                    island = m_SimulatedDiscoveryIsland;
                }
                else
                {
                    if (m_SimulationIsland == null)
                    {
                        Debug.LogWarning("There is no simulation island set in the MARSSceneModule to be used for play mode simulation");
                        return;
                    }

                    island = m_SimulationIsland;
                }
            }
#endif
            if (island)
                dependency.AddIsland(island);
        }

        /// <summary>
        /// Gets all MonoBehaviours in the scene, including ones on inactive objects
        /// </summary>
        static void GetAllMonoBehaviors()
        {
            k_MonoBehaviours.Clear();
            k_MonoBehaviourObjects.Clear();
            var loadedSceneCount = SceneManager.sceneCount;
            for (var i = 0; i < loadedSceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    GetMonoBehaviorsRecursively(gameObject);
                }
            }
        }

        static void GetMonoBehaviorsRecursively(GameObject gameObject)
        {
            gameObject.GetComponents(k_MonoBehaviours);
            foreach (var behaviour in k_MonoBehaviours)
            {
                k_MonoBehaviourObjects.Add(behaviour);
            }

            foreach (Transform child in gameObject.transform)
            {
                GetMonoBehaviorsRecursively(child.gameObject);
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake()
        {
            if (!Application.isPlaying)
                return;

            var session = MARSSession.Instance;
            if (session == null)
                return;

            GetAllMonoBehaviors();
            var subscriberCount = 0;
            var sceneObjects = k_MonoBehaviourObjects;
            sceneObjects.AddRange(m_CustomRuntimeSceneObjects);
            var providers = new List<IFunctionalityProvider>();
            var providerTypes = new HashSet<Type>();
            var subscriberTypes = new HashSet<Type>();
            subscriberTypes.Add(typeof(MARSSceneModule));
            foreach (var behavior in sceneObjects)
            {
                // Exclude modules as they have already been set up for FI
                if (behavior is IModule)
                    continue;

                var functionalityProvider = behavior as IFunctionalityProvider;
                if (functionalityProvider != null)
                {
                    providers.Add(functionalityProvider);
                    providerTypes.Add(functionalityProvider.GetType());
                }

                var subscriber = behavior as IFunctionalitySubscriber;
                if (subscriber != null)
                {
                    subscriberCount++;
                    subscriberTypes.Add(subscriber.GetType());
                }
            }

            if (MarsDebugSettings.SceneModuleLogging)
            {
                Debug.Log(string.Format("Scene Module found {0} providers with types: {1}", providers.Count,
                    string.Join(",", providerTypes.Select(type => type.Name).ToArray())));
                Debug.Log(string.Format("Scene Module found {0} subscribers with types: {1}", subscriberCount,
                    string.Join(",", subscriberTypes.Select(type => type.Name).ToArray())));
            }

            // TODO: notify other modules (i.e. backend) that the active island has changed
#if UNITY_EDITOR
            var useSimulationIsland = Application.isPlaying && simulateInPlaymode;
            if (useSimulationIsland)
            {
                var simulationIsland = m_SimulateDiscovery ? m_SimulatedDiscoveryIsland : m_SimulationIsland;
                if (simulationIsland != null)
                    m_FIModule.SetActiveIsland(simulationIsland);
            }
            else
            {
                var island = session.island;
                if (island != null)
                    m_FIModule.SetActiveIsland(island);
            }
#else
            var island = session.island;
            if (island)
                m_FIModule.SetActiveIsland(island);
#endif
            var activeIsland = m_FIModule.activeIsland;
            activeIsland.AddProviders(providers);

            var newProviders = new List<IFunctionalityProvider>();
            if (BeforeSetupDefaultProviders != null)
            {
                BeforeSetupDefaultProviders(newProviders);
                activeIsland.AddProviders(newProviders);
            }

            activeIsland.SetupDefaultProviders(subscriberTypes, newProviders);

            var definitions = new HashSet<TraitDefinition>();
            foreach (var requirement in session.requirements.TraitRequirements)
            {
                definitions.Add(requirement);
            }

            activeIsland.InjectFunctionality(sceneObjects);
            activeIsland.RequireProvidersWithDefaultProviders(definitions, newProviders);
            sceneObjects.Clear();
            sceneObjects.AddRange(newProviders);
            activeIsland.InjectFunctionality(sceneObjects);
            activeIsland.InjectFunctionalitySingle(this);

#if UNITY_EDITOR
            if (EditorOnlyDelegates.CullEnvironmentFromSceneLights != null)
            {
                for (var i = 0; i < SceneManager.sceneCount; i++)
                {
                    EditorOnlyDelegates.CullEnvironmentFromSceneLights(SceneManager.GetSceneAt(i));
                }
            }
#endif

            // Update the scale provider to the scene's session scale in case it needs to cache this value
            this.SetCameraScale(session.transform.localScale.x);
            subscriberTypes.Clear();
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable() { }
        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }
        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }
        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }
        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { m_CustomRuntimeSceneObjects.Clear(); }

        /// <summary>
        /// Add runtime objects to include when gathering functionality subscribers and providers from the MARS scene.
        /// This also updates the scene requirements in the MARS Session.
        /// </summary>
        /// <param name="sceneObjects">Collection of objects to include in the MARS scene</param>
        public void AddRuntimeSceneObjects(IEnumerable<object> sceneObjects)
        {
            m_CustomRuntimeSceneObjects.AddRange(sceneObjects);
            var session = MARSSession.Instance;
            if (session != null)
                session.CheckCapabilities();
        }
    }
}

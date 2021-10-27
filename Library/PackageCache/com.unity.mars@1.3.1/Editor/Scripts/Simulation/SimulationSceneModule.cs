using System;
using Unity.MARS;
using Unity.MARS.MARSUtils;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Maintains a preview scene that the MARS Environment Manager uses to hold the environment objects
    /// and simulation query objects.
    /// </summary>
    [ModuleOrder(ModuleOrders.SimSceneLoadOrder)]
    [ModuleUnloadOrder(ModuleOrders.SimSceneLoadOrder)]
    [ModuleBehaviorCallbackOrder(ModuleOrders.SimSceneBehaviorOrder)]
    [MovedFrom("Unity.MARS")]
    public partial class SimulationSceneModule : IModuleDependency<MARSSceneModule>, IModuleBehaviorCallbacks
    {
        SimulationScene m_SimulationScene;
        SimulationSceneUsers m_SimulationSceneUsers;
        MARSSceneModule m_SceneModule;
        bool m_SceneModuleIsUser;

        /// <summary>
        /// Is the simulation scene open and ready to be used.
        /// </summary>
        public bool IsSimulationReady => m_SimulationScene != null && m_SimulationScene.contentScene.IsValid()
            && m_SimulationScene.contentScene.isLoaded;

        /// <summary>
        /// Are there any simulation scene users.
        /// </summary>
        public static bool UsingSimulation => SimulationSceneUsers.instance
            && SimulationSceneUsers.instance.simulationSceneUserCount > 0;

        /// <summary>
        /// Are the assemblies being reloaded
        /// </summary>
        public static bool isAssemblyReloading { get; internal set; }

        /// <summary>
        /// Current instance of the <c>SimulationSceneModule</c>
        /// </summary>
        public static SimulationSceneModule instance { get; private set; }

        /// <summary>
        /// The preview scene being used by the Simulation View to render simulated content objects.
        /// </summary>
        public Scene ContentScene => m_SimulationScene?.contentScene ?? new Scene();

        /// <summary>
        /// The preview scene being used by the Simulation View to render the simulated environment.
        /// </summary>
        public Scene EnvironmentScene => m_SimulationScene?.environmentScene ?? new Scene();

        /// <summary>
        /// Root game object in the Content Scene.
        /// </summary>
        public GameObject ContentRoot => m_SimulationScene?.contentRoot;

        /// <summary>
        /// Root game object in the Environment Scene.
        /// </summary>
        public GameObject EnvironmentRoot => m_SimulationScene?.environmentRoot;

        /// <summary>
        /// Callback for when a simulation scene is opened.
        /// </summary>
        public static event Action SimulationSceneOpened;

        /// <summary>
        /// Callback for when a simulation scene is closing.
        /// </summary>
        public static event Action SimulationSceneClosing;

        /// <inheritdoc/>
        void IModuleBehaviorCallbacks.OnBehaviorAwake()
        {
            if (!Application.isPlaying)
                return;

            if (m_SceneModule.simulateInPlaymode)
                OpenSimulation();
        }

        /// <inheritdoc/>
        void IModuleBehaviorCallbacks.OnBehaviorEnable() { }

        /// <inheritdoc/>
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }

        /// <inheritdoc/>
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }

        /// <inheritdoc/>
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }

        /// <inheritdoc/>
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }

        /// <summary>
        /// Checks whether the camera is assigned to the simulation.
        /// </summary>
        /// <param name="camera">Camera to check if is assigned to the simulation.</param>
        /// <returns><c>True</c> is camera is assigned to the simulation.</returns>
        public bool IsCameraAssignedToSimulationScene(Camera camera)
        {
            return camera != null && IsSimulationReady && m_SimulationScene.IsCameraAssignedToSimulationScene(camera);
        }

        /// <summary>
        /// Moves a GameObject to the simulated content scene
        /// </summary>
        /// <param name="go"> The GameObject to move</param>
        /// <param name="keepAtRoot">Will keep the object at the root level of the simulated content scene
        /// otherwise it will be added the simulated content scene root object.</param>
        public void AddContentGameObject(GameObject go, bool keepAtRoot = false)
        {
            m_SimulationScene.AddSimulatedGameObject(go, true, keepAtRoot);
        }

        /// <summary>
        /// Moves a GameObject to the simulated Environment scene
        /// </summary>
        /// <param name="go"> The GameObject to move</param>
        /// <param name="keepAtRoot">Will keep the object at the root level of the simulated environment scene
        /// otherwise it will be added the simulated environment scene root object.</param>
        public void AddEnvironmentGameObject(GameObject go, bool keepAtRoot = false)
        {
            m_SimulationScene.AddSimulatedGameObject(go, false, keepAtRoot);
        }

        /// <summary>
        /// Assigns a camera to a simulation with proper settings to render that view.
        /// </summary>
        /// <param name="camera">Camera to render a simulation scene</param>
        public void AssignCameraToSimulation(Camera camera)
        {
            m_SimulationScene.AssignCameraToSimulation(camera);
        }

        /// <summary>
        /// Camera to be removed from rendering a simulation.
        /// </summary>
        /// <param name="camera">Camera to stop rendering the simulation scene</param>
        public void RemoveCameraFromSimulation(Camera camera)
        {
            if (m_SimulationScene != null)
                m_SimulationScene.RemoveCameraFromSimulationScene(camera);
        }

        /// <summary>
        /// Is the Scriptable Object assigned as a user of the Simulation Scene
        /// </summary>
        /// <param name="user">The object to check if using</param>
        /// <returns>True if the object is using the simulation scene</returns>
        public static bool ContainsSimulationUser(ScriptableObject user)
        {
            return SimulationSceneUsers.instance &&
                SimulationSceneUsers.instance.ContainsSimulationUser(user);
        }

        /// <summary>
        /// Adds an object to the simulation scene users and opens the simulation scene if it is not already open
        /// </summary>
        /// <param name="user">The object using the simulation scene</param>
        public void RegisterSimulationUser(ScriptableObject user)
        {
            m_SimulationSceneUsers.AddSimulationUser(user);
            OpenSimulation();
        }

        /// <summary>
        /// Removes an object from the simulation scene users.
        /// If there are no users after this removal then the simulation scene is closed.
        /// </summary>
        /// <param name="user">The object no longer using the simulation scene</param>
        public void UnregisterSimulationUser(ScriptableObject user)
        {
            if (m_SimulationSceneUsers)
            {
                m_SimulationSceneUsers.RemoveSimulationUser(user);

                if (m_SimulationSceneUsers.simulationSceneUserCount < 1)
                    CloseSimulation();
            }
            else
                CloseSimulation();
        }

        /// <summary>
        /// Opens a new simulation scene if it is not already open and if any objects are using the simulation scene
        /// </summary>
        void OpenSimulation()
        {
            if (m_SimulationScene == null && UsingSimulation)
            {
                m_SimulationScene = new SimulationScene();
                EditorOnlyDelegates.GetSimulatedContentScene = () => m_SimulationScene.contentScene;
                EditorOnlyDelegates.GetSimulatedEnvironmentScene = () => m_SimulationScene.environmentScene;

                if (SimulationSceneOpened != null)
                    SimulationSceneOpened();
            }
        }

        /// <summary>
        /// Closes the current simulation scene without changing if any objects are using the simulation scene
        /// </summary>
        public void CloseSimulation()
        {
            if (m_SimulationScene != null)
            {
                if (SimulationSceneClosing != null)
                    SimulationSceneClosing();

                m_SimulationScene.Dispose();
                m_SimulationScene = null;
            }

            EditorOnlyDelegates.GetSimulatedContentScene = null;
            EditorOnlyDelegates.GetSimulatedEnvironmentScene = null;
        }

        /// <inheritdoc/>
        void IModuleDependency<MARSSceneModule>.ConnectDependency(MARSSceneModule dependency) { m_SceneModule = dependency; }

        /// <inheritdoc/>
        void IModule.LoadModule()
        {
            if (!m_SceneModule.simulateInPlaymode && Application.isPlaying)
                return;

            // TODO: Move environment manager functionality to runtime assembly
            EditorOnlyDelegates.OpenSimulationScene = OpenSimulation;
            EditorOnlyDelegates.GetSimulatedContentRoot = () => ContentRoot;
            instance = this;

            if (!SimulationSceneUsers.instance)
                m_SimulationSceneUsers = SimulationSceneUsers.CreateSimulationSceneSubscribers();
            else
                m_SimulationSceneUsers = SimulationSceneUsers.instance;

            if (m_SceneModule.simulateInPlaymode && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                m_SimulationSceneUsers.AddSimulationUser(MARSSceneModule.instance);
                m_SceneModuleIsUser = true;
            }

            if (!Application.isPlaying)
                OpenSimulation();

            AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReload;
            AssemblyReloadEvents.beforeAssemblyReload += OnBeforeAssemblyReload;
        }

        /// <inheritdoc/>
        void IModule.UnloadModule()
        {
            if (m_SimulationSceneUsers && m_SceneModuleIsUser)
                m_SimulationSceneUsers.RemoveSimulationUser(MARSSceneModule.instance);

            EditorOnlyDelegates.GetSimulatedContentRoot = null;
            EditorOnlyDelegates.OpenSimulationScene = null;
            CloseSimulation();

            AssemblyReloadEvents.afterAssemblyReload -= OnAfterAssemblyReload;
            AssemblyReloadEvents.beforeAssemblyReload -= OnBeforeAssemblyReload;

            instance = null;
        }

        void OnAfterAssemblyReload()
        {
            isAssemblyReloading = false;
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            if (!SimulationSceneUsers.instance)
                m_SimulationSceneUsers = SimulationSceneUsers.CreateSimulationSceneSubscribers();
            else
                m_SimulationSceneUsers = SimulationSceneUsers.instance;

            OpenSimulation();
        }

        void OnBeforeAssemblyReload()
        {
            isAssemblyReloading = true;
            CloseSimulation();
        }
    }
}

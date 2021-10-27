using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.MARS;
using Unity.MARS.Landmarks;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.MARS.Authoring;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Module responsible for copying simulatable objects to the simulation scene, mapping between these copies and their originals,
    /// and checking for changes to the original objects
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class SimulatedObjectsManager : EditorScriptableSettings<SimulatedObjectsManager>, IModuleDependency<QuerySimulationModule>,
        IModuleDependency<MARSEnvironmentManager>, IModuleDependency<SimulationSceneModule>,
        IModuleDependency<SceneWatchdogModule>
    {
        /// <summary>
        /// Hide flags for game objects in the simulated content scene
        /// </summary>
        public const HideFlags SimulatedObjectHideFlags = HideFlags.DontSave;

        const string k_TemporaryRootName = "DELETE ME | temporary root used by SimulatedObjectsManager";
        const string k_SimulatedContentRootName = "Augmented Objects";

        static readonly Dictionary<Type, MethodInfo> k_OnDisableMethods = new Dictionary<Type, MethodInfo>();

        readonly Dictionary<ISimulatable, ISimulatable> m_CopiedToOriginalSimulatables = new Dictionary<ISimulatable, ISimulatable>();
        readonly Dictionary<ISimulatable, ISimulatable> m_OriginalToCopiedSimulatables = new Dictionary<ISimulatable, ISimulatable>();
        readonly Dictionary<Transform, Transform> m_OriginalToCopiedTransforms = new Dictionary<Transform, Transform>();
        readonly Dictionary<Transform, Transform> m_CopiedToOriginalTransforms = new Dictionary<Transform, Transform>();

        QuerySimulationModule m_QuerySimulationModule;
        MARSEnvironmentManager m_EnvironmentManager;
        SimulationSceneModule m_SimulationSceneModule;
        SceneWatchdogModule m_SceneWatchdogModule;

        EditorSlowTask m_SimulatableChangeFinalizedTask;
        EditorSlowTask m_OffsetChangeFinalizedTask;
        bool m_SimulatableSceneDirty;

        readonly List<MonoBehaviour> m_SimulatableBehaviours = new List<MonoBehaviour>();
        readonly List<MonoBehaviour> m_SpawnedSimulatableBehaviours = new List<MonoBehaviour>();
        readonly List<GameObject> m_SpawnedSimulatableObjects = new List<GameObject>();
        readonly Dictionary<LandmarkController, LandmarkController> m_LandmarkControllers = new Dictionary<LandmarkController, LandmarkController>();
        readonly HashSet<MonoBehaviour> m_SimulatableBehavioursBlockingSyncing = new HashSet<MonoBehaviour>();

        /// <summary>
        /// The root object that simulated content copies are added to
        /// </summary>
        public GameObject SimulatedContentRoot { get; private set; }

        /// <summary>
        /// The copied MARS camera reference in the simulated content scene
        /// </summary>
        public Camera SimulatedCamera { get; private set; }

        /// <summary>
        /// Number of behaviours that are currently blocking auto resync
        /// </summary>
        public int SimulatableBehavioursBlockingResyncCount => m_SimulatableBehavioursBlockingSyncing.Count;

        /// <summary>
        /// Whether the simulated content reflects the state of the active scene
        /// </summary>
        public bool SimulationSyncedWithScene { get; private set; }

        internal bool IsCameraOffsetDirty { get; private set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<GameObject> k_RootGameObjects = new List<GameObject>();
        static readonly List<ISimulatable> k_OriginalSimulatables = new List<ISimulatable>();
        static readonly List<ISimulatable> k_CopiedSimulatables = new List<ISimulatable>();
        static readonly List<ISimulatable> k_SynthBufferSimulatables = new List<ISimulatable>();
        static readonly List<Light> k_CopiedLights = new List<Light>();
        static readonly List<Transform> k_OriginalTransforms = new List<Transform>();
        static readonly List<Transform> k_CopiedTransforms = new List<Transform>();
        static readonly List<IFunctionalitySubscriber> k_Subscribers = new List<IFunctionalitySubscriber>();

        /// <inheritdoc />
        void IModuleDependency<QuerySimulationModule>.ConnectDependency(QuerySimulationModule dependency) { m_QuerySimulationModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<MARSEnvironmentManager>.ConnectDependency(MARSEnvironmentManager dependency) { m_EnvironmentManager = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulationSceneModule>.ConnectDependency(SimulationSceneModule dependency) { m_SimulationSceneModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SceneWatchdogModule>.ConnectDependency(SceneWatchdogModule dependency) { m_SceneWatchdogModule = dependency; }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            // Simulated objects manager should not be providing the camera in play mode
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                MarsRuntimeUtils.TryGetActiveCamera = TryGetSimulatedCamera;

            EditorOnlyDelegates.AddSpawnedTransformToSimulationManager = AddSpawnedTransformToSimulationManager;
            EditorOnlyDelegates.AddSpawnedSimulatableToSimulationManager = AddSpawnedSimulatableToSimulationManager;
            EditorOnlyDelegates.DirtySimulatableScene = DirtySimulatableScene;
            EditorOnlyDelegates.GetSimulatedObjectsRoot = () => SimulatedContentRoot;
            EditorOnlyEvents.onBlockSimulationSync += BlockSimulationSync;
            Undo.postprocessModifications += OnPostprocessModifications;
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
            EditorApplication.update += Update;
            m_SceneWatchdogModule.prefabInstanceReverted += PrefabInstanceReverted;
            SimulationSceneModule.SimulationSceneClosing += OnSimulationSceneClosing;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            CleanupSimulation();
            m_SimulatableSceneDirty = false;
            IsCameraOffsetDirty = false;
            SimulationSyncedWithScene = false;

            MarsRuntimeUtils.TryGetActiveCamera = null;
            EditorOnlyDelegates.AddSpawnedTransformToSimulationManager = null;
            EditorOnlyDelegates.AddSpawnedSimulatableToSimulationManager = null;
            EditorOnlyDelegates.DirtySimulatableScene = null;
            EditorOnlyDelegates.GetSimulatedObjectsRoot = null;
            EditorOnlyEvents.onBlockSimulationSync -= BlockSimulationSync;

            Undo.postprocessModifications -= OnPostprocessModifications;
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
            EditorApplication.update -= Update;
            m_SceneWatchdogModule.prefabInstanceReverted -= PrefabInstanceReverted;
            SimulationSceneModule.SimulationSceneClosing -= OnSimulationSceneClosing;
        }

        Camera TryGetSimulatedCamera() { return SimulatedCamera; }

        /// <summary>
        /// Checks whether an object is a simulated object.
        /// </summary>
        /// <param name="obj"> The gameobject to check. </param>
        /// <returns>True if the object is a simulated object</returns>
        public static bool IsSimulatedObject(GameObject obj)
        {
            var simulatedContentRoot = instance.SimulatedContentRoot;
            return obj != null && simulatedContentRoot != null &&
                obj.transform.IsChildOf(simulatedContentRoot.transform);
        }

        /// <summary>
        /// Returns the original version of an ISimulatable copied to the simulation scene, if there is one
        /// </summary>
        /// <param name="copy">The ISimulatable in the simulation scene</param>
        /// <returns>The original version of the copied object</returns>
        public ISimulatable GetOriginalSimulatable(ISimulatable copy)
        {
            ISimulatable original;
            return m_CopiedToOriginalSimulatables.TryGetValue(copy, out original) ? original : null;
        }

        /// <summary>
        /// Returns the simulation scene copy of an ISimulatable, if there is one
        /// </summary>
        /// <param name="original">The original version of a copied ISimulatable</param>
        /// <returns></returns>
        public ISimulatable GetCopiedSimulatable(ISimulatable original)
        {
            ISimulatable copy;
            return m_OriginalToCopiedSimulatables.TryGetValue(original, out copy) ? copy : null;
        }

        /// <summary>
        /// Returns the simulation scene copy of a Transform, if there is one
        /// </summary>
        /// <param name="original">The original version of a copied Transform</param>
        /// <returns></returns>
        public Transform GetCopiedTransform(Transform original)
        {
            Transform copy;
            return m_OriginalToCopiedTransforms.TryGetValue(original, out copy) ? copy : null;
        }

        /// <summary>
        /// Returns the original scene copy of a simulation scene Transform, if there is one
        /// </summary>
        /// <param name="copy">The copied version of a Transform</param>
        /// <returns></returns>
        public Transform GetOriginalTransform(Transform copy)
        {
            Transform original;
            return m_CopiedToOriginalTransforms.TryGetValue(copy, out original) ? original : null;
        }

        /// <summary>
        /// Returns the original scene copy of a simulation scene Object, if there is one being managed
        /// </summary>
        /// <param name="copy">The copied version of an object</param>
        /// <returns></returns>
        public UnityObject GetOriginalObject(UnityObject copy)
        {
            UnityObject originalObj = null;
            var simulatable = copy as ISimulatable;
            if (simulatable != null)
                originalObj = (UnityObject)GetOriginalSimulatable(simulatable);

            if (originalObj == null)
            {
                var tf = copy as Transform;
                if (tf != null)
                    originalObj = GetOriginalTransform(tf);
            }

            if (originalObj == null)
            {
                var go = copy as GameObject;
                if (go != null)
                {
                    var originalTransform = GetOriginalTransform(go.transform);
                    if (originalTransform != null)
                        originalObj = originalTransform.gameObject;
                }
            }

            if (originalObj == null)
            {
                var component = copy as Component;
                if (component != null)
                {
                    var type = component.GetType();
                    var index = component.GetComponents(type).ToList().IndexOf(component);
                    var originalTransform = GetOriginalTransform(component.transform);
                    if (originalTransform != null)
                        originalObj = originalTransform.GetComponents(type)[index];
                }
            }

            return originalObj;
        }

        /// <summary>
        /// Sets flags that the active scene has been modified and simulation should restart.
        /// This guarantees that the scene contents will be copied to the simulation scene for the next simulation.
        /// </summary>
        public void DirtySimulatableScene()
        {
            m_SimulatableSceneDirty = true;
            SimulationSyncedWithScene = false;
            RestartSimulationIfNeeded();
        }

        /// <summary>
        /// Cleans up objects from the last simulation and sets up objects for a new simulation.
        /// If the active scene and its contents have not changed since the last simulation, this will preserve objects
        /// from the last simulation (aside from objects spawned during simulation). Otherwise the previous objects will
        /// be destroyed and replaced with new copies from the active scene.
        /// <param name="subscribers">List that will be populated with functionality subscribers among the simulated objects</param>
        /// </summary>
        internal void SetupSimulatables(List<IFunctionalitySubscriber> subscribers)
        {
            foreach (var behaviour in m_SimulatableBehaviours)
            {
                CleanupBehaviour(behaviour);
            }

            foreach (var behaviour in m_SpawnedSimulatableBehaviours)
            {
                CleanupBehaviour(behaviour);

                if (behaviour != null)
                    m_CopiedToOriginalSimulatables.Remove((ISimulatable)behaviour);
            }

            foreach (var gameObject in m_SpawnedSimulatableObjects)
            {
                if (gameObject == null)
                    continue;

                m_CopiedToOriginalTransforms.Remove(gameObject.transform);
                DestroyImmediate(gameObject);
            }

            var copySimulatables = m_SimulatableSceneDirty || m_SimulatableBehaviours.Count == 0;
            if (!copySimulatables)
            {
                foreach (var behaviour in m_SimulatableBehaviours)
                {
                    if (behaviour == null)
                    {
                        // Cannot reuse simulatables that have been destroyed
                        copySimulatables = true;
                        break;
                    }
                }
            }

            var logging = MarsDebugSettings.SimObjectsManagerLogging;
            if (copySimulatables)
            {
                if (logging)
                    Debug.Log("Destroy and copy simulatables");

                m_SimulatableSceneDirty = false;
                CopySimulatablesToSimulationScene();
            }
            else
            {
                if (logging)
                    Debug.Log("Preserve simulatables");

                var startingPose = m_EnvironmentManager.DeviceStartingPose;
                SimulatedCamera.transform.SetLocalPose(startingPose);
            }

            IsCameraOffsetDirty = false;

            m_SpawnedSimulatableObjects.Clear();
            m_SpawnedSimulatableBehaviours.Clear();

            GetSubscribersInChildren(SimulatedContentRoot, subscribers);
            GetSubscribersInChildren(m_EnvironmentManager.EnvironmentParent, subscribers);

            SimulationSyncedWithScene = true;
        }

        static void GetSubscribersInChildren(GameObject gameObject, List<IFunctionalitySubscriber> subscribers)
        {
            k_Subscribers.Clear();
            gameObject.GetComponentsInChildren(k_Subscribers);
            subscribers.AddRange(k_Subscribers);
        }

        /// <summary>
        /// Starts running the current simulated behaviours in edit mode. This triggers OnEnable for the behaviours.
        /// </summary>
        internal void StartRunningSimulatables()
        {
            // We disable each simulatable before running it, and then enable it if it was enabled. This prevents
            // the possibility of OnDisable being called right before OnEnable.
            foreach (var behaviour in m_SimulatableBehaviours)
            {
                var wasEnabled = behaviour.enabled;
                if (wasEnabled)
                    behaviour.enabled = false;

                behaviour.runInEditMode = true;
                if (wasEnabled)
                    behaviour.enabled = true;
            }
        }

        /// <summary>
        /// Adds the given Game Object to the current simulation and starts running its ISimulatable behaviours
        /// </summary>
        /// <param name="gameObject">The Game Object to add to simulation</param>
        public void AddSpawnedObjectToSimulation(GameObject gameObject)
        {
            if (gameObject.transform.parent == null && SimulatedContentRoot != null)
            {
                m_SimulationSceneModule.AddContentGameObject(gameObject);
                gameObject.transform.SetParent(SimulatedContentRoot.transform, true);
                gameObject.SetHideFlagsRecursively(SimulatedObjectHideFlags);
            }

            k_Subscribers.Clear();
            gameObject.GetComponentsInChildren(k_Subscribers);
            m_QuerySimulationModule.functionalityIsland.InjectPreparedFunctionality(k_Subscribers);

            // Because GameObjects may be created in Awake, AddSpawnedObjectToSimulation can be called recursively, thus
            // we cannot re-use the list of simulatables as it may be modified while iterating
            var simulatablesList = CollectionPool<List<ISimulatable>, ISimulatable>.GetCollection();
            gameObject.GetComponentsInChildren(simulatablesList);
            foreach (var simulatable in simulatablesList.Cast<MonoBehaviour>())
            {
                m_SpawnedSimulatableBehaviours.Add(simulatable);
                simulatable.StartRunInEditMode();
            }

            m_SpawnedSimulatableObjects.Add(gameObject);
            CollectionPool<List<ISimulatable>, ISimulatable>.RecycleCollection(simulatablesList);
        }

        /// <summary>
        /// Stops running the current simulated behaviours in edit mode. This triggers OnDisable for the behaviours.
        /// </summary>
        internal void StopRunningSimulatables()
        {
            foreach (var behaviour in m_SimulatableBehaviours)
            {
                if (behaviour != null)
                    behaviour.StopRunInEditMode();
            }

            foreach (var behaviour in m_SpawnedSimulatableBehaviours)
            {
                if (behaviour != null)
                    behaviour.StopRunInEditMode();
            }
        }

        /// <summary>
        /// Stops running the current simulated behaviours in edit mode.
        /// Unlike <see cref="StopRunningSimulatables"/> this does not trigger OnDisable for the behaviours.
        /// </summary>
        internal void StopRunningSimulatablesKeepState()
        {
            foreach (var behaviour in m_SimulatableBehaviours)
            {
                StopRunningBehaviourKeepState(behaviour);
            }

            foreach (var behaviour in m_SpawnedSimulatableBehaviours)
            {
                StopRunningBehaviourKeepState(behaviour);
            }
        }

        internal void CleanupSimulation()
        {
            if (SimulatedContentRoot == null) // Simulation has already been cleaned up
                return;

            foreach (var behaviour in m_SimulatableBehaviours)
            {
                CleanupBehaviour(behaviour);
            }

            foreach (var behaviour in m_SpawnedSimulatableBehaviours)
            {
                CleanupBehaviour(behaviour);
            }

            DestroySimulatedObjectsRoot();

            m_SimulatableBehaviours.Clear();
            m_SpawnedSimulatableBehaviours.Clear();
            m_SpawnedSimulatableObjects.Clear();
            m_CopiedToOriginalSimulatables.Clear();
            m_OriginalToCopiedSimulatables.Clear();
            m_CopiedToOriginalTransforms.Clear();
            m_OriginalToCopiedTransforms.Clear();
        }

        static void CleanupBehaviour(MonoBehaviour behaviour)
        {
            if (behaviour == null)
                return;

            if (behaviour.runInEditMode)
            {
                behaviour.StopRunInEditMode();
                return;
            }

            if (!behaviour.enabled)
                return;

            TryCallOnDisable(behaviour);
        }

        static void TryCallOnDisable(MonoBehaviour behaviour)
        {
            var type = behaviour.GetType();

            MethodInfo method;
            if (!k_OnDisableMethods.TryGetValue(type, out method))
            {
                method = type.GetMethod("OnDisable", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                k_OnDisableMethods[type] = method;
            }

            try
            {
                if (method != null)
                    method.Invoke(behaviour, null);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        static void StopRunningBehaviourKeepState(MonoBehaviour behaviour)
        {
            if (behaviour == null)
                return;

            // Force queries to have a state of Unavailable if they are not tracking, so that it is clear
            // which queries did not find a match in the simulation.
            var realWorldObject = behaviour as Proxy;
            if (realWorldObject != null && realWorldObject.queryState != QueryState.Tracking)
                realWorldObject.UpdateQueryState(QueryState.Unavailable, null, true);

            var set = behaviour as ProxyGroup;
            if (set != null && set.queryState != QueryState.Tracking)
                set.UpdateQueryState(QueryState.Unavailable, null, true);

            behaviour.StopAllCoroutines();
            behaviour.runInEditMode = false;
        }

        void CopySimulatablesToSimulationScene()
        {
            ProfilerMarkers.CopySimulatablesToSimulationScene.Begin();
            // Destroy old copied objects and objects spawned by queries.
            DestroySimulatedObjectsRoot();

            // If anything about the session changes in EnsureRuntimeState, it tries to dirty the simulatable scene
            // which would trigger another simulation. To prevent that we temporarily clear the delegate.
            EditorOnlyDelegates.DirtySimulatableScene = null;
            MARSSession.EnsureRuntimeState();
            EditorOnlyDelegates.DirtySimulatableScene = DirtySimulatableScene;
            var session = MarsRuntimeUtils.GetMarsSessionInActiveScene();

            // Find all the root game objects in the active scene and move them under a root transform.
            var activeScene = SceneManager.GetActiveScene();
            k_RootGameObjects.Clear();
            activeScene.GetRootGameObjects(k_RootGameObjects);
            SimulatedContentRoot = new GameObject(k_TemporaryRootName);
            SimulatedContentRoot.SetActive(false);
            foreach (var gameObject in k_RootGameObjects)
            {
                gameObject.transform.SetParent(SimulatedContentRoot.transform, true);
            }

            k_OriginalSimulatables.Clear();
            SimulatedContentRoot.GetComponentsInChildren(k_OriginalSimulatables);

            k_OriginalTransforms.Clear();
            SimulatedContentRoot.GetComponentsInChildren(k_OriginalTransforms);
            k_OriginalTransforms.RemoveAt(0); // Ignore the root

            // Copy the root transform to the simulated content scene. The reason we copy simulatables this way rather than
            // copying them individually is so that their references to other simulatables stay intact.
            var copiedSimulatedContentRoot = GameObjectUtils.CloneWithHideFlags(SimulatedContentRoot);
            copiedSimulatedContentRoot.name = k_SimulatedContentRootName;

            // After copying, we need to move original gameobjects back to the scene root.
            foreach (var gameObject in k_RootGameObjects)
            {
                gameObject.transform.SetParent(null, true);
            }

            UnityObjectUtils.Destroy(SimulatedContentRoot);
            SimulatedContentRoot = copiedSimulatedContentRoot;

            // Remove the copied MARS Session to avoid conflicts
            var copiedSession = SimulatedContentRoot.GetComponentInChildren(typeof(MARSSession));
            UnityObjectUtils.Destroy(copiedSession);

            m_SimulationSceneModule.AddContentGameObject(SimulatedContentRoot);

            k_CopiedTransforms.Clear();
            SimulatedContentRoot.GetComponentsInChildren(k_CopiedTransforms);
            k_CopiedTransforms.RemoveAt(0); // Ignore the root
            var copiedTransformsCount = k_CopiedTransforms.Count;
            Debug.Assert(k_OriginalTransforms.Count == copiedTransformsCount,
                "Copied Transforms in the simulation scene do not map 1:1 with original Transforms in the query scene.");

            m_OriginalToCopiedTransforms.Clear();
            m_CopiedToOriginalTransforms.Clear();
            for (var i = 0; i < copiedTransformsCount; ++i)
            {
                AddTransformCopy(k_CopiedTransforms[i], k_OriginalTransforms[i]);
            }

            m_SimulatableBehaviours.Clear();
            k_CopiedSimulatables.Clear();
            SimulatedContentRoot.GetComponentsInChildren(k_CopiedSimulatables);
            var copiedSimulatablesCount = k_CopiedSimulatables.Count;
            Debug.Assert(k_OriginalSimulatables.Count == copiedSimulatablesCount,
                "Copied ISimulatables in the simulation scene do not map 1:1 with original ISimulatables in the query scene.");

            m_CopiedToOriginalSimulatables.Clear();
            m_OriginalToCopiedSimulatables.Clear();
            m_LandmarkControllers.Clear();
            for (var i = 0; i < copiedSimulatablesCount; i++)
            {
                var originalSimulatable = k_OriginalSimulatables[i];
                var copiedSimulatable = k_CopiedSimulatables[i];
                var behaviour = copiedSimulatable as MonoBehaviour;
                if (behaviour != null)
                    m_SimulatableBehaviours.Add(behaviour);

                var landmarkController = originalSimulatable as LandmarkController;
                if (landmarkController)
                {
                    m_LandmarkControllers[landmarkController] = (LandmarkController)copiedSimulatable;
                }

                AddSimulatedCopy(copiedSimulatable, originalSimulatable);
            }

            AddSyntheticEnvironmentSimulatedObjects();

            EditorOnlyEvents.OnSetupSimulatables(m_SimulatableBehaviours);
            k_CopiedLights.Clear();
            SimulatedContentRoot.GetComponentsInChildren(k_CopiedLights);
            // Content scene lights on shouldn't cast on the simulated environment
            foreach (var light in k_CopiedLights)
                light.cullingMask &= ~(SimulationConstants.SimulatedEnvironmentLayerMask);

            // Set up simulation camera at the device starting position
            // with the correct settings for rendering the sim scene
            var cameraReference = session.cameraReference;
            if (cameraReference == null)
            {
                cameraReference = session.GetComponentInChildren<MARSCamera>(true);
                if (cameraReference == null)
                {
                    Debug.LogError("MARSSession does not have a MARSCamera");
                    return;
                }
            }

            var originalCamera = cameraReference.gameObject;
            var copiedCameraTrans = GetCopiedTransform(originalCamera.transform);

            var startingPose = m_EnvironmentManager.DeviceStartingPose;
            copiedCameraTrans.SetLocalPose(startingPose);
            SimulatedCamera = copiedCameraTrans.GetComponent<Camera>();
            SimulatedCamera.cameraType = CameraType.SceneView;
            SimulatedCamera.tag = "Untagged"; // Copied camera should not be marked as the main camera
            SimulationSceneModule.instance.AssignCameraToSimulation(SimulatedCamera);

            // Disallow MSAA on copied camera to avoid tiled GPU perf warning
            // https://issuetracker.unity3d.com/issues/tiled-gpu-perf-warning-appears-when-multiple-cameras-with-allow-msaa-are-present-in-the-scene-and-viewport-rect-is-not-default
            SimulatedCamera.allowMSAA = false;

            SimulatedContentRoot.AddToHideFlagsRecursively(SimulatedObjectHideFlags);

            EntityVisualsModule.instance.simEntitiesRoot = SimulatedContentRoot.transform;
            SimulatedContentRoot.SetActive(true);

            foreach (var contentHierarchy in Resources.FindObjectsOfTypeAll<ContentHierarchyPanel>())
            {
                contentHierarchy.RestoreState();
            }

            ProfilerMarkers.CopySimulatablesToSimulationScene.End();
        }

        void AddSyntheticEnvironmentSimulatedObjects()
        {
            if(m_EnvironmentManager.EnvironmentParent == null)
                return;

            var environmentParent = m_EnvironmentManager.EnvironmentParent;
            k_SynthBufferSimulatables.Clear();
            environmentParent.GetComponentsInChildren(k_SynthBufferSimulatables);

            foreach (var behaviour in k_SynthBufferSimulatables.Select(x => x as MonoBehaviour).Where(x => x != null))
            {
                m_SimulatableBehaviours.Add(behaviour);
            }
        }

        internal void AddSimulatedCopy(ISimulatable copiedSimulatable, ISimulatable originalSimulatable)
        {
            m_CopiedToOriginalSimulatables[copiedSimulatable] = originalSimulatable;
            m_OriginalToCopiedSimulatables[originalSimulatable] = copiedSimulatable;
        }

        void AddTransformCopy(Transform copiedTransform, Transform originalTransform)
        {
            m_CopiedToOriginalTransforms[copiedTransform] = originalTransform;
            m_OriginalToCopiedTransforms[originalTransform] = copiedTransform;
        }

        void AddSpawnedTransformToSimulationManager(Transform spawnedTransform, Transform originalTransform)
        {
            m_CopiedToOriginalTransforms[spawnedTransform] = GetOriginalTransform(originalTransform);
        }

        void AddSpawnedSimulatableToSimulationManager(ISimulatable spawnedSimulatable, ISimulatable originalsSimulatable)
        {
            m_CopiedToOriginalSimulatables[spawnedSimulatable] = GetOriginalSimulatable(originalsSimulatable);
        }

        void DestroySimulatedObjectsRoot()
        {
            m_SimulatableBehavioursBlockingSyncing.Clear();

            // Clean up root objects in the simulation scene which "leaked" out of SimulatedContentRoot on the last simulation setup
            k_RootGameObjects.Clear();
            m_SimulationSceneModule.ContentScene.GetRootGameObjects(k_RootGameObjects);
            foreach (var root in k_RootGameObjects)
            {
                if (root == m_SimulationSceneModule.ContentRoot || root == m_SimulationSceneModule.EnvironmentRoot)
                    continue;

                DestroyImmediate(root);
            }

            if (SimulatedContentRoot == null)
                return;

            var simSceneModule = ModuleLoaderCore.instance.GetModule<SimulationSceneModule>();
            if (SimulatedCamera != null && simSceneModule != null)
                simSceneModule.RemoveCameraFromSimulation(SimulatedCamera);

            foreach (var contentHierarchy in Resources.FindObjectsOfTypeAll<ContentHierarchyPanel>())
            {
                contentHierarchy.CacheState();
            }

            UnityObjectUtils.Destroy(SimulatedContentRoot);
            SimulatedContentRoot = null;
        }

        internal void UpdateLandmarkChildren()
        {
            foreach (var kvp in m_LandmarkControllers)
            {
                var originalLandmark = kvp.Key;
                var copyLandmark = kvp.Value;

                if (originalLandmark == null || copyLandmark == null)
                    continue;

                var copyChildCount = copyLandmark.transform.childCount;
                var originalChildCount = originalLandmark.transform.childCount;

                if (originalChildCount != copyChildCount)
                {
                    DirtySimulatableScene();
                    continue;
                }

                for (var j = 0; j < copyChildCount; j++)
                {
                    var originalChild = originalLandmark.transform.GetChild(j);
                    var copyChild = copyLandmark.transform.GetChild(j);

                    if (copyChild.GetComponent<ILandmarkOutput>() != null)
                        continue;

                    copyChild.localPosition = originalChild.localPosition;
                    copyChild.localRotation = originalChild.localRotation;
                    copyChild.localScale = originalChild.localScale;
                }
            }
        }

        UndoPropertyModification[] OnPostprocessModifications(UndoPropertyModification[] modifications)
        {
            if (!SimulationSceneModule.UsingSimulation)
                return modifications;

            var marsSession = MARSSession.Instance;
            foreach (var modification in modifications)
            {
                var gameObject = modification.currentValue.target as GameObject;
                var hasGameObject = gameObject != null;
                if (!hasGameObject)
                {
                    var component = modification.currentValue.target as Component;
                    if (component != null)
                    {
                        gameObject = component.gameObject;
                        hasGameObject = true;
                    }
                }
                else if (gameObject.GetComponent<ISimulatable>() != null)
                {
                    // GetComponentInParent ignores inactive GameObjects, so we need this check to
                    // handle the case in which a simulatable's GameObject has been deactivated.
                    if (OnSimulatableObjectChanged(gameObject))
                        break;
                }

                // Don't bother checking for other modifications if we have already reset the timer for simulatable changes.
                if (hasGameObject && gameObject.GetComponentInParent<ISimulatable>() != null
                    && OnSimulatableObjectChanged(gameObject))
                    break;

                // Refresh if lighting changes
                if (hasGameObject && gameObject.GetComponent<Light>())
                {
                    DirtySimulatableScene();
                    continue;
                }

                // Camera offset comes from the Transform of the MARSSession, so if we're targeting it that means
                // this is a camera offset modification
                var transformTarget = modification.currentValue.target as Transform;
                if (transformTarget == null)
                    continue;

                if (marsSession == null || transformTarget.gameObject != marsSession.gameObject)
                    continue;

                StartOffsetChangeTask();
            }

            return modifications;
        }

        void OnUndoRedoPerformed()
        {
            if (!SimulationSceneModule.UsingSimulation)
                return;

            var gameObject = Selection.activeGameObject;
            if (gameObject != null && gameObject.GetComponentInParent<ISimulatable>() != null && OnSimulatableObjectChanged(gameObject))
                return;

            var marsSession = MARSSession.Instance;
            if (marsSession != null && gameObject == marsSession.gameObject)
                StartOffsetChangeTask();
        }

        bool OnSimulatableObjectChanged(GameObject simulatableObject)
        {
            // Don't re-evaluate queries if the object is a child of a LandmarkController
            if (simulatableObject.GetComponentInParent<LandmarkController>())
                return false;

            // Don't re-evaluate queries if it was an object in the simulation scene that was touched
            if (!IsSimulatedObject(simulatableObject))
            {
                StartSimulatableChangeTask();
                return true;
            }

            return false;
        }

        void StartSimulatableChangeTask()
        {
            // We only re-evaluate queries if a certain amount of time has passed without any change happening.
            // This keeps us from rapidly re-evaluating queries as, for example, a slider is dragged.
            SimulationSyncedWithScene = false;
            m_SimulatableChangeFinalizedTask = new EditorSlowTask(OnSimulatableChangeFinalized, SimulationSettings.instance.TimeToFinalizeSceneModification);
        }

        void OnSimulatableChangeFinalized()
        {
            m_SimulatableChangeFinalizedTask = null;
            DirtySimulatableScene();
        }

        void StartOffsetChangeTask()
        {
            SimulationSyncedWithScene = false;
            m_OffsetChangeFinalizedTask = new EditorSlowTask(OnOffsetChangeFinalized, SimulationSettings.instance.TimeToFinalizeSceneModification);
        }

        void OnOffsetChangeFinalized()
        {
            m_OffsetChangeFinalizedTask = null;
            IsCameraOffsetDirty = true;
            DirtySimulatableScene();
        }

        void Update()
        {
            m_SimulatableChangeFinalizedTask?.Update();
            m_OffsetChangeFinalizedTask?.Update();
        }

        void PrefabInstanceReverted()
        {
            StartSimulatableChangeTask();
        }

        void BlockSimulationSync(MonoBehaviour behaviour, bool enabled)
        {
            if (behaviour == null)
                return;

            if (behaviour.gameObject.scene != m_SimulationSceneModule.ContentScene)
                return; // skip objects not in the simulation content scene

            if (enabled)
                m_SimulatableBehavioursBlockingSyncing.Add(behaviour);
            else
                m_SimulatableBehavioursBlockingSyncing.Remove(behaviour);

            if (m_SimulatableSceneDirty) // When handle stops blocking, immediately restart sim if scene is dirty
                RestartSimulationIfNeeded();
        }

        void RestartSimulationIfNeeded()
        {
            if (SimulationSettings.instance.AutoSyncWithSceneChanges && m_SimulatableBehavioursBlockingSyncing.Count == 0)
                m_QuerySimulationModule.RestartSimulationIfNeeded();
        }

        void OnSimulationSceneClosing()
        {
            CleanupSimulation();
        }
    }
}

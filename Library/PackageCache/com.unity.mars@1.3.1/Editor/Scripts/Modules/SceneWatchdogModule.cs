using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.MARS.Simulation;
using UnityEditor.SceneManagement;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

#if INCLUDE_AR_FOUNDATION
using UnityEngine.XR.ARFoundation;
#endif

namespace UnityEditor.MARS
{
    /// <summary>
    /// Polls the scene for changes to a MARS scene and provides callbacks when those changes happen
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class SceneWatchdogModule : EditorScriptableSettings<SceneWatchdogModule>, IModuleDependency<SimulatedObjectsManager>
    {
        const string k_RevertPrefabGroupName = "Revert Prefab Instance";
        const string k_PrefabRevertedGroupName = "Prefab Instance Reverted";

        [SerializeField]
        [Range(0.5f, 2.5f)]
        [Tooltip("The interval on which we poll the scene for changes, in seconds")]
        double m_PollingInterval = 1.5d;

        SimulatedObjectsManager m_SimulatedObjectsManager;

        EditorSlowTask m_PollingTask;

        int m_BrokenComponentCount;

        readonly List<MARSEntity> m_CurrentEntities = new List<MARSEntity>();
        readonly List<Component> m_CurrentEntityComponents = new List<Component>();
        readonly List<IFunctionalitySubscriber> m_CurrentFunctionalitySubscribers = new List<IFunctionalitySubscriber>();
        readonly List<Component> m_CurrentSubscriberComponents = new List<Component>();

        /// <summary>
        /// Called when MARSEntities are added to the active scene.
        /// Use this for a coarse-grained change check. Provided list contains only entities which have been added
        /// </summary>
        public event Action<List<MARSEntity>> entitiesAdded;

        /// <summary>
        /// Called when MARSEntities or components on a MARSEntity or its children are added to the active scene.
        /// Use this for a fine-grained change check. Provided list contains all entities and child components which have been added
        /// </summary>
        public event Action<List<Component>> entityComponentsAdded;

        /// <summary>
        /// Called when IFunctionalitySubscribers are added to the active scene.
        /// Provided list contains subscribers which have been added.
        /// </summary>
        public event Action<List<IFunctionalitySubscriber>> functionalitySubscribersAdded;

        /// <summary>
        /// Called when MARSEntities are removed from the active scene
        /// These have been destroyed and should only be used for the hash code or equality checks, like Dictionary removal
        /// Use this for a coarse-grained change check. Provided list contains only entities which have been destroyed
        /// </summary>
        public event Action<List<MARSEntity>> entitiesRemoved;

        /// <summary>
        /// Called when MARSEntities or their child components are removed from the active scene.
        /// These have been destroyed and should only be used for the hash code or equality checks, like Dictionary removal
        /// Use this for a fine-grained change check. Provided list contains all entities and child components which have been destroyed
        /// </summary>
        public event Action<List<Component>> entityComponentsRemoved;

        /// <summary>
        /// Called when IFunctionalitySubscribers are removed from the active scene.
        /// These have been destroyed and should only be used for the hash code or equality checks, like Dictionary removal.
        /// Provided list contains subscribers which have been removed.
        /// </summary>
        public event Action<List<IFunctionalitySubscriber>> functionalitySubscribersRemoved;

        /// <summary>
        /// Called when the state of whether the active scene uses face tracking has changed
        /// </summary>
        public event Action<bool> faceSceneStateChanged;

        /// <summary>
        /// Called when a prefab is reverted outside of a prefab stage.
        /// </summary>
        public event Action prefabInstanceReverted;

        /// <summary>
        /// Whether there are any MARSEntities in the active scene
        /// </summary>
        public bool anyEntitiesInScene { get { return m_CurrentEntities.Count > 0; } }

        /// <summary>
        /// Whether there are any IFunctionalitySubscribers in the active scene
        /// </summary>
        public bool anySubscribersInScene { get { return m_CurrentFunctionalitySubscribers.Count > 0; } }

        /// <summary>
        /// Whether the active scene requires the "face" trait or has face tracking subscribers
        /// </summary>
        public bool currentSceneIsFaceScene { get; private set; }

        /// <summary>
        /// Whether AR Foundation simulation mode is currently needed.  True if the current scene setup contains an
        /// AR Foundation Session, and no MARS Session.
        /// </summary>
        internal bool onlyARFSessionExists { get; private set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly HashSet<Component> k_PreviousEntityComponentSet = new HashSet<Component>();
        static readonly List<Component> k_AddedEntityComponents = new List<Component>();
        static readonly List<Component> k_RemovedEntityComponents = new List<Component>();
        static readonly HashSet<MARSEntity> k_PreviousEntitySet = new HashSet<MARSEntity>();
        static readonly List<MARSEntity> k_AddedEntities = new List<MARSEntity>();
        static readonly List<MARSEntity> k_RemovedEntities = new List<MARSEntity>();
        static readonly HashSet<IFunctionalitySubscriber> k_PreviousFunctionalitySubscriberSet = new HashSet<IFunctionalitySubscriber>();
        static readonly List<IFunctionalitySubscriber> k_AddedFunctionalitySubscribers = new List<IFunctionalitySubscriber>();
        static readonly List<IFunctionalitySubscriber> k_RemovedFunctionalitySubscribers = new List<IFunctionalitySubscriber>();
        static readonly List<GameObject> k_RootGameObjects = new List<GameObject>();
        static readonly List<Component> k_Components = new List<Component>();
        static readonly List<MARSEntity> k_Entities = new List<MARSEntity>();
        static readonly List<IFunctionalitySubscriber> k_FunctionalitySubscribers = new List<IFunctionalitySubscriber>();
#if INCLUDE_AR_FOUNDATION
        static readonly List<ARSession> k_ARSessions = new List<ARSession>();
#endif

        /// <inheritdoc />
        void IModuleDependency<SimulatedObjectsManager>.ConnectDependency(SimulatedObjectsManager dependency) { m_SimulatedObjectsManager = dependency; }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            GetCurrentComponents();
            m_PollingTask = new EditorSlowTask(ScenePoll, m_PollingInterval);

            EditorApplication.update += Update;
            EditorSceneManager.sceneSaved += OnSceneSaved;
            entityComponentsAdded += OnEntityComponentsChanged;
            entityComponentsRemoved += OnEntityComponentsChanged;
            functionalitySubscribersAdded += OnFunctionalitySubscribersChanged;
            functionalitySubscribersRemoved += OnFunctionalitySubscribersChanged;

            FindBrokenComponents();

            ScenePoll(); // Calling this here makes sure we immediately have updated scene information as soon as we switch scenes
            CheckIfFaceScene();
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            EditorApplication.update -= Update;
            EditorSceneManager.sceneSaved -= OnSceneSaved;
            entityComponentsAdded -= OnEntityComponentsChanged;
            entityComponentsRemoved -= OnEntityComponentsChanged;
            functionalitySubscribersAdded -= OnFunctionalitySubscribersChanged;
            functionalitySubscribersRemoved -= OnFunctionalitySubscribersChanged;

            m_PollingTask = null;
            m_BrokenComponentCount = 0;
            currentSceneIsFaceScene = false;
            m_CurrentEntities.Clear();
            m_CurrentEntityComponents.Clear();
            m_CurrentFunctionalitySubscribers.Clear();
            m_CurrentSubscriberComponents.Clear();
        }

        /// <summary>
        /// Update the module. When loaded called on <c>EditorApplication.update</c>
        /// </summary>
        public void Update()
        {
            m_PollingTask?.Update();

            // Check every update to avoid missing undo group change.
            CheckPrefabRevert();
        }

        void GetCurrentComponents()
        {
            m_CurrentEntities.Clear();
            m_CurrentEntityComponents.Clear();
            m_CurrentFunctionalitySubscribers.Clear();
            m_CurrentSubscriberComponents.Clear();

#if INCLUDE_AR_FOUNDATION
            k_ARSessions.Clear();
            onlyARFSessionExists = false;
#endif

            // Static collections used below are cleared by the methods that use them
            SceneManager.GetActiveScene().GetRootGameObjects(k_RootGameObjects);
            foreach (var gameObject in k_RootGameObjects)
            {
                gameObject.GetComponentsInChildren(k_Entities);
                m_CurrentEntities.AddRange(k_Entities);
                gameObject.GetComponentsInChildren(k_FunctionalitySubscribers);
                foreach (var subscriber in k_FunctionalitySubscribers)
                {
                    m_CurrentFunctionalitySubscribers.Add(subscriber);
                    m_CurrentSubscriberComponents.Add(subscriber as Component);
                }

#if INCLUDE_AR_FOUNDATION
                gameObject.GetComponentsInChildren(k_ARSessions);
                onlyARFSessionExists |= k_ARSessions.Count > 0 && MARSSession.Instance == null;
#endif
            }

            foreach (var entity in m_CurrentEntities)
            {
                entity.GetComponentsInChildren(k_Components);
                m_CurrentEntityComponents.AddRange(k_Components);
            }
        }

        void FindBrokenComponents()
        {
            m_BrokenComponentCount = 0;
            var scene = SceneManager.GetActiveScene();

            // Static collections used below are cleared by the methods that use them
            scene.GetRootGameObjects(k_RootGameObjects);
            foreach (var gameObject in k_RootGameObjects)
            {
                gameObject.GetComponentsInChildren(k_Entities);
                foreach (var entity in k_Entities)
                {
                    entity.GetComponentsInChildren(k_Components);
                    m_CurrentEntityComponents.AddRange(k_Components);
                }
            }

            foreach (var component in m_CurrentEntityComponents)
            {
                if (component == null)
                    m_BrokenComponentCount++;
            }

            if (m_BrokenComponentCount > 0)
                Debug.LogWarningFormat("detected {0} broken entity components in scene {1}",
                    m_BrokenComponentCount, scene.name);
        }

        internal void ExecutePollingTask()
        {
            m_PollingTask.ExecuteTask();
        }

        internal void ScenePoll()
        {
            k_PreviousEntityComponentSet.Clear();
            k_AddedEntityComponents.Clear();
            k_RemovedEntityComponents.Clear();

            k_PreviousEntitySet.Clear();
            k_AddedEntities.Clear();
            k_RemovedEntities.Clear();

            k_PreviousFunctionalitySubscriberSet.Clear();
            k_AddedFunctionalitySubscribers.Clear();
            k_RemovedFunctionalitySubscribers.Clear();

            foreach (var obj in m_CurrentEntityComponents)
            {
                if (obj == null)
                    k_RemovedEntityComponents.Add(obj);
                else
                    k_PreviousEntityComponentSet.Add(obj);
            }

            foreach (var obj in m_CurrentEntities)
            {
                if (obj == null)
                    k_RemovedEntities.Add(obj);
                else
                    k_PreviousEntitySet.Add(obj);
            }

            for (var i = 0; i < m_CurrentFunctionalitySubscribers.Count; i++)
            {
                var subscriber = m_CurrentFunctionalitySubscribers[i];
                if (m_CurrentSubscriberComponents[i] == null)
                    k_RemovedFunctionalitySubscribers.Add(subscriber);
                else
                    k_PreviousFunctionalitySubscriberSet.Add(subscriber);
            }

            GetCurrentComponents();

            foreach (var component in m_CurrentEntityComponents)
            {
                if (!k_PreviousEntityComponentSet.Contains(component) && component != null)
                    k_AddedEntityComponents.Add(component);
            }

            foreach (var entity in m_CurrentEntities)
            {
                if (!k_PreviousEntitySet.Contains(entity))
                    k_AddedEntities.Add(entity);
            }

            foreach (var subscriber in m_CurrentFunctionalitySubscribers)
            {
                if (!k_PreviousFunctionalitySubscriberSet.Contains(subscriber))
                    k_AddedFunctionalitySubscribers.Add(subscriber);
            }

            if (k_AddedEntityComponents.Count > 0)
                entityComponentsAdded(k_AddedEntityComponents);

            // only fire the removed event if the amount of null Components is greater than the
            // number of broken components we detected on load
            if (k_RemovedEntityComponents.Count > m_BrokenComponentCount)
                entityComponentsRemoved(k_RemovedEntityComponents);

            if (entitiesAdded != null && k_AddedEntities.Count > 0)
                entitiesAdded(k_AddedEntities);

            if (entitiesRemoved != null && k_RemovedEntityComponents.Count > 0)
                entitiesRemoved(k_RemovedEntities);

            if (k_AddedFunctionalitySubscribers.Count > 0)
                functionalitySubscribersAdded(k_AddedFunctionalitySubscribers);

            if (k_RemovedFunctionalitySubscribers.Count > 0)
                functionalitySubscribersRemoved(k_RemovedFunctionalitySubscribers);
        }

        void OnEntityComponentsChanged(List<Component> changed)
        {
            if (anyEntitiesInScene)
                MARSSession.EnsureRuntimeState();

#if UNITY_EDITOR
            var marsSession = MARSSession.Instance;
            if (marsSession)
                marsSession.CheckCapabilities();
#endif

            m_SimulatedObjectsManager.DirtySimulatableScene();
            CheckIfFaceScene();
        }

        void OnFunctionalitySubscribersChanged(List<IFunctionalitySubscriber> changed)
        {
            m_SimulatedObjectsManager.DirtySimulatableScene();
            CheckIfFaceScene();
        }

        void OnSceneSaved(Scene scene)
        {
            if (scene != SceneManager.GetActiveScene())
                return;

            ScenePoll();
        }

        void CheckIfFaceScene()
        {
            var faceScene = false;
            var session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (session && session.requirements != null)
            {
                if (session.requirements.TraitRequirements.Any(r => r.TraitName == TraitNames.Face))
                    faceScene = true;
            }

            if (!faceScene)
            {
                // k_RootGameObjects is cleared by GetRootGameObjects
                SceneManager.GetActiveScene().GetRootGameObjects(k_RootGameObjects);
                foreach (var gameObject in k_RootGameObjects)
                {
                    if (gameObject.GetComponentInChildren<IUsesFaceTracking>() != null)
                    {
                        faceScene = true;
                        break;
                    }
                }
            }

            if (faceScene != currentSceneIsFaceScene)
            {
                currentSceneIsFaceScene = faceScene;
                if (faceSceneStateChanged != null)
                    faceSceneStateChanged(faceScene);
            }
        }

        void CheckPrefabRevert()
        {
            // Only want prefab modification in an editor scene.
            if (PrefabStageUtility.GetCurrentPrefabStage() != null)
                return;

            var undoGroup = Undo.GetCurrentGroupName();
            if (!undoGroup.Contains(k_RevertPrefabGroupName))
                return;

            // Need to change the name of group to know if we processed the undo group
            Undo.SetCurrentGroupName(k_PrefabRevertedGroupName);
            prefabInstanceReverted();
        }
    }
}

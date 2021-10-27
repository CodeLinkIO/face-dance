using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.MARSUtils;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    /// <summary>
    /// Base class for a provider that simulates changes to the tracking states of synthesized data over time and updates data accordingly
    /// </summary>
    /// <typeparam name="TSynthTrackable">The type of <see cref="SynthesizedTrackable"/> to track</typeparam>
    /// <typeparam name="TData">The type of <see cref="IMRTrackable"/> data to provide</typeparam>
    public abstract class SimulatedDataTrackingProvider<TSynthTrackable, TData> : MonoBehaviour, IUsesFunctionalityInjection
        where TSynthTrackable : SynthesizedTrackable<TData> where TData : IMRTrackable
    {
        [SerializeField]
        float m_TrackingUpdateInterval = 0.1f;

        protected Scene m_EnvironmentScene;
        protected PhysicsScene m_EnvironmentPhysicsScene;

        protected readonly Dictionary<TSynthTrackable, SimulatedObject> m_SimulatedTrackableObjects = new Dictionary<TSynthTrackable, SimulatedObject>();
        protected readonly HashSet<TSynthTrackable> m_DiscoveredTrackables = new HashSet<TSynthTrackable>();

        SlowTaskModule.SlowTask m_TrackingUpdateTask;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<SimulatedObject> k_SimulatedObjects = new List<SimulatedObject>();

        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        protected virtual void OnEnable()
        {
            MarsTime.MarsUpdate += OnMarsUpdate;
            this.EnsureFunctionalityInjected();
            EditorOnlyEvents.onEnvironmentSetup += SetupTrackingForEnvironment;

            m_TrackingUpdateTask = new SlowTaskModule.SlowTask
            {
                task = UpdateTracking,
                sleepTime = m_TrackingUpdateInterval,
                lastExecutionTime = MarsTime.Time
            };

            if (Application.isPlaying)
                return;

            // In edit mode simulation the environment is set up before providers are enabled
            SetupTrackingForEnvironment();
        }

        protected virtual void OnDisable()
        {
            MarsTime.MarsUpdate -= OnMarsUpdate;
            EditorOnlyEvents.onEnvironmentSetup -= SetupTrackingForEnvironment;

            foreach (var kvp in m_SimulatedTrackableObjects)
            {
                var synthTrackable = kvp.Key;
                if (synthTrackable == null)
                    continue;

                if (m_DiscoveredTrackables.Contains(synthTrackable))
                    RemoveTrackableData(synthTrackable);

                var simObject = kvp.Value;
                if (simObject != null)
                    simObject.StopRunInEditMode();
            }

            m_DiscoveredTrackables.Clear();
            m_SimulatedTrackableObjects.Clear();
        }

        protected virtual void OnMarsUpdate()
        {
            m_TrackingUpdateTask.Update(MarsTime.Time);
        }

        /// <summary>
        /// Gather trackable objects in the simulated environment and do any other initialization that depends on the environment
        /// </summary>
        protected virtual void SetupTrackingForEnvironment()
        {
            // Once the environment is set up we can gather its synthesized trackables. To simulate discovery of these
            // trackables we can check how visible they are to the camera - this includes frustum checking, occlusion checking,
            // and other heuristics.
            m_EnvironmentScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene();
            if (!m_EnvironmentScene.IsValid())
                return;

            // Get the environment physics scene to check if trackable objects are occluded by other objects in the environment
            m_EnvironmentPhysicsScene = m_EnvironmentScene.GetPhysicsScene();

            m_SimulatedTrackableObjects.Clear();
            k_SimulatedObjects.Clear();
            GameObjectUtils.GetComponentsInScene(m_EnvironmentScene, k_SimulatedObjects);
            foreach (var simulatedObject in k_SimulatedObjects)
            {
                var synthTrackable = simulatedObject.GetComponent<TSynthTrackable>();
                if (synthTrackable == null)
                    continue;

                synthTrackable.Initialize();
                m_SimulatedTrackableObjects[synthTrackable] = simulatedObject;
                this.InjectFunctionalitySingle(simulatedObject);
                simulatedObject.StartRunInEditMode();
            }

            k_SimulatedObjects.Clear();
        }

        void UpdateTracking()
        {
            if (!m_EnvironmentScene.IsValid() || !m_EnvironmentPhysicsScene.IsValid())
                return;

            var marsCamera = MarsRuntimeUtils.GetActiveCamera(true);
            if (marsCamera == null)
                return;

            foreach (var kvp in m_SimulatedTrackableObjects)
            {
                var synthTrackable = kvp.Key;
                var simObject = kvp.Value;
                var previouslyFound = m_DiscoveredTrackables.Contains(synthTrackable);
                if (!synthTrackable.isActiveAndEnabled || !simObject.isActiveAndEnabled)
                {
                    if (previouslyFound)
                    {
                        m_DiscoveredTrackables.Remove(synthTrackable);
                        RemoveTrackableData(synthTrackable);
                    }

                    continue;
                }

                var trackingState = GetTrackingState(synthTrackable, marsCamera);
                var tracking = trackingState != MARSTrackingState.Unknown;
                if (!previouslyFound)
                {
                    if (!tracking)
                        return;

                    m_DiscoveredTrackables.Add(synthTrackable);
                    AddTrackableData(synthTrackable, trackingState);
                }
                else
                {
                    UpdateTrackableData(synthTrackable, trackingState);
                }
            }
        }

        /// <summary>
        /// Get the tracking quality of the synthesized trackable relative to the MARS camera. This is where to check whether the trackable
        /// is within the camera frustum and whether it is occluded by other objects in <see cref="m_EnvironmentPhysicsScene"/>.
        /// </summary>
        /// <param name="synthesizedTrackable"></param>
        /// <param name="marsCamera"></param>
        protected abstract MARSTrackingState GetTrackingState(TSynthTrackable synthesizedTrackable, Camera marsCamera);

        /// <summary>
        /// Add data from the synthesized trackable. This is called when the trackable has started tracking for the first time
        /// and has been added to <see cref="m_DiscoveredTrackables"/>.
        /// </summary>
        /// <param name="synthesizedTrackable">Synthesized trackable whose data to add</param>
        /// <param name="trackingState">Initial tracking quality of the trackable</param>
        protected abstract void AddTrackableData(TSynthTrackable synthesizedTrackable, MARSTrackingState trackingState);

        /// <summary>
        /// Update data from a synthesized trackable that has been previously discovered. The tracking quality may be Unknown,
        /// but this does not necessarily mean the data must be removed from the database.
        /// </summary>
        /// <param name="synthesizedTrackable">Synthesized trackable whose data to update</param>
        /// <param name="trackingState">Current tracking quality of the trackable, may be used to limit which traits get updated</param>
        protected abstract void UpdateTrackableData(TSynthTrackable synthesizedTrackable, MARSTrackingState trackingState);

        /// <summary>
        /// Remove data from the synthesized trackable
        /// </summary>
        /// <param name="synthesizedTrackable">Synthesized trackable whose data to remove</param>
        protected abstract void RemoveTrackableData(TSynthTrackable synthesizedTrackable);
    }
#else
    public abstract class SimulatedDataTrackingProvider<TSynthTrackable, TData> : MonoBehaviour
        where TSynthTrackable : SynthesizedTrackable<TData> where TData : IMRTrackable
    {
#pragma warning disable 414, 649
        [SerializeField]
        float m_TrackingUpdateInterval = 0.1f;
#pragma warning restore 414, 649
    }
#endif
}

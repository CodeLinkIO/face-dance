#if ARSUBSYSTEMS_2_1_OR_NEWER
using System.Collections.Generic;
using Unity.MARS.Settings;
using UnityEngine;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Unity.MARS.XRSubsystem
{
    class MARSXRSubsystemModule : IModuleDependency<MARSSceneModule>, IModuleBehaviorCallbacks
    {
        readonly List<IMarsXRSubscriber> m_MarsXRSubscribers = new List<IMarsXRSubscriber>();

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<IMarsXRSubsystem> k_MarsXRSubsystems = new List<IMarsXRSubsystem>();
        static readonly List<object> k_SubscriberObjects = new List<object>();

        [InitializeOnLoadMethod]
        static void OnEditorLoad() { SceneManager.sceneLoaded += OnSceneLoaded; }

        static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // List is cleared by GetInstances
            SubsystemManager.GetInstances(k_MarsXRSubsystems);
            var anyMarsSubsystemsRunning = false;
            foreach (var subsystem in k_MarsXRSubsystems)
            {
                if (subsystem.running)
                {
                    anyMarsSubsystemsRunning = true;
                    break;
                }
            }

            if (anyMarsSubsystemsRunning)
                MARSSession.EnsureSessionInActiveScene();
        }

        public void ConnectDependency(MARSSceneModule dependency)
        {
            // List is cleared by GetInstances
            SubsystemManager.GetInstances(k_MarsXRSubsystems);
            m_MarsXRSubscribers.Clear();
            k_SubscriberObjects.Clear();
            foreach (var subsystem in k_MarsXRSubsystems)
            {
                // For most SubsystemLifecycleManagers we can guarantee that if they exist in the scene they have started
                // running their subsystems by this point, since they have lower script execution orders than MARSSession.
                // ARRaycastManager is an exception to this - it has a default execution order. So we make an exception for
                // the raycast subsystem here and assume that it will need a provider.
                // Also for Subsystems before version 3 the image marker subsystem does not report as running.
#if AR_SUBSYSTEMS_3_OR_NEWER
                if (subsystem.running || subsystem is RaycastSubsystem)
#else
                if (subsystem.running || subsystem is RaycastSubsystem || subsystem is ImageMarkerSubsystem)
#endif
                {
                    var subscriber = subsystem.FunctionalitySubscriber;
                    m_MarsXRSubscribers.Add(subscriber);
                    k_SubscriberObjects.Add(subscriber);
                }
            }

            if (k_SubscriberObjects.Count > 0)
                dependency.AddRuntimeSceneObjects(k_SubscriberObjects);
        }

        public void LoadModule() { }

        public void UnloadModule() { }

        public void OnBehaviorAwake() { }

        public void OnBehaviorEnable()
        {
            foreach (var subscriber in m_MarsXRSubscribers)
            {
                subscriber.SubscribeToEvents();
            }
        }

        public void OnBehaviorStart() { }

        public void OnBehaviorUpdate() { }

        public void OnBehaviorDisable()
        {
            foreach (var subscriber in m_MarsXRSubscribers)
            {
                subscriber?.UnsubscribeFromEvents();
            }
        }

        public void OnBehaviorDestroy() { }
    }
}
#endif

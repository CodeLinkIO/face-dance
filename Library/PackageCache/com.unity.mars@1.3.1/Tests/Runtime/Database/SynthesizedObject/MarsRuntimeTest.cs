#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Base class used for each Synthesized Object test case.
    /// Responsible for clearing out the backend and database to a base state and creating any extra providers
    /// </summary>
    [AddComponentMenu("")]
    abstract class MarsRuntimeTest : MonoBehaviour, IMonoBehaviourTest
    {
        /// <summary>
        /// Provides identity camera offsets and matrices
        /// </summary>
        [ProviderSelectionOptions(ProviderPriorities.TestProviderPriority)]
        class CameraProvider : IProvidesCameraPose, IProvidesCameraOffset, IProvidesCameraProjectionMatrix
        {
            Vector3 IProvidesCameraOffset.cameraPositionOffset
            {
                get { return Vector3.zero; }
                set {}
            }

            float IProvidesCameraOffset.cameraYawOffset
            {
                get { return 0; }
                set {}
            }
            float IProvidesCameraOffset.cameraScale
            {
                get { return 1.0f; }
                set {}
            }

            Matrix4x4 IProvidesCameraOffset.CameraOffsetMatrix { get { return Matrix4x4.identity; } }

#pragma warning disable 67
            public event Action<Pose> poseUpdated;
            public event Action<MRCameraTrackingState> trackingStateChanged;
#pragma warning restore 67

            Pose IProvidesCameraOffset.ApplyInverseOffsetToPose(Pose pose)
            {
                return pose;
            }

            Pose IProvidesCameraOffset.ApplyOffsetToPose(Pose pose)
            {
                return pose;
            }

            Vector3 IProvidesCameraOffset.ApplyOffsetToPosition(Vector3 position)
            {
                return position;
            }

            Vector3 IProvidesCameraOffset.ApplyInverseOffsetToPosition(Vector3 position)
            {
                return position;
            }

            public Vector3 ApplyOffsetToDirection(Vector3 direction)
            {
                return direction;
            }

            public Vector3 ApplyInverseOffsetToDirection(Vector3 direction)
            {
                return direction;
            }

            Quaternion IProvidesCameraOffset.ApplyOffsetToRotation(Quaternion rotation)
            {
                return rotation;
            }

            Quaternion IProvidesCameraOffset.ApplyInverseOffsetToRotation(Quaternion rotation)
            {
                return rotation;
            }

            void IFunctionalityProvider.ConnectSubscriber(object obj)
            {
                this.TryConnectSubscriber<IProvidesCameraPose>(obj);
                this.TryConnectSubscriber<IProvidesCameraOffset>(obj);
                this.TryConnectSubscriber<IProvidesCameraProjectionMatrix>(obj);
            }

            Pose IProvidesCameraPose.GetCameraPose()
            {
                return default;
            }

            Matrix4x4? IProvidesCameraProjectionMatrix.GetProjectionMatrix()
            {
                return null;
            }

            void IFunctionalityProvider.LoadProvider() { }

            void IFunctionalityProvider.UnloadProvider() { }
        }

        bool m_WasBlockingEnsureSession;
        MARSSession m_MARSSession;

        FunctionalityInjectionModule m_FIModule;
        Transform m_InactiveParent;

        protected int m_StartSceneCount;
        protected int m_StartFrame;
        protected int m_FrameCount = 10;

        protected MARSQueryBackend m_QueryBackend;

        public virtual bool IsTestFinished
        {
            get
            {
                // Wait until all simulation scenes are unloaded before completing the test
                if (!enabled && SceneManager.sceneCount == m_StartSceneCount)
                    return true;

                // Shut down after desired frame count
                if (MarsTime.FrameCount - m_StartFrame >= m_FrameCount)
                    enabled = false;

                return false;
            }
        }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<Component> k_ComponentList = new List<Component>();
        static readonly List<IFunctionalityProvider> k_ProvidersToRemove = new List<IFunctionalityProvider>();

        protected virtual void OnEnable()
        {
            m_StartSceneCount = SceneManager.sceneCount;
            MarsTime.MarsUpdate += OnMarsUpdate;

            var inactiveObject = new GameObject();
            inactiveObject.SetActive(false);
            m_InactiveParent = inactiveObject.transform;

            var marsSceneModule = MARSSceneModule.instance;
            m_WasBlockingEnsureSession = marsSceneModule.BlockEnsureSession;
            marsSceneModule.BlockEnsureSession = false;

            MARSSession.TestMode = true;
            MARSSession.EnsureRuntimeState();
            m_MARSSession = MARSSession.Instance;
            m_StartFrame = MarsTime.FrameCount;
            var moduleLoader = ModuleLoaderCore.instance;
            m_FIModule = moduleLoader.GetModule<FunctionalityInjectionModule>();
            m_QueryBackend = moduleLoader.GetModule<MARSQueryBackend>();
            var cameraProvider = new CameraProvider();
            var activeIsland = m_FIModule.activeIsland;
            if (activeIsland.providers.TryGetValue(typeof(IProvidesCameraOffset), out var functionalityProvider))
            {
                k_ProvidersToRemove.Clear();
                k_ProvidersToRemove.Add(functionalityProvider);
                activeIsland.RemoveProviders(k_ProvidersToRemove);
            }

            activeIsland.AddProvider(cameraProvider.GetType(), cameraProvider );
            moduleLoader.InjectFunctionalityInModules(activeIsland);
        }

        protected bool ForceUpdateQueries()
        {
            return m_QueryBackend.RunAllQueries();
        }

        /// <summary>
        /// Instantiates an object in a way that ensures functionality injection runs before the object's enable
        /// This function is temporary until we make certain interfaces not require a connection step
        /// </summary>
        protected GameObject InstantiateReferenceObject(GameObject prefab)
        {
            var instance = Instantiate(prefab, m_InactiveParent);

            // k_ComponentList is cleared by GetComponentsInChildren
            instance.GetComponentsInChildren(true, k_ComponentList);
            var activeIsland = m_FIModule.activeIsland;
            foreach (var currentComponent in k_ComponentList)
            {
                activeIsland.InjectFunctionalitySingle(currentComponent);
            }

            instance.transform.parent = null;
            return instance;
        }

        protected virtual void OnDisable()
        {
            MarsTime.MarsUpdate -= OnMarsUpdate;

            MARSSceneModule.instance.BlockEnsureSession = m_WasBlockingEnsureSession;

            if (m_MARSSession)
            {
                Destroy(m_MARSSession.gameObject);
                MARSSession.TestMode = false;
            }

            if (m_InactiveParent != null)
            {
                Destroy(m_InactiveParent.gameObject);
                m_InactiveParent = null;
            }
        }

        protected abstract void OnMarsUpdate();
    }
}
#endif

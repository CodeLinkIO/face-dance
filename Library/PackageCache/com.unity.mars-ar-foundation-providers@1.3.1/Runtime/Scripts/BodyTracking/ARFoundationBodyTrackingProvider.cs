#if ARFOUNDATION_4_OR_NEWER
using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using Unity.MARS.Providers.ARFoundation;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Object = UnityEngine.Object;

namespace Unity.MARS.Providers
{
    [ProviderSelectionOptions(excludedPlatforms: new[]{
        RuntimePlatform.WindowsEditor,
        RuntimePlatform.OSXEditor,
        RuntimePlatform.LinuxEditor,
        RuntimePlatform.WindowsPlayer,
        RuntimePlatform.OSXPlayer,
        RuntimePlatform.LinuxPlayer
    })]
    class ARFoundationBodyTrackingProvider : IProvidesMarsBodyTracking, IProvidesTraits<bool>, IProvidesTraits<Pose>,
        IUsesMARSTrackableData<IMarsBody>, ITrackableProvider
    {
        static readonly TraitDefinition[] k_ProvidedTraits =
        {
            TraitDefinitions.Body,
            TraitDefinitions.Pose
        };

        ARHumanBodyManager m_ARHumanBodyManager;
        ARHumanBodyManager m_NewARHumanBodyManager;

#pragma warning disable 649
        Transform[] m_JointToTransform;
#pragma warning restore 649
        GameObject m_BodyRigInstance;
        Animator m_BodyRigAnimator;
        HumanPoseHandler m_BodyPoseExtractor;

        readonly Dictionary<TrackableId, ARFoundationBody> m_TrackedBodies = new Dictionary<TrackableId, ARFoundationBody>();

        public event Action<IMarsBody> BodyAdded;
        public event Action<IMarsBody> BodyUpdated;
        public event Action<IMarsBody> BodyRemoved;

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        public void ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesMarsBodyTracking>(obj);
        }

        public void LoadProvider()
        {
            ARFoundationSessionProvider.RequireARSession();

            // Create platform specific rig and mapping
#if UNITY_IOS
            var rigSettings = ARKitBodyRigSettings.instance;
            SetupRigInstance(rigSettings.ControlRig);

            m_JointToTransform = rigSettings.GenerateJointMapping(m_BodyRigInstance);
#endif

            var currentSession = ARFoundationSessionProvider.currentSession;
            if (currentSession)
            {
                var currentSessionGameObject = currentSession.gameObject;
                m_ARHumanBodyManager = Object.FindObjectOfType<ARHumanBodyManager>();

                if (!m_ARHumanBodyManager)
                {
                    m_ARHumanBodyManager = currentSessionGameObject.AddComponent<ARHumanBodyManager>();
                    m_ARHumanBodyManager.hideFlags = HideFlags.DontSave;
                    m_NewARHumanBodyManager = m_ARHumanBodyManager;
                }

                m_ARHumanBodyManager.humanBodiesChanged += ARBodyManagerOnBodiesChanged;
            }

            AddExistingTrackables();
        }

        public void UnloadProvider()
        {
            m_ARHumanBodyManager.humanBodiesChanged -= ARBodyManagerOnBodiesChanged;

            ClearTrackables();

            if (m_NewARHumanBodyManager)
                UnityObjectUtils.Destroy(m_NewARHumanBodyManager);

            if (m_BodyRigInstance)
            {
                UnityObjectUtils.Destroy(m_BodyRigInstance);
                m_BodyRigInstance = null;
                m_BodyRigAnimator = null;
                m_BodyPoseExtractor = null;
            }

            ARFoundationSessionProvider.TearDownARSession();
        }

        void SetupRigInstance(GameObject rigPrefab)
        {
            if (rigPrefab == null)
                return;

            m_BodyRigInstance = Object.Instantiate(rigPrefab);
            m_BodyRigInstance.hideFlags = HideFlags.HideAndDontSave;
            Object.DontDestroyOnLoad(m_BodyRigInstance);
            m_BodyRigAnimator = m_BodyRigInstance.GetComponent<Animator>();

            if (m_BodyRigAnimator != null)
                m_BodyPoseExtractor = new HumanPoseHandler(m_BodyRigAnimator.avatar, m_BodyRigAnimator.transform);
        }

        void ARBodyManagerOnBodiesChanged(ARHumanBodiesChangedEventArgs changedEvent)
        {

            foreach (var arHumanBody in changedEvent.removed)
            {
                var trackableId = arHumanBody.trackableId;
                m_TrackedBodies.TryGetValue(trackableId, out var arfBody);
                m_TrackedBodies.Remove(trackableId);
                RemoveBodyData(arfBody);
            }

            foreach (var arHumanBody in changedEvent.updated)
            {
                UpdateBodyData(GetOrAddBody(arHumanBody));
            }

            foreach (var arHumanBody in changedEvent.added)
            {
                AddBodyData(GetOrAddBody(arHumanBody));
            }
        }

        ARFoundationBody GetOrAddBody(ARHumanBody arHumanBody)
        {
            var trackableId = arHumanBody.trackableId;
            if (!m_TrackedBodies.TryGetValue(trackableId, out var arfBody))
            {
                arfBody = new ARFoundationBody(trackableId.ToMarsId());
                m_TrackedBodies[trackableId] = arfBody;
                arfBody.UpdateARFoundationBody(arHumanBody, m_BodyRigInstance.transform, m_BodyRigAnimator.humanScale, m_JointToTransform, m_BodyPoseExtractor);
            }
            else
            {
                arfBody.UpdateARFoundationBody(arHumanBody, m_BodyRigInstance.transform, m_BodyRigAnimator.humanScale, m_JointToTransform, m_BodyPoseExtractor);
            }
            return arfBody;
        }


        void AddBodyData(ARFoundationBody arHumanBody)
        {
            var id = this.AddOrUpdateData(arHumanBody);
            this.AddOrUpdateTrait(id, TraitNames.Body, true);
            this.AddOrUpdateTrait(id, TraitNames.Pose, arHumanBody.pose);

            if (BodyAdded != null)
                BodyAdded(arHumanBody);
        }

        void UpdateBodyData(ARFoundationBody arHumanBody)
        {
            var id = this.AddOrUpdateData(arHumanBody);
            this.AddOrUpdateTrait(id, TraitNames.Pose, arHumanBody.pose);

            if (BodyUpdated != null)
                BodyUpdated(arHumanBody);
        }

        void RemoveBodyData(ARFoundationBody arHumanBody)
        {
            var id = this.RemoveData(arHumanBody);
            this.RemoveTrait<bool>(id, TraitNames.Body);
            this.RemoveTrait<Pose>(id, TraitNames.Pose);

            if (BodyRemoved != null)
                BodyRemoved(arHumanBody);
        }


        public void AddExistingTrackables()
        {
#if !UNITY_EDITOR
            if (m_ARHumanBodyManager == null)
                return;

            foreach (var arBody in m_ARHumanBodyManager.trackables)
            {
                AddBodyData(GetOrAddBody(arBody));
            }
#endif
        }

        public void ClearTrackables()
        {
            if (m_ARHumanBodyManager == null)
                return;

            foreach (var kvp in m_TrackedBodies)
            {
                RemoveBodyData(kvp.Value);
            }

            m_TrackedBodies.Clear();
        }

        public void GetBodies(List<IMarsBody> bodies)
        {
            if (m_ARHumanBodyManager == null || bodies == null)
                return;

            foreach (var arBody in m_ARHumanBodyManager.trackables)
            {
                bodies.Add(GetOrAddBody(arBody));
            }
        }
    }
}
#endif

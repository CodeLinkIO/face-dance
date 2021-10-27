#if ARFOUNDATION_2_1_OR_NEWER
using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

#if ARFOUNDATION_3_0_1_OR_NEWER
using ARReferencePoint = UnityEngine.XR.ARFoundation.ARAnchor;
using ARReferencePointManager = UnityEngine.XR.ARFoundation.ARAnchorManager;
using ARReferencePointsChangedEventArgs = UnityEngine.XR.ARFoundation.ARAnchorsChangedEventArgs;
#endif

namespace Unity.MARS.Providers.ARFoundation
{
    [ProviderSelectionOptions(excludedPlatforms: new []{
        RuntimePlatform.WindowsEditor,
        RuntimePlatform.OSXEditor,
        RuntimePlatform.LinuxEditor,
        RuntimePlatform.WindowsPlayer,
        RuntimePlatform.OSXPlayer,
        RuntimePlatform.LinuxPlayer
    })]
    class ARFoundationReferencePointProvider : IProvidesReferencePoints, IProvidesTraits<Pose>, IUsesMARSTrackableData<MRReferencePoint>
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.Pose };

        readonly Dictionary<MarsTrackableId, ARReferencePoint> k_TrackableIds = new Dictionary<MarsTrackableId, ARReferencePoint>();

        ARReferencePointManager m_ARReferencePointManager;
        ARReferencePointManager m_NewARReferencePointManager;

        public event Action<MRReferencePoint> pointAdded;
        public event Action<MRReferencePoint> pointUpdated;
        public event Action<MRReferencePoint> pointRemoved;

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        void IFunctionalityProvider.LoadProvider()
        {
            ARFoundationSessionProvider.RequireARSession();

            var currentSession = ARFoundationSessionProvider.currentSession;
            if (currentSession)
            {
                m_ARReferencePointManager = UnityEngine.Object.FindObjectOfType<ARReferencePointManager>();
                if (!m_ARReferencePointManager)
                {
                    m_ARReferencePointManager = currentSession.gameObject.AddComponent<ARReferencePointManager>();
                    m_ARReferencePointManager.hideFlags = HideFlags.DontSave;
                    m_NewARReferencePointManager = m_ARReferencePointManager;
                }

#if ARFOUNDATION_3_0_1_OR_NEWER
                m_ARReferencePointManager.anchorsChanged += ARReferencePointManagerOnReferencePointsChanged;
#else
                m_ARReferencePointManager.referencePointsChanged += ARReferencePointManagerOnReferencePointsChanged;
#endif
            }
        }

        void ARReferencePointManagerOnReferencePointsChanged(ARReferencePointsChangedEventArgs changedEvent)
        {
            foreach (var point in changedEvent.removed)
            {
                var mrPoint = point.ToMRReferencePoint();
                k_TrackableIds.Remove(mrPoint.id);
                var dataId = this.RemoveData(mrPoint);
                this.RemoveTrait(dataId, TraitNames.Pose);
                if (pointRemoved != null)
                    pointRemoved(mrPoint);
            }

            foreach (var point in changedEvent.updated)
            {
                var mrPoint = point.ToMRReferencePoint();
                var dataId = this.AddOrUpdateData(mrPoint);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, mrPoint.pose);
                if (pointUpdated != null)
                    pointUpdated(mrPoint);
            }

            foreach (var point in changedEvent.added)
            {
                var mrPoint = point.ToMRReferencePoint();
                k_TrackableIds[mrPoint.id] = point;
                var dataId = this.AddOrUpdateData(mrPoint);
                this.AddOrUpdateTrait(dataId, TraitNames.Pose, mrPoint.pose);
                if (pointAdded != null)
                    pointAdded(mrPoint);
            }
        }

        void IFunctionalityProvider.UnloadProvider()
        {
#if ARFOUNDATION_3_0_1_OR_NEWER
            m_ARReferencePointManager.anchorsChanged -= ARReferencePointManagerOnReferencePointsChanged;
#else
            m_ARReferencePointManager.referencePointsChanged -= ARReferencePointManagerOnReferencePointsChanged;
#endif
            if (m_NewARReferencePointManager)
                UnityObjectUtils.Destroy(m_NewARReferencePointManager);

            ARFoundationSessionProvider.TearDownARSession();
        }

        public void GetAllReferencePoints(List<MRReferencePoint> referencePoints)
        {
            foreach (var point in m_ARReferencePointManager.trackables)
            {
                referencePoints.Add(point.ToMRReferencePoint());
            }
        }

        public bool TryAddReferencePoint(Pose pose, out MarsTrackableId referencePointId)
        {
            if (m_ARReferencePointManager)
            {
#if ARFOUNDATION_4_1_OR_NEWER
                var go = new GameObject("Reference point");
                go.transform.SetLocalPose(pose);
                var pointAdded = go.AddComponent<ARAnchor>();
#elif ARFOUNDATION_3_0_1_OR_NEWER
                var pointAdded = m_ARReferencePointManager.AddAnchor(pose);
#else
                var pointAdded = m_ARReferencePointManager.AddReferencePoint(pose);
#endif
                referencePointId = pointAdded.ToMRReferencePoint().id;
                return true;
            }

            referencePointId = default(MarsTrackableId);
            return false;
        }

        public bool TryGetReferencePoint(MarsTrackableId id, out MRReferencePoint referencePoint)
        {
            ARReferencePoint arReferencePoint;
            if (!k_TrackableIds.TryGetValue(id, out arReferencePoint) || m_ARReferencePointManager == null)
            {
                referencePoint = default(MRReferencePoint);
                return false;
            }

#if ARFOUNDATION_3_0_1_OR_NEWER
            var result = m_ARReferencePointManager.GetAnchor(arReferencePoint.trackableId);
#else
            var result = m_ARReferencePointManager.GetReferencePoint(arReferencePoint.trackableId);
#endif
            referencePoint = result.ToMRReferencePoint();
            return true;
        }

        public bool TryRemoveReferencePoint(MarsTrackableId id)
        {
            ARReferencePoint referencePoint;
            if (!k_TrackableIds.TryGetValue(id, out referencePoint))
                return false;

            if (m_ARReferencePointManager)
#if ARFOUNDATION_4_1_OR_NEWER
                UnityObjectUtils.Destroy(referencePoint.gameObject);
#elif ARFOUNDATION_3_0_1_OR_NEWER
                return m_ARReferencePointManager.RemoveAnchor(referencePoint);
#else
                return m_ARReferencePointManager.RemoveReferencePoint(referencePoint);
#endif

            return false;
        }

        public void StopTrackingReferencePoints()
        {
            if (m_ARReferencePointManager && m_ARReferencePointManager.subsystem != null)
                m_ARReferencePointManager.subsystem.Stop();
        }

        public void StartTrackingReferencePoints()
        {
            if (m_ARReferencePointManager && m_ARReferencePointManager.subsystem != null)
                m_ARReferencePointManager.subsystem.Start();
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesReferencePoints>(obj);
        }
    }
}
#endif

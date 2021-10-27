#if ARFOUNDATION_2_1_OR_NEWER
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

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
    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationHitTestingProvider : IProvidesMRHitTesting
    {
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<ARRaycastHit> k_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_ARRaycastManager;
        ARRaycastManager m_NewARRaycastManager;

        public bool ScreenHitTest(Vector2 screenPosition, out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any)
        {
            if (m_ARRaycastManager == null)
            {
                result = default(MRHitTestResult);
                return false;
            }

            k_Hits.Clear();
            if (m_ARRaycastManager.Raycast(screenPosition, k_Hits, HitTestResultTypeToTrackableType(types)))
            {
                foreach (var hit in k_Hits)
                {
                    result = hit.ToMRHitTestResult();
                    return true;
                }
            }

            result = new MRHitTestResult();
            return false;
        }

        public bool WorldHitTest(Ray ray, out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any)
        {
            if (m_ARRaycastManager == null)
            {
                result = default(MRHitTestResult);
                return false;
            }

            k_Hits.Clear();
            if (m_ARRaycastManager.Raycast(ray, k_Hits, HitTestResultTypeToTrackableType(types)))
            {
                foreach (var hit in k_Hits)
                {
                    result = hit.ToMRHitTestResult();
                    return true;
                }
            }

            result = new MRHitTestResult();
            return false;
        }

        public void StopHitTesting()
        {
            if (m_ARRaycastManager && m_ARRaycastManager.subsystem != null)
                m_ARRaycastManager.subsystem.Stop();
        }

        public void StartHitTesting()
        {
            if (m_ARRaycastManager && m_ARRaycastManager.subsystem != null)
                m_ARRaycastManager.subsystem.Start();
        }

        static TrackableType HitTestResultTypeToTrackableType(MRHitTestResultTypes types)
        {
            switch (types)
            {
                case MRHitTestResultTypes.FeaturePoint:
                    return TrackableType.FeaturePoint;
                case MRHitTestResultTypes.HorizontalPlane:
                case MRHitTestResultTypes.VerticalPlane:
                case MRHitTestResultTypes.Plane:
                    return TrackableType.PlaneWithinPolygon;
                default:
                    return TrackableType.All;
            }
        }

        void IFunctionalityProvider.LoadProvider()
        {
            ARFoundationSessionProvider.RequireARSession();
            var currentSession = ARFoundationSessionProvider.currentSession;
            if (currentSession)
            {
                m_ARRaycastManager = UnityEngine.Object.FindObjectOfType<ARRaycastManager>();
                if (!m_ARRaycastManager)
                {
                    m_ARRaycastManager = currentSession.gameObject.AddComponent<ARRaycastManager>();
                    m_ARRaycastManager.hideFlags = HideFlags.DontSave;
                    m_NewARRaycastManager = m_ARRaycastManager;
                }
            }
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesMRHitTesting>(obj);
        }

        void IFunctionalityProvider.UnloadProvider()
        {
            if (m_NewARRaycastManager)
                UnityObjectUtils.Destroy(m_NewARRaycastManager);

            ARFoundationSessionProvider.TearDownARSession();
        }
    }
}
#endif

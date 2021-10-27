using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Visualizers
{
    [MovedFrom("Unity.MARS.Behaviors")]
    public class MARSMarkerVisualizer : MonoBehaviour, IUsesMarkerTracking, IUsesCameraOffset, ISimulatable
    {
        IProvidesMarkerTracking IFunctionalitySubscriber<IProvidesMarkerTracking>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

#pragma warning disable 649
        [SerializeField]
        GameObject m_MarkerPrefab;
#pragma warning restore 649

        readonly Dictionary<MarsTrackableId, GameObject> m_MarkerGameObjects =  new Dictionary<MarsTrackableId, GameObject>();

        void OnEnable()
        {
            this.SubscribeMarkerAdded(MarkerAddedHandler);
            this.SubscribeMarkerUpdated(MarkerUpdatedHandler);
            this.SubscribeMarkerRemoved(MarkerRemovedHandler);

            var markers = new List<MRMarker>();
            this.GetMarkers(markers);
            foreach (var marker in markers)
            {
                CreateOrUpdateGameObject(marker);
            }
        }

        void OnDisable()
        {
            this.UnsubscribeMarkerAdded(MarkerAddedHandler);
            this.UnsubscribeMarkerUpdated(MarkerUpdatedHandler);
            this.UnsubscribeMarkerRemoved(MarkerRemovedHandler);
        }

        void MarkerAddedHandler(MRMarker marker)
        {
            if (m_MarkerPrefab)
                CreateOrUpdateGameObject(marker);
        }

        void MarkerUpdatedHandler(MRMarker marker)
        {
            if (m_MarkerPrefab)
                CreateOrUpdateGameObject(marker);
        }

        void MarkerRemovedHandler(MRMarker marker)
        {
            GameObject go;
            if (m_MarkerGameObjects.TryGetValue(marker.id, out go))
            {
                UnityObjectUtils.Destroy(go);
                m_MarkerGameObjects.Remove(marker.id);
            }
        }

        void CreateOrUpdateGameObject(MRMarker marker)
        {
            if (MARSCore.instance.paused)
                return;

            GameObject go;
            var id = marker.id;
            if (!m_MarkerGameObjects.TryGetValue(id, out go))
            {
                go = Instantiate(m_MarkerPrefab, transform);
                m_MarkerGameObjects.Add(id, go);
            }

            var goTransform = go.transform;
            var pose = this.ApplyOffsetToPose(marker.pose);
            goTransform.SetWorldPose(pose);
            goTransform.localScale = this.GetCameraScale() * Vector3.one;
        }
    }
}

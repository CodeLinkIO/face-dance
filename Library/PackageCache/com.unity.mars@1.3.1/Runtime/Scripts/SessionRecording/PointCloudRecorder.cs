using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;
using Object = UnityEngine.Object;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Data recorder for point clouds
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PointCloudRecorder : DataRecorder, IUsesPointCloud
    {
        List<PointCloudEvent> m_PointCloudEvents = new List<PointCloudEvent>();

        /// <summary>
        /// List of point cloud update events
        /// </summary>
        public List<PointCloudEvent> PointCloudEvents
        {
            get { return m_PointCloudEvents; }
            set { m_PointCloudEvents = value; }
        }

        IProvidesPointCloud IFunctionalitySubscriber<IProvidesPointCloud>.provider { get; set; }

        /// <summary>
        /// Create a new point cloud data recording track on the provided timeline
        /// </summary>
        /// <param name="timeline">The timeline to which the track will be added</param>
        /// <param name="newAssets">A list to which new assets can be added. None are added by this method</param>
        /// <returns>The point cloud recording</returns>
        public override DataRecording TryCreateDataRecording(TimelineAsset timeline, List<Object> newAssets)
        {
            var signalTrack = timeline.CreateTrack<SignalTrack>(null, "Point Cloud Events");
            foreach (var pointCloudEvent in m_PointCloudEvents)
            {
                var time = pointCloudEvent.Time;
                var marker = signalTrack.CreateMarker<PointCloudEventMarker>(time);
                marker.Data = pointCloudEvent.Data;
                marker.name = $"Points {time}";
            }

            var recording = ScriptableObject.CreateInstance<PointCloudRecording>();
            recording.SignalTrack = signalTrack;
            recording.hideFlags = HideFlags.NotEditable;
            return recording;
        }

        /// <inheritdoc />
        protected override void Setup()
        {
            this.SubscribePointCloudUpdated(OnPointCloudUpdated);
        }

        /// <inheritdoc />
        protected override void TearDown()
        {
            this.UnsubscribePointCloudUpdated(OnPointCloudUpdated);
        }

        void OnPointCloudUpdated(Dictionary<MarsTrackableId, PointCloudData> data)
        {
            var dataList = new List<SerializedPointCloudData>();
            foreach (var kvp in data)
            {
                var eventData = new SerializedPointCloudData();
                var pointCloudData = kvp.Value;
                var positions = pointCloudData.Positions;
                if (!positions.HasValue)
                    continue;

                var positionsValue = positions.Value;
                eventData.Positions = positionsValue.ToArray();
                var length = positionsValue.Length;

                var identifiers = pointCloudData.Identifiers;
                if (identifiers.HasValue && identifiers.Value.Length == length)
                    eventData.Identifiers = identifiers.Value.ToArray();

                var confidenceValues = pointCloudData.ConfidenceValues;
                if (confidenceValues.HasValue && confidenceValues.Value.Length == length)
                    eventData.ConfidenceValues = confidenceValues.Value.ToArray();

                dataList.Add(eventData);
            }

            m_PointCloudEvents.Add(new PointCloudEvent { Time = TimeFromStart, Data = dataList});
        }
    }
}

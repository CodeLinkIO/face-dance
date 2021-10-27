using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.MARS.Recording;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Data recording for planes
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PlaneFindingRecorder : DataRecorder, IUsesPlaneFinding
    {
        List<PlaneEvent> m_PlaneEvents = new List<PlaneEvent>();

        /// <summary>
        /// List of plane events
        /// </summary>
        public List<PlaneEvent> PlaneEvents { get { return m_PlaneEvents; } set { m_PlaneEvents = value; } }

        IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }

        /// <summary>
        /// Create a new plane recording track on the provided timeline
        /// </summary>
        /// <param name="timeline">The timeline to which the track will be added</param>
        /// <param name="newAssets">A list to which new assets can be added. None are added by this method</param>
        /// <returns>The plane recording</returns>
        public override DataRecording TryCreateDataRecording(TimelineAsset timeline, List<Object> newAssets)
        {
            var signalTrack = timeline.CreateTrack<SignalTrack>(null, "Plane Events");
            foreach (var planeEvent in m_PlaneEvents)
            {
                var marker = signalTrack.CreateMarker<PlaneEventMarker>(planeEvent.time);
                marker.SetData(planeEvent);
            }

            var recording = ScriptableObject.CreateInstance<PlaneFindingRecording>();
            recording.SignalTrack = signalTrack;
            recording.hideFlags = HideFlags.NotEditable;
            return recording;
        }

        /// <inheritdoc />
        protected override void Setup()
        {
            this.SubscribePlaneAdded(OnPlaneAdded);
            this.SubscribePlaneUpdated(OnPlaneUpdated);
            this.SubscribePlaneRemoved(OnPlaneRemoved);
        }

        /// <inheritdoc />
        protected override void TearDown()
        {
            this.UnsubscribePlaneAdded(OnPlaneAdded);
            this.UnsubscribePlaneUpdated(OnPlaneUpdated);
            this.UnsubscribePlaneRemoved(OnPlaneRemoved);
        }

        void OnPlaneAdded(MRPlane plane)
        {
            m_PlaneEvents.Add(new PlaneEvent
            {
                time = TimeFromStart,
                plane = RecordPlane(plane), // The plane keeps its collection references as it updates, so capture a copy of the plane
                eventType = TrackableEventType.Added
            });
        }

        void OnPlaneUpdated(MRPlane plane)
        {
            m_PlaneEvents.Add(new PlaneEvent
            {
                time = TimeFromStart,
                plane = RecordPlane(plane),
                eventType = TrackableEventType.Updated
            });
        }

        void OnPlaneRemoved(MRPlane plane)
        {
            m_PlaneEvents.Add(new PlaneEvent
            {
                time = TimeFromStart,
                plane = RecordPlane(plane),
                eventType = TrackableEventType.Removed
            });
        }

        static MRPlane RecordPlane(MRPlane plane)
        {
            return new MRPlane
            {
                id = plane.id,
                alignment = plane.alignment,
                pose = plane.pose,
                center = plane.center,
                extents = plane.extents,
                vertices = new List<Vector3>(plane.vertices),
                textureCoordinates = new List<Vector2>(plane.textureCoordinates),
                normals = new List<Vector3>(plane.normals),
                indices = new List<int>(plane.indices)
            };
        }
    }
}

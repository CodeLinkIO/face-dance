using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.MARS.Recording;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Records face tracking data
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public class FaceTrackingRecorder : DataRecorder, IUsesFaceTracking
    {
        readonly List<FaceEvent> m_FaceEvents = new List<FaceEvent>();

        MRFaceLandmark[] m_LandmarkEnumValues;
        MRFaceExpression[] m_ExpressionEnumValues;
        bool m_HasProvider;

        IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }

        /// <summary>
        /// Try to add recorded face data to a Timeline and create a face recording object that references this recorded data
        /// </summary>
        /// <param name="timeline">The Timeline that holds recorded data</param>
        /// <param name="newAssets">List to be filled out with newly created Assets other than the Data Recording.
        /// This method adds none.</param>
        /// <returns>The face recording object, or null if creation fails</returns>
        public override DataRecording TryCreateDataRecording(TimelineAsset timeline, List<Object> newAssets)
        {
            if (!m_HasProvider)
            {
                Debug.LogWarning("Failed to create face tracking recording. No face tracking provider available.");
                return null;
            }

            var signalTrack = timeline.CreateTrack<SignalTrack>(null, "Face Tracking Events");
            foreach (var faceEvent in m_FaceEvents)
            {
                var marker = signalTrack.CreateMarker<FaceEventMarker>(faceEvent.Time);
                marker.SetData(faceEvent);
            }

            var recording = FaceTrackingRecording.Create(signalTrack, this.GetCurrentMaximumFaceCount(), m_LandmarkEnumValues, m_ExpressionEnumValues);
            recording.hideFlags = HideFlags.NotEditable;
            return recording;
        }

        protected override void Setup()
        {
            m_HasProvider = this.HasProvider();
            if (!m_HasProvider)
                return;

            m_LandmarkEnumValues = EnumValues<MRFaceLandmark>.Values;
            m_ExpressionEnumValues = EnumValues<MRFaceExpression>.Values;
            this.SubscribeFaceAdded(OnFaceAdded);
            this.SubscribeFaceUpdated(OnFaceUpdated);
            this.SubscribeFaceRemoved(OnFaceRemoved);
        }

        protected override void TearDown()
        {
            if (!m_HasProvider)
                return;

            this.UnsubscribeFaceAdded(OnFaceAdded);
            this.UnsubscribeFaceUpdated(OnFaceUpdated);
            this.UnsubscribeFaceRemoved(OnFaceRemoved);
        }

        void OnFaceAdded(IMRFace face)
        {
            m_FaceEvents.Add(new FaceEvent
            {
                Time = GetCurrentTime(),
                FaceData = new SerializedFaceData(face, m_LandmarkEnumValues, m_ExpressionEnumValues),
                EventType = TrackableEventType.Added
            });
        }

        void OnFaceUpdated(IMRFace face)
        {
            m_FaceEvents.Add(new FaceEvent
            {
                Time = GetCurrentTime(),
                FaceData = new SerializedFaceData(face, m_LandmarkEnumValues, m_ExpressionEnumValues),
                EventType = TrackableEventType.Updated
            });
        }

        void OnFaceRemoved(IMRFace face)
        {
            m_FaceEvents.Add(new FaceEvent
            {
                Time = GetCurrentTime(),
                FaceData = new SerializedFaceData(face, m_LandmarkEnumValues, m_ExpressionEnumValues),
                EventType = TrackableEventType.Removed
            });
        }

        double GetCurrentTime()
        {
            var appendedDataTimestamp = DataRecorderUtils.TryGetAppendedDataTimestamp();
            return appendedDataTimestamp ?? TimeFromStart;
        }
    }
}

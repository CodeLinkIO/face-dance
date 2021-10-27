using Unity.MARS.Recording;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Event for face tracking recordings
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public struct FaceEvent
    {
        public double Time;
        public SerializedFaceData FaceData;
        public TrackableEventType EventType;
    }
}

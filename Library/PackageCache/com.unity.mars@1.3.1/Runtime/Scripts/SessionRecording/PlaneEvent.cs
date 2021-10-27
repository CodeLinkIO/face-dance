using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Event for plane recordings
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public struct PlaneEvent
    {
        public float time;
        public MRPlane plane;
        public TrackableEventType eventType;
    }
}

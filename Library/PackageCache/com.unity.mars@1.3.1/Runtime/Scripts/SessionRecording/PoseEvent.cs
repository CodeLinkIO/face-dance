using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Event for camera tracking recordings
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public struct PoseEvent
    {
        public float time;
        public Pose pose;
    }
}

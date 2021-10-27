using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Event for point cloud recordings
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public struct PointCloudEvent
    {
        public float Time;
        public List<SerializedPointCloudData> Data;
    }
}

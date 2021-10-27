using UnityEngine;

namespace Unity.MARS.Simulation
{
    enum TrackingFailureCause
    {
        None,
        OutOfFrustum,
        OutOfRange,
        Occluded,
    }

    readonly struct SimulatedMarkerTrackingResult
    {
        public readonly float Quality;
        public readonly TrackingFailureCause FailureCause;
        public readonly Vector3 FirstOcclusionPoint;
        public readonly int RayHitCount;

        public SimulatedMarkerTrackingResult(float quality, TrackingFailureCause failureCause = TrackingFailureCause.None,
            Vector3 firstOcclusionPoint = default, int rayHitCount = 0)
        {
            Quality = quality;
            FailureCause = failureCause;
            FirstOcclusionPoint = firstOcclusionPoint;
            RayHitCount = rayHitCount;
        }
    }
}

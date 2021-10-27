using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Mirrors UnityEngine.XR.ARSubsystems.TrackingState. But the indices are not in order.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum MARSTrackingState
    {
        /// <summary>
        /// Not tracking.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Tracking is working normally.
        /// </summary>
        Tracking = 1,

        /// <summary>
        /// Some tracking information is available, but it is limited or of poor quality.
        /// </summary>
        Limited = 2
    }

}

#if ARFOUNDATION_2_1_OR_NEWER
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class TrackableIdExtensions
    {
        public static MarsTrackableId ToMarsId(this TrackableId id)
        {
            return new MarsTrackableId(id.subId1, id.subId2);
        }

        // Instead of just casting, explicitly specify conversion in case the definition of AR Foundation's enum changes
        internal static MARSTrackingState ToMARSTrackingState(this TrackingState state)
        {
            switch (state)
            {
                case TrackingState.None: return MARSTrackingState.Unknown;
                case TrackingState.Limited: return MARSTrackingState.Limited;
                case TrackingState.Tracking: return MARSTrackingState.Tracking;
                default: return MARSTrackingState.Unknown;
            }
        }
    }


}
#endif

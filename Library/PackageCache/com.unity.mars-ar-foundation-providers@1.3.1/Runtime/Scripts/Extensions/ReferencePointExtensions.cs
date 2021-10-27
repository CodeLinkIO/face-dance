#if ARFOUNDATION_2_1_OR_NEWER
using Unity.XRTools.Utils;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARSubsystems;

#if ARFOUNDATION_3_0_1_OR_NEWER
using ARReferencePoint = UnityEngine.XR.ARFoundation.ARAnchor;
#else
using UnityEngine.XR.ARFoundation;
#endif

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class ReferencePointExtensions
    {
        public static MRReferencePoint ToMRReferencePoint(this ARReferencePoint point)
        {
            var mrReferencePoint = new MRReferencePoint
            {
                id = point.trackableId.ToMarsId(),
                pose = point.transform.GetLocalPose()
            };

            switch (point.trackingState)
            {
                case TrackingState.Tracking:
                    mrReferencePoint.trackingState = MARSTrackingState.Tracking;
                    break;
                case TrackingState.Limited:
                    mrReferencePoint.trackingState = MARSTrackingState.Limited;
                    break;
                default:
                    mrReferencePoint.trackingState = MARSTrackingState.Unknown;
                    break;
            }

            return mrReferencePoint;
        }
    }
}
#endif

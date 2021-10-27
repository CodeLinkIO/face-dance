#if ARFOUNDATION_2_1_OR_NEWER
using Unity.XRTools.Utils;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class ARTrackedImageExtensions
    {
        public static MRMarker ToMRMarker(this ARTrackedImage trackedImage)
        {
            var mrMarker = new MRMarker
            {
                id = trackedImage.trackableId.ToMarsId(),
                pose = trackedImage.transform.GetWorldPose(),
                markerId = trackedImage.referenceImage.guid,
                extents = trackedImage.extents,
                trackingState = trackedImage.trackingState.ToMARSTrackingState(),
            };

            return mrMarker;
        }
    }
}
#endif

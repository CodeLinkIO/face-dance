#if ARFOUNDATION_2_1_OR_NEWER
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARFoundation;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class XRRaycastHitExtensions
    {
        public static MRHitTestResult ToMRHitTestResult(this ARRaycastHit hit)
        {
            return new MRHitTestResult
            {
                pose = hit.pose
            };
        }
    }
}
#endif

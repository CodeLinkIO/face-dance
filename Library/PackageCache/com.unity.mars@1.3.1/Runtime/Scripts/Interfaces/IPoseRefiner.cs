using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Declares that a MonoBehaviour can refine a pose
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IPoseRefiner
    {
        Pose RefinePose(Pose pose, bool leaveProxyInNewPose);
    }
}

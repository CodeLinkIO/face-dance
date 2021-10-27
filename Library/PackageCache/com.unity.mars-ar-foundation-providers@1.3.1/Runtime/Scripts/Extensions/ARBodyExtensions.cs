#if ARFOUNDATION_4_OR_NEWER
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Contains methods for handling taking body tracking data from AR Foundation and converting to MARS format
    /// </summary>
    static class ARBodyExtensions
    {
        const float k_ControlRigHeight = 1.857131f;

        internal static void UpdateARFoundationBody(this ARFoundationBody targetBody, ARHumanBody sourceBody,
            Transform poseRig, float poseScale, Transform[] jointMapping, HumanPoseHandler poseExtractor)
        {
            // Pose and transform are the same
            poseRig.position = sourceBody.pose.position;
            poseRig.rotation = sourceBody.pose.rotation;

            // Load transforms into temporary mesh
            var joints = sourceBody.joints;
            if (joints.IsCreated)
            {
                for (var i = 0; i < ARKitJointIndices.Total; ++i)
                {
                    var joint = joints[i];
                    var bone = jointMapping[i];
                    if (bone != null)
                    {
                        var boneTransform = bone.transform;
                        boneTransform.localPosition = joint.localPose.position;
                        boneTransform.localRotation = joint.localPose.rotation;
                    }
                }
            }

            // Read out pose
            poseExtractor.GetHumanPose(ref targetBody.BodyPoseInternal);

            targetBody.pose = new Pose { position  = (targetBody.BodyPoseInternal.bodyPosition * poseScale - poseRig.localPosition) * poseRig.lossyScale.y + poseRig.position,
                                         rotation = targetBody.BodyPoseInternal.bodyRotation };

            targetBody.Height = k_ControlRigHeight * sourceBody.estimatedHeightScaleFactor;
            targetBody.DeviceData = sourceBody;
        }
    }
}
#endif

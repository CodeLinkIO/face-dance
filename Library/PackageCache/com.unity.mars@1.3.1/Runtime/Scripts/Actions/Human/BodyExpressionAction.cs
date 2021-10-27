using System;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.MARS.Actions
{
    [Serializable]
    struct BodyExpressionEvent
    {
#pragma warning disable 649
        [SerializeField]
        internal BodyPoseData bodyPose;

        [SerializeField]
        internal UnityEvent triggeringEvent;
#pragma warning restore 649
    }

    /// <summary>
    /// Fires events when body poses are matched
    /// </summary>
    [HelpURL(DocumentationConstants.BodyExpressionActionDocs)]
    [MonoBehaviourComponentMenu(typeof(BodyExpressionAction), "Action/Body Expressions")]
    public class BodyExpressionAction : MonoBehaviour, IMatchAcquireHandler, IMatchUpdateHandler, IRequiresTraits,
        IUsesMARSTrackableData<IMarsBody>
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Body, TraitDefinitions.Pose };

        static Animator s_PoseMatchingRig;

        [SerializeField]
        bool m_ScaleToMatchHeight = true;

#pragma warning disable 649
        [SerializeField]
        BodyExpressionEvent[] m_TriggerEvents;
#pragma warning restore 649

        [HideInInspector]
        [SerializeField]
        float m_BodyPoseDotProductMatchTolerance = 0.707f;

        IMarsBody m_AssignedBody;
        HumanPoseHandler m_PoseApplicator;
        HumanPose m_BodyPose;
        float m_RigHeight;

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        void OnEnable()
        {
            EnsureBodyPoseMatchingRig();
            m_PoseApplicator = new HumanPoseHandler(s_PoseMatchingRig.avatar, s_PoseMatchingRig.transform);
            m_RigHeight = s_PoseMatchingRig.humanScale * MarsBody.BodyDefaultHeight;
        }

        /// <summary>
        /// Called by MARS when the proxy data is updated
        /// </summary>
        /// <param name="queryResult">The query result data for this match</param>
        public void OnMatchUpdate(QueryResult queryResult)
        {
            EnsureBodyPoseMatchingRig();
            if (!isActiveAndEnabled || s_PoseMatchingRig == null)
                return;

            UpdateBody(queryResult);
            MatchBody();
        }

        /// <summary>
        /// Called by MARS when the proxy data is matched
        /// </summary>
        /// <param name="queryResult">The query result data for this match</param>
        public void OnMatchAcquire(QueryResult queryResult)
        {
            EnsureBodyPoseMatchingRig();
            if (!isActiveAndEnabled || s_PoseMatchingRig == null)
                return;

            UpdateBody(queryResult);
            MatchBody();
        }

        internal static void EnsureBodyPoseMatchingRig()
        {
            if (s_PoseMatchingRig != null)
                return;

            var rig = GameObject.Find(MarsBodySettings.BodyPoseMatchingRigName);
            if (rig)
            {
                var rigAnimator = rig.GetComponent<Animator>();
                if (rigAnimator)
                {
                    s_PoseMatchingRig = rigAnimator;
                    return;
                }

                DestroyImmediate(rig);
                Debug.LogError("MarsBodySettings.DefaultPoseMatchingBodyRig is missing an Animator component, " +
                               "and will be unable to match body poses.");
            }

            var generatedPoseMatchingRig =
                Instantiate(MarsBodySettings.instance.DefaultPoseMatchingBodyRig).transform;

            generatedPoseMatchingRig.localPosition = Vector3.zero;
            generatedPoseMatchingRig.localRotation = Quaternion.identity;
            generatedPoseMatchingRig.name = MarsBodySettings.BodyPoseMatchingRigName;
            generatedPoseMatchingRig.gameObject.hideFlags = HideFlags.HideInHierarchy;
            var generatedRigAnimator = generatedPoseMatchingRig.GetComponent<Animator>();

            Debug.Assert(generatedRigAnimator != null);

            s_PoseMatchingRig = generatedRigAnimator;
        }

        void UpdateBody(QueryResult queryResult)
        {
            m_AssignedBody = queryResult.ResolveValue(this);
            m_BodyPose = m_AssignedBody.BodyPose;
            m_BodyPose.bodyPosition = Vector3.zero;
            m_BodyPose.bodyRotation = Quaternion.identity;

            m_PoseApplicator.SetHumanPose(ref m_BodyPose);

            if (queryResult.TryGetTrait(TraitNames.Pose, out Pose newPose))
                transform.SetWorldPose(newPose);

            if (m_ScaleToMatchHeight)
                transform.localScale = Vector3.one * (m_AssignedBody.Height / m_RigHeight);
        }

        void MatchBody()
        {
            EnsureBodyPoseMatchingRig();

            for (var i = 0; i < m_TriggerEvents.Length; i++)
            {
                if (m_TriggerEvents[i].bodyPose != null &&
                    DoesPoseMatch(s_PoseMatchingRig, m_TriggerEvents[i].bodyPose))
                {
                    m_TriggerEvents[i].triggeringEvent.Invoke();
                }
            }
        }

        bool DoesPoseMatch(Animator currAnimatedBody, BodyPoseData poseDataToMatch)
        {
            if (currAnimatedBody == null)
                return false;

            var currOrientations = GenerateBoneOrientations(currAnimatedBody);
            var rotated = RotatePoseOrientationsTowardsAnimator(poseDataToMatch.BonesOrientations, currAnimatedBody);

            for (var i = 0; i < currOrientations.Length; i++)
            {
                if (poseDataToMatch.RelevantBoneData[i] &&
                    Vector3.Dot(currOrientations[i], rotated[i]) < m_BodyPoseDotProductMatchTolerance)
                    return false;
            }

            return true;
        }

        static Vector3[] RotatePoseOrientationsTowardsAnimator(Vector3[] orientations, Animator anim)
        {
            var rotatedOrientations = new Vector3[orientations.Length];
            for (var i = 0; i < orientations.Length; i++)
            {
                rotatedOrientations[i] = anim.transform.rotation * orientations[i];
            }
            return rotatedOrientations;
        }

        internal static Vector3[] GenerateBoneOrientations(Animator animator)
        {
            var boneOrientations = new Vector3[16];

            boneOrientations[(int)BodyData.Hips] = animator.GetBoneTransform(HumanBodyBones.Hips).up;
            boneOrientations[(int)BodyData.Spine] = animator.GetBoneTransform(HumanBodyBones.Spine).up;
            boneOrientations[(int)BodyData.Chest] = animator.GetBoneTransform(HumanBodyBones.Chest).up;
            boneOrientations[(int)BodyData.UpperChest] = animator.GetBoneTransform(HumanBodyBones.UpperChest).up;
            boneOrientations[(int)BodyData.Neck] = animator.GetBoneTransform(HumanBodyBones.Neck).up;
            boneOrientations[(int)BodyData.Head] = animator.GetBoneTransform(HumanBodyBones.Head).up;

            boneOrientations[(int)BodyData.RightShoulder] = animator.GetBoneTransform(HumanBodyBones.RightShoulder).right;
            boneOrientations[(int)BodyData.RightUpperArm] = animator.GetBoneTransform(HumanBodyBones.RightUpperArm).right;
            boneOrientations[(int)BodyData.RightLowerArm] = animator.GetBoneTransform(HumanBodyBones.RightLowerArm).right;

            boneOrientations[(int)BodyData.LeftShoulder] = -animator.GetBoneTransform(HumanBodyBones.LeftShoulder).right;
            boneOrientations[(int)BodyData.LeftUpperArm] = -animator.GetBoneTransform(HumanBodyBones.LeftUpperArm).right;
            boneOrientations[(int)BodyData.LeftLowerArm] = -animator.GetBoneTransform(HumanBodyBones.LeftLowerArm).right;

            boneOrientations[(int)BodyData.RightUpperLeg] = -animator.GetBoneTransform(HumanBodyBones.RightUpperLeg).up;
            boneOrientations[(int)BodyData.RightLowerLeg] = -animator.GetBoneTransform(HumanBodyBones.RightLowerLeg).up;

            boneOrientations[(int)BodyData.LeftUpperLeg] = -animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg).up;
            boneOrientations[(int)BodyData.LeftLowerLeg] = -animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg).up;

            return boneOrientations;
        }
    }
}

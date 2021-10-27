using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Actions
{
    [MonoBehaviourComponentMenu(typeof(MatchBodyPoseAction), "Action/Match Body Pose Action")]
    [HelpURL(DocumentationConstants.MatchBodyPoseActionDocs)]
    class MatchBodyPoseAction : TransformAction, IMatchAcquireHandler, IMatchUpdateHandler,
        IUsesMARSTrackableData<IMarsBody>, IRequiresTraits
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Body, TraitDefinitions.Pose };

#pragma warning disable 649
        [SerializeField]
        Animator m_Animator;
#pragma warning restore 649

        [SerializeField]
        bool m_ScaleToMatchHeight = true;

        IMarsBody m_AssignedBody;
        HumanPoseHandler m_PoseApplicator;
        HumanPose m_BodyPose;
        float m_RigHeight;

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        void OnEnable()
        {
            if (m_Animator == null)
            {
                enabled = false;
                return;
            }

            if (!m_Animator.isHuman)
            {
                Debug.LogError("Cannot apply pose to a non-humanoid. Please set associated rig as a humanoid avatar.");
                enabled = false;
                return;
            }

            m_PoseApplicator = new HumanPoseHandler(m_Animator.avatar, m_Animator.transform);
            m_RigHeight = m_Animator.humanScale * MarsBody.BodyDefaultHeight;
        }

        public void OnMatchAcquire(QueryResult queryResult)
        {
            UpdateBodyPose(queryResult);
        }

        public void OnMatchUpdate(QueryResult queryResult)
        {
            UpdateBodyPose(queryResult);
        }


        void UpdateBodyPose(QueryResult queryResult)
        {
            if (!isActiveAndEnabled || m_Animator == null)
                return;

            m_AssignedBody = queryResult.ResolveValue(this);
            m_BodyPose = m_AssignedBody.BodyPose;

            // We zero out the internal body position here - we let SetPose action handle that instead
            m_BodyPose.bodyPosition = Vector3.zero;
            m_BodyPose.bodyRotation = Quaternion.identity;

            m_PoseApplicator.SetHumanPose(ref m_BodyPose);

            if (queryResult.TryGetTrait(TraitNames.Pose, out Pose newPose))
                transform.SetWorldPose(newPose);

            if (m_ScaleToMatchHeight)
            {
                transform.localScale = Vector3.one * (m_AssignedBody.Height / m_RigHeight);
            }
        }
    }
}

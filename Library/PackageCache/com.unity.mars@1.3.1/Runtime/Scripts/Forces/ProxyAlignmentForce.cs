using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Forces.ForceDefinitions;
using Unity.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS.Forces
{
    /// <summary>
    /// How this object should align with it's target
    /// </summary>
    [Serializable]
    public enum ProxyAlignmentForceType
    {
        /// <summary>
        /// Goal transform is the target's transform
        /// </summary>
        MoveToAndAlignWith = 0,

        /// <summary>
        /// Effectively 'go towards': look at target while moving towards it's location
        /// </summary>
        MoveToAndFace,

        /// <summary>
        /// Towards closest point directly in front of target, and face it
        /// </summary>
        CenterInFrontOfAndFace,

        /// <summary>
        /// Stores the relative pose at Awake, and tries to maintain that.
        /// </summary>
        SceneInitialRelativePose,

        /// <summary>
        /// Stores the relative angle at Awake, and tries to maintain that.
        /// </summary>
        SceneInitialRelativeAngle,

        /// <summary>
        /// Same behavior as MoveToAndFace except the target's backwards facing direction is used. Use this for UI canvases
        /// </summary>
        MoveToAndFaceAwayFrom,
    }

    /// <summary>
    /// Scales how an alignment force is applied to an object
    /// </summary>
    [System.Serializable]
    public struct ProxyAlignmentForceScaling
    {
        [Range(0.0f, 2.0f)]
        [Tooltip("Scales the effect on position of the force. 0 for no effect, 1 for default, etc.")]
        public float movementScale;
        [Range(0.0f, 2.0f)]
        [Tooltip("Scales the effect on rotation of the force. 0 for no effect, 1 for default, etc.")]
        public float rotationScale;

        public ProxyAlignmentForceScaling(float moveForce, float rotationForce)
        {
            movementScale = moveForce;
            rotationScale = rotationForce;
        }

        public static ProxyAlignmentForceScaling Default = new ProxyAlignmentForceScaling(1.0f, 1.0f);
    }

    internal interface IProxyAlignmentForceSource
    {
        // wrapper to avoid making the region definition type public:
        void UpdateAlignmentDefinitionWithin(ProxyForces into);
    }

    [HelpURL(DocumentationConstants.ProxyAlignmentForceDocs)]
    [ComponentTooltip("Applies an alignment force relative to another object.")]
    [MonoBehaviourComponentMenu(typeof(ProxyAlignmentForce), "Forces/Align To")]
    [RequireComponent(typeof(ProxyForces))]
    public class ProxyAlignmentForce : MonoBehaviour, ISimulatable, IProxyAlignmentForceSource
    {
        [SerializeField]
        [Tooltip("Target ProxyForces to align to (if needed, add a ProxyForces component to the target set to NotForced)")]
        private ProxyForces m_TargetProxy;

        [SerializeField]
        [Tooltip("Type of alignment (SceneInitialRelativePose uses initial Scene alignment, etc.)")]
        private ProxyAlignmentForceType m_TargetRelation = ProxyAlignmentForceType.SceneInitialRelativePose;

        [SerializeField]
        [Tooltip("Controls the amount of force applied towards the goal pose.")]
        private ProxyAlignmentForceScaling m_ScaleForces = ProxyAlignmentForceScaling.Default;

        Pose m_RelativeToTargetInitialPose = Pose.identity;
        bool m_HasInitialPose;
        bool m_ReadyForValidation;

        static List<ProxyAlignmentForce> s_NeedingEarlyAlignment = new List<ProxyAlignmentForce>();

        public ProxyAlignmentForce()
        {
            s_NeedingEarlyAlignment.Add(this);
        }

        /// <summary>
        /// Target of this force should align to
        /// </summary>
        public ProxyForces targetProxy
        {
            get => m_TargetProxy;
            set
            {
                m_TargetProxy = value;
                MarkForcesAsDirty();
            }
        }

        /// <summary>
        /// Style of relation to the target
        /// </summary>
        public ProxyAlignmentForceType targetRelation
        {
            get => m_TargetRelation;
            set
            {
                m_TargetRelation = value;
                MarkForcesAsDirty();
            }
        }

        /// <summary>
        /// Strength of the alignment force
        /// </summary>
        public ProxyAlignmentForceScaling scaleForces
        {
            get => m_ScaleForces;
            set
            {
                m_ScaleForces = value;
                MarkForcesAsDirty();
            }
        }

        ProxyForceAlignmentDefinition GetAlignmentDef()
        {
            var al = ProxyForceAlignmentDefinition.Default;
            al.alignmentType = targetRelation;
            al.scaleForces = scaleForces;
            al.relativeFromTargetPose = m_RelativeToTargetInitialPose;
            return al;
        }

        ProxyForceFieldAlignment GetAlignmentForce()
        {
            if (targetProxy)
            {
                targetProxy.CheckFieldUpdated();
            }
            return new ProxyForceFieldAlignment()
            {
                isActive = enabled && gameObject.activeInHierarchy,
                targetProxyId = ((targetProxy ? targetProxy.ForceFieldId : ProxyForceFieldId.DefaultUnknown)),
                alignmentDefinition = GetAlignmentDef(),
            };
        }

        internal static void DoSceneInitAlignment()
        {
            foreach (var aligner in s_NeedingEarlyAlignment)
            {
                if (aligner)
                    aligner.CheckInitialRelativePose();
            }
            s_NeedingEarlyAlignment.Clear();
        }

        public void UpdateAlignmentDefinitionWithin(ProxyForces into)
        {
            into.UpdateAlignment(GetAlignmentForce());
        }

        void Awake()
        {
            CheckInitialRelativePose();
        }

        void Start()
        {
            var vpar = TryFindOwningProxy();
            if (vpar)
            {
                vpar.EnsureSubAlignment(this);
            }
            else
            {
                Debug.LogWarning("This region belongs in a Proxy with ProxyForce!");
            }

            m_ReadyForValidation = true;
        }

        void OnValidate()
        {
            if (!m_ReadyForValidation)
            {
                return;
            }

            MarkForcesAsDirty();
        }

        /// <summary>
        /// Checks that the initial pose has been configured
        /// </summary>
        public void CheckInitialRelativePose()
        {
            if (!m_HasInitialPose)
            {
                m_HasInitialPose = true;
                UpdateInitialRelativePose();
            }
        }

        /// <summary>
        /// Updates the initial relative pose to it's current alignment
        /// </summary>
        public void UpdateInitialRelativePose()
        {
            Pose otherWorld;
            var myPose = PoseUtils.FromTransform(transform);
            if (TryGetTargetPose(out otherWorld, true))
            {
                m_RelativeToTargetInitialPose = PoseUtils.LocalFromWorldPose(otherWorld, myPose);
            }
        }

        ProxyForces TryFindOwningProxy()
        {
            var vpar = gameObject.GetComponent<ProxyForces>();
            if (!vpar)
            {
                vpar = gameObject.GetComponentInParent<ProxyForces>();
            }
            return vpar;
        }

        void OnEnable()
        {
            var vp = TryFindOwningProxy();
            if (vp)
            {
                vp.MarkFieldDirty();
                vp.EnsureSubAlignment(this);
            }
        }

        void OnDisable()
        {
            MarkForcesAsDirty();
        }

        void MarkForcesAsDirty()
        {
            var vp = TryFindOwningProxy();
            if (vp)
            {
                vp.MarkFieldDirty();
            }
        }

        public bool TryGetTargetPose(out Pose pose, bool ignoreActive)
        {
            var hasTarget = (targetProxy && (ignoreActive || (targetProxy.IsTracking)));
            if (hasTarget)
            {
                pose = targetProxy.TransformPose;
                return true;
            }

            pose = Pose.identity;
            return false;
        }

        public bool TryGetGoalPose(out Pose goalPose, bool ignoreActive)
        {
            var myPose = PoseUtils.FromTransform(transform);
            goalPose = myPose;

            if (TryGetTargetPose(out Pose targetPose, ignoreActive))
            {
                var af = GetAlignmentDef();
                goalPose = af.GoalPose(myPose, targetPose);
                return true;
            }

            return false;
        }
    }
}

using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Playables;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Creates data for a MarsBody
    /// When added to a synthesized object, adds a trackable IMRBody to the database.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(PlayableDirector))]
    [RequireComponent(typeof(SynthesizedManualPose))]
    [RequireComponent(typeof(Animator))]
    [HelpURL(DocumentationConstants.SynthesizedBodyDocs)]
    public class SynthesizedBody : SynthesizedTrackable<IMarsBody>, IUsesCameraOffset
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.Body };

        internal Animator animator => m_Animator;

        Animator m_Animator;
        HumanPoseHandler m_PoseExtractor;
        HumanPose m_BodyPose;

        SynthesizedManualPose m_PoseSource;

        PlayableDirector m_playableDirector;
        MarsBody m_BodyData = new MarsBody();
        bool m_MRBodyGenerated = false;
        float m_PoseScalar = 1.0f;
        
        internal PlayableDirector Director { get => m_playableDirector; }

        /// <summary>
        /// The trait which will be added to the associated SynthesizedObject
        /// </summary>
        public override string TraitName { get { return TraitNames.Body; } }

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        /// <summary>
        /// Called by MARS when the SynthesizedObject is initialized
        /// </summary>
        public override void Initialize()
        {
            m_playableDirector = GetComponent<PlayableDirector>();
            m_PoseSource = GetComponent<SynthesizedManualPose>();
            m_Animator = GetComponent<Animator>();

            if (!m_Animator.isHuman)
                Debug.LogError("Animator is not set up as a humanoid - cannot synthesize data. Please set associated rig as a humanoid avatar.");
            else
                m_PoseExtractor = new HumanPoseHandler(m_Animator.avatar, m_Animator.transform);

            m_PoseScalar = m_Animator.humanScale;
        }

        void UpdateBodyFromData()
        {
            if (!m_MRBodyGenerated)
            {
                m_BodyData.id = MarsTrackableId.Create();
                m_MRBodyGenerated = true;
            }

            if (m_PoseExtractor != null)
            {
                // This calculation here is pretty wacky because scale on a rig won't effect the body's
                // origin in the bodyPose but it -will- effect have an effect if it's on a parent

                m_PoseExtractor.GetHumanPose(ref m_BodyPose);
                var parentRotation = Quaternion.identity;
                var parentTransform = transform.parent;
                if (parentTransform != null)
                    parentRotation = parentTransform.rotation;
                m_PoseSource.Position = parentRotation * (((m_BodyPose.bodyPosition * m_PoseScalar) - transform.localPosition) * transform.lossyScale.y) + transform.position;
                m_PoseSource.Rotation = transform.rotation*Quaternion.Inverse(transform.localRotation)*m_BodyPose.bodyRotation;
                m_BodyData.BodyPose = m_BodyPose;
            }

            m_BodyData.Height = m_Animator.humanScale * MarsBody.BodyDefaultHeight * transform.lossyScale.y;

            // Traits from other synthesized data
            var worldPose = m_PoseSource.GetTraitData();
            m_BodyData.pose = worldPose;
        }

        /// <summary>
        /// Get the IMarsBody data for this body
        /// </summary>
        /// <returns>The IMarsBody data</returns>
        public override IMarsBody GetData()
        {
            UpdateBodyFromData();

            return m_BodyData;
        }

        /// <summary>
        /// Called when this body is removed from the MARS database
        /// </summary>
        public override void Terminate()
        {
            m_BodyData.id = MarsTrackableId.InvalidId;
        }
    }
}

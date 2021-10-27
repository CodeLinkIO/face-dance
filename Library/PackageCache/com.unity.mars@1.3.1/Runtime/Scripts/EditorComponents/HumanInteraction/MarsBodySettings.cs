using Unity.MARS.Data;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Default general settings for Body workflows
    /// </summary>
    internal class MarsBodySettings : ScriptableSettings<MarsBodySettings>
    {
        const string k_NoAvatarAnimatorFoundLabel = "No avatar found in Animator in the Default body in MarsBodySettings";
        
        
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Used for attaching landmarks to bodies.")]
        Animator m_DefaultLandmarksBodyRig;

        [SerializeField]
        [Tooltip("Used for generating, loading, saving and matching poses for the BodyExpressionAction")]
        Animator m_DefaultPoseMatchingBodyRig;

        [SerializeField]
        [Tooltip("Used for displaying the preview on BodyPoseData inspectors")]
        Animator m_DefaultPreviewBodyPoseData;

        [SerializeField]
        BodyPoseData m_TPose;
        
#pragma warning restore 649

        Avatar m_BodyAvatar;

        internal const string BodyPoseMatchingRigName = "__BodyPoseMatchingRig";

        internal Animator DefaultLandmarksBodyRig { get => m_DefaultLandmarksBodyRig; }

        internal Animator DefaultPoseMatchingBodyRig { get => m_DefaultPoseMatchingBodyRig; }

        internal BodyPoseData TPoseBodyData { get => m_TPose; }

        internal Animator DefaultPreviewBody { get => m_DefaultPreviewBodyPoseData; }

        internal Avatar DefaultPreviewBodyAvatar
        {
            get
            {
                if (m_BodyAvatar == null)
                {
                    m_BodyAvatar = m_DefaultPreviewBodyPoseData.GetComponent<Animator>().avatar;

                    if (m_BodyAvatar == null)
                        Debug.LogError(k_NoAvatarAnimatorFoundLabel);
                }

                return m_BodyAvatar;
            }
        }
    }
}

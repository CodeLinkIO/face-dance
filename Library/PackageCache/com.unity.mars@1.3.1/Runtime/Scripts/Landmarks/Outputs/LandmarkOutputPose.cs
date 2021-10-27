using System;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Component that contains pose data (position and rotation) for a landmark.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class LandmarkOutputPose : MonoBehaviour, ILandmarkOutput
    {
        [SerializeField]
        bool m_ShowPoseAxes = true;

        [SerializeField]
        Color m_PoseAxesColor = Color.cyan;

        [SerializeField]
        [Range(0.001f, 1f)]
        float m_PoseAxesSize = 0.01f;

        Pose m_CurrentPose;

#pragma warning disable 649
        [SerializeField]
        [Tooltip("If enabled, the landmark rotation will be ignored when setting the transform. " +
            "Enable this if another component is setting the rotation.")]
        bool m_IgnoreRotation;
#pragma warning restore 649

        public Pose currentPose { get { return m_CurrentPose; } set { m_CurrentPose = value; } }

        /// <inheritdoc />
        public void UpdateOutput()
        {
            if (m_IgnoreRotation)
                transform.position = currentPose.position;
            else
                transform.SetWorldPose(currentPose);
        }

        void OnDrawGizmosSelected()
        {
            if (!m_ShowPoseAxes)
                return;

            Gizmos.color = m_PoseAxesColor;
            var position = transform.position;
            var rotation = transform.rotation;

            var worldScale = MARSSession.GetWorldScale();

            Gizmos.DrawWireSphere(position, m_PoseAxesSize * 0.5f * worldScale);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(position, position + rotation * Vector3.right * m_PoseAxesSize * worldScale);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(position, position + rotation * Vector3.up * m_PoseAxesSize * worldScale);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(position, position + rotation * Vector3.forward * m_PoseAxesSize * worldScale);
        }
    }
}

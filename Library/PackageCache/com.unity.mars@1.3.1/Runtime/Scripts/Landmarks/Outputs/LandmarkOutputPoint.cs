using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Component that contains a single point data (position) for a landmark
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class LandmarkOutputPoint : MonoBehaviour, ILandmarkOutput
    {
        [SerializeField]
        bool m_ShowPoint = true;

        [SerializeField]
        Color m_PointColor = Color.cyan;

        [SerializeField]
        [Range(0.01f, 1f)]
        float m_PointSize = 0.1f;

        public Vector3 position { get; set; }

        /// <inheritdoc />
        public void UpdateOutput()
        {
            transform.position = position;
        }

        void OnDrawGizmosSelected()
        {
            if (!m_ShowPoint)
                return;

            Gizmos.color = m_PointColor;
            Gizmos.DrawWireSphere(position, m_PointSize);
        }
    }
}

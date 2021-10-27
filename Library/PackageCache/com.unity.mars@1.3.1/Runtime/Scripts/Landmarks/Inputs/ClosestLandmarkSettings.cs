using System;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    [MovedFrom("Unity.MARS")]
    public class ClosestLandmarkSettings : MonoBehaviour, ILandmarkSettings
    {
        [SerializeField]
        Component m_Target;

        [SerializeField]
        bool m_UpdateIfTargetMoves = true;

        [SerializeField]
        float m_UpdateInterval = 0.03f;

        Vector3 m_PreviousPosition;
        Quaternion m_PreviousRotation;
        float m_TimeSinceLastCheck;

        public Component target { get { return m_Target; } set { m_Target = value; } }

        public event Action<ILandmarkSettings> dataChanged;

        void OnEnable() { MarsTime.MarsUpdate += OnMarsUpdate; }

        void OnDisable() { MarsTime.MarsUpdate -= OnMarsUpdate; }

        void OnMarsUpdate()
        {
            CheckIfMoved();
        }

        void CheckIfMoved()
        {
            if (!m_UpdateIfTargetMoves || dataChanged == null || m_Target == null)
                return;

            m_TimeSinceLastCheck += MarsTime.TimeStep;
            if (m_TimeSinceLastCheck < m_UpdateInterval)
                return;

            m_TimeSinceLastCheck = 0f;
            var targetTransform = m_Target.transform;
            if (targetTransform.position != m_PreviousPosition ||
                targetTransform.rotation != m_PreviousRotation)
            {
                dataChanged(this);
                m_PreviousPosition = targetTransform.position;
                m_PreviousRotation = targetTransform.rotation;
            }
        }

        void OnValidate()
        {
            // If target has a landmark output component, prefer to reference it specifically
            if (m_Target != null)
            {
                var landmarkOutput = m_Target.GetComponent<ILandmarkOutput>();
                if (landmarkOutput != null)
                    m_Target = landmarkOutput as Component;
            }
        }
    }
}

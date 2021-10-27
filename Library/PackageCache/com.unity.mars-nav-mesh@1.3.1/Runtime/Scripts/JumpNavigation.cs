using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.AI
{
    /// <summary>
    /// Paired with a MARSNavMesh Agent, this will allow the agent to visually 'leap' to new locations
    /// </summary>
    [MovedFrom("Unity.MARS.Tests")]
    public class JumpNavigation : MonoBehaviour, MARSNavMeshAgent.ICustomDynamicMotion, MARSNavMeshAgent.ICustomOutOfBoundsMotion
    {
        const float k_JumpHeight = 0.5f;

        public bool Complete { get; set; }
        public Vector3 CustomPosition { get; set; }

        float m_JumpHeight = k_JumpHeight;
        float m_HangTime = 0.0f;
        float m_JumpTimer = 0.0f;

        Vector3 m_JumpStart = Vector3.zero;
        Vector3 m_JumpEnd = Vector3.zero;

        public void DynamicMotionBegin(Vector3 start, Vector3 destination)
        {
            StartJump(start, destination);
        }

        public void OutOfBoundsMotionBegin(Vector3 start, Vector3 destination)
        {
            StartJump(start, destination);
        }

        void StartJump(Vector3 start, Vector3 destination)
        {
            enabled = true;
            m_JumpTimer = 0.0f;
            m_JumpStart = start;
            m_JumpEnd = destination;
            CustomPosition = m_JumpStart;

            var jumpDistance = (start - destination).magnitude;
            var heightDifference = Mathf.Abs(start.y - destination.y);
            m_JumpHeight = heightDifference * 0.5f + k_JumpHeight;

            m_HangTime = Mathf.Sqrt(Mathf.Abs((k_JumpHeight / Physics.gravity.y))) +
                            Mathf.Sqrt(Mathf.Abs(((k_JumpHeight + heightDifference) / Physics.gravity.y)));
        }

        // Performs an animated jump
        void Update()
        {
            if (!Complete)
            {
                m_JumpTimer += Time.deltaTime;
                var jumpPercent = m_JumpTimer / m_HangTime;

                var jumpPosition = Vector3.Lerp(m_JumpStart, m_JumpEnd, jumpPercent);
                jumpPosition.y += m_JumpHeight * (1.0f - (2.0f * jumpPercent - 1) * (2.0f * jumpPercent - 1));
                CustomPosition = jumpPosition;

                if (m_JumpTimer >= m_HangTime)
                {
                    Complete = true;
                }

            }
            else
                enabled = false;
        }
    }
}

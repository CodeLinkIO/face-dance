using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [AddComponentMenu("")]
    sealed class Slider1DHandle : SliderHandleBase
    {
        readonly Vector3 m_Direction;
        Ray m_Ray;
        Vector3 m_HandleStartPos;
        Vector3 m_StartNormalizedOffset;
        float m_StartCenterPosSize;
        float m_StartHandlePosSize;
        Vector3 m_LastFramePos;

        /// <summary>
        /// The direction in world space.
        /// </summary>
        public Vector3 direction
        {
            get { return transform.forward; }
        }

        Ray directionRay
        {
            get { return new Ray(transform.position, direction);}
        }

        public override Plane GetProjectionPlane(Vector3 camPosition)
        {
            Vector3 pos = transform.position;
            Vector3 forward = transform.forward;
            Vector3 camDir = camPosition - pos;

            return new Plane(pos, pos + forward, pos + Vector3.Cross(forward, camDir));
        }

        protected override void OnTranslationBegin(DragTranslation translationInfo)
        {
            Vector3 handlePosition = transform.position;
            m_LastFramePos = handlePosition;

            m_HandleStartPos = MathUtility.ProjectPointOnRay(translationInfo.currentPosition, directionRay);
            Vector3 offset = m_HandleStartPos - handlePosition;
            m_StartNormalizedOffset = offset / HandleUtility.GetHandleSize(handlePosition);
            m_StartCenterPosSize = HandleUtility.GetHandleSize(handlePosition);
            m_StartHandlePosSize = HandleUtility.GetHandleSize(m_HandleStartPos);
        }

        protected override Vector3 GetWorldTranslationDelta(DragTranslation translationInfo, Vector3 sourcePos)
        {
            Vector3 projected = MathUtility.ProjectPointOnRay(translationInfo.currentPosition, directionRay);
            float handleTargetSize = HandleUtility.GetHandleSize(projected); //TODO this isn't true if the target doesn't scale with screen
            float centerTargetSize = handleTargetSize * m_StartCenterPosSize / m_StartHandlePosSize;
            Vector3 newOffset = m_StartNormalizedOffset * centerTargetSize;
            Vector3 newPos = projected - newOffset;

            var delta = newPos - m_LastFramePos;
            m_LastFramePos = newPos;
            m_HandleStartPos = projected;
            return delta;
        }

        protected override void OnTranslationEnd(DragTranslation translationInfo)
        {
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.matrix = Matrix4x4.Translate(transform.position);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(direction * 1000, -direction * 1000);
        }
    }
}

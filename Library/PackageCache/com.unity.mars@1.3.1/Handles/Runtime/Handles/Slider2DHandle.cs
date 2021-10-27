using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    /// <summary>
    /// Handle class that implements the logic of sliding a mesh handle constrained to two axes.
    /// </summary>
    [AddComponentMenu("")]
    class Slider2DHandle : SliderHandleBase
    {
        Vector3 m_LastHitPos = Vector3.zero;

        public override Plane GetProjectionPlane(Vector3 camPosition)
        {
            return new Plane(planeNormal, transform.position);
        }

        public Vector3 planeNormal { get { return transform.forward;} }

        protected sealed override void OnTranslationBegin(DragTranslation translationInfo)
        {
            m_LastHitPos = translationInfo.currentPosition;
        }

        protected sealed override Vector3 GetWorldTranslationDelta(DragTranslation translationInfo, Vector3 sourcePos)
        {
            var delta = translationInfo.currentPosition - m_LastHitPos;
            m_LastHitPos = translationInfo.currentPosition;
            return delta;
        }

        protected sealed override void OnTranslationEnd(DragTranslation translationInfo)
        {
        }

        void OnDrawGizmosSelected()
        {
            var color = Color.blue;
            Gizmos.color = color;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one * 10);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(1, 1, 0));

            color.a = 0.1f;
            Gizmos.color = color;
            Gizmos.DrawCube(Vector3.zero, new Vector3(1, 1, 0));
        }
    }
}

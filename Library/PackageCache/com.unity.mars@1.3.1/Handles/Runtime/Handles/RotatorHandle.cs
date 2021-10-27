using System;
using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [AddComponentMenu("")]
    sealed class RotatorHandle : InteractiveHandle
    {
        public event Action<RotationBeginInfo> rotationBegun;
        public event Action<RotationUpdateInfo> rotationUpdated;
        public event Action<RotationEndInfo> rotationEnded;

        public override Plane GetProjectionPlane(Vector3 camPosition)
        {
            return new Plane(planeNormal, transform.position); ;
        }

        Plane projectionPlane
        {
            get { return new Plane(planeNormal, transform.position); }
        }

        Vector3 planeNormal
        {
            get { return transform.forward; }
        }
        
        Vector3 m_LastDirection;
        Vector3 m_Normal;
        float m_TotalAngle;
        
        protected override void DragBegin(InteractiveHandle target, DragBeginInfo info)
        {
            if (target != ownerHandle)
                return;

            m_LastDirection = info.translation.initialPosition - transform.position;
            m_TotalAngle = 0f;
            m_Normal = planeNormal;

            if (rotationBegun != null) rotationBegun.Invoke(new RotationBeginInfo(
                new RotationInfo( // World
                    0, 
                    0,
                    m_Normal),

                new RotationInfo(  // Local
                    0,
                    0,
                    transform.worldToLocalMatrix.rotation * m_Normal)));
        }

        protected override void DragUpdate(InteractiveHandle target, DragUpdateInfo info)
        {
            if (target != ownerHandle)
                return;

            var currentDir = info.translation.currentPosition - transform.position;

            var deltaAngle = Vector3.SignedAngle(m_LastDirection, currentDir, m_Normal);
            m_TotalAngle += deltaAngle;
            m_LastDirection = currentDir;

            if (rotationUpdated != null) rotationUpdated.Invoke(new RotationUpdateInfo(
                new RotationInfo( // World
                    m_TotalAngle,
                    deltaAngle,
                    m_Normal),

                new RotationInfo(  // Local
                    m_TotalAngle,
                    deltaAngle,
                    transform.worldToLocalMatrix.rotation * m_Normal)));
        }

        protected override void DragEnd(InteractiveHandle target, DragEndInfo info)
        {
            if (target != ownerHandle)
                return;

            var worldToLocalRotation = transform.worldToLocalMatrix.rotation;

            if (rotationEnded != null) rotationEnded.Invoke(new RotationEndInfo(
                new RotationInfo( // World
                    m_TotalAngle,
                    0,
                    m_Normal),

                new RotationInfo(  // Local
                    m_TotalAngle,
                    0,
                    worldToLocalRotation * m_Normal)));
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.matrix =  transform.localToWorldMatrix * Matrix4x4.Scale(new Vector3(1, 1, 0));

            var color = Color.blue;
            Gizmos.color = color;
            Gizmos.DrawWireSphere(Vector3.zero, 1f);

            color.a = 0.2f;
            Gizmos.color = color;
            Gizmos.DrawSphere(Vector3.zero, 1f);
        }
    }
}

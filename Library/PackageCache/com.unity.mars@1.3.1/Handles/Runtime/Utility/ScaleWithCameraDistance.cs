using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    sealed class ScaleWithCameraDistance : HandleBehaviour
    {
        Vector3 m_InitialScale;

        void Awake()
        {
            m_InitialScale = transform.localScale;
        }

        protected override void PreRender(Camera camera)
        {
            transform.localScale = Vector3.Scale(m_InitialScale, HandleUtility.GetHandleSizeVector(transform.position));
        }

        protected override void PostRender(Camera camera)
        {
        }
    }
}

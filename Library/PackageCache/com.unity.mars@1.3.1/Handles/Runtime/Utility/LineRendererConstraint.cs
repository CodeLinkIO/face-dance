using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(LineRenderer))]
    sealed class LineRendererConstraint : MonoBehaviour
    {
        [SerializeField] Transform m_A = null;
        [SerializeField] Transform m_B = null;

        LineRenderer m_Line;
        void Awake()
        {
            m_Line = GetComponent<LineRenderer>();
            m_Line.useWorldSpace = true;
            Camera.onPreRender += PreRender;
        }

        void OnDestroy()
        {
            Camera.onPreRender -= PreRender;
        }

        void PreRender(Camera camera)
        {
            if (!m_A || !m_B)
                return;

            m_Line.SetPosition(0, m_A.position);
            m_Line.SetPosition(1, m_B.position);
        }
    }
}
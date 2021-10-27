using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data.ARFoundation
{
    class ARFoundationFaceExpressionSettings : ScriptableSettings<ARFoundationFaceExpressionSettings>
    {
        [SerializeField]
        float[] m_Thresholds;

        [SerializeField]
        float m_EventCooldownInSeconds;

        [SerializeField]
        float m_ExpressionChangeSmoothingFilter;

        public float[] thresholds
        {
            get { return m_Thresholds; }
            set { m_Thresholds = value; }
        }

        public float eventCooldownInSeconds
        {
            get => m_EventCooldownInSeconds;
            set => m_EventCooldownInSeconds = value;
        }

        public float expressionChangeSmoothingFilter
        {
            get => m_ExpressionChangeSmoothingFilter;
            set => m_ExpressionChangeSmoothingFilter = value;
        }

        public ARFoundationFaceExpressionSettings()
        {
            var length = EnumValues<MRFaceExpression>.Values.Length;

            if (m_Thresholds == null)
                m_Thresholds = new float[length];
        }
    }
}

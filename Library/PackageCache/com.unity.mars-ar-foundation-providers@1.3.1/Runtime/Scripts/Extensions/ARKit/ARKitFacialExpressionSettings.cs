using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public class ARKitFacialExpressionSettings : ScriptableSettings<ARKitFacialExpressionSettings>
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

        public ARKitFacialExpressionSettings()
        {
            var length = EnumValues<MRFaceExpression>.Values.Length;
            m_Thresholds = new float[length];
        }
    }
}

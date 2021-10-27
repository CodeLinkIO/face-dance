using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public class ARCoreFacialExpressionSettings : ScriptableSettings<ARCoreFacialExpressionSettings>
    {
        const float k_MaxHeadAngleXMin = 15f;
        const float k_MaxHeadAngleXMax = 40f;
        const float k_MaxHeadAngleYMin = 12f;
        const float k_MaxHeadAngleYMax = 25f;
        const float k_MaxHeadAngleZMin = 30f;
        const float k_MaxHeadAngleZMax = 60f;

        [SerializeField]
        float[] m_Thresholds;

        [SerializeField]
        float[] m_ExpressionDistanceMinimums;

        [SerializeField]
        float[] m_ExpressionDistanceMaximums;

        [SerializeField]
        bool[] m_ExpressionDistanceReverseStates;

        [SerializeField]
        float m_EventCooldownInSeconds;

        [SerializeField]
        float m_ExpressionChangeSmoothingFilter;

        [SerializeField]
        [Range(k_MaxHeadAngleXMin, k_MaxHeadAngleXMax)]
        float m_MaxHeadAngleX;

        [SerializeField]
        [Range(k_MaxHeadAngleYMin, k_MaxHeadAngleYMax)]
        float m_MaxHeadAngleY;

        [SerializeField]
        [Range(k_MaxHeadAngleZMin, k_MaxHeadAngleZMax)]
        float m_MaxHeadAngleZ;

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

        public float[] expressionDistanceMinimums
        {
            get { return m_ExpressionDistanceMinimums; }
            set { m_ExpressionDistanceMinimums = value; }
        }

        public float[] expressionDistanceMaximums
        {
            get { return m_ExpressionDistanceMaximums; }
            set { m_ExpressionDistanceMaximums = value; }
        }

        public float maxHeadAngleX
        {
            get { return m_MaxHeadAngleX; }
            set { m_MaxHeadAngleX = Mathf.Clamp(value, k_MaxHeadAngleXMin, k_MaxHeadAngleXMax); }
        }

        public float maxHeadAngleY
        {
            get { return m_MaxHeadAngleY; }
            set { m_MaxHeadAngleY = Mathf.Clamp(value, k_MaxHeadAngleYMin, k_MaxHeadAngleYMax); }
        }

        public float maxHeadAngleZ
        {
            get { return m_MaxHeadAngleZ; }
            set { m_MaxHeadAngleZ = Mathf.Clamp(value, k_MaxHeadAngleZMin, k_MaxHeadAngleZMax); }
        }

        public ARCoreFacialExpressionSettings()
        {
            var length = EnumValues<MRFaceExpression>.Values.Length;

            if (m_Thresholds == null)
                m_Thresholds = new float[length];

            if (m_ExpressionDistanceMinimums == null)
                m_ExpressionDistanceMinimums = new float[length];

            if (m_ExpressionDistanceMaximums == null)
                m_ExpressionDistanceMaximums = new float[length];

            if (m_ExpressionDistanceReverseStates == null)
                m_ExpressionDistanceReverseStates = new bool[length];
        }
    }
}

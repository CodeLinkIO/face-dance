using UnityEngine;

namespace Unity.MARS.Conditions
{
    public abstract class BoundedFloatRelation<T> : NonBinaryRelation<float, T>, ISpatialCondition
    {
        const float k_MinRangeWarning = 0.01f;

#if UNITY_EDITOR
        public void ScaleParameters(float scale)
        {
            m_Minimum *= scale;
            m_Maximum *= scale;
            OnRatingConfigChange();
        }

        public override void OnValidate()
        {
            base.OnValidate();

            smallMinMaxRangeWarning =
                m_MaxBounded && m_MinBounded && m_Maximum - m_Minimum < k_MinRangeWarning;
            drawWarning = noMinMaxWarning || smallMinMaxRangeWarning;

            m_Minimum = Mathf.Clamp(
                m_Minimum, Mathf.NegativeInfinity, maxBounded ? m_Maximum : Mathf.Infinity);
            m_Maximum = Mathf.Clamp(
                m_Maximum, minBounded ? m_Minimum : Mathf.NegativeInfinity, Mathf.Infinity);
        }
#endif
    }
}

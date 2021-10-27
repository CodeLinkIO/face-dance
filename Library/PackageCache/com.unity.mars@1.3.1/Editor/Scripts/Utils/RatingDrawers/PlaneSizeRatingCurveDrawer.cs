using Unity.MARS.Conditions;
using UnityEngine;

namespace Unity.MARS
{
    sealed class PlaneSizeRatingCurveDrawer : ConditionRatingCurveDrawer<PlaneSizeCondition, Vector2>
    {
        float m_StartingPoint;

        public PlaneSizeRatingCurveDrawer(PlaneSizeCondition condition)
            : base(condition, new Vector2(280, 100))
        {
            m_Condition.minimumSize = new Vector2(1f, 1f);
            m_Condition.maximumSize = new Vector2(2f, 2f);
            m_Samples = new float[m_TextureSize.x];
        }

        public override void SampleAndDraw()
        {
            var width = m_TextureSize.x;
            if (m_Samples == null)
                m_Samples = new float[width];

            var heightMinusOne = m_TextureSize.y - 1f;
            var increasePerStep = 1f / m_TextureSize.x;
            m_StartingPoint = m_Condition.minimumSize.x + increasePerStep * -10f;
            for (int i = 0; i < width; i += 1)
            {
                var distance = m_StartingPoint + i * increasePerStep;
                var rating = SampleAtPoint(distance);
                m_Samples[i] = rating;

                var yPixel = (int) Mathf.Clamp(Mathf.Floor(rating * heightMinusOne), 0f, heightMinusOne);
                var index = yPixel * width + i;

                m_Pixels[index] = Color.Lerp(k_MinimumRatingColor, m_Green, rating);
            }
        }

        public override float SampleAtPoint(float pointInDistribution)
        {
            var bounds2d = new Vector2(pointInDistribution, pointInDistribution);
            return m_Condition.RateDataMatch(ref bounds2d);

        }
    }
}

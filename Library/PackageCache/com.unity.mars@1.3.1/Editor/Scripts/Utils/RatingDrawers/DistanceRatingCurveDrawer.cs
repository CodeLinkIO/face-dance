using Unity.MARS.Conditions;
using UnityEngine;

namespace Unity.MARS
{
    class DistanceRatingCurveDrawer : RatingCurveDrawer<DistanceRelation, Pose>
    {
        Vector3 m_UnitDistancePoint;

        public DistanceRatingCurveDrawer(DistanceRelation relation) : base(relation)
        {
            m_Condition.minimum = 1f;
            m_Condition.maximum = 2f;
            m_UnitDistancePoint = Random.onUnitSphere;
        }

        protected override void SampleColumn(int widthIndex, float startPoint, float increasePerStep)
        {
            var distance = startPoint + widthIndex * increasePerStep;
            var rating = SampleAtPoint(distance);
            m_Samples[widthIndex] = rating;
            m_SamplePixelHeights[widthIndex] = YPixelForRating(rating);
        }

        public override float SampleAtPoint(float pointInRange)
        {
            var newPose = new Pose(m_UnitDistancePoint * pointInRange, Quaternion.identity);
            var identity = Pose.identity;
            return m_Condition.RateDataMatch(ref newPose, ref identity);
        }
    }
}

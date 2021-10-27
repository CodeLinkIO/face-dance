using Unity.MARS.Conditions;
using UnityEngine;

namespace Unity.MARS
{
    class ElevationRatingCurveDrawer : RatingCurveDrawer<ElevationRelation, Pose>
    {
        public ElevationRatingCurveDrawer(ElevationRelation relation) : base(relation)
        {
            m_Condition.minimum = 1f;
            m_Condition.maximum = 2f;
        }

        protected override void SampleColumn(int widthIndex, float startPoint, float increasePerStep)
        {
            var elevation = startPoint + widthIndex * increasePerStep;
            var rating = SampleAtPoint(elevation);
            m_Samples[widthIndex] = rating;
            m_SamplePixelHeights[widthIndex] = YPixelForRating(rating);
        }

        public override float SampleAtPoint(float pointInRange)
        {
            var newPose = new Pose(new Vector3(0f, 1f * pointInRange, 0f), Quaternion.identity);
            var identity = Pose.identity;
            return m_Condition.RateDataMatch(ref newPose, ref identity);
        }
    }
}

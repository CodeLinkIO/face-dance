#if UNITY_EDITOR
using UnityEngine;
using NUnit.Framework;
using Unity.MARS.Conditions;

namespace Unity.MARS.Data.Tests.ConditionMatching
{
#pragma warning disable 67
    class DistanceRelationMatchRatingTests : BoundedRelationMatchRatingTestBase<DistanceRelation, Pose>
    {
        const float k_MinDistance = 2f;
        const float k_MaxDistance = 3f;

        protected override float min { get { return k_MinDistance; }}
        protected override float max { get { return k_MaxDistance; }}

        static float Rate(DistanceRelation relation, float x, float y, float z)
        {
            var position = new Vector3(x, y, z);
            var pose = new Pose(position, Quaternion.identity);
            // to simplify things, we test all relations as if the origin pose is the 2nd child
            return relation.RateDataMatch(ref pose, ref s_IdentityPose);
        }

        static float Rate(DistanceRelation relation, float distance)
        {
            var pose = new Pose(PointAtDistance(distance), Quaternion.identity);
            return relation.RateDataMatch(ref pose, ref s_IdentityPose);
        }

        static float Rate(DistanceRelation relation, RatingConfiguration config, float distance)
        {
            relation.ratingConfig = config;
            var pose = new Pose(PointAtDistance(distance), Quaternion.identity);
            return relation.RateDataMatch(ref pose, ref s_IdentityPose);
        }

        static Vector3 PointAtDistance(float distance)
        {
            return Random.onUnitSphere * distance;
        }

        // Many of these cases are identical to those found in the elevation relation match rating tests

        // The cases here that border an edge of the ideal range have a counterpart in the test below
        [TestCase(0.25f, 0.5f, 2.5f)]        // exact average / ideal elevation
        [TestCase(0.25f, 0.5f, 2.376f)]       // almost at edge of bottom of dead zone
        [TestCase(0.25f, 0.5f, 2.624f)]       // almost at edge of top of dead zone
        [TestCase(0.1f, 0.5f, 2.5f)]        // exact average / ideal elevation
        [TestCase(0.1f, 0.5f, 2.451f)]       // almost at edge of bottom of dead zone
        [TestCase(0.1f, 0.5f, 2.549f)]       // almost at edge of top of dead zone
        [TestCase(0.5f, 0.5f, 2.5f)]        // exact average / ideal elevation
        [TestCase(0.5f, 0.5f, 2.251f)]       // almost at edge of bottom of dead zone
        [TestCase(0.5f, 0.5f, 2.749f)]       // almost at edge of top of dead zone
        public void MinAndMaxBounded_CenterPointInMiddle_PerfectMatches(float deadZone, float center, float distance)
        {
            var config = new RatingConfiguration(deadZone, center);
            Assert.AreEqual(1f, Rate(m_DoubleBoundedCondition, config, distance));
        }

        [TestCase(0.25f, 0.5f, 2.374f)]       // almost at edge of bottom of dead zone
        [TestCase(0.25f, 0.5f, 2.626f)]       // almost at edge of top of dead zone
        [TestCase(0.1f, 0.5f, 2.449f)]       // almost at edge of bottom of dead zone
        [TestCase(0.1f, 0.5f, 2.551f)]       // almost at edge of top of dead zone
        [TestCase(0.5f, 0.5f, 2.249f)]       // almost at edge of bottom of dead zone
        [TestCase(0.5f, 0.5f, 2.751f)]       // almost at edge of top of dead zone
        public void MinAndMaxBounded_CenterPointInMiddle_AlmostIdealMatches(float deadZone, float center, float distance)
        {
            var rating = Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), distance);
            Assert.GreaterOrEqual(rating, 0.99f);
            Assert.Less(rating, 1f);
        }

        // next 3 cases have a dead zone of 2.05-2.15
        [TestCase(0.1f, 0.1f, 2.1f)]          // exact middle of dead zone
        [TestCase(0.1f, 0.1f, 2.149f)]        // just inside top of dead zone
        [TestCase(0.1f, 0.1f, 2.051f)]        // just inside bottom of dead zone
        // next 3 cases have a dead zone of 2.2-2.4
        [TestCase(0.2f, 0.3f, 2.3f)]          // exact middle of dead zone
        [TestCase(0.2f, 0.3f, 2.399f)]        // just inside top of dead zone
        [TestCase(0.2f, 0.3f, 2.201f)]        // just inside bottom of dead zone
        // next 3 cases have a dead zone of 2.6-2.8
        [TestCase(0.2f, 0.7f, 2.7f)]          // exact middle of dead zone
        [TestCase(0.2f, 0.7f, 2.799f)]        // just inside top of dead zone
        [TestCase(0.2f, 0.7f, 2.601f)]        // just inside bottom of dead zone
        // next 3 cases have a dead zone of 2.85-2.95
        [TestCase(0.1f, 0.9f, 2.9f)]          // exact middle of dead zone
        [TestCase(0.1f, 0.9f, 2.949f)]        // just inside top of dead zone
        [TestCase(0.1f, 0.9f, 2.851f)]        // just inside bottom of dead zone
        public void MinAndMaxBounded_CenterPointNotInMiddle_IdealMatches(float deadZone, float center, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), y);
            Assert.AreEqual(1f, rating);
        }

        [TestCase(0.1f, 0.5f, 2.999f)]       // almost at edge of top of dead zone
        [TestCase(0.25f, 0.5f, 2.999f)]      // almost at edge of top of dead zone
        [TestCase(0.5f, 0.5f, 2.999f)]       // almost at edge of top of dead zone
        [TestCase(0.1f, 0.5f, 2.001f)]       // almost at edge of bottom of dead zone
        [TestCase(0.25f, 0.5f, 2.001f)]      // almost at edge of bottom of dead zone
        [TestCase(0.5f, 0.5f, 2.001f)]       // almost at edge of bottom of dead zone
        public void MinAndMaxBounded_CenteredPointInMiddle_RatingApproachesMinimumWhenAlmostFailing(float deadZone, float center, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), y);
            Assert.LessOrEqual(rating, MARSDatabase.MinimumPassingConditionRating + 0.025f);
            Assert.Greater(rating, MARSDatabase.MinimumPassingConditionRating);
        }

        // these next 4 cases vary the center point while keeping the rest the same
        [TestCase(0.2f, 0.2f)]
        [TestCase(0.2f, 0.3f)]
        [TestCase(0.2f, 0.7f)]
        [TestCase(0.2f, 0.8f)]
        // these next 4 cases repeat the previous ones with a smaller dead zone to confirm similar results
        [TestCase(0.1f, 0.2f)]
        [TestCase(0.1f, 0.3f)]
        [TestCase(0.1f, 0.7f)]
        [TestCase(0.1f, 0.8f)]
        // these next 6 cases use a center closer to the middle & larger dead zones
        [TestCase(0.3f, 0.4f)]
        [TestCase(0.4f, 0.4f)]
        [TestCase(0.5f, 0.4f)]
        [TestCase(0.3f, 0.6f)]
        [TestCase(0.4f, 0.6f)]
        [TestCase(0.5f, 0.6f)]
        public void MinAndMaxBounded_CenterPointNotInMiddle_RatingApproachesMinimumWhenAlmostFailing(float deadZone, float center)
        {
            var config = new RatingConfiguration(deadZone, center);
            const float deltaFromFailure = 0.002f;
            AssertApproachesMin(Rate(m_DoubleBoundedCondition, config, min + deltaFromFailure));
            AssertApproachesMin(Rate(m_DoubleBoundedCondition, config, max - deltaFromFailure));
        }

        [TestCase(1f)]            // way under min
        [TestCase(1.999f)]        // barely under min
        [TestCase(3.001f)]        // barely over max
        [TestCase(4f)]            // way over max
        public void MinAndMaxBounded_FailingCases(float distance)
        {
            Assert.AreEqual(0f, Rate(m_DoubleBoundedCondition, distance));
        }

        [TestCase(2.001f, 0f, 0f)]        // barely over min, pass
        [TestCase(0f, 2.001f, 0f)]    // barely over min, pass
        [TestCase(0f, 0f, 2.001f)]        // barely over min, pass
        [TestCase(10f, 15f, 1f)]      // way past min, pass
        [TestCase(1.8f, 1.8f, 1.8f)]
        public void OnlyMinBounded_PassingCases(float x, float y, float z)
        {
            Assert.AreEqual(1f, Rate(m_OnlyMinBoundedCondition, x, y, z));
        }

        [TestCase(1.999f, 0f, 0f)]
        [TestCase(0f, 1.999f, 0f)]
        [TestCase(0f, 0f, 1.999f)]
        [TestCase(0.1f, 0.1f, 0.1f)]
        [TestCase(0.5f, 0.5f, 0.5f)]
        public void OnlyMinBounded_FailingCases(float x, float y, float z)
        {
            Assert.AreEqual(0f, Rate(m_OnlyMinBoundedCondition, x, y, z));
        }

        [TestCase(2.001f, 0f, 0f)]        // barely over min, pass
        [TestCase(0f, 2.001f, 0f)]    // barely over min, pass
        [TestCase(0f, 0f, 2.001f)]        // barely over min, pass
        [TestCase(1.5f, 1.5f, 1.5f)]
        public void OnlyMaxBounded_PassingCases(float x, float y, float z)
        {
            Assert.AreEqual(1f, Rate(m_OnlyMaxBoundedCondition, x, y, z));
        }

        [TestCase(3.001f, 0f, 0f)]
        [TestCase(0f, 3.001f, 0f)]
        [TestCase(0f, 0f, 3.001f)]
        [TestCase(2.5f, 2.5f, 2.5f)]
        public void OnlyMaxBounded_FailingCases(float x, float y, float z)
        {
            Assert.AreEqual(0f, Rate(m_OnlyMaxBoundedCondition, x, y, z));
        }

        [TestCase(30f, 0f, 0f)]
        [TestCase(-10f, 10f, 10f)]
        [TestCase(0.1f, 0.1f, 0.1f)]
        public void NotBounded_AlwaysPasses(float x, float y, float z)
        {
            Assert.AreEqual(1f, Rate(m_NotBoundedCondition, x, y, z));
        }
    }
#pragma warning restore 67
}
#endif

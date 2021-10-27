#if UNITY_EDITOR
using UnityEngine;
using NUnit.Framework;
using Unity.MARS.Conditions;

namespace Unity.MARS.Data.Tests.ConditionMatching
{
#pragma warning disable 67
    class ElevationRelationMatchRatingTests : BoundedRelationMatchRatingTestBase<ElevationRelation, Pose>
    {
        const float k_MinElevation = 2f;
        const float k_MaxElevation = 3f;

        protected override float min { get { return k_MinElevation; }}
        protected override float max { get { return k_MaxElevation; }}

        static float Rate(ElevationRelation relation, float elevation)
        {
            var pose = new Pose(new Vector3(0, elevation, 0), Quaternion.identity);
            // to simplify things, we test all relations as if the origin pose is the 2nd child
            return relation.RateDataMatch(ref pose, ref s_IdentityPose);
        }

        static float Rate(ElevationRelation relation, RatingConfiguration config, float elevation)
        {
            var pose = new Pose(new Vector3(0, elevation, 0), Quaternion.identity);
            relation.ratingConfig = config;
            return relation.RateDataMatch(ref pose, ref s_IdentityPose);
        }

        static float Rate(ElevationRelation relation, RatingConfiguration config,
            float child1Elevation, float child2Elevation)
        {
            var pose1 = new Pose(new Vector3(0, child1Elevation, 0), Quaternion.identity);
            var pose2 = new Pose(new Vector3(0, child2Elevation, 0), Quaternion.identity);
            relation.ratingConfig = config;
            return relation.RateDataMatch(ref pose1, ref pose2);
        }

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
        public void MinAndMaxBounded_CenterPointInMiddle_PerfectMatches(float deadZone, float center, float y)
        {
            Assert.AreEqual(1f, Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), y));
        }

        [TestCase(0.25f, 0.5f, 2.374f)]       // almost at edge of bottom of dead zone
        [TestCase(0.25f, 0.5f, 2.626f)]       // almost at edge of top of dead zone
        [TestCase(0.1f, 0.5f, 2.449f)]       // almost at edge of bottom of dead zone
        [TestCase(0.1f, 0.5f, 2.551f)]       // almost at edge of top of dead zone
        [TestCase(0.5f, 0.5f, 2.249f)]       // almost at edge of bottom of dead zone
        [TestCase(0.5f, 0.5f, 2.751f)]       // almost at edge of top of dead zone
        public void MinAndMaxBounded_CenterPointInMiddle_AlmostIdealMatches(float deadZone, float center, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), y);
            Assert.GreaterOrEqual(rating, 0.99f);
            Assert.Less(rating, 1f);
        }

        // the next two test cases complement each other - one covers matches inside the dead zone , one just outside

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

        // next 2 cases have a dead zone of 2.05-2.15
        [TestCase(0.1f, 0.1f, 2.152f)]        // just outside top of dead zone
        [TestCase(0.1f, 0.1f, 2.048f)]        // just outside bottom of dead zone
        // next 2 cases have a dead zone of 2.2-2.4
        [TestCase(0.2f, 0.3f, 2.402f)]        // just outside top of dead zone
        [TestCase(0.2f, 0.3f, 2.198f)]        // just outside bottom of dead zone
        // next 2 cases have a dead zone of 2.6-2.8
        [TestCase(0.2f, 0.7f, 2.802f)]        // just outside top of dead zone
        [TestCase(0.2f, 0.7f, 2.598f)]        // just outside bottom of dead zone
        // next 2 cases have a dead zone of 2.85-2.95
        [TestCase(0.1f, 0.9f, 2.952f)]        // just outside top of dead zone
        [TestCase(0.1f, 0.9f, 2.848f)]        // just outside bottom of dead zone
        public void MinAndMaxBounded_CenterPointNotInMiddle_RatingApproachesOneWhenNearIdeal(float deadZone, float center, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), y);
            Assert.GreaterOrEqual(rating, 0.99f);
            Assert.Less(rating, 1f);
        }

        // vary the dead zone while keeping the rest about this case the same,
        // to make sure dead zone doesn't affect the near-failing ratings much
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
            AssertApproachesMin(Rate(m_DoubleBoundedCondition, config, k_MinElevation + deltaFromFailure));
            AssertApproachesMin(Rate(m_DoubleBoundedCondition, config, k_MaxElevation - deltaFromFailure));
        }

        // These test for a case that failed in the original implementation:
        // when the center point was not in the middle, interpolated values would be calculated as if it was,
        // resulting in cases that should fail having a passing rating
        [TestCase(0.2f, 0.1f, 1.999f)]        // just outside bottom of range, dead zone: 0.2-0.4
        [TestCase(0.2f, 0.3f, 1.999f)]        // just outside bottom of range, dead zone: 0.2-0.4
        [TestCase(0.2f, 0.7f, 3.001f)]        // just outside top of range, dead zone: 0.6-0.8
        [TestCase(0.2f, 0.9f, 3.001f)]        // just outside top of range, dead zone: 0.6-0.8
        public void MinAndMaxBounded_OffCenterFailureCases(float deadZone, float center, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, new RatingConfiguration(deadZone, center), y);
            Assert.AreEqual(0f, rating);
        }

        // these test cases are to make sure that comparing against origin doesn't cause false positive in other tests
        [TestCase(0.5f, 3.5f, 1f)]       // diff of 2.5, totally ideal
        [TestCase(0.8f, 3.8f, 1f)]       // diff of 2.8, totally ideal
        [TestCase(0.2f, 3.2f, 1f)]       // diff of 2.2, totally ideal
        // use a negative elevation for some children to make sure signs don't affect the calculation
        [TestCase(0.5f, 1.5f, -1f)]       // diff of 2.5, totally ideal
        [TestCase(0.8f, 1.8f, -1f)]       // diff of 2.8, totally ideal
        [TestCase(0.2f, 1.2f, -1f)]       // diff of 2.2, totally ideal
        public void MinAndMaxBounded_NonZeroComparison_PerfectMatches(float center,
            float child1Elevation, float child2Elevation)
        {
            var config = new RatingConfiguration(0.25f, center);
            var rating = Rate(m_DoubleBoundedCondition, config, child1Elevation, child2Elevation);
            Assert.AreEqual(1f, rating);
        }

        [TestCase(3.001f)]    // over max
        [TestCase(1.999f)]       // under min
        public void MinAndMaxBounded_FailingCases(float y)
        {
            Assert.AreEqual(0f, Rate(m_DoubleBoundedCondition, y));
        }

        [TestCase(2.001f)]    // barely over min
        [TestCase(15f)]      // way past min
        public void OnlyMinBounded_PassingCases(float y)
        {
            Assert.AreEqual(1f, Rate(m_OnlyMinBoundedCondition, y));
        }

        [TestCase(1.999f)]     // very close to min
        [TestCase(0.1f)]       // far from min
        public void OnlyMinBounded_FailingCases(float y)
        {
            Assert.AreEqual(0f, Rate(m_OnlyMinBoundedCondition, y));
        }

        [TestCase(2.999f)]    // very close to max
        [TestCase(0.5f)]      // far under max
        public void OnlyMaxBounded_PassingCases(float y)
        {
            Assert.AreEqual(1f, Rate(m_OnlyMaxBoundedCondition, y));
        }

        [TestCase(3.001f)]    // just over max
        [TestCase(30f)]        // far over max
        public void OnlyMaxBounded_FailingCases(float y)
        {
            Assert.AreEqual(0f, Rate(m_OnlyMaxBoundedCondition, y));
        }

        [TestCase(10f)]
        [TestCase(0.1f)]
        public void NotBounded_AlwaysPasses(float y)
        {
            Assert.AreEqual(1f, Rate(m_NotBoundedCondition, y));
        }
    }
#pragma warning restore 67
}
#endif

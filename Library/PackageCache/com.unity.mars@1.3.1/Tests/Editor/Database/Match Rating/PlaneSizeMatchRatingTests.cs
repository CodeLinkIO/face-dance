#if UNITY_EDITOR
using UnityEngine;
using NUnit.Framework;
using Unity.MARS.Conditions;
using Unity.MARS.MARSUtils;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests.ConditionMatching
{
#pragma warning disable 67
    class PlaneSizeMatchRatingTests
    {
        const float k_PlaneSizeRatingTolerance = 0.005f;
        const float k_MinimumRatingPassingThreshold = MARSDatabase.MinimumPassingConditionRating + 0.02f;

        // the "ideal range" for this condition, with the default %25 value for the dead zone
        // x: 1.375 - 1.625, y: 2.0625 - 2.4375
        static readonly Vector2 k_MinPlaneSize = new Vector2(1f, 1.5f);
        static readonly Vector2 k_MaxPlaneSize = new Vector2(2f, 3f);

        PlaneSizeCondition m_DoubleBoundedCondition;
        PlaneSizeCondition m_OnlyMinBoundedCondition;
        PlaneSizeCondition m_OnlyMaxBoundedCondition;

        [OneTimeSetUp]
        public void Setup()
        {
            m_DoubleBoundedCondition = new GameObject("double bounded").AddComponent<PlaneSizeCondition>();
            m_DoubleBoundedCondition.minBounded = true;
            m_DoubleBoundedCondition.maxBounded = true;

            m_OnlyMinBoundedCondition = new GameObject("only min bounded").AddComponent<PlaneSizeCondition>();
            m_OnlyMinBoundedCondition.ratingConfig = new RatingConfiguration(0.25f);
            m_OnlyMinBoundedCondition.minimumSize = k_MinPlaneSize;
            m_OnlyMinBoundedCondition.minBounded = true;
            m_OnlyMinBoundedCondition.maxBounded = false;

            m_OnlyMaxBoundedCondition = new GameObject("only max bounded").AddComponent<PlaneSizeCondition>();
            m_OnlyMaxBoundedCondition.ratingConfig = new RatingConfiguration(0.25f);
            m_OnlyMaxBoundedCondition.maximumSize = k_MaxPlaneSize;
            m_OnlyMaxBoundedCondition.minBounded = false;
            m_OnlyMaxBoundedCondition.maxBounded = true;
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            var gameObjects = UnityObject.FindObjectsOfType<GameObject>();
            foreach (var go in gameObjects)
            {
                if (go == null)
                    continue;

                if(go.GetComponent<PlaneSizeCondition>() != null)
                    UnityObject.DestroyImmediate(go);
            }
        }

        [SetUp]
        public void BeforeEach()
        {
            SlowTaskModule.instance.ClearTasks();
            m_DoubleBoundedCondition.ratingConfig = new RatingConfiguration(0.25f);
            m_DoubleBoundedCondition.minimumSize = k_MinPlaneSize;
            m_DoubleBoundedCondition.maximumSize = k_MaxPlaneSize;
        }

        static float Rate(PlaneSizeCondition condition, float inputX, float inputY)
        {
            var input = new Vector2(inputX, inputY);
            return condition.RateDataMatch(ref input);
        }

        [TestCase(1.1f, 1.1f)]
        [TestCase(1.5f, 3f)]
        [TestCase(0.9f, 2.3f)]
        [TestCase(2.1f, 2.2f)]
        // this tests the checks near the beginning that eliminate impossible data
        public void DataInvalidOnAnyAxisFails(float x, float y)
        {
            m_DoubleBoundedCondition.minimumSize = new Vector2(1, 2f);
            m_DoubleBoundedCondition.maximumSize = new Vector2(2, 2.5f);
            Assert.Zero(Rate(m_DoubleBoundedCondition, x, y));
        }

        [TestCase(1.4f, 2.15f)]
        [TestCase(2.15f, 1.4f)]        // fails before flipping, but an ideal match when flipped
        [TestCase(1.6f, 2.3f)]
        public void MinAndMaxBounded_WithinIdealRangeHasPerfectRating(float x, float y)
        {
            Assert.AreEqual(1f, Rate(m_DoubleBoundedCondition, x, y), k_PlaneSizeRatingTolerance);
        }

        [TestCase(0.5f, 1.2f)]
        [TestCase(2.5f, 3.5f)]
        public void MinAndMaxBounded_OutsideRangeHasZeroRating(float x, float y)
        {
            Assert.AreEqual(0f, Rate(m_DoubleBoundedCondition, x, y), k_PlaneSizeRatingTolerance);
        }

        [TestCase(1.35f, 2.45f, 0.958f)]
        [TestCase(1.3f, 2.5f, 0.852f)]        // just a sampling of points along the curve.
        [TestCase(1.2f, 2.65f, 0.6f)]        // these should decrease in match rating as
        [TestCase(1.15f, 2.7f, 0.493f)]     // they get further from the ideal range's edge
        [TestCase(1.1f, 2.75f, 0.387f)]
        [TestCase(1.05f, 2.9f, 0.2f)]
        public void MinAndMaxBounded_WithinToleranceHasVariableRating(float x, float y, float expected)
        {
            Assert.AreEqual(expected, Rate(m_DoubleBoundedCondition, x, y), k_PlaneSizeRatingTolerance);
        }

        [TestCase(1.37f, 2.25f)]   // ideal y, with x barely outside bottom of ideal range
        [TestCase(1.63f, 2.25f)]   // ideal y, with x barely outside top of ideal range
        [TestCase(1.5f, 2.06f)]   // ideal x, with y barely outside bottom of ideal range
        [TestCase(1.5f, 2.44f)]   // ideal x, with y barely outside top of ideal range
        public void MinAndMaxBounded_CloseToIdealRatingNearsOne(float x, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.GreaterOrEqual(rating, 0.98f);
            Assert.Less(rating, 1f);
        }

        [TestCase(1.001f, 1.501f)]    // x & y near minimum
        [TestCase(1.001f, 2.999f)]    // x near min, y near max
        [TestCase(1.999f, 2.999f)]    // x & y near maximum
        public void MinAndMaxBounded_CloseToFailureRatingNearsMinimum(float x, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.LessOrEqual(rating, k_MinimumRatingPassingThreshold);
            Assert.Greater(rating, MARSDatabase.MinimumPassingConditionRating);
        }

        [TestCase(1.001f, 2.25f)]    // x near min, y ideal
        [TestCase(1.999f, 2.25f)]    // x near max, y ideal
        [TestCase(1.5f, 2.999f)]    // x ideal, y near max
        [TestCase(1.5f, 1.501f)]    // x ideal, y near min
        public void MinAndMaxBounded_OneIdealOneBarelyMatches(float x, float y)
        {
            var rating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.LessOrEqual(rating, 0.53f);
            Assert.Greater(rating, 0.5f);
        }

        [TestCase(1.35f, 2.45f)]       // x & y outside initial ideal range, but then inside
        [TestCase(1.25f, 2.55f)]
        public void MinAndMaxBounded_GrowingDeadZone(float x, float y)
        {
            var initalRating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.Less(initalRating, 1f);
            Assert.Greater(initalRating, 0.5f);

            m_DoubleBoundedCondition.ratingConfig = new RatingConfiguration(0.5f);
            var newRating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.AreEqual(1f, newRating);
        }

        [TestCase(1.45f, 2.4f)]       // x & y inside initial ideal range, but then outside
        [TestCase(1.4f, 2.35f)]
        public void MinAndMaxBounded_ShrinkingDeadZone(float x, float y)
        {
            var initialRating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.AreEqual(initialRating, 1f);

            m_DoubleBoundedCondition.ratingConfig = new RatingConfiguration(0.05f);
            var newRating = Rate(m_DoubleBoundedCondition, x, y);
            Assert.Less(newRating, 1f);
            Assert.Greater(newRating, 0.1f);
        }

        [TestCase(1.001f, 1.501f, 1f)]        // barely over min, pass
        [TestCase(10f, 15f, 1f)]              // x & y very far over min, pass
        [TestCase(2f, 1.2f, 1f)]              // y is under min, but flipping brings x & y over min, pass
        [TestCase(0.1f, 0.2f, 0f)]            // x & y far under min, even when flipped, fail
        [TestCase(0.999f, 2f, 0f)]            // x is under min & flipping would have y under min, fail
        [TestCase(2f, 0.5f, 0f)]              // y is under min & flipping would have x under min, fail
        public void OnlyMinBounded_RatingsAreOnlyPassOrFail(float x, float y, float expected)
        {
            Assert.AreEqual(expected, Rate(m_OnlyMinBoundedCondition, x, y));
        }

        [TestCase(1.999f, 2.999f, 1f)]        // x & y barely under max, pass
        [TestCase(2.999f, 1.999f, 1f)]        // x is over max, but flipping brings both in range (see previous), pass
        [TestCase(2.1f, 2.5f, 0f)]            // x is over max, even when flipped, fail
        [TestCase(10f, 15f, 0f)]              // x & y far over max, even when flipped, fail
        public void OnlyMaxBounded_RatingsAreOnlyPassOrFail(float x, float y, float expected)
        {
            Assert.AreEqual(expected, Rate(m_OnlyMaxBoundedCondition, x, y));
        }

        // TODO - unit test for altering dead zone
    }
#pragma warning restore 67
}
#endif

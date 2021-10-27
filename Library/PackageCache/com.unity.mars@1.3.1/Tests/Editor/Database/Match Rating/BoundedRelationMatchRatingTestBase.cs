using NUnit.Framework;
using Unity.MARS.Conditions;
using Unity.MARS.MARSUtils;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests.ConditionMatching
{
    class BoundedRelationMatchRatingTestBase<TRelation, TData>
        where TRelation : NonBinaryRelation<float, TData>, IRangeBoundingOptions<float>
    {
        protected static Pose s_IdentityPose = Pose.identity;

        GameObject m_CameraObject;

        protected TRelation m_DoubleBoundedCondition;
        protected TRelation m_OnlyMinBoundedCondition;
        protected TRelation m_OnlyMaxBoundedCondition;
        protected TRelation m_NotBoundedCondition;

        protected virtual float min { get; set; }
        protected virtual float max { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            QuerySimulationModule.TestMode = true;
            m_CameraObject = new GameObject("relation rating test camera");

            m_DoubleBoundedCondition = new GameObject("double bounded").AddComponent<TRelation>();
            m_DoubleBoundedCondition.minimum = min;
            m_DoubleBoundedCondition.maximum = max;

            m_OnlyMinBoundedCondition = new GameObject("only min bounded").AddComponent<TRelation>();
            m_OnlyMinBoundedCondition.minimum = min;
            m_OnlyMinBoundedCondition.maxBounded = false;

            m_OnlyMaxBoundedCondition = new GameObject("only max bounded").AddComponent<TRelation>();
            m_OnlyMaxBoundedCondition.maximum = max;
            m_OnlyMaxBoundedCondition.minBounded = false;

            m_NotBoundedCondition = new GameObject("not bounded").AddComponent<TRelation>();
            m_NotBoundedCondition.minBounded = false;
            m_NotBoundedCondition.maxBounded = false;
        }

        [SetUp]
        public void SetupBeforeEach()
        {
            // make sure the usual scene evaluation slow tasks can't be hanging around during tests.
            // This is sort of overkill to do it every test, but it was causing test failures
            SlowTaskModule.instance.ClearTasks();
            m_DoubleBoundedCondition.ratingConfig = new RatingConfiguration(0.25f);

            // Ensure a consistent random seed for all test runs
            Random.InitState(0);
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            UnityObject.DestroyImmediate(m_CameraObject);

            var gameObjects = UnityObject.FindObjectsOfType<GameObject>();
            foreach (var go in gameObjects)
            {
                if (go == null)
                    continue;

                if(go.GetComponent<TRelation>() != null)
                    UnityObject.DestroyImmediate(go);
            }

            QuerySimulationModule.TestMode = false;
        }

        protected void AssertApproachesMin(float rating)
        {
            Assert.LessOrEqual(rating, MARSDatabase.MinimumPassingConditionRating + 0.025f);
            Assert.Greater(rating, MARSDatabase.MinimumPassingConditionRating);
        }
    }
}

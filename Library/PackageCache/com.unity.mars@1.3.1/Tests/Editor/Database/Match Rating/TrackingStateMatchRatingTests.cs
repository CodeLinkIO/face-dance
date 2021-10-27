#if UNITY_EDITOR
using UnityEngine;
using NUnit.Framework;
using Unity.MARS.Conditions;

namespace Unity.MARS.Data.Tests.ConditionMatching
{
    class MARSTrackingStateConditionMatchRatingTests
    {
        GameObject m_GameObject;
        TrackingStateCondition m_Condition;

        [OneTimeSetUp]
        public void Setup()
        {
            m_GameObject = new GameObject("tracking state condition tests");
            m_Condition = m_GameObject.AddComponent<TrackingStateCondition>();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_GameObject);
        }

        [TestCase(MARSTrackingState.Unknown, MARSTrackingState.Tracking, 1f)]
        [TestCase(MARSTrackingState.Unknown, MARSTrackingState.Limited, 1f)]
        [TestCase(MARSTrackingState.Unknown, MARSTrackingState.Unknown, 1f)]
        [TestCase(MARSTrackingState.Limited, MARSTrackingState.Tracking, 1f)]
        [TestCase(MARSTrackingState.Limited, MARSTrackingState.Limited, 1f)]
        [TestCase(MARSTrackingState.Limited, MARSTrackingState.Unknown, 0f)]
        [TestCase(MARSTrackingState.Tracking, MARSTrackingState.Tracking, 1f)]
        [TestCase(MARSTrackingState.Tracking, MARSTrackingState.Limited, 0f)]
        [TestCase(MARSTrackingState.Tracking, MARSTrackingState.Unknown, 0f)]
        public void UnMatchesWhenBelowMinimumQuality(MARSTrackingState minimum, MARSTrackingState state, float expectedRating)
        {
            m_Condition.MinimumState = minimum;
            var traitValue = (int) state;
            Assert.AreEqual(m_Condition.RateDataMatch(ref traitValue), expectedRating);
        }
    }
}
#endif

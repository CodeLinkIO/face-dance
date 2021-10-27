using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Unity.MARS.Query;

namespace Unity.MARS.Data.Tests
{
    class MatchIntersectionTests
    {
        GameObject m_TestObject;

        [OneTimeSetUp]
        public void Setup()
        {
            MARSSession.TestMode = true;
            m_TestObject = new GameObject("Match intersection tests");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(m_TestObject);
            MARSSession.TestMode = false;
        }

        [Test]
        public void ExcludedTagsNotUsedAsIntersectionStartingPoint()
        {
            var tagConditions = new ISemanticTagCondition[2];
            tagConditions[0] = m_TestObject.AddSemanticTagCondition("exclude", SemanticTagMatchRule.Exclude);
            tagConditions[1] = m_TestObject.AddSemanticTagCondition("match");

            var conditions = new ProxyConditions(tagConditions);
            var ratings = new ConditionRatingsData(conditions)
            {
                MatchRuleIndexes = { SemanticTagMatchRule.Exclude, SemanticTagMatchRule.Match }
            };

            // fake like we rated conditions
            var excludeRuleSet = new []{ 0, 1 };
            var excludeRuleRatings = ratings[typeof(bool)][0];
            foreach (var t in excludeRuleSet)
            {
                excludeRuleRatings.Add(t, 1);
            }

            var matchRuleSet = new []{ 2, 3, 4 };
            var matchRuleRatings = ratings[typeof(bool)][1];
            foreach (var t in matchRuleSet)
            {
                matchRuleRatings.Add(t, 1);
            }

            var matchSet = new HashSet<int>();
            FindMatchProposalsTransform.GetStartingIdSet(ratings, matchSet);

            // because we can't use the excluding tag ratings as the starting set for intersection,
            // it should skip them & use another set, even though they come first in the ratings in our setup
            Assert.True(matchSet.SetEquals(matchRuleSet));
        }
    }
}

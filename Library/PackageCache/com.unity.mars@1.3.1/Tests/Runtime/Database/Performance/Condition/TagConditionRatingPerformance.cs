#if UNITY_EDITOR
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class TagConditionRatingPerformance : TimedConditionPerformanceTest<SemanticTagCondition, bool>
    {
        public virtual SemanticTagMatchRule matchRule { get; set; }

        public void Start()
        {
            Random.InitState(0);
            m_Condition.matchRule = matchRule;
            for (int i = 0; i < s_DataCount; i++)
            {
                m_DataToCompare[i] = Random.Range(0f, 1f) > 0.5f;
            }
        }
    }

    class TagConditionInclusiveMatchRatingPerformance : TagConditionRatingPerformance
    {
        public override SemanticTagMatchRule matchRule { get { return SemanticTagMatchRule.Match; } }
    }

    class TagConditionExclusiveMatchRatingPerformance : TagConditionRatingPerformance
    {
        public override SemanticTagMatchRule matchRule { get { return SemanticTagMatchRule.Exclude; } }
    }
}
#endif

#if UNITY_EDITOR
using Unity.MARS.Conditions;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class AlignmentConditionRatingPerformance : TimedConditionPerformanceTest<AlignmentCondition, int>
    {
        public void Start()
        {
            for (var i = 0; i < s_DataCount; i++)
            {
                m_DataToCompare[i] = (int) RandomAlignment();
            }
        }

        protected override void Update()
        {
            m_Condition.alignment = RandomAlignment();
            RunTestIteration();
        }

        static MarsPlaneAlignment RandomAlignment()
        {
            var randomRange = Random.Range(0f, 1f);

            if (randomRange > 0.66f)
                return MarsPlaneAlignment.HorizontalUp;

            if (randomRange > 0.33f)
                return MarsPlaneAlignment.Vertical;

            return MarsPlaneAlignment.HorizontalDown;
        }
    }
}
#endif

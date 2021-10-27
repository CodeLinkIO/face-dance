#if UNITY_EDITOR
using Unity.MARS.Conditions;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class DistanceRatingPerformance : TimedRelationPerformanceTest<DistanceRelation, Pose>
    {
        public void Start()
        {
            m_Relation.maximum = 3f;
            m_Relation.minimum = 1f;

            for (int i = 0; i < s_DataCount; i++)
            {
                var position = Random.insideUnitSphere * 5f;
                m_DataToCompare[i] = new Pose(position, Quaternion.identity);
            }
        }

        protected override void Update()
        {
            var newPosition = Random.insideUnitSphere * 4f;
            RunTestIteration(new Pose(newPosition, Quaternion.identity));
        }
    }
}
#endif

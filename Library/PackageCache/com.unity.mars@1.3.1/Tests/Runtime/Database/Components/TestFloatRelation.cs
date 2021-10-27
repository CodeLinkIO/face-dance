using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class TestFloatRelation : TestRelation<float, float>
    {
        public override float RateDataMatch(ref float child1Data, ref float child2Data)
        {
            var value = (child1Data + child2Data) * 0.1f;
            return value > 1f ? 0f : value;
        }
    }

}

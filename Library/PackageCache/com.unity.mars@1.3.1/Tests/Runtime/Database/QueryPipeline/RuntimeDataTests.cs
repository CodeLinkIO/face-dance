#if UNITY_EDITOR
using System.Collections;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    class RuntimeDataTests
    {
        [UnityTest]
        public IEnumerator TraitDataBuffering()
        {
            yield return new MonoBehaviourTest<TraitDataBufferingTest>();
        }
    }
}
#endif

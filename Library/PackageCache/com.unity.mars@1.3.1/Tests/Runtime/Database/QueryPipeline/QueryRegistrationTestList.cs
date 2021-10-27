#if UNITY_EDITOR
using System.Collections;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    class QueryRegistrationTestList
    {
        [UnityTest]
        public IEnumerator QueryRegistration()
        {
            yield return new MonoBehaviourTest<QueryRegistrationTest>();
        }
    }
}
#endif

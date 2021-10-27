#if UNITY_EDITOR
using System.Collections;
using Unity.MARS.Tests;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    class RuntimeQueryTestList
    {
        [UnityTest]
        public IEnumerator ProxyGroupAndMemberProxies_HaveSameQueryID_AfterInitialization()
        {
            yield return new MonoBehaviourTest<GroupMatchIdsAreConsistentTest>();
        }

        [UnityTest]
        public IEnumerator NonRequiredChildrenLoss()
        {
            yield return new MonoBehaviourTest<NonRequiredChildrenPartialLossTest>();
        }

        [UnityTest]
        public IEnumerator AllChildrenNonRequired_LosingAllData_TriggersGroupLoss_WithoutReacquire()
        {
            yield return new MonoBehaviourTest<AllChildrenNonRequiredDataLossTest>();
        }

        [UnityTest]
        public IEnumerator AllChildrenNonRequired_LosingAllData_TriggersGroupLoss_AndReacquire()
        {
            var test = new MonoBehaviourTest<AllChildrenNonRequiredDataLossTest>();
            test.component.ReAcquireOnLoss = true;
            yield return test;
        }

        [UnityTest]
        public IEnumerator UnsetStandaloneMatch()
        {
            yield return new MonoBehaviourTest<StandaloneQueryUnMatchingTest>();
        }

        [UnityTest]
        public IEnumerator StandaloneProxyManualMatchAssignment()
        {
            yield return new MonoBehaviourTest<StandaloneQueryManualMatchAssignmentTest>();
        }

        [UnityTest]
        public IEnumerator UnsetGroupMatch()
        {
            yield return new MonoBehaviourTest<GroupQueryUnMatchingTest>();
        }

        [UnityTest]
        public IEnumerator UnmatchRequiredGroupMember()
        {
            yield return new MonoBehaviourTest<RequiredGroupMemberUnMatchingTest>();
        }

        [UnityTest]
        public IEnumerator UnmatchNonRequiredGroupMember()
        {
            yield return new MonoBehaviourTest<NonRequiredGroupMemberUnMatchingTest>();
        }

        [UnityTest]
        public IEnumerator StandaloneSpawnerUnMatching()
        {
            yield return new MonoBehaviourTest<StandaloneReplicatorUnMatchingTest>();
        }
    }
}
#endif

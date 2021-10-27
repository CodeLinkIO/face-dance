#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class NonRequiredChildrenPartialLossTest : ProxyGroupRuntimeTest
    {
        public void Start()
        {
            m_FrameCount = 5;
            TestPrefab = QueryTestObjectSettings.instance.NonRequiredChildrenSet;
            Initialize();
        }

        protected override void OnMarsUpdate()
        {
            switch (frameCount)
            {
                case 1:
                {
                    AssertValidInitialState();
                    // this data is what the proxies in the prefab need to match
                    this.AddOrUpdateTrait(k_Member1DataId, TraitNames.Floor, true);
                    DatabaseUtils.AddPlane(k_Member1DataId);
                    DatabaseUtils.AddPlane(k_Member2DataId);
                    ForceUpdateQueries();
                    break;
                }
                case 2:
                    AssertValidTrackingState();
                    break;
                case 3:
                    // this should cause our non-required floor to be lost
                    this.RemoveTrait<bool>(k_Member1DataId, TraitNames.Floor);
                    ForceUpdateQueries();
                    break;
                case 4:
                    // the group should still be 'tracking' despite losing the non-required child
                    Assert.AreEqual(QueryState.Tracking, m_ProxyGroup.queryState);
                    Assert.AreEqual(QueryState.Tracking, m_ChildProxy1.queryState);
                    Assert.AreEqual(QueryState.Unavailable, m_ChildProxy2.queryState);
                    Assert.True(m_Child1ContentObject.activeInHierarchy);
                    Assert.False(m_Child2ContentObject.activeInHierarchy);
                    break;
            }
        }
    }
}
#endif

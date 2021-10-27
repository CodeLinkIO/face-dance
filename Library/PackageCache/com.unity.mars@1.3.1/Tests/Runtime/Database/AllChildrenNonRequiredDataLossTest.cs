#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Tests the behavior of a ProxyGroup with only non-required children when it loses all of its data
    /// </summary>
    [AddComponentMenu("")]
    class AllChildrenNonRequiredDataLossTest : ProxyGroupRuntimeTest
    {
        MARSDatabase m_Database;

        public void Start()
        {
            m_FrameCount = 10;
            // the difference between these prefabs is only that the group is set to re-acquire on the latter
            TestPrefab = ReAcquireOnLoss
                ? QueryTestObjectSettings.instance.AllNonRequiredChildrenReacquireGroup
                : QueryTestObjectSettings.instance.AllNonRequiredChildrenGroup;


            m_Database = ModuleLoaderCore.instance.GetModule<MARSDatabase>();
            Initialize();
        }

        protected override void OnMarsUpdate()
        {
            switch (frameCount)
            {
                case 1:
                    AssertValidInitialState();
                    break;
                case 2:
                {
                    // this data is what the proxies in the prefab need to match
                    DatabaseUtils.AddPlane(k_Member1DataId);
                    DatabaseUtils.AddPlane(k_Member2DataId);
                    ForceUpdateQueries();
                    break;
                }
                case 3:
                    AssertValidTrackingState();
                    AssertGroupQueryDataUseTracked(m_ProxyGroup.queryID);
                    break;
                case 4:
                    DatabaseUtils.RemovePlane(k_Member1DataId);
                    ForceUpdateQueries();
                    break;
                case 5:
                    Assert.AreEqual(QueryState.Tracking, m_ProxyGroup.queryState);
                    Assert.AreEqual(QueryState.Tracking, m_ChildProxy2.queryState);
                    Assert.True(m_Child2ContentObject.activeInHierarchy);

                    // since this child has been lost its data it should be unavailable
                    Assert.AreEqual(QueryState. Unavailable, m_ChildProxy1.queryState);
                    Assert.Null(m_ChildProxy1.currentData);
                    Assert.False(m_Child1ContentObject.activeInHierarchy);

                    // make sure the backend is still tracking this group's data despite partial loss
                    AssertGroupQueryDataUseTracked(m_ProxyGroup.queryID);
                    break;
                case 6:
                    // removing this plane should cause the second member to be lost,
                    // causing the group to be lost because all members have now lost their data
                    DatabaseUtils.RemovePlane(k_Member2DataId);
                    break;
                case 7:
                    Assert.AreEqual(ReAcquireOnLoss ? QueryState.Resuming : QueryState.Unavailable, m_ProxyGroup.queryState);
                    QueryAssertUtils.QueryStateIs(QueryState.Unavailable, m_ChildProxy1, m_ChildProxy2);
                    QueryAssertUtils.AssignedDataIsNull(m_ChildProxy1, m_ChildProxy2);
                    QueryAssertUtils.ActiveInHierarchy(false, m_Child1ContentObject, m_Child2ContentObject);

                    AssertGroupQueryDataUseTracked(m_ProxyGroup.queryID, false);
                    break;
                case 8:
                    // re-add the data we need to match, to test reacquire behavior
                    DatabaseUtils.AddPlane(k_Member1DataId);
                    DatabaseUtils.AddPlane(k_Member2DataId);
                    ForceUpdateQueries();
                    break;
                case 9:
                    if (ReAcquireOnLoss)
                    {
                        AssertValidTrackingState();
                        AssertGroupQueryDataUseTracked(m_ProxyGroup.queryID, true);
                    }
                    else
                    {
                        QueryAssertUtils.AssignedDataIsNull(m_ChildProxy1, m_ChildProxy2);
                        QueryAssertUtils.QueryStateIs(QueryState.Unavailable, m_ProxyGroup);
                        QueryAssertUtils.ActiveInHierarchy(false, m_Child1ContentObject, m_Child2ContentObject);
                        AssertGroupQueryDataUseTracked(m_ProxyGroup.queryID, false);
                    }
                    break;
            }
        }

        // Track some internal data ownership state along with the client-level changes.
        // Intended to test a specific issue where empty sets were hanging around in 'SetDataUsedByQueryMatches'
        void AssertGroupQueryDataUseTracked(QueryMatchID queryMatchId, bool shouldBePresent = true)
        {
            if (shouldBePresent)
            {
                Assert.IsTrue(m_Database.SetDataUsedByQueryMatches.TryGetValue(queryMatchId, out var usedDataSet));
                Assert.Greater(usedDataSet.Count, 0);
            }
            else
            {
                Assert.IsFalse(m_Database.SetDataUsedByQueryMatches.ContainsKey(queryMatchId));
            }

            if (shouldBePresent)
                Assert.IsTrue(m_Database.SetDataUsedByQueries.ContainsKey(queryMatchId.queryID));
        }
    }
}
#endif

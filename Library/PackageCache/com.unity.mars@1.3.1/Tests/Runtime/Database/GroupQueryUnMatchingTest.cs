#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    class GroupQueryUnMatchingTest : GroupQueryUnMatchingTestBase
    {
        public void Start()
        {
            m_FrameCount = 18;
            TestObject = QueryTestObjectSettings.instance.SimpleProxyGroup;
            m_QueryBackend = ModuleLoaderCore.instance.GetModule<MARSQueryBackend>();
            m_QueryBackend.UnsetGroupMatchIndices.Clear();
        }

        protected override void OnMarsUpdate()
        {
            var frameCount = MarsTime.FrameCount - m_StartFrame;
            switch (frameCount)
            {
                case 2:
                    m_Instance = InstantiateReferenceObject(TestObject);
                    FindSetChildren(m_Instance);
                    break;
                case 4:
                    Assert.False(m_ChildProxyObject1.activeInHierarchy);
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    break;
                case 5:
                    // this data is what the proxies in the prefab need to match
                    DatabaseUtils.AddPlane(k_Child1Id);
                    this.AddOrUpdateTrait(k_Child1Id, TraitNames.Bounds2D, k_FakePlaneBounds);
                    this.AddOrUpdateTrait(k_Child1Id, TraitNames.Pose, new Pose());
                    this.AddOrUpdateTrait(k_Child1Id, TraitNames.Plane, true);

                    DatabaseUtils.AddPlane(k_Child2Id);
                    this.AddOrUpdateTrait(k_Child2Id, TraitNames.Bounds2D, k_FakePlaneBounds);
                    this.AddOrUpdateTrait(k_Child2Id, TraitNames.Pose, new Pose());
                    this.AddOrUpdateTrait(k_Child2Id, TraitNames.Plane, true);
                    break;
                case 6:
                    ForceUpdateQueries();
                    break;
                case 7:
                    Assert.True(m_ChildProxyObject1.activeInHierarchy);
                    Assert.True(m_ChildProxyObject2.activeInHierarchy);
                    break;
                case 8:
                    // unmatch this group, and seek a match again.
                    Assert.True(m_ProxyGroup.Unmatch());
                    break;
                case 9:
                    // these objects should now be inactive because the loss handlers have been called
                    Assert.False(m_ChildProxyObject1.activeInHierarchy);
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    // because we're seeking a new match, we shouldn't add this query to the un-set group indices
                    Assert.AreEqual(0, m_QueryBackend.UnsetGroupMatchIndices.Count);
                    break;
                case 10:
                    ForceUpdateQueries();
                    break;
                case 11:
                    // because we didn't specify to not seek a new match, updating queries again should result in them re-activating.
                    Assert.True(m_ChildProxyObject1.activeInHierarchy);
                    Assert.True(m_ChildProxyObject2.activeInHierarchy);
                    break;
                case 12:
                    // unmatch this group again, but don't seek a new match this time.
                    m_ProxyGroup.Unmatch(false);
                    break;
                case 13:
                    Assert.False(m_ChildProxyObject1.activeInHierarchy);
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    break;
                case 14:
                    ForceUpdateQueries();
                    break;
                case 16:
                    // because we specified to not seek a new match, updating queries shouldn't affect their active states
                    Assert.False(m_ChildProxyObject1.activeInHierarchy);
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    // not seeking also means we should add this query to the un-set group indices
                    Assert.AreEqual(1, m_QueryBackend.UnsetGroupMatchIndices.Count);
                    break;
                case 17:
                    // a call to Unmatch() when the query isn't matched should do nothing & return false
                    Assert.False(m_ProxyGroup.Unmatch());
                    break;
            }
        }
    }
}
#endif

#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class RequiredGroupMemberUnMatchingTest : GroupQueryUnMatchingTestBase
    {
        Proxy m_RequiredProxy1;
        Proxy m_NonRequiredProxy2;

        public void Start()
        {
            m_FrameCount = 12;
            TestObject = QueryTestObjectSettings.instance.ProxyGroupWithNonRequiredMember;
            m_QueryBackend = ModuleLoaderCore.instance.GetModule<MARSQueryBackend>();
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
                    // unmatch the required member
                    Assert.True(m_RequiredProxy1.Unmatch(false));
                    break;
                case 9:
                    // all of the group proxies' contents should now be inactive because loss handlers have been called
                    Assert.False(m_ChildProxyObject1.activeInHierarchy);
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    // because we're not seeking a new match, we should add this query to the un-set group indices
                    Assert.AreEqual(1, m_QueryBackend.UnsetGroupMatchIndices.Count);
                    break;
                case 10:
                    ForceUpdateQueries();
                    break;
                case 11:
                    // evaluating queries again should not re-match
                    Assert.False(m_ChildProxyObject1.activeInHierarchy);
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    break;
            }
        }

        protected override void FindSetChildren(GameObject setRoot)
        {
            m_ChildProxyObject1 = setRoot.transform.GetChild(0).GetChild(0).gameObject;
            m_ChildProxyObject2 = setRoot.transform.GetChild(1).GetChild(0).gameObject;
            Assert.NotNull(m_ChildProxyObject1);
            Assert.NotNull(m_ChildProxyObject2);

            m_ProxyGroup = m_Instance.GetComponent<ProxyGroup>();
            Assert.NotNull(m_ProxyGroup);

            m_RequiredProxy1 = m_ChildProxyObject1.GetComponentInParent<Proxy>();
            m_NonRequiredProxy2 = m_ChildProxyObject1.GetComponentInParent<Proxy>();
            Assert.NotNull(m_RequiredProxy1);
            Assert.NotNull(m_NonRequiredProxy2);
        }
    }
}
#endif

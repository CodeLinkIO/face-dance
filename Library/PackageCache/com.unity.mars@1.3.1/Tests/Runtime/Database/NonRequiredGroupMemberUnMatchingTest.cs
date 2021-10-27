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
    class NonRequiredGroupMemberUnMatchingTest : GroupQueryUnMatchingTestBase
    {
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
                    this.AddOrUpdateTrait(k_Child1Id, TraitNames.Plane, true);
                    this.AddOrUpdateTrait(k_Child1Id, TraitNames.Pose, new Pose());
                    DatabaseUtils.AddPlane(k_Child2Id);
                    this.AddOrUpdateTrait(k_Child2Id, TraitNames.Bounds2D, k_FakePlaneBounds);
                    this.AddOrUpdateTrait(k_Child2Id, TraitNames.Plane, true);
                    this.AddOrUpdateTrait(k_Child2Id, TraitNames.Pose, new Pose());
                    break;
                case 6:
                    ForceUpdateQueries();
                    break;
                case 7:
                    Assert.True(m_ChildProxyObject1.activeInHierarchy);
                    Assert.True(m_ChildProxyObject2.activeInHierarchy);
                    break;
                case 8:
                    // unmatch the non-required member
                    Assert.True(m_Proxy2.Unmatch(false));
                    break;
                case 9:
                    Assert.True(m_ChildProxyObject1.activeInHierarchy);
                    // only the specific proxy we un-matched should have had loss handlers called
                    Assert.False(m_ChildProxyObject2.activeInHierarchy);
                    break;
            }
        }
    }
}
#endif

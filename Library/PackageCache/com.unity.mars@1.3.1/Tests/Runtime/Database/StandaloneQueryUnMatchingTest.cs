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
    class StandaloneQueryUnMatchingTest : RuntimeQueryTest, IProvidesTraits<Vector2>, IProvidesTraits<Pose>, IProvidesTraits<bool>,
        IUsesQueryResults
    {
        const int k_DataId = 100;

        readonly Vector2 k_FakePlaneBounds = new Vector2(10f, 10f);

        public GameObject TestPrefab;

        GameObject m_ProxyContent;
        GameObject m_ProxyObject;
        Proxy m_Proxy;

        public void Start()
        {
            m_FrameCount = 18;
            TestPrefab = QueryTestObjectSettings.instance.SimplePlaneConditionProxy;
            m_QueryBackend = ModuleLoaderCore.instance.GetModule<MARSQueryBackend>();
        }


        protected override void OnMarsUpdate()
        {
            var frameCount = MarsTime.FrameCount - m_StartFrame;
            switch (frameCount)
            {
                case 2:
                    m_ProxyObject = InstantiateReferenceObject(TestPrefab);
                    m_Proxy = m_ProxyObject.GetComponent<Proxy>();
                    m_ProxyContent = m_ProxyObject.transform.GetChild(0).gameObject;
                    break;
                case 4:
                    Assert.False(m_ProxyContent.activeInHierarchy);
                    break;
                case 5:
                    // this data is what the proxy in the prefab needs to match
                    DatabaseUtils.AddPlane(k_DataId);
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Bounds2D, k_FakePlaneBounds);
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Pose, new Pose());
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Plane, true);
                    break;
                case 6:
                    Assert.True(ForceUpdateQueries());
                    break;
                case 7:
                    Assert.True(m_ProxyContent.activeInHierarchy);
                    break;
                case 8:
                    // unmatch this group, and seek a match again.
                    Assert.True(m_Proxy.Unmatch());
                    break;
                case 9:
                    // the child content should now be inactive because the loss handlers have been called
                    Assert.False(m_ProxyContent.activeInHierarchy);
                    // because we're seeking a new match, we shouldn't add this query to the un-set standalone indices
                    Assert.AreEqual(0, m_QueryBackend.UnsetStandaloneMatchIndices.Count);
                    break;
                case 10:
                    Assert.True(ForceUpdateQueries());
                    break;
                case 11:
                    // because we didn't specify to not seek a new match, updating queries again should result in re-activation.
                    Assert.True(m_ProxyContent.activeInHierarchy);
                    break;
                case 12:
                    // unmatch this group again, but don't seek a new match this time.
                    m_Proxy.Unmatch(false);
                    break;
                case 13:
                    Assert.False(m_ProxyContent.activeInHierarchy);
                    break;
                case 14:
                    Assert.False(ForceUpdateQueries());
                    break;
                case 16:
                    // because we specified to not seek a new match, updating queries shouldn't affect the active state
                    Assert.False(m_ProxyContent.activeInHierarchy);
                    // not seeking also means we should add this query to the un-set standalone indices
                    Assert.AreEqual(1, m_QueryBackend.UnsetStandaloneMatchIndices.Count);
                    break;
                case 17:
                    // a call to Unmatch() when the query isn't matched should do nothing & return false
                    Assert.False(m_Proxy.Unmatch());
                    break;
            }
        }
    }
}
#endif

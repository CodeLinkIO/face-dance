#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class StandaloneReplicatorUnMatchingTest : RuntimeQueryTest, IProvidesTraits<Vector2>, IProvidesTraits<Pose>, IUsesQueryResults
    {
        const int k_MaxDataId = 20;

        readonly Vector2 k_FakePlaneBounds = new Vector2(0.5f, 2.5f);

        public GameObject TestPrefab;

        GameObject m_ProxyContent;
        GameObject m_ProxyObject;
        Proxy m_Proxy;

        public override bool IsTestFinished
        {
            get
            {
                // Wait until all simulation scenes are unloaded before completing the test
                if (!enabled && SceneManager.sceneCount == m_StartSceneCount)
                    return true;

                // Shut down after desired frame count
                if (Time.frameCount - m_StartFrame >= m_FrameCount)
                    enabled = false;

                return false;
            }
        }

        public void Start()
        {
            m_FrameCount = 15;
            TestPrefab = QueryTestObjectSettings.instance.SimpleReplicatedProxy;
            m_QueryBackend = ModuleLoaderCore.instance.GetModule<MARSQueryBackend>();
        }

        protected override void OnMarsUpdate() { }

        protected void Update()
        {
            var frameCount = Time.frameCount - m_StartFrame;
            switch (frameCount)
            {
                case 2:
                    m_ProxyObject = InstantiateReferenceObject(TestPrefab);
                    m_Proxy = m_ProxyObject.GetComponentInChildren<Proxy>();
                    m_ProxyContent = m_Proxy.gameObject.transform.GetChild(0).gameObject;
                    break;
                case 4:
                    Assert.False(m_ProxyContent.activeInHierarchy);
                    break;
                case 5:
                    for (var i = 0; i < k_MaxDataId; i++)
                    {
                        // This data is what the proxy in the prefab needs to match
                        this.AddOrUpdateTrait(i, TraitNames.Bounds2D, k_FakePlaneBounds);
                        this.AddOrUpdateTrait(i, TraitNames.Pose, new Pose());
                    }
                    break;
                case 6:
                    Assert.True(ForceUpdateQueries());
                    break;
                case 7:
                    Assert.True(m_ProxyContent.activeInHierarchy);
                    break;
                case 8:
                    // Un-match this group, and seek a match again.
                    Assert.True(m_Proxy.Unmatch());
                    break;
                case 9:
                    // The child content should now be inactive because the loss handlers have been called
                    Assert.False(m_ProxyContent.activeInHierarchy);
                    // Because we're seeking a new match, we shouldn't add this query to the un-set standalone indices
                    Assert.AreEqual(0, m_QueryBackend.UnsetStandaloneMatchIndices.Count);
                    break;
                case 10:
                    Assert.True(ForceUpdateQueries());
                    break;
                case 11:
                    // Because we didn't specify to not seek a new match, updating queries again should result in re-activation.
                    Assert.True(m_ProxyContent.activeInHierarchy);
                    break;
                case 12:
                    // Un-match this group again, but don't seek a new match this time.
                    m_Proxy.Unmatch(false);
                    break;
                case 14:
                    // Because we specified to not seek a new match, that spawn instance should be destroyed
                    Assert.True(m_Proxy == null);
                    // Not seeking also means we should add this query to the un-set standalone indices
                    Assert.AreEqual(1, m_QueryBackend.UnsetStandaloneMatchIndices.Count);
                    break;
            }
        }
    }
}
#endif

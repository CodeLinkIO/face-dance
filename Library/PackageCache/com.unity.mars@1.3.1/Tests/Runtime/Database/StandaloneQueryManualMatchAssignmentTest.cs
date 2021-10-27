#if UNITY_EDITOR
using System;
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class StandaloneQueryManualMatchAssignmentTest : RuntimeQueryTest, IProvidesTraits<Vector2>, IProvidesTraits<Pose>, IProvidesTraits<bool>,
        IUsesQueryResults
    {
        const int k_DataId = 100;
        const int k_DataId2 = 110;

        static readonly Vector2 k_DataId1Bounds = new Vector2(10f, 10f);
        static readonly Vector2 k_DataId2Bounds = new Vector2(0.01f, 0.01f);

        public GameObject TestPrefab;

        EvaluationSchedulerModule m_SchedulerModule;

        GameObject m_ProxyContent;
        GameObject m_ProxyObject;
        Proxy m_Proxy;

        MarsSceneEvaluationMode m_PreviousSchedulerMode;

        public void Start()
        {
            m_FrameCount = 14;
            TestPrefab = QueryTestObjectSettings.instance.SimplePlaneConditionProxy;
            m_QueryBackend = ModuleLoaderCore.instance.GetModule<MARSQueryBackend>();
            m_SchedulerModule = ModuleLoaderCore.instance.GetModule<EvaluationSchedulerModule>();
            // block automatic solving on interval
            m_PreviousSchedulerMode = m_SchedulerModule.ActiveMode;
            m_SchedulerModule.SetMode(MarsSceneEvaluationMode.WaitForRequest);
        }

        new void OnDisable()
        {
            m_SchedulerModule.SetMode(m_PreviousSchedulerMode);
            base.OnDisable();
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
                    Assert.Throws<ArgumentException>(() =>
                    {
                        var result1 = this.AssignQueryMatch(m_Proxy.queryID, k_DataId);
                        Assert.False(result1);
                    });

                    Assert.False(m_ProxyContent.activeInHierarchy);
                    Assert.Null(m_Proxy.currentData);
                    break;
                case 6:
                    // this data has all traits required by the proxy, but doesn't match the conditions
                    DatabaseUtils.AddPlane(k_DataId);
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Bounds2D, new Vector2(0.01f, 0.01f));
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Pose, new Pose());
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Plane, true);
                    break;
                case 7:
                    Assert.Throws<ArgumentException>(() =>
                    {
                        var result2 = this.AssignQueryMatch(m_Proxy.queryID, k_DataId);
                        Assert.False(result2);
                    });

                    Assert.False(m_ProxyContent.activeInHierarchy);
                    Assert.Null(m_Proxy.currentData);
                    break;
                case 8:
                    // this should make the data match the conditions
                    this.AddOrUpdateTrait(k_DataId, TraitNames.Bounds2D, k_DataId1Bounds);

                    // now that conditions match, assignment should succeed
                    var result3 = this.AssignQueryMatch(m_Proxy.queryID, k_DataId);
                    Assert.True(result3);

                    // make sure the data match made it into the query result
                    Assert.AreEqual(k_DataId, m_Proxy.currentData.DataID);
                    Assert.True(m_Proxy.currentData.TryGetTrait(TraitNames.Bounds2D, out Vector2 boundsValue1));
                    Assert.AreEqual(k_DataId1Bounds, boundsValue1);
                    break;
                case 9:
                    // verify the content was activated after acquire
                    Assert.True(m_ProxyContent.activeInHierarchy);
                    break;
                case 10:
                    // this data has all traits required by the proxy, but doesn't match the conditions
                    this.AddOrUpdateTrait(k_DataId2, TraitNames.Bounds2D, k_DataId2Bounds);
                    this.AddOrUpdateTrait(k_DataId2, TraitNames.Pose, new Pose());
                    this.AddOrUpdateTrait(k_DataId2, TraitNames.Plane, true);
                    break;
                case 11:
                    // Assignment should fail because the query is already using the data
                    Assert.Throws<ArgumentException>(() =>
                    {
                        var result4 = this.AssignQueryMatch(m_Proxy.queryID, k_DataId);
                        Assert.False(result4);
                    });
                    break;
                case 12:
                    // Assignment should succeed, even though conditions aren't met
                    var result5 = m_Proxy.AssignMatch(k_DataId2, false);
                    Assert.True(result5);
                    Assert.True(m_ProxyContent.activeInHierarchy);

                    // make sure the new data made it into the query result
                    Assert.AreEqual(k_DataId2, m_Proxy.currentData.DataID);
                    Assert.True(m_Proxy.currentData.TryGetTrait(TraitNames.Bounds2D, out Vector2 boundsValue2));
                    Assert.AreEqual(k_DataId2Bounds, boundsValue2);
                    break;
                case 13:
                    this.UnregisterQuery(m_Proxy.queryID);
                    Assert.AreEqual(0, m_QueryBackend.UnsetStandaloneMatchIndices.Count);
                    break;
            }
        }
    }
}
#endif

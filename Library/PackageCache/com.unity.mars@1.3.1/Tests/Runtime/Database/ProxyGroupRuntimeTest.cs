#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.MARS.Tests;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    abstract class ProxyGroupRuntimeTest : RuntimeQueryTest, IProvidesTraits<bool>, IProvidesTraits<Pose>
    {
        protected const int k_Member1DataId = 1001;
        protected const int k_Member2DataId = 1002;

        protected ProxyGroup m_ProxyGroup;

        protected Proxy m_ChildProxy1;
        protected Proxy m_ChildProxy2;

        protected GameObject m_Child1ContentObject;
        protected GameObject m_Child2ContentObject;

        protected GameObject m_PrefabInstance;

        protected int frameCount => MarsTime.FrameCount - m_StartFrame;

        public GameObject TestPrefab;

        public bool ReAcquireOnLoss;

        protected void Initialize()
        {
            m_PrefabInstance = InstantiateReferenceObject(TestPrefab);

            m_ProxyGroup = m_PrefabInstance.GetComponent<ProxyGroup>();
            var trans = m_PrefabInstance.transform;
            var obj1 = trans.GetChild(0);
            var obj2 = trans.GetChild(1);

            m_ChildProxy1 = obj1.GetComponent<Proxy>();
            m_ChildProxy2 = obj2.GetComponent<Proxy>();
            m_Child1ContentObject = obj1.GetChild(0).gameObject;
            m_Child2ContentObject = obj2.GetChild(0).gameObject;

            Assert.NotNull(m_Child1ContentObject);
            Assert.NotNull(m_Child2ContentObject);
        }

        protected void AssertValidInitialState()
        {
            QueryAssertUtils.QueryStateIs(QueryState.Unknown, m_ProxyGroup);
            QueryAssertUtils.ActiveInHierarchy(false, m_Child1ContentObject, m_Child2ContentObject);
            QueryAssertUtils.AssignedDataIsNull(m_ChildProxy1, m_ChildProxy2);
        }

        protected void AssertValidTrackingState()
        {
            QueryAssertUtils.QueryStateIs(QueryState.Tracking, m_ProxyGroup);
            QueryAssertUtils.ActiveInHierarchy(true, m_Child1ContentObject, m_Child2ContentObject);
            QueryAssertUtils.AssignedDataIdIsValid(m_ChildProxy1, m_ChildProxy2);
        }
    }
}
#endif

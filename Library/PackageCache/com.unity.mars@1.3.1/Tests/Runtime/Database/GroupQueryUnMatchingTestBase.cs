#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Query;
using Unity.MARS.Tests;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    abstract class GroupQueryUnMatchingTestBase : RuntimeQueryTest, IProvidesTraits<Vector2>, IProvidesTraits<Pose>, IProvidesTraits<bool>, IUsesSetQueryResults
    {
        protected const int k_Child1Id = 100;
        protected const int k_Child2Id = 101;

        protected readonly Vector2 k_FakePlaneBounds = new Vector2(10f, 10f);

        public GameObject TestObject;

        protected GameObject m_Instance;

        protected GameObject m_ChildProxyObject1;
        protected GameObject m_ChildProxyObject2;

        protected ProxyGroup m_ProxyGroup;
        protected Proxy m_Proxy1;
        protected Proxy m_Proxy2;

        protected virtual void FindSetChildren(GameObject setRoot)
        {
            m_ChildProxyObject1 = setRoot.transform.GetChild(0).GetChild(0).gameObject;
            m_ChildProxyObject2 = setRoot.transform.GetChild(1).GetChild(0).gameObject;
            Assert.NotNull(m_ChildProxyObject1);
            Assert.NotNull(m_ChildProxyObject2);

            m_ProxyGroup = m_Instance.GetComponent<ProxyGroup>();
            Assert.NotNull(m_ProxyGroup);

            m_Proxy1 = m_ChildProxyObject1.GetComponentInParent<Proxy>();
            m_Proxy2 = m_ChildProxyObject2.GetComponentInParent<Proxy>();
            Assert.NotNull(m_Proxy1);
            Assert.NotNull(m_Proxy2);
        }
    }
}
#endif

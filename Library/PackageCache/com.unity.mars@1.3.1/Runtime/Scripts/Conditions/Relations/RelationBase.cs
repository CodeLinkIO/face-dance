using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Base condition that is fulfilled when both child entities are fulfilled as part of a Proxy Group.
    /// </summary>
    [RequireComponent(typeof(ProxyGroup))]
    [MovedFrom("Unity.MARS")]
    public abstract class RelationBase : ConditionBase
    {
        [SerializeField]
        protected Proxy m_Child1;

        [SerializeField]
        protected Proxy m_Child2;

        ProxyGroup m_ProxyGroup;

        public IMRObject child1 { get { return m_Child1; } }
        public IMRObject child2 { get { return m_Child2; } }
        public Transform child1Transform { get { return m_Child1 == null ? null : m_Child1.transform; } }
        public Transform child2Transform { get { return m_Child2 == null ? null : m_Child2.transform; } }

        public Proxy child1Proxy
        {
            get { return m_Child1; }
            set { m_Child1 = value; }
        }

        public Proxy child2Proxy
        {
            get { return m_Child2; }
            set { m_Child2 = value; }
        }

        public ProxyGroup proxyGroup
        {
            get
            {
                if (m_ProxyGroup == null)
                    m_ProxyGroup = GetComponent<ProxyGroup>();

                return m_ProxyGroup;
            }
        }

        // Local method use only -- created here to reduce garbage collection
        static readonly List<Proxy> k_ChildObjects = new List<Proxy>();

#if UNITY_EDITOR
        public virtual void Reset()
        {
            ResetChildrenReferences();
        }

        public override void OnValidate()
        {
            base.OnValidate();
            EnsureChildClients();
        }

        public void EnsureChildClients()
        {
            if (m_Child1 != null && !m_Child1.gameObject.transform.IsChildOf(transform))
                m_Child1 = null;

            if (m_Child2 != null && !m_Child2.gameObject.transform.IsChildOf(transform))
                m_Child2 = null;
        }
#endif

        public void ResetChildrenReferences()
        {
            proxyGroup.RepopulateChildList();
            proxyGroup.GetChildList(k_ChildObjects);
            if (k_ChildObjects.Count < 2)
                return;

            m_Child1 = k_ChildObjects[0];
            m_Child2 = k_ChildObjects[1];
            k_ChildObjects.Clear();
        }
    }
}

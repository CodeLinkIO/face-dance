using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class that must be used to build up any members of MultiRelations
    /// </summary>
    [System.Serializable]
    [MovedFrom("Unity.MARS")]
    public class SubRelation
    {
        /// <summary>
        /// Refers to the MonoBehaviour that is hosting the Relations
        /// </summary>
        [HideInInspector]
        public MonoBehaviour Host;

        [SerializeField]
        [HideInInspector]
        protected Proxy m_Child1;

        [SerializeField]
        [HideInInspector]
        protected Proxy m_Child2;

        public IMRObject child1 => m_Child1;
        public IMRObject child2 => m_Child2;

        public bool enabled => Host != null && Host.enabled;

        public void SetChildren(Proxy context1, Proxy context2)
        {
            m_Child1 = context1;
            m_Child2 = context2;
        }
    }
}

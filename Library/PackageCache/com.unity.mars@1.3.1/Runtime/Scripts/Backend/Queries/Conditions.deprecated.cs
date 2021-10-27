using System;
using UnityEngine;

namespace Unity.MARS.Query
{
    /// <summary>
    /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
    /// </summary>
    [Obsolete("Conditions has been deprecated. Use ProxyConditions instead.", true)]
    public class Conditions
    {
        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public int Count => default;

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public Conditions(Proxy target) { }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public static Conditions FromGenericIMRObject<TComponentRootType>(TComponentRootType target) where TComponentRootType : Component, IMRObject
        {
            return default;
        }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public static Conditions FromGameObject<TComponentRootType>(GameObject target) where TComponentRootType : Component, IMRObject
        {
            return default;
        }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public Conditions(Condition condition) { }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public Conditions(ICondition[] conditions) { }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public bool TryGetType<T>(out T[] conditions)
        {
            conditions = default;
            return default;
        }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public bool TryGetType(out object[] conditions)
        {
            conditions = default;
            return default;
        }

        /// <summary>
        /// (Obsolete) Conditions has been deprecated. Use ProxyConditions instead.
        /// </summary>
        public int GetTypeCount(out object[] conditions)
        {
            conditions = default;
            return default;
        }
    }
}

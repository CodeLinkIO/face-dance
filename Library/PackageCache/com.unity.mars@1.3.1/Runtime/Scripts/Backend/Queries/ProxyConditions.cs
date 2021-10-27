using System;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Collections of different types of data filters
    /// </summary>
    public partial class ProxyConditions
    {
        /// <summary>
        /// The number of conditions present on this proxy, across all types
        /// </summary>
        public int Count => CountInternal(this);

        /// <summary>
        /// Collections of different types of conditions
        /// </summary>
        /// <param name="target">Proxy to create conditions for</param>
        public ProxyConditions(Proxy target)
        {
            FilterConditions(target);
        }

        ProxyConditions()
        {
        }

        public static ProxyConditions FromGenericIMRObject<TComponentRootType>(TComponentRootType target) where TComponentRootType : Component, IMRObject
        {
            var conditions = new ProxyConditions();
            conditions.FilterConditions(target);
            return conditions;
        }

        public static ProxyConditions FromGameObject<TComponentRootType>(GameObject target) where TComponentRootType : Component, IMRObject
        {
            var root = target.GetComponent<TComponentRootType>();
            return root == null ? null : FromGenericIMRObject(root);
        }

        public ProxyConditions(Condition condition)
        {
            FromCondition(condition);
        }

        public ProxyConditions(ICondition[] conditions)
        {
            using (var componentFilter = new CachedComponentFilter<ICondition, Component>(conditions, false))
            {
                GatherComponents(componentFilter);
            }
        }

        void FilterConditions<TComponentRootType>(TComponentRootType target) where TComponentRootType : Component, IMRObject
        {
            using (var componentFilter = new CachedComponentFilter<ICondition, TComponentRootType>(target, CachedSearchType.Self | CachedSearchType.Parents, false))
            {
                GatherComponents(componentFilter);
            }
        }

        // These methods here to allow compilation before code generation, and should be unused after generation runs.

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        void GatherComponents(object componentFilter) { }
        void FromCondition(object condition) { }

        public bool TryGetType<T>(out T[] conditions)
        {
# if UNITY_EDITOR
            Debug.LogWarning($"generic version of conditions.TryGetType was called - this should never happen!");
#endif
            conditions = default;
            return default;
        }

        [Obsolete("This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method")]
        public bool TryGetType(out object[] conditions)
        {
            conditions = default;
            return default;
        }

        [Obsolete("This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method")]
        public int GetTypeCount(out object[] conditions)
        {
            return !TryGetType(out conditions) ? 0 : conditions.Length;
        }

        static int CountInternal(object self)
        {
            return 0;
        }

        // ReSharper restore UnusedMember.Local
        // ReSharper restore UnusedParameter.Local
    }
}

using System.Collections.Generic;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Caches references to all the trait collections.
    /// The lists of dictionaries here are parallel to the collections in ProxyConditions and ConditionRatingsData.
    /// </summary>
    partial class CachedTraitCollection
    {
        public bool fulfilled { get; set; }

        public CachedTraitCollection() { }

        public CachedTraitCollection(ProxyConditions conditions)
        {
            // FromConditions' actual implementation is in generated code
            FromConditions(conditions);
        }

        public void Clear()
        {
            fulfilled = false;
            ClearInternal(this);
        }

        public bool CheckForDestroyedCollections()
        {
            return CheckDestroyedInternal(this);
        }

        // these functions should all be unused after code generation runs
        void ClearInternal(object self) { }
        void FromConditions(object conditions) { }
        bool CheckDestroyedInternal(object conditions) { return false; }

        // This method should only be used by other generic methods
        public bool TryGetType<T>(out List<Dictionary<int, T>> traits)
        {
# if UNITY_EDITOR
            const string callWarning = "CachedTraitCollection.TryGetType was called with an " +
                "explicit generic parameter - you must specify the type using only the out parameter";
            var handlerWarning = $"type {typeof(T).FullName} has no registered handler in the trait type database!";
            Debug.LogWarning($"Either {handlerWarning}, or,\n{callWarning}");
#endif
            traits = default;
            return default;
        }
    }
}

using System.Collections.Generic;
using Unity.MARS.Query;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Caches references to all the Relation trait collections.
    /// </summary>
    partial class RelationTraitCache
    {
        public class ChildTraits<T>
        {
            public Dictionary<int, T> One;
            public Dictionary<int, T> Two;

            public ChildTraits() { }

            public ChildTraits(Dictionary<int, T> traitValues)
            {
                One = traitValues;
                Two = traitValues;
            }
        }

        public bool Fulfilled { get; set; }

        public RelationTraitCache() { }

        public RelationTraitCache(Relations relations)
        {
            FromRelations(relations);
        }

        public void Clear()
        {
            Fulfilled = false;
            ClearInternal(this);
        }

        public bool CheckForDestroyedCollections()
        {
            return CheckDestroyedInternal(this);
        }

        // functions below here are stubs for before code generation runs
        // ReSharper disable once UnusedMember.Local
        public bool TryGetType<T>(out List<ChildTraits<T>> traits)
        {
            traits = default;
            return default;
        }

        // ReSharper disable once UnusedMember.Local
        void ClearInternal(object self) { }
        // ReSharper disable once UnusedMember.Local
        void FromRelations(object relations) { }
        // ReSharper disable once UnusedMember.Local
        bool CheckDestroyedInternal(object self) { return false; }
    }
}

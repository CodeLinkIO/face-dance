using System.Collections.Generic;
using Unity.MARS.Query;
using Unity.MARS.Settings;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Stores unfiltered match rating results for a single set query's relations
    /// Each index in this list represents a relation in the same set query.
    /// </summary>
    class RelationRatingsData : List<Dictionary<RelationDataPair, float>>
    {
        /// <summary>
        /// Pre-allocate the storage for match ratings for a set's relations.
        /// </summary>
        /// <param name="relations">The set of relations to store the results for</param>
        public RelationRatingsData(Relations relations)
        {
            Initialize(relations);
        }

        // this constructor & the public Initialize methods exist so this can be used with the ObjectPool
        public RelationRatingsData() { }

        public RelationRatingsData Initialize(Relations relations)
        {
            if (relations.Count > Capacity)
                Capacity = relations.Count;

            for (var i = 0; i < relations.Count; i++)
            {
                Add(new Dictionary<RelationDataPair, float>(MARSMemoryOptions.instance.RatingDictionaryCapacity * 4));
            }

            return this;
        }

        internal RelationRatingsData Initialize(int count)
        {
            if (count > Capacity)
                Capacity = count;

            for (var i = 0; i < count; i++)
            {
                Add(new Dictionary<RelationDataPair, float>(MARSMemoryOptions.instance.RatingDictionaryCapacity * 4));
            }

            return this;
        }
    }
}

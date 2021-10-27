using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    class DictionaryPool<TKey, TValue> : ObjectPool<Dictionary<TKey, TValue>>
    {
        internal int defaultCapacity;

        public DictionaryPool(int capacity = 16)
        {
            defaultCapacity = capacity;
        }

        public void PreAllocate(int count)
        {
            for (var i = 0; i < count; i++)
            {
                m_Queue.Enqueue(new Dictionary<TKey, TValue>(defaultCapacity));
            }
        }

        public override Dictionary<TKey, TValue> Get()
        {
            return m_Queue.Count == 0 ? new Dictionary<TKey, TValue>(defaultCapacity) : m_Queue.Dequeue();
        }

        protected override void ClearInstance(Dictionary<TKey, TValue> instance)
        {
            instance.Clear();
        }
    }

    abstract class PreWarmedHashSetPool<T> : ObjectPool<HashSet<T>>
    {
        internal int defaultCapacity;

        protected PreWarmedHashSetPool(int setCapacity = 16, int preCreationCount = 8)
        {
            defaultCapacity = setCapacity;
            for (var i = 0; i < preCreationCount; i++)
            {
                m_Queue.Enqueue(AllocateNew());
            }
        }

        public void PreAllocate(int count)
        {
            for (var i = 0; i < count; i++)
            {
                m_Queue.Enqueue(AllocateNew());
            }
        }

        public override HashSet<T> Get()
        {
            return m_Queue.Count == 0 ? AllocateNew() : m_Queue.Dequeue();
        }

        // There's no way to initialize a HashSet to a capacity as with other collections.
        // This has to be implemented in a derived class, because you can't add the default
        // value to a hashset over and over again - it won't increase capacity.
        protected abstract HashSet<T> AllocateNew();

        protected override void ClearInstance(HashSet<T> instance)
        {
            instance.Clear();
        }
    }

    class RatingDictionaryPool : DictionaryPool<int, float>
    {
        // we want the ratings dictionaries to have a fair amount of space by default.
        // This drastically cuts down on the amount of re-allocation that happens while rating matches.
        public RatingDictionaryPool() : base(MARSMemoryOptions.instance.RatingDictionaryCapacity) { }
    }

    class QueryResultDictionaryPool<T> : DictionaryPool<string, T>
    {
        public QueryResultDictionaryPool() : base(MARSMemoryOptions.instance.ResultDictionaryCapacity) { }
    }

    class CachedTraitCollectionPool : ObjectPool<CachedTraitCollection>
    {
        protected override void ClearInstance(CachedTraitCollection instance)
        {
            instance.Clear();
        }
    }

    class ConditionRatingsDataPool : ObjectPool<ConditionRatingsData>
    {
        protected override void ClearInstance(ConditionRatingsData instance)
        {
            instance.Recycle();
        }
    }

    class RelationRatingsDataPool : ObjectPool<RelationRatingsData>
    {
        protected override void ClearInstance(RelationRatingsData instance)
        {
            instance.Clear();
        }
    }

    class RelationTraitCachePool : ObjectPool<RelationTraitCache>
    {
        protected override void ClearInstance(RelationTraitCache instance)
        {
            instance.Clear();
        }
    }

    class DataIdHashSetPool : PreWarmedHashSetPool<int>
    {
        public DataIdHashSetPool() : base(MARSMemoryOptions.instance.MatchIdHashSetCapacity, 24) { }

        // There's no way to initialize a HashSet to a capacity as with other generic collections like List<T>.
        protected override HashSet<int> AllocateNew()
        {
            var set = new HashSet<int>();
            // However, a HashSet will increase it capacity internally if you add elements to it.
            // So, in order to pre-allocate capacity in a hashset, we can add dummy values and Clear() them.
            for (var i = 0; i < defaultCapacity; i++)
            {
                set.Add(i);
            }

            set.Clear();
            return set;
        }
    }

    class ListPool<T> : ObjectPool<List<T>>
    {
        protected override void ClearInstance(List<T> instance)
        {
            instance.Clear();
        }
    }

    /// <summary>
    /// An object pool for <seealso cref="DataIdRequestMap"/> that automatically clears on recycle.
    /// </summary>
    class DataRequestMapPool : ObjectPool<DataIdRequestMap>
    {
        protected override void ClearInstance(DataIdRequestMap instance)
        {
            instance.Clear();
        }
    }

    static partial class Pools
    {
        public static CachedTraitCollectionPool TraitCaches;
        public static ConditionRatingsDataPool ConditionRatings;
        public static RelationRatingsDataPool RelationRatings;
        public static RelationTraitCachePool RelationTraitCaches;
        public static ListPool<RelationDataPair> RelationDataPairLists;
        public static RatingDictionaryPool Ratings;
        public static DataIdHashSetPool DataIdHashSets;

        public static DictionaryPool<QueryMatchID, bool> QueryDataDirtyStates;

        public static ListPool<int> IntLists;

        public static BufferPool<int> IntBuffers;
        public static BufferPool<float> FloatBuffers;

        static Pools()
        {
            Initialize();
        }

        static void Initialize()
        {
            var options = MARSMemoryOptions.instance;
            TraitCaches = new CachedTraitCollectionPool();
            ConditionRatings = new ConditionRatingsDataPool();
            RelationRatings = new RelationRatingsDataPool();
            RelationTraitCaches = new RelationTraitCachePool();
            Ratings = new RatingDictionaryPool();
            DataIdHashSets = new DataIdHashSetPool();
            RelationDataPairLists = new ListPool<RelationDataPair>();

            QueryDataDirtyStates = new DictionaryPool<QueryMatchID, bool>(options.DataDirtyStatesCapacity);

            IntLists = new ListPool<int>();

            IntBuffers = new BufferPool<int>();
            FloatBuffers = new BufferPool<float>();
        }
    }
}

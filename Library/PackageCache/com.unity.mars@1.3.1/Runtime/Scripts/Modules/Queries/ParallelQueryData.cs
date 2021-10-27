using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Assertions;

namespace Unity.MARS
{
    /// <summary>
    /// Stores all data for each standalone query match in a number of parallel arrays
    /// </summary>
    class ParallelQueryData : ParallelSparseArrays
    {
        /// <summary>Map a query match to an index into the parallel arrays</summary>
        public readonly Dictionary<QueryMatchID, int> MatchIdToIndex;

        /// <summary>The unique identifier for each Proxy</summary>
        public QueryMatchID[] QueryMatchIds;
        /// <summary>The input arguments for each query - used for timeout handling</summary>
        public QueryArgs[] QueryArgs;
        /// <summary>The data use rule for each Proxy</summary>
        public Exclusivity[] Exclusivities;

        /// <summary>The time, in seconds, between update checks for each Proxy</summary>
        public float[] UpdateMatchInterval;

        /// <summary>How long until the Proxy times out</summary>
        public float[] TimeOuts;
        /// <summary>Whether to attempt to acquire another match when the match is lost</summary>
        public bool[] ReAcquireOnLoss;
        /// <summary>How important each proxies' match is</summary>
        public MarsEntityPriority[] Priority;
        /// <summary>All defined conditions for this Proxy</summary>
        public ProxyConditions[] Conditions;
        /// <summary>All defined trait requirements for this Proxy</summary>
        public ProxyTraitRequirements[] TraitRequirements;

        /// <summary>Collections of references to the trait values the Conditions for each Proxy needs</summary>
        public CachedTraitCollection[] CachedTraits;
        /// <summary>Ratings for all individual Conditions on each Proxy</summary>
        public ConditionRatingsData[] ConditionRatings;
        /// <summary>The set of all data IDs that passed all Conditions on each Proxy</summary>
        public HashSet<int>[] ConditionMatchSets;
        /// <summary>Maps each data ID that passed all Conditions to the rating they receive for this proxy</summary>
        public Dictionary<int, float>[] ReducedConditionRatings;
        /// <summary>The data id assigned to each proxy. ReservedDataIds.Invalid if a proxy is not matched</summary>
        public int[] BestMatchDataIds;
        /// <summary>The data passed to users when a query matches, in OnMatchAcquire</summary>
        public QueryResult[] QueryResults;

        /// <summary>User callbacks executed when a new match is found for a Proxy</summary>
        public Action<QueryResult>[] AcquireHandlers;
        /// <summary>User callbacks executed every time a matched proxy's data updates</summary>
        public Action<QueryResult>[] UpdateHandlers;
        /// <summary>User callbacks executed when a match is lost for a Proxy</summary>
        public Action<QueryResult>[] LossHandlers;
        /// <summary>User callbacks executed when a proxy's query times out</summary>
        public Action<QueryArgs>[] TimeoutHandlers;

        public void ClearCycleIndices()
        {
            FilteredAcquiringIndices.Clear();
            PotentialMatchAcquiringIndices.Clear();
            DefiniteMatchAcquireIndices.Clear();
        }

        public bool Remove(QueryMatchID id)
        {
            int index;
            if (!MatchIdToIndex.TryGetValue(id, out index))
                return false;

            MatchIdToIndex.Remove(id);

            QueryMatchIds[index] = QueryMatchID.NullQuery;
            QueryArgs[index] = null;
            // the query result can still be in use (by the onLoss event), so we don't pool/recycle it
            QueryResults[index] = null;

            Pools.TraitCaches.Recycle(CachedTraits[index]);
            CachedTraits[index] = null;
            Pools.ConditionRatings.Recycle(ConditionRatings[index]);
            ConditionRatings[index] = null;

            // these collection members are re-usable, but we null them out so it's clear what data is invalid
            Pools.DataIdHashSets.Recycle(ConditionMatchSets[index]);
            ConditionMatchSets[index] = null;
            Pools.Ratings.Recycle(ReducedConditionRatings[index]);
            ReducedConditionRatings[index] = null;

            Exclusivities[index] = default(Exclusivity);
            BestMatchDataIds[index] = (int) ReservedDataIDs.Invalid;

            TimeOuts[index] = 0f;
            Conditions[index] = null;
            TraitRequirements[index] = null;
            ReAcquireOnLoss[index] = false;
            Priority[index] = MarsEntityPriority.Normal;
            UpdateMatchInterval[index] = 0f;

            AcquireHandlers[index] = null;
            UpdateHandlers[index] = null;
            LossHandlers[index] = null;
            TimeoutHandlers[index] = null;

            FreeIndex(index);
            UpdatingIndices.Remove(index);
            AcquiringIndices.Remove(index);
            m_Count--;
            return true;
        }

        internal bool RemoveAndTimeout(QueryMatchID id)
        {
            if (!MatchIdToIndex.TryGetValue(id, out var index))
                return false;

            TimeoutHandlers[index]?.Invoke(QueryArgs[index]);
            return Remove(id);
        }

        public void Clear()
        {
            m_Count = 0;
            MatchIdToIndex.Clear();
            ValidIndices.Clear();
            FreedIndices.Clear();
            FilteredAcquiringIndices.Clear();
            AcquiringIndices.Clear();
            PotentialMatchAcquiringIndices.Clear();
            DefiniteMatchAcquireIndices.Clear();
            UpdatingIndices.Clear();

            Array.Clear(QueryMatchIds, 0, QueryMatchIds.Length);
            Array.Clear(QueryArgs, 0, QueryArgs.Length);
            Array.Clear(Exclusivities, 0, Exclusivities.Length);

            Array.Clear(UpdateMatchInterval, 0, UpdateMatchInterval.Length);
            Array.Clear(TimeOuts, 0, TimeOuts.Length);
            Array.Clear(ReAcquireOnLoss, 0, ReAcquireOnLoss.Length);

            Array.Clear(Conditions, 0, Conditions.Length);
            Array.Clear(TraitRequirements, 0, TraitRequirements.Length);
            Array.Clear(CachedTraits, 0, CachedTraits.Length);
            Array.Clear(ConditionRatings, 0, ConditionRatings.Length);
            Array.Clear(ConditionMatchSets, 0, ConditionMatchSets.Length);
            Array.Clear(ReducedConditionRatings, 0, ReducedConditionRatings.Length);
            Array.Clear(BestMatchDataIds, 0, BestMatchDataIds.Length);
            Array.Clear(QueryResults, 0, QueryResults.Length);

            Array.Clear(AcquireHandlers, 0, AcquireHandlers.Length);
            Array.Clear(UpdateHandlers, 0, UpdateHandlers.Length);
            Array.Clear(LossHandlers, 0, LossHandlers.Length);
            Array.Clear(TimeoutHandlers, 0, TimeoutHandlers.Length);
        }

        public ParallelQueryData(int initialCapacity) : base(initialCapacity)
        {
            MatchIdToIndex = new Dictionary<QueryMatchID, int>(initialCapacity);

            QueryMatchIds = new QueryMatchID[initialCapacity];
            QueryArgs = new QueryArgs[initialCapacity];
            CachedTraits = new CachedTraitCollection[initialCapacity];
            Exclusivities = new Exclusivity[initialCapacity];

            UpdateMatchInterval = new float[initialCapacity];
            TimeOuts = new float[initialCapacity];
            ReAcquireOnLoss = new bool[initialCapacity];
            Priority = new MarsEntityPriority[initialCapacity];

            Conditions = new ProxyConditions[initialCapacity];
            TraitRequirements = new ProxyTraitRequirements[initialCapacity];
            ConditionRatings = new ConditionRatingsData[initialCapacity];
            ConditionMatchSets = new HashSet<int>[initialCapacity];
            ReducedConditionRatings = new Dictionary<int, float>[initialCapacity];

            BestMatchDataIds = new int[initialCapacity];
            for (int i = 0; i < BestMatchDataIds.Length; i++)
            {
                BestMatchDataIds[i] = (int) ReservedDataIDs.Invalid;
            }

            QueryResults = new QueryResult[initialCapacity];

            AcquireHandlers = new Action<QueryResult>[initialCapacity];
            UpdateHandlers = new Action<QueryResult>[initialCapacity];
            LossHandlers = new Action<QueryResult>[initialCapacity];
            TimeoutHandlers = new Action<QueryArgs>[initialCapacity];
        }

        public QueryMatchID Register(QueryArgs args)
        {
            var matchId = QueryMatchID.Generate();
            Register(matchId, args);
            return matchId;
        }

        public void Register(QueryMatchID id, QueryArgs args)
        {
            if (MatchIdToIndex.ContainsKey(id))
            {
                return; // query is already registered
            }

            var index = GetInsertionIndex();

            QueryMatchIds[index] = id;
            QueryArgs[index] = args;
            Exclusivities[index] = args.exclusivity;
            BestMatchDataIds[index] = (int) ReservedDataIDs.Invalid;

            TimeOuts[index] = args.commonQueryData.timeOut;
            ReAcquireOnLoss[index] = args.commonQueryData.reacquireOnLoss;
            Priority[index] = args.commonQueryData.priority;
            UpdateMatchInterval[index] = args.commonQueryData.updateMatchInterval;

            CachedTraits[index] = new CachedTraitCollection(args.conditions);
            TraitRequirements[index] = args.traitRequirements;
            Conditions[index] = args.conditions;
            ConditionRatings[index] = Pools.ConditionRatings.Get().Initialize(args.conditions);
            ConditionMatchSets[index] = Pools.DataIdHashSets.Get();
            ReducedConditionRatings[index] = Pools.Ratings.Get();
            QueryResults[index] = new QueryResult {queryMatchId = id};

            AcquireHandlers[index] = args.onAcquire;
            UpdateHandlers[index] = args.onMatchUpdate;
            LossHandlers[index] = args.onLoss;
            TimeoutHandlers[index] = args.onTimeout;

            m_Count++;
            ValidIndices.Add(index);
            MatchIdToIndex.Add(id, index);
            AcquiringIndices.Add(index);
        }

        public void Modify(QueryMatchID id, QueryArgs args)
        {
            if (!MatchIdToIndex.TryGetValue(id, out var index))
                return;

            Assert.IsTrue(QueryMatchIds[index].Equals(id),
                $"{index} mismatch with {id}!");

            QueryArgs[index] = args;
            Exclusivities[index] = args.exclusivity;
            BestMatchDataIds[index] = (int) ReservedDataIDs.Invalid;

            TimeOuts[index] = args.commonQueryData.timeOut;
            ReAcquireOnLoss[index] = args.commonQueryData.reacquireOnLoss;
            Priority[index] = args.commonQueryData.priority;
            UpdateMatchInterval[index] = args.commonQueryData.updateMatchInterval;

            CachedTraits[index] = new CachedTraitCollection(args.conditions);
            TraitRequirements[index] = args.traitRequirements;
            Conditions[index] = args.conditions;
            ConditionRatings[index] = Pools.ConditionRatings.Get().Initialize(args.conditions);
            ConditionMatchSets[index] = Pools.DataIdHashSets.Get();
            ReducedConditionRatings[index] = Pools.Ratings.Get();
            QueryResults[index] = new QueryResult {queryMatchId = id};

            AcquireHandlers[index] = args.onAcquire;
            UpdateHandlers[index] = args.onMatchUpdate;
            LossHandlers[index] = args.onLoss;
            TimeoutHandlers[index] = args.onTimeout;

            if (!AcquiringIndices.Contains(index))
                AcquiringIndices.Add(index);

            UpdatingIndices.Remove(index);
        }

        internal override void Resize(int newSize)
        {
            var oldCapacity = m_Capacity;
            m_Capacity = newSize;
            Array.Resize(ref QueryMatchIds, newSize);
            Array.Resize(ref QueryArgs, newSize);
            Array.Resize(ref Exclusivities, newSize);

            Array.Resize(ref UpdateMatchInterval, newSize);
            Array.Resize(ref TimeOuts, newSize);
            Array.Resize(ref ReAcquireOnLoss, newSize);
            Array.Resize(ref Priority, newSize);

            Array.Resize(ref Conditions, newSize);
            Array.Resize(ref TraitRequirements, newSize);
            Array.Resize(ref CachedTraits, newSize);
            Array.Resize(ref ConditionRatings, newSize);
            Array.Resize(ref ConditionMatchSets, newSize);
            Array.Resize(ref ReducedConditionRatings, newSize);

            Array.Resize(ref BestMatchDataIds, newSize);
            for (int i = oldCapacity; i < newSize; i++)
            {
                BestMatchDataIds[i] = (int) ReservedDataIDs.Invalid;
            }

            Array.Resize(ref QueryResults, newSize);
            Array.Resize(ref AcquireHandlers, newSize);
            Array.Resize(ref UpdateHandlers, newSize);
            Array.Resize(ref LossHandlers, newSize);
            Array.Resize(ref TimeoutHandlers, newSize);
            OnResize?.Invoke();
        }

        internal static int CountUnmatchedStatic(List<int> acquiringIndices, QueryMatchID[] queryMatchIds)
        {
            var count = 0;
            foreach (var index in acquiringIndices)
            {
                var queryMatchId = queryMatchIds[index];
                // if it's an instance of a replicated proxy past the first, don't count it as unmatched
                if (queryMatchId.matchID <= 1)
                    count++;
            }

            return count;
        }

        internal int CountUnmatched()
        {
            return CountUnmatchedStatic(AcquiringIndices, QueryMatchIds);
        }
    }
}

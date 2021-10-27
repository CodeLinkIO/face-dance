using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.Utils;

namespace Unity.MARS.Query
{
    class FindBestMatchTransform : DataTransform<List<int>,
        Dictionary<int, float>[],
        Exclusivity[],
        MarsEntityPriority[],
        int[]>
    {
        static readonly List<int> k_TempReservedIds = new List<int>();

        /// <summary>
        /// A staging area for best match assignments.
        /// We modify assignments in here before assigning to the actual query data.
        /// </summary>
        readonly Dictionary<int, int> m_CandidateDataIds;

        /// <summary>
        /// A mapping of how each data Id has been requested by the queries in the working set
        /// </summary>
        readonly Dictionary<int, DataIdRequestMap> m_RequestMaps = new Dictionary<int, DataIdRequestMap>();

        readonly HashSet<int> m_IdRemovalBuffer = new HashSet<int>();

        /// <summary>
        /// The set of all query indexes that are Reserved & still have data conflicts to sort
        /// </summary>
        readonly HashSet<int> m_GlobalReservedConflictSet = new HashSet<int>();

        /// <summary>
        /// All indexes of Shared queries in the working set
        /// </summary>
        readonly HashSet<int> m_GlobalSharedIndexSet = new HashSet<int>();

        readonly DataRequestMapPool m_RequestMapPool = new DataRequestMapPool();

        public FindBestMatchTransform(int capacity)
        {
            Process = FindBestStage;
            m_CandidateDataIds = new Dictionary<int, int>(capacity);
        }

        internal void FindBestStage(List<int> workingIndices, List<int> verifiedMatchIndices,
            Dictionary<int, float>[] ratingsById,
            Exclusivity[] exclusivities,
            MarsEntityPriority[] allPriorities,
            ref int[] bestMatchIds)
        {
            if (workingIndices.Count == 0)
                return;

            Clear();
            verifiedMatchIndices.Clear();

            // build up a map of which queries are requesting which data ids, and how.
            var requestMap = BuildRequestMap(workingIndices, ratingsById, exclusivities);

            // sort any conflicts in the data matches
            ResolveConflicts(requestMap, ratingsById, allPriorities);

            // after we have our final assignment candidates, copy those to the result array
            // THIS IS WHERE FINAL QUERY RESULTS ARE ASSIGNED
            foreach (var index in workingIndices)
            {
                int dataId;
                if (m_CandidateDataIds.TryGetValue(index, out dataId))
                {
                    if (dataId == (int)ReservedDataIDs.Invalid)
                        continue;

                    bestMatchIds[index] = dataId;
                    if(!verifiedMatchIndices.Contains(index))
                        verifiedMatchIndices.Add(index);
                }
            }
        }

        void Clear()
        {
            m_CandidateDataIds.Clear();
            foreach (var kvp in m_RequestMaps)
            {
                m_RequestMapPool.Recycle(kvp.Value);
            }

            m_RequestMaps.Clear();

            m_IdRemovalBuffer.Clear();
            m_GlobalReservedConflictSet.Clear();
            m_GlobalSharedIndexSet.Clear();
        }

        /// <summary>
        /// Figure out the data assignments for all queries in the working set,
        /// taking into account ownership rules and match ratings.
        /// </summary>
        /// <param name="indicesRequestingId">
        /// A <see cref="DataIdRequestMap"/> for every data ID in the working set.
        /// This must be built with <see cref="BuildRequestMap"/> before calling this.
        /// </param>
        /// <param name="ratings">The ratings sets for all standalone queries</param>
        /// <returns>
        /// A sparse array which contains all assignments for the working set.
        /// Invalid entries in the array represent queries outside the working set.
        /// </returns>
        internal Dictionary<int, int> ResolveConflicts(Dictionary<int, DataIdRequestMap> indicesRequestingId,
            Dictionary<int, float>[] ratings, MarsEntityPriority[] allPriorities)
        {
            m_IdRemovalBuffer.Clear();
            foreach (var kvp in indicesRequestingId)
            {
                var dataId = kvp.Key;
                var indexSet = kvp.Value;
                // Start by assigning the ReadOnly best matches, since there can be no conflict there
                foreach (var readOnlyIndex in indexSet.ReadOnly)
                {
                    m_CandidateDataIds[readOnlyIndex] = dataId;
                }
            }

            // Solve which reserved query match will be assigned which ID, if any
            SolveReservedLoop(indicesRequestingId, ratings, allPriorities);

            // After all Reserved queries have their final IDs, remove those IDs from all shared data match sets
            foreach (var id in m_IdRemovalBuffer)
            {
                foreach (var index in m_GlobalSharedIndexSet)
                {
                    var sharedQueryRatings = ratings[index];
                    sharedQueryRatings.Remove(id);
                }
            }

            // Assign all shared data the best of what remains
            foreach (var kvp in indicesRequestingId)
            {
                var indexSet = kvp.Value;
                SolveShared(ratings, indexSet.Shared);
            }

            return m_CandidateDataIds;
        }

        /// <summary>
        /// This loop is where all Reserved data conflicts in the working set are sorted out.
        /// </summary>
        void SolveReservedLoop(Dictionary<int, DataIdRequestMap> indicesRequestingId,
            Dictionary<int, float>[] ratings, MarsEntityPriority[] allPriorities)
        {
            // don't allow more iterations than we have reserved queries, as a safeguard against infinite loop
            var safetyCounter = 0;
            var counterMax = ratings.Length;
            int conflictCount;
            do
            {
                m_GlobalReservedConflictSet.Clear();
                foreach (var kvp in indicesRequestingId)
                {
                    // solve which match will reserve this ID, if any
                    SolveReserved(kvp.Key, kvp.Value, ratings, allPriorities);
                }

                // for any queries that had their best match taken by another query, update the request map
                foreach (var conflictingIndex in m_GlobalReservedConflictSet)
                {
                    var ratingSet = ratings[conflictingIndex];
                    if (ratingSet.Count == 0)
                    {
                        // this query has run out of matches - assign an invalid data id.
                        m_CandidateDataIds[conflictingIndex] = (int)ReservedDataIDs.Invalid;
                        continue;
                    }

                    var nextBestKvp = ratingSet.First();
                    var dataId = nextBestKvp.Key;
                    DataIdRequestMap requestMapForIndex;
                    if (indicesRequestingId.TryGetValue(dataId, out requestMapForIndex))
                    {
                        requestMapForIndex.Reserved.Add(conflictingIndex);
                    }
                    else
                    {
                        // no query had requested this data id before, so we need to create a new map for it
                        requestMapForIndex = m_RequestMapPool.Get();
                        requestMapForIndex.Reserved.Add(conflictingIndex);
                        indicesRequestingId.Add(dataId, requestMapForIndex);
                    }
                }

                safetyCounter++;
                conflictCount = m_GlobalReservedConflictSet.Count;
            }
            while (conflictCount > 0 && safetyCounter <= counterMax);
        }

        /// <summary>
        /// Solve any data reservation conflicts for a single data ID in the working standalone query set.
        /// </summary>
        void SolveReserved(int dataId, DataIdRequestMap map, Dictionary<int, float>[] ratings,
            MarsEntityPriority[] priorities = null)
        {
            var reservedIndexes = map.Reserved;
            switch (reservedIndexes.Count)
            {
                // no reserved queries asked for this ID, so this ID's assignments are already valid.
                case 0:
                    return;
                // Once only 1 reserved query asks for an ID, we can finalize that ID's assignments.
                // This is only place reserved IDs should ever be assigned.
                case 1:
                    var index = reservedIndexes.First();
                    m_CandidateDataIds[index] = dataId;
                    // add to the list of data IDs to remove from shared match possibilities
                    m_IdRemovalBuffer.Add(dataId);
                    break;
                // as long as more than 1 Reserved query is asking for this ID, there is a conflict.
                default:
                    //first find the set of indices that tie for highest priority requester
                    var highestPriority = HighestPriorityIndicesForId(reservedIndexes, priorities);

                    // out of all the reserved queries requesting this id at this priority level, which has the best score ?
                    var bestIndex = BestScoringIndexForId(dataId, highestPriority, ratings);
                    if (bestIndex == int.MinValue)
                        return;

                    // add any other reserved queries that wanted this data id to the conflict set
                    foreach (var ri in reservedIndexes)
                    {
                        if (ri == bestIndex)
                            continue;

                        m_GlobalReservedConflictSet.Add(ri);
                    }

                    // in the conflict map for this data id, set the best match as the only one reserving the id.
                    // this means that the next iteration, it will hit case 1 above & have the assignment finalized.
                    reservedIndexes.Clear();
                    reservedIndexes.Add(bestIndex);

                    // for every reserved query that wanted to reserve this data id, but wasn't the best match,
                    // remove the data id from their rating sets
                    foreach (var conflictIndex in m_GlobalReservedConflictSet)
                    {
                        var ratingSet = ratings[conflictIndex];
                        ratingSet.Remove(dataId);
                    }

                    break;
            }
        }

        // which query match has the best score for this data ID in the given set of query indexes?
        static int BestScoringIndexForId<T>(int dataId, T indices, Dictionary<int, float>[] ratings)
            where T : class, IEnumerable<int>
        {
            var bestIndex = int.MinValue;
            var bestScore = -1f;
            foreach (var i in indices)
            {
                var ratingSet = ratings[i];
                var rating = ratingSet[dataId];
                if (!(rating > bestScore))
                    continue;

                bestScore = rating;
                bestIndex = i;
            }

            return bestIndex;
        }

        internal static List<int> HighestPriorityIndicesForId<T>(T indices, MarsEntityPriority[] priorities)
            where T : class, IEnumerable<int>
        {
            if (priorities == null)
                return k_TempReservedIds;

            var highest = MarsEntityPriority.Low;
            foreach (var i in indices)
            {
                var priority = priorities[i];
                if (priority > highest)
                    highest = priority;
            }

            k_TempReservedIds.Clear();
            foreach (var i in indices)
            {
                if (priorities[i] == highest)
                    k_TempReservedIds.Add(i);
            }

            return k_TempReservedIds;
        }

        void SolveShared(Dictionary<int, float>[] ratings, HashSet<int> sharedIndexes)
        {
            foreach (var sharedIndex in sharedIndexes)
            {
                var sharedRatings = ratings[sharedIndex];
                var enumerator = sharedRatings.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    var sharedKvp = enumerator.Current;
                    m_CandidateDataIds[sharedIndex] = sharedKvp.Key;
                }
                else
                {
                    // no candidates left for this shared query, so assign an invalid data ID
                    m_CandidateDataIds[sharedIndex] = (int)ReservedDataIDs.Invalid;
                }
                enumerator.Dispose();
            }
        }

        /// <summary>
        /// Construct the initial map of how each data Id has been requested in the working query set.
        /// </summary>
        /// <param name="workingIndices">Indices of queries in the working set</param>
        /// <param name="ratings">A mapping of data id to score for all queries</param>
        /// <param name="exclusivities">The exclusivity rules for all queries</param>
        /// <returns></returns>
        internal Dictionary<int, DataIdRequestMap> BuildRequestMap(List<int> workingIndices,
            Dictionary<int, float>[] ratings, Exclusivity[] exclusivities)
        {
            var requests = m_RequestMaps;
            foreach (var i in workingIndices)
            {
                var matchRatingsForQuery = ratings[i];
                if (matchRatingsForQuery.Count == 0)
                    continue;

                var exclusivity = exclusivities[i];
                var kvp = matchRatingsForQuery.First();
                var dataId = kvp.Key;
                DataIdRequestMap indices;
                switch (exclusivity)
                {
                    case Exclusivity.Shared:
                        m_GlobalSharedIndexSet.Add(i);
                        break;
                }

                if (requests.TryGetValue(dataId, out indices))
                {
                    indices.Add(i, exclusivity);
                }
                else
                {
                    // This data id was not previously in the request map, because
                    // it was not any query's best match before conflicts were considered.
                    var requestMap = m_RequestMapPool.Get();
                    requestMap.Add(i, exclusivity);
                    requests[dataId] = requestMap;
                }
            }

            return requests;
        }

        internal override void OnCycleStart()
        {
            base.OnCycleStart();
            Clear();
        }
    }

    class FindBestStandaloneMatchStage : QueryStage<FindBestMatchTransform>
    {
        public FindBestStandaloneMatchStage(FindBestMatchTransform transformation)
            : base("Standalone Best Match Finding", transformation)
        {
        }
    }
}

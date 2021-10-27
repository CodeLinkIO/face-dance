using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;

namespace Unity.MARS.Query
{
    class DataAvailabilityTransform : DataTransform<
        Dictionary<int, HashSet<int>>,
        Dictionary<int, QueryMatchID>,
        Dictionary<int, int>,
        QueryMatchID[],
        Exclusivity[],
        HashSet<int>[]>
    {
        static int[] s_IDsToRemove = new int[MARSMemoryOptions.RemovalBufferSize];

#if UNITY_EDITOR
        public readonly Dictionary<QueryMatchID, List<int>> DebugFilteredResults =
                new Dictionary<QueryMatchID, List<int>>();
#endif

        public DataAvailabilityTransform()
        {
            Process = FilterAvailableDataStage;
        }

        internal void FilterAvailableDataStage(List<int> indices,
            Dictionary<int, HashSet<int>> dataUsedByQueries,
            Dictionary<int, QueryMatchID> reservedData,
            Dictionary<int, int> sharedDataUsers,
            QueryMatchID[] queryIds,
            Exclusivity[] exclusivity,
            ref HashSet<int>[] matchingIdSets)
        {
#if UNITY_EDITOR
            RecycleFilteredLists();
#endif
            foreach (var i in indices)
            {
                Filter(dataUsedByQueries, reservedData, sharedDataUsers, matchingIdSets[i], queryIds[i], exclusivity[i]);
            }
        }

        void Filter(Dictionary<int, HashSet<int>> dataUsedByQueries,
                    Dictionary<int, QueryMatchID> reservedData,
                    Dictionary<int, int> sharedDataUsers,
                    HashSet<int> dataIDs, QueryMatchID matchId, Exclusivity exclusivity)
        {
            if(s_IDsToRemove.Length < dataIDs.Count)
                Array.Resize(ref s_IDsToRemove, dataIDs.Count + MARSMemoryOptions.ResizeHeadroom);

            var removeCounter = 0;
            var queryId = matchId.queryID;

            // Data should not be used again if this query is already using it
            if (dataUsedByQueries.TryGetValue(queryId, out var dataUsedByQuery))
            {
                dataIDs.ExceptWithNonAlloc(dataUsedByQuery);
            }

            var isReadOnly = exclusivity == Exclusivity.ReadOnly;
            // read only matches are valid if not already used by the query, so we're done with this one
            if (!isReadOnly)
            {
                var isShared = exclusivity == Exclusivity.Shared;
                foreach (var dataID in dataIDs)
                {
                    var idIsPreviouslyReserved = reservedData.ContainsKey(dataID);
                    // if it's previously reserved, neither shared nor reserved can use it
                    if (idIsPreviouslyReserved)
                    {
                        s_IDsToRemove[removeCounter] = dataID;
                        removeCounter++;
                        continue;
                    }
                    // if this query is reserved & something has previously used it as shared, can't use it
                    if (!isShared && sharedDataUsers.ContainsKey(dataID))
                    {
                        s_IDsToRemove[removeCounter] = dataID;
                        removeCounter++;
                    }
                }
            }

#if UNITY_EDITOR
            if (removeCounter > 0)
            {
                // collect information about what, if anything, got filtered, for editor debug purposes
                var filteredList = Pools.IntLists.Get();
                for (var j = 0; j < removeCounter; j++)
                {
                    filteredList.Add(s_IDsToRemove[j]);
                }

                DebugFilteredResults.Add(matchId, filteredList);
            }
#endif
            for (int i = 0; i < removeCounter; i++)
            {
                dataIDs.Remove(s_IDsToRemove[i]);
            }

        }

#if UNITY_EDITOR
        void RecycleFilteredLists()
        {
            foreach (var kvp in DebugFilteredResults)
            {
                Pools.IntLists.Recycle(kvp.Value);
            }

            DebugFilteredResults.Clear();
        }
#endif
    }

    /// <summary>
    /// Filters out any data that is not available for use due to previous queries' data ownership.
    /// </summary>
    class DataAvailabilityCheckStage : QueryStage<DataAvailabilityTransform>
    {
        public DataAvailabilityCheckStage(DataAvailabilityTransform transformation)
            : base("Data Availability Check", transformation)
        {
        }
    }
}

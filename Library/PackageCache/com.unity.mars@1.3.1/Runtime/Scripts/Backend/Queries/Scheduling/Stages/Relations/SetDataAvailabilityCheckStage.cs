using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;

namespace Unity.MARS.Query
{
    class CheckSetDataAvailabilityTransform : DataTransform<
        int[][],
        Dictionary<int, HashSet<int>>,
        Dictionary<int, QueryMatchID>,
        Dictionary<int, int>,
        QueryMatchID[],
        Exclusivity[],
        HashSet<int>[]>
    {
        static int[] s_IdsToRemove = new int[MARSMemoryOptions.RemovalBufferSize];
        static readonly HashSet<int> k_IndicesToRemove = new HashSet<int>();

        public CheckSetDataAvailabilityTransform()
        {
            Process = FilterAvailableDataStage;
        }

        internal void FilterAvailableDataStage(List<int> workingIndices,
            int[][] memberIndices,
            Dictionary<int, HashSet<int>> dataUsedByQueries,
            Dictionary<int, QueryMatchID> reservedData,
            Dictionary<int, int> sharedDataUsers,
            QueryMatchID[] queryIds,
            Exclusivity[] exclusivity,
            ref HashSet<int>[] matchingIdSets)
        {
            k_IndicesToRemove.Clear();
            foreach (var i in workingIndices)
            {
                var members = memberIndices[i];
                var queryMatchId = queryIds[i];

                if (dataUsedByQueries.TryGetValue(queryMatchId.queryID, out var dataUsedByQuery))
                {
                    foreach (var memberIndex in members)
                    {
                        var dataIDs = matchingIdSets[memberIndex];
                        // Data should not be used again if this query is already using it
                        dataIDs.ExceptWithNonAlloc(dataUsedByQuery);
                    }
                }

                foreach (var mi in members)
                {
                    if (!FilterMember(reservedData, sharedDataUsers, matchingIdSets[mi], exclusivity[mi]))
                        k_IndicesToRemove.Add(i);
                }
            }
        }

        static bool FilterMember(Dictionary<int, QueryMatchID> reservedData,
                          Dictionary<int, int> sharedDataUsers,
                          HashSet<int> dataIDs, Exclusivity exclusivity)
        {
            if (s_IdsToRemove.Length < dataIDs.Count)
                Array.Resize(ref s_IdsToRemove, dataIDs.Count + MARSMemoryOptions.ResizeHeadroom);

            var removeCounter = 0;
            var isReadOnly = exclusivity == Exclusivity.ReadOnly;
            // read only matches are valid if not already used by the query, so we're done with this one
            if (!isReadOnly)
            {
                var isShared = exclusivity == Exclusivity.Shared;
                foreach (var dataId in dataIDs)
                {
                    var idIsPreviouslyReserved = reservedData.ContainsKey(dataId);
                    // if it's previously reserved, neither shared nor reserved can use it
                    if (idIsPreviouslyReserved)
                    {
                        s_IdsToRemove[removeCounter] = dataId;
                        removeCounter++;
                        continue;
                    }

                    // if this query is reserved & something has previously used it as shared, can't use it
                    if (!isShared && sharedDataUsers.ContainsKey(dataId))
                    {
                        s_IdsToRemove[removeCounter] = dataId;
                        removeCounter++;
                    }
                }
            }

            for (int i = 0; i < removeCounter; i++)
            {
                dataIDs.Remove(s_IdsToRemove[i]);
            }

            // as int as there are any data ids remaining in the set, then this query passes this stage
            return dataIDs.Count != 0;
        }
    }

    /// <summary>
    /// Filters out any data that is not available for use due to previous queries' data ownership.
    /// </summary>
    class SetDataAvailabilityCheckStage : QueryStage<CheckSetDataAvailabilityTransform>
    {
        public SetDataAvailabilityCheckStage(CheckSetDataAvailabilityTransform transformation)
            : base("Set Data Availability Check", transformation)
        {
        }
    }
}

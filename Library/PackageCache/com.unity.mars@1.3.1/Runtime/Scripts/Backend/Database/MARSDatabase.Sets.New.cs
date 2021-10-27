using System.Collections.Generic;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data
{
    public partial class MARSDatabase
    {
        internal Dictionary<int, PreviousSetMatches> SetDataUsedByQueries { get; private set;} =
            new Dictionary<int, PreviousSetMatches>(12);

        internal Dictionary<QueryMatchID, HashSet<int>> SetDataUsedByQueryMatches { get; private set;} =
            new Dictionary<QueryMatchID,  HashSet<int>>(24);

        public void MarkSetDataUsedForUpdates(QueryMatchID queryMatchId, HashSet<int> data)
        {
            var module = ModuleLoaderCore.instance.GetModule<QueryPipelinesModule>();
            if (module == null)
                return;

            var setPipe = module.GroupPipeline;
            if (!setPipe.Data.MatchIdToIndex.TryGetValue(queryMatchId, out var setIndex))
                return;

            if (SetDataUsedByQueryMatches.ContainsKey(queryMatchId))
            {
                Debug.LogErrorFormat(
                    "Query '{0}' is already using set data. If you wish to mark new data as used, " +
                    "first call UnmarkSetDataUsedForUpdates with this query ID.", queryMatchId);
                return;
            }

            // duplicate input into owned buffer:
            {
                var newBuffer = Pools.DataIdHashSets.Get();
                newBuffer.Clear();
                foreach (var i in data)
                    newBuffer.Add(i);
                data = newBuffer;
            }

            SetDataUsedByQueryMatches[queryMatchId] = data;
            var queryId = queryMatchId.queryID;
            if (SetDataUsedByQueries.TryGetValue(queryId, out var dataUsedByQuery))
                dataUsedByQuery.Add(data);
            else
            {
                dataUsedByQuery = new PreviousSetMatches(data.Count);
                dataUsedByQuery.Add(data);
                SetDataUsedByQueries[queryId] = dataUsedByQuery;
            }

            var memberIndices = setPipe.Data.MemberIndices[setIndex];
            var memberData = setPipe.MemberData;
            foreach (var mi in memberIndices)
            {
                var assignedId = memberData.BestMatchDataIds[mi];
                var exclusivity = memberData.Exclusivities[mi];
                ReserveDataForQueryMatch(assignedId, queryMatchId, exclusivity);
            }
        }

        public void UnmarkSetDataUsedForUpdates(QueryMatchID queryMatchId)
        {
            if (SetDataUsedByQueryMatches.TryGetValue(queryMatchId, out var dataUsedByQueryMatch))
            {
                foreach (var id in dataUsedByQueryMatch)
                {
                    UnreserveDataForQueryMatch(id, queryMatchId);
                }

                dataUsedByQueryMatch.Clear();
                SetDataUsedByQueryMatches.Remove(queryMatchId);
            }

            var queryId = queryMatchId.queryID;
            if (SetDataUsedByQueries.TryGetValue(queryId, out var dataUsedByQuery))
            {
                dataUsedByQuery.Remove(dataUsedByQueryMatch);
                if (dataUsedByQuery.Count == 0)
                    SetDataUsedByQueries.Remove(queryId);
            }
        }

        public void UnmarkPartialSetDataUsedForUpdates(QueryMatchID queryMatchId, ICollection<IMRObject> childrenToUnmark)
        {
            if (!SetDataUsedByQueryMatches.TryGetValue(queryMatchId, out var dataUsedByQueryMatch))
                return;

            var module = ModuleLoaderCore.instance.GetModule<QueryPipelinesModule>();
            var setPipe = module.GroupPipeline;
            if (!setPipe.Data.MatchIdToIndex.TryGetValue(queryMatchId, out var setIndex))
            {
                // Query IDs should be found in both of those collections, or neither of them, but just in case
                SetDataUsedByQueryMatches.Remove(queryMatchId);
                Pools.DataIdHashSets.Recycle(dataUsedByQueryMatch);
                return;
            }

            var memberIndices = setPipe.Data.MemberIndices[setIndex];
            var memberData = setPipe.MemberData;
            foreach (var mi in memberIndices)
            {
                var objectRef = setPipe.MemberData.ObjectReferences[mi];
                if (!childrenToUnmark.Contains(objectRef))
                    continue;

                var assignedId = memberData.BestMatchDataIds[mi];
                UnreserveDataForQueryMatch(assignedId, queryMatchId);
                dataUsedByQueryMatch.Remove(assignedId);
            }

            if (dataUsedByQueryMatch.Count == 0)
            {
                // this was the last remaining member of the group, so remove the group from the 'used by' map
                SetDataUsedByQueryMatches.Remove(queryMatchId);
                Pools.DataIdHashSets.Recycle(dataUsedByQueryMatch);
            }

            var setMatchData = setPipe.Data.SetMatchData[setIndex];
            foreach (var child in childrenToUnmark)
            {
                setMatchData.dataAssignments.Remove(child);
            }
        }
        
        public bool IsSetQueryDataDirty(QueryMatchID queryMatchId)
        {
            if (!SetDataUsedByQueryMatches.TryGetValue(queryMatchId, out var setData))
                return false;

            foreach (var id in setData)
            {
                if (QueryDataDirty(id, queryMatchId))
                    return true;
            }

            return false;
        }

        internal void MarkGroupDataUsedAction(List<int> workingGroupIndices, int[][] allMemberIndices,
            QueryMatchID[] groupMatchIds,
            HashSet<int>[] allSetDataUsed,
            SetMatchData[] allSetMatchData,
            int[] allMemberDataIds,
            IMRObject[] allMemberObjects,
            ref Exclusivity[] allMemberExclusivities)
        {
            foreach (var i in workingGroupIndices)
            {
                var usedSet = allSetDataUsed[i];
                usedSet.Clear();

                var matchData = allSetMatchData[i];
                matchData.dataAssignments.Clear();
                foreach (var mi in allMemberIndices[i])
                {
                    var id = allMemberDataIds[mi];
                    usedSet.Add(id);
                    matchData.dataAssignments.Add(allMemberObjects[mi], id);
                }

                MarkSetDataUsedForUpdates(groupMatchIds[i], usedSet);
            }
        }
    }
}

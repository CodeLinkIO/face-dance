using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    partial class MARSQueryBackend
    {
        internal bool RemoveAssociatedDataStandalone(QueryMatchID queryMatchID)
        {
            int index;
            if(!Pipeline.Data.MatchIdToIndex.TryGetValue(queryMatchID, out index))
                return false;

            var matchFound = Pipeline.Data.UpdatingIndices.Contains(index);
            if (matchFound)
                this.UnmarkDataUsedForUpdates(queryMatchID);

            return matchFound;
        }

        internal bool RemoveAssociatedDataGroup(QueryMatchID queryMatchID, bool allMatches)
        {
            var groupData = m_PipelinesModule.GroupPipeline.Data;
            if(!groupData.MatchIdToIndex.TryGetValue(queryMatchID, out var index))
                return false;

            if (allMatches)
            {
                foreach (var activeQueryID in groupData.QueryMatchIds)
                {
                    if (activeQueryID.SameQuery(queryMatchID))
                        this.UnmarkSetDataUsedForUpdates(activeQueryID);;
                }
            }
            else
            {
                this.UnmarkSetDataUsedForUpdates(queryMatchID);
            }

            return true;
        }

        internal bool UnregisterQuery(QueryMatchID queryMatchID, bool allMatches)
        {
            // any requests for removal that come in while the pipeline is running are buffered until afterwards
            if (m_PipelinesModule.State != QueryPipelinesModule.AcquireCycleState.UpdatesOnly)
            {
                EnqueueUpdate(new BufferedAction(BufferedAction.ActionKind.RemoveSingle, queryMatchID));
                return true;
            }

            var matchFound = RemoveAssociatedDataStandalone(queryMatchID);

            RemoveQuery(queryMatchID);

            return matchFound;
        }


        internal bool UnregisterSetQuery(QueryMatchID queryMatchID, bool allMatches)
        {
            // any requests for removal that come in while the pipeline is running are buffered until afterwards
            if (m_PipelinesModule.State != QueryPipelinesModule.AcquireCycleState.UpdatesOnly)
            {
                EnqueueUpdate(new BufferedAction(BufferedAction.ActionKind.RemoveGroup, queryMatchID));
                return true;
            }

            var result = RemoveAssociatedDataGroup(queryMatchID, allMatches);

            RemoveSetQuery(queryMatchID, allMatches);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    partial class MARSQueryBackend
    {
        static readonly HashSet<int> k_TempFilterSet = new HashSet<int>();

        bool TryAssignStandaloneMatch(QueryMatchID queryMatchId, int newDataId, bool matchConditions = true)
        {
            var data = m_PipelinesModule.StandalonePipeline.Data;
            if (!data.MatchIdToIndex.TryGetValue(queryMatchId, out var index))
            {
                throw new ArgumentException($"{queryMatchId} is not registered, so cannot have a match assigned");
            }

            // the bare minimum requirement for a new data match to be valid is that it has every trait required by the Proxy
            var traitRequirements = data.TraitRequirements[index];
            if (!DataHasAllTraitRequirements(newDataId, traitRequirements))
                throw new ArgumentException($"Data ID \"{newDataId}\" does not have all traits required by {queryMatchId}");

            if (matchConditions)
            {
                if (!m_Database.DataPassesAllConditions(data.Conditions[index], newDataId))
                    throw new ArgumentException($"Data ID \"{newDataId}\" did not pass every Condition for {queryMatchId}");
            }

            var exclusivity = data.Exclusivities[index];
            // manual matches must still obey data availability
            if (!m_Database.DataAvailableForUse(newDataId, queryMatchId.queryID, exclusivity))
                throw new ArgumentException($"Data ID \"{newDataId}\" is not available for use by {queryMatchId}");

            // all validity checks have passed, so unmatch the previous data if any
            var previouslyAssignedDataId = data.BestMatchDataIds[index];
            var hasExistingMatch = previouslyAssignedDataId != (int) ReservedDataIDs.Invalid;

            if (hasExistingMatch)
            {
                UnsetStandaloneMatch(queryMatchId, false, false);
            }
            else
            {
                data.UpdatingIndices.Add(index);
                data.AcquiringIndices.Remove(index);
            }
            
            UnsetStandaloneMatchIndices.Remove(index);

            // claim the new data id for this proxy
            m_Database.MarkDataUsedForUpdates(newDataId, queryMatchId, exclusivity);
            data.BestMatchDataIds[index] = newDataId;
            
            // fill the proxy's result with the new data
            var result = data.QueryResults[index];
            result.Clear();
            result.SetDataId(newDataId);
            m_Database.FillQueryResultRequirements(newDataId, traitRequirements, result);
            
            // if this query had previously acquired, treat setting a new match as an update rather than acquire
            if (hasExistingMatch)
                data.UpdateHandlers[index]?.Invoke(result);
            else
                data.AcquireHandlers[index].Invoke(result);
            
            return true;
        }

        bool DataHasAllTraitRequirements(int dataId, ProxyTraitRequirements traitRequirements)
        {
            k_TempFilterSet.Clear();
            k_TempFilterSet.Add(dataId);

            foreach (var trait in traitRequirements)
            {
                if (m_Database.TypeToFilterAction.TryGetValue(trait.Type, out var filterAction))
                {
                    filterAction.Invoke(trait.TraitName, k_TempFilterSet);
                    if (k_TempFilterSet.Count == 0)
                        return false;
                }
            }
            
            return k_TempFilterSet.Count == 1;
        }
    }
}

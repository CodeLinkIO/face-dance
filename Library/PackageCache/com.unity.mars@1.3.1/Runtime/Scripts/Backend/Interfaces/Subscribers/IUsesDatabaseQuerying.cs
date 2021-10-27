using System.Collections.Generic;
using Unity.MARS.Query;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides access to database querying
    /// </summary>
    public interface IUsesDatabaseQuerying
    {
    }

    delegate void MarkDataUsedForUpdatesDelegate(int dataID, QueryMatchID queryMatchID, Exclusivity exclusivity);
    delegate void UnmarkDataUsedForUpdatesDelegate(QueryMatchID queryMatchID);
    delegate bool QueryDataDirtyDelegate(QueryMatchID queryMatchID);
    delegate bool TryUpdateQueryMatchDataDelegate(int dataID, ProxyConditions conditions, ProxyTraitRequirements requirements, QueryResult result);

    delegate void MarkSetDataUsedForUpdatesDelegate(QueryMatchID queryMatchId, HashSet<int> data);

    delegate void UnmarkSetDataUsedForUpdatesDelegate(QueryMatchID queryMatchID);
    delegate void UnmarkPartialSetDataUsedForUpdatesDelegate(QueryMatchID queryMatchID, ICollection<IMRObject> childrenToUnmark);
    delegate bool IsSetQueryDataDirtyDelegate(QueryMatchID queryMatchID);

    delegate bool TryUpdateSetQueryMatchDataDelegate(SetMatchData data,
        Relations relations, SetQueryResult result, bool failOnNonRequiredChildren = false);

    static class IUsesDatabaseQueryingMethods
    {
        public static MarkDataUsedForUpdatesDelegate MarkDataUsedForUpdates { internal get; set; }
        public static UnmarkDataUsedForUpdatesDelegate UnmarkDataUsedForUpdates { internal get; set; }
        public static QueryDataDirtyDelegate QueryDataDirty { internal get; set; }
        public static TryUpdateQueryMatchDataDelegate TryUpdateQueryMatchData { internal get; set; }
        public static MarkSetDataUsedForUpdatesDelegate MarkSetDataUsedForUpdates { internal get; set; }
        public static UnmarkSetDataUsedForUpdatesDelegate UnmarkSetDataUsedForUpdates { internal get; set; }
        public static UnmarkPartialSetDataUsedForUpdatesDelegate UnmarkPartialSetDataUsedForUpdates { internal get; set; }
        public static IsSetQueryDataDirtyDelegate IsSetQueryDataDirty { internal get; set; }
        public static TryUpdateSetQueryMatchDataDelegate TryUpdateSetQueryMatchData { internal get; set; }
    }

    /// <summary>
    /// Extension methods for <c>IUsesDatabaseQuerying</c> interface
    /// </summary>
    public static class IUsesDatabaseQueryingExtensionMethods
    {
        /// <summary>
        /// Tells the database that data will be used to update a query match
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="dataID">ID for the data used by a query match</param>
        /// <param name="queryMatchID">ID of the query match using this data</param>
        /// <param name="exclusivity">Specification of how the data should be reserved</param>
        public static void MarkDataUsedForUpdates(this IUsesDatabaseQuerying obj, int dataID, QueryMatchID queryMatchID, Exclusivity exclusivity)
        {
            IUsesDatabaseQueryingMethods.MarkDataUsedForUpdates(dataID, queryMatchID, exclusivity);
        }

        /// <summary>
        /// Tells the database that data is no longer used by a query match
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="queryMatchID">ID of the query match no longer using its data</param>
        public static void UnmarkDataUsedForUpdates(this IUsesDatabaseQuerying obj, QueryMatchID queryMatchID)
        {
            IUsesDatabaseQueryingMethods.UnmarkDataUsedForUpdates(queryMatchID);
        }

        /// <summary>
        /// Checks whether data used by a query match has changed
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="queryMatchID">ID of the query match using data</param>
        /// <returns>True if the data has changed, false otherwise</returns>
        public static bool QueryDataDirty(this IUsesDatabaseQuerying obj, QueryMatchID queryMatchID)
        {
            return IUsesDatabaseQueryingMethods.QueryDataDirty(queryMatchID);
        }

        /// <summary>
        /// Tries to fill out a QueryResult with updated data for a query that has been matched.
        /// This also checks if the data no longer meets the given conditions.
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="dataID">ID for the data used by the query match</param>
        /// <param name="conditions">Criteria that the data must continue to meet</param>
        /// <param name="requirements">Requirements for the given conditions</param>
        /// <param name="result">Object that will contain the updated data that still matches the conditions</param>
        /// <returns>True if the data still matches the conditions, false otherwise</returns>
        public static bool TryUpdateQueryMatchData(this IUsesDatabaseQuerying obj, int dataID, ProxyConditions conditions, ProxyTraitRequirements requirements, QueryResult result)
        {
            return IUsesDatabaseQueryingMethods.TryUpdateQueryMatchData(dataID, conditions, requirements, result);
        }

        /// <summary>
        /// Tells the database that data will be used to update a set query match
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="queryMatchID">ID of the query match using this data</param>
        /// <param name="data">Specification of which data is used for each set child</param>
        public static void MarkSetDataUsedForUpdates(this IUsesDatabaseQuerying obj, QueryMatchID queryMatchID, HashSet<int> data)
        {
            IUsesDatabaseQueryingMethods.MarkSetDataUsedForUpdates(queryMatchID, data);
        }

        /// <summary>
        /// Tells the database that data is no longer used by a set query match
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="queryMatchID">ID of the query match no longer using its data</param>
        public static void UnmarkSetDataUsedForUpdates(this IUsesDatabaseQuerying obj, QueryMatchID queryMatchID)
        {
            IUsesDatabaseQueryingMethods.UnmarkSetDataUsedForUpdates(queryMatchID);
        }

        /// <summary>
        /// Tells the database that a certain set of child data is no longer used by a set query match.
        /// This should be used when a set's non-required children are lost, in order to free up their data.
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="queryMatchID">ID of the query match no longer using some of its data</param>
        /// <param name="childrenToUnmark">Collection of child MR objects whose data should be unmarked</param>
        public static void UnmarkPartialSetDataUsedForUpdates(this IUsesDatabaseQuerying obj, QueryMatchID queryMatchID,
            ICollection<IMRObject> childrenToUnmark)
        {
            IUsesDatabaseQueryingMethods.UnmarkPartialSetDataUsedForUpdates(queryMatchID, childrenToUnmark);
        }

        /// <summary>
        /// Checks whether data used by a set query match has changed
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="queryMatchID">ID of the query match using data</param>
        /// <returns>True if any of the set's data has changed, false otherwise</returns>
        public static bool IsSetQueryDataDirty(this IUsesDatabaseQuerying obj, QueryMatchID queryMatchID)
        {
            return IUsesDatabaseQueryingMethods.IsSetQueryDataDirty(queryMatchID);
        }

        /// <summary>
        /// Tries to fill out a SetQueryResult with updated data for a query that has been matched.
        /// This also checks if the data no longer meets the given relations.
        /// </summary>
        /// <param name="obj">The object making the database query.</param>
        /// <param name="data">Specification of which data is used for each set child</param>
        /// <param name="relations">Bi-directional constraints that the data must continue to meet</param>
        /// <param name="result">Object that will contain the updated data that still matches the relations,
        /// as well as a list of non-required children that were lost during this update</param>
        /// <returns>True if the data still matches the relations, false otherwise</returns>
        public static bool TryUpdateSetQueryMatchData(this IUsesDatabaseQuerying obj, SetMatchData data,
            Relations relations, SetQueryResult result)
        {
            return IUsesDatabaseQueryingMethods.TryUpdateSetQueryMatchData(data, relations, result);
        }
    }
}

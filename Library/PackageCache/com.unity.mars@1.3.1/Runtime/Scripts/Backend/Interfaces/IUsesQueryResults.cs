namespace Unity.MARS.Query
{
    /// <summary>
    /// A class that implements IUsesQueryResults gains the ability to register with the MARS backend for different events relating to real world data
    /// </summary>
    public interface IUsesQueryResults : IUsesMarsSceneEvaluation { }

    delegate QueryMatchID RegisterQueryDelegate(QueryArgs queryArgs);
    delegate bool UnregisterQueryDelegate(QueryMatchID queryMatchID, bool allMatches = false);
    delegate bool AssignQueryMatchDelegate(QueryMatchID queryMatchId, int newMatchId, bool matchConditions = true);
    delegate bool UnsetQueryMatchDelegate(QueryMatchID queryMatchId, bool searchForNewMatch = true);
    delegate void ModifyQueryDelegate(QueryMatchID queryMatchID, QueryArgs queryArgs);

    static class IUsesQueryResultsMethods
    {
        public static RegisterQueryDelegate RegisterQuery { get; internal set; }
        public static UnregisterQueryDelegate UnregisterQuery { get; internal set; }
        public static AssignQueryMatchDelegate AssignQueryMatch { get; internal set; }
        public static UnsetQueryMatchDelegate UnmatchStandaloneProxy { get; internal set; }
        public static ModifyQueryDelegate ModifyQuery { get; internal set; }
    }

    /// <summary>
    /// Extension methods for <c>IUsesQueryResults</c> interface
    /// </summary>
    public static class IUsesQueryResultsExtensionMethods
    {
        /// <summary>
        /// Registers to get event(s) from the MARS backend
        /// </summary>
        /// <param name="caller">The object making the query</param>
        /// <param name="queryArgs">The different specified data requirements we are querying for</param>
        /// <returns>A ID that identifies this series of queries</returns>
        public static QueryMatchID RegisterQuery(this IUsesQueryResults caller, QueryArgs queryArgs)
        {
            return IUsesQueryResultsMethods.RegisterQuery(queryArgs);
        }

        /// <summary>
        /// Notifies the MARS backend that a particular query is no longer needed.
        /// This function is not required if the Registration was oneShot - the query will be unregistered automatically
        /// </summary>
        /// <param name="caller">The object that had made a query</param>
        /// <param name="queryMatchID">The identifier of the query</param>
        /// <param name="allMatches">Whether to unregister all matches referring to the same query as <paramref name="queryMatchID"/></param>
        /// <returns>True if the query was stopped, false if the query was not currently running</returns>
        public static bool UnregisterQuery(this IUsesQueryResults caller, QueryMatchID queryMatchID, bool allMatches = false)
        {
            return IUsesQueryResultsMethods.UnregisterQuery(queryMatchID, allMatches);
        }

        /// <summary>
        /// Try to assign a new data match to a Proxy, instead of the match being picked automatically.
        /// </summary>
        /// <param name="caller">The object that had made a query</param>
        /// <param name="queryMatchId">The query identifier to assign the match for</param>
        /// <param name="newMatchId">The identifier of the data to assign as the match</param>
        /// <param name="matchConditions">
        /// If true, all Conditions on the Proxy must be met by the new data.
        /// If false, the data only has to have all the traits required by the Proxy.
        /// </param>
        /// <returns>A description of the result of the call</returns>
        public static bool AssignQueryMatch(this IUsesQueryResults caller,
            QueryMatchID queryMatchId, int newMatchId, bool matchConditions = true)
        {
            return IUsesQueryResultsMethods.AssignQueryMatch(queryMatchId, newMatchId, matchConditions);
        }

        // This method is internal so that users call the methods on Proxy / ProxyGroup, which wrap this.
        /// <summary>
        /// Revoke the match found for a given Proxy instance, without removing it from the system.
        /// </summary>
        /// <param name="caller">The object that had made a query</param>
        /// <param name="queryMatchId">The identifier of the query match instance</param>
        /// <param name="searchForNewMatch">
        /// If true, the system will try to match the query again without prompting.
        /// If false, a new match will not be found automatically, but must be specified.
        /// </param>
        /// <returns>True if the query had a match which was unset, false if the query had not been matched yet</returns>
        internal static bool UnmatchProxy(this IUsesQueryResults caller, QueryMatchID queryMatchId, bool searchForNewMatch = true)
        {
            return IUsesQueryResultsMethods.UnmatchStandaloneProxy(queryMatchId, searchForNewMatch);
        }

        /// <summary>
        /// Notifies the MARS backend that a particular query's arguments have been modified.
        /// </summary>
        /// <param name="caller">The object making the query</param>
        /// <param name="queryMatchID">The identifier of the query</param>
        /// <param name="queryArgs">The different specified data requirements we are querying for</param>
        public static void ModifyQuery(this IUsesQueryResults caller, QueryMatchID queryMatchID, QueryArgs queryArgs)
        {
            IUsesQueryResultsMethods.ModifyQuery(queryMatchID, queryArgs);
        }
    }
}

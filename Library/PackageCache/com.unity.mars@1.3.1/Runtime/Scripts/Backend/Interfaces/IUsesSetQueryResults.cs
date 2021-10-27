namespace Unity.MARS.Query
{
    /// <summary>
    /// A class that implements IUsesSetQueryResults gains the ability to register with the MARS backend for different events
    /// relating to relations between real world data
    /// </summary>
    public interface IUsesSetQueryResults : IUsesMarsSceneEvaluation { }

    delegate QueryMatchID RegisterSetQueryDelegate(SetQueryArgs queryArgs);
    delegate void RegisterOverrideSetQueryDelegate(QueryMatchID queryMatchID, SetQueryArgs queryArgs);
    delegate bool UnregisterSetQueryDelegate(QueryMatchID queryMatchId, bool allMatches = false);
    delegate bool UnmatchNonRequiredMemberDelegate(QueryMatchID queryMatchId,  IMRObject memberProxy);
    delegate void ModifySetQueryDelegate(QueryMatchID queryMatchID, SetQueryArgs queryArgs);

    internal static class ISetQueryResultsMethods
    {
        internal static RegisterSetQueryDelegate RegisterSetQuery;
        internal static RegisterOverrideSetQueryDelegate RegisterSetOverrideQuery;
        internal static UnregisterSetQueryDelegate UnregisterSetQuery;
        internal static UnsetQueryMatchDelegate UnmatchGroupQuery;
        internal static UnmatchNonRequiredMemberDelegate UnmatchNonRequiredMember;
        internal static ModifySetQueryDelegate ModifySetQuery;
    }

    /// <summary>
    /// Extension methods for <c>IUsesSetQueryResults</c> interface
    /// </summary>
    public static class IUsesSetQueryResultsExtensionMethods
    {
        /// <summary>
        /// Called to get set event(s) from the MARS backend
        /// </summary>
        /// <param name="caller">The object making the query</param>
        /// <param name="queryArgs">The different specified data requirements we are querying for</param>
        /// <returns>A ID that identifies this series of queries</returns>
        public static QueryMatchID RegisterSetQuery(this IUsesSetQueryResults caller, SetQueryArgs queryArgs)
        {
            return ISetQueryResultsMethods.RegisterSetQuery(queryArgs);
        }

        /// <summary>
        /// Called to get set event(s) from the MARS backend
        /// Allows a user to specify a custom query ID to use - make sure it is unique!
        /// </summary>
        /// <param name="caller">The object making the query</param>
        /// <param name="queryMatchID">The identifier to use for this query</param>
        /// <param name="queryArgs">The different specified data requirements we are querying for</param>
        public static void RegisterSetQuery(this IUsesSetQueryResults caller, QueryMatchID queryMatchID, SetQueryArgs queryArgs)
        {
            ISetQueryResultsMethods.RegisterSetOverrideQuery(queryMatchID, queryArgs);
        }

        /// <summary>
        /// Notifies the MARS backend that a particular set query is no longer needed.
        /// This function is not required if the Registration was oneShot - the query will be unregistered automatically
        /// </summary>
        /// <param name="caller">The object that had made a query</param>
        /// <param name="eventMatchId">The identifier of the query</param>
        /// <param name="allMatches">Whether to unregister all matches referring to the same query as <paramref name="eventMatchId"/></param>
        /// <returns>True if the query was stopped, false if the query was not currently running</returns>
        public static bool UnregisterSetQuery(this IUsesSetQueryResults caller, QueryMatchID eventMatchId, bool allMatches = false)
        {
            return ISetQueryResultsMethods.UnregisterSetQuery(eventMatchId, allMatches);
        }

        /// <summary>
        /// Revoke the matches found for a given ProxyGroup instance
        /// </summary>
        /// <param name="caller">The object that had made a query</param>
        /// <param name="queryMatchId">The identifier of the query match instance</param>
        /// <param name="searchForNewMatch">
        /// If true, the system will try to match the query again without prompting.
        /// If false, a new match will not be found automatically, but must be specified.
        /// </param>
        /// <returns>True if the query had a match which was unset, false if the query had not been matched yet</returns>
        internal static bool UnmatchGroup(this IUsesSetQueryResults caller, QueryMatchID queryMatchId, bool searchForNewMatch = true)
        {
            return ISetQueryResultsMethods.UnmatchGroupQuery(queryMatchId, searchForNewMatch);
        }

        /// <summary>
        /// Revoke the match for a single Proxy in a group, which must not be marked as required.
        /// </summary>
        /// <param name="caller">The object that had made a query</param>
        /// <param name="queryMatchId">The identifier of the query match instance</param>
        /// <param name="memberProxy">The proxy to unmatch.</param>
        /// <returns>True if the proxy had a match that it has now given up, false otherwise</returns>
        internal static bool UnmatchNonRequiredMember(this IUsesSetQueryResults caller, QueryMatchID queryMatchId, IMRObject memberProxy)
        {
            return ISetQueryResultsMethods.UnmatchNonRequiredMember(queryMatchId, memberProxy);
        }

        /// <summary>
        /// Notifies the MARS backend that a particular set query's arguments have been modified.
        /// </summary>
        /// <param name="caller">The object making the set query.</param>
        /// <param name="queryMatchID">The identifier of the query</param>
        /// <param name="queryArgs">The different specified data requirements we are querying for</param>
        internal static void ModifySetQuery(this IUsesSetQueryResults caller, QueryMatchID queryMatchID,
            SetQueryArgs queryArgs)
        {
            ISetQueryResultsMethods.ModifySetQuery(queryMatchID, queryArgs);
        }
    }
}

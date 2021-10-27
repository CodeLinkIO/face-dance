namespace Unity.MARS.Query
{
    /// <summary>
    /// An internal/dangerous version of IUsesQueryResults that lets you influence the match ID
    /// </summary>
    interface IUsesDevQueryResults { }
    delegate void RegisterOverrideQueryDelegate(QueryMatchID queryMatchID, QueryArgs queryArgs);

    static class IUsesDevQueryResultsMethods
    {
        public static RegisterOverrideQueryDelegate RegisterOverrideQuery { get; internal set; }
    }

    /// <summary>
    /// Extension methods for <c>IUsesDevQueryResults</c> interface.
    /// </summary>
    public static class IUsesDevQueryResultsExtensionMethods
    {
        /// <summary>
        /// Registers to get event(s) from the MARS backend
        /// Allows a user to specify a custom query ID to use - make sure it is unique!
        /// </summary>
        /// <param name="caller">The object making the query</param>
        /// <param name="queryMatchID">The identifier to use for this query</param>
        /// <param name="queryArgs">The different specified data requirements we are querying for</param>
        public static void RegisterQuery(this IUsesQueryResults caller, QueryMatchID queryMatchID, QueryArgs queryArgs)
        {
            IUsesDevQueryResultsMethods.RegisterOverrideQuery(queryMatchID, queryArgs);
        }
    }
}

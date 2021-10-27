using System;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Contains all the conditions and data a user can ask for in a single request
    /// </summary>
    public class QueryArgs
    {
        /// <summary>Should other objects be able to query this same data?</summary>
        public Exclusivity exclusivity;
        /// <summary>Behavior around timing and recovery of queries</summary>
        public CommonQueryData commonQueryData;
        /// <summary>A list of traits required for this query to function</summary>
        public ProxyTraitRequirements traitRequirements;
        /// <summary>A list of configurable filters for what acceptable real world data fits this query</summary>
        public ProxyConditions conditions;

        /// <summary>
        /// Callback to trigger when data matching the query has been acquired for the first time
        /// </summary>
        public Action<QueryResult> onAcquire;
        /// <summary>
        /// Callback to trigger when data related to the query has been changed
        /// </summary>
        public Action<QueryResult> onMatchUpdate;
        /// <summary>
        /// Callback to trigger when the data related to the query has been lost
        /// </summary>
        public Action<QueryResult> onLoss;
        /// <summary>
        /// Callback to trigger if data related to the query has not been found in the specified time period
        /// </summary>
        public Action<QueryArgs> onTimeout;

        /// <inheritdoc />
        public override string ToString()
        {
            const string str = "Exclusivity: {0}\n{1}\n" +
                                "Conditions - {2}";

            return string.Format(str, exclusivity, commonQueryData, conditions);
        }
    }
}

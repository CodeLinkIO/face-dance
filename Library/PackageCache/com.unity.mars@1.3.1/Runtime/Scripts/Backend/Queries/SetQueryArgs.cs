using System;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Contains all the relations and data a user can ask for in a single request
    /// </summary>
    public class SetQueryArgs
    {
        /// <summary>Behavior around timing and recovery of queries</summary>
        public CommonQueryData commonQueryData;

        /// <summary>Bi-directional data filters for what acceptable real world data fits this query</summary>
        public Relations relations;

        /// <summary>
        /// Callback to trigger when data matching the query has been acquired for the first time
        /// </summary>
        public Action<SetQueryResult> onAcquire;
        /// <summary>
        /// Callback to trigger when data related to the query has been changed
        /// </summary>
        public Action<SetQueryResult> onMatchUpdate;
        /// <summary>
        /// Callback to trigger when the data related to the query has been lost
        /// </summary>
        public Action<SetQueryResult> onLoss;
        /// <summary>
        /// Callback to trigger if data related to the query has not been found in the specified time period
        /// </summary>
        public Action<SetQueryArgs> onTimeout;
    }
}

using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// The state of a proxy query.
    /// </summary>
    [Flags]
    [MovedFrom("Unity.MARS")]
    public enum QueryState
    {
        /// <summary>
        /// Initial state, query has not yet run.
        /// </summary>
        Unknown = 1,

        /// <summary>
        /// No query match before time out or a query match was lost and is not set to recover.
        /// </summary>
        Unavailable = 2,

        /// <summary>
        /// The proxy is looking for a match in the database.
        /// </summary>
        Querying = 4,

        /// <summary>
        /// The proxy has a match in the database.
        /// </summary>
        Tracking = 8,

        /// <summary>
        /// Happens for 1 frame/function call as the proxy moves from <c>Querying</c> to <c>Tracking</c>.
        /// </summary>
        Acquiring = Tracking | 16,

        /// <summary>
        /// A match was found previously, was lost, but the proxy is set to auto-recover and thus is querying again.
        /// </summary>
        Resuming = Querying | 32
    }
}

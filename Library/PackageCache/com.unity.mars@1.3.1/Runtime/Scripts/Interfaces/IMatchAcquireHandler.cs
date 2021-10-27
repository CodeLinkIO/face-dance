using Unity.MARS.Data;
using Unity.MARS.Simulation;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Allows a component on a Real World Object to receive callbacks for when a query match is found
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IMatchAcquireHandler : IAction, ISimulatable
    {
        /// <summary>
        /// Called when a query match has been found
        /// </summary>
        /// <param name="queryResult">Data associated with this event</param>
        void OnMatchAcquire(QueryResult queryResult);
    }
}

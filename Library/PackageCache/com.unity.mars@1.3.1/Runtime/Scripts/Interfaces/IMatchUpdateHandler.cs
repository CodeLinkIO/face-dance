using Unity.MARS.Data;
using Unity.MARS.Simulation;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Allows a component on a Real World Object to receive callbacks for when a query match's data is updated
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IMatchUpdateHandler : IAction, ISimulatable
    {
        /// <summary>
        /// Called when a query match's data has updated
        /// </summary>
        /// <param name="queryResult">Data associated with this event</param>
        void OnMatchUpdate(QueryResult queryResult);
    }
}

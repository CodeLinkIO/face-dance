using Unity.MARS.Data;
using Unity.MARS.Simulation;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Allows a component on a Set to receive callbacks for when a query match is found
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ISetMatchAcquireHandler : IAction, ISimulatable
    {
        /// <summary>
        /// Called when a query match has been found
        /// </summary>
        /// <param name="queryResult">Data associated with this event</param>
        void OnSetMatchAcquire(SetQueryResult queryResult);
    }
}

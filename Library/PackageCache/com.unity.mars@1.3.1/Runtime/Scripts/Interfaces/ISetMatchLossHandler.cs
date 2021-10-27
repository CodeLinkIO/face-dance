using Unity.MARS.Data;
using Unity.MARS.Simulation;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Allows a component on a Set to receive callbacks for when a query match is lost
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ISetMatchLossHandler : IAction, ISimulatable
    {
        /// <summary>
        /// Called when a query match has been lost
        /// </summary>
        /// <param name="queryResult">Data associated with this event</param>
        void OnSetMatchLoss(SetQueryResult queryResult);
    }
}

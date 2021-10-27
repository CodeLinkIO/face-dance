using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Defines an action that controls the visible/enabled state of objects
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IMatchVisibilityHandler : IAction, ISimulatable
    {
        /// <summary>
        /// Called when an object should decide whether or not objects it is associated with should be visible
        /// </summary>
        /// <param name="newState">The tracking state this object is switching to</param>
        /// <param name="queryResult">Data associated with this event</param>
        /// <param name="objectsToActivate">List that stores which objects this handler wants to enable</param>
        /// <param name="objectsToDeactivate">List that stores which objects this handler wants to disable</param>
        void FilterVisibleObjects(QueryState newState, QueryResult queryResult, List<GameObject> objectsToActivate, List<GameObject> objectsToDeactivate);
    }
}

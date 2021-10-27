using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Actions
{
    [HelpURL(DocumentationConstants.ShowChildrenOnTrackingActionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Activates children if the parent Real World Object is tracked; disables children otherwise.")]
    [MonoBehaviourComponentMenu(typeof(ShowChildrenOnTrackingAction), "Action/Show Objects on Tracking")]
    [MovedFrom("Unity.MARS")]
    public class ShowChildrenOnTrackingAction : MonoBehaviour, IMatchVisibilityHandler
    {
        /// <summary>
        /// Shows and hides child objects based on a parent's tracking of AR Data
        /// </summary>
        /// <param name="newState">The current state of the parent object</param>
        /// <param name="queryResult">Query data associated with the state change</param>
        /// <param name="objectsToActivate">A list containing objects that should be activated</param>
        /// <param name="objectsToDeactivate">A list containing objects which should be set to inactive</param>
        void IMatchVisibilityHandler.FilterVisibleObjects(QueryState newState, QueryResult queryResult, List<GameObject> objectsToActivate, List<GameObject> objectsToDeactivate)
        {
            if (!this) // object may have been destroyed
                return;

            switch (newState)
            {
                case QueryState.Acquiring:
                    foreach (Transform child in transform)
                    {
                        objectsToActivate.Add(child.gameObject);
                    }

                    break;
                case QueryState.Resuming:
                case QueryState.Unavailable:
                case QueryState.Unknown:
                    foreach (Transform child in transform)
                    {
                        objectsToDeactivate.Add(child.gameObject);
                    }

                    break;
            }
        }
    }
}

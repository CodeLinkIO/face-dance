using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Unity.XRTools.ModuleLoader;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Body Tracking Provider
    /// This functionality provider is responsible for body tracking
    /// </summary>
    [MovedFrom("Unity.MARS")]
    [Obsolete(IUsesBodyTrackingMethods.ProviderObsoleteMessage)]
    public interface IProvidesBodyTracking : IFunctionalityProvider
    {
        /// <summary>
        /// Called when a body become tracked for the first time
        /// </summary>
        event Action<MRBody> bodyAdded;

        /// <summary>
        /// Called when a tracked body has updated data
        /// </summary>
        event Action<MRBody> bodyUpdated;

        /// <summary>
        /// Called when a tracked body is removed (lost)
        /// </summary>
        event Action<MRBody> bodyRemoved;

        /// <summary>
        /// Get the currently tracked bodies
        /// </summary>
        /// <param name="bodies">A list of MRRect objects to which the currently tracked bodies will be added</param>
        void GetBodies(List<MRBody> bodies);

        /// <summary>
        /// Track body at specified position
        /// </summary>
        /// <param name="position">Position of the tracked body</param>
        void TrackBody(Vector2 position);
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Body Tracking Provider
    /// This functionality provider is responsible for body tracking
    /// </summary>
    public interface IProvidesMarsBodyTracking : IFunctionalityProvider
    {
        /// <summary>
        /// Called when a body becomes tracked for the first time
        /// </summary>
        event Action<IMarsBody> BodyAdded;

        /// <summary>
        /// Called when a tracked body has updated data
        /// </summary>
        event Action<IMarsBody> BodyUpdated;

        /// <summary>
        /// Called when a tracked body is removed (lost)
        /// </summary>
        event Action<IMarsBody> BodyRemoved;

        /// <summary>
        /// Get the currently tracked bodies
        /// </summary>
        /// <param name="bodies">A list of IMarsBody objects to which the currently tracked bodies will be added</param>
        void GetBodies(List<IMarsBody> bodies);
    }
}

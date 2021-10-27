using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Compass Heading Provider
    /// This functionality provider is responsible for compass headings
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesCompassHeading : IFunctionalityProvider
    {
        /// <summary>
        /// Called when the compass heading changes
        /// </summary>
        event Action<float> headingUpdated;

        /// <summary>
        /// Get the current compass heading
        /// </summary>
        /// <returns>The compass heading</returns>
        float GetHeading();
    }
}

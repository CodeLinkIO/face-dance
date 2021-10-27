using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Light Estimation Provider
    /// This functionality provider is responsible for light estimation
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesLightEstimation : IFunctionalityProvider
    {
        /// <summary>
        /// Called when the light estimation changes
        /// </summary>
        event Action<MRLightEstimation> lightEstimationUpdated;

        /// <summary>
        /// Try to get the light estimation data
        /// </summary>
        /// <param name="lightEstimation">The light estimation data</param>
        /// <returns></returns>
        bool TryGetLightEstimation(out MRLightEstimation lightEstimation);
    }
}

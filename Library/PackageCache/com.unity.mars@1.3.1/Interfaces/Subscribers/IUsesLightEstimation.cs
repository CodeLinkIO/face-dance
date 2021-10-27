using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to light estimation features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesLightEstimation : IFunctionalitySubscriber<IProvidesLightEstimation>
    {
    }

    /// <summary>
    /// Extension methods for light estimation users
    /// </summary>
    public static class UsesLightEstimationMethods
    {
        /// <summary>
        /// Try to get the light estimation data
        /// </summary>
        /// <param name="obj">The functionality subscriber</param>
        /// <param name="lightEstimation">The light estimation data</param>
        /// <returns>True if the operation succeeded; false if the data is not available or the feature is not supported</returns>
        public static bool TryGetLightEstimation(this IUsesLightEstimation obj, out MRLightEstimation lightEstimation)
        {
            return obj.provider.TryGetLightEstimation(out lightEstimation);
        }

        /// <summary>
        /// Subscribe to the lightEstimationUpdated event, which is invoked when the light estimation changes
        /// </summary>
        /// <param name="obj">The functionality subscriber</param>
        /// <param name="lightEstimationUpdated">The action which will be invoked when light estimation changes</param>
        public static void SubscribeLightEstimationUpdated(this IUsesLightEstimation obj, Action<MRLightEstimation> lightEstimationUpdated)
        {
            obj.provider.lightEstimationUpdated += lightEstimationUpdated;
        }

        /// <summary>
        /// Unsubscribe to the lightEstimationUpdated event, which is invoked when the light estimation changes
        /// </summary>
        /// <param name="obj">The functionality subscriber</param>
        /// <param name="lightEstimationUpdated">An action which was previously subscribed to lightEstimationUpdated</param>
        public static void UnsubscribeLightEstimationUpdated(this IUsesLightEstimation obj, Action<MRLightEstimation> lightEstimationUpdated)
        {
            obj.provider.lightEstimationUpdated -= lightEstimationUpdated;
        }
    }
}

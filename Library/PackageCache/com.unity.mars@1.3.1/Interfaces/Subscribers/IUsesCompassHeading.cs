using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to compass heading data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesCompassHeading : IFunctionalitySubscriber<IProvidesCompassHeading>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesCompassHeadingMethods
    {
        /// <summary>
        /// Get the current compass heading
        /// </summary>
        /// <returns>The compass heading</returns>
        public static float GetHeading(this IUsesCompassHeading obj)
        {
            return obj.provider.GetHeading();
        }

        /// <summary>
        /// Subscribe to the headingUpdated event, which is called when the compass heading changes
        /// </summary>
        /// <param name="headingUpdated">The delegate to subscribe</param>
        public static void SubscribeHeadingUpdated(this IUsesCompassHeading obj, Action<float> headingUpdated)
        {
            obj.provider.headingUpdated += headingUpdated;
        }

        /// <summary>
        /// Unsubscribe from the headingUpdated event, which is called when the compass heading changes
        /// </summary>
        /// <param name="headingUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribeHeadingUpdated(this IUsesCompassHeading obj, Action<float> headingUpdated)
        {
            obj.provider.headingUpdated -= headingUpdated;
        }
    }
}

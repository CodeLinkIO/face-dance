using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to body tracking features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    [Obsolete(IUsesBodyTrackingMethods.UserObsoleteMessage)]
    public interface IUsesBodyTracking : IFunctionalitySubscriber<IProvidesBodyTracking>
    {
    }

    [MovedFrom("Unity.MARS")]
    [Obsolete(UserObsoleteMessage)]
    public static class IUsesBodyTrackingMethods
    {
        internal const string ProviderObsoleteMessage = "Body tracking APIs have moved to IProvidesMarsBodyTracking";
        internal const string UserObsoleteMessage = "Body tracking APIs have moved to IUsesMarsBodyTracking";

        /// <summary>
        /// Track body at specified position
        /// </summary>
        /// <param name="center">The position (center) at which to track a body</param>
        public static void TrackBody(this IUsesBodyTracking obj, Vector2 center)
        {
            obj.provider.TrackBody(center);
        }

        /// <summary>
        /// Get the currently tracked bodies
        /// </summary>
        /// <param name="bodies">A list of MRRect objects to which the currently tracked planes will be added</param>
        public static void GetBodies(this IUsesBodyTracking obj, List<MRBody> bodies)
        {
            obj.provider.GetBodies(bodies);
        }

        /// <summary>
        /// Subscribe to the bodyAdded event, which is called whenever a body becomes tracked for the first time
        /// </summary>
        /// <param name="bodyAdded">The delegate to subscribe</param>
        public static void SubscribeBodyAdded(this IUsesBodyTracking obj, Action<MRBody> bodyAdded)
        {
            obj.provider.bodyAdded += bodyAdded;
        }

        /// <summary>
        /// Unsubscribe a delegate from the bodyAdded event
        /// </summary>
        /// <param name="bodyAdded">The delegate to unsubscribe</param>
        public static void UnsubscribeBodyAdded(this IUsesBodyTracking obj, Action<MRBody> bodyAdded)
        {
            obj.provider.bodyAdded -= bodyAdded;
        }

        /// <summary>
        /// Subscribe to the bodyUpdated event, which is called when a tracked body has updated data
        /// </summary>
        /// <param name="bodyUpdated">The delegate to subscribe</param>
        public static void SubscribeBodyUpdated(this IUsesBodyTracking obj, Action<MRBody> bodyUpdated)
        {
            obj.provider.bodyUpdated += bodyUpdated;
        }

        /// <summary>
        /// Unsubscribe a delegate from the bodyUpdated event
        /// </summary>
        /// <param name="bodyUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribeBodyUpdated(this IUsesBodyTracking obj, Action<MRBody> bodyUpdated)
        {
            obj.provider.bodyUpdated -= bodyUpdated;
        }

        /// <summary>
        /// Subscribe to the bodyRemoved event, which is called whenever a tracked body is removed (lost)
        /// </summary>
        /// <param name="bodyRemoved">The delegate to subscribe</param>
        public static void SubscribeBodyRemoved(this IUsesBodyTracking obj, Action<MRBody> bodyRemoved)
        {
            obj.provider.bodyRemoved += bodyRemoved;
        }

        /// <summary>
        /// Unsubscribe a delegate from the bodyRemoved event
        /// </summary>
        /// <param name="bodyRemoved">The delegate to unsubscribe</param>
        public static void UnsubscribeBodyRemoved(this IUsesBodyTracking obj, Action<MRBody> bodyRemoved)
        {
            obj.provider.bodyRemoved -= bodyRemoved;
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to body tracking features
    /// </summary>
    public interface IUsesMarsBodyTracking : IFunctionalitySubscriber<IProvidesMarsBodyTracking>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class UsesMarsBodyTrackingMethods
    {
        /// <summary>
        /// Get the currently tracked bodies
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodies">A list of IMarsBody objects to which the currently tracked bodies will be added</param>
        public static void GetBodies(this IUsesMarsBodyTracking user, List<IMarsBody> bodies)
        {
            user.provider.GetBodies(bodies);
        }

        /// <summary>
        /// Subscribe to the bodyAdded event, which is called whenever a body becomes tracked for the first time
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodyAdded">The delegate to subscribe</param>
        public static void SubscribeBodyAdded(this IUsesMarsBodyTracking user, Action<IMarsBody> bodyAdded)
        {
            user.provider.BodyAdded += bodyAdded;
        }

        /// <summary>
        /// Unsubscribe a delegate from the bodyAdded event
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodyAdded">The delegate to unsubscribe</param>
        public static void UnsubscribeBodyAdded(this IUsesMarsBodyTracking user, Action<IMarsBody> bodyAdded)
        {
            user.provider.BodyAdded -= bodyAdded;
        }

        /// <summary>
        /// Subscribe to the bodyUpdated event, which is called when a tracked body has updated data
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodyUpdated">The delegate to subscribe</param>
        public static void SubscribeBodyUpdated(this IUsesMarsBodyTracking user, Action<IMarsBody> bodyUpdated)
        {
            user.provider.BodyUpdated += bodyUpdated;
        }

        /// <summary>
        /// Unsubscribe a delegate from the bodyUpdated event
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodyUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribeBodyUpdated(this IUsesMarsBodyTracking user, Action<IMarsBody> bodyUpdated)
        {
            user.provider.BodyUpdated -= bodyUpdated;
        }

        /// <summary>
        /// Subscribe to the bodyRemoved event, which is called whenever a tracked body is removed (lost)
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodyRemoved">The delegate to subscribe</param>
        public static void SubscribeBodyRemoved(this IUsesMarsBodyTracking user, Action<IMarsBody> bodyRemoved)
        {
            user.provider.BodyRemoved += bodyRemoved;
        }

        /// <summary>
        /// Unsubscribe a delegate from the bodyRemoved event
        /// </summary>
        /// <param name="user">The functionality user</param>
        /// <param name="bodyRemoved">The delegate to unsubscribe</param>
        public static void UnsubscribeBodyRemoved(this IUsesMarsBodyTracking user, Action<IMarsBody> bodyRemoved)
        {
            user.provider.BodyRemoved -= bodyRemoved;
        }
    }
}

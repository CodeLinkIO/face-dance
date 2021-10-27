using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to marker tracking features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesMarkerTracking : IFunctionalitySubscriber<IProvidesMarkerTracking>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesMarkerTrackingMethods
    {
        /// <summary>
        /// Get the currently tracked markers
        /// </summary>
        /// <param name="markers">A list of MRMarker objects to which the currently tracked markers will be added</param>
        public static void GetMarkers(this IUsesMarkerTracking obj, List<MRMarker> markers)
        {
            obj.provider.GetMarkers(markers);
        }

        /// <summary>
        /// Subscribe to the markerAdded event, which is called when a marker becomes tracked for the first time
        /// </summary>
        /// <param name="markerAdded">The delegate to subscribe</param>
        public static void SubscribeMarkerAdded(this IUsesMarkerTracking obj, Action<MRMarker> markerAdded)
        {
            obj.provider.markerAdded += markerAdded;
        }

        /// <summary>
        /// Unsubscribe from the markerAdded event, which is called when a marker becomes tracked for the first time
        /// </summary>
        /// <param name="markerAdded">The delegate to unsubscribe</param>
        public static void UnsubscribeMarkerAdded(this IUsesMarkerTracking obj, Action<MRMarker> markerAdded)
        {
            obj.provider.markerAdded -= markerAdded;
        }

        /// <summary>
        /// Subscribe to the markerUpdated event, which is called when a tracked marker has updated data
        /// </summary>
        /// <param name="markerUpdated">The delegate to subscribe</param>
        public static void SubscribeMarkerUpdated(this IUsesMarkerTracking obj, Action<MRMarker> markerUpdated)
        {
            obj.provider.markerUpdated += markerUpdated;
        }

        /// <summary>
        /// Unsubscribe from the markerUpdated event, which is called when a tracked marker has updated data
        /// </summary>
        /// <param name="markerUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribeMarkerUpdated(this IUsesMarkerTracking obj, Action<MRMarker> markerUpdated)
        {
            obj.provider.markerUpdated -= markerUpdated;
        }

        /// <summary>
        /// Subscribe to the markerRemoved event, which is called when a tracked marker is removed (lost)
        /// </summary>
        /// <param name="markerRemoved">The delegate to subscribe</param>
        public static void SubscribeMarkerRemoved(this IUsesMarkerTracking obj, Action<MRMarker> markerRemoved)
        {
            obj.provider.markerRemoved += markerRemoved;
        }

        /// <summary>
        /// Unsubscribe from the markerRemoved event, which is called when a tracked marker is removed (lost)
        /// </summary>
        /// <param name="markerRemoved">The delegate to unsubscribe</param>
        public static void UnsubscribeMarkerRemoved(this IUsesMarkerTracking obj, Action<MRMarker> markerRemoved)
        {
            obj.provider.markerRemoved -= markerRemoved;
        }

        /// <summary>
        /// Stop tracking markers. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause marker tracking while maintaining camera tracking
        /// </summary>
        public static void StopTrackingMarkers(this IUsesMarkerTracking obj)
        {
            obj.provider.StopTrackingMarkers();
        }

        /// <summary>
        /// Start tracking markers. Marker tracking is enabled on initialization, so this is only necessary after
        /// calling StopTrackingMarkers.
        /// </summary>
        public static void StartTrackingMarkers(this IUsesMarkerTracking obj)
        {
            obj.provider.StartTrackingMarkers();
        }

        public static bool SetActiveMarkerLibrary(this IUsesMarkerTracking obj, IMRMarkerLibrary markerLibrary)
        {
            return obj.provider.SetActiveMarkerLibrary(markerLibrary);
        }
    }
}

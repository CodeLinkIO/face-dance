using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Marker Tracking Provider
    /// This functionality provider is responsible for marker tracking
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesMarkerTracking : IFunctionalityProvider
    {
        /// <summary>
        /// Called when a marker becomes tracked for the first time
        /// </summary>
        event Action<MRMarker> markerAdded;

        /// <summary>
        /// Called when a tracked marker has updated data
        /// </summary>
        event Action<MRMarker> markerUpdated;

        /// <summary>
        /// Called when a tracked marker is removed (lost)
        /// </summary>
        event Action<MRMarker> markerRemoved;

        /// <summary>
        /// Initialize the list of markers to look for when this marker tracking provider starts tracking.
        /// If an existing marker library is being used, this one replaces the active one and images contained
        /// in this marker library start getting detected.  The existing tracked markers will stop receiving
        /// update events, and they may be removed.
        /// </summary>
        /// <param name="activeLibrary">Marker library with list of markers to detect</param>
        /// <returns></returns>
        bool SetActiveMarkerLibrary(IMRMarkerLibrary activeLibrary);

        /// <summary>
        /// Get the currently tracked markers
        /// </summary>
        /// <param name="markers">A list of MRMarker objects to which the currently tracked markers will be added</param>
        void GetMarkers(List<MRMarker> markers);

        /// <summary>
        /// Stop tracking markers. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause marker tracking while maintaining camera tracking.
        /// </summary>
        void StopTrackingMarkers();

        /// <summary>
        /// Start tracking markers. Marker tracking is enabled on initialization, so this is only necessary after
        /// calling StopTrackingMarkers.
        /// </summary>
        void StartTrackingMarkers();
    }
}

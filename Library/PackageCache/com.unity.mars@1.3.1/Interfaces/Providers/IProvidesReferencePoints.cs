using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Reference Point Provider
    /// This functionality provider is responsible for reference point tracking
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesReferencePoints : IFunctionalityProvider
    {
        /// <summary>
        /// Called when a reference point is added the first time
        /// </summary>
        event Action<MRReferencePoint> pointAdded;

        /// <summary>
        /// Called when a reference point has updated data
        /// </summary>
        event Action<MRReferencePoint> pointUpdated;

        /// <summary>
        /// Called when a reference point is removed (lost)
        /// </summary>
        event Action<MRReferencePoint> pointRemoved;

        /// <summary>
        /// Get the full list of reference points we know about
        /// </summary>
        /// <param name="referencePoints">A list of MRReferencePoint objects to which the currently tracked reference points will be added</param>
        void GetAllReferencePoints(List<MRReferencePoint> referencePoints);

        /// <summary>
        /// Try to add a reference point
        /// </summary>
        /// <returns>true if adding the point succeeded, false otherwise</returns>
        bool TryAddReferencePoint(Pose pose, out MarsTrackableId referencePointId);

        /// <summary>
        /// Try to get a reference point
        /// </summary>
        /// <returns>true if getting the point succeeded, false otherwise</returns>
        bool TryGetReferencePoint(MarsTrackableId id, out MRReferencePoint referencePoint);

        /// <summary>
        /// Try to remove a reference point
        /// </summary>
        /// <returns>true if removing the point succeeded, false otherwise</returns>
        bool TryRemoveReferencePoint(MarsTrackableId id);

        /// <summary>
        /// Stop tracking reference points. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        void StopTrackingReferencePoints();

        /// <summary>
        /// Start tracking reference points. Reference point detection is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        void StartTrackingReferencePoints();
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Plane Finding Provider
    /// This functionality provider is responsible for plane finding
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesPlaneFinding : IFunctionalityProvider
    {
        /// <summary>
        /// Called when a plane become tracked for the first time
        /// </summary>
        event Action<MRPlane> planeAdded;

        /// <summary>
        /// Called when a tracked plane has updated data
        /// </summary>
        event Action<MRPlane> planeUpdated;

        /// <summary>
        /// Called when a tracked plane is removed (Lost)
        /// </summary>
        event Action<MRPlane> planeRemoved;

        /// <summary>
        /// Get the currently tracked planes
        /// </summary>
        /// <param name="planes">A list of MRPlane objects to which the currently tracked planes will be added</param>
        void GetPlanes(List<MRPlane> planes);

        /// <summary>
        /// Stop detecting planes. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        void StopDetectingPlanes();

        /// <summary>
        /// Start detecting planes. Plane detection is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        void StartDetectingPlanes();
    }
}

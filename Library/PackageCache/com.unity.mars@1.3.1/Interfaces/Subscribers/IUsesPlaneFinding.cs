using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to plane finding features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesPlaneFinding : IFunctionalitySubscriber<IProvidesPlaneFinding>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesPlaneFindingMethods
    {
        /// <summary>
        /// Get the currently tracked planes
        /// </summary>
        /// <param name="planes">A list of MRPlane objects to which the currently tracked planes will be added</param>
        public static void GetPlanes(this IUsesPlaneFinding obj, List<MRPlane> planes)
        {
            obj.provider.GetPlanes(planes);
        }

        /// <summary>
        /// Subscribe to the planeAdded event, which is called when a plane becomes tracked for the first time
        /// </summary>
        /// <param name="planeAdded">The delegate to subscribe</param>
        public static void SubscribePlaneAdded(this IUsesPlaneFinding obj, Action<MRPlane> planeAdded)
        {
            obj.provider.planeAdded += planeAdded;
        }

        /// <summary>
        /// Unsubscribe from the planeAdded event, which is called when a plane becomes tracked for the first time
        /// </summary>
        /// <param name="planeAdded">The delegate to unsubscribe</param>
        public static void UnsubscribePlaneAdded(this IUsesPlaneFinding obj, Action<MRPlane> planeAdded)
        {
            obj.provider.planeAdded -= planeAdded;
        }

        /// <summary>
        /// Subscribe to the planeUpdated event, which is called when a tracked plane has new data
        /// </summary>
        /// <param name="planeUpdated">The delegate to subscribe</param>
        public static void SubscribePlaneUpdated(this IUsesPlaneFinding obj, Action<MRPlane> planeUpdated)
        {
            obj.provider.planeUpdated += planeUpdated;
        }

        /// <summary>
        /// Unsubscribe from the planeUpdated event, which is called when a tracked plane has new data
        /// </summary>
        /// <param name="planeUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribePlaneUpdated(this IUsesPlaneFinding obj, Action<MRPlane> planeUpdated)
        {
            obj.provider.planeUpdated -= planeUpdated;
        }

        /// <summary>
        /// Subscribe to the planeRemoved event, which is called when a tracked plane is removed (lost)
        /// </summary>
        /// <param name="planeRemoved">The delegate to subscribe</param>
        public static void SubscribePlaneRemoved(this IUsesPlaneFinding obj, Action<MRPlane> planeRemoved)
        {
            obj.provider.planeRemoved += planeRemoved;
        }

        /// <summary>
        /// Unsubscribe from the planeRemoved event, which is called when a tracked plane is removed (lost)
        /// </summary>
        /// <param name="planeRemoved">The delegate to unsubscribe</param>
        public static void UnsubscribePlaneRemoved(this IUsesPlaneFinding obj, Action<MRPlane> planeRemoved)
        {
            obj.provider.planeRemoved -= planeRemoved;
        }

        /// <summary>
        /// Stop detecting planes. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        public static void StopDetectingPlanes(this IUsesPlaneFinding obj)
        {
            obj.provider.StopDetectingPlanes();
        }

        /// <summary>
        /// Start detecting planes. Plane detection is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        public static void StartDetectingPlanes(this IUsesPlaneFinding obj)
        {
            obj.provider.StartDetectingPlanes();
        }
    }
}

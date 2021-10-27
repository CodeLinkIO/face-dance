using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to tracked world reference points
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesReferencePoints : IFunctionalitySubscriber<IProvidesReferencePoints>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesReferencePointsMethods
    {
        /// <summary>
        /// Get all registered reference points
        /// </summary>
        /// <param name="referencePoints">A list of MRReferencePoint objects to which the currently tracked reference points will be added</param>
        public static void GetAllReferencePoints(this IUsesReferencePoints obj, List<MRReferencePoint> referencePoints)
        {
            obj.provider.GetAllReferencePoints(referencePoints);
        }

        /// <summary>
        /// Add a reference point
        /// </summary>
        /// <returns>true if adding the point succeeded, false otherwise</returns>
        public static bool TryAddReferencePoint(this IUsesReferencePoints obj, Pose pose, out MarsTrackableId referencePointId)
        {
            return obj.provider.TryAddReferencePoint(pose, out referencePointId);
        }

        /// <summary>
        /// Get a reference point
        /// </summary>
        /// <returns>true if getting the point succeeded, false otherwise</returns>
        public static bool TryGetReferencePoint(this IUsesReferencePoints obj, MarsTrackableId referencePointId, out MRReferencePoint point)
        {
            return obj.provider.TryGetReferencePoint(referencePointId, out point);
        }

        /// <summary>
        /// Remove a reference point
        /// </summary>
        /// <returns>true if removing the point succeeded, false otherwise</returns>
        public static bool TryRemoveReferencePoint(this IUsesReferencePoints obj, MarsTrackableId referencePointId)
        {
            return obj.provider.TryRemoveReferencePoint(referencePointId);
        }

        /// <summary>
        /// Subscribe to the pointAdded event, which is called when a reference point is first added
        /// </summary>
        /// <param name="pointAdded">The delegate to subscribe</param>
        public static void SubscribePointAdded(this IUsesReferencePoints obj, Action<MRReferencePoint> pointAdded)
        {
            obj.provider.pointAdded += pointAdded;
        }

        /// <summary>
        /// Unsubscribe from the pointAdded event, which is called when a reference point is first added
        /// </summary>
        /// <param name="pointAdded">The delegate to unsubscribe</param>
        public static void UnsubscribePointAdded(this IUsesReferencePoints obj, Action<MRReferencePoint> pointAdded)
        {
            obj.provider.pointAdded -= pointAdded;
        }

        /// <summary>
        /// Subscribe to the pointUpdated event, which is called when a reference point is updated
        /// </summary>
        /// <param name="pointUpdated">The delegate to subscribe</param>
        public static void SubscribePointUpdated(this IUsesReferencePoints obj, Action<MRReferencePoint> pointUpdated)
        {
            obj.provider.pointUpdated += pointUpdated;
        }

        /// <summary>
        /// Unsubscribe from the pointUpdated event, which is called when a reference point is updated
        /// </summary>
        /// <param name="pointUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribePointUpdated(this IUsesReferencePoints obj, Action<MRReferencePoint> pointUpdated)
        {
            obj.provider.pointUpdated -= pointUpdated;
        }

        /// <summary>
        /// Subscribe to the pointRemoved event, which is called when a reference point is removed
        /// </summary>
        /// <param name="pointRemoved">The delegate to subscribe</param>
        public static void SubscribePointRemoved(this IUsesReferencePoints obj, Action<MRReferencePoint> pointRemoved)
        {
            obj.provider.pointRemoved += pointRemoved;
        }

        /// <summary>
        /// Unsubscribe from the pointRemoved event, which is called when a reference point is removed
        /// </summary>
        /// <param name="pointRemoved">The delegate to unsubscribe</param>
        public static void UnsubscribePointRemoved(this IUsesReferencePoints obj, Action<MRReferencePoint> pointRemoved)
        {
            obj.provider.pointRemoved -= pointRemoved;
        }

        /// <summary>
        /// Stop tracking reference points. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        public static void StopTrackingReferencePoints(this IUsesReferencePoints obj)
        {
            obj.provider.StopTrackingReferencePoints();
        }

        /// <summary>
        /// Start tracking reference points. Point cloud detection is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        public static void StartTrackingReferencePoints(this IUsesReferencePoints obj)
        {
            obj.provider.StartTrackingReferencePoints();
        }
    }
}

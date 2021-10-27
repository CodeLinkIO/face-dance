using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to point cloud features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesPointCloud : IFunctionalitySubscriber<IProvidesPointCloud>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesPointCloudMethods
    {
        /// <summary>
        /// Get the latest available point cloud data
        /// </summary>
        /// <returns>The point cloud data</returns>
        public static Dictionary<MarsTrackableId, PointCloudData> GetPoints(this IUsesPointCloud obj)
        {
            return obj.provider.GetPoints();
        }

        /// <summary>
        /// Subscribe to the pointCloudUpdated event, which is called whenever the point cloud is updated
        /// </summary>
        /// <param name="pointCloudUpdated">The delegate to subscribe</param>
        public static void SubscribePointCloudUpdated(this IUsesPointCloud obj, Action<Dictionary<MarsTrackableId, PointCloudData>> pointCloudUpdated)
        {
            obj.provider.PointCloudUpdated += pointCloudUpdated;
        }

        /// <summary>
        /// Unsubscribe a delegate from the pointCloudUpdated event
        /// </summary>
        /// <param name="pointCloudUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribePointCloudUpdated(this IUsesPointCloud obj, Action<Dictionary<MarsTrackableId, PointCloudData>> pointCloudUpdated)
        {
            obj.provider.PointCloudUpdated -= pointCloudUpdated;
        }

        /// <summary>
        /// Stop detecting point clouds. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        public static void StopDetectingPoints(this IUsesPointCloud obj)
        {
            obj.provider.StopDetectingPoints();
        }

        /// <summary>
        /// Start detecting point clouds. Point cloud detection is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        public static void StartDetectingPoints(this IUsesPointCloud obj)
        {
            obj.provider.StartDetectingPoints();
        }
    }
}

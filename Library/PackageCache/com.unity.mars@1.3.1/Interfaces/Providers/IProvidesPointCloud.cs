using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Point Cloud Provider
    /// This functionality provider is responsible for providing a way to get current point cloud data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesPointCloud : IFunctionalityProvider
    {
        /// <summary>
        /// Get the current point cloud data
        /// </summary>
        /// <returns>The point cloud data</returns>
        Dictionary<MarsTrackableId, PointCloudData> GetPoints();

        /// <summary>
        /// Callback for point cloud updates
        /// Passes the point cloud data as an argument
        /// </summary>
        event Action<Dictionary<MarsTrackableId, PointCloudData>> PointCloudUpdated;

        /// <summary>
        /// Stop detecting point clouds. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        void StopDetectingPoints();

        /// <summary>
        /// Start detecting point clouds. Point cloud detection is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        void StartDetectingPoints();
    }
}

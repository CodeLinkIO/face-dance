using Unity.MARS;
using UnityEngine;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Utility methods for creating MARS preset objects
    /// </summary>
    public static class MarsObjectCreation
    {
        /// <summary>
        /// Create a GameObject that is set up as a MARS Proxy Object
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateProxyObjectPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.ProxyObjectPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Proxy Group
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateProxyGroupPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.ProxyGroupPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Replicator
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateReplicatorPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.ReplicatorPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Synthetic Object
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateSyntheticObjectPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.SyntheticObjectPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Horizontal Plane Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateHorizontalPlanePreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.HorizontalPlanePreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Vertical Plane Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateVerticalPlanePreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.VerticalPlanePreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Image Marker Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateImageMarkerPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.ImageMarkerPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Face Mask Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateFaceMaskPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.FaceMaskPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Floor Object Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateFloorObjectPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.FloorObjectPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Elevated Surface Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateElevatedSurfacePreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.ElevatedSurfacePreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Plane Visuals Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreatePlaneVisualsPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.PlaneVisualsPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Point Cloud Visuals Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreatePointCloudVisualsPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.PointCloudVisualsPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Face Landmark Visuals Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateFaceLandmarkVisualsPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.FaceLandmarkVisualsPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Light Estimation Visuals Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateLightEstimationVisualsPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.LightEstimationVisualsPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }

        /// <summary>
        /// Create a GameObject that is set up as a MARS Synthetic Image Marker Proxy
        /// </summary>
        /// <param name="parent">If specified, the new GameObject will be a child of this transform</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateSyntheticImageMarkerPreset(Transform parent = null)
        {
            MarsObjectCreationResources.instance.SyntheticImageMarkerPreset.CreateGameObject(out var gameObject, parent);
            return gameObject;
        }
    }
}

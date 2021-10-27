using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation.Rendering
{
    [MovedFrom("Unity.MARS")]
    public static class XRayRuntimeUtils
    {
        const string k_XRayRegionWarningFormat = "{0} already has a XRay Region on {1}. Replacing with new region on {2}";

        static readonly Dictionary<Scene, XRayRegion> k_XRayRegions = new Dictionary<Scene, XRayRegion>();

        /// <summary>
        /// Dictionary of scenes that contain an XRay Region.
        /// </summary>
        public static Dictionary<Scene, XRayRegion> XRayRegions => k_XRayRegions;

        /// <summary>
        /// Assign an XRay Region to be the active region for the region's scene.
        /// </summary>
        /// <param name="xRayRegion">XRay Region to assign to be used the the XRayModule.</param>
        public static void AssignXRayRegion(XRayRegion xRayRegion)
        {
            var scene = xRayRegion.gameObject.scene;
            if (!scene.IsValid())
                return;

            if (!k_XRayRegions.TryGetValue(scene, out var cachedRegion))
            {
                k_XRayRegions.Add(scene, xRayRegion);
            }
            else if (cachedRegion != null)
            {
                Debug.LogWarning(string.Format(k_XRayRegionWarningFormat, scene.name, cachedRegion.gameObject.name,
                    xRayRegion.gameObject.name));
                k_XRayRegions[scene] = xRayRegion;
            }
            else
            {
                k_XRayRegions[scene] = xRayRegion;
            }
        }

        /// <summary>
        /// Remove a XRay Region from use.
        /// </summary>
        /// <param name="xRayRegion">XRay Region to remove from use.</param>
        public static void RemoveXRayRegion(XRayRegion xRayRegion)
        {
            var scene = xRayRegion.gameObject.scene;
            if (!scene.IsValid())
                return;

            if (k_XRayRegions.TryGetValue(scene, out var cachedRegion))
            {
                if (cachedRegion == xRayRegion)
                    k_XRayRegions.Remove(scene);
            }
        }
    }
}

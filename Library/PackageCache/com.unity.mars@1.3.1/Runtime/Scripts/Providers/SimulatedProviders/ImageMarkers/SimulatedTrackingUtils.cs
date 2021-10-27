using UnityEngine;

namespace Unity.MARS.Simulation
{
    static class SimulatedTrackingUtils
    {
        /// <summary>
        /// Test if a point is within a camera's field of view
        /// </summary>
        /// <param name="camera">Camera to test visibility from</param>
        /// <param name="worldPoint">Point in world space to test</param>
        /// <param name="tolerance">
        /// Allows the failure point to be defined inside or outside of the true frustum.
        /// 0-1 is inside the frustum, > 1 is outside
        /// </param>
        /// <returns>True if inside the frustum tolerance, false otherwise</returns>
        public static bool PointInFrustum(Camera camera, Vector3 worldPoint, float tolerance = 1f)
        {
            var viewPoint = camera.WorldToViewportPoint(worldPoint);
            var negativeTolerance = 1f - tolerance;
            var xInBounds = viewPoint.x > negativeTolerance && viewPoint.x <= tolerance;
            var yInBounds = viewPoint.y > negativeTolerance && viewPoint.y <= tolerance;
            var zInBounds = viewPoint.z > 0;
            return xInBounds && yInBounds && zInBounds;
        }
    }
}

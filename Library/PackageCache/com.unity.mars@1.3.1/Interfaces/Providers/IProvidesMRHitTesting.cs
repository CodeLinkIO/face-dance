using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a MR hit testing provider
    /// This functionality provider is responsible for performing hit tests on feature points, planes, and point clouds
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesMRHitTesting : IFunctionalityProvider
    {
        /// <summary>
        /// Perform a screen-based hit test against MR feature points.
        /// </summary>
        /// <param name="screenPosition">The screen position from which test will originate</param>
        /// <param name="result">The result of the hit test</param>
        /// <param name="types">The types of results to test against</param>
        /// <returns>Whether the test succeeded</returns>
        bool ScreenHitTest(Vector2 screenPosition, out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any);

        /// <summary>
        /// Perform a world-based hit test against MR feature points.
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <param name="result">The result of the hit test</param>
        /// <param name="types">The types of results to test against</param>
        /// <returns>Whether the test succeeded</returns>
        bool WorldHitTest(Ray ray, out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any);

        /// <summary>
        /// Stop performing hit tests. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        void StopHitTesting();

        /// <summary>
        /// Start performing hit tests. Hit test support is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        void StartHitTesting();
    }
}

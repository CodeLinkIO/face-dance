using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to MR hit testing features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesMRHitTesting : IFunctionalitySubscriber<IProvidesMRHitTesting>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesHitTestingMethods
    {
        /// <summary>
        /// Perform a screen-based hit test against MR data
        /// </summary>
        /// <param name="screenPosition">The screen position from which test will originate</param>
        /// <param name="result">The result of the hit test</param>
        /// <param name="types">The types of results to test against</param>
        /// <returns>Whether the test succeeded</returns>
        public static bool ScreenHitTest(this IUsesMRHitTesting obj, Vector2 screenPosition,
            out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any)
        {
            return obj.provider.ScreenHitTest(screenPosition, out result, types);
        }

        /// <summary>
        /// Perform a world-based hit test against MR feature points.
        /// </summary>
        /// <param name="ray">The ray to test</param>
        /// <param name="result">The result of the hit test</param>
        /// <param name="types">The types of results to test against</param>
        /// <returns>Whether the test succeeded</returns>
        public static bool WorldHitTestHitTest(this IUsesMRHitTesting obj, Ray ray,
            out MRHitTestResult result, MRHitTestResultTypes types = MRHitTestResultTypes.Any)
        {
            return obj.provider.WorldHitTest(ray, out result, types);
        }

        /// <summary>
        /// Stop performing hit tests. This will happen automatically on destroying the session. It is only necessary to
        /// call this method to pause plane detection while maintaining camera tracking
        /// </summary>
        public static void StopHitTesting(this IUsesMRHitTesting obj)
        {
            obj.provider.StopHitTesting();
        }

        /// <summary>
        /// Start performing hit tests. Hit test support is enabled on initialization, so this is only necessary after
        /// calling StopDetecting.
        /// </summary>
        public static void StartHitTesting(this IUsesMRHitTesting obj)
        {
            obj.provider.StartHitTesting();
        }

    }
}

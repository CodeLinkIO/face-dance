using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Provides access to a video feed spatial context for simulation
    /// </summary>
    public interface IUsesSimulationVideoFeed : IFunctionalitySubscriber<IProvidesSimulationVideoFeed>
    {
    }

    public static class IUsesSimulationVideoFeedMethods
    {
        /// <summary>
        /// Get the texture displaying the video feed
        /// </summary>
        /// <returns>The texture displaying the video feed</returns>
        public static Texture GetVideoFeedTexture(this IUsesSimulationVideoFeed obj)
        {
            return obj.provider.VideoFeedTexture;
        }

        /// <summary>
        /// Get the focal length of the camera used to capture the video, in pixels
        /// </summary>
        /// <returns>The focal length of the camera used to capture the video, in pixels</returns>
        public static float GetVideoFocalLength(this IUsesSimulationVideoFeed obj)
        {
            return obj.provider.VideoFocalLength;
        }

        /// <summary>
        /// Get the direction of the camera used to capture the video
        /// </summary>
        /// <returns>The direction of the camera used to capture the video</returns>
        public static CameraFacingDirection GetVideoFacingDirection(this IUsesSimulationVideoFeed obj)
        {
            return obj.provider.VideoFacingDirection;
        }

        /// <summary>
        /// Subscribe to the VideoFeedTextureChanged event, which is called right after the video feed texture has been created
        /// </summary>
        /// <param name="onVideoFeedTextureCreated">The delegate to subscribe</param>
        public static void SubscribeVideoFeedTextureCreated(this IUsesSimulationVideoFeed obj, Action<Texture> onVideoFeedTextureCreated)
        {
            obj.provider.VideoFeedTextureChanged += onVideoFeedTextureCreated;
        }

        /// <summary>
        /// Unsubscribe from the VideoFeedTextureChanged event, which is called right after the video feed texture has been created
        /// </summary>
        /// <param name="onVideoFeedTextureCreated">The delegate to unsubscribe</param>
        public static void UnsubscribeVideoFeedTextureCreated(this IUsesSimulationVideoFeed obj, Action<Texture> onVideoFeedTextureCreated)
        {
            obj.provider.VideoFeedTextureChanged -= onVideoFeedTextureCreated;
        }
    }
}

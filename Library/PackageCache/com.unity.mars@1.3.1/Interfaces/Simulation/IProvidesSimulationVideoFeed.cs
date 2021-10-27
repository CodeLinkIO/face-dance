using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Defines the API for a video feed spatial context for simulation
    /// </summary>
    public interface IProvidesSimulationVideoFeed : IFunctionalityProvider
    {
        /// <summary>
        /// The texture displaying the video feed
        /// </summary>
        Texture VideoFeedTexture { get; }

        /// <summary>
        /// The focal length of the camera used to capture the video, in pixels
        /// </summary>
        float VideoFocalLength { get; }

        /// <summary>
        /// The direction of the camera used to capture the video
        /// </summary>
        CameraFacingDirection VideoFacingDirection { get; }

        /// <summary>
        /// Called right after the video feed texture has been created
        /// </summary>
        event Action<Texture> VideoFeedTextureChanged;
    }
}

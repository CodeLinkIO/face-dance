using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Camera Texture Provider
    /// This functionality provider is responsible for access to a camera texture.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesCameraTexture : IFunctionalityProvider
    {
        /// <summary>
        /// The current facing direction of the camera used to supply the texture
        /// </summary>
        CameraFacingDirection CameraFacingDirection { get; }

        /// <summary>
        /// Get the current camera texture
        /// </summary>
        /// <returns>The current camera texture</returns>
        Texture GetCameraTexture();

        /// <summary>
        /// Request that the provider use the camera with the given facing direction, if possible
        /// </summary>
        /// <param name="facingDirection">The requested camera facing direction</param>
        void RequestCameraFacingDirection(CameraFacingDirection facingDirection);
    }
}

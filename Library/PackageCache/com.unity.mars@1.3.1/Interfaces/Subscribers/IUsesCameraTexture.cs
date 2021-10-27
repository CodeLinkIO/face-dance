using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to a camera texture
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesCameraTexture : IFunctionalitySubscriber<IProvidesCameraTexture>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesCameraTextureMethods
    {
        /// <summary>
        /// Get the current facing direction of the camera used to supply the texture
        /// </summary>
        public static CameraFacingDirection GetCameraFacingDirection(this IUsesCameraTexture obj)
        {
            return obj.provider.CameraFacingDirection;
        }

        /// <summary>
        /// Get the current camera texture
        /// </summary>
        /// The returned Texture is reused for subsequent calls so should be copied if the data needs to be preserved
        /// across future calls.
        /// <returns>The current camera texture</returns>
        public static Texture GetCameraTexture(this IUsesCameraTexture obj)
        {
            return obj.provider.GetCameraTexture();
        }

        /// <summary>
        /// Request that the provider use the camera with the given facing direction, if possible
        /// </summary>
        /// <param name="facingDirection">The requested camera facing direction</param>
        public static void RequestCameraFacingDirection(this IUsesCameraTexture obj, CameraFacingDirection facingDirection)
        {
            obj.provider.RequestCameraFacingDirection(facingDirection);
        }
    }
}

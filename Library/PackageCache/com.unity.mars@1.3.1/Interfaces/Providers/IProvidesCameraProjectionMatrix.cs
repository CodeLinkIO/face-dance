using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Camera Projection Matrix Provider
    /// This functionality provider is responsible for providing a projection matrix to match the device's physical camera
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesCameraProjectionMatrix : IFunctionalityProvider
    {
        /// <summary>
        /// Get the current camera projection matrix
        /// </summary>
        /// <returns>The current projection matrix-- will be null if no frames have been received yet</returns>
        Matrix4x4? GetProjectionMatrix();
    }
}

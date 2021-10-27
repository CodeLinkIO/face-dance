using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Camera Intrinsics Provider
    /// This functionality provider is responsible for providing information about the intrinsics of the physical camera
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesCameraIntrinsics : IFunctionalityProvider
    {
        /// <summary>
        /// The focal length of the camera, in pixels
        /// </summary>
        float FocalLength { get; }

        /// <summary>
        /// Get the field of view of the physical camera
        /// </summary>
        /// <returns>The camera field of view</returns>
        float? GetFieldOfView();

        /// <summary>
        /// Called when the camera field of view has changed
        /// </summary>
        event Action<float> FieldOfViewUpdated;
    }
}

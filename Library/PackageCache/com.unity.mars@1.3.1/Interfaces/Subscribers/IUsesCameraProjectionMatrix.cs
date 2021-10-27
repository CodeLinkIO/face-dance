using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to a projection matrix that matches the physical camera
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesCameraProjectionMatrix : IFunctionalitySubscriber<IProvidesCameraProjectionMatrix>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesCameraProjectionMatrixMethods
    {
        /// <summary>
        /// Get the current camera projection matrix
        /// </summary>
        /// <returns>The current camera projection matrix</returns>
        public static Matrix4x4? GetProjectionMatrix(this IUsesCameraProjectionMatrix obj)
        {
            return obj.provider.GetProjectionMatrix();
        }
    }
}

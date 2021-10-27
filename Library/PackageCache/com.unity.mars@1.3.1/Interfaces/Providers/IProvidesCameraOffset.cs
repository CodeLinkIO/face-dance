using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a Camera Offset Provider
    /// This functionality provider is responsible for getting and setting offsets on the MR camera
    /// Offsets are cached statically in IUsesCameraOffset--there can be only one Camera Offset Provider
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesCameraOffset : IFunctionalityProvider
    {
        /// <summary>
        /// Get or set the camera position offset
        /// </summary>
        Vector3 cameraPositionOffset { get; set; }

        /// <summary>
        /// Get or set the camera rotation offset
        /// </summary>
        float cameraYawOffset { get; set; }

        /// <summary>
        /// Get or set the camera scale
        /// </summary>
        float cameraScale { get; set; }

        /// <summary>
        /// Get the matrix that applies the camera offset transformation
        /// </summary>
        Matrix4x4 CameraOffsetMatrix { get; }

        /// <summary>
        /// Apply the camera offset to a pose and return the modified pose
        /// </summary>
        /// <param name="pose">The pose to which the offset will be applied</param>
        /// <returns>The modified pose</returns>
        Pose ApplyOffsetToPose(Pose pose);

        /// <summary>
        /// Apply the inverse of the camera offset to a pose and return the modified pose
        /// </summary>
        /// <param name="pose">The pose to which the offset will be applied</param>
        /// <returns>The modified pose</returns>
        Pose ApplyInverseOffsetToPose(Pose pose);

        /// <summary>
        /// Apply the camera offset to a position and return the modified position
        /// </summary>
        /// <param name="position">The position to which the offset will be applied</param>
        /// <returns>The modified position</returns>
        Vector3 ApplyOffsetToPosition(Vector3 position);

        /// <summary>
        /// Apply the inverse of the camera offset to a position and return the modified position
        /// </summary>
        /// <param name="position">The position to which the offset will be applied</param>
        /// <returns>The modified position</returns>
        Vector3 ApplyInverseOffsetToPosition(Vector3 position);

        /// <summary>
        /// Apply the camera offset to a direction and return the modified direction. This is not affected by scale or position.
        /// </summary>
        /// <param name="direction">The direction to which the offset will be applied</param>
        /// <returns>The modified direction</returns>
        Vector3 ApplyOffsetToDirection(Vector3 direction);

        /// <summary>
        /// Apply the inverse of the camera offset to a direction and return the modified direction.
        /// This is not affected by scale or position.
        /// </summary>
        /// <param name="direction">The direction to which the offset will be applied</param>
        /// <returns>The modified direction</returns>
        Vector3 ApplyInverseOffsetToDirection(Vector3 direction);

        /// <summary>
        /// Apply the camera offset to a rotation and return the modified rotation
        /// </summary>
        /// <param name="rotation">The rotation to which the offset will be applied</param>
        /// <returns>The modified rotation</returns>
        Quaternion ApplyOffsetToRotation(Quaternion rotation);

        /// <summary>
        /// Apply the inverse of the camera offset to a rotation and return the modified rotation
        /// </summary>
        /// <param name="rotation">The rotation to which the offset will be applied</param>
        /// <returns>The modified rotation</returns>
        Quaternion ApplyInverseOffsetToRotation(Quaternion rotation);
    }
}

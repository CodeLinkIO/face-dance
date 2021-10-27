using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to camera offset (position, yaw, uniform scale)
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesCameraOffset : IFunctionalitySubscriber<IProvidesCameraOffset>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesCameraOffsetMethods
    {
        /// <summary>
        /// Get the camera position offset
        /// </summary>
        /// <returns>The camera position offset</returns>
        public static Vector3 GetCameraPositionOffset(this IUsesCameraOffset obj)
        {
            return obj.provider.cameraPositionOffset;
        }

        /// <summary>
        /// Set the camera position offset
        /// </summary>
        /// <param name="offset">The camera position offset</param>
        public static void SetCameraPositionOffset(this IUsesCameraOffset obj, Vector3 offset)
        {
            obj.provider.cameraPositionOffset = offset;
        }

        /// <summary>
        /// Get the camera yaw offset
        /// </summary>
        /// <returns>The camera yaw offset</returns>
        public static float GetCameraYawOffset(this IUsesCameraOffset obj)
        {
            return obj.provider.cameraYawOffset;
        }

        /// <summary>
        /// Set the camera yaw offset
        /// </summary>
        /// <param name="offset">The yaw offset</param>
        public static void SetCameraYawOffset(this IUsesCameraOffset obj, float offset)
        {
            obj.provider.cameraYawOffset = offset;
        }

        /// <summary>
        /// Get the camera scale
        /// </summary>
        /// <returns>The camera scale</returns>
        public static float GetCameraScale(this IUsesCameraOffset obj)
        {
            return obj.provider.cameraScale;
        }

        /// <summary>
        /// Set the camera scale
        /// </summary>
        /// <param name="scale">The camera scale</param>
        public static void SetCameraScale(this IUsesCameraOffset obj, float scale)
        {
            obj.provider.cameraScale = scale;
        }

        /// <summary>
        /// Get the matrix that applies the camera offset transformation
        /// </summary>
        /// <returns>The camera offset matrix</returns>
        public static Matrix4x4 GetCameraOffsetMatrix(this IUsesCameraOffset obj)
        {
            return obj.provider.CameraOffsetMatrix;
        }

        /// <summary>
        /// Apply the camera offset to a pose and return the modified pose
        /// </summary>
        /// <param name="pose">The pose to which the offset will be applied</param>
        /// <returns>The modified pose</returns>
        public static Pose ApplyOffsetToPose(this IUsesCameraOffset obj, Pose pose)
        {
            return obj.provider.ApplyOffsetToPose(pose);
        }

        /// <summary>
        /// Apply the inverse of the camera offset to a pose and return the modified pose
        /// </summary>
        /// <param name="pose">The pose to which the offset will be applied</param>
        /// <returns>The modified pose</returns>
        public static Pose ApplyInverseOffsetToPose(this IUsesCameraOffset obj, Pose pose)
        {
            return obj.provider.ApplyInverseOffsetToPose(pose);
        }

        /// <summary>
        /// Apply the camera offset to a position and return the modified position
        /// </summary>
        /// <param name="position">The position to which the offset will be applied</param>
        /// <returns>The modified position</returns>
        public static Vector3 ApplyOffsetToPosition(this IUsesCameraOffset obj, Vector3 position)
        {
            return obj.provider.ApplyOffsetToPosition(position);
        }

        /// <summary>
        /// Apply the inverse of the camera offset to a pose and return the modified pose
        /// </summary>
        /// <param name="pose">The pose to which the offset will be applied</param>
        /// <returns>The modified pose</returns>
        public static Vector3 ApplyInverseOffsetToPosition(this IUsesCameraOffset obj, Vector3 position)
        {
            return obj.provider.ApplyInverseOffsetToPosition(position);
        }

        /// <summary>
        /// Apply the camera offset to a direction and return the modified direction. This is not affected by scale or position.
        /// </summary>
        /// <param name="direction">The direction to which the offset will be applied</param>
        /// <returns>The modified direction</returns>
        public static Vector3 ApplyOffsetToDirection(this IUsesCameraOffset obj, Vector3 direction)
        {
            return obj.provider.ApplyOffsetToDirection(direction);
        }

        /// <summary>
        /// Apply the inverse of the camera offset to a direction and return the modified direction.
        /// This is not affected by scale or position.
        /// </summary>
        /// <param name="direction">The direction to which the offset will be applied</param>
        /// <returns>The modified direction</returns>
        public static Vector3 ApplyInverseOffsetToDirection(this IUsesCameraOffset obj, Vector3 direction)
        {
            return obj.provider.ApplyInverseOffsetToDirection(direction);
        }

        /// <summary>
        /// Apply the camera offset to a rotation and return the modified rotation
        /// </summary>
        /// <param name="rotation">The rotation to which the offset will be applied</param>
        /// <returns>The modified rotation</returns>
        public static Quaternion ApplyOffsetToRotation(this IUsesCameraOffset obj, Quaternion rotation)
        {
            return obj.provider.ApplyOffsetToRotation(rotation);
        }

        /// <summary>
        /// Apply the inverse of the camera offset to a rotation and return the modified rotation
        /// </summary>
        /// <param name="rotation">The rotation to which the offset will be applied</param>
        /// <returns>The modified rotation</returns>
        public static Quaternion ApplyInverseOffsetToRotation(this IUsesCameraOffset obj, Quaternion rotation)
        {
            return obj.provider.ApplyInverseOffsetToRotation(rotation);
        }
    }
}

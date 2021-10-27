using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to 3dof/6dof camera tracking features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesCameraPose : IFunctionalitySubscriber<IProvidesCameraPose>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesCameraPoseMethods
    {
        /// <summary>
        /// Get the current camera pose
        /// </summary>
        /// <returns>The current camera pose</returns>
        public static Pose GetPose(this IUsesCameraPose obj)
        {
            return obj.provider.GetCameraPose();
        }

        /// <summary>
        /// Subscribe to the poseUpdated event, which is called when the camera pose changes
        /// </summary>
        /// <param name="poseUpdated">The delegate to subscribe</param>
        public static void SubscribePoseUpdated(this IUsesCameraPose obj, Action<Pose> poseUpdated)
        {
            obj.provider.poseUpdated += poseUpdated;
        }

        /// <summary>
        /// Unsubscribe from the poseUpdated event, which is called when the camera pose changes
        /// </summary>
        /// <param name="poseUpdated">The delegate to unsubscribe</param>
        public static void UnsubscribePoseUpdated(this IUsesCameraPose obj, Action<Pose> poseUpdated)
        {
            obj.provider.poseUpdated -= poseUpdated;
        }

        /// <summary>
        /// Subscribe to the trackingTypeChanged event, which is called when the camera tracking type changes
        /// </summary>
        /// <param name="trackingTypeChanged">The delegate to subscribe</param>
        public static void SubscribeTrackingTypeChanged(this IUsesCameraPose obj, Action<MRCameraTrackingState> trackingTypeChanged)
        {
            obj.provider.trackingStateChanged += trackingTypeChanged;
        }

        /// <summary>
        /// Unsubscribe from the trackingTypeChanged event, which is called when the camera tracking type changes
        /// </summary>
        /// <param name="trackingTypeChanged">The delegate to unsubscribe</param>
        public static void UnsubscribeTrackingTypeChanged(this IUsesCameraPose obj, Action<MRCameraTrackingState> trackingTypeChanged)
        {
            obj.provider.trackingStateChanged -= trackingTypeChanged;
        }
    }
}

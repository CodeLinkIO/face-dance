using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Provides access to settings used when simulating the movement of an MR device
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesDeviceSimulationSettings : IFunctionalitySubscriber<IProvidesDeviceSimulationSettings>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesDeviceSimulationSettingsMethods
    {
        /// <summary>
        /// Gets the world pose of the device at the start of simulation
        /// </summary>
        /// <returns>The world pose of the device at the start of simulation</returns>
        public static Pose GetDeviceStartingPose(this IUsesDeviceSimulationSettings obj)
        {
            return obj.provider.DeviceStartingPose;
        }

        /// <summary>
        /// Gets the bounds encapsulating the current environment, used to restrict device movement
        /// </summary>
        /// <returns>The bounds encapsulating the current environment, used to restrict device movement</returns>
        public static Bounds GetEnvironmentBounds(this IUsesDeviceSimulationSettings obj)
        {
            return obj.provider.EnvironmentBounds;
        }

        /// <summary>
        /// Gets whether simulated device movement is enabled
        /// </summary>
        /// <returns>Whether simulated device movement is enabled</returns>
        public static bool GetIsMovementEnabled(this IUsesDeviceSimulationSettings obj)
        {
            return obj.provider.IsMovementEnabled;
        }

        /// <summary>
        /// Gets the plane discovery voxel size from any PlaneExtractionSettings component on the current environment.
        /// </summary>
        /// <returns>The voxel size on the environment or null if there is none</returns>
        public static float? GetVoxelSizeFromEnvironment(this IUsesDeviceSimulationSettings obj)
        {
            return obj.provider.VoxelSizeFromEnvironment;
        }

        /// <summary>
        /// Subscribe to the EnvironmentChanged event, which is called when the simulation environment changes
        /// </summary>
        /// <param name="environmentChanged">The delegate to subscribe</param>
        public static void SubscribeEnvironmentChanged(this IUsesDeviceSimulationSettings obj, Action environmentChanged)
        {
            obj.provider.EnvironmentChanged += environmentChanged;
        }

        /// <summary>
        /// Unsubscribe from the EnvironmentChanged event, which is called when the simulation environment changes
        /// </summary>
        /// <param name="environmentChanged">The delegate to unsubscribe</param>
        public static void UnsubscribeEnvironmentChanged(this IUsesDeviceSimulationSettings obj, Action environmentChanged)
        {
            obj.provider.EnvironmentChanged -= environmentChanged;
        }
    }
}

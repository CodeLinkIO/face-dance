using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Defines the API for settings used when simulating the movement of an MR device
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesDeviceSimulationSettings : IFunctionalityProvider
    {
        /// <summary>
        /// World pose of the device at the start of simulation
        /// </summary>
        Pose DeviceStartingPose { get; }

        /// <summary>
        /// Bounds encapsulating the current environment, used to restrict device movement
        /// </summary>
        Bounds EnvironmentBounds { get; }

        /// <summary>
        /// Whether simulated device movement is enabled
        /// </summary>
        bool IsMovementEnabled { get; }

        /// <summary>
        /// Returns any plane discovery voxel size setting from a PlaneExtractionSettings on the current environment
        /// </summary>
        float? VoxelSizeFromEnvironment { get; }

        /// <summary>
        /// Called when the simulation environment has changed
        /// </summary>
        event Action EnvironmentChanged;
    }
}

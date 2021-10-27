using System;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Interface used for components that provide extra settings to a landmark definition
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ILandmarkSettings : ISimulatable
    {
        /// <summary>
        /// Event to call when the settings data has changed such that the landmark should recalculate
        /// </summary>
        event Action<ILandmarkSettings> dataChanged;
    }
}

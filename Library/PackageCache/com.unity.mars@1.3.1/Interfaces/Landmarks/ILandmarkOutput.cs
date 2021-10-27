using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Interface for components that are used by landmarks to store the result to be used by another system.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ILandmarkOutput : ISimulatable
    {
        /// <summary>
        /// Called to apply the output data to the attached gameobject or scene.
        /// This is called by the landmark controller automatically after calling the source's calculation method.
        /// </summary>
        void UpdateOutput();
    }
}

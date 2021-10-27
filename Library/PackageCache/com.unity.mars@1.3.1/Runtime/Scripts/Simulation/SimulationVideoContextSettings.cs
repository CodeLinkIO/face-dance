using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Settings used for video feed spatial contexts for simulation
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    public class SimulationVideoContextSettings : ScriptableSettings<SimulationVideoContextSettings>
    {
        // Found by trial and error
        internal const float DefaultFocalLength = 1680.0f;

        const float k_DefaultBackgroundScale = 0.002f;

        [SerializeField]
        [Tooltip("Sets the focal length, in video texture pixels, to use for video feeds in simulation. " +
            "This controls the focal length value that the simulated camera feed provider provides. " +
            "This value is also used for the unscaled distance between the MARS camera and the video background plane.")]
        float m_SimulatedFocalLength = DefaultFocalLength;

        [SerializeField]
        [Tooltip("Sets the scaling factor to apply to the video background in simulation.")]
        float m_VideoBackgroundScale = k_DefaultBackgroundScale;

        /// <summary>
        /// The focal length, in video texture pixels, to use for video feeds in simulation
        /// </summary>
        public float SimulatedFocalLength
        {
            get => m_SimulatedFocalLength;
            set => m_SimulatedFocalLength = value;
        }

        /// <summary>
        /// The scaling factor to apply to the video background in simulation
        /// </summary>
        public float VideoBackgroundScale
        {
            get => m_VideoBackgroundScale;
            set => m_VideoBackgroundScale = value;
        }
    }
}

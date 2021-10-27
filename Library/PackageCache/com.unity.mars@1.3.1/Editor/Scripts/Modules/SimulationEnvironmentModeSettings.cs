using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Base class for how an environment is loaded and displayed in MARS with the <c>MARSEnvironmentManager</c>
    /// </summary>
    [MovedFrom("Unity.MARS.Simulation")]
    public abstract class SimulationEnvironmentModeSettings : ScriptableObject
    {
        /// <summary>
        /// GUI contents to as <c>EnvironmentSwitchingContents</c> when environment switching is not supported
        /// </summary>
        public static readonly GUIContent[] NoEnvironmentSwitchingContents = {new GUIContent("No Environment Switching")};

        /// <summary>
        /// Name of the environment Mode
        /// </summary>
        public abstract string EnvironmentModeName { get; }

        /// <summary>
        /// Default simulation mode preference when switching to this mode settings
        /// </summary>
        public abstract SimulationModeSelection DefaultSimulationMode { get; }

        /// <summary>
        /// Is framing enabled in this mode from the simulation view
        /// </summary>
        public abstract bool IsFramingEnabled { get; }

        /// <summary>
        /// Is movement enabled in this mode from the device view
        /// </summary>
        public abstract bool IsMovementEnabled { get; }

        /// <summary>
        /// Is there environment switching in this mode
        /// </summary>
        public abstract bool HasEnvironmentSwitching { get; }

        /// <summary>
        /// List of all the environments available in this mode
        /// </summary>
        public abstract GUIContent[] EnvironmentSwitchingContents { get; }

        /// <summary>
        /// The index of the active environment, this is also the index of the environment in <c>EnvironmentSwitchingContents</c>
        /// </summary>
        public abstract int ActiveEnvironmentIndex { get; }

        /// <summary>
        /// Set the active environment to an index
        /// </summary>
        /// <param name="index"></param>
        public abstract void SetActiveEnvironment(int index);

        /// <summary>
        /// Used to generate an array of environments for environment switching
        /// </summary>
        public abstract void FindEnvironmentCandidates();

        /// <summary>
        /// Used to open a simulation environment in this mode
        /// </summary>
        public abstract void OpenSimulationEnvironment();
    }
}

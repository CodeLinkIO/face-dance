using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Simulation
{
    /// <summary>
    /// Holds metadata about a MARS environment scene
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class MARSEnvironmentInfo
    {
        // By default start 1.5 meters off the ground, 1 meter back, facing forward
        static readonly Pose k_DefaultStartingPose = new Pose(new Vector3(0f, 1.5f, -1f), Quaternion.identity);

        [SerializeField]
        [Tooltip("Default world pose of the camera when this environment scene is loaded")]
        Pose m_DefaultCameraWorldPose = k_DefaultStartingPose;

        [SerializeField]
        [Tooltip("Default world pivot of the scene camera for this environment scene")]
        Vector3 m_DefaultCameraPivot;

        [SerializeField]
        [Tooltip("Default orbit radius of the camera when viewing this environment scene")]
        float m_DefaultCameraSize;

        [SerializeField]
        [Tooltip("World pose of the device at the start of simulation")]
        Pose m_SimulationStartingPose = k_DefaultStartingPose;

        [SerializeField]
        [Tooltip("Bounds encapsulating the whole environment")]
        Bounds m_EnvironmentBounds;

        /// <summary>
        /// Default world pose of the camera when this environment scene is loaded
        /// </summary>
        public Pose DefaultCameraWorldPose { get { return m_DefaultCameraWorldPose; } set { m_DefaultCameraWorldPose = value; } }

        /// <summary>
        /// Default world pivot of the scene camera for this environment scene
        /// </summary>
        public Vector3 DefaultCameraPivot { get { return m_DefaultCameraPivot; } set { m_DefaultCameraPivot = value; } }

        /// <summary>
        /// Default orbit radius of the camera when viewing this environment scene
        /// </summary>
        public float DefaultCameraSize { get { return m_DefaultCameraSize; } set { m_DefaultCameraSize = value; } }

        /// <summary>
        /// World pose of the device at the start of simulation
        /// </summary>
        public Pose SimulationStartingPose { get { return m_SimulationStartingPose; } set { m_SimulationStartingPose = value; } }

        /// <summary>
        /// Bounds encapsulating the whole environment
        /// </summary>
        public Bounds EnvironmentBounds { get { return m_EnvironmentBounds; } set { m_EnvironmentBounds = value; } }
    }
}

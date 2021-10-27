using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Type of view the simulation view is displaying
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public enum ViewSceneType
    {
        /// <summary>
        /// Scene view is not a simulation view
        /// </summary>
        None = -1,
        /// <summary>
        /// Simulation scene view
        /// </summary>
        Simulation = 0,
        /// <summary>
        /// Simulation device view
        /// </summary>
        Device = 1
    }

    /// <summary>
    /// Common interface for objects that draw a simulation view.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ISimulationView
    {
        /// <summary>
        /// The Camera that is rendering this simulation view.
        /// </summary>
        Camera camera { get; }
        /// <summary>
        /// The type of scene being viewed in the simulation view.
        /// </summary>
        ViewSceneType SceneType { get; set; }
        /// <summary>
        /// The center point, or pivot, of the Scene view.
        /// </summary>
        Vector3 pivot { get; set; }
        /// <summary>
        /// The direction of the <c>camera</c> to the pivot of the view.
        /// </summary>
        Quaternion rotation { get; set; }
        /// <summary>
        /// The size of the view measured diagonally.
        /// </summary>
        float size { get; set; }
        /// <summary>
        /// Whether the view camera is set to orthographic mode.
        /// </summary>
        bool orthographic { get; set; }
        /// <summary>
        /// Whether the view camera can be rotated.
        /// </summary>
        bool isRotationLocked { get; set; }

        /// <summary>
        /// Look at a specific point from a given direction with a given zoom level, enabling and disabling perspective
        /// </summary>
        /// <param name="point">The position in world space to frame.</param>
        /// <param name="direction">The direction that the Scene view should view the target point from.</param>
        /// <param name="newSize">The amount of camera zoom. Sets <c>size</c>.</param>
        /// <param name="ortho">Whether the camera focus is in orthographic mode (true) or perspective mode (false).</param>
        /// <param name="instant">Apply the movement immediately (true) or animate the transition (false).</param>
        void LookAt(Vector3 point, Quaternion direction, float newSize, bool ortho, bool instant);

        /// <summary>
        /// Make the view repaint.
        /// </summary>
        void Repaint();

        /// <summary>
        /// Setup the view as using the Simulation Scene.
        /// </summary>
        /// <param name="forceFrame">Force using the framing of the simulated environment settings.</param>
        void SetupViewAsSimUser(bool forceFrame = false);
    }
}

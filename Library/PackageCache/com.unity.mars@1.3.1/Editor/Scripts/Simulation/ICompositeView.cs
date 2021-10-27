using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation.Rendering
{
    /// <summary>
    /// Type of view a composite render context is targeting
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public enum ContextViewType
    {
        /// <summary>Undefined view type</summary>
        Undefined = -1,
        /// <summary>Simulation View</summary>
        SimulationView = 0,
        /// <summary>Device View</summary>
        DeviceView,
        /// <summary>Scene view viewing the main scene</summary>
        NormalSceneView,
        /// <summary>Scene view in prefab isolation mode</summary>
        PrefabIsolation,
        /// <summary>Game View</summary>
        GameView,
        /// <summary>Other custom view type</summary>
        OtherView,
    }

    /// <summary>
    /// Interface that contains values and methods needed to set up a composite view on a given object
    /// </summary>
    [MovedFrom("Unity.MARS")]
    interface ICompositeView
    {
        /// <summary>
        /// Context view type of the view
        /// </summary>
        ContextViewType ContextViewType { get; }

        /// <summary>
        /// Camera associated with the view. This is the one providing the render for a view.
        /// </summary>
        Camera TargetCamera { get; }

        /// <summary>
        /// Render texture descriptor for the <c>TargetCamera</c>
        /// </summary>
        RenderTextureDescriptor CameraTargetDescriptor { get; }

        /// <summary>
        /// Color to use as a background fill when drawing the composite
        /// </summary>
        Color BackgroundColor { get; }

        /// <summary>
        /// Are image effects active and should be rendered
        /// </summary>
        bool ShowImageEffects { get; }

        /// <summary>
        /// Is the composited scene the active scene
        /// </summary>
        bool BackgroundSceneActive { get; }

        /// <summary>
        /// Desaturate the layer being composited to the view
        /// </summary>
        bool DesaturateComposited { get; }

        /// <summary>
        /// Enable the x-ray rendering for the view
        /// </summary>
        bool UseXRay { get; }
    }
}

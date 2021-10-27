using System;
using System.Collections.Generic;
using Unity.MARS.Simulation.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.MARS
{
    /// <summary>
    /// Utility methods used by the Composite Renderer at runtime
    /// </summary>
    static class CompositeRenderRuntimeUtils
    {
        static readonly Dictionary<Scene, SimulationRenderSettings> k_SceneSimulationRenderSettings
            = new Dictionary<Scene, SimulationRenderSettings>();

        /// <summary>
        /// Callback for when an image effect setting is to be used as the global image effect setting for simulation environments.
        /// </summary>
        public static event Action<ScriptableObject> OnImageEffectSettingsSet;

        /// <summary>
        /// Callback for when an image effect is cleared from the composite render module.
        /// </summary>
        public static event Action OnImageEffectSettingsUnset;

        /// <summary>
        /// The image effect settings to be used by the Composite Renderer.
        /// </summary>
        public static ScriptableObject ImageEffectSettings { get; private set; }

        /// <summary>
        /// The active simulation settings and their scenes.
        /// </summary>
        public static Dictionary<Scene, SimulationRenderSettings> SceneSimulationRenderSettings => k_SceneSimulationRenderSettings;

        /// <summary>
        /// Assigns the simulation render settings to a scene in the composite render module
        /// </summary>
        /// <param name="scene">The scene to associate with the simulation render settings</param>
        /// <param name="simulationRenderSettings">The render setting associate with the scene.</param>
        public static void AssignSimulationRenderSettings(Scene scene, SimulationRenderSettings simulationRenderSettings)
        {
            ClearSimulationRenderSettings(scene);

            k_SceneSimulationRenderSettings.Add(scene, simulationRenderSettings);
        }

        /// <summary>
        /// Removes the render settings associated with a scene.
        /// </summary>
        /// <param name="scene">Scene to remove render settings for.</param>
        public static void ClearSimulationRenderSettings(Scene scene)
        {
            k_SceneSimulationRenderSettings.Remove(scene);
        }

        /// <summary>
        /// Assign an image effect setting to be used as the global image effect setting for simulation environments.
        /// </summary>
        /// <param name="imageEffectSettings">The scriptable object to be used for simulation environments.</param>
        public static void AssignImageEffectSettings(ScriptableObject imageEffectSettings)
        {
            if (OnImageEffectSettingsSet != null)
                OnImageEffectSettingsSet(imageEffectSettings);

            ImageEffectSettings = imageEffectSettings;
        }

        /// <summary>
        /// Clear the currently used image effects settings in the composite render module.
        /// </summary>
        public static void ClearImageEffectSettings()
        {
            if (OnImageEffectSettingsUnset != null)
                OnImageEffectSettingsUnset();

            ImageEffectSettings = null;
        }
    }
}

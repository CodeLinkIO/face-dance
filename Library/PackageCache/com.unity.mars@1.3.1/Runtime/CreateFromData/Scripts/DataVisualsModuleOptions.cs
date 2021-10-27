using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// User options for Data Visual module
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class DataVisualsModuleOptions : ScriptableSettings<DataVisualsModuleOptions>
    {
        static readonly GradientColorKey[] k_DefaultGradientColorKeys = {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.green, 1f)
        };

        static readonly GradientAlphaKey[] k_DefaultGradientAlphaKeys = {
            new GradientAlphaKey(0f, 0f),
            new GradientAlphaKey(1f, 1f)
        };

#pragma warning disable 649
        [SerializeField]
        [Tooltip("When comparing conditions to data, they will change their color based on their match rating according to this color gradient.")]
        Gradient m_RatingGradient;

#pragma warning disable 414
        [SerializeField]
        [Tooltip("If enabled, the data visuals will be visible in the simulation content hierarchy.")]
        bool m_ShowDataVisualsInHierarchy;
#pragma warning restore 414

        [SerializeField]
        [Tooltip("If enabled, data visuals will not be created when simulation begins. Interactions with data will not be possible when they are disabled.")]
        bool m_DisableSimulationDataVisuals;
#pragma warning restore 649

        /// <summary>
        /// The standard gradient that can be used for coloring visuals based on their rating.
        /// </summary>
        public Gradient RatingGradient
        {
            get => m_RatingGradient;
            set => m_RatingGradient = value;
        }

        /// <summary>
        /// Disable data visuals from being generated in simulation
        /// </summary>
        public bool DisableSimulationDataVisuals
        {
            get => m_DisableSimulationDataVisuals;
            set => m_DisableSimulationDataVisuals = value;
        }

        /// <summary>
        /// If enabled, the data visuals will be visible in the hierarchy
        /// </summary>
        public bool ShowDataVisualsInHierarchy
        {
            get => m_ShowDataVisualsInHierarchy;
            set => m_ShowDataVisualsInHierarchy = value;
        }

        void Reset()
        {
            ResetDefaultPreferences();
        }

        /// <summary>
        /// Reset option to default values
        /// </summary>
        public void ResetDefaultPreferences()
        {
            m_ShowDataVisualsInHierarchy = false;
            m_DisableSimulationDataVisuals = false;
            m_RatingGradient = new Gradient();
            m_RatingGradient.SetKeys(k_DefaultGradientColorKeys, k_DefaultGradientAlphaKeys);
            m_RatingGradient.mode = GradientMode.Blend;
        }
    }
}

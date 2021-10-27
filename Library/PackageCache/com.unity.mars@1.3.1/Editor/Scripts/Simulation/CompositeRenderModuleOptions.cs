using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation.Rendering
{
    /// <summary>
    /// Settings options for the <c>CompositeRenderModule</c>
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class CompositeRenderModuleOptions : EditorScriptableSettings<CompositeRenderModuleOptions>
    {
        [SerializeField]
        [Tooltip("Use a simplified version of composite rendering with greater compatibility to different rendering setups.")]
        bool m_UseFallbackCompositeRendering;

        [SerializeField]
        [Tooltip("Use a camera stack for composite rendering of game view and other views that support camera stacking in Fallback composite rendering.")]
        bool m_UseCameraStackInFallback;

#pragma warning disable 649
        [SerializeField]
        bool m_IncludeUniversalRenderPipeline;
#pragma warning restore 649

        /// <summary>
        /// Use a simplified version of composite rendering with greater compatibility to different rendering setups.
        /// </summary>
        public bool UseFallbackCompositeRendering
        {
            get
            {
                if (RenderPipelineManager.currentPipeline != null && !m_UseFallbackCompositeRendering)
                    UseFallbackCompositeRendering = true;

                return m_UseFallbackCompositeRendering;
            }
            set
            {
                if (RenderPipelineManager.currentPipeline != null && m_UseFallbackCompositeRendering)
                    return;

                if (m_UseFallbackCompositeRendering != value)
                {
                    m_UseFallbackCompositeRendering = value;
                    // Do not reload modules if changed when application is playing
                    if (ModuleLoaderCore.instance != null && !Application.isPlaying)
                        ModuleLoaderCore.instance.ReloadModules();
                }
            }
        }

        /// <summary>
        /// Use a camera stack for composite rendering of game view and other views that support camera stacking in Fallback composite rendering.
        /// </summary>
        internal bool UseCameraStackInFallback
        {
            get { return m_UseFallbackCompositeRendering && m_UseCameraStackInFallback; }
            set
            {
                if (m_UseCameraStackInFallback != value)
                {
                    m_UseCameraStackInFallback = value;
                    // Do not reload modules if changed when application is playing
                    if (ModuleLoaderCore.instance != null  && !Application.isPlaying)
                        ModuleLoaderCore.instance.ReloadModules();
                }
            }
        }

        internal bool CheckShadersNeedToRecompile()
        {
            var needsRecompile = false;
            var serializedObject = new SerializedObject(this);
            bool includeURP;

#if INCLUDE_RENDER_PIPELINES_UNIVERSAL
            includeURP = true;
#else
            includeURP = false;
#endif

            if (m_IncludeUniversalRenderPipeline != includeURP)
            {
                serializedObject.FindProperty(nameof(m_IncludeUniversalRenderPipeline)).boolValue = includeURP;
                needsRecompile = true;
            }

            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            return needsRecompile;
        }
    }
}

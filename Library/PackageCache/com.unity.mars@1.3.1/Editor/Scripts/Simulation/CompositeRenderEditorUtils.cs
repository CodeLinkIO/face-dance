using System.Reflection;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Utility methods used by the Composite Renderer in editor
    /// </summary>
    static class CompositeRenderEditorUtils
    {
        const string k_IncludeUniversalKeyword = "INCLUDE_RENDER_PIPELINES_UNIVERSAL";
        const string k_MarsShaderPath = "Packages/com.unity.mars/Runtime/Shaders/";
        static FieldInfo s_SceneTargetTextureFieldInfo;

        static FieldInfo SceneTargetTextureFieldInfo
        {
            get
            {
                if (s_SceneTargetTextureFieldInfo == null)
                {
                    s_SceneTargetTextureFieldInfo = typeof(SceneView).GetField("m_SceneTargetTexture",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                }

                return s_SceneTargetTextureFieldInfo;
            }
        }

        /// <summary>
        /// Gets the render target texture from a scene view
        /// </summary>
        /// <param name="sceneView">The scene view to get the target render texture from.</param>
        /// <returns></returns>
        internal static RenderTexture GetSceneTargetTexture(this SceneView sceneView)
        {
            return SceneTargetTextureFieldInfo.GetValue(sceneView) as RenderTexture;
        }

        [MenuItem(MenuConstants.DevMenuPrefix + "Reimport Shaders", priority = MenuConstants.ImportContentPriority + 1)]
        static void ReimportMarsShaders()
        {
            SetupRenderShaderGlobals();
            AssetDatabase.ImportAsset(k_MarsShaderPath + "URPRoomXRay.shader");
            AssetDatabase.ImportAsset(k_MarsShaderPath + "LegacyRoomXRay.shader");
            AssetDatabase.ImportAsset(k_MarsShaderPath + "RoomXRay.shader");
            AssetDatabase.ImportAsset(k_MarsShaderPath + "LegacyMarsStandard.shader");
            AssetDatabase.ImportAsset(k_MarsShaderPath + "MarsStandardLit.shader");
            ModuleLoaderCore.instance.ReloadModules();
        }

        [InitializeOnLoadMethod]
        static void CheckShadersNeedToRecompile()
        {
            EditorApplication.delayCall += () =>
            {
                if(!CompositeRenderModuleOptions.instance.CheckShadersNeedToRecompile())
                    return;

                ReimportMarsShaders();
                Debug.LogWarning("Unity MARS shaders are out of date for the currently installed " +
                                 "render pipeline and will be reimported.");
            };
        }

        [InitializeOnLoadMethod]
        internal static void SetupRenderShaderGlobals()
        {
#if INCLUDE_RENDER_PIPELINES_UNIVERSAL
            Shader.EnableKeyword(k_IncludeUniversalKeyword);
#else // INCLUDE_RENDER_PIPELINES_UNIVERSAL
            Shader.DisableKeyword(k_IncludeUniversalKeyword);
#endif // INCLUDE_RENDER_PIPELINES_UNIVERSAL
        }
    }
}

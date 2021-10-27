using System.Linq;
using Unity.XRTools.Utils.Internal;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.XRTools.ModuleLoader
{
    class ModuleLoaderEditorCallbacks : IPreprocessBuildWithReport, IProcessSceneWithReport, IPostprocessBuildWithReport
    {
        public int callbackOrder { get { return 0; } }

        public void OnPreprocessBuild(BuildReport report)
        {
            ModuleLoaderCore.OnPreprocessBuild();
        }

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            ModuleLoaderCore.OnProcessScene(scene);
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            ModuleLoaderCore.OnPostprocessBuild();
        }
    }

    class ModuleLoaderAssetModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string path)
        {
            ModuleLoaderCore.OnWillCreateAsset(path);
        }

        public static string[] OnWillSaveAssets(string[] paths)
        {
            return ModuleLoaderCore.OnWillSaveAssets(paths);
        }

        public static AssetDeleteResult OnWillDeleteAsset(string path, RemoveAssetOptions options)
        {
            return ModuleLoaderCore.OnWillDeleteAsset(path, options);
        }
    }

    class ModuleLoaderAssetPostprocessor : AssetPostprocessor
    {
        public static void OnPostprocessAllAssets(
            string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (Application.isPlaying)
                return;

            // To ensure that ModuleLoaderCore references the correct ScriptableSettings module instances,
            // we reload modules whenever an IModule ScriptableSettings is imported.
            foreach (var asset in importedAssets)
            {
                if (!typeof(ScriptableSettingsBase).IsAssignableFrom(AssetDatabase.GetMainAssetTypeAtPath(asset)))
                    continue;

                var scriptableSettings = AssetDatabase.LoadAssetAtPath<ScriptableSettingsBase>(asset);
                if (scriptableSettings != null && scriptableSettings is IModule)
                {
                    // Since OnPostprocessAllAssets could get called while a module is in the middle of executing some method
                    // we delay the call to ModuleLoaderCore.ReloadModules so that we don't interrupt that execution.
                    EditorApplication.delayCall += ModuleLoaderCore.instance.ReloadModules;
                    break;
                }
            }
        }
    }
}

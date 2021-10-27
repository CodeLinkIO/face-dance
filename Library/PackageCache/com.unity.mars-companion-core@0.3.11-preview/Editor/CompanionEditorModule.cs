using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Companion.Core
{
    // ReSharper disable once UnusedType.Global
    class CompanionEditorModule : IModule
    {
        public void LoadModule() { EditorSceneManager.sceneSaved += OnSceneSaved; }

        static void OnSceneSaved(Scene scene)
        {
            if (!scene.IsValid())
                return;

            GameObject cloudSaverGameObject = null;
            foreach (var gameObject in scene.GetRootGameObjects())
            {
                var cloudGuidSaver = gameObject.GetComponent<CloudGuidSaver>();
                if (cloudGuidSaver != null)
                {
                    cloudSaverGameObject = gameObject;
                    var cloudGuid = cloudGuidSaver.CloudGuid;
                    if (!string.IsNullOrEmpty(cloudGuid))
                    {
                        var assetGuid = AssetDatabase.AssetPathToGUID(scene.path);
                        var companionResourceSync = CompanionResourceSync.instance;
                        companionResourceSync.SetAssetGuid(assetGuid, cloudGuid);

                        // Refresh resource window to update this scene's object field
                        var resourceWindows = Resources.FindObjectsOfTypeAll<CompanionResourceUI>();
                        foreach (var window in resourceWindows)
                        {
                            window.Refresh();
                        }
                    }
                }
            }

            if (cloudSaverGameObject != null)
                UnityObject.DestroyImmediate(cloudSaverGameObject);
        }

        public void UnloadModule() { EditorSceneManager.sceneSaved -= OnSceneSaved; }
    }
}

using System;
using System.IO;
using Unity.RuntimeSceneSerialization;
using System.Linq;
using Unity.MARS.Companion.CloudStorage;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;
using UnityObject = UnityEngine.Object;
using MarsMarkerLibrary = Unity.MARS.Data.MarsMarkerLibrary;

namespace Unity.MARS.Companion.Core
{
    static class CompanionEditorAssetUtils
    {
        const string k_AssetBundlePath = "Temp/CompanionAssetBundles";
        const string k_MarkerLibraryAssetSearch = "t:MarsMarkerLibrary";

        public static void BuildAssetBundles(AssetBundleBuild[] builds)
        {
            var outputPath = GetTempPath();
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            Debug.Log("Exporting AssetBundles");
            var manifest = BuildPipeline.BuildAssetBundles(outputPath, builds, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            if (manifest == null)
                throw new BuildFailedException("Failed to build AssetBundles");
        }

        static string GetTempAssetBundlePath(string name) { return Path.Combine(GetTempPath(), name.ToLowerInvariant()); }

        static string GetTempPath()
        {
            var fullPath = Directory.GetParent(Application.dataPath).FullName;
            fullPath = Path.Combine(fullPath, k_AssetBundlePath);
            return fullPath;
        }

        internal static RequestHandle UploadSceneAssetBundle(this IUsesCloudStorage storageUser, string resourceFolder,
            string platform, string guid, Action<bool, string, long> callback = null, ProgressCallback progress = null)
        {
            return UploadAssetBundle(storageUser, CompanionAssetUtils.SceneAssetBundleGroupName, resourceFolder, platform, guid, callback, progress);
        }

        internal static RequestHandle SavePrefab(this IUsesCloudStorage storageUser, CompanionProject project, string resourceFolder,
            GameObject prefab, Action<bool, string> callback = null)
        {
            // Write to local storage in case cloud isn't reachable
            var prefabName = prefab.name;
            var path = AssetDatabase.GetAssetPath(prefab);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("Cannot get path for " + prefab);
                return default;
            }

            var guid = AssetDatabase.AssetPathToGUID(path);
            if (string.IsNullOrEmpty(guid))
            {
                Debug.LogError("Cannot get asset guid for path " + path);
                return default;
            }

            var prefabResource = new Prefab(prefabName);
            var jsonText = SceneSerialization.ToJson(prefabResource);
            CompanionAssetUtils.WriteLocalPrefab(project, resourceFolder, guid, jsonText);

            var prefabKey = CompanionAssetUtils.GetPrefabKey(resourceFolder, guid);
            return storageUser.CloudSaveAsync(prefabKey, jsonText, (success, responseCode, response) =>
            {
                Debug.LogFormat(success ? "Prefab resource {0} saved" : "Failed to save prefab resource {0}", prefabName);
                callback?.Invoke(success, prefabKey);
            });
        }

        internal static RequestHandle UploadPrefabAssetBundle(this IUsesCloudStorage storageUser, string resourceFolder,
            string platform, string guid, Action<bool, string, long> callback = null, ProgressCallback progress = null)
        {
            return UploadAssetBundle(storageUser, CompanionAssetUtils.PrefabAssetBundleGroupName, resourceFolder, platform, guid, callback, progress);
        }

        static RequestHandle UploadAssetBundle(this IUsesCloudStorage storageUser, string group, string resourceFolder,
            string platform, string guid, Action<bool, string, long> callback = null, ProgressCallback progress = null)
        {
            const int timeout = 0; // Asset bundles may be quite large and take a long time to upload
            var bundlePath = GetTempAssetBundlePath(guid);
            if (!File.Exists(bundlePath))
            {
                Debug.LogError("Could not find AssetBundle at path: " + bundlePath);
                callback?.Invoke(false, null, 0);
            }

            var assetBundle = File.ReadAllBytes(bundlePath);
            var key = CompanionAssetUtils.GetAssetBundleKey(group, resourceFolder, platform, guid);
            return storageUser.CloudSaveAsync(key, assetBundle, (success, responseCode, response) =>
            {
                Debug.LogFormat(success ? "AssetBundle {0} uploaded" : "Failed to upload AssetBundle {0}", key);
                callback?.Invoke(success, key, assetBundle.Length);
            }, progress, timeout);
        }

        internal static MarsMarkerLibrary[] LoadAllMarkerLibraryAssets()
        {
            return AssetDatabase.FindAssets(k_MarkerLibraryAssetSearch)
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<MarsMarkerLibrary>).ToArray();
        }

        internal static MarsMarkerLibrary CreateAndSaveNewLibrary()
        {
            var newMarkerLibrary = ScriptableObject.CreateInstance<MarsMarkerLibrary>();

            const string saveDialogTitle = "Save new image marker library";
            const string saveDialogMessage = "Choose where to save the new library";
            const string defaultFile = "New Image Marker Library";

            var savePath = EditorUtility.SaveFilePanelInProject(saveDialogTitle, defaultFile, "asset", saveDialogMessage);
            if (string.IsNullOrEmpty(savePath))
                return null;

            AssetDatabase.CreateAsset(newMarkerLibrary, savePath);
            AssetDatabase.SaveAssets();
            return newMarkerLibrary;
        }

        internal static Guid CreateMarkerInLibrary(MarsMarkerLibrary library, Marker marker, Texture2D markerImage, Vector2 size = default)
        {
            var insertIndex = library.Count;
            library.CreateAndAdd();
            library.SetLabel(insertIndex, marker.name);
            library.SetTexture(insertIndex, markerImage);

            if (size != default)
                library.SetSize(insertIndex, size);

            var guid = Guid.NewGuid();
            library.SetGuid(insertIndex, guid);
            library.SaveMarkerLibrary();

#if MARS_COMPANION_DATA_LOG
            Debug.Log($"Added new marker '{marker.name}' to image marker library '{library.name}'");
#endif
            return guid;
        }
    }
}

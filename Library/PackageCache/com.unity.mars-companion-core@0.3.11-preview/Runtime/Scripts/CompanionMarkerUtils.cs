// #define MARS_COMPANION_DATA_LOG

using System;
using System.Collections.Generic;
using System.IO;
using Unity.MARS.Companion.CloudStorage;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    static class CompanionMarkerUtils
    {
        const string k_MarkerImageGroupName = "MarkerImages";
        const string k_MarkerGroupName = "Markers";
        const string k_TmpFileFormat = "Image-{0}.png";
        const string k_FileFormat = "{0}.json";
        const string k_ImageFileFormat = "{0}.png";

        static string GetMarkerKey(string resourceFolder, string guid)
        {
            return $"{k_MarkerGroupName}_{resourceFolder}_{guid}";
        }

        internal static string GetMarkerImageKey(string resourceFolder, string guid)
        {
            return $"{k_MarkerImageGroupName}_{resourceFolder}_{guid}";
        }

        internal static void SplitMarkerKey(string key, out string resourceFolder, out string guid)
        {
            var parts = key.Split('_');
            if (parts.Length != 3)
            {
                resourceFolder = null;
                guid = null;
                return;
            }

            resourceFolder = parts[1];
            guid = parts[2];
        }

        static string GetTempImagePath() { return Path.Combine(Application.persistentDataPath, "Temp", string.Format(k_TmpFileFormat, DateTime.UtcNow.Ticks)); }

        static RequestHandle SaveMarker(this IUsesCloudStorage storageUser, CompanionProject project,
            string resourceFolder, string guid, Marker marker, Action<bool, string> callback)
        {
            var jsonText = SceneSerialization.ToJson(marker);
            WriteLocalMarker(project, resourceFolder, guid, jsonText);
            var key = GetMarkerKey(resourceFolder, guid);
            if (!project.linked)
            {
                callback?.Invoke(true, key);
                return default;
            }

            return storageUser.CloudSaveAsync(key, jsonText, (success, responseCode, response) =>
            {
#if MARS_COMPANION_DATA_LOG
                Debug.LogFormat(success ? "Marker {0} saved" : "Failed to save marker {0}", guid);
#endif

                callback?.Invoke(success, key);
            });
        }

        internal static void SaveMarkerAndUpdateResourceList(this IUsesCloudStorage storageUser, CompanionProject project,
            string resourceFolder, string markerName, string markerGuid, Marker marker, long fileSize,
            Stack<RequestHandle> requests, byte[] thumbnail = null, Action<bool, bool, string, ResourceList> callback = null)
        {
            requests.Push(SaveMarker(storageUser, project, resourceFolder, markerGuid, marker, (markerSuccess, key) =>
            {
                if (thumbnail != null)
                {
                    CompanionResourceUtils.SaveThumbnailImage(storageUser, project, resourceFolder, key, thumbnail, markerSuccess,
                        requests, (thumbnailSuccess, thumbnailKey) =>
                        {
                            storageUser.AddOrUpdateResource(project, resourceFolder, key, markerName, ResourceType.Marker,
                                fileSize, false, thumbnailSuccess, requests, (writeListSuccess, resourceList) =>
                                {
                                    callback?.Invoke(true, writeListSuccess, key, resourceList);
                                });
                        });
                }
                else
                {
                    storageUser.AddOrUpdateResource(project, resourceFolder, key, markerName, ResourceType.Marker,
                        fileSize, false, markerSuccess, requests, (writeListSuccess, resourceList) =>
                        {
                            callback?.Invoke(true, writeListSuccess, key, resourceList);
                        });
                }
            }));
        }

        internal static RequestHandle SaveMarkerImage(this IUsesCloudStorage storageUser, CompanionProject project,
            string resourceFolder, string markerGuid, byte[] imageBytes, Action<bool> callback = null)
        {
            // Write to local storage in case cloud isn't reachable
            var key = GetMarkerImageKey(resourceFolder, markerGuid);
            WriteLocalImage(project, resourceFolder, markerGuid, imageBytes);
            if (!project.linked)
            {
                callback?.Invoke(true);
                return default;
            }

            return storageUser.CloudSaveAsync(key, imageBytes, (success, responseCode, response) =>
            {
#if MARS_COMPANION_DATA_LOG
                Debug.LogFormat(success ? "Marker image {0} saved" : "Failed to save marker image {0}", key);
#endif

                callback?.Invoke(success);
            });
        }

        static string GetLocalImagePath(CompanionProject project, string resourceFolder, string guid)
        {
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_MarkerImageGroupName);
            var filename = string.Format(k_ImageFileFormat, guid);
            return Path.Combine(folder, filename);
        }

        static void WriteLocalImage(CompanionProject project, string resourceFolder, string guid, byte[] imageBytes)
        {
            var path = GetLocalImagePath(project, resourceFolder, guid);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Write marker image to path " + path);
#endif

            CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(path, imageBytes));
        }

        static byte[] GetLocalImage(CompanionProject project, string resourceFolder, string guid)
        {
            var path = GetLocalImagePath(project, resourceFolder, guid);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Write marker image to path " + path);
#endif

            try
            {
                if (!File.Exists(path))
                {
                    // TODO: error feedback
                    Debug.LogWarningFormat("Could not find Marker Image at path {0}", path);
                    return null;
                }

                return File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

        internal static RequestHandle DownloadMarkerImage(this IUsesCloudStorage storageUser, string markerKey, Action<bool, string> callback)
        {
            SplitMarkerKey(markerKey, out var resourceFolder, out var guid);
            var imageKey = GetMarkerImageKey(resourceFolder, guid);
            return storageUser.CloudLoadAsync(imageKey, (bool success, long responseCode, byte[] response) =>
            {
                var tempPath = GetTempImagePath();
                if (success)
                    CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(tempPath, response, callback));
                else
                    callback?.Invoke(false, tempPath);
            });
        }

        static string GetLocalMarker(CompanionProject project, string resourceFolder, string guid)
        {
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_MarkerGroupName);
            var filename = string.Format(k_FileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Get Marker from path " + path);
#endif

            if (!File.Exists(path))
            {
                // TODO: error feedback
                Debug.LogWarningFormat("Could not find Marker with key {0}", GetMarkerKey(resourceFolder, guid));
                return null;
            }

            return File.ReadAllText(path);
        }

        static void WriteLocalMarker(CompanionProject project, string resourceFolder, string guid, string jsonText)
        {
            // Write to local storage in case cloud isn't reachable
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_MarkerGroupName);
            var filename = string.Format(k_FileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Write Marker to path " + path);
#endif

            if (File.Exists(path))
                File.Delete(path);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(path, jsonText));
        }

        public static void DeleteLocalMarker(CompanionProject project, string key)
        {
            SplitMarkerKey(key, out var resourceFolder, out var guid);
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_MarkerGroupName);
            var filename = string.Format(k_FileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Delete scene at path " + path);
#endif

            if (File.Exists(path))
                File.Delete(path);

            path = GetLocalImagePath(project, resourceFolder, guid);
            if (File.Exists(path))
                File.Delete(path);
        }

        internal static void UploadMarker(this IUsesCloudStorage storageUser, CompanionProject project,
            CompanionResource resource, Stack<RequestHandle> requests, Action<bool> callback = null)
        {
            if (!project.linked)
            {
                Debug.LogError("Cannot upload marker in unlinked project");
                callback?.Invoke(false);
                return;
            }

            var key = resource.key;
            SplitMarkerKey(key, out var resourceFolder, out var markerGuid);
            var jsonText = GetLocalMarker(project, resourceFolder, markerGuid);
            if (string.IsNullOrEmpty(jsonText))
            {
                callback?.Invoke(false);
                return;
            }

            var imageBytes = GetLocalImage(project, resourceFolder, markerGuid);
            if (imageBytes == null)
            {
                callback?.Invoke(false);
                return;
            }

            requests.Push(storageUser.SaveMarkerImage(project, resourceFolder, markerGuid, imageBytes,
                saveImageSuccess =>
                {
                    if (saveImageSuccess)
                    {
                        requests.Push(storageUser.CloudSaveAsync(key, jsonText,
                            (success, responseCode, response) => callback?.Invoke(success)));
                    }
                    else
                    {
                        // TODO: Error feedback
                        callback?.Invoke(false);
                    }
                }));
        }
    }
}

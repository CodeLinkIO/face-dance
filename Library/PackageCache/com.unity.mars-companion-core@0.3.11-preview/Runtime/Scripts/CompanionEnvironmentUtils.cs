// #define MARS_COMPANION_DATA_LOG

using System;
using System.Collections.Generic;
using System.IO;
using Unity.MARS.Companion.CloudStorage;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    static class CompanionEnvironmentUtils
    {
        const string k_EnvironmentGroupName = "Environments";
        const string k_FileFormat = "{0}.json";

        static string GetEnvironmentKey(string resourceFolder, string guid)
        {
            return $"{k_EnvironmentGroupName}_{resourceFolder}_{guid}";
        }

        public static void SplitEnvironmentKey(string key, out string resourceFolder, out string guid)
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

        static RequestHandle SaveEnvironment(this IUsesCloudStorage storageUser, CompanionProject project,
            string resourceFolder, string guid, Environment environment, Action<bool, string, long> callback)
        {
            var jsonText = SceneSerialization.ToJson(environment);

            // Write to local storage in case cloud isn't reachable
            WriteLocalEnvironment(project, resourceFolder, guid, jsonText);
            var key = GetEnvironmentKey(resourceFolder, guid);
            if (!project.linked)
            {
                callback?.Invoke(true, key, jsonText.Length);
                return default;
            }

            return storageUser.CloudSaveAsync(key, jsonText, (success, responseCode, response) =>
            {
#if MARS_COMPANION_DATA_LOG
                Debug.LogFormat(success ? "Environment {0} saved" : "Failed to save environment {0}", guid);
#endif

                callback?.Invoke(success, key, jsonText.Length);
            });
        }

        internal static void SaveEnvironmentAndUpdateResourceList(this IUsesCloudStorage storageUser, CompanionProject project,
            string resourceFolder, string environmentName, Environment environment, Stack<RequestHandle> requests,
            byte[] thumbnail = null, Action<bool, bool, string, ResourceList> callback = null)
        {
            requests.Push(SaveEnvironment(storageUser, project, resourceFolder, Guid.NewGuid().ToString(), environment,
                (environmentSuccess, key, fileSize) =>
                {
                    if (thumbnail != null)
                    {
                        storageUser.SaveThumbnailImage(project, resourceFolder, key, thumbnail, environmentSuccess, requests, (thumbnailSuccess, thumbnailKey) =>
                        {
                            storageUser.AddOrUpdateResource(project, resourceFolder, key, environmentName,
                                ResourceType.Environment, fileSize, false, thumbnailSuccess, requests, (writeListSuccess, resourceList) =>
                                {
                                    callback?.Invoke(true, writeListSuccess, key, resourceList);
                                });
                        });
                    }
                    else
                    {
                        storageUser.AddOrUpdateResource(project, resourceFolder, key, environmentName,
                            ResourceType.Environment, fileSize, false, environmentSuccess, requests, (writeListSuccess, resourceList) =>
                            {
                                callback?.Invoke(true, writeListSuccess, key, resourceList);
                            });
                    }
                }));
        }

        static string GetLocalEnvironment(CompanionProject project, string key)
        {
            SplitEnvironmentKey(key, out var resourceFolder, out var guid);
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_EnvironmentGroupName);
            var filename = string.Format(k_FileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Get environment from path " + path);
#endif

            if (!File.Exists(path))
            {
                // TODO: error feedback
                Debug.LogWarningFormat("Could not find environment with key {0}", key);
                return null;
            }

            return File.ReadAllText(path);
        }

        static void WriteLocalEnvironment(CompanionProject project, string resourceFolder, string guid, string jsonText)
        {
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_EnvironmentGroupName);
            var filename = string.Format(k_FileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Write environment to path " + path);
#endif

            CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(path, jsonText));
        }

        public static void DeleteLocalEnvironment(CompanionProject project, string key)
        {
            SplitEnvironmentKey(key, out var resourceFolder, out var guid);
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_EnvironmentGroupName);
            var filename = string.Format(k_FileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Delete scene at path " + path);
#endif

            if (File.Exists(path))
                File.Delete(path);
        }

        internal static RequestHandle UploadEnvironment(this IUsesCloudStorage storageUser, CompanionProject project,
            CompanionResource resource, Action<bool> callback = null)
        {
            if (!project.linked)
            {
                Debug.LogError("Cannot upload resource on unlinked project");
                callback?.Invoke(false);
                return default;
            }

            var key = resource.key;
            var jsonText = GetLocalEnvironment(project, key);
            if (string.IsNullOrEmpty(jsonText))
            {
                callback?.Invoke(false);
                return default;
            }

            return storageUser.CloudSaveAsync(key, jsonText,
                (success, responseCode, response) => callback?.Invoke(success));
        }
    }
}

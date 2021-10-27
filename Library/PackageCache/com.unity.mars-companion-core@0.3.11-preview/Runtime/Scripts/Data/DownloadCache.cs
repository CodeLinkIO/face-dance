using System;
using System.Collections.Generic;
using Unity.MARS.Companion.CloudStorage;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    static class DownloadCache
    {
        static readonly Dictionary<string, GameObject> k_CachedPrefabs = new Dictionary<string, GameObject>();

        // Resource lists are created and destroyed frequently--cache thumbnail image that we've already loaded
        static readonly Dictionary<string, Texture2D> k_CachedThumbnails = new Dictionary<string, Texture2D>();

        public static void GetPrefab(IUsesCloudStorage storageUser, CompanionProject project, string key, Action<GameObject> callback)
        {
            if (k_CachedPrefabs.TryGetValue(key, out var prefab))
            {
                callback?.Invoke(prefab);
            }
            else
            {
                storageUser.GetPrefabAsset(project, key, (success, downloadedPrefab) =>
                {
                    SetPrefab(key, downloadedPrefab);
                    callback?.Invoke(downloadedPrefab);
                });
            }
        }

        static void SetPrefab(string key, GameObject prefab)
        {
            k_CachedPrefabs[key] = prefab;
        }

        public static bool TryGetThumbnail(string key, out Texture2D outThumbnail)
        {
            return k_CachedThumbnails.TryGetValue(key, out outThumbnail);
        }

        public static void SetThumbnail(string key, Texture2D thumbnail)
        {
            k_CachedThumbnails[key] = thumbnail;
        }

        public static void ClearCache()
        {
            k_CachedPrefabs.Clear();
            k_CachedThumbnails.Clear();
        }
    }
}

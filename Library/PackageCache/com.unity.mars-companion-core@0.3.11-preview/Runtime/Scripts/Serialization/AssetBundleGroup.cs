using System;
using System.Collections.Generic;
using Unity.MARS.Companion.CloudStorage;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class AssetBundleGroup : ISerializationCallbackReceiver
    {
#pragma warning disable 649
        [SerializeField]
        string m_Key;

        [SerializeField]
        List<AssetBundleResource> m_Bundles = new List<AssetBundleResource>();
#pragma warning restore 649

        readonly Dictionary<string, AssetBundleResource> m_BundleDictionary = new Dictionary<string, AssetBundleResource>();

        public AssetBundleGroup cloudVersion { get; set; }
        public bool isCloudResource { get; set; }
        public string Key => m_Key;
        public int Count => m_BundleDictionary.Count;

        public bool TryGetBundleResource(string platform, out AssetBundleResource resource) { return m_BundleDictionary.TryGetValue(platform, out resource); }

        public AssetBundleGroup() { }
        public AssetBundleGroup(string key) { m_Key = key; }

        public void OnBeforeSerialize()
        {
            m_Bundles.Clear();
            foreach (var kvp in m_BundleDictionary)
            {
                m_Bundles.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            m_BundleDictionary.Clear();
            foreach (var bundle in m_Bundles)
            {
                m_BundleDictionary[bundle.Platform] = bundle;
            }
        }

        public void AddOrUpdateBundle(string platform, string bundleKey, long fileSize)
        {
            if (m_BundleDictionary.TryGetValue(platform, out var bundle))
            {
                bundle.Update(bundleKey, fileSize);
                return;
            }

            bundle = new AssetBundleResource(platform, bundleKey, fileSize);
            m_BundleDictionary[platform] = bundle;
        }

        public bool HasBundleForPlatform(string platform) { return m_BundleDictionary.ContainsKey(platform); }
        public long GetFileSize()
        {
            var result = 0L;
            foreach (var kvp in m_BundleDictionary)
            {
                result += kvp.Value.FileSize;
            }

            return result;
        }

        public void RemoveAssetBundle(string platform)
        {
            m_BundleDictionary.Remove(platform);
        }

        public void DeleteBundles(IUsesCloudStorage storageUser, Stack<RequestHandle> requests)
        {
            foreach (var kvp in m_BundleDictionary)
            {
                requests.Push(storageUser.CloudSaveAsync(kvp.Value.Key, string.Empty));
            }
        }
    }
}

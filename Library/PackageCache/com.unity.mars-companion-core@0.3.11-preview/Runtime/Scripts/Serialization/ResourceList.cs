using System;
using System.Collections.Generic;
using System.Text;
using Unity.RuntimeSceneSerialization;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class ResourceList : ISerializationCallbackReceiver, IFormatVersion
    {
        const int k_FormatVersion = 1;

        [SerializeField]
        int m_FormatVersion = k_FormatVersion;

        [SerializeField]
        List<CompanionResource> m_Resources = new List<CompanionResource>();

        [SerializeField]
        List<AssetBundleGroup> m_BundleGroups = new List<AssetBundleGroup>();

        readonly Dictionary<string, CompanionResource> m_ResourceDictionary = new Dictionary<string, CompanionResource>();
        readonly Dictionary<string, AssetBundleGroup> m_BundleDictionary = new Dictionary<string, AssetBundleGroup>();

        bool m_Merged;

        public bool Merged => m_Merged;

        public bool TryGetResource(string key, out CompanionResource resource) { return m_ResourceDictionary.TryGetValue(key, out resource); }

        public bool TryGetBundleGroup(string key, out AssetBundleGroup resource) { return m_BundleDictionary.TryGetValue(key, out resource); }

        /// <summary>
        /// Add a new or updated resource the list. The current time will be applied as a timestamp
        /// </summary>
        /// <param name="key">The storage key of the new resource</param>
        /// <param name="name">The name of the new resource</param>
        /// <param name="type">The type of the new resource</param>
        /// <param name="fileSize">The file size of the new resource</param>
        /// <param name="hasBundle">Whether this resource has an associated AssetBundle</param>
        /// <returns>The ResourceListViewData that was created or updated</returns>
        public CompanionResource AddOrUpdateResource(string key, string name, ResourceType type, long fileSize, bool hasBundle)
        {
            if (m_ResourceDictionary.TryGetValue(key, out var resource))
            {
                resource.Update(name, fileSize, hasBundle);
            }
            else
            {
                resource = new CompanionResource(key, name, type, fileSize, hasBundle);
                m_ResourceDictionary[key] = resource;
            }

            return resource;
        }

        /// <summary>
        /// Add or overwrite an existing resource. The timestamp in the provided resource will be preserved
        /// </summary>
        /// <param name="resource">The resource to add or write to the list </param>
        public void AddOrOverwriteExistingResource(CompanionResource resource)
        {
            m_ResourceDictionary[resource.key] = resource;
        }

        public void RemoveResource(string index)
        {
            m_ResourceDictionary.Remove(index);
            m_BundleDictionary.Remove(index);
        }

        public void RemoveResources(List<CompanionResource> resources)
        {
            foreach (var resource in resources)
            {
                m_ResourceDictionary.Remove(resource.key);
            }
        }

        public string GetListAsString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Resources:\n");
            foreach (var resource in m_Resources)
            {
                stringBuilder.Append("\n");
                stringBuilder.Append(resource.name);
            }

            return stringBuilder.ToString();
        }

        public List<CompanionResource> GetSortedList()
        {
            var list = new List<CompanionResource>();
            foreach (var kvp in m_ResourceDictionary)
            {
                list.Add(kvp.Value);
            }

            list.Sort((a, b) =>
            {
                var aType = (int)a.type;
                var bType = (int)b.type;
                var compare = aType.CompareTo(bType);
                if (compare != 0)
                    return compare;

                return b.timestamp.CompareTo(a.timestamp);
            });

            return list;
        }

        public void OnBeforeSerialize()
        {
            m_Resources.Clear();
            foreach (var kvp in m_ResourceDictionary)
            {
                m_Resources.Add(kvp.Value);
            }

            m_BundleGroups.Clear();
            foreach (var kvp in m_BundleDictionary)
            {
                m_BundleGroups.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            foreach (var resource in m_Resources)
            {
                m_ResourceDictionary[resource.key] = resource;
            }

            foreach (var resource in m_BundleGroups)
            {
                if (resource.Key == null)
                    continue;

                m_BundleDictionary[resource.Key] = resource;
            }
        }

        public static ResourceList MergeResourceLists(ResourceList local, ResourceList remote)
        {
            if (local == null)
                return remote;

            if (remote == null)
                return local;

            var resourceList = new ResourceList();
            resourceList.m_Merged = true;
            var resourceDictionary = resourceList.m_ResourceDictionary;
            var bundleDictionary = resourceList.m_BundleDictionary;
            foreach (var kvp in local.m_ResourceDictionary)
            {
                resourceDictionary[kvp.Key] = kvp.Value;
            }

            foreach (var kvp in local.m_BundleDictionary)
            {
                bundleDictionary[kvp.Key] = kvp.Value;
            }

            foreach (var kvp in remote.m_ResourceDictionary)
            {
                var key = kvp.Key;
                if (resourceDictionary.TryGetValue(key, out var resource))
                    resource.cloudVersion = kvp.Value;
                else
                    resourceDictionary[key] = kvp.Value;
            }

            foreach (var kvp in remote.m_BundleDictionary)
            {
                var key = kvp.Key;
                if (bundleDictionary.TryGetValue(key, out var group))
                    group.cloudVersion = kvp.Value;
                else
                    bundleDictionary[key] = kvp.Value;
            }

            return resourceList;
        }

        public void SetCloudResource(bool isCloudResourceList)
        {
            foreach (var kvp in m_ResourceDictionary)
            {
                kvp.Value.isCloudResource = isCloudResourceList;
            }

            foreach (var kvp in m_BundleDictionary)
            {
                kvp.Value.isCloudResource = isCloudResourceList;
            }
        }

        public bool HasAssetBundle(string key, string platform)
        {
            if (!m_BundleDictionary.TryGetValue(key, out var group))
                return false;

            return group.HasBundleForPlatform(platform);
        }

        public bool TryGetAssetBundleKey(string key, string platform, out string bundleKey)
        {
            if (m_BundleDictionary.TryGetValue(key, out var group))
            {
                if (group.TryGetBundleResource(platform, out var bundle))
                {
                    bundleKey = bundle.Key;
                    return true;
                }

                var cloudVersion = group.cloudVersion;
                if (cloudVersion != null)
                {
                    if (cloudVersion.TryGetBundleResource(platform, out bundle))
                    {
                        bundleKey = bundle.Key;
                        return true;
                    }
                }
            }

            bundleKey = default;
            return false;
        }

        public void AddOrUpdateBundle(string key, string platform, string bundleKey, long fileSize)
        {
            if (!m_BundleDictionary.TryGetValue(key, out var group))
            {
                group = new AssetBundleGroup(key);
                m_BundleDictionary[key] = group;
            }

            group.AddOrUpdateBundle(platform, bundleKey, fileSize);
        }

        public long GetBundleGroupSize(string key, bool useCloudVersion = false)
        {
            if (!m_BundleDictionary.TryGetValue(key, out var group))
                return 0;

            if (useCloudVersion && !group.isCloudResource)
            {
                var cloudVersion = group.cloudVersion;
                if (cloudVersion != null)
                    return cloudVersion.GetFileSize();

                return 0;
            }

            return group.GetFileSize();
        }

        public void CheckFormatVersion()
        {
            if (m_FormatVersion != k_FormatVersion)
                throw new FormatException($"Serialization format mismatch. Expected {k_FormatVersion} but was {m_FormatVersion}.");
        }

        public void RemoveAssetBundle(string resourceKey, string platform)
        {
            if (!m_BundleDictionary.TryGetValue(resourceKey, out var bundleGroup))
                return;

            bundleGroup.RemoveAssetBundle(platform);
            if (bundleGroup.Count == 0)
                m_BundleDictionary.Remove(resourceKey);
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.ListViewFramework;
using Unity.MARS.Companion.CloudStorage;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    enum ResourceType
    {
        Scene,
        Environment,
        Recording,
        Marker,
        Prefab
    }

    [Serializable]
    class CompanionResource : IListViewItemData<string>
    {
        const string k_Template = "ResourceListViewItem";

#pragma warning disable 649
        [SerializeField]
        string m_Key;

        [SerializeField]
        string m_Name;

        [SerializeField]
        int m_Type;

        [SerializeField]
        long m_FileSize;

        [SerializeField]
        long m_Timestamp;

        [SerializeField]
        bool m_HasAssetBundle;
#pragma warning restore 649

        Texture2D m_Thumbnail;

        public string index { get { return m_Key; } }
        public string key { get { return m_Key; } }
        public string name { get { return m_Name; } }
        public ResourceType type { get { return (ResourceType)m_Type; } }
        public virtual string template { get { return k_Template; } }
        public long timestamp { get { return m_Timestamp; } }
        public bool hasAssetBundle { get => m_HasAssetBundle; }
        public bool selected { get; set; }
        public long fileSize { get => m_FileSize; }
        public Texture2D cachedThumbnail { get => m_Thumbnail; }

        public bool isCloudResource { get; set; }
        public CompanionResource cloudVersion { get; set; }

        public CompanionResource() { }

        public CompanionResource(string key, string name, ResourceType type, long fileSize, bool hasBundle)
        {
            m_Key = key;
            m_Name = name;
            m_Type = (int)type;
            m_Timestamp = DateTime.UtcNow.Ticks;
            m_FileSize = fileSize;
            m_HasAssetBundle = hasBundle;
        }

        public void Update(string newName, long size, bool hasBundle)
        {
            m_Name = newName;
            m_Timestamp = DateTime.UtcNow.Ticks;
            m_FileSize = size;
            m_HasAssetBundle = hasBundle;
        }

        // From https://www.somacon.com/p576.php
        internal string GetReadableFileSize(long extraSize = 0)
        {
            var size = m_FileSize + extraSize;
            return CompanionFileUtils.GetReadableFileSize(size);
        }

        internal string GetReadableTimestamp()
        {
            var dateTime = new DateTime(m_Timestamp).ToLocalTime();
            return dateTime.ToString("dd/MM/yy HH:mm");
        }

        public string GetMetadataString(long extraSize = 0) { return $"{GetReadableTimestamp()} - {GetReadableFileSize(extraSize)}"; }

        public SynchronizationStatus GetSyncStatus()
        {
            switch (type)
            {
                // Scenes are editable so show CloudOnly status
                case ResourceType.Scene:
                    if (cloudVersion == null)
                        return isCloudResource ? SynchronizationStatus.CloudOnly : SynchronizationStatus.LocalOnly;

                    return cloudVersion.timestamp == timestamp ? SynchronizationStatus.Synced : SynchronizationStatus.Conflicted;

                // You can't edit other resource types, so cloud-only and synced show up as no status
                default:
                    if (cloudVersion == null)
                        return isCloudResource ? SynchronizationStatus.None : SynchronizationStatus.LocalOnly;

                    return cloudVersion.timestamp == timestamp ? SynchronizationStatus.Synced : SynchronizationStatus.Conflicted;
            }
        }

        public void GetThumbnail(IUsesCloudStorage storageUser, CompanionProject project,
            Stack<RequestHandle> requests, Action<Texture2D> callback = null)
        {
            if (m_Thumbnail == null)
            {
                if (DownloadCache.TryGetThumbnail(m_Key, out m_Thumbnail))
                {
                    callback?.Invoke(m_Thumbnail);
                }
                else
                {
                    storageUser.GetThumbnailImage(project, m_Key, requests,  (success, texture) =>
                    {
                        if (texture != null)
                            texture.filterMode = FilterMode.Trilinear;

                        m_Thumbnail = texture;
                        DownloadCache.SetThumbnail(m_Key, texture);
                        callback?.Invoke(texture);
                    });
                }
            }
            else
            {
                callback?.Invoke(m_Thumbnail);
            }
        }
    }
}

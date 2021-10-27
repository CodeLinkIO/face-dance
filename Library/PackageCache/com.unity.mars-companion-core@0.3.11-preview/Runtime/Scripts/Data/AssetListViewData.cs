using System;
using System.Collections.Generic;
using Unity.ListViewFramework;
using Unity.MARS.Companion.CloudStorage;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class AssetListViewData : IListViewItemData<string>
    {
        const string k_Template = "AssetListViewItem";

        [SerializeField]
        string m_Key;

        [SerializeField]
        string m_Name;

        [SerializeField]
        GameObject m_Prefab;

        [SerializeField]
        string m_Guid;

        [SerializeField]
        Texture2D m_Thumbnail;

        public string index => m_Key;
        public bool selected => false;
        public string name => m_Name;
        public string template => k_Template;
        public string guid { get => m_Guid; internal set => m_Guid = value; }
        public GameObject prefab => m_Prefab;

        public AssetListViewData() { }

        public AssetListViewData(string key, string name)
        {
            m_Key = key;
            m_Name = name;
            CompanionAssetUtils.SplitPrefabKey(key, out _, out m_Guid);
        }

        public void GetPrefab(IUsesCloudStorage storageUser, CompanionProject project, Action<GameObject> callback = null)
        {
            if (m_Prefab == null)
            {
                DownloadCache.GetPrefab(storageUser, project, m_Key, downloadedPrefab =>
                {
                    m_Prefab = downloadedPrefab;
                    callback?.Invoke(downloadedPrefab);
                });
            }
            else
            {
                callback?.Invoke(m_Prefab);
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
                    storageUser.GetThumbnailImage(project, m_Key, requests, (success, texture) =>
                    {
                        if(texture != null)
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

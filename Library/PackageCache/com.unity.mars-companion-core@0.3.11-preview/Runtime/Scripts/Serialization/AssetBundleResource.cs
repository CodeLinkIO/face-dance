using System;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    [Serializable]
    class AssetBundleResource
    {
#pragma warning disable 649
        [SerializeField]
        string m_Platform;

        [SerializeField]
        string m_Key;

        [SerializeField]
        long m_FileSize;

        [SerializeField]
        long m_Timestamp;
#pragma warning restore 649

        public string Platform => m_Platform;
        public string Key => m_Key;
        public long FileSize => m_FileSize;
        public long Timestamp => m_Timestamp;

        public AssetBundleResource() { }

        public AssetBundleResource(string platform, string key, long fileSize)
        {
            m_Platform = platform;
            m_Key = key;
            m_FileSize = fileSize;
            m_Timestamp = DateTime.UtcNow.Ticks;
        }

        public void Update(string key, long fileSize)
        {
            m_Key = key;
            m_FileSize = fileSize;
            m_Timestamp = DateTime.UtcNow.Ticks;
        }
    }
}

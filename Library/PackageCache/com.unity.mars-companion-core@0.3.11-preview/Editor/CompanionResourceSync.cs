using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// Tracks associations between MARS Companion cloud resources and assets in a Unity project
    /// </summary>
    [ScriptableSettingsPath(MARSCore.SettingsFolder)]
    public class CompanionResourceSync : EditorScriptableSettings<CompanionResourceSync>, ISerializationCallbackReceiver
    {
        [Serializable]
        struct Resource : IComparable<Resource>
        {
            [SerializeField]
            string m_AssetGuid;

            [SerializeField]
            string m_CloudGuid;

            public string AssetGuid => m_AssetGuid;
            public string CloudGuid => m_CloudGuid;

            public Resource(string assetGuid, string cloudGuid)
            {
                m_AssetGuid = assetGuid;
                m_CloudGuid = cloudGuid;
            }

            public int CompareTo(Resource other)
            {
                var assetGuidComparison = string.Compare(m_AssetGuid, other.m_AssetGuid, StringComparison.Ordinal);
                if (assetGuidComparison != 0)
                    return assetGuidComparison;

                return string.Compare(m_CloudGuid, other.m_CloudGuid, StringComparison.Ordinal);
            }
        }

        [SerializeField]
        List<Resource> m_Resources;

        [SerializeField]
        MarsMarkerLibrary m_DefaultMarkerLibrary;

        readonly Dictionary<string, string> m_CloudToAsset = new Dictionary<string, string>();
        readonly Dictionary<string, string> m_AssetToCloud = new Dictionary<string, string>();

        internal Dictionary<string, string> ResourceDictionary => m_CloudToAsset;
        internal MarsMarkerLibrary DefaultMarkerLibrary
        {
            get => m_DefaultMarkerLibrary;
            set => m_DefaultMarkerLibrary = value;
        }

        /// <summary>
        /// Called when this ScriptableObject is loaded
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (m_DefaultMarkerLibrary == null)
            {
                var libraries = CompanionEditorAssetUtils.LoadAllMarkerLibraryAssets();
                if (libraries.Length > 0)
                {
                    m_DefaultMarkerLibrary = libraries[0];
                    EditorUtility.SetDirty(this);
                }
            }
        }

        /// <summary>
        /// Called before serialization to set up lists from dictionaries
        /// </summary>
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (m_Resources == null)
                m_Resources = new List<Resource>(m_AssetToCloud.Count);
            else
                m_Resources.Clear();

            foreach (var kvp in m_AssetToCloud)
            {
                m_Resources.Add(new Resource(kvp.Key, kvp.Value));
            }

            m_Resources.Sort();
        }

        /// <summary>
        /// Called after deserialization to set up dictionaries from lists
        /// </summary>
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            m_AssetToCloud.Clear();
            m_CloudToAsset.Clear();

            foreach (var scene in m_Resources)
            {
                m_AssetToCloud[scene.AssetGuid] = scene.CloudGuid;
                m_CloudToAsset[scene.CloudGuid] = scene.AssetGuid;
            }
        }

        /// <summary>
        /// Get a new or existing cloud guid for a given asset guid
        /// </summary>
        /// <param name="assetGuid">The asset guid</param>
        /// <returns>The cloud guid for the resource associated with the given asset guid, or a new guid if one was not found</returns>
        public string GetCloudGuid(string assetGuid)
        {
            if (!m_AssetToCloud.TryGetValue(assetGuid, out var cloudGuid))
            {
                cloudGuid = Guid.NewGuid().ToString();
                m_AssetToCloud[assetGuid] = cloudGuid;
                m_CloudToAsset[cloudGuid] = assetGuid;

                EditorUtility.SetDirty(this);
            }

            return cloudGuid;
        }

        /// <summary>
        /// Get an asset guid for a given cloud guid, or null if the cloud guid is not tracked
        /// </summary>
        /// <param name="cloudGuid">The cloud guid</param>
        /// <returns>The asset guid for the asset associated with the given cloud guid, or null if one was not found</returns>
        public string GetAssetGuid(string cloudGuid)
        {
            if (m_CloudToAsset.TryGetValue(cloudGuid, out var assetGuid))
                return assetGuid;

            return null;
        }

        /// <summary>
        /// Associate an asset guid to a cloud guid
        /// </summary>
        /// <param name="assetGuid">The asset guid to be associated to this cloud guid</param>
        /// <param name="cloudGuid">The cloud guid associated to this asset guid</param>
        public void SetAssetGuid(string assetGuid, string cloudGuid)
        {
            m_AssetToCloud[assetGuid] = cloudGuid;
            m_CloudToAsset[cloudGuid] = assetGuid;

            EditorUtility.SetDirty(this);
        }

        /// <summary>
        /// Remove a tracked resource, using its cloud guid as the key
        /// </summary>
        /// <param name="cloudGuid">The cloud guid of the resource to remove</param>
        public void RemoveCloudGuid(string cloudGuid)
        {
            if (!m_CloudToAsset.TryGetValue(cloudGuid, out var assetGuid))
                return;

            m_CloudToAsset.Remove(cloudGuid);
            m_AssetToCloud.Remove(assetGuid);

            EditorUtility.SetDirty(this);
        }
    }
}

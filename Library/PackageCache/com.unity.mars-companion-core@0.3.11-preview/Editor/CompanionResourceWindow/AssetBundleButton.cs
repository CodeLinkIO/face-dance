using System;
using System.Collections.Generic;
using Unity.MARS.Companion.CloudStorage;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Companion.Core
{
    class AssetBundleButton : Button
    {
        internal delegate void UploadComplete(bool success, string resourceKey, RuntimePlatform platform, string bundleKey, long fileSize);
        internal delegate void UploadProgress(string guid, float progress);

        enum State
        {
            NotUploaded,
            Uploaded,
            Update,
            Warn
        }

        const string k_NotUploadedIcon = "not_uploaded_icon";
        const string k_UploadedIcon = "uploaded_icon";
        const string k_UpdateIcon = "update_icon";
        const string k_WarnIcon = "warn_icon";

        State m_State;
        readonly CompanionResource m_Resource;
        readonly AssetBundleResource m_Bundle;
        readonly RuntimePlatform m_Platform;
        readonly UnityObject m_Asset;
        readonly IUsesCloudStorage m_StorageUser;

        string m_Guid;
        UploadProgress m_UploadProgressCallback;
        UploadComplete m_UploadCompleteCallback;

        public string Guid => m_Guid;

        public AssetBundleButton(CompanionResource resource, AssetBundleResource bundle, RuntimePlatform platform,
            UnityObject asset, IUsesCloudStorage storageUser)
        {
            clicked += OnClicked;

            if (asset == null)
                SetEnabled(false);

            m_Resource = resource;
            m_Platform = platform;
            m_Bundle = bundle;
            m_Asset = asset;
            m_StorageUser = storageUser;

            name = $"{resource.name} - {platform} bundle button";

            var state = State.NotUploaded;
            if (m_Bundle != null)
            {
                if (m_Bundle.Timestamp >= m_Resource.timestamp)
                    state = State.Uploaded;
                else
                    state = CompanionResourceUI.IsPlatformInstalled(m_Platform) ? State.Update : State.Warn;
            }

            SetState(state);
        }

        void SetState(State state)
        {
            m_State = state;

            ClearClassList();
            AddToClassList(CompanionResourceUI.ColumnBundleClassName);
            switch (state)
            {
                case State.NotUploaded:
                    AddToClassList(k_NotUploadedIcon);
                    break;
                case State.Uploaded:
                    AddToClassList(k_UploadedIcon);
                    break;
                case State.Update:
                    AddToClassList(k_UpdateIcon);
                    break;
                case State.Warn:
                    AddToClassList(k_WarnIcon);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        void OnClicked()
        {
            switch (m_State)
            {
                case State.NotUploaded:
                    if (m_Bundle != null && m_Bundle.Timestamp < m_Resource.timestamp)
                        SetState(State.Update);
                    else
                        SetState(CompanionResourceUI.IsPlatformInstalled(m_Platform) ? State.Uploaded : State.Warn);
                    break;
                case State.Uploaded:
                    SetState(State.NotUploaded);
                    break;
                case State.Update:
                    SetState(State.Uploaded);
                    break;
                case State.Warn:
                    SetState(State.NotUploaded);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool NeedsUpdate()
        {
            switch (m_State)
            {
                case State.NotUploaded:
                    return m_Bundle != null;
                case State.Uploaded:
                    return m_Bundle == null;
                case State.Update:
                    if (m_Bundle != null)
                        return m_Bundle.Timestamp <= m_Resource.timestamp;
                    else
                        throw new Exception("Button is in update state but BundleResource is null");
                case State.Warn:
                    return false;
            }

            return false;
        }

        public void Process(ResourceList resourceList, List<AssetBundleBuild> builds,
            Dictionary<string, AssetImporter> importers, Stack<RequestHandle> requests)
        {
            switch (m_State)
            {
                case State.NotUploaded:
                    if (m_Bundle == null)
                        return;

                    resourceList.RemoveAssetBundle(m_Resource.key, m_Platform.ToString());
                    requests.Push(m_StorageUser.CloudSaveAsync(m_Bundle.Key, string.Empty));
                    return;
                case State.Uploaded:
                    if (m_Bundle != null)
                        return;

                    BuildAssetBundle(builds, importers);
                    return;
                case State.Update:
                    if (m_Bundle == null)
                        throw new Exception("Button is in update state but BundleResource is null");

                    if (m_Bundle.Timestamp > m_Resource.timestamp)
                        return;

                    BuildAssetBundle(builds, importers);
                    return;
            }
        }

        void BuildAssetBundle(List<AssetBundleBuild> builds, Dictionary<string, AssetImporter> importers)
        {
            var path = AssetDatabase.GetAssetPath(m_Asset);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError($"Could not find path for {m_Asset}");
                return;
            }

            m_Guid = AssetDatabase.AssetPathToGUID(path);
            if (!importers.ContainsKey(m_Guid))
            {
                if (string.IsNullOrEmpty(m_Guid))
                {
                    Debug.LogError("Could not get valid guid for asset at path " + path);
                    return;
                }

                // Check existing asset bundle name to avoid overwriting it
                var assetImporter = AssetImporter.GetAtPath(path);
                if (!string.IsNullOrEmpty(assetImporter.assetBundleName) && assetImporter.assetBundleName != m_Guid)
                {
                    Debug.LogError($"{m_Asset.name} is already part of an AssetBundle, and cannot be published to the cloud without overwriting its AssetBundle name");
                    return;
                }

                assetImporter.assetBundleName = m_Guid;
                importers[m_Guid] = assetImporter;
            }

            builds.Add(new AssetBundleBuild
            {
                assetBundleName = m_Guid,
                assetNames = new[] { path }
            });
        }

        internal bool PublishBundleAndCleanUp(string resourceFolder, UploadComplete complete, UploadProgress progress,
            Stack<RequestHandle> requests)
        {
            if (string.IsNullOrEmpty(m_Guid))
                return false;

            m_UploadCompleteCallback = complete;
            m_UploadProgressCallback = progress;
            switch (m_Resource.type)
            {
                case ResourceType.Scene:
                    requests.Push(m_StorageUser.UploadSceneAssetBundle(resourceFolder, m_Platform.ToString(), m_Guid,
                        OnComplete, OnUploadProgress));

                    break;
                case ResourceType.Prefab:
                    requests.Push(m_StorageUser.UploadPrefabAssetBundle(resourceFolder, m_Platform.ToString(), m_Guid,
                        OnComplete, OnUploadProgress));

                    break;
                default:
                    Debug.LogWarning($"Trying to upload asset bundle {m_Resource.name} which is of type {m_Resource.type} which is not a Scene or a Prefab");
                    break;
            }

            return true;
        }

        void OnComplete(bool success, string bundleKey, long fileSize)
        {
            m_UploadCompleteCallback(success, m_Resource.key, m_Platform, bundleKey, fileSize);
        }

        void OnUploadProgress(float upload, float download)
        {
            m_UploadProgressCallback(m_Guid, upload);
        }

        public void SetUploadOrUpdate()
        {
            if (m_Bundle != null)
                SetState(m_Bundle.Timestamp <= m_Resource.timestamp ? State.Update : State.Uploaded);
            else
                SetState(State.Uploaded);
        }

        public void SetNotUploaded()
        {
            SetState(State.NotUploaded);
        }
    }
}

// #define MARS_COMPANION_DATA_LOG

using System;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.MARS.Companion.CloudStorage;
using Unity.MARS.Data.Recorded;
using Unity.RuntimeSceneSerialization;
using Unity.Serialization.Binary;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// Utility methods for synchronizing data recordings using cloud storage
    /// </summary>
    static class CompanionDataRecordingUtils
    {
        [Serializable]
        struct CameraPathRecording
        {
            public List<PoseEvent> events;
        }

        [Serializable]
        struct PlaneDataRecording
        {
            public List<PlaneEvent> events;
        }

        [Serializable]
        struct PointCloudRecording
        {
            public List<PointCloudEvent> events;
        }

        internal const string VideoType = "Videos";
        internal const string CameraPathType = "CameraPaths";
        internal const string PlaneDataType = "PlaneData";
        internal const string PointCloudType = "PointClouds";

        const string k_DataRecordingType = "DataRecordings";

        const string k_TmpVideoFileFormat = "Recording-{0}.mp4";
        const string k_JsonFileFormat = "{0}.json";
        const string k_BinaryFileFormat = "{0}.bin";

        static string GetDataRecordingKey(string resourceFolder, string guid) { return $"{k_DataRecordingType}_{resourceFolder}_{guid}"; }

        internal static string GetRecordingComponentKey(string type, string resourceFolder, string resourceGuid) { return $"{type}_{resourceFolder}_{resourceGuid}"; }

        internal static void SplitDataRecordingKey(string key, out string resourceFolder, out string guid)
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

        static RequestHandle SaveDataRecording(this IUsesCloudStorage storageUser, CompanionProject project, string resourceFolder,
            string guid, CompanionDataRecording recording, Action<bool, string, long> callback, ProgressCallback progress)
        {
            var jsonText = SceneSerialization.ToJson(recording);
            WriteLocalDataRecording(project, resourceFolder, guid, jsonText);

            var key = GetDataRecordingKey(resourceFolder, guid);

            if (!project.linked)
            {
                callback?.Invoke(true, key, jsonText.Length);
                return default;
            }

            return storageUser.CloudSaveAsync(key, jsonText, (success, responseCode, response) =>
            {
#if MARS_COMPANION_DATA_LOG
                Debug.LogFormat(success ? "Data recording {0} saved" : "Failed to save data recording {0}", guid);
#endif

                callback?.Invoke(success, key, jsonText.Length);
            }, progress);
        }

        internal static RequestHandle DownloadVideo(this IUsesCloudStorage storageUser, string recordingKey, Action<bool, string> callback)
        {
            const int timeout = 0; // Videos may be quite large and take a long time to download
            SplitDataRecordingKey(recordingKey, out var resourceFolder, out var recordingGuid);
            var videoKey = GetRecordingComponentKey(VideoType, resourceFolder, recordingGuid);
            return storageUser.CloudLoadAsync(videoKey, (bool success, long responseCode, byte[] response) =>
            {
                var tempPath = GetTempVideoPath();
                if (success)
                    CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(tempPath, response, callback));
                else
                    callback?.Invoke(false, tempPath);
            }, timeout: timeout);
        }

        internal static void SaveDataRecordingAndUpdateResourceList(this IUsesCloudStorage storageUser,
            CompanionProject project, string resourceFolder, string recordingName, string guid,
            CompanionDataRecording recording, long videoFileSize, Stack<RequestHandle> requests, byte[] thumbnail = null,
            Action<bool, bool, string, ResourceList> callback = null, ProgressCallback progress = null)
        {
            requests.Push(SaveDataRecording(storageUser, project, resourceFolder, guid, recording,
                (recordingSuccess, key, recordingFileSize) =>
                {
                    var totalFileSize = recordingFileSize + videoFileSize;
                    if (thumbnail != null)
                    {
                        CompanionResourceUtils.SaveThumbnailImage(storageUser, project, resourceFolder, key, thumbnail, recordingSuccess,
                            requests, (thumbnailSuccess, thumbnailKey) =>
                            {
                                storageUser.AddOrUpdateResource(project, resourceFolder, key, recordingName,
                                    ResourceType.Recording, totalFileSize, false, thumbnailSuccess, requests,
                                    (writeListSuccess, resourceList) =>
                                    {
                                        callback?.Invoke(true, writeListSuccess, key, resourceList);
                                    });
                            });
                    }
                    else
                    {
                        storageUser.AddOrUpdateResource(project, resourceFolder, key, recordingName,
                            ResourceType.Recording, totalFileSize, false, recordingSuccess, requests,
                            (writeListSuccess, resourceList) =>
                            {
                                callback?.Invoke(true, writeListSuccess, key, resourceList);
                            });
                    }
                }, progress));
        }

        internal static RequestHandle SaveCameraPath(this IUsesCloudStorage storageUser, CompanionProject project, string resourceFolder,
            string recordingGuid, List<PoseEvent> recording)
        {
            const int timeout = 0; // Camera paths may be quite large and take a long time to upload
            var cameraPathRecording = new CameraPathRecording { events = recording };
            return storageUser.SaveBinaryData(project, resourceFolder, recordingGuid, CameraPathType, cameraPathRecording, timeout);
        }

        internal static RequestHandle DownloadCameraPath(this IUsesCloudStorage storageUser, string recordingKey, Action<bool, List<PoseEvent>> callback)
        {
            const int timeout = 0; // Camera paths may be quite large and take a long time to download
            SplitDataRecordingKey(recordingKey, out var resourceFolder, out var recordingGuid);
            var cameraPathKey = GetRecordingComponentKey(CameraPathType, resourceFolder, recordingGuid);
            return storageUser.CloudLoadAsync(cameraPathKey, (bool success, long status, byte[] data) =>
            {
                if (!success || data == null || data.Length == 0)
                {
                    callback?.Invoke(false, null);
                    return;
                }

                unsafe
                {
                    fixed (byte* readerPtr = data)
                    {
                        var reader = new UnsafeAppendBuffer.Reader(readerPtr, data.Length);
                        var recording = BinarySerialization.FromBinary<CameraPathRecording>(&reader);
                        callback?.Invoke(true, recording.events);
                    }
                }
            }, timeout: timeout);
        }

        internal static RequestHandle DownloadPlaneData(this IUsesCloudStorage storageUser, string recordingKey, Action<bool, List<PlaneEvent>> callback)
        {
            const int timeout = 0; // Plane data may be quite large and take a long time to download
            SplitDataRecordingKey(recordingKey, out var resourceFolder, out var recordingGuid);
            var planeDataKey = GetRecordingComponentKey(PlaneDataType, resourceFolder, recordingGuid);
            return storageUser.CloudLoadAsync(planeDataKey, (bool success, long status, byte[] data) =>
            {
                if (!success || data == null || data.Length == 0)
                {
                    callback?.Invoke(false, null);
                    return;
                }

                unsafe
                {
                    fixed (byte* readerPtr = data)
                    {
                        var reader = new UnsafeAppendBuffer.Reader(readerPtr, data.Length);
                        var recording = BinarySerialization.FromBinary<PlaneDataRecording>(&reader);
                        callback?.Invoke(true, recording.events);
                    }
                }
            }, timeout: timeout);
        }

        internal static RequestHandle DownloadPointCloud(this IUsesCloudStorage storageUser, string recordingKey, Action<bool, List<PointCloudEvent>> callback)
        {
            const int timeout = 0; // Point cloud data may be quite large and take a long time to download
            SplitDataRecordingKey(recordingKey, out var resourceFolder, out var recordingGuid);
            var pointCloudKey = GetRecordingComponentKey(PointCloudType, resourceFolder, recordingGuid);
            return storageUser.CloudLoadAsync(pointCloudKey, (bool success, long status, byte[] data) =>
            {
                if (!success || data == null || data.Length == 0)
                {
                    callback?.Invoke(false, null);
                    return;
                }

                unsafe
                {
                    fixed (byte* readerPtr = data)
                    {
                        var reader = new UnsafeAppendBuffer.Reader(readerPtr, data.Length);
                        var recording = BinarySerialization.FromBinary<PointCloudRecording>(&reader);
                        callback?.Invoke(true, recording.events);
                    }
                }
            }, timeout: timeout);
        }

        internal static RequestHandle SavePlaneData(this IUsesCloudStorage storageUser, CompanionProject project, string resourceFolder,
            string recordingGuid, List<PlaneEvent> recording)
        {
            const int timeout = 0; // Plane data may be quite large and take a long time to upload
            var planeDataRecording = new PlaneDataRecording { events = recording };
            return storageUser.SaveBinaryData(project, resourceFolder, recordingGuid, PlaneDataType, planeDataRecording, timeout);
        }

        internal static RequestHandle SavePointCloud(this IUsesCloudStorage storageUser, CompanionProject project, string resourceFolder,
            string recordingGuid, List<PointCloudEvent> recording)
        {
            const int timeout = 0; // Point cloud data may be quite large and take a long time to upload
            var pointCloudRecording = new PointCloudRecording { events = recording };
            return storageUser.SaveBinaryData(project, resourceFolder, recordingGuid, PointCloudType, pointCloudRecording, timeout);
        }

        static RequestHandle SaveBinaryData<T>(this IUsesCloudStorage storageUser, CompanionProject project, string resourceFolder,
            string recordingGuid, string type, T value, int timeout)
        {
            unsafe
            {
                byte[] data;
                using (var stream = new UnsafeAppendBuffer(16, 8, Allocator.Temp))
                {
                    BinarySerialization.ToBinary(&stream, value);
                    data = stream.ToBytes();
                }

                WriteLocalBinaryData(project, resourceFolder, recordingGuid, type, data);
                var key = GetRecordingComponentKey(type, resourceFolder, recordingGuid);

                if (!project.linked)
                {
                    return default;
                }

                return storageUser.CloudSaveAsync(key, data, (success, responseCode, response) =>
                {
#if MARS_COMPANION_DATA_LOG
                    Debug.LogFormat(success ? "{0} recording {1} saved" : "Failed to save {0} recording {1}", type,  recordingGuid);
#endif
                }, timeout: timeout);
            }
        }

        internal static string GetTempVideoPath() { return Path.Combine(Application.persistentDataPath, "Temp", string.Format(k_TmpVideoFileFormat, DateTime.Now.Ticks)); }

        static string GetRecordingComponentFolder(string projectFolder, string resourceFolder, string type) { return Path.Combine(projectFolder, resourceFolder, type); }

        static string GetRecordingComponentPath(string folder, string guid) { return Path.Combine(folder, $"{guid}.mp4"); }

        internal static string MoveTempVideoFile(string tempFilePath, string projectFolder, string resourceFolder, string guid)
        {
            if (File.Exists(tempFilePath))
            {
                var folder = GetRecordingComponentFolder(projectFolder, resourceFolder, VideoType);
                var path = GetRecordingComponentPath(folder, guid);

                if (File.Exists(path))
                    File.Delete(path);

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                File.Move(tempFilePath, path);
                return path;
            }

            Debug.LogErrorFormat("Error: Could not find video file at path {0}", tempFilePath);
            return null;
        }

        static string GetLocalDataRecording(CompanionProject project, string key)
        {
            SplitDataRecordingKey(key, out var resourceFolder, out var guid);
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_DataRecordingType);
            var filename = string.Format(k_JsonFileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Get DataRecording from path " + path);
#endif

            if (!File.Exists(path))
            {
                // TODO: error feedback
                Debug.LogWarningFormat("Could not find DataRecording with key {0}", key);
                return null;
            }

            return File.ReadAllText(path);
        }

        static void WriteLocalDataRecording(CompanionProject project, string resourceFolder, string guid, string jsonText)
        {
            // Write to local storage in case cloud isn't reachable
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_DataRecordingType);
            var filename = string.Format(k_JsonFileFormat, guid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Write DataRecording to path " + path);
#endif

             CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(path, jsonText));
        }

        static void WriteLocalBinaryData(CompanionProject project, string resourceFolder, string recordingGuid, string type, byte[] data)
        {
            // Write to local storage in case cloud isn't reachable
            var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, type);
            var filename = string.Format(k_BinaryFileFormat, recordingGuid);
            var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
            Debug.Log("Write Binary data to path " + path);
#endif

            CoroutineUtils.StartCoroutine(CompanionFileUtils.WriteFileAsync(path, data));
        }

        internal static void DeleteLocalDataRecording(CompanionProject project, string key)
        {
            try
            {
                SplitDataRecordingKey(key, out var resourceFolder, out var recordingGuid);
                var folder = CompanionResourceUtils.GetLocalResourceFolderPath(project, resourceFolder, k_DataRecordingType);
                var filename = string.Format(k_JsonFileFormat, recordingGuid);
                var path = Path.Combine(folder, filename);

#if MARS_COMPANION_DATA_LOG
                Debug.Log("Delete scene at path " + path);
#endif

                if (File.Exists(path))
                {
                    var recordingJson = File.ReadAllText(path);
                    if (!string.IsNullOrEmpty(recordingJson))
                    {
                        var projectFolder = project.GetLocalPath();
                        DeleteRecordingComponent(projectFolder, resourceFolder, VideoType, recordingGuid);
                        DeleteRecordingComponent(projectFolder, resourceFolder, CameraPathType, recordingGuid);
                        DeleteRecordingComponent(projectFolder, resourceFolder, PlaneDataType, recordingGuid);
                        DeleteRecordingComponent(projectFolder, resourceFolder, PointCloudType, recordingGuid);
                    }

                    File.Delete(path);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        static void DeleteRecordingComponent(string projectFolder, string resourceFolder, string type, string recordingGuid)
        {
            var folder = GetRecordingComponentFolder(projectFolder, resourceFolder, type);
            var path = GetRecordingComponentPath(folder, recordingGuid);
            if (File.Exists(path))
                File.Delete(path);
        }

        internal static void UploadDataRecording(this IUsesCloudStorage storageUser, CompanionProject project,
            CompanionResource resource, Stack<RequestHandle> requests, Action<bool> callback = null)
        {
            try
            {
                if (!project.linked)
                {
                    Debug.LogError("Cannot upload data recording in unlinked project");
                    callback?.Invoke(false);
                    return;
                }

                var key = resource.key;
                SplitDataRecordingKey(key, out var resourceFolder, out var guid);
                var jsonText = GetLocalDataRecording(project, key);
                if (string.IsNullOrEmpty(jsonText))
                {
                    callback?.Invoke(false);
                    return;
                }

                var projectFolder = project.GetLocalPath();
                requests.Push(storageUser.UploadRecordingComponent(guid, projectFolder, resourceFolder, VideoType));
                requests.Push(storageUser.UploadRecordingComponent(guid, projectFolder, resourceFolder, CameraPathType));
                requests.Push(storageUser.UploadRecordingComponent(guid, projectFolder, resourceFolder, PlaneDataType));
                requests.Push(storageUser.UploadRecordingComponent(guid, projectFolder, resourceFolder, PointCloudType));
                requests.Push(storageUser.CloudSaveAsync(key, jsonText, (success, responseCode, response) => callback?.Invoke(success)));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        internal static RequestHandle UploadRecordingComponent(this IUsesCloudStorage storageUser, string recordingGuid, string projectFolder,
            string resourceFolder, string type, Action<bool> callback = null, ProgressCallback progress = null)
        {
            const int timeout = 0; // Recording components may be quite large and take a long time to download
            var path = GetRecordingComponentPath(GetRecordingComponentFolder(projectFolder, resourceFolder, type), recordingGuid);
            var key = GetRecordingComponentKey(type, resourceFolder, recordingGuid);
            if (!File.Exists(path))
            {
                Debug.LogError("Component file not found at path " + path);
                return default;
            }

            var componentFile = File.ReadAllBytes(path);
            return storageUser.CloudSaveAsync(key, componentFile, (success, responseCode, response) =>
            {
#if MARS_COMPANION_DATA_LOG
                Debug.LogFormat(success ? "Component {0} saved" : "Failed to save component {0}", key);
#endif
                callback?.Invoke(success);
            }, progress, timeout);
        }
    }
}

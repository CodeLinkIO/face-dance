using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.MARS.Companion.CloudStorage;
using Unity.MARS.Companion.Mobile;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.RuntimeSceneSerialization;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS.Authoring;
using UnityEditor.MARS.Data.Recorded;
using UnityEditor.MARS.Simulation;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Video;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Companion.Core
{
    static class CompanionImportUtils
    {
        const string k_SaveEnvironmentDialogTitle = "Save Environment";
        const string k_SaveRecordingDialogTitle = "Save Recording";
        const string k_SaveVideoDialogTitle = "Save Video";
        const string k_SaveImageDialogTitle = "Save Image";
        const string k_SaveMeshDialogTitle = "Save Mesh";
        const string k_RecordingExtension = "playable";
        const string k_ImageExtension = "png";
        const string k_PrefabExtension = "prefab";
        const string k_VideoExtension = "mp4";
        const string k_ProxyNameFormat = "{0} Proxy";
        const string k_DefaultVideoTrackName = "Video";

        const string k_SaveProxyTitle = "Save Marker Proxy Prefab";
        const string k_SaveProxyMessage = "Choose a location for the marker proxy prefab";

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<DataRecording> k_DataRecordings = new List<DataRecording>();
        static readonly List<UnityObject> k_NewAssets = new List<UnityObject>();

        static readonly string[] k_SessionRecordingLabels = { "SessionRecording" };

        static readonly CameraPoseRecorder k_CameraPoseRecorder = new CameraPoseRecorder();
        static readonly PlaneFindingRecorder k_PlaneFindingRecorder = new PlaneFindingRecorder();
        static readonly PointCloudRecorder k_PointCloudRecorder = new PointCloudRecorder();

        internal static void ImportResource(this IUsesCloudStorage storageUser, CompanionProject project,
            CompanionResource resource, string platform, ResourceList resourceList, GameObject simulatedPlanePrefab,
            Material simulatedPlaneMaterial, Post postPrefab, MeshFilter meshPrefab, GameObject simulatedLightingPrefab,
            Stack<RequestHandle> requests, Action<UnityObject> callback)
        {
            string path;
            string cloudGuid;
            var resourceKey = resource.key;
            switch (resource.type)
            {
                case ResourceType.Scene:
                    if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                        return;

                    void ImportSceneCallback(bool bundleSuccess, AssetPack assetPack)
                    {
                        storageUser.GetScene(project, resource, (success, jsonText) =>
                        {
                            if (success)
                            {
                                CompanionSceneUtils.SplitSceneKey(resourceKey, out _, out cloudGuid);
                                var sceneGuid = CompanionResourceSync.instance.GetAssetGuid(cloudGuid);
                                var scenePath = AssetDatabase.GUIDToAssetPath(sceneGuid);

                                // GUIDToAssetPath will return a path if the asset was recently deleted
                                if (AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath) == null)
                                    scenePath = null;

                                if (!string.IsNullOrEmpty(sceneGuid) && string.IsNullOrEmpty(scenePath))
                                    Debug.LogWarningFormat("Could not find scene with guid {0}. Falling back to new scene", sceneGuid);

                                var sceneName = CompanionSceneUtils.GetSceneName(resource.name);
                                ImportScene(sceneName, jsonText, assetPack, scenePath);

                                // Store cloud ID in temp scene object if original scene not found
                                if (string.IsNullOrEmpty(scenePath))
                                {
                                    var cloudIdObject = new GameObject("__Temp");
                                    cloudIdObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSaveInBuild;
                                    var cloudIdSaver = cloudIdObject.AddComponent<CloudGuidSaver>();
                                    cloudIdSaver.CloudGuid = cloudGuid;
                                }
                            }
                        });
                    }

                    if (resourceList.TryGetAssetBundleKey(resource.key, platform, out var assetBundleKey))
                        requests.Push(storageUser.GetAssetPack(project, assetBundleKey, ImportSceneCallback));
                    else
                        ImportSceneCallback(true, null);

                    return;
                case ResourceType.Environment:
                    requests.Push(storageUser.CloudLoadAsync(resourceKey, (success, responseCode, response) =>
                    {
                        if (success)
                        {
                            var environmentName = resource.name;
                            path = EditorUtility.SaveFilePanelInProject(k_SaveEnvironmentDialogTitle, environmentName,
                                k_PrefabExtension, string.Empty);

                            if (string.IsNullOrEmpty(path))
                                return;

                            ImportEnvironment(environmentName, response, path, simulatedPlanePrefab,
                                simulatedPlaneMaterial, postPrefab, meshPrefab, simulatedLightingPrefab, callback);

                            var resourceSync = CompanionResourceSync.instance;
                            CompanionEnvironmentUtils.SplitEnvironmentKey(resourceKey, out _, out cloudGuid);
                            resourceSync.SetAssetGuid(AssetDatabase.AssetPathToGUID(path), cloudGuid);
                        }
                    }));

                    return;
                case ResourceType.Recording:
                    path = EditorUtility.SaveFilePanelInProject(k_SaveRecordingDialogTitle, resource.name,
                        k_RecordingExtension, string.Empty);

                    if (string.IsNullOrEmpty(path))
                        return;

                    requests.Push(storageUser.CloudLoadAsync(resourceKey, (success, responseCode, response) =>
                    {
                        if (success)
                            CoroutineUtils.StartCoroutine(storageUser.ImportDataRecording(path,
                                resourceKey, resource.name, response, requests,  callback));
                    }));

                    return;
                case ResourceType.Marker:
                    path = EditorUtility.SaveFilePanelInProject(k_SaveImageDialogTitle, resource.name,
                        k_ImageExtension, string.Empty);

                    if (string.IsNullOrEmpty(path))
                        return;

                    var markerKey = resourceKey;
                    requests.Push(storageUser.CloudLoadAsync(markerKey, (success, responseCode, response) =>
                    {
                        if (success)
                        {
                            requests.Push(storageUser.ImportMarker(path, markerKey, response, callback));
                        }
                    }));

                    return;
                case ResourceType.Prefab:
                    requests.Push(storageUser.GetPrefabAsset(project, resourceKey, platform,
                        (bundleSuccess, prefab) =>
                        {
                            UnityObject.Instantiate(prefab);
                        }));
                    return;
            }
        }

        static void ImportEnvironment(string environmentName, string jsonText, string path,
            GameObject simulatedPlanePrefab, Material simulatedPlaneMaterial, Post postPrefab, MeshFilter meshPrefab,
            GameObject simulatedLightingPrefab, Action<UnityObject> callback)
        {
            var environment = SceneSerialization.FromJson<Environment>(jsonText);
            var height = environment.height;
            var vertices = environment.vertices;
            var center = Vector3.zero;
            var posts = CollectionPool<List<Post>, Post>.GetCollection();
            var count = vertices.Count;
            Post previous = null;
            foreach (var vertex in vertices)
            {
                var post = UnityObject.Instantiate(postPrefab);
                posts.Add(post);
                center += vertex;
                var postTransform = post.transform;
                postTransform.position = vertex;
                post.SetTopSphereHeight(height);

                if (previous != null)
                {
                    previous.Setup();
                    var previousPosition = previous.transform.position;
                    previous.UpdateWall(vertex, previousPosition - vertex, height);
                }

                previous = post;
            }

            if (count != 0)
                center /= count;

            var prefabRoot = new GameObject(environmentName).transform;
            var floorPlan = new GameObject("Floor Plan").transform;
            prefabRoot.position = center;
            floorPlan.SetParent(prefabRoot, false);
            foreach (var post in posts)
            {
                post.transform.SetParent(floorPlan, true);
                var wall = post.Wall;
                if (wall != null)
                    wall.SetParent(floorPlan, true);
            }

            var planesRoot = new GameObject("Planes").transform;
            planesRoot.SetParent(prefabRoot, false);
            foreach (var plane in environment.planes)
            {
                var synthesizedPlane = ((GameObject)PrefabUtility.InstantiatePrefab(simulatedPlanePrefab, planesRoot)).GetComponent<SynthesizedPlane>();
                synthesizedPlane.transform.SetWorldPose(plane.pose);
                synthesizedPlane.SetMRPlaneData(plane.vertices, plane.center, plane.extents);
                synthesizedPlane.transform.SetParent(planesRoot, true);
                var renderer = synthesizedPlane.GetComponentInChildren<Renderer>();
                renderer.AddMaterial(simulatedPlaneMaterial);
            }

            var meshCapture = environment.MeshCapture;
            if (meshCapture.Meshes.Count > 0)
            {
                var meshesRoot = new GameObject("Meshes").transform;
                meshesRoot.SetParent(prefabRoot, false);
                var meshPath = EditorUtility.SaveFilePanelInProject(k_SaveMeshDialogTitle, environmentName, "asset", string.Empty);
                var index = 0;
                foreach (var segment in meshCapture.Meshes)
                {
                    var meshFilter = UnityObject.Instantiate(meshPrefab, meshesRoot);
                    var mesh = new Mesh { name = $"Mesh Segment {index}" };
                    mesh.SetVertices(segment.Vertices);
                    mesh.SetIndices(segment.Indices, MeshTopology.Triangles, 0);
                    mesh.SetNormals(segment.Normals);
                    meshFilter.transform.SetWorldPose(segment.Pose);
                    meshFilter.sharedMesh = mesh;
                    if (index == 0)
                    {
                        AssetDatabase.CreateAsset(mesh, meshPath);
                        AssetDatabase.SetMainObject(mesh, meshPath);
                    }
                    else
                        AssetDatabase.AddObjectToAsset(mesh, meshPath);

                    index++;
                }

                AssetDatabase.SaveAssets();
            }

            var environmentBounds = BoundsUtils.GetBounds(prefabRoot);
            var prefabRootGameObject = prefabRoot.gameObject;
            var environmentSettings = prefabRootGameObject.AddComponent<MARSEnvironmentSettings>();
            var environmentInfo = environmentSettings.EnvironmentInfo;
            environmentInfo.EnvironmentBounds = environmentBounds;
            center = environmentBounds.center;
            var extents = environmentBounds.extents * 0.9f; // Reduce offset to avoid sim starting pose warning
            environmentInfo.DefaultCameraPivot = center;
            var cameraPose = new Pose(center + extents, Quaternion.LookRotation(-extents));
            environmentInfo.DefaultCameraWorldPose = cameraPose;
            environmentInfo.DefaultCameraSize = environmentBounds.size.magnitude;
            environmentSettings.SetSimulationStartingPose(cameraPose, false);
            environmentSettings.UpdatePrefabInfo();
            UnityObject.Instantiate(simulatedLightingPrefab, prefabRoot);

            var prefab = PrefabUtility.SaveAsPrefabAssetAndConnect(prefabRootGameObject, path, InteractionMode.AutomatedAction);
            UnityObject.DestroyImmediate(prefabRootGameObject);
            AssetDatabase.SetLabels(prefab, new[] { MARSEnvironmentManager.EnvironmentLabel });
            ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>().UpdateSimulatedEnvironmentCandidates();
            callback(prefab);

            CollectionPool<List<Post>, Post>.RecycleCollection(posts);
        }

        static void ImportScene(string sceneName, string jsonText, AssetPack assetPack, string path = null)
        {
            var sceneModule = MARSSceneModule.instance;
            var wasBlockingEnsureSession = sceneModule.BlockEnsureSession;
            sceneModule.BlockEnsureSession = true;
            if (string.IsNullOrEmpty(path))
            {
                var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
                scene.name = sceneName;
            }
            else
            {
                var scene = EditorSceneManager.OpenScene(path);
                foreach (var gameObject in scene.GetRootGameObjects().ToList())
                {
                    UnityObject.DestroyImmediate(gameObject);
                }
            }

            // TODO: preload prefabs
            CompanionSceneUtils.ImportScene(jsonText, assetPack);

            sceneModule.BlockEnsureSession = wasBlockingEnsureSession;
        }

        static void ApplyImageMarkerTextureImportSettings(string imagePath)
        {
            var importer = AssetImporter.GetAtPath(imagePath);
            if (!(importer is TextureImporter textureImporter))
                return;

            textureImporter.npotScale = TextureImporterNPOTScale.None;
            textureImporter.mipmapEnabled = false;
            textureImporter.SaveAndReimport();
        }

        static GameObject CreateMarkerProxy(Marker marker, Guid guid)
        {
            var proxyObject = MarsObjectCreation.CreateImageMarkerPreset();
            var proxyTrans = proxyObject.transform;
            proxyObject.name = GameObjectUtility.GetUniqueNameForSibling(proxyTrans.parent, string.Format(k_ProxyNameFormat, marker.name));

            var markerCondition = proxyObject.GetComponent<MarkerCondition>();
            markerCondition.MarkerGuid = guid.ToString();

            foreach (var hotSpot in marker.hotspots)
            {
                var hotSpotObject = new GameObject(hotSpot.name);
                var hotSpotTrans = hotSpotObject.transform;
                hotSpotTrans.SetParent(proxyTrans);

                // In the future we need to get the image size from the marker library
                const float assumedImageSize = 0.1f;
                // HotSpot coordinates range from -0.5 to 0.5, as a portion of the size of the image
                hotSpotTrans.localPosition = new Vector3(hotSpot.x * assumedImageSize, 0, hotSpot.y * assumedImageSize);
            }

            return proxyObject;
        }

        static RequestHandle ImportMarker(this IUsesCloudStorage storageUser, string imagePath, string markerKey,
            string jsonText, Action<UnityObject> callback)
        {
            return storageUser.DownloadMarkerImage(markerKey, (success, tempPath) =>
            {
                var destinationPath = Path.Combine(Directory.GetCurrentDirectory(), imagePath);
                try
                {
                    AssetDatabase.StartAssetEditing();

                    if (File.Exists(tempPath))
                    {
                        if (File.Exists(destinationPath))
                            File.Delete(destinationPath);

                        File.Move(tempPath, destinationPath);
                    }
                    else
                    {
                        Debug.LogError($"Couldn't find image file at path {tempPath}");
                    }
                }
                catch (IOException e)
                {
                    Debug.LogException(e);
                }
                finally
                {
                    AssetDatabase.StopAssetEditing();
                }

                // we need access to the created texture for the image before we can add it to a marker library
                AssetDatabase.Refresh();

                ApplyImageMarkerTextureImportSettings(imagePath);

                var marker = SceneSerialization.FromJson<Marker>(jsonText);

                // add the created marker to a marker library
                var markerTex = AssetDatabase.LoadAssetAtPath<Texture2D>(imagePath);
                var markerLibrary = SelectMarkerLibrary();
                var markerGuid = Guid.Empty;
                if (markerTex != null && markerLibrary != null)
                    markerGuid = CompanionEditorAssetUtils.CreateMarkerInLibrary(markerLibrary, marker, markerTex);

                // create a Proxy in the scene with a MarkerCondition looking for the marker's new guid
                var markerProxyObj = CreateMarkerProxy(marker, markerGuid);
                EditorGUIUtility.PingObject(markerProxyObj);


                var prefabSavePath = EditorUtility.SaveFilePanelInProject(k_SaveProxyTitle,
                    string.Format(k_ProxyNameFormat, marker.name), k_PrefabExtension, k_SaveProxyMessage);

                // if user presses 'cancel' in the save prompt, no prefab will be saved
                if (!string.IsNullOrEmpty(prefabSavePath))
                {
                    // creation of prefab is outside the start/stop editing block so we can highlight the created asset
                    var createdPrefab = PrefabUtility.SaveAsPrefabAssetAndConnect(markerProxyObj, prefabSavePath, InteractionMode.AutomatedAction);
                    ProjectWindowUtil.ShowCreatedAsset(createdPrefab);
                    callback(createdPrefab);
                }

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                var resourceSync = CompanionResourceSync.instance;
                CompanionMarkerUtils.SplitMarkerKey(markerKey, out _, out var cloudGuid);
                resourceSync.SetAssetGuid(AssetDatabase.AssetPathToGUID(prefabSavePath), cloudGuid);
            });
        }

        internal static (MarsMarkerLibrary[], string[]) RefreshMarkerLibraryList()
        {
            var updatedMarkerLibraries = CompanionEditorAssetUtils.LoadAllMarkerLibraryAssets();
            var updatedLibraryNames = updatedMarkerLibraries.Length == 0
                ? new[] { string.Empty, "Add Marker Library" }
                : updatedMarkerLibraries.Select(lib => lib.name).ToArray();

            return (updatedMarkerLibraries, updatedLibraryNames);
        }

        static MarsMarkerLibrary SelectMarkerLibrary()
        {
            var companionResourceSync = CompanionResourceSync.instance;
            var library = companionResourceSync.DefaultMarkerLibrary;
            if (library == null)
            {
                var libraries = CompanionEditorAssetUtils.LoadAllMarkerLibraryAssets();
                if (libraries == null || libraries.Length == 0)
                {
                    library = CompanionEditorAssetUtils.CreateAndSaveNewLibrary();
                    RefreshMarkerLibraryList();
                    companionResourceSync.DefaultMarkerLibrary = library;
                }
                else if (libraries.Length > 0)
                {
                    var session = MARSSession.Instance;
                    if (session != null && session.MarkerLibrary != null)
                        library = session.MarkerLibrary;

                    if(library == null)
                        library = libraries[0];
                }
            }

            return library;
        }

        static IEnumerator ImportDataRecording(this IUsesCloudStorage storageUser, string recordingPath,
            string recordingKey, string recordingName, string jsonText, Stack<RequestHandle> requests,
            Action<UnityObject> callback)
        {
            k_DataRecordings.Clear();
            k_NewAssets.Clear();

            var recording = SceneSerialization.FromJson<CompanionDataRecording>(jsonText);

            var recordingInfo = SessionRecordingUtils.CreateSessionRecordingAsset(recordingPath);
            var timeline = recordingInfo.Timeline;
            recordingInfo.name = recordingName + " Info";
            recordingInfo.CloudResourceId = recordingKey;

            var resourceCount = 0;

            if (recording.HasCameraPath)
            {
                resourceCount++;
                requests.Push(storageUser.DownloadCameraPath(recordingKey, (success, list) =>
                {
                    if (success && list != null && list.Count > 0)
                    {
                        k_CameraPoseRecorder.PoseEvents = list;
                        var dataRecording = k_CameraPoseRecorder.TryCreateDataRecording(timeline, k_NewAssets);
                        if (dataRecording != null)
                            k_DataRecordings.Add(dataRecording);
                    }

                    // ReSharper disable once AccessToModifiedClosure
                    resourceCount--;
                }));
            }

            if (recording.HasPlaneData)
            {
                resourceCount++;
                requests.Push(storageUser.DownloadPlaneData(recordingKey, (success, list) =>
                {
                    if (success && list != null && list.Count > 0)
                    {
                        k_PlaneFindingRecorder.PlaneEvents = list;
                        var dataRecording = k_PlaneFindingRecorder.TryCreateDataRecording(timeline, k_NewAssets);
                        if (dataRecording != null)
                            k_DataRecordings.Add(dataRecording);
                    }

                    resourceCount--;
                }));
            }

            if (recording.HasPointCloud)
            {
                resourceCount++;
                requests.Push(storageUser.DownloadPointCloud(recordingKey, (success, list) =>
                {
                    if (success && list != null && list.Count > 0)
                    {
                        k_PointCloudRecorder.PointCloudEvents = list;
                        var dataRecording = k_PointCloudRecorder.TryCreateDataRecording(timeline, k_NewAssets);
                        if (dataRecording != null)
                            k_DataRecordings.Add(dataRecording);
                    }

                    resourceCount--;
                }));
            }

            while (resourceCount > 0)
            {
                yield return null;
            }

            foreach (var dataRecording in k_DataRecordings)
            {
                recordingInfo.AddDataRecording(dataRecording);
                dataRecording.name = dataRecording.GetType().Name;
                AssetDatabase.AddObjectToAsset(dataRecording, timeline);
            }

            foreach (var newAsset in k_NewAssets)
            {
                AssetDatabase.AddObjectToAsset(newAsset, timeline);
            }

            AssetDatabase.SaveAssets();
            ProjectWindowUtil.ShowCreatedAsset(timeline);

            k_DataRecordings.Clear();
            k_NewAssets.Clear();

            if (!recording.HasVideo)
            {
                FinalizeDataRecordingImport(timeline, recordingKey, recordingPath, callback);
                yield break;
            }

            var videoPath = EditorUtility.SaveFilePanelInProject(k_SaveVideoDialogTitle, recordingName, k_VideoExtension, string.Empty);
            if (string.IsNullOrEmpty(recordingPath))
            {
                FinalizeDataRecordingImport(timeline, recordingKey, recordingPath, callback);
                yield break;
            }

            // TODO: Progress bar
            requests.Push(storageUser.DownloadVideo(recordingKey, (success, path) =>
            {
                try
                {
                    AssetDatabase.StartAssetEditing();

                    if (File.Exists(path))
                    {
                        var destinationPath = Path.Combine(Directory.GetCurrentDirectory(), videoPath);
                        if (File.Exists(destinationPath))
                            File.Delete(destinationPath);

                        File.Move(path, destinationPath);
                    }
                    else
                    {
                        Debug.LogError($"Couldn't find temp video file at path {path}");
                    }
                }
                catch (IOException e)
                {
                    Debug.LogException(e);
                }
                finally
                {
                    AssetDatabase.StopAssetEditing();
                }

                AssetDatabase.Refresh();

                var videoClip = AssetDatabase.LoadAssetAtPath<VideoClip>(videoPath);
                var videoTrack = timeline.CreateTrack<MarsVideoPlayableTrack>(null, k_DefaultVideoTrackName);
                var timelineClip = videoTrack.CreateClip<MarsVideoPlayableAsset>();
                timelineClip.displayName = videoClip.name;
                timelineClip.duration = videoClip.length;
                var videoPlayableAsset = (MarsVideoPlayableAsset)timelineClip.asset;
                videoPlayableAsset.VideoClip = videoClip;
                videoPlayableAsset.FacingDirection = CameraFacingDirection.World;
                timeline.editorSettings.fps = (float)videoClip.frameRate;

                var videoHalfHeight = videoClip.height * 0.5f;
                var halfFOV = recording.fovRadians * 0.5f;
                videoPlayableAsset.FocalLength = videoHalfHeight / Mathf.Tan(halfFOV);

                videoPlayableAsset.ZRotation = recording.zRotation;
            }));

            FinalizeDataRecordingImport(timeline, recordingKey, recordingPath, callback);
        }

        static void FinalizeDataRecordingImport(TimelineAsset timeline, string recordingKey, string recordingPath,
            Action<UnityObject> callback)
        {
            AssetDatabase.SetLabels(timeline, k_SessionRecordingLabels);
            AssetDatabase.SaveAssets();

            var resourceSync = CompanionResourceSync.instance;
            CompanionDataRecordingUtils.SplitDataRecordingKey(recordingKey, out _, out var cloudGuid);
            resourceSync.SetAssetGuid(AssetDatabase.AssetPathToGUID(recordingPath), cloudGuid);

            SimulationRecordingManager.RefreshSessionRecordings();
            callback(timeline);
        }

        internal static bool IsCurrentBuildPlatformSupported()
        {
            var currentTarget = EditorUserBuildSettings.activeBuildTarget;
            return currentTarget == BuildTarget.iOS || currentTarget == BuildTarget.Android ||
                   currentTarget == BuildTarget.Lumin;
        }
    }
}

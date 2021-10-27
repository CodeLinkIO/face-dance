using System;
using System.IO;
using System.Linq;
using Unity.MARS.Actions;
using Unity.MARS.Behaviors;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Query;
using Unity.MARS.Recording;
using Unity.MARS.Simulation;
using Unity.MARS.Simulation.Rendering;
using Unity.MARS.Visualizers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Data.Recorded;
using UnityEditor.MARS.Simulation;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS
{
    static class CreateMenuItems
    {
        internal class CreateEnvironmentPrefab : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                var fileName = Path.GetFileNameWithoutExtension(pathName);
                var go = new GameObject(fileName, typeof(MARSEnvironmentSettings));
                var xRayGo = new GameObject(k_XRayLabel, typeof(XRayRegion));
                xRayGo.transform.parent = go.transform;
                PrefabUtility.SaveAsPrefabAsset(go, pathName);
                var o = AssetDatabase.LoadAssetAtPath<UnityObject>(pathName);
                MarsEnvironmentUtils.EnsureAssetHasEnvironmentLabel(o);
                ProjectWindowUtil.ShowCreatedAsset(o);
                UnityObjectUtils.Destroy(go);
            }
        }

        public const string MenuPrefix = "GameObject/MARS/";
        const string k_VisualizersPrefab = MenuPrefix + "Data Visualizers/";

        const string k_ProxyLabel = "Proxy Object";
        const string k_ReplicatorLabel = "Proxy Replicator";
        const string k_SyntheticLabel = "Synthetic Object";
        const string k_RuleSetLabel = "Proxy Rule Set";
        // Presets
        const string k_HorizontalPlaneLabel = "Horizontal Plane";
        const string k_VerticalPlaneLabel = "Vertical Plane";
        const string k_ImageMarkerLabel = "Image Marker";
        const string k_FaceLabel = "Face Mask";
        const string k_BodyLabel = "Body";
        const string k_ProxyGroupLabel = "Proxy Group";
        const string k_FloorLabel = "Floor";
        const string k_ElevatedSurfaceLabel = "Elevated Surface";

        // Primitives
        const string k_CreateMARSSessionLabel = MenuPrefix + "MARS Session";
        const string k_CreateProxyObjectLabel = MenuPrefix + k_ProxyLabel;
        const string k_CreateReplicatorLabel = MenuPrefix + k_ReplicatorLabel;
        const string k_CreateSyntheticLabel = MenuPrefix + k_SyntheticLabel;
        const string k_CreateRulesetObjectLabel = MenuPrefix + k_RuleSetLabel;
        // Turn into:
        const string k_TurnIntoLabel = MenuPrefix + "Turn Into/";
        const string k_TurnIntoProxy = k_TurnIntoLabel + k_ProxyLabel;
        const string k_TurnIntoProxyPlane = k_TurnIntoLabel + "Proxy Plane";
        const string k_TurnIntoReplicator = k_TurnIntoLabel + k_ReplicatorLabel;
        // Presets
        const string k_PresetsPrefix = MenuPrefix + "Presets/";
        const string k_CreateHorizontalPlaneLabel = k_PresetsPrefix + k_HorizontalPlaneLabel;
        const string k_CreateVerticalPlaneLabel = k_PresetsPrefix + k_VerticalPlaneLabel;
        const string k_CreateImageMarkerLabel = k_PresetsPrefix + k_ImageMarkerLabel;
        const string k_CreateFaceLabel = k_PresetsPrefix + k_FaceLabel;
        const string k_CreateBodyLabel = k_PresetsPrefix + k_BodyLabel;

        const string k_CreateProxyGroupLabel = MenuPrefix + k_ProxyGroupLabel;
        const string k_CreateFloorLabel = k_PresetsPrefix + "Floor";
        const string k_CreateElevatedSurfaceLabel = k_PresetsPrefix + k_ElevatedSurfaceLabel;

        const string k_CreateFaceLandmarkVisualizerLabel = k_VisualizersPrefab + "Face Landmark Visualizer";
        const string k_CreatePlaneVisualizerLabel = k_VisualizersPrefab + "Plane Visualizer";
        const string k_CreatePointCloudVisualizerLabel = k_VisualizersPrefab + "Point Cloud Visualizer";
        const string k_CreateLightVisualizerLabel = k_VisualizersPrefab + "Light Estimation Visualizer";

        // Assets
        const string k_AssetMenuPrefix = "Assets/Create/MARS/";
        const string k_CreateSimulatedEnvironmentPrefab = k_AssetMenuPrefix + "Simulated Environment Prefab";
        const string k_EnvironmentPrefabName = "Simulated Environment";
        const string k_PrefabFileTypeName = "prefab";
        const string k_PrefabIconName = "Prefab Icon";
        const string k_CreateRecordingFromVideoLabel = k_AssetMenuPrefix + "Session Recording from Video Clip";
        const string k_PlayableFileTypeName = "playable";

        const int k_PresetsPriority = 10;
        const int k_PrimitivesPriority = 20;
        const int k_VisualizersPriority = 30;

        static readonly Type[] k_ProxyObjectBaseComponents = { typeof(Proxy), typeof(ShowChildrenOnTrackingAction),
            typeof(SetPoseAction) };
        const string k_XRayLabel = "Clipping Region";

        [MenuItem(k_CreateMARSSessionLabel, false, k_PrimitivesPriority)]
        public static GameObject CreateMARSSessionObject(MenuCommand command)
        {
            MARSSession.EnsureRuntimeState();
            return MARSSession.Instance.gameObject;
        }

        // Primitives
        [MenuItem(k_CreateProxyObjectLabel, false, k_PrimitivesPriority)]
        public static GameObject CreateProxyObject(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.ProxyObjectPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateProxyObjectLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateReplicatorLabel, false, k_PrimitivesPriority)]
        public static GameObject CreateReplicator(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.ReplicatorPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateReplicatorLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateSyntheticLabel, false, k_PrimitivesPriority+1)]
        public static GameObject CreateSyntheticObject(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.SyntheticObjectPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateSyntheticLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateProxyGroupLabel, false, k_PrimitivesPriority)]
        public static GameObject CreateProxyGroup(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.ProxyGroupPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateProxyGroupLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateRulesetObjectLabel, false, k_PrimitivesPriority)]
        public static GameObject CreateRulesetObject(MenuCommand command)
        {
            MARSSession.EnsureRuntimeState();
            EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateRulesetObjectLabel});
            var go = CreateInContext(command, k_RuleSetLabel, new Type[]{ typeof(Rules.ProxyRuleSet) } );
            return RegisterUndoAndSelect(go, "Create Rule Set");
        }

        // Turn Intos
        [MenuItem(k_TurnIntoProxy, false, k_PrimitivesPriority)]
        public static GameObject TurnIntoProxyObject(MenuCommand command)
        {
            MARSSession.EnsureRuntimeState();
            EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_TurnIntoProxy});
            var go = TurnIntoInContext(command, k_ProxyLabel, k_ProxyObjectBaseComponents);
            return RegisterUndoAndSelect(go, "Turned into Proxy");
        }

        [MenuItem(k_TurnIntoProxyPlane, false, k_PrimitivesPriority)]
        public static GameObject TurnIntoProxyPlane(MenuCommand command)
        {
            MARSSession.EnsureRuntimeState();
            EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_TurnIntoProxyPlane});
            var types = k_ProxyObjectBaseComponents.ToList();
            types.Add(typeof(PlaneSizeCondition));
            types.Add(typeof(AlignmentCondition));
            var go = TurnIntoInContext(command, k_ProxyLabel, types.ToArray());
            go.GetComponent<PlaneSizeCondition>().maxBounded = false;
            return RegisterUndoAndSelect(go, "Turned into Proxy Plane");
        }

        [MenuItem(k_TurnIntoReplicator, false, k_PrimitivesPriority)]
        public static GameObject TurnIntoReplicator(MenuCommand command)
        {
            MARSSession.EnsureRuntimeState();
            EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_TurnIntoReplicator});
            var go = TurnIntoInContext(command, k_ReplicatorLabel, typeof(Replicator));
            return RegisterUndoAndSelect(go, "Turned into Replicator");
        }

        // Presets
        [MenuItem(k_CreateHorizontalPlaneLabel, false, k_PresetsPriority)]
        public static GameObject CreateHorizontalPlane(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.HorizontalPlanePreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_HorizontalPlaneLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateVerticalPlaneLabel, false, k_PresetsPriority)]
        public static GameObject CreateVerticalPlane(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.VerticalPlanePreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_VerticalPlaneLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateImageMarkerLabel, false, k_PresetsPriority)]
        public static GameObject CreateImageMarker(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.ImageMarkerPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_ImageMarkerLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateFaceLabel, false, k_PresetsPriority)]
        public static GameObject CreateFaceMask(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.FaceMaskPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_FaceLabel});
            }

            return createdObj;
        }
        
        [MenuItem(k_CreateBodyLabel, false, k_PresetsPriority)]
        public static GameObject CreateBody(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.BodyPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_BodyLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateFloorLabel, false, k_PresetsPriority)]
        public static GameObject CreateFloorObject(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.FloorObjectPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateFloorLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateElevatedSurfaceLabel, false, k_PresetsPriority)]
        public static GameObject CreateElevatedSurfaceObject(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.ElevatedSurfacePreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateElevatedSurfaceLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateSimulatedEnvironmentPrefab)]
        public static void CreateSimulatedEnvironmentPrefab()
        {
            var path = GetPathAtSelected();

            var assetPath = AssetDatabase.GenerateUniqueAssetPath($"{path}{k_EnvironmentPrefabName}.{k_PrefabFileTypeName}");

            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateEnvironmentPrefab>(),
                assetPath, EditorGUIUtility.FindTexture(k_PrefabIconName), "");
        }

        [MenuItem(k_CreateFaceLandmarkVisualizerLabel, false, k_VisualizersPriority)]
        public static GameObject CreateFaceLandmarkVisualizer(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.FaceLandmarkVisualsPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateFaceLandmarkVisualizerLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreatePlaneVisualizerLabel, false, k_VisualizersPriority)]
        public static GameObject CreatePlaneVisualizer(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.PlaneVisualsPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreatePlaneVisualizerLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreatePointCloudVisualizerLabel, false, k_VisualizersPriority)]
        public static GameObject CreatePointCloudVisualizer(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.PointCloudVisualsPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreatePointCloudVisualizerLabel});
            }

            return createdObj;
        }

        [MenuItem(k_CreateLightVisualizerLabel, false, k_VisualizersPriority)]
        public static MARSLightEstimationVisualizer CreateLightEstimationVisualizer(MenuCommand command)
        {
            GameObject createdObj = null;
            var parent = command.context as GameObject;
            var parentTransform = parent != null ? parent.transform : null;

            if (MarsObjectCreationResources.instance.LightEstimationVisualsPreset.CreateGameObject(out createdObj, parentTransform))
            {
                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs { label = k_CreateLightVisualizerLabel});
            }

            return createdObj == null ? null : createdObj.GetComponent<MARSLightEstimationVisualizer>();
        }

        [MenuItem(k_CreateRecordingFromVideoLabel, true)]
        public static bool ValidateCreateSessionRecordingFromVideoClip() { return Selection.activeObject is VideoClip; }

        [MenuItem(k_CreateRecordingFromVideoLabel, false)]
        public static void CreateSessionRecordingFromVideoClip()
        {
            var videoClip = Selection.activeObject as VideoClip;
            var pathAtSelected = GetPathAtSelected();
            var assetPath = AssetDatabase.GenerateUniqueAssetPath($"{pathAtSelected}{videoClip.name}.{k_PlayableFileTypeName}");
            var recordingInfo = SessionRecordingUtils.CreateSessionRecordingAsset(assetPath);
            recordingInfo.DefaultExtrapolationMode = DirectorWrapMode.Loop;
            var timeline = recordingInfo.Timeline;
            var videoTrack = timeline.CreateTrack<MarsVideoPlayableTrack>(null, "Video");
            var timelineClip = videoTrack.CreateClip<MarsVideoPlayableAsset>();
            timelineClip.displayName = videoClip.name;
            var videoPlayableAsset = timelineClip.asset as MarsVideoPlayableAsset;
            timelineClip.duration = videoClip.length;
            videoPlayableAsset.VideoClip = videoClip;
            AssetDatabase.SaveAssets();
            ProjectWindowUtil.ShowCreatedAsset(timeline);
        }

        static GameObject CreateInContext(MenuCommand command, string objectLabel, params Type[] componentTypes)
        {
            GameObject parent = null;
            if (command != null)
                parent = command.context as GameObject;
            return CreateUnderGameobject(parent, objectLabel, componentTypes);
        }

        static GameObject CreateUnderGameobject(GameObject parent, string objectLabel, params Type[] componentTypes)
        {
            var parentTransform = parent ? parent.transform : null;
            objectLabel = GameObjectUtility.GetUniqueNameForSibling(parentTransform, objectLabel);
            var go = new GameObject(objectLabel, componentTypes);
            GameObjectUtility.SetParentAndAlign(go, parent);
            var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
            simObjectsManager?.DirtySimulatableScene();
            return go;
        }

        static GameObject TurnIntoInContext(MenuCommand command, string objectLabel, params Type[] componentTypes)
        {
            GameObject turnThis = null;
            if (command != null)
                turnThis = command.context as GameObject;
            if (!turnThis)
            {
                var activeObject = UnityEditor.Selection.activeObject;
                if (activeObject)
                {
                    turnThis = (activeObject as GameObject);
                    if (!turnThis)
                    {
                        var comp = (activeObject as Component);
                        if (comp)
                        {
                            turnThis = comp.gameObject;
                        }
                    }
                }
            }
            if (!turnThis)
            {
                return CreateInContext(command, objectLabel, componentTypes);
            }
            GameObject parent = null;
            if ((turnThis) && (turnThis.transform.parent))
            {
                parent = turnThis.transform.parent.gameObject;
            }
            var newObject = CreateUnderGameobject(parent, objectLabel, componentTypes);
            newObject.name = objectLabel + " " + turnThis.name;
            newObject.transform.position = turnThis.transform.position;
            newObject.transform.rotation = turnThis.transform.rotation;
            turnThis.transform.parent = newObject.transform;
            return newObject;
        }

        static GameObject RegisterUndoAndSelect(GameObject go, string undoLabel)
        {
            Undo.RegisterCreatedObjectUndo(go, undoLabel);
            Selection.activeGameObject = go;
            return go;
        }

        static string GetPathAtSelected()
        {
            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogWarning("No path found at selection! Returning default.");
                path = $"Assets{Path.AltDirectorySeparatorChar}";
            }
            else
            {
                path = string.IsNullOrEmpty(Path.GetExtension(path))
                    ? $"{path}{Path.AltDirectorySeparatorChar}"
                    : path.Replace(Path.GetFileName(path), "");
            }

            return path;
        }
    }
}

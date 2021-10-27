using System;
using System.Collections.Generic;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Simulation;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS.Data.Synthetic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS
{
    static class PlanesExtractionManager
    {
        const int k_RaycastProgressBatchSize = 1024;
        static readonly Vector3 k_Forward = Vector3.forward;

        const int k_MaxColliders = 1;
        const int k_MaxRayGenerationRetries = 25;
        const float k_CheckSphereRadius = 0.0001f;

        static readonly Collider[] k_Colliders = new Collider[k_MaxColliders];

        static PlaneExtractionVoxelGrid s_UpVoxelGrid;
        static PlaneExtractionVoxelGrid s_DownVoxelGrid;
        static PlaneExtractionVoxelGrid s_ForwardVoxelGrid;
        static PlaneExtractionVoxelGrid s_BackVoxelGrid;
        static PlaneExtractionVoxelGrid s_RightVoxelGrid;
        static PlaneExtractionVoxelGrid s_LeftVoxelGrid;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<MeshFilter> k_MeshFilters = new List<MeshFilter>();
        static readonly List<MeshCollider> k_MeshColliders = new List<MeshCollider>();
        static readonly List<Vector3> k_RayOrigins = new List<Vector3>();
        static readonly List<Vector3> k_UpGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_DownGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_ForwardGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_BackGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_RightGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_LeftGridPoints = new List<Vector3>();
        static readonly List<ExtractedPlaneData> k_ExtractedPlanes = new List<ExtractedPlaneData>();

        internal static void ExtractPlanes(PlaneExtractionSettings settings)
        {
            using (var undoBlock = new UndoBlock("Extract Planes"))
            {
                var prefabRoot = settings.gameObject;
                undoBlock.RecordObject(prefabRoot);
                var voxelGenerationParams = settings.VoxelGenerationParams;
                var planeExtractionParams = settings.PlaneFindingParams;
                var voxelSize = voxelGenerationParams.voxelSize;
                if ((int) (planeExtractionParams.minPointsPerSqMeter * (voxelSize * voxelSize)) <= 0)
                {
                    Debug.LogWarning("Minimum points per voxel is not greater than 0. " +
                                     "Increase either the voxel size or the minimum points per square meter.");
                    return;
                }

                if (!PlaneGenerationModule.TryDestroyPreviousPlanes(prefabRoot, "Extracting Planes", undoBlock))
                    return;

                GenerateVoxelGrids(prefabRoot, voxelGenerationParams, planeExtractionParams);
                FindPlanesInGrids(prefabRoot, undoBlock);
            }
        }

        static void GenerateVoxelGrids(GameObject prefabRoot, PlaneVoxelGenerationParams voxelGenerationParams, VoxelPlaneFindingParams planeFindingParams)
        {
            // Rather than modifying collider properties and risking corrupting the scene, for each object with a mesh
            // we create a game object with a collider that uses that mesh and add that object to a preview scene.
            var tempPreviewScene = EditorSceneManager.NewPreviewScene();
            var tempPhysicsScene = tempPreviewScene.GetPhysicsScene();

            // k_MeshFilters is cleared by GetComponentsInChildren
            prefabRoot.GetComponentsInChildren(k_MeshFilters);
            var meshesRoot = new GameObject("Meshes").transform;
            k_MeshColliders.Clear();
            foreach (var meshFilter in k_MeshFilters)
            {
                // Ignore synth planes
                if (meshFilter.GetComponent<SynthesizedPlane>())
                    continue;

                var meshCopyTrans = new GameObject(string.Format("{0} (Mesh)", meshFilter.gameObject.name)).transform;
                var meshCopyCollider = meshCopyTrans.gameObject.AddComponent<MeshCollider>();
                k_MeshColliders.Add(meshCopyCollider);
                meshCopyCollider.sharedMesh = meshFilter.sharedMesh;
                meshCopyTrans.SetParent(meshesRoot);
                var meshFilterTrans = meshFilter.transform;
                meshCopyTrans.position = meshFilterTrans.position;
                meshCopyTrans.rotation = meshFilterTrans.rotation;
                meshCopyTrans.localScale = meshFilterTrans.lossyScale;
            }

            SceneManager.MoveGameObjectToScene(meshesRoot.gameObject, tempPreviewScene);

            var sceneBounds = BoundsUtils.GetBounds(k_MeshColliders);
            var sceneBoundsMin = sceneBounds.min;
            var sceneBoundsMax = sceneBounds.max;

            // Make mesh colliders convex so that we can use CheckSphere to make sure our
            // raycasts don't originate within meshes.
            foreach (var meshCollider in k_MeshColliders)
            {
                meshCollider.convex = true;
            }

            // Seed the random number generator so that results are deterministic
            Random.InitState(voxelGenerationParams.raycastSeed);

            // Setup all ray origins before raycasting since we need mesh colliders to be convex for this step
            // but concave for the raycasting.
            var raycastCount = voxelGenerationParams.raycastCount;
            k_RayOrigins.Clear();
            k_RayOrigins.Capacity = raycastCount;
            for (var i = 0; i < raycastCount; i++)
            {
                var rayGenerationAttempts = 0;
                Vector3 origin;
                while (true)
                {
                    origin = new Vector3(
                        Random.Range(sceneBoundsMin.x, sceneBoundsMax.x),
                        Random.Range(sceneBoundsMin.y, sceneBoundsMax.y),
                        Random.Range(sceneBoundsMin.z, sceneBoundsMax.z));

                    // If the randomly generated ray origin lies inside a mesh, try again
                    if (tempPhysicsScene.OverlapSphere(origin, k_CheckSphereRadius, k_Colliders,
                        Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide) == 0)
                        break;

                    rayGenerationAttempts++;
                    if (rayGenerationAttempts >= k_MaxRayGenerationRetries)
                        break;
                }

                k_RayOrigins.Add(origin);
            }

            foreach (var meshCollider in k_MeshColliders)
            {
                // Make mesh colliders concave for more useful raycast results
                meshCollider.convex = false;
            }

            k_UpGridPoints.Clear();
            k_DownGridPoints.Clear();
            k_ForwardGridPoints.Clear();
            k_BackGridPoints.Clear();
            k_RightGridPoints.Clear();
            k_LeftGridPoints.Clear();

            var outerPointsThreshold = voxelGenerationParams.outerPointsThreshold;
            var upGridBounds = sceneBounds;
            var upGridMax = upGridBounds.max;
            upGridMax.y -= Mathf.Min(outerPointsThreshold, upGridBounds.size.y);
            upGridBounds.max = upGridMax;

            var downGridBounds = sceneBounds;
            var downGridMin = downGridBounds.min;
            downGridMin.y += Mathf.Min(outerPointsThreshold, downGridBounds.size.y);
            downGridBounds.min = downGridMin;

            var forwardGridBounds = sceneBounds;
            var forwardGridMax = forwardGridBounds.max;
            forwardGridMax.z -= Mathf.Min(outerPointsThreshold, forwardGridBounds.size.z);
            forwardGridBounds.max = forwardGridMax;

            var backGridBounds = sceneBounds;
            var backGridMin = backGridBounds.min;
            backGridMin.z += Mathf.Min(outerPointsThreshold, backGridBounds.size.z);
            backGridBounds.min = backGridMin;

            var rightGridBounds = sceneBounds;
            var rightGridMax = rightGridBounds.max;
            rightGridMax.x -= Mathf.Min(outerPointsThreshold, rightGridBounds.size.x);
            rightGridBounds.max = rightGridMax;

            var leftGridBounds = sceneBounds;
            var leftGridMin = leftGridBounds.min;
            leftGridMin.x += Mathf.Min(outerPointsThreshold, leftGridBounds.size.x);
            leftGridBounds.min = leftGridMin;

            // Start raycasting. We run raycasts synchronously so the user can't switch scenes or make scene changes while they are running.
            var maxHitDistance = voxelGenerationParams.maxHitDistance;
            var normalToleranceAngle = voxelGenerationParams.normalToleranceAngle;
            var rayIndex = 0;
            var up = Vector3.up;
            var down = Vector3.down;
            var back = Vector3.back;
            var right = Vector3.right;
            var left = Vector3.left;
            while (rayIndex < raycastCount)
            {
                if (EditorUtility.DisplayCancelableProgressBar(
                    "Generating Point Cloud",
                    string.Format("{0}/{1} raycasts completed", rayIndex, raycastCount),
                    (float) rayIndex / raycastCount))
                {
                    EditorUtility.ClearProgressBar();
                    GUIUtility.ExitGUI();
                    break;
                }

                for (var i = 0; i < k_RaycastProgressBatchSize && rayIndex < raycastCount; i++, rayIndex++)
                {
                    var origin = k_RayOrigins[rayIndex];
                    var direction = RandomRayDirection();
                    RaycastHit raycastHit;
                    if (!tempPhysicsScene.Raycast(origin, direction, out raycastHit, maxHitDistance))
                        continue;

                    var point = raycastHit.point;
                    var normal = raycastHit.normal;

                    if (Vector3.Angle(normal, up) <= normalToleranceAngle && upGridBounds.Contains(point))
                        k_UpGridPoints.Add(point);

                    if (Vector3.Angle(normal, down) <= normalToleranceAngle && downGridBounds.Contains(point))
                        k_DownGridPoints.Add(point);

                    if (Vector3.Angle(normal, k_Forward) <= normalToleranceAngle && forwardGridBounds.Contains(point))
                        k_ForwardGridPoints.Add(point);

                    if (Vector3.Angle(normal, back) <= normalToleranceAngle && backGridBounds.Contains(point))
                        k_BackGridPoints.Add(point);

                    if (Vector3.Angle(normal, right) <= normalToleranceAngle && rightGridBounds.Contains(point))
                        k_RightGridPoints.Add(point);

                    if (Vector3.Angle(normal, left) <= normalToleranceAngle && leftGridBounds.Contains(point))
                        k_LeftGridPoints.Add(point);
                }
            }

            EditorUtility.ClearProgressBar();
            EditorSceneManager.ClosePreviewScene(tempPreviewScene);

            // Reset the seed so other uses of Random are not deterministic
            Random.InitState((int) DateTime.Now.Ticks);

            // Generate voxel grids from point cloud
            var voxelSize = voxelGenerationParams.voxelSize;
            s_UpVoxelGrid = new PlaneExtractionVoxelGrid(VoxelGridOrientation.Up, upGridBounds, voxelSize, planeFindingParams);
            s_DownVoxelGrid = new PlaneExtractionVoxelGrid(VoxelGridOrientation.Down, downGridBounds, voxelSize, planeFindingParams);
            s_ForwardVoxelGrid = new PlaneExtractionVoxelGrid(VoxelGridOrientation.Forward, forwardGridBounds, voxelSize, planeFindingParams);
            s_BackVoxelGrid = new PlaneExtractionVoxelGrid(VoxelGridOrientation.Back, backGridBounds, voxelSize, planeFindingParams);
            s_RightVoxelGrid = new PlaneExtractionVoxelGrid(VoxelGridOrientation.Right, rightGridBounds, voxelSize, planeFindingParams);
            s_LeftVoxelGrid = new PlaneExtractionVoxelGrid(VoxelGridOrientation.Left, leftGridBounds, voxelSize, planeFindingParams);
            s_UpVoxelGrid.AddPoints(k_UpGridPoints);
            s_DownVoxelGrid.AddPoints(k_DownGridPoints);
            s_ForwardVoxelGrid.AddPoints(k_ForwardGridPoints);
            s_BackVoxelGrid.AddPoints(k_BackGridPoints);
            s_RightVoxelGrid.AddPoints(k_RightGridPoints);
            s_LeftVoxelGrid.AddPoints(k_LeftGridPoints);
        }

        static void FindPlanesInGrids(GameObject prefabRoot, UndoBlock undoBlock)
        {
            k_ExtractedPlanes.Clear();
            s_UpVoxelGrid.ExtractPlanes(k_ExtractedPlanes);
            s_DownVoxelGrid.ExtractPlanes(k_ExtractedPlanes);
            s_ForwardVoxelGrid.ExtractPlanes(k_ExtractedPlanes);
            s_BackVoxelGrid.ExtractPlanes(k_ExtractedPlanes);
            s_RightVoxelGrid.ExtractPlanes(k_ExtractedPlanes);
            s_LeftVoxelGrid.ExtractPlanes(k_ExtractedPlanes);

            var planesRoot = PlaneGenerationModule.CreateGeneratedPlanesRoot(prefabRoot.transform, undoBlock);
            var simPlanePrefab = MarsObjectCreationResources.instance.GeneratedSimulatedPlanePrefab;
            foreach (var plane in k_ExtractedPlanes)
            {
                var synthPlane = UnityObject.Instantiate(simPlanePrefab, planesRoot);
                synthPlane.transform.SetWorldPose(plane.pose);
                synthPlane.SetMRPlaneData(plane.vertices, plane.center, plane.extents);
            }

            planesRoot.gameObject.SetLayerRecursively(SimulationConstants.SimulatedEnvironmentLayerIndex);
        }

        static Vector3 RandomRayDirection()
        {
            return Random.rotationUniform * k_Forward;
        }
    }
}

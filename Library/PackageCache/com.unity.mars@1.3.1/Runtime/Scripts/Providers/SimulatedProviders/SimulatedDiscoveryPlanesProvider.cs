using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Random = UnityEngine.Random;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority, disallowAutoCreation:true)]
    [RequireComponent(typeof(SimulatedDiscoveryPointCloudProvider))]
    [MovedFrom("Unity.MARS")]
    public class SimulatedDiscoveryPlanesProvider : MonoBehaviour, IProvidesPlaneFinding, IProvidesTraits<Pose>,
        IProvidesTraits<Vector2>, IProvidesTraits<int>, IProvidesTraits<bool>, IUsesMARSTrackableData<MRPlane>,
        IUsesFunctionalityInjection, IUsesCameraOffset, IUsesDeviceSimulationSettings
    {
        class DebugVisualsData
        {
            public readonly Color DebugColor;
            public readonly Vector3[] WorldBoundingBox = new Vector3[4];
            public readonly List<Vector3> WorldVertices = new List<Vector3>();

            public DebugVisualsData(Color debugColor) { DebugColor = debugColor; }
        }

        static readonly Color k_DebugExtentsColor = Color.black;
        static readonly Color k_DebugCenterColor = Color.white;

        static readonly TraitDefinition[] k_ProvidedTraits =
        {
            TraitDefinitions.Plane,
            TraitDefinitions.Pose,
            TraitDefinitions.Bounds2D,
            TraitDefinitions.Alignment
        };

#pragma warning disable 649
        [SerializeField]
        SimulatedDiscoverySessionProvider m_SessionProvider;
#pragma warning restore 649

        [SerializeField]
        float m_MinimumRegrowthTime = 0.2f;

        [SerializeField]
        int m_NewPointsEvaluationThreshold = 5;

        [SerializeField]
        // The factor used to randomly drop per-plane updates.
        // If a random number between 0 & 1 is below this number, the update is dropped.
        float m_PointUpdateDropoutRate = 0.667f;

        [SerializeField]
        // the factor used to determine what portion of points per plane we use for updates.
        // this is the increment used when iterating over the points - a skip factor of two means we take half the points.
        int m_PointSkip = 2;

        [SerializeField]
        [Tooltip("Side length of each voxel in the plane voxel grid")]
        float m_VoxelSize = 0.1f;

        [SerializeField]
        [Tooltip("If the angle between a point's normal and a voxel grid direction is within this range, the point is added to the grid")]
        float m_NormalToleranceAngle = 15f;

#pragma warning disable 649
        [SerializeField]
        VoxelPlaneFindingParams m_PlaneFindingParams;
#pragma warning restore 649

        SimulatedDiscoveryPointCloudProvider m_PointCloudProvider;
        float m_LastGrowthTime;
        bool m_PointCloudChanged;
        bool m_Paused;

        PlaneDiscoveryVoxelGrid m_UpVoxelGrid;
        PlaneDiscoveryVoxelGrid m_DownVoxelGrid;
        PlaneDiscoveryVoxelGrid m_ForwardVoxelGrid;
        PlaneDiscoveryVoxelGrid m_BackVoxelGrid;
        PlaneDiscoveryVoxelGrid m_RightVoxelGrid;
        PlaneDiscoveryVoxelGrid m_LeftVoxelGrid;
        bool m_GridsInitialized;
        bool m_PreviousExtentsDebug;
        bool m_PreviousVerticesDebug;
        IProvidesSessionControl m_ProvidesSessionControl;

        readonly Dictionary<MarsTrackableId, MRPlane> m_ProvidedPlanesById = new Dictionary<MarsTrackableId, MRPlane>();
        readonly Dictionary<MarsTrackableId, DebugVisualsData> m_DebugDataById =
            new Dictionary<MarsTrackableId, DebugVisualsData>();

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }
        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }
        IProvidesDeviceSimulationSettings IFunctionalitySubscriber<IProvidesDeviceSimulationSettings>.provider { get; set; }

// Suppresses the warning "The event 'event' is never used", because it is not an issue if the planes provider events are not used
#pragma warning disable 67
        public event Action<MRPlane> planeAdded;
        public event Action<MRPlane> planeUpdated;
        public event Action<MRPlane> planeRemoved;
#pragma warning restore 67

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<Vector3> k_UpGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_DownGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_ForwardGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_BackGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_RightGridPoints = new List<Vector3>();
        static readonly List<Vector3> k_LeftGridPoints = new List<Vector3>();
        static readonly List<MRPlane> k_AddedPlanes = new List<MRPlane>();
        static readonly List<MRPlane> k_UpdatedPlanes = new List<MRPlane>();
        static readonly List<MRPlane> k_RemovedPlanes = new List<MRPlane>();
        static readonly List<Color> k_AddedPlaneDebugColors = new List<Color>();

        public TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPlaneFinding>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        void IProvidesPlaneFinding.GetPlanes(List<MRPlane> planes)
        {
            foreach (var kvp in m_ProvidedPlanesById)
            {
                planes.Add(kvp.Value);
            }
        }

        void IProvidesPlaneFinding.StopDetectingPlanes() { m_Paused = true; }
        void IProvidesPlaneFinding.StartDetectingPlanes() { m_Paused = false; }

        void OnValidate()
        {
            m_PointUpdateDropoutRate = Mathf.Clamp(m_PointUpdateDropoutRate, 0f, 0.95f);
            m_NewPointsEvaluationThreshold = Mathf.Clamp(m_NewPointsEvaluationThreshold, 3, 16);
            m_PointSkip = Mathf.Clamp(m_PointSkip, 1, 5);
        }

        void OnEnable()
        {
            m_LastGrowthTime = MarsTime.Time;
            MarsTime.MarsUpdate += OnMarsUpdate;
            m_PreviousExtentsDebug = MarsDebugSettings.SimDiscoveryModulePlaneExtentsDebug;
            m_PreviousVerticesDebug = MarsDebugSettings.SimDiscoveryModulePlaneVerticesDebug;
            m_PointCloudProvider = GetComponent<SimulatedDiscoveryPointCloudProvider>();
            m_PointCloudProvider.PointCloudUpdated += OnPointCloudUpdated;
            EditorOnlyEvents.onEnvironmentSetup += SetupFromEnvironment;
            if (EditorOnlyDelegates.IsEnvironmentSetup != null && EditorOnlyDelegates.IsEnvironmentSetup())
                SetupFromEnvironment();

            m_ProvidesSessionControl = m_SessionProvider;
        }

        void OnDisable()
        {
            ClearPlanes();
            m_DebugDataById.Clear();

            m_PointCloudProvider.PointCloudUpdated -= OnPointCloudUpdated;
            EditorOnlyEvents.onEnvironmentSetup -= SetupFromEnvironment;
            MarsTime.MarsUpdate -= OnMarsUpdate;
            m_GridsInitialized = false;
            m_PointCloudChanged = false;
            m_Paused = false;
        }

        void SetupFromEnvironment()
        {
            var sceneBounds = this.GetEnvironmentBounds();
            float voxelSize = this.GetVoxelSizeFromEnvironment() ?? m_VoxelSize;
            m_UpVoxelGrid = new PlaneDiscoveryVoxelGrid(VoxelGridOrientation.Up, sceneBounds, voxelSize, m_PlaneFindingParams);
            m_DownVoxelGrid = new PlaneDiscoveryVoxelGrid(VoxelGridOrientation.Down, sceneBounds, voxelSize, m_PlaneFindingParams);
            m_ForwardVoxelGrid = new PlaneDiscoveryVoxelGrid(VoxelGridOrientation.Forward, sceneBounds, voxelSize, m_PlaneFindingParams);
            m_BackVoxelGrid = new PlaneDiscoveryVoxelGrid(VoxelGridOrientation.Back, sceneBounds, voxelSize, m_PlaneFindingParams);
            m_RightVoxelGrid = new PlaneDiscoveryVoxelGrid(VoxelGridOrientation.Right, sceneBounds, voxelSize, m_PlaneFindingParams);
            m_LeftVoxelGrid = new PlaneDiscoveryVoxelGrid(VoxelGridOrientation.Left, sceneBounds, voxelSize, m_PlaneFindingParams);
            this.InjectFunctionalitySingle(m_UpVoxelGrid);
            this.InjectFunctionalitySingle(m_DownVoxelGrid);
            this.InjectFunctionalitySingle(m_ForwardVoxelGrid);
            this.InjectFunctionalitySingle(m_BackVoxelGrid);
            this.InjectFunctionalitySingle(m_RightVoxelGrid);
            this.InjectFunctionalitySingle(m_LeftVoxelGrid);
            m_GridsInitialized = true;
        }

        void OnPointCloudUpdated(Dictionary<MarsTrackableId, PointCloudData> data)
        {
            m_PointCloudChanged = true;
            var up = Vector3.up;
            var down = Vector3.down;
            var forward = Vector3.forward;
            var back = Vector3.back;
            var right = Vector3.right;
            var left = Vector3.left;
            k_UpGridPoints.Clear();
            k_DownGridPoints.Clear();
            k_ForwardGridPoints.Clear();
            k_BackGridPoints.Clear();
            k_RightGridPoints.Clear();
            k_LeftGridPoints.Clear();

            var normalData = m_PointCloudProvider.GetNormals();
            foreach (var kvp in data)
            {
                var pointCloud = kvp.Value;
                var positions = pointCloud.Positions;
                if (!positions.HasValue)
                    continue;

                var positionsValue = positions.Value;
                var pointsCount = positionsValue.Length;
                var normals = normalData[kvp.Key];
                for (var i = 0; i < pointsCount; i++)
                {
                    // don't update a portion of the surfaces we get new points for each update,
                    // the idea being that for a surface to update you need shots from a few perspectives.
                    // this is one of our factors for pretending that acquiring planes is more like on device
                    if (Random.Range(0f, 1f) < m_PointUpdateDropoutRate)
                        continue;

                    var normal = normals[i];
                    var position = positionsValue[i];
                    if (Vector3.Angle(normal, up) <= m_NormalToleranceAngle)
                        k_UpGridPoints.Add(position);

                    if (Vector3.Angle(normal, down) <= m_NormalToleranceAngle)
                        k_DownGridPoints.Add(position);

                    if (Vector3.Angle(normal, forward) <= m_NormalToleranceAngle)
                        k_ForwardGridPoints.Add(position);

                    if (Vector3.Angle(normal, back) <= m_NormalToleranceAngle)
                        k_BackGridPoints.Add(position);

                    if (Vector3.Angle(normal, right) <= m_NormalToleranceAngle)
                        k_RightGridPoints.Add(position);

                    if (Vector3.Angle(normal, left) <= m_NormalToleranceAngle)
                        k_LeftGridPoints.Add(position);
                }
            }

            m_UpVoxelGrid.AddPoints(k_UpGridPoints);
            m_DownVoxelGrid.AddPoints(k_DownGridPoints);
            m_ForwardVoxelGrid.AddPoints(k_ForwardGridPoints);
            m_BackVoxelGrid.AddPoints(k_BackGridPoints);
            m_RightVoxelGrid.AddPoints(k_RightGridPoints);
            m_LeftVoxelGrid.AddPoints(k_LeftGridPoints);
        }

        void OnMarsUpdate()
        {
            // Make sure we have debug data if debugging state changes
            var extentsDebug = MarsDebugSettings.SimDiscoveryModulePlaneExtentsDebug;
            if (extentsDebug && !m_PreviousExtentsDebug)
            {
                foreach (var kvp in m_ProvidedPlanesById)
                {
                    UpdateDebugBounds(m_DebugDataById[kvp.Key], kvp.Value);
                }
            }

            var verticesDebug = MarsDebugSettings.SimDiscoveryModulePlaneVerticesDebug;
            if (verticesDebug && !m_PreviousVerticesDebug)
            {
                foreach (var kvp in m_ProvidedPlanesById)
                {
                    UpdateDebugVertices(m_DebugDataById[kvp.Key], kvp.Value);
                }
            }

            m_PreviousExtentsDebug = extentsDebug;
            m_PreviousVerticesDebug = verticesDebug;

            // TODO subscribe to IProvidesSessionControl
            if (m_Paused || m_SessionProvider && !m_ProvidesSessionControl.SessionRunning())
                return;

            var time = MarsTime.Time;
            if (!m_PointCloudChanged || time - m_LastGrowthTime < m_MinimumRegrowthTime)
                return;

            m_PointCloudChanged = false;
            m_LastGrowthTime = time;

            k_AddedPlanes.Clear();
            k_UpdatedPlanes.Clear();
            k_RemovedPlanes.Clear();
            k_AddedPlaneDebugColors.Clear();
            m_UpVoxelGrid.FindMRPlanes(k_AddedPlanes, k_UpdatedPlanes, k_RemovedPlanes, k_AddedPlaneDebugColors);
            m_DownVoxelGrid.FindMRPlanes(k_AddedPlanes, k_UpdatedPlanes, k_RemovedPlanes, k_AddedPlaneDebugColors);
            m_ForwardVoxelGrid.FindMRPlanes(k_AddedPlanes, k_UpdatedPlanes, k_RemovedPlanes, k_AddedPlaneDebugColors);
            m_BackVoxelGrid.FindMRPlanes(k_AddedPlanes, k_UpdatedPlanes, k_RemovedPlanes, k_AddedPlaneDebugColors);
            m_RightVoxelGrid.FindMRPlanes(k_AddedPlanes, k_UpdatedPlanes, k_RemovedPlanes, k_AddedPlaneDebugColors);
            m_LeftVoxelGrid.FindMRPlanes(k_AddedPlanes, k_UpdatedPlanes, k_RemovedPlanes, k_AddedPlaneDebugColors);

            for (var i = 0; i < k_AddedPlanes.Count; i++)
            {
                var plane = k_AddedPlanes[i];
                AddProvidedPlane(plane);
                m_DebugDataById.Add(plane.id, new DebugVisualsData(k_AddedPlaneDebugColors[i]));
            }

            foreach (var plane in k_UpdatedPlanes)
            {
                UpdatedProvidedPlane(plane);
            }

            foreach (var plane in k_RemovedPlanes)
            {
                RemoveProvidedPlane(plane);
            }

            if (extentsDebug)
            {
                foreach (var plane in k_AddedPlanes)
                {
                    UpdateDebugBounds(m_DebugDataById[plane.id], plane);
                }

                foreach (var plane in k_UpdatedPlanes)
                {
                    UpdateDebugBounds(m_DebugDataById[plane.id], plane);
                }
            }

            if (verticesDebug)
            {
                foreach (var plane in k_AddedPlanes)
                {
                    UpdateDebugVertices(m_DebugDataById[plane.id], plane);
                }

                foreach (var plane in k_UpdatedPlanes)
                {
                    UpdateDebugVertices(m_DebugDataById[plane.id], plane);
                }
            }
        }

        void AddProvidedPlane(MRPlane plane)
        {
            m_ProvidedPlanesById.Add(plane.id, plane);
            var id = this.AddOrUpdateData(plane);
            this.AddOrUpdateTrait(id, TraitNames.Plane, true);
            this.AddOrUpdateTrait(id, TraitNames.Pose, plane.pose);
            this.AddOrUpdateTrait(id, TraitNames.Bounds2D, plane.extents);
            this.AddOrUpdateTrait(id, TraitNames.Alignment, (int)plane.alignment);
            if (planeAdded != null)
                planeAdded(plane);
        }

        void UpdatedProvidedPlane(MRPlane plane)
        {
            m_ProvidedPlanesById[plane.id] = plane;
            var id = this.AddOrUpdateData(plane);
            this.AddOrUpdateTrait(id, TraitNames.Pose, plane.pose);
            this.AddOrUpdateTrait(id, TraitNames.Bounds2D, plane.extents);
            if (planeUpdated != null)
                planeUpdated(plane);
        }

        void RemoveProvidedPlane(MRPlane plane)
        {
            m_ProvidedPlanesById.Remove(plane.id);
            m_DebugDataById.Remove(plane.id);
            RemovePlaneData(plane);
        }

        void RemovePlaneData(MRPlane plane)
        {
            var id = this.RemoveData(plane);
            this.RemoveTrait<bool>(id, TraitNames.Plane);
            this.RemoveTrait<Pose>(id, TraitNames.Pose);
            this.RemoveTrait<Vector2>(id, TraitNames.Bounds2D);
            this.RemoveTrait<int>(id, TraitNames.Alignment);
            if (planeRemoved != null)
                planeRemoved(plane);
        }

        void UpdateDebugBounds(DebugVisualsData debugData, MRPlane plane)
        {
            var planePose = plane.pose;
            var center = plane.center;
            var extents = plane.extents;
            var halfExtentsX = extents.x * 0.5f;
            var halfExtentsY = extents.y * 0.5f;
            var boundsVertices = debugData.WorldBoundingBox;
            boundsVertices[0] = this.PoseToCameraSpace(planePose, center + new Vector3(-halfExtentsX, 0f, halfExtentsY));
            boundsVertices[1] = this.PoseToCameraSpace(planePose, center + new Vector3(-halfExtentsX, 0f, -halfExtentsY));
            boundsVertices[2] = this.PoseToCameraSpace(planePose, center + new Vector3(halfExtentsX, 0f, -halfExtentsY));
            boundsVertices[3] = this.PoseToCameraSpace(planePose, center + new Vector3(halfExtentsX, 0f, halfExtentsY));
        }

        void UpdateDebugVertices(DebugVisualsData debugData, MRPlane plane)
        {
            var planePose = plane.pose;
            var worldVertices = debugData.WorldVertices;
            worldVertices.Clear();
            foreach (var vertex in plane.vertices)
            {
                worldVertices.Add(this.PoseToCameraSpace(planePose, vertex));
            }
        }

        void DrawDebugPolygons()
        {
            var debugPlaneExtents = MarsDebugSettings.SimDiscoveryModulePlaneExtentsDebug;
            var debugPlaneVertices = MarsDebugSettings.SimDiscoveryModulePlaneVerticesDebug;
            if (!(debugPlaneExtents || debugPlaneVertices))
                return;

            if (debugPlaneExtents)
            {
                Gizmos.color = k_DebugExtentsColor;
                foreach (var kvp in m_DebugDataById)
                {
                    var boundsVertices = kvp.Value.WorldBoundingBox;
                    Gizmos.DrawLine(boundsVertices[0], boundsVertices[1]);
                    Gizmos.DrawLine(boundsVertices[1], boundsVertices[2]);
                    Gizmos.DrawLine(boundsVertices[2], boundsVertices[3]);
                    Gizmos.DrawLine(boundsVertices[3], boundsVertices[0]);
                }
            }

            if (debugPlaneVertices)
            {
                foreach (var kvp in m_DebugDataById)
                {
                    var debugData = kvp.Value;
                    var vertices = debugData.WorldVertices;
                    var lastVertex = vertices.Count - 1;
                    if (lastVertex < 0)
                        continue;

                    Gizmos.color = debugData.DebugColor;
                    for (var i = 0; i < lastVertex; ++i)
                    {
                        Gizmos.DrawLine(vertices[i], vertices[i + 1]);
                    }
                    Gizmos.DrawLine(vertices[lastVertex], vertices[0]);
                }
            }
        }

        void OnDrawGizmos()
        {
            if (!m_GridsInitialized)
                return;

            var gizmosColor = Gizmos.color;

            if (MarsDebugSettings.SimDiscoveryVoxelsDebug)
            {
                // Set matrix since Gizmos cubes are axis-aligned
                var gizmosMatrix = Gizmos.matrix;
                Gizmos.matrix = this.GetCameraOffsetMatrix();
                m_UpVoxelGrid.DrawDebugVoxels();
                m_DownVoxelGrid.DrawDebugVoxels();
                m_ForwardVoxelGrid.DrawDebugVoxels();
                m_BackVoxelGrid.DrawDebugVoxels();
                m_RightVoxelGrid.DrawDebugVoxels();
                m_LeftVoxelGrid.DrawDebugVoxels();
                Gizmos.matrix = gizmosMatrix;
            }

            if (MarsDebugSettings.SimDiscoveryModulePlaneCenterDebug)
            {
                Gizmos.color = k_DebugCenterColor;
                foreach (var kvp in m_ProvidedPlanesById)
                {
                    var plane = kvp.Value;
                    var cameraCenter = this.PoseToCameraSpace(plane.pose, plane.center);
                    Gizmos.DrawWireSphere(cameraCenter, 0.075f);
                }
            }

            DrawDebugPolygons();

            Gizmos.color = gizmosColor;
        }

        public void ClearPlanes()
        {
            foreach (var kvp in m_ProvidedPlanesById)
            {
                RemovePlaneData(kvp.Value);
            }

            m_ProvidedPlanesById.Clear();
        }

        internal void ResetPlanes()
        {
            ClearPlanes();
            SetupFromEnvironment();
        }
    }
#else
    public class SimulatedDiscoveryPlanesProvider : MonoBehaviour
    {
        [SerializeField]
        SimulatedDiscoverySessionProvider m_SessionProvider;

        [SerializeField]
        float m_MinimumRegrowthTime;

        [SerializeField]
        int m_NewPointsEvaluationThreshold;

        [SerializeField]
        float m_PointUpdateDropoutRate;

        [SerializeField]
        int m_PointSkip;

        [SerializeField]
        float m_VoxelSize;

        [SerializeField]
        float m_NormalToleranceAngle;

        [SerializeField]
        VoxelPlaneFindingParams m_PlaneFindingParams;
    }
#endif
}

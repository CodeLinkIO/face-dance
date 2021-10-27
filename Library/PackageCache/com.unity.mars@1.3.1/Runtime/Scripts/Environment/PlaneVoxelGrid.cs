using System;
using System.Collections.Generic;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    [MovedFrom("Unity.MARS")]
    public enum VoxelGridOrientation { Up, Down, Forward, Back, Right, Left }

    /// <summary>
    /// A grid of voxels that is used to find planes of a specific orientation.
    /// Planes can be found in each individual layer of the grid based on the density of points in each voxel.
    /// </summary>
    public abstract class PlaneVoxelGrid<TLayerPlane> where TLayerPlane : LayerPlaneData
    {
        /// <summary>
        /// A small local y offset applied to a plane to avoid z-fighting with the mesh it was extracted from
        /// </summary>
        protected const float k_PlaneYEpsilon = 0.001f;

        protected static readonly Vector3 k_Up = Vector3.up;
        static readonly Quaternion k_UpGridRotation = Quaternion.identity;
        static readonly Quaternion k_DownGridRotation = Quaternion.Euler(180f, 0f, 0f);
        static readonly Quaternion k_ForwardGridRotation = Quaternion.Euler(90f, 0f, 0f);
        static readonly Quaternion k_BackGridRotation = Quaternion.Euler(90f, 0f, 180f);
        static readonly Quaternion k_RightGridRotation = Quaternion.Euler(90f, 90f, 0f);
        static readonly Quaternion k_LeftGridRotation = Quaternion.Euler(90f, 0f, 90f);

        readonly string m_DebugFilter;
        protected readonly float m_VoxelSize;
        protected readonly int m_Layers;
        protected readonly List<HashSet<Vector2Int>> m_UpdatedVoxelsPerLayer;
        protected readonly List<List<TLayerPlane>> m_PlanesPerLayer;
        protected readonly List<List<TLayerPlane>> m_ModifiedPlanesPerLayer;
        protected readonly List<List<TLayerPlane>> m_RemovedPlanesPerLayer;

        readonly Dictionary<Vector3Int, PlaneVoxel> m_Voxels;
        readonly float m_VoxelHalfSize;
        readonly float m_VoxelSqSize;
        readonly int m_Columns;
        readonly int m_Rows;
        readonly int m_LayerSize;
        readonly int m_WorldXVoxels;
        readonly int m_WorldYVoxels;
        readonly int m_WorldZVoxels;
        readonly Vector3 m_GridBoundsMin;
        readonly Vector3 m_GridBoundsMax;
        readonly Vector3 m_MinVoxelPosition;
        readonly VoxelGridOrientation m_Orientation;

        readonly int m_MinPointsPerVoxel;
        protected readonly float m_MinSideLength;
        readonly float m_CrossLayerMergeDistance;
        readonly float m_InLayerMergeSqDistance;
        readonly bool m_CheckEmptyArea;
        readonly AnimationCurve m_AllowedEmptyAreaCurve;

        /// <summary>
        /// Pose used to convert layer-local planes to world space.
        /// The position is the center of the voxel at layer 0, column 0, row 0.
        /// The forward axis is column-aligned in the direction of increasing rows.
        /// The right axis is row-aligned in the direction of increasing columns.
        /// </summary>
        readonly Pose m_GridOriginPose;

        protected abstract bool CheckEmptyAreaForInitialPlanes { get; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<Vector2Int> k_Voxels = new List<Vector2Int>();
        static readonly List<Vector2Int> k_NextLayerVoxels = new List<Vector2Int>();
        static readonly List<Vector2Int> k_VoxelNeighbors = new List<Vector2Int>();
        static readonly Queue<Vector2Int> k_VoxelsQueue = new Queue<Vector2Int>();
        static readonly Queue<Vector2Int> k_VoxelsToRevisit = new Queue<Vector2Int>();
        static readonly List<Vector3> k_VoxelCornersInPlane = new List<Vector3>();
        static readonly List<Vector3> k_PotentialPlaneVertices = new List<Vector3>();
        static readonly List<Vector3> k_PotentialPlanePoints = new List<Vector3>();
        static readonly HashSet<Vector2Int> k_PotentialPlaneVoxels = new HashSet<Vector2Int>();
        static readonly HashSet<TLayerPlane> k_RemovedPlanesSet = new HashSet<TLayerPlane>();
        static readonly Vector3[] k_PlaneBoundingBox = new Vector3[4];

        /// <summary>
        /// Constructs an oriented voxel grid of a given size
        /// </summary>
        /// <param name="orientation">Determines how the grid is divided into layers from which planes can be found</param>
        /// <param name="containedBounds">The grid will be just large enough to contain these bounds</param>
        /// <param name="voxelSize">Side length of each voxel</param>
        /// <param name="planeFindingParams">Parameters used to find planes</param>
        protected PlaneVoxelGrid(
            VoxelGridOrientation orientation, Bounds containedBounds, float voxelSize, VoxelPlaneFindingParams planeFindingParams)
        {
            var boundsSize = containedBounds.size;
            m_VoxelSize = voxelSize;
            m_VoxelSqSize = voxelSize * voxelSize;
            m_VoxelHalfSize = voxelSize * 0.5f;
            m_WorldXVoxels = Mathf.CeilToInt(boundsSize.x / voxelSize);
            m_WorldYVoxels = Mathf.CeilToInt(boundsSize.y / voxelSize);
            m_WorldZVoxels = Mathf.CeilToInt(boundsSize.z / voxelSize);
            m_GridBoundsMin = containedBounds.min;
            m_GridBoundsMax = m_GridBoundsMin + new Vector3(m_WorldXVoxels * voxelSize, m_WorldYVoxels * voxelSize, m_WorldZVoxels * voxelSize);
            m_MinVoxelPosition = m_GridBoundsMin + Vector3.one * m_VoxelHalfSize;
            m_Orientation = orientation;
            m_DebugFilter = $"[{orientation} Plane Finding]";
            if (MarsDebugSettings.SimPlaneFindingLogging)
                Debug.Log($"{m_DebugFilter} Create grid");

            m_MinPointsPerVoxel = (int)(planeFindingParams.minPointsPerSqMeter * m_VoxelSqSize);
            m_MinSideLength = planeFindingParams.minSideLength;
            m_CrossLayerMergeDistance = planeFindingParams.crossLayerMergeDistance;
            var mergeDistance = planeFindingParams.inLayerMergeDistance;
            m_InLayerMergeSqDistance = mergeDistance * mergeDistance;
            m_CheckEmptyArea = planeFindingParams.checkEmptyArea;
            m_AllowedEmptyAreaCurve = planeFindingParams.allowedEmptyAreaCurve;

            switch (orientation)
            {
                case VoxelGridOrientation.Up:
                    m_Layers = m_WorldYVoxels;
                    m_Columns = m_WorldXVoxels;
                    m_Rows = m_WorldZVoxels;
                    m_GridOriginPose = new Pose(m_MinVoxelPosition, k_UpGridRotation);
                    break;
                case VoxelGridOrientation.Down:
                    m_Layers = m_WorldYVoxels;
                    m_Columns = m_WorldXVoxels;
                    m_Rows = m_WorldZVoxels;
                    m_GridOriginPose = new Pose(
                        m_MinVoxelPosition + new Vector3(0f, voxelSize * (m_WorldYVoxels - 1), voxelSize * (m_WorldZVoxels - 1)),
                        k_DownGridRotation);
                    break;
                case VoxelGridOrientation.Forward:
                    m_Layers = m_WorldZVoxels;
                    m_Columns = m_WorldXVoxels;
                    m_Rows = m_WorldYVoxels;
                    m_GridOriginPose = new Pose(
                        m_MinVoxelPosition + k_Up * (voxelSize * (m_WorldYVoxels - 1)),
                        k_ForwardGridRotation);
                    break;
                case VoxelGridOrientation.Back:
                    m_Layers = m_WorldZVoxels;
                    m_Columns = m_WorldXVoxels;
                    m_Rows = m_WorldYVoxels;
                    m_GridOriginPose = new Pose(
                        m_GridBoundsMax - Vector3.one * m_VoxelHalfSize,
                        k_BackGridRotation);
                    break;
                case VoxelGridOrientation.Right:
                    m_Layers = m_WorldXVoxels;
                    m_Columns = m_WorldZVoxels;
                    m_Rows = m_WorldYVoxels;
                    m_GridOriginPose = new Pose(
                        m_MinVoxelPosition + new Vector3(0f, voxelSize * (m_WorldYVoxels - 1), voxelSize * (m_WorldZVoxels - 1)),
                        k_RightGridRotation);
                    break;
                case VoxelGridOrientation.Left:
                    m_Layers = m_WorldXVoxels;
                    m_Columns = m_WorldZVoxels;
                    m_Rows = m_WorldYVoxels;
                    m_GridOriginPose = new Pose(
                        m_MinVoxelPosition + new Vector3(voxelSize * (m_WorldXVoxels - 1), voxelSize * (m_WorldYVoxels - 1), 0f),
                        k_LeftGridRotation);
                    break;
            }

            m_LayerSize = m_Columns * m_Rows;
            m_Voxels = new Dictionary<Vector3Int, PlaneVoxel>();

            m_UpdatedVoxelsPerLayer = new List<HashSet<Vector2Int>>(m_Layers);
            m_PlanesPerLayer = new List<List<TLayerPlane>>(m_Layers);
            m_ModifiedPlanesPerLayer = new List<List<TLayerPlane>>(m_Layers);
            m_RemovedPlanesPerLayer = new List<List<TLayerPlane>>(m_Layers);
            for (var i = 0; i < m_Layers; ++i)
            {
                m_UpdatedVoxelsPerLayer.Add(new HashSet<Vector2Int>());
                m_PlanesPerLayer.Add(new List<TLayerPlane>());
                m_ModifiedPlanesPerLayer.Add(new List<TLayerPlane>());
                m_RemovedPlanesPerLayer.Add(new List<TLayerPlane>());
            }
        }

        protected PlaneVoxel GetVoxel(int layer, int column, int row)
        {
            return GetVoxel(new Vector3Int(layer, column, row));
        }

        protected PlaneVoxel GetVoxel(Vector3Int coordinates)
        {
            return m_Voxels.TryGetValue(coordinates, out var voxelData) ?
                voxelData : new PlaneVoxel { LayerCoordinates = new Vector2Int(coordinates.y, coordinates.z) };
        }

        public void AddPoints(List<Vector3> points)
        {
            int worldX, worldY, worldZ;
            Vector3 offsetFromVoxel;
            switch (m_Orientation)
            {
                case VoxelGridOrientation.Up:
                    foreach (var point in points)
                    {
                        GetWorldVoxelCoordinates(point, out worldX, out worldY, out worldZ, out offsetFromVoxel);
                        AddPointToVoxel(worldY, worldX, worldZ, offsetFromVoxel.y);
                    }
                    break;
                case VoxelGridOrientation.Down:
                    foreach (var point in points)
                    {
                        GetWorldVoxelCoordinates(point, out worldX, out worldY, out worldZ, out offsetFromVoxel);
                        AddPointToVoxel(m_WorldYVoxels - 1 - worldY, worldX, m_WorldZVoxels - 1 - worldZ, -offsetFromVoxel.y);
                    }
                    break;
                case VoxelGridOrientation.Forward:
                    foreach (var point in points)
                    {
                        GetWorldVoxelCoordinates(point, out worldX, out worldY, out worldZ, out offsetFromVoxel);
                        AddPointToVoxel(worldZ, worldX, m_WorldYVoxels - 1 - worldY, offsetFromVoxel.z);
                    }
                    break;
                case VoxelGridOrientation.Back:
                    foreach (var point in points)
                    {
                        GetWorldVoxelCoordinates(point, out worldX, out worldY, out worldZ, out offsetFromVoxel);
                        AddPointToVoxel(m_WorldZVoxels - 1 - worldZ, m_WorldXVoxels - 1 - worldX, m_WorldYVoxels - 1 - worldY, -offsetFromVoxel.z);
                    }
                    break;
                case VoxelGridOrientation.Right:
                    foreach (var point in points)
                    {
                        GetWorldVoxelCoordinates(point, out worldX, out worldY, out worldZ, out offsetFromVoxel);
                        AddPointToVoxel(worldX, m_WorldZVoxels - 1 - worldZ, m_WorldYVoxels - 1 - worldY, offsetFromVoxel.x);
                    }
                    break;
                case VoxelGridOrientation.Left:
                    foreach (var point in points)
                    {
                        GetWorldVoxelCoordinates(point, out worldX, out worldY, out worldZ, out offsetFromVoxel);
                        AddPointToVoxel(m_WorldXVoxels - 1 - worldX, worldZ, m_WorldYVoxels - 1 - worldY, -offsetFromVoxel.x);
                    }
                    break;
            }
        }

        void GetWorldVoxelCoordinates(Vector3 point, out int worldX, out int worldY, out int worldZ, out Vector3 offsetFromVoxel)
        {
            var invLerpX = Mathf.InverseLerp(m_GridBoundsMin.x, m_GridBoundsMax.x, point.x);
            var invLerpY = Mathf.InverseLerp(m_GridBoundsMin.y, m_GridBoundsMax.y, point.y);
            var invLerpZ = Mathf.InverseLerp(m_GridBoundsMin.z, m_GridBoundsMax.z, point.z);
            worldX = Mathf.FloorToInt(m_WorldXVoxels * invLerpX);
            worldY = Mathf.FloorToInt(m_WorldYVoxels * invLerpY);
            worldZ = Mathf.FloorToInt(m_WorldZVoxels * invLerpZ);
            var voxelPosition = m_MinVoxelPosition + new Vector3(m_VoxelSize * worldX, m_VoxelSize * worldY, m_VoxelSize * worldZ);
            offsetFromVoxel = point - voxelPosition;
        }

        void AddPointToVoxel(int layer, int column, int row, float pointYOffset)
        {
            var coordinates = new Vector3Int(layer, column, row);
            var voxel = GetVoxel(coordinates);
            var currentPointsCount = voxel.PointDensity;
            var newPointsCount = currentPointsCount + 1;
            var avgYOffset = voxel.PointYOffset;
            voxel.PointYOffset = (avgYOffset * currentPointsCount + pointYOffset) / newPointsCount;
            voxel.PointDensity = newPointsCount;
            m_Voxels[coordinates] = voxel;
            m_UpdatedVoxelsPerLayer[layer].Add(voxel.LayerCoordinates);
        }

        protected Pose GetLayerOriginPose(int layerIndex)
        {
            var layerOrigin = m_GridOriginPose;
            layerOrigin.position += m_VoxelSize * layerIndex * layerOrigin.up;
            return layerOrigin;
        }

        protected void FindPlanes()
        {
            if (MarsDebugSettings.SimPlaneFindingLogging)
                Debug.Log($"{m_DebugFilter} FindPlanes");

            // First find planes in each individual layer.
            // Then see if we can merge planes in adjacent layers.
            // Then see if we can merge planes in each individual layer.

            for (var i = 0; i < m_Layers; i++)
            {
                ProcessUpdatedVoxels(i);
            }

            for (var i = 0; i < m_Layers - 1; i++)
            {
                MergeModifiedPlanesAcrossLayers(i);
            }

            for (var i = 0; i < m_Layers; i++)
            {
                MergeModifiedPlanesInLayer(i);
            }
        }

        void ProcessUpdatedVoxels(int layer)
        {
            var updatedVoxels = m_UpdatedVoxelsPerLayer[layer];
            var modifiedPlanes = m_ModifiedPlanesPerLayer[layer];
            modifiedPlanes.Clear();

            foreach (var plane in m_RemovedPlanesPerLayer[layer])
            {
                plane.Recycle();
            }

            m_RemovedPlanesPerLayer[layer].Clear();

            // First find voxels that do not pass the density threshold
            k_Voxels.Clear();
            foreach (var voxel in updatedVoxels)
            {
                if (GetVoxel(layer, voxel.x, voxel.y).PointDensity < m_MinPointsPerVoxel)
                    k_Voxels.Add(voxel);
            }

            foreach (var voxel in k_Voxels)
            {
                updatedVoxels.Remove(voxel);
            }

            // Next find voxels that are already part of planes, and update the elevations of those planes.
            // If there is a layer above this one then we should check voxels in this layer and the next, since some
            // planes contain voxels across layers.
            var planes = m_PlanesPerLayer[layer];
            if (layer < m_Layers - 1)
            {
                var nextLayer = layer + 1;
                var nextLayerUpdatedVoxels = m_UpdatedVoxelsPerLayer[nextLayer];
                foreach (var layerPlane in planes)
                {
                    k_Voxels.Clear();
                    var updatedVoxelsYOffset = 0f;
                    foreach (var voxel in updatedVoxels)
                    {
                        if (layerPlane.Voxels.Contains(voxel))
                        {
                            k_Voxels.Add(voxel);
                            updatedVoxelsYOffset += GetVoxel(layer, voxel.x, voxel.y).PointYOffset;
                        }
                    }

                    k_NextLayerVoxels.Clear();
                    if (layerPlane.CrossLayer)
                    {
                        foreach (var voxel in nextLayerUpdatedVoxels)
                        {
                            if (layerPlane.Voxels.Contains(voxel))
                            {
                                k_NextLayerVoxels.Add(voxel);

                                // Include voxel size in the y offset for voxels that belong to the layer above
                                updatedVoxelsYOffset += GetVoxel(nextLayer, voxel.x, voxel.y).PointYOffset + m_VoxelSize;
                            }
                        }
                    }

                    var updatedCount = k_Voxels.Count + k_NextLayerVoxels.Count;
                    if (updatedCount > 0)
                    {
                        foreach (var voxel in k_Voxels)
                        {
                            updatedVoxels.Remove(voxel);
                        }

                        var prevYOffset = layerPlane.YOffsetFromLayer;
                        var totalCount = layerPlane.Voxels.Count;
                        var newYOffset = (prevYOffset * (totalCount - updatedCount) + updatedVoxelsYOffset) / totalCount;
                        layerPlane.YOffsetFromLayer = newYOffset;
                        modifiedPlanes.Add(layerPlane);
                    }
                }
            }
            else
            {
                foreach (var layerPlane in planes)
                {
                    k_Voxels.Clear();
                    var updatedVoxelsYOffset = 0f;
                    foreach (var voxel in updatedVoxels)
                    {
                        if (layerPlane.Voxels.Contains(voxel))
                        {
                            k_Voxels.Add(voxel);
                            updatedVoxelsYOffset += GetVoxel(layer, voxel.x, voxel.y).PointYOffset;
                        }
                    }

                    var updatedCount = k_Voxels.Count;
                    if (updatedCount > 0)
                    {
                        foreach (var voxel in k_Voxels)
                        {
                            updatedVoxels.Remove(voxel);
                        }

                        var prevYOffset = layerPlane.YOffsetFromLayer;
                        var totalCount = layerPlane.Voxels.Count;
                        var newYOffset = (prevYOffset * (totalCount - updatedCount) + updatedVoxelsYOffset) / totalCount;
                        layerPlane.YOffsetFromLayer = newYOffset;
                        modifiedPlanes.Add(layerPlane);
                    }
                }
            }

            // Create new planes from the remaining voxels
            var checkEmptyArea = m_CheckEmptyArea && CheckEmptyAreaForInitialPlanes;
            var logging = MarsDebugSettings.SimPlaneFindingLogging;
            var createPlaneIter = 0;
            while (updatedVoxels.Count > 0)
            {
                if (logging)
                    Debug.Log($"{m_DebugFilter} Create plane iteration {createPlaneIter}; remaining voxels count = {updatedVoxels.Count}");

                k_VoxelsQueue.Clear();
                var startingVoxel = updatedVoxels.First();
                updatedVoxels.Remove(startingVoxel);
                var layerPlane = CreateLayerPlane(GetVoxel(layer, startingVoxel.x, startingVoxel.y));
                QueueUpdatedVoxelNeighbors(startingVoxel, updatedVoxels, k_VoxelsQueue);

                if (checkEmptyArea)
                {
                    k_VoxelCornersInPlane.Clear();
                    AddVoxelCorners(startingVoxel, k_VoxelCornersInPlane);
                    bool planeChanged;
                    do
                    {
                        planeChanged = false;
                        k_VoxelsToRevisit.Clear();
                        while (k_VoxelsQueue.Count > 0)
                        {
                            var currentVoxel = k_VoxelsQueue.Dequeue();
                            k_PotentialPlanePoints.Clear();
                            k_PotentialPlaneVertices.Clear();
                            k_PotentialPlanePoints.AddRange(k_VoxelCornersInPlane);
                            AddVoxelCorners(currentVoxel, k_PotentialPlanePoints);
                            GeometryUtils.ConvexHull2D(k_PotentialPlanePoints, k_PotentialPlaneVertices);
                            if (PassesEmptyAreaCheck(k_PotentialPlaneVertices, k_PotentialPlanePoints.Count / 4))
                            {
                                k_VoxelCornersInPlane.Clear();
                                k_VoxelCornersInPlane.AddRange(k_PotentialPlanePoints);
                                layerPlane.AddVoxel(GetVoxel(layer, currentVoxel.x, currentVoxel.y));
                                QueueUpdatedVoxelNeighbors(currentVoxel, updatedVoxels, k_VoxelsQueue);
                                planeChanged = true;
                            }
                            else
                            {
                                k_VoxelsToRevisit.Enqueue(currentVoxel);
                            }
                        }

                        while (k_VoxelsToRevisit.Count > 0)
                        {
                            k_VoxelsQueue.Enqueue(k_VoxelsToRevisit.Dequeue());
                        }
                    } while (planeChanged && k_VoxelsQueue.Count > 0);
                }
                else
                {
                    while (k_VoxelsQueue.Count > 0)
                    {
                        var currentVoxel = k_VoxelsQueue.Dequeue();
                        layerPlane.AddVoxel(GetVoxel(layer, currentVoxel.x, currentVoxel.y));
                        QueueUpdatedVoxelNeighbors(currentVoxel, updatedVoxels, k_VoxelsQueue);
                    }
                }

                UpdateLayerPlaneVertices(layerPlane);
                planes.Add(layerPlane);
                modifiedPlanes.Add(layerPlane);
                createPlaneIter++;
            }

            if (logging && createPlaneIter > 0)
                Debug.Log($"{m_DebugFilter} Done creating planes");
        }

        protected abstract TLayerPlane CreateLayerPlane(PlaneVoxel startingVoxel);

        void QueueUpdatedVoxelNeighbors(Vector2Int voxel, HashSet<Vector2Int> updatedVoxels, Queue<Vector2Int> voxelsQueue)
        {
            k_VoxelNeighbors.Clear();
            var column = voxel.x;
            var row = voxel.y;
            var leftColumn = column - 1;
            var rightColumn = column + 1;
            var bottomRow = row - 1;
            var topRow = row + 1;
            var leftAvailable = leftColumn >= 0;
            var rightAvailable = rightColumn < m_Columns;
            var bottomAvailable = bottomRow >= 0;
            var topAvailable = topRow < m_Rows;

            if (leftAvailable)
            {
                k_VoxelNeighbors.Add(new Vector2Int(leftColumn, row));

                if (bottomAvailable)
                    k_VoxelNeighbors.Add(new Vector2Int(leftColumn, bottomRow));

                if (topAvailable)
                    k_VoxelNeighbors.Add(new Vector2Int(leftColumn, topRow));
            }

            if (rightAvailable)
            {
                k_VoxelNeighbors.Add(new Vector2Int(rightColumn, row));

                if (bottomAvailable)
                    k_VoxelNeighbors.Add(new Vector2Int(rightColumn, bottomRow));

                if (topAvailable)
                    k_VoxelNeighbors.Add(new Vector2Int(rightColumn, topRow));
            }

            if (bottomAvailable)
                k_VoxelNeighbors.Add(new Vector2Int(column, bottomRow));

            if (topAvailable)
                k_VoxelNeighbors.Add(new Vector2Int(column, topRow));

            foreach (var neighbor in k_VoxelNeighbors)
            {
                if (updatedVoxels.Contains(neighbor))
                {
                    voxelsQueue.Enqueue(neighbor);
                    updatedVoxels.Remove(neighbor);
                }
            }
        }

        void UpdateLayerPlaneVertices(LayerPlaneData layerPlane)
        {
            k_VoxelCornersInPlane.Clear();
            foreach (var voxel in layerPlane.Voxels)
            {
                AddVoxelCorners(voxel, k_VoxelCornersInPlane);
            }

            layerPlane.Vertices.Clear();
            GeometryUtils.ConvexHull2D(k_VoxelCornersInPlane, layerPlane.Vertices);
        }

        void AddVoxelCorners(Vector2Int voxel, List<Vector3> voxelCorners)
        {
            // Plane vertices are in XZ relative to the layer origin (the center of the voxel at column 0, row 0).
            // We add each voxel's outer points to a list and then get the convex hull of all those points.
            var column = voxel.x;
            var row = voxel.y;
            var center = new Vector3(m_VoxelSize * column, 0f, m_VoxelSize * row);
            voxelCorners.Add(center + new Vector3(m_VoxelHalfSize, 0f, m_VoxelHalfSize));
            voxelCorners.Add(center + new Vector3(m_VoxelHalfSize, 0f, -m_VoxelHalfSize));
            voxelCorners.Add(center + new Vector3(-m_VoxelHalfSize, 0f, -m_VoxelHalfSize));
            voxelCorners.Add(center + new Vector3(-m_VoxelHalfSize, 0f, m_VoxelHalfSize));
        }

        void MergeModifiedPlanesAcrossLayers(int lowerLayer)
        {
            var lowerModifiedPlanes = m_ModifiedPlanesPerLayer[lowerLayer];
            var upperLayer = lowerLayer + 1;
            var upperPlanes = m_PlanesPerLayer[upperLayer];
            var upperModifiedPlanes = m_ModifiedPlanesPerLayer[upperLayer];
            var upperRemovedPlanes = m_RemovedPlanesPerLayer[upperLayer];
            foreach (var lowerPlane in lowerModifiedPlanes)
            {
                var lowerPlaneVertices = lowerPlane.Vertices;
                for (var i = upperPlanes.Count - 1; i >= 0; i--)
                {
                    var upperPlane = upperPlanes[i];
                    var upperPlaneVertices = upperPlane.Vertices;
                    var lowerPlaneHeight = lowerPlane.YOffsetFromLayer;
                    var upperPlaneHeight = upperPlane.YOffsetFromLayer + m_VoxelSize;
                    if (Mathf.Abs(upperPlaneHeight - lowerPlaneHeight) > m_CrossLayerMergeDistance)
                        continue;

                    if (!GeometryUtils.PolygonsWithinSqRange(lowerPlaneVertices, upperPlaneVertices, m_InLayerMergeSqDistance))
                        continue;

                    if (!TryMergePlanes(lowerPlane, upperPlane, lowerPlaneHeight, upperPlaneHeight))
                    {
                        continue;
                    }

                    lowerPlane.CrossLayer = true;
                    upperPlanes.RemoveAt(i);
                    upperModifiedPlanes.Remove(upperPlane);
                    upperRemovedPlanes.Add(upperPlane);
                }
            }
        }

        void MergeModifiedPlanesInLayer(int layer)
        {
            var modifiedPlanes = m_ModifiedPlanesPerLayer[layer];
            if (modifiedPlanes.Count == 0)
                return;

            var allPlanes = m_PlanesPerLayer[layer];
            var removedPlanes = m_RemovedPlanesPerLayer[layer];
            bool planesMerged;
            var iteration = 0;
            var logging = MarsDebugSettings.SimPlaneFindingLogging;
            do
            {
                if (logging)
                {
                    Debug.Log($"{m_DebugFilter} merge within layer iteration {iteration}; " +
                        $"all planes count = {allPlanes.Count}; modified planes count = {modifiedPlanes.Count}");
                }

                planesMerged = false;
                k_RemovedPlanesSet.Clear();
                foreach (var planeA in modifiedPlanes)
                {
                    if (k_RemovedPlanesSet.Contains(planeA))
                        continue;

                    var planeAVertices = planeA.Vertices;

                    // Iterate backwards since we remove planes as we merge them
                    for (var i = allPlanes.Count - 1; i >= 0; i--)
                    {
                        var planeB = allPlanes[i];
                        if (planeB == planeA)
                            continue;

                        var planeBVertices = planeB.Vertices;
                        if (!GeometryUtils.PolygonsWithinSqRange(planeAVertices, planeBVertices, m_InLayerMergeSqDistance))
                            continue;

                        if (!TryMergePlanes(planeA, planeB, planeA.YOffsetFromLayer, planeB.YOffsetFromLayer))
                        {
                            continue;
                        }

                        planesMerged = true;
                        allPlanes.RemoveAt(i);
                        removedPlanes.Add(planeB);
                        k_RemovedPlanesSet.Add(planeB);
                    }
                }

                foreach (var plane in k_RemovedPlanesSet)
                {
                    modifiedPlanes.Remove(plane);
                }

                iteration++;
            } while (planesMerged);

            if (logging)
                Debug.Log($"{m_DebugFilter} Done merging planes");

            k_RemovedPlanesSet.Clear();
        }

        protected virtual bool TryMergePlanes(TLayerPlane planeA, TLayerPlane planeB, float planeAHeight, float planeBHeight)
        {
            k_PotentialPlanePoints.Clear();
            k_PotentialPlaneVertices.Clear();
            k_PotentialPlaneVoxels.Clear();

            var planeAVertices = planeA.Vertices;
            var planeBVertices = planeB.Vertices;
            k_PotentialPlanePoints.AddRange(planeAVertices);
            k_PotentialPlanePoints.AddRange(planeBVertices);
            GeometryUtils.ConvexHull2D(k_PotentialPlanePoints, k_PotentialPlaneVertices);

            var planeAVoxels = planeA.Voxels;
            var planeBVoxels = planeB.Voxels;
            k_PotentialPlaneVoxels.UnionWith(planeAVoxels);
            k_PotentialPlaneVoxels.UnionWith(planeBVoxels);

            if (m_CheckEmptyArea && !PassesEmptyAreaCheck(k_PotentialPlaneVertices, k_PotentialPlaneVoxels.Count))
                return false;

            planeAVertices.Clear();
            planeAVertices.AddRange(k_PotentialPlaneVertices);
            planeAVoxels.UnionWith(planeBVoxels);

            // The y offset of the merged plane is a weighted average of the y offsets of each sub-plane,
            // with weights determined by the number of voxels in each sub-plane.
            var planeANumVoxels = planeAVoxels.Count;
            var planeBNumVoxels = planeBVoxels.Count;
            planeA.YOffsetFromLayer = (planeAHeight * planeANumVoxels + planeBHeight * planeBNumVoxels) /
                (planeANumVoxels + planeBNumVoxels);

            return true;
        }

        bool PassesEmptyAreaCheck(List<Vector3> planeVertices, int numVoxelsInPlane)
        {
            // A rough approximation of empty area is the difference between the total area of the plane geometry
            // and the combined area of all voxels that contribute to the plane.
            var area = GeometryUtils.ConvexPolygonArea(planeVertices);
            var emptyArea = area - m_VoxelSqSize * numVoxelsInPlane;
            return emptyArea <= m_AllowedEmptyAreaCurve.Evaluate(area) * area;
        }

        protected bool TryGetPlaneData(LayerPlaneData layerPlane, Pose layerOriginPose,
            List<Vector3> vertices, out Pose pose, out Vector3 center, out Vector2 extents)
        {
            var layerPlaneVertices = layerPlane.Vertices;
            extents = GeometryUtils.OrientedMinimumBoundingBox2D(layerPlaneVertices, k_PlaneBoundingBox);
            if (extents.x < m_MinSideLength || extents.y < m_MinSideLength)
            {
                pose = default;
                center = default;
                return false;
            }

            var centroid = GeometryUtils.PolygonCentroid2D(layerPlaneVertices);
            var layerPlanePose = new Pose(centroid, GeometryUtils.RotationForBox(k_PlaneBoundingBox));

            foreach (var vertex in layerPlaneVertices)
            {
                var localVertex = layerPlanePose.ApplyInverseOffsetTo(vertex);
                vertices.Add(localVertex);
            }

            for (var j = 0; j < k_PlaneBoundingBox.Length; ++j)
            {
                k_PlaneBoundingBox[j] = layerPlanePose.ApplyInverseOffsetTo(k_PlaneBoundingBox[j]);
            }

            layerPlanePose.position += k_Up * (layerPlane.YOffsetFromLayer + k_PlaneYEpsilon);
            pose = layerOriginPose.ApplyOffsetTo(layerPlanePose);
            center = (k_PlaneBoundingBox[0] + k_PlaneBoundingBox[2]) * 0.5f;
            return true;
        }
    }
}

using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// A grid of voxels that is used to find and grow planes of a specific orientation over time.
    /// Planes can be found in each individual layer of the grid based on the density of points in each voxel.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PlaneDiscoveryVoxelGrid : PlaneVoxelGrid<MRLayerPlaneData>, IUsesCameraOffset
    {
        class DebugVoxelData
        {
            public Color DebugColor;
            public Vector3 Center;
            public Vector3 YOffsetCenter;
        }

        const float k_DebugVoxelMargin = 0.01f;
        const float k_DebugYOffsetCubeThickness = 0.005f;

        static readonly Color k_DebugUnusedVoxelsColor = new Color(1f, 1f, 1f, 0.3f);

        readonly MarsPlaneAlignment m_PlaneAlignment;

        readonly Vector3 m_DebugVoxelSize;
        readonly Vector3 m_DebugVoxelYOffsetSize;
        readonly Dictionary<Vector3Int, DebugVoxelData> m_DebugUpdatedVoxels = new Dictionary<Vector3Int, DebugVoxelData>();

        public IProvidesCameraOffset provider { get; set; }

        protected override bool CheckEmptyAreaForInitialPlanes
        {
            // In discovery, planes created from processing updated voxels should always be small enough that there's
            // no need to check how much empty area they take up. It is sufficient to only check empty area when merging planes.
            get { return false; }
        }

        /// <inheritdoc/>
        public PlaneDiscoveryVoxelGrid(
            VoxelGridOrientation orientation, Bounds containedBounds, float voxelSize, VoxelPlaneFindingParams planeFindingParams)
            : base(orientation, containedBounds, voxelSize, planeFindingParams)
        {
            m_PlaneAlignment = orientation == VoxelGridOrientation.Up ? MarsPlaneAlignment.HorizontalUp : orientation == VoxelGridOrientation.Down ?
                MarsPlaneAlignment.HorizontalDown : MarsPlaneAlignment.Vertical;

            m_DebugVoxelSize = Vector3.one * (voxelSize - k_DebugVoxelMargin * 2f);
            m_DebugVoxelYOffsetSize = m_DebugVoxelSize;
            switch (orientation)
            {
                case VoxelGridOrientation.Up:
                case VoxelGridOrientation.Down:
                    m_DebugVoxelYOffsetSize.y = k_DebugYOffsetCubeThickness;
                    break;
                case VoxelGridOrientation.Forward:
                case VoxelGridOrientation.Back:
                    m_DebugVoxelYOffsetSize.z = k_DebugYOffsetCubeThickness;
                    break;
                case VoxelGridOrientation.Right:
                case VoxelGridOrientation.Left:
                    m_DebugVoxelYOffsetSize.x = k_DebugYOffsetCubeThickness;
                    break;
            }
        }

        public void FindMRPlanes(
            List<MRPlane> addedPlanes, List<MRPlane> updatedPlanes, List<MRPlane> removedPlanes, List<Color> addedPlaneDebugColors)
        {
            if (MarsDebugSettings.SimDiscoveryVoxelsDebug)
            {
                m_DebugUpdatedVoxels.Clear();
                for (var i = 0; i < m_Layers; i++)
                {
                    var layerOrigin = GetLayerOriginPose(i);
                    var updatedVoxels = m_UpdatedVoxelsPerLayer[i];
                    foreach (var voxel in updatedVoxels)
                    {
                        AddDebugVoxelData(i, voxel, layerOrigin);
                    }
                }
            }

            FindPlanes();

            for (var i = 0; i < m_Layers; i++)
            {
                var layerOrigin = GetLayerOriginPose(i);
                var modifiedLayerPlanes = m_ModifiedPlanesPerLayer[i];
                foreach (var layerPlane in modifiedLayerPlanes)
                {
                    var mrPlane = layerPlane.MRPlane;
                    if (mrPlane.id == MarsTrackableId.InvalidId)
                    {
                        // This layer plane doesn't have an MRPlane yet, so try to create one.
                        // This can fail if the plane is too small.
                        if (TryCreateMRPlane(layerPlane, layerOrigin))
                        {
                            addedPlanes.Add(layerPlane.MRPlane);
                            addedPlaneDebugColors.Add(layerPlane.DebugColor);
                        }
                    }
                    else
                    {
                        UpdateMRPlane(layerPlane, layerOrigin);
                        updatedPlanes.Add(layerPlane.MRPlane);
                    }
                }

                var removedLayerPlanes = m_RemovedPlanesPerLayer[i];
                foreach (var layerPlane in removedLayerPlanes)
                {
                    // Some layer planes get removed in merges before they have ever created an MRPlane
                    var mrPlane = layerPlane.MRPlane;
                    if (mrPlane.id != MarsTrackableId.InvalidId)
                        removedPlanes.Add(mrPlane);
                }
            }

            if (!MarsDebugSettings.SimDiscoveryVoxelsDebug)
                return;

            // Debug colors for voxels must be assigned at the end since the planes voxels belong to can change during merges
            for (var i = 0; i < m_Layers; i++)
            {
                var modifiedLayerPlanes = m_ModifiedPlanesPerLayer[i];
                foreach (var layerPlane in modifiedLayerPlanes)
                {
                    foreach (var voxel in layerPlane.Voxels)
                    {
                        DebugVoxelData debugData;
                        if (m_DebugUpdatedVoxels.TryGetValue(new Vector3Int(i, voxel.x, voxel.y), out debugData))
                            debugData.DebugColor = layerPlane.DebugColor;
                    }

                    if (layerPlane.CrossLayer)
                    {
                        var nextLayer = i + 1;
                        foreach (var voxel in layerPlane.Voxels)
                        {
                            DebugVoxelData debugData;
                            if (m_DebugUpdatedVoxels.TryGetValue(new Vector3Int(nextLayer, voxel.x, voxel.y), out debugData))
                                debugData.DebugColor = layerPlane.DebugColor;
                        }
                    }
                }
            }
        }

        void AddDebugVoxelData(int layer, Vector2Int layerCoordinates, Pose layerOriginPose)
        {
            var column = layerCoordinates.x;
            var row = layerCoordinates.y;
            var voxel = GetVoxel(layer, column, row);
            var debugData = new DebugVoxelData();
            var rotation = layerOriginPose.rotation;
            var center = layerOriginPose.position + rotation * new Vector3(column * m_VoxelSize, 0f, row * m_VoxelSize);
            debugData.Center = center;
            debugData.YOffsetCenter = center + rotation * (k_Up * voxel.PointYOffset);
            debugData.DebugColor = k_DebugUnusedVoxelsColor;
            m_DebugUpdatedVoxels.Add(new Vector3Int(layer, column, row), debugData);
        }

        protected override MRLayerPlaneData CreateLayerPlane(PlaneVoxel startingVoxel) { return MRLayerPlaneData.GetOrCreate(startingVoxel); }

        protected override bool TryMergePlanes(MRLayerPlaneData planeA, MRLayerPlaneData planeB, float planeAHeight, float planeBHeight)
        {
            if (!base.TryMergePlanes(planeA, planeB, planeAHeight, planeBHeight))
                return false;

            var mrPlaneA = planeA.MRPlane;
            var mrPlaneB = planeB.MRPlane;
            if (mrPlaneA.id == MarsTrackableId.InvalidId && mrPlaneB.id != MarsTrackableId.InvalidId)
            {
                // Swapping MRPlanes helps us avoid an unnecessary plane loss event when one MRPlane is valid and the other is not.
                // Since it is always layer plane B that gets removed during a merge, we have to account for the case of
                // B having a valid MRPlane and A having an invalid one. We can avoid a loss of the valid MRPlane by swapping
                // the MRPlanes. Layer plane A will update its MRPlane and layer plane B will be removed without a loss event for its MRPlane.
                planeB.MRPlane = mrPlaneA;
                planeA.MRPlane = mrPlaneB;

                // We need to also preserve the debug color of the valid plane
                planeA.DebugColor = planeB.DebugColor;
            }

            return true;
        }

        bool TryCreateMRPlane(MRLayerPlaneData layerPlane, Pose layerOriginPose)
        {
            var mrPlaneVertices = new List<Vector3>();
            Pose pose;
            Vector3 center;
            Vector2 extents;
            if (!TryGetPlaneData(layerPlane, layerOriginPose, mrPlaneVertices, out pose, out center, out extents))
                return false;

            var vertsCount = mrPlaneVertices.Count;
            var normals = new List<Vector3>(vertsCount);
            var textureCoordinates = new List<Vector2>(vertsCount);
            var indices = new List<int>();
            PlaneUtils.TriangulatePlaneFromVertices(pose, mrPlaneVertices, indices, normals, textureCoordinates);

            var mrPlane = new MRPlane
            {
                id = MarsTrackableId.Create(),
                alignment = m_PlaneAlignment,
                vertices = mrPlaneVertices,
                normals = normals,
                indices = indices,
                textureCoordinates = textureCoordinates,
                pose = pose,
                center = center,
                extents = extents
            };

            layerPlane.MRPlane = mrPlane;
            return true;
        }

        void UpdateMRPlane(MRLayerPlaneData layerPlane, Pose layerOriginPose)
        {
            var mrPlane = layerPlane.MRPlane;
            var mrPlaneVertices = mrPlane.vertices;
            mrPlaneVertices.Clear();
            Pose pose;
            Vector3 center;
            Vector2 extents;
            TryGetPlaneData(layerPlane, layerOriginPose, mrPlaneVertices, out pose, out center, out extents);
            mrPlane.pose = pose;
            mrPlane.center = center;
            mrPlane.extents = extents;

            // Grow capacity for normals and UVs if needed
            const int capacityBuffer = 8;
            var vertsCount = mrPlaneVertices.Count;
            var normals = mrPlane.normals;
            if (normals.Capacity <= vertsCount)
                normals.Capacity = vertsCount + capacityBuffer;

            var textureCoordinates = mrPlane.textureCoordinates;
            if (textureCoordinates.Capacity <= vertsCount)
                textureCoordinates.Capacity = vertsCount + capacityBuffer;

            var indices = mrPlane.indices;
            indices.Clear();
            normals.Clear();
            textureCoordinates.Clear();
            PlaneUtils.TriangulatePlaneFromVertices(mrPlane.pose, mrPlaneVertices, indices, normals, textureCoordinates);

            layerPlane.MRPlane = mrPlane;
        }

        public void DrawDebugVoxels()
        {
            foreach (var kvp in m_DebugUpdatedVoxels)
            {
                var debugData = kvp.Value;
                Gizmos.color = debugData.DebugColor;
                Gizmos.DrawWireCube(debugData.Center, m_DebugVoxelSize);
                Gizmos.DrawCube(debugData.YOffsetCenter, m_DebugVoxelYOffsetSize);
            }
        }
    }
}

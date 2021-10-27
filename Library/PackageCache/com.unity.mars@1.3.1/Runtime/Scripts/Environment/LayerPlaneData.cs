using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    [MovedFrom("Unity.MARS")]
    public class LayerPlaneData
    {
        // Voxels already contains one element--increase capacity to 32
        const int k_VoxelPreWarmCount = 31;
        const int k_InitialPoolSize = 32;
        const int k_InitialVertexCapacity = 16;
        static readonly Stack<LayerPlaneData> k_Pool = new Stack<LayerPlaneData>();

        /// <summary>
        /// XZ vertices of the plane, relative to the layer origin
        /// </summary>
        public readonly List<Vector3> Vertices = new List<Vector3>(k_InitialVertexCapacity);

        /// <summary>
        /// Y offset of the plane, relative to the layer origin
        /// </summary>
        public float YOffsetFromLayer;

        /// <summary>
        /// Coordinates of voxels that contribute to this plane
        /// </summary>
        public readonly HashSet<Vector2Int> Voxels;

        /// <summary>
        /// Is this plane included in the layer above it due to a cross-layer merge?
        /// </summary>
        public bool CrossLayer;

        static LayerPlaneData()
        {
            var allocated = new List<LayerPlaneData>();
            for (var i = 0; i < k_InitialPoolSize; i++)
            {
                var data = GetOrCreate(default);
                allocated.Add(data);
                for (var j = 0; j < k_VoxelPreWarmCount; j++)
                {
                    data.Voxels.Add(new Vector2Int(i,j));
                }
            }
            foreach (var item in allocated)
                item.Recycle();
        }

        protected LayerPlaneData(PlaneVoxel startingVoxel)
        {
            Voxels = new HashSet<Vector2Int> { startingVoxel.LayerCoordinates };
            YOffsetFromLayer = startingVoxel.PointYOffset;
        }

        internal virtual void Reset(PlaneVoxel startingVoxel)
        {
            Voxels.Clear();
            Voxels.Add(startingVoxel.LayerCoordinates);
            YOffsetFromLayer = startingVoxel.PointYOffset;
            Vertices.Clear();
            CrossLayer = false;
        }

        public static LayerPlaneData GetOrCreate(PlaneVoxel startingVoxel)
        {
            if (k_Pool.Count > 0)
            {
                var data = k_Pool.Pop();
                data.Reset(startingVoxel);
                return data;
            }

            return new LayerPlaneData(startingVoxel);
        }

        public void AddVoxel(PlaneVoxel voxel)
        {
            var numVoxelsInPlane = Voxels.Count;
            Voxels.Add(voxel.LayerCoordinates);
            YOffsetFromLayer = (YOffsetFromLayer * numVoxelsInPlane + voxel.PointYOffset) / Voxels.Count;
        }

        internal virtual void Recycle()
        {
            k_Pool.Push(this);
        }
    }
}

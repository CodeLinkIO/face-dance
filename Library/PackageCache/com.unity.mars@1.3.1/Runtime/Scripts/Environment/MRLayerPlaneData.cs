using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Random = UnityEngine.Random;

namespace Unity.MARS.Data.Synthetic
{
    [MovedFrom("Unity.MARS")]
    public class MRLayerPlaneData : LayerPlaneData
    {
        // Voxels already contains one element--increase capacity to 32
        const int k_VoxelPreWarmCount = 31;
        const int k_InitialPoolSize = 32;
        static readonly Stack<MRLayerPlaneData> k_Pool = new Stack<MRLayerPlaneData>();

        public MRPlane MRPlane;
        public Color DebugColor;

        static MRLayerPlaneData()
        {
            var allocated = new List<MRLayerPlaneData>();
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

        MRLayerPlaneData(PlaneVoxel startingVoxel)
            : base(startingVoxel)
        {
            InitDebugColor();
        }

        void InitDebugColor()
        {
            DebugColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        }

        public new static MRLayerPlaneData GetOrCreate(PlaneVoxel startingVoxel)
        {
            if (k_Pool.Count > 0)
            {
                var data = k_Pool.Pop();
                data.Reset(startingVoxel);
                return data;
            }

            return new MRLayerPlaneData(startingVoxel);
        }

        internal override void Reset(PlaneVoxel startingVoxel)
        {
            base.Reset(startingVoxel);
            MRPlane = default;
            InitDebugColor();
        }

        internal override void Recycle()
        {
            k_Pool.Push(this);
        }
    }
}

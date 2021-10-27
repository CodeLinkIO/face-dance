using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class PlaneVoxelGenerationParams
    {
        const int k_DefaultRaycastCount = 204800;
        const float k_DefaultMaxHitDistance = 10f;
        const float k_DefaultNormalToleranceAngle = 15f;
        const float k_DefaultVoxelSize = 0.1f;
        const float k_DefaultOuterPointsThreshold = 0.2f;

        [Tooltip("Seed with which to initialize the random number generator used to create rays")]
        public int raycastSeed;

        [Tooltip("Number of raycasts used to generate a point cloud")]
        public int raycastCount = k_DefaultRaycastCount;

        [Tooltip("Maximum hit distance for each raycast")]
        public float maxHitDistance = k_DefaultMaxHitDistance;

        [Tooltip("If the angle between a point's normal and a voxel grid direction is within this range, the point is added to the grid")]
        public float normalToleranceAngle = k_DefaultNormalToleranceAngle;

        [Tooltip("Side length of each voxel")]
        public float voxelSize = k_DefaultVoxelSize;

        [Tooltip("Points that are within this distance from the bounds outer side " +
                 "facing the same way as the point's normal will be ignored")]
        public float outerPointsThreshold = k_DefaultOuterPointsThreshold;
    }
}

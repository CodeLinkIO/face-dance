using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class VoxelPlaneFindingParams
    {
        const int k_DefaultMinPointsPerSqMeter = 600;
        const float k_DefaultMinSideLength = 0.15f;
        const float k_DefaultInLayerMergeDistance = 0.2f;
        const float k_DefaultCrossLayerMergeDistance = 0.05f;

        [Tooltip("Voxel point density threshold that is independent of voxel size")]
        public int minPointsPerSqMeter = k_DefaultMinPointsPerSqMeter;

        [Tooltip("A plane with x or y extent less than this value will be ignored")]
        public float minSideLength = k_DefaultMinSideLength;

        [Tooltip("Planes within the same layer that are at most this distance from each other will be merged")]
        public float inLayerMergeDistance = k_DefaultInLayerMergeDistance;

        [Tooltip("Planes in adjacent layers with an elevation difference of at most this much will be merged")]
        public float crossLayerMergeDistance = k_DefaultCrossLayerMergeDistance;

        [Tooltip("When enabled, planes will only be created if they do not contain too much empty area")]
        public bool checkEmptyArea;

        [Tooltip("Curve that maps the area of a plane to the ratio of area that is allowed to be empty")]
        public AnimationCurve allowedEmptyAreaCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.Synthetic
{
    /// <summary>
    /// Data for synthetic planes extracted from a synthetic environment
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public struct ExtractedPlaneData
    {
        /// <summary>
        /// Collection of the plane vertices
        /// </summary>
        public List<Vector3> vertices;
        /// <summary>
        /// Pose of the plane
        /// </summary>
        public Pose pose;
        /// <summary>
        /// Center of the Plane
        /// </summary>
        public Vector3 center;
        /// <summary>
        /// Extents of the plane
        /// </summary>
        public Vector2 extents;
    }
}

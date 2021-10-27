using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// A segment of a mesh with a pose
    /// </summary>
    [Serializable]
    class MeshSegment
    {
        [SerializeField]
        Pose m_Pose;

        [SerializeField]
        List<Vector3> m_Vertices = new List<Vector3>();

        [SerializeField]
        List<Vector3> m_Normals = new List<Vector3>();

        [SerializeField]
        List<int> m_Indices = new List<int>();

        /// <summary>
        /// Mesh vertices
        /// </summary>
        public List<Vector3> Vertices => m_Vertices;

        /// <summary>
        /// Per-vertex normals
        /// </summary>
        public List<Vector3> Normals => m_Normals;

        /// <summary>
        /// Mesh indices (triangles)
        /// </summary>
        public List<int> Indices => m_Indices;

        /// <summary>
        /// Model pose for this mesh segment (all segments are at [1, 1, 1] scale)
        /// </summary>
        public Pose Pose { get => m_Pose; set => m_Pose = value; }
    }
}

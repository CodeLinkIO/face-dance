using System;
using UnityEngine;
using System.Collections.Generic;

namespace Unity.MARS.Companion.Core
{
    /// <summary>
    /// Collections of captured mesh segments that exist in the same space
    /// </summary>
    [Serializable]
    class MeshCapture
    {
        [SerializeField]
        List<MeshSegment> m_Meshes = new List<MeshSegment>();

        /// <summary>
        /// Mesh segments included in this capture
        /// </summary>
        public List<MeshSegment> Meshes { get => m_Meshes; set => m_Meshes = value; }
    }
}

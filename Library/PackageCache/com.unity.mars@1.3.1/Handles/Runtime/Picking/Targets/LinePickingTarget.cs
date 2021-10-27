using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    /// <summary>
    /// A Picking target that uses a line strip for picking.
    /// </summary>
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    sealed class LinePickingTarget : MonoBehaviour, IPickingTarget
    {
        [SerializeField] Vector3[] m_Points = {Vector3.zero, Vector3.one};

        readonly List<Vector3> m_Vertices = new List<Vector3>();
        readonly List<int> m_Indices = new List<int>();
        Transform m_Transform;
        Mesh m_Mesh;

        /// <summary>
        /// The points used to create the line in local space. Returns a copy of the point array.
        /// </summary>
        public Vector3[] points
        {
            get
            {
                Vector3[] p = new Vector3[m_Points.Length];
                Array.Copy(m_Points, p, m_Points.Length);
                return p;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                m_Points = value;
                UpdatePickingMeshData();
            }
        }

        void OnEnable()
        {
            EnsureMeshExists();
            m_Transform = transform;
            UpdatePickingMeshData();
        }

        void OnDisable()
        {
            DestroyImmediate(m_Mesh);
        }

        void OnValidate()
        {
            EnsureMeshExists();
            UpdatePickingMeshData();
        }

        void UpdatePickingMeshData()
        {
            int prevIndicesSize = m_Indices.Count;
            m_Indices.Clear();
            for (int i = 0; i < m_Points.Length; ++i)
            {
                m_Indices.Add(i);
            }

            m_Vertices.Clear();
            for (int i = 0; i < m_Points.Length; ++i)
            {
                m_Vertices.Add(m_Points[i]);
            }

            if (prevIndicesSize != m_Indices.Count)
                m_Mesh.Clear();

            m_Mesh.SetVertices(m_Vertices);
            m_Mesh.SetIndices(m_Indices.ToArray(), m_Indices.Count > 1 ? MeshTopology.LineStrip : MeshTopology.Points, 0);
        }

        void EnsureMeshExists()
        {
            if (m_Mesh == null)
                m_Mesh = new Mesh();
        }

        public PickingData GetPickingData()
        {
            return new PickingData(m_Transform, m_Mesh);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = transform.localToWorldMatrix;
            for (var i = 0; i < m_Points.Length-1; ++i)
            {
                var a = m_Points[i];
                var b = m_Points[i + 1];
                Gizmos.DrawLine(a, b);
            }
        }
    }
}

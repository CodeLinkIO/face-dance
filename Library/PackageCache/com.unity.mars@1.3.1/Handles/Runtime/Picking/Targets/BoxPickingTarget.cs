using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    /// <summary>
    /// A Picking target that uses a box for picking.
    /// </summary>
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    sealed class BoxPickingTarget : MonoBehaviour, IPickingTarget
    {
        [SerializeField]
        [Tooltip("The offset in local space used to place the box")]
        Vector3 m_Offset = Vector3.zero;

        [SerializeField]
        [Tooltip("The size of the box")]
        Vector3 m_Size = Vector3.one;

        Transform m_Transform;

        static readonly int[] s_Indices =
        {
            0, 1, 2, 3,
            0, 1, 5, 4,
            4, 5, 6, 7,
            6, 7, 3, 2,
            0, 4, 7, 3,
            1, 5, 6, 2,
        };

        readonly Vector3[] m_Vertices = new Vector3[8];
        Mesh m_Mesh;

        /// <summary>
        /// The offset in local space used to place the box.
        /// </summary>
        public Vector3 offset
        {
            get { return m_Offset; }
            set
            {
                m_Offset = value;
                UpdatePickingMeshData();
            }
        }

        /// <summary>
        /// The size of the box.
        /// </summary>
        public Vector3 size
        {
            get { return m_Size; }
            set
            {
                m_Size = value;
                UpdatePickingMeshData();
            }
        }

        /// <summary>
        /// Set the information required by the box picking target.
        /// This will only recalculate the picking mesh once instead of for each property.
        /// </summary>
        /// <param name="offset">The offset in local space used to place the box.</param>
        /// <param name="size">The size of the box.</param>
        public void Set(Vector3 offset, Vector3 size)
        {
            m_Offset = offset;
            m_Size = size;
            UpdatePickingMeshData();
        }

        void OnEnable()
        {
            m_Transform = transform;
            EnsureMeshExists();
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

        public PickingData GetPickingData()
        {
            return new PickingData(m_Transform, m_Mesh);
        }

        void UpdatePickingMeshData()
        {
            var extents = m_Size * 0.5f;
            var offset = m_Offset;

            m_Vertices[0] = (offset + new Vector3(-extents.x, -extents.y, extents.z));
            m_Vertices[1] = (offset + new Vector3(-extents.x, extents.y, extents.z));
            m_Vertices[2] = (offset + new Vector3(extents.x, extents.y, extents.z));
            m_Vertices[3] = (offset + new Vector3(extents.x, -extents.y, extents.z));
            m_Vertices[4] = (offset + new Vector3(-extents.x, -extents.y, -extents.z));
            m_Vertices[5] = (offset + new Vector3(-extents.x, extents.y, -extents.z));
            m_Vertices[6] = (offset + new Vector3(extents.x, extents.y, -extents.z));
            m_Vertices[7] = (offset + new Vector3(extents.x, -extents.y, -extents.z));

            m_Mesh.vertices = m_Vertices;
        }

        void EnsureMeshExists()
        {
            if (m_Mesh == null)
            {
                m_Mesh = new Mesh
                {
                    vertices = new[]
                    {
                        Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero,
                        Vector3.zero, Vector3.zero
                    }
                };

                m_Mesh.SetIndices(s_Indices, MeshTopology.Quads, 0);
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(m_Offset, m_Size);
        }
    }
}

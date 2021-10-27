using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    /// <summary>
    /// A Picking target that uses a mesh for picking.
    /// </summary>
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    sealed class MeshPickingTarget : MonoBehaviour, IPickingTarget
    {
        [SerializeField]
        [Tooltip("The mesh used for picking")]
        Mesh m_CollisionMesh = null;

        Transform m_Transform;

        /// <summary>
        /// The mesh used for picking.
        /// </summary>
        public Mesh collisionMesh
        {
            get { return m_CollisionMesh; }
            set
            {
                if (m_CollisionMesh == value)
                    return;

                m_CollisionMesh = value;
            }
        }

        void OnEnable()
        {
            m_Transform = transform;
        }

        public PickingData GetPickingData()
        {
            return new PickingData(m_Transform, m_CollisionMesh);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireMesh(m_CollisionMesh);
        }
    }
}

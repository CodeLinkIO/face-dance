using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.AI;
using Unity.MARS.Query;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.AI
{

    [RequireComponent(typeof(NavMeshSurface))]
    [MovedFrom("Unity.MARS")]
    public class MARSNavMeshSurface : MonoBehaviour, ISpawnable
    {
        Transform m_Transform;
        NavMeshSurface m_NavMeshSurface;

        void Awake()
        {
            m_Transform = transform;
            m_NavMeshSurface = GetComponent<NavMeshSurface>();
            m_NavMeshSurface.collectObjects = CollectObjects.Children;
        }

        public void OnMatchAcquire(QueryResult result) { RebuildNavMesh(); }

        public void OnMatchUpdate(QueryResult result) { RebuildNavMesh(); }

        public void OnMatchLoss(QueryResult result) { RebuildNavMesh(); }

        void RebuildNavMesh()
        {
            var navMeshData = m_NavMeshSurface.navMeshData;
            if (navMeshData == null)
            {
                m_NavMeshSurface.BuildNavMesh();
            }
            else
            {
                navMeshData.position = m_Transform.position;
                navMeshData.rotation = m_Transform.rotation;
                m_NavMeshSurface.UpdateNavMesh(navMeshData);
            }
        }
    }

}

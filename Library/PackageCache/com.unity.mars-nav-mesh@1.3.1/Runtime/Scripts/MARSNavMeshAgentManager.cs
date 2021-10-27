using Unity.MARS.MARSUtils;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.AI
{
    [MovedFrom("Unity.MARS")]
    public class MARSNavMeshAgentManager : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        LayerMask m_LayerMask;

        [SerializeField]
        GameObject m_AgentPrefab;

        Camera m_Camera;
        MARSNavMeshAgent m_Agent;
#pragma warning restore 649

        void Start()
        {
            m_Camera = MarsRuntimeUtils.GetActiveCamera(true);

            if (m_AgentPrefab == null)
            {
                m_Agent = GetComponent<MARSNavMeshAgent>();
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 500, Color.blue);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_LayerMask))
                {
                    if (m_Agent)
                        m_Agent.SetDestination(hit.point);
                    else
                        m_Agent = GameObjectUtils.Instantiate(m_AgentPrefab, hit.point, Quaternion.identity).GetComponent<MARSNavMeshAgent>();
                }
            }
        }
    }
}

using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    [MovedFrom("Unity.MARS")]
    public abstract class ConditionBase : MonoBehaviour, ISimulatable
    {
        Proxy m_Proxy;

        /// <summary>
        /// Entity associated with this condition
        /// </summary>
        public Proxy proxy
        {
            get
            {
                if (m_Proxy == null)
                    m_Proxy = GetComponent<Proxy>();
                return m_Proxy;
            }
        }

        public bool drawWarning { get; protected set; }

        public virtual void OnValidate()
        {
            drawWarning = false;
        }
    }
}

using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Base class for creating from trait data.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class CreateFromDataBase
    {
        protected GameObject m_CreatedObject;
        protected bool m_Replicate;
        protected Replicator m_Replicator;
        protected internal Transform ObjectParent;

        /// <summary>
        /// If enabled, the created object will be replicated for all matches. The max instance count can be set via SetMaxCount
        /// </summary>
        public bool Replicate
        {
            get => m_Replicate;
            set
            {
                m_Replicate = value;
                SetupReplicator();
            }
        }

        /// <summary>
        /// The max count for the created replicator. If set to 1, there will be no replicator. 0 indicates infinite matches.
        /// </summary>
        public int MaxCount
        {
            get
            {
                return m_Replicator == null ? 1 : m_Replicator.MaxInstances;
            }
            set
            {
                m_Replicate = value != 1;
                SetupReplicator();

                if (m_Replicator != null)
                    m_Replicator.MaxInstances = value;
            }
        }

        protected void SetupReplicator()
        {
            if (m_Replicate)
            {
                if (m_Replicator == null)
                    m_Replicator = new GameObject("Replicator", typeof(Replicator)).GetComponent<Replicator>();

                if (m_CreatedObject != null)
                    m_CreatedObject.transform.SetParent(m_Replicator.transform);
            }
            else
            {
                if (m_CreatedObject != null)
                    m_CreatedObject.transform.SetParent(ObjectParent);

                if (m_Replicator != null)
                    UnityObjectUtils.Destroy(m_Replicator.gameObject);
            }
        }

        internal virtual void CancelCreate()
        {
            if (m_CreatedObject != null)
                UnityObjectUtils.Destroy(m_CreatedObject);

            if (m_Replicator != null && m_Replicator.gameObject != null)
                UnityObjectUtils.Destroy(m_Replicator.gameObject);
        }
    }
}

using System;
using Unity.MARS.Actions;
using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Companion
{
    /// <summary>
    /// Marks companion app surfaces in the Proxy Scan flow as matched so that the proxy can be selected
    /// </summary>
    [RequireComponent(typeof(Proxy))]
    [MonoBehaviourComponentMenu(typeof(MatchAction), "Action/Mark Surface Action")]
    class MarkSurfaceAction : MonoBehaviour, IMatchAcquireHandler, IMatchLossHandler
    {
        Proxy m_Proxy;

        /// <summary>
        /// Called when a match has been found
        /// </summary>
        public event Action<QueryResult, Proxy> MatchAcquire;

        /// <summary>
        /// Called when a match has been lost
        /// </summary>
        public event Action<QueryResult, Proxy> MatchLoss;

        void Awake()
        {
            m_Proxy = GetComponent<Proxy>();
        }

        /// <summary>
        /// Called when a query match has been found
        /// </summary>
        /// <param name="queryResult">Data associated with this event</param>
        public void OnMatchAcquire(QueryResult queryResult)
        {
            MatchAcquire?.Invoke(queryResult, m_Proxy);
        }

        /// <summary>
        /// Called when a query match has been lost
        /// </summary>
        /// <param name="queryResult">Data associated with this event</param>
        public void OnMatchLoss(QueryResult queryResult)
        {
            MatchLoss?.Invoke(queryResult, m_Proxy);
        }
    }
}

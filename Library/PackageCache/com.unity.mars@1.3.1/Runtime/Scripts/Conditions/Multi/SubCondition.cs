using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class that must be used to build up any members of MultiConditions
    /// </summary>
    [System.Serializable]
    [MovedFrom("Unity.MARS")]
    public class SubCondition
    {
        /// <summary>
        /// Refers to the MonoBehaviour that is a MultiCondition hosting this SubCondition
        /// </summary>
        [HideInInspector]
        public MonoBehaviour Host;

        public bool enabled { get { return (Host != null) ? Host.enabled : false; } }
    }
}

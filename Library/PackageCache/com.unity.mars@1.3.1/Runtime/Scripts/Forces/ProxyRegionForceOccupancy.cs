using System.Collections;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.MARS.Forces
{
    [HelpURL(DocumentationConstants.ProxyRegionForceOccupancyDocs)]
    [RequireComponent(typeof(ProxyForces))]
    [ComponentTooltip("Applies a region force of occupancy or padding/emptiness to the proxy")]
    [MonoBehaviourComponentMenu(typeof(ProxyRegionForceOccupancy), "Forces/Region Occupancy")]
    public class ProxyRegionForceOccupancy : ProxyRegionForceBase
    {
        [SerializeField]
        [Tooltip("When enabled, will avoid occupied regions but allow overlap with other padding regions.")]
        private bool m_IsPadding;

        public bool isPadding
        {
            get => m_IsPadding;
            set => m_IsPadding = value;
        }

        internal override ProxyForceRegionDefintion GetRegionDefinition()
        {
            var rd = base.GetRegionDefinition();
            rd.regionType = (isPadding ? ProxyRegionForceType.PaddingKeptEmpty : ProxyRegionForceType.OccupiedSpace);
            return rd;
        }
    }

}

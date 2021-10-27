using System.Collections;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.MARS.Forces
{
    [HelpURL(DocumentationConstants.ProxyRegionForceTowardsDocs)]
    [ComponentTooltip("Applies a region force towards nearby regions, filtered by layers/alignments/edges")]
    [MonoBehaviourComponentMenu(typeof(ProxyRegionForceTowards), "Forces/Region Towards")]
    [RequireComponent(typeof(ProxyForces))]
    public class ProxyRegionForceTowards : ProxyRegionForceBase
    {
        [SerializeField]
        [Tooltip("Which layers to attract towards")]
        private LayerMask m_TowardsLayers = ProxyForceRegionDefintion.LayerMaskAll;

        [SerializeField]
        [Tooltip("Which alignments to attract towards")]
        private MarsPlaneAlignment m_TowardsAlignment = MarsPlaneAlignment.None;

        [SerializeField]
        [Tooltip("When enabled, will only attract to the edge of the object.")]
        private bool m_TowardsEdgeOnly;

        public LayerMask towardsLayers
        {
            get => m_TowardsLayers;
            set => m_TowardsLayers = value;
        }

        public MarsPlaneAlignment towardsAlignment
        {
            get => m_TowardsAlignment;
            set => m_TowardsAlignment = value;
        }

        public bool towardsEdgeOnly
        {
            get => m_TowardsEdgeOnly;
            set => m_TowardsEdgeOnly = value;
        }

        internal override ProxyForceRegionDefintion GetRegionDefinition()
        {
            var rd = base.GetRegionDefinition();
            rd.regionType = (towardsEdgeOnly ? ProxyRegionForceType.TowardsOccupiedEdge : ProxyRegionForceType.TowardsOccupiedSpace);
            rd.touchesAlignmentMask = towardsAlignment;
            rd.touchesLayersMask = towardsLayers;

            return rd;
        }
    }
}

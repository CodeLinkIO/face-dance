using System.Collections;
using System.Collections.Generic;
using Unity.MARS.Data;
using UnityEngine;

namespace Unity.MARS.Forces.ForceDefinitions
{
    internal enum ProxyForceRegionResponce
    {
        Nothing = 0,
        StayOutOf,
        AlignWithVolume,
        AlignWithEdge,
        COUNT_TYPES,
    }

    [System.Serializable]
    internal struct ProxyForceRegionDefintion
    {
        public ProxyRegionForceType regionType;
        public LayerMask touchesLayersMask;
        public MarsPlaneAlignment touchesAlignmentMask;
        public LayerMask regionLayer;
        public MarsPlaneAlignment regionAlignment;


        public ProxyForceFieldPrimitive shapePrimitive;
        [Range(0.0f, 2.0f)]
        public float fieldWeightScalar;

        public static ProxyForceRegionDefintion Default
        {
            get
            {
                var ans = new ProxyForceRegionDefintion();
                ans.regionType = ProxyRegionForceType.OccupiedSpace;
                ans.shapePrimitive = ProxyForceFieldPrimitive.Default;
                ans.touchesAlignmentMask = MarsPlaneAlignment.None;
                ans.touchesLayersMask = LayerMaskAll;
                ans.regionAlignment = MarsPlaneAlignment.None;
                ans.regionLayer = LayerMaskDefault;
                ans.fieldWeightScalar = 1.0f;
                return ans;
            }
        }

        public static LayerMask LayerMaskDefault => 1; // default layer id
        public static LayerMask LayerMaskAll => ~0; // all layers

        internal ProxyForceRegionResponce GetResponceTypeToOtherRegion(ProxyForceRegionDefintion other)
        {
            var coreResp = ProxyForceRegionResponce.Nothing;
            switch (regionType)
            {
                case ProxyRegionForceType.None:
                    coreResp = ProxyForceRegionResponce.Nothing;
                    break;
                case ProxyRegionForceType.OccupiedSpace:
                    if ((other.regionType == ProxyRegionForceType.OccupiedSpace) || (other.regionType == ProxyRegionForceType.PaddingKeptEmpty))
                    {
                        coreResp = ProxyForceRegionResponce.StayOutOf;
                    }
                    break;
                case ProxyRegionForceType.PaddingKeptEmpty:
                    if (other.regionType == ProxyRegionForceType.OccupiedSpace)
                    {
                        coreResp = ProxyForceRegionResponce.StayOutOf;
                    }
                    break;
                case ProxyRegionForceType.TowardsOccupiedSpace:
                    if (other.regionType == ProxyRegionForceType.OccupiedSpace)
                    {
                        coreResp = ProxyForceRegionResponce.AlignWithVolume;
                    }
                    break;
                case ProxyRegionForceType.TowardsOccupiedEdge:
                    if (other.regionType == ProxyRegionForceType.OccupiedSpace)
                    {
                        coreResp = ProxyForceRegionResponce.AlignWithEdge;
                    }
                    break;

            }
            if (coreResp == ProxyForceRegionResponce.Nothing) return ProxyForceRegionResponce.Nothing;

            if (touchesAlignmentMask != MarsPlaneAlignment.None)
            {
                if (other.regionAlignment != touchesAlignmentMask)
                {
                    return ProxyForceRegionResponce.Nothing;
                }
            }
            if ((touchesLayersMask != 0) && ((touchesLayersMask & other.regionLayer) == 0))
            {
                return ProxyForceRegionResponce.Nothing;
            }

            return coreResp;
        }

        internal static float GetResponceWeight(ProxyForceRegionResponce responce)
        {
            switch (responce)
            {
                case ProxyForceRegionResponce.Nothing:
                    return 0.0f;
                case ProxyForceRegionResponce.StayOutOf:
                case ProxyForceRegionResponce.AlignWithVolume:
                case ProxyForceRegionResponce.AlignWithEdge:
                    return 1.0f;
                default:
                    throw new System.NotImplementedException("Responce weight for : " + responce);
            }
        }

    }

}

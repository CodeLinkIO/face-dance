using System.Collections.Generic;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEngine;

namespace Unity.MARS.Forces.ForceDefinitions
{
    internal struct ProxyForceFieldRegion
    {
        public bool isActive;
        public ProxyForceRegionDefintion regionDefinition;
        public MarsTrackableId trackableId;
        public Pose proxyRelativePose;
        public MarsTrackableId requireOtherId;
    }

    internal struct ProxyForceFieldAlignment
    {
        public bool isActive;
        public ProxyForceFieldId targetProxyId;
        public ProxyForceAlignmentDefinition alignmentDefinition;
    }

    internal struct ProxyForceField : System.IDisposable
    {
        public ProxyForceFieldId proxyId;
        public bool isActive;
        public bool isNotTracking;
        public ProxyForceMotionType allowedMotion;
        public List<ProxyForceFieldRegion> regions;
        public List<ProxyForceFieldAlignment> alignments;

        public void Dispose()
        {
            if (regions != null) { regions.Clear(); regions = default; }
            if (alignments != null) { alignments.Clear(); alignments = default; }
            isActive = false;
        }

        public void CloneFrom(ProxyForceField other)
        {
            // could make copies of the region list at this point, but currently not needed (used to use NativeArray)
            this = other;
        }
    }



}

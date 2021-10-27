using System;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Forces.ForceDefinitions;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Forces
{
    /// <summary>
    /// Applies a planar region attraction force to the proxy at its origin.
    /// </summary>
	[HelpURL(DocumentationConstants.ProxyRegionForcePlane2DDocs)]
    [RequireComponent(typeof(ProxyForces))]
    [ComponentTooltip("Applies a planar region attraction force to the proxy at its origin")]
    [MonoBehaviourComponentMenu(typeof(ProxyRegionForcePlane2D), "Forces/Region Planar Force")]
    public class ProxyRegionForcePlane2D : MonoBehaviour, IProxyRegionForceSource, IMatchAcquireHandler, IMatchUpdateHandler, IMatchLossHandler, IUsesMARSTrackableData<MRPlane>
    {
        [SerializeField]
        [Tooltip("When enabled within a plane proxy, only is attracted to the matched plane.")]
        bool m_KeepMatchPlane;

        [SerializeField]
        [Tooltip("When enabled, gets the region size from a PlaneSizeCondition available at start.")]
        bool m_UsePlaneSizeCondition = true;

        [SerializeField]
        [Tooltip("When enabled, gets the region alignment from an AlignmentCondition available at start.")]
        bool m_UseAlignmentCondition = true;

        [SerializeField]
        [Tooltip("Size on the 2d plane in meters")]
        Vector2 m_PlaneSize = Vector2.zero;

        [SerializeField]
        [Tooltip("Alignment the plane should be attracted towards")]
        MarsPlaneAlignment m_PlaneAlignment = MarsPlaneAlignment.None;

        bool m_CachedComponentsYet;
        MarsTrackableId m_MatchDataId;

        /// <summary>
        /// Size on the 2d plane in meters
        /// </summary>
        public Vector2 planeSize
        {
            get => m_PlaneSize;
            set => m_PlaneSize = value;
        }

        /// <summary>
        /// Alignment the plane should be attracted towards
        /// </summary>
        public MarsPlaneAlignment planeAlignment
        {
            get => m_PlaneAlignment;
            set => m_PlaneAlignment = value;
        }

        /// <summary>
        /// When enabled within a plane proxy, only is attracted to the matched plane.
        /// </summary>
        public bool KeepMatchPlane { get => m_KeepMatchPlane; set => m_KeepMatchPlane = value; }

        public void UpdateFromSources()
        {
            var planeSizeCondition = GetComponent<PlaneSizeCondition>();
            var alignmentCondition = GetComponent<AlignmentCondition>();

            if (m_UsePlaneSizeCondition && planeSizeCondition && planeSizeCondition.minBounded)
            {
                m_PlaneSize = planeSizeCondition.minimumSize;
            }

            if (m_UseAlignmentCondition && alignmentCondition)
            {
                m_PlaneAlignment = alignmentCondition.alignment;
            }
        }

        void MarkForcesDirty()
        {
            var forces = GetComponent<ProxyForces>();

            if (!forces)
                forces = GetComponentInParent<ProxyForces>();

            if (forces)
                forces.MarkFieldDirty();
        }

        void OnEnable()
        {
            MarkForcesDirty();
        }

        void OnDisable()
        {
            MarkForcesDirty();
        }

        void CheckCachedCompoonents()
        {
            if (m_CachedComponentsYet)
                return;

            m_CachedComponentsYet = true;
            UpdateFromSources();
        }

        ProxyForceFieldRegion GetRegionForce(ProxyForces proxyForces)
        {
            CheckCachedCompoonents();

            const float defaultWidth = 0.01f; // 1cm

            var region = ProxyForceRegionDefintion.Default;
            region.regionType = ProxyRegionForceType.TowardsOccupiedSpace;
            region.touchesAlignmentMask = m_PlaneAlignment;
            region.shapePrimitive.primitiveType = ProxyForceFieldPrimitive.FieldPrimitiveType.Box;

            var minBound = Vector3.one * defaultWidth; // 1cm
            if (m_PlaneSize != Vector2.zero)
            {
                minBound = (new Vector3(m_PlaneSize.x, defaultWidth, m_PlaneSize.y )) * 0.5f;
            }
            region.shapePrimitive.vectorRadii = minBound;

            var anyActive = ((m_PlaneSize != Vector2.zero) || (m_PlaneAlignment != MarsPlaneAlignment.None));

            var fr = new ProxyForceFieldRegion()
            {
                isActive = isActiveAndEnabled && anyActive,
                proxyRelativePose = new Pose(Vector3.zero, Quaternion.identity),
                trackableId = MarsTrackableId.InvalidId,
                regionDefinition = region,
                requireOtherId = (m_KeepMatchPlane ? m_MatchDataId : MarsTrackableId.InvalidId),
            };
            return fr;
        }

        public void UpdateRegionDefinitionWithin(ProxyForces proxyForces)
        {
            proxyForces.UpdateRegion(GetRegionForce(proxyForces));
        }

        void UpdateQueryResult(QueryResult queryResult)
        {
            if (m_KeepMatchPlane)
            {
                var plane = queryResult.ResolveValue(this);
                m_MatchDataId = plane.id;
                MarkForcesDirty();
            }
        }

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult) { UpdateQueryResult(queryResult); }

        /// <inheritdoc />
        public void OnMatchUpdate(QueryResult queryResult) { UpdateQueryResult(queryResult); }

        /// <inheritdoc />
        public void OnMatchLoss(QueryResult queryResult)
        {
            if (m_KeepMatchPlane)
            {
                m_MatchDataId = MarsTrackableId.InvalidId;
                MarkForcesDirty();
            }
        }
    }

}

using System;
using Unity.MARS.Forces.ForceDefinitions;
using UnityEngine;

namespace Unity.MARS.Forces
{
    internal interface IProxyRegionForceSource
    {
        // wrapper to avoid making the region definition type public:
        void UpdateRegionDefinitionWithin(ProxyForces proxyForces);
    }

    /// <summary>
    /// How this force-field reacts to others
    /// </summary>
    [Serializable]
    public enum ProxyRegionForceType
    {
        /// <summary>
        /// No affect on other shapes
        /// </summary>
        None = 0,

        /// <summary>
        /// De-collides with other occupied and empty spaces
        /// </summary>
        OccupiedSpace = 1,

        /// <summary>
        /// De-collides with occupied spaces, can overlap other empty spaces
        /// </summary>
        PaddingKeptEmpty = 2,

        /// <summary>
        /// Moves towards occupied spaces
        /// </summary>
        TowardsOccupiedSpace = 3,

        /// <summary>
        /// Moves towards edges of occupied spaces
        /// </summary>
        TowardsOccupiedEdge = 4,
    }

    public abstract class ProxyRegionForceBase : MonoBehaviour, IProxyRegionForceSource
    {
        [SerializeField]
        [Tooltip("Unit cube transform to use for the region's shape and pose")]
        private Transform m_RegionTransform;

        bool m_HasEnsuredProxy;
        ProxyForces m_ParentProxy;

        public Transform regionTransform
        {
            get => m_RegionTransform;
            set => m_RegionTransform = value;
        }

        internal virtual ProxyForceRegionDefintion GetRegionDefinition()
        {
            var rd = ProxyForceRegionDefintion.Default;
            var objLayer = gameObject.layer;
            if (objLayer != 0)
            {
                rd.regionLayer = objLayer;
            }
            if (regionTransform)
            {
                rd.shapePrimitive.vectorRadii = regionTransform.localScale * 0.5f;
            }
            return rd;
        }

        internal virtual ProxyForceFieldRegion GetRegionForce()
        {
            var def = GetRegionDefinition();
            var fr = new ProxyForceFieldRegion()
            {
                isActive = enabled && gameObject.activeInHierarchy && (regionTransform != null),
                regionDefinition = def,
                proxyRelativePose = GetRelativePose(),
            };
            return fr;
        }

        public void UpdateRegionDefinitionWithin(ProxyForces proxyForces)
        {
            proxyForces.UpdateRegion(GetRegionForce());
        }

        internal virtual ProxyForceFieldPrimitivePosed GetPosedPrimitive(Pose proxyPose)
        {
            var prim = GetRegionDefinition().shapePrimitive;
            prim.vectorRadii = transform.localScale * 0.5f;
            return new ProxyForceFieldPrimitivePosed(prim, GetPoseFromProxyPose(proxyPose));
        }

        public Pose GetRelativePose()
        {
            if (!regionTransform)
                return Pose.identity;

            if (regionTransform && (regionTransform.transform.parent == transform))
            {
                return new Pose(regionTransform.localPosition, regionTransform.localRotation);
            }

            if (m_ParentProxy)
            {
                var myPose = PoseUtils.FromTransform(transform);
                var proxyPose = m_ParentProxy.TransformPose;
                return PoseUtils.LocalFromWorldPose(proxyPose, myPose);
            }
            else
            {
                return PoseUtils.FromTransformLocal(transform);
            }
        }

        public Pose GetPoseFromProxyPose(Pose p)
        {
            var relative = GetRelativePose();
            return relative.GetTransformedBy(p);
        }

        [ContextMenu("Update Field Defintion")]
        public void CauseUpdateInParentProxy()
        {
            TryEnsureProxy();
            if (m_ParentProxy)
            {
                m_ParentProxy.MarkFieldDirty();
                m_ParentProxy.CheckFieldUpdated();
            }
        }

        void OnEnable()
        {
            CauseUpdateInParentProxy();
        }

        void OnDisable()
        {
            CauseUpdateInParentProxy();
        }


        void TryEnsureProxy()
        {
            if (m_HasEnsuredProxy)
                return;

            m_HasEnsuredProxy = true;

            var vpar = gameObject.GetComponent<ProxyForces>();
            if (!vpar)
            {
                // this is actually the usual case:
                vpar = gameObject.GetComponentInParent<ProxyForces>();
            }
            m_ParentProxy = vpar;
            if (vpar)
            {
                vpar.EnsureSubRegion(this);
            }
            else
            {
                Debug.LogWarning("This region belongs in a Proxy with ProxyForce!");
            }
        }

        void Start()
        {
            TryEnsureProxy();
        }

    }

}

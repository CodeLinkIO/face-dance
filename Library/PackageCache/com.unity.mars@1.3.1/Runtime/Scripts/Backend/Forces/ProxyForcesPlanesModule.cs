using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Forces.ForceDefinitions;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Forces
{
    [ModuleOrder(ModuleOrders.ForcesFromPlanesLoadOrder)]
    class ProxyForcesPlanesModule : IModuleBehaviorCallbacks, IUsesPlaneFinding, IUsesCameraOffset
    {
        ProxyForceField m_FieldDef = CreateFieldProxyDef();
        bool m_FieldUpToDate;

        IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        internal ProxyForceFieldId FieldProxyId { get { return m_FieldDef.proxyId; } }

        void CheckExistingPlanes()
        {
            if (!this.HasProvider<IProvidesPlaneFinding>())
                return;

            var planes = new List<MRPlane>();
            this.GetPlanes(planes);
            foreach (var mrp in planes)
            {
                PlaneAddedHandler(mrp);
            }
        }


        void SetPlaneRegistration(bool isEnable)
        {
            if (!this.HasProvider<IProvidesPlaneFinding>())
                return;

            if (isEnable)
            {
                this.SubscribePlaneAdded(PlaneAddedHandler);
                this.SubscribePlaneUpdated(PlaneUpdatedHandler);
                this.SubscribePlaneRemoved(PlaneRemovedHandler);
            }
            else
            {
                this.UnsubscribePlaneAdded(PlaneAddedHandler);
                this.UnsubscribePlaneUpdated(PlaneUpdatedHandler);
                this.UnsubscribePlaneRemoved(PlaneRemovedHandler);
            }
        }

        int TryFindRegionFieldIndex(MarsTrackableId marsId)
        {
            if (m_FieldDef.regions == null)
                return -1;
            for (var ri = 0; ri < m_FieldDef.regions.Count; ri++)
            {
                if (m_FieldDef.regions[ri].trackableId == marsId)
                {
                    return ri;
                }
            }
            return -1;
        }

        int EnsureRegionFieldIndex(MarsTrackableId marsId)
        {
            var curId = TryFindRegionFieldIndex(marsId);
            if (curId >= 0) return curId;

            if (m_FieldDef.regions == null)
                m_FieldDef.regions = new List<ProxyForceFieldRegion>();

            var nextId = m_FieldDef.regions.Count;
            m_FieldDef.regions.Add(new ProxyForceFieldRegion());
            m_FieldUpToDate = false;
            return nextId;
        }


        void EnsureRegionFieldUpdated(MRPlane plane)
        {
            var regionNdx = EnsureRegionFieldIndex(plane.id);
            const float planeThickness = 0.1f; // in meters
            const float planeOffset = 0.0f;

            ProxyForceRegionDefintion def = ProxyForceRegionDefintion.Default;
            def.regionType = ProxyRegionForceType.OccupiedSpace;
            def.regionAlignment = plane.alignment;
            def.shapePrimitive = ProxyForceFieldPrimitive.Default;
            def.shapePrimitive.vectorRadii = new Vector3(plane.extents.x * 0.5f, planeThickness, plane.extents.y * 0.5f);
            def.shapePrimitive.verticesInXZ = plane.vertices;

            var basePose = plane.pose;
            basePose.position += basePose.rotation * (new Vector3(0, planeOffset, 0));

            var fr = new ProxyForceFieldRegion();
            fr.regionDefinition = def;
            fr.isActive = true;
            fr.proxyRelativePose = basePose;
            fr.trackableId = plane.id;

            m_FieldDef.regions[regionNdx] = fr;

            TryUpdateField(true);
        }

        void TryUpdateField(bool isForce=false)
        {
            if (m_FieldUpToDate && (!isForce))
                return;

            m_FieldUpToDate = false;

            m_FieldDef.isActive = true;

            var xrToWorldOffset = Pose.identity;
            if (this.HasProvider<IProvidesCameraOffset>()) // ideally fix the order this module exists in
                xrToWorldOffset = this.ApplyOffsetToPose(xrToWorldOffset);

            ProxyForcesFieldSolverModule.instance.mainFieldSolver.UpdateFieldProxy(m_FieldDef, xrToWorldOffset);
        }

        void PlaneAddedHandler(MRPlane plane)
        {
            EnsureRegionFieldUpdated(plane);
        }

        void PlaneUpdatedHandler(MRPlane plane)
        {
            EnsureRegionFieldUpdated(plane);
        }

        void PlaneRemovedHandler(MRPlane plane)
        {
            var fieldIndex = TryFindRegionFieldIndex(plane.id);
            if (fieldIndex >= 0)
            {
                var reg = m_FieldDef.regions[fieldIndex];
                if (reg.isActive)
                {
                    reg.isActive = false;
                }
                m_FieldDef.regions[fieldIndex] = reg;

                TryUpdateField(true);
            }

        }

        void IModuleBehaviorCallbacks.OnBehaviorAwake()
        {
            CheckExistingPlanes();
        }

        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
            SetPlaneRegistration(true);
            CheckExistingPlanes();
        }

        void IModuleBehaviorCallbacks.OnBehaviorStart()
        {
            SetPlaneRegistration(true);
            CheckExistingPlanes();
        }

        void IModuleBehaviorCallbacks.OnBehaviorUpdate()
        {
        }

        void IModuleBehaviorCallbacks.OnBehaviorDisable()
        {
            SetPlaneRegistration(false);
            ClearPlanes();
        }

        void IModuleBehaviorCallbacks.OnBehaviorDestroy()
        {
            ClearPlanes();
        }

        public void ClearPlanes()
        {
            m_FieldDef.Dispose();
            m_FieldDef.isActive = true;
            TryUpdateField(true);
        }

        void IModule.LoadModule() { }

        void IModule.UnloadModule()
        {
            ClearPlanes();
        }

        static ProxyForceField CreateFieldProxyDef()
        {
            var ans = new ProxyForceField()
            {
                isActive = true,
                proxyId = ProxyForceFieldId.GenerateNew(),
                allowedMotion = ProxyForceMotionType.NotForced,
            };
            return ans;
        }

        internal ProxyForceField FieldProxyDefinition()
        {
            return m_FieldDef;
        }
    }

}

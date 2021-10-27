using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Forces.ForceDefinitions;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS.Forces
{
    /// <summary>
    /// Constrains how forces affect this object
    /// </summary>
    [Serializable]
    public enum ProxyForceMotionType
    {
        NotForced = 0,
        MoveAndRotateY,
        MoveAndRotateFreely,
        MoveAndRotateZ,
    }

    [HelpURL(DocumentationConstants.ProxyForcesDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Supports alignment and region forces and defines how they affect movement")]
    [MonoBehaviourComponentMenu(typeof(ProxyForces), "Forces/Forces Settings")]
    public class ProxyForces : Condition<Pose>, IPoseRefiner
    {
        [SerializeField]
        [Tooltip("How the object is allowed to move. Use MoveAndRotateAny for no restrictions.")]
        private ProxyForceMotionType m_AllowedMotion = ProxyForceMotionType.MoveAndRotateY;

        [SerializeField]
        [Tooltip("When enabled, forces are applied every frame for interactive placement.")]
        private bool m_ContinuousSolve = true;

        [SerializeField]
        [Tooltip("When enabled, forces act as Proxy Conditions to filter out invalid starting states.")]
        private bool m_RequireForces;

        bool m_HasCheckedChildRefs = false;
        readonly List<IProxyRegionForceSource> m_Regions = new List<IProxyRegionForceSource>();
        readonly List<IProxyAlignmentForceSource> m_Alignments = new List<IProxyAlignmentForceSource>();
        ProxyForceFieldAlignment m_UpdatingAlignment;
        ProxyForceFieldRegion m_UpdatingRegion;

        bool m_FieldIsUpdated;
        bool m_RecursionStopper;
        readonly ProxyForceFieldId m_ForceFieldId = ProxyForceFieldId.GenerateNew();
        ProxyForceField m_FieldDefinition;
        Pose m_LatestFieldPose = Pose.identity;

        public ProxyForceMotionType allowedMotion
        {
            get => m_AllowedMotion;
            set => m_AllowedMotion = value;
        }

        public bool continuousSolve
        {
            get => m_ContinuousSolve;
            set => m_ContinuousSolve = value;
        }

        public bool requireForces
        {
            get => m_RequireForces;
            set => m_RequireForces = value;
        }

        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Pose };

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        internal ProxyForceFieldId ForceFieldId => m_ForceFieldId;

        internal void UpdateAlignment(ProxyForceFieldAlignment alignment) { m_UpdatingAlignment = alignment; }
        internal void UpdateRegion(ProxyForceFieldRegion region) { m_UpdatingRegion = region; }

        /// <inheritdoc />
        public override float RateDataMatch(ref Pose data)
        {
            if (!enabled || !requireForces)
                return 1.0f;

            CheckFieldUpdated();

            var solver = ProxyForcesFieldSolverModule.instance.mainFieldSolver;
            var id = ForceFieldId;
            var testPose = data;

            // In theory we should refine the pose before scoring it, but that is very expensive, and for now
            //  we are mostly using the scoreFatalErrorCount to ensure that all required planes are available,
            //  and otherwise to rate the different options:
            //testPose = RefinePose(testPose, false);

            var score = solver.ScorePose(id, testPose);

            if (requireForces && (score.scoreFatalErrorCount > 0))
            {
                return 0.0f;
            }

            var scoreFlt = Mathf.Clamp01(score.scoreErrorTotal);

            if (!requireForces)
            {
                scoreFlt = Mathf.Lerp(0.5f, 1.0f, scoreFlt);
            }

            return scoreFlt;
        }

        /// <inheritdoc />
        public Pose RefinePose(Pose pose, bool leaveProxyInNewPose)
        {
            return TrySingleSolve(pose, false, leaveProxyInNewPose);
        }

        public void SingleStepTranformPose()
        {
            CheckFieldUpdated();
            if (allowedMotion != ProxyForceMotionType.NotForced)
            {
                var oldPose = TransformPose;
                var newPose = TrySingleSolve(oldPose, true, true);
                TransformPose = newPose;
            }
        }

        internal bool IsTracking
        {
            get
            {
                if (!this.isActiveAndEnabled)
                    return false;
                if (proxy)
                    return ((proxy.queryState & QueryState.Tracking) != 0);
                else
                    return true;
            }
        }

        void FixedUpdate()
        {
            if (continuousSolve && IsTracking)
            {
                SingleStepTranformPose();
            }
        }

        internal void EnsureSubRegion(IProxyRegionForceSource region)
        {
            if (!m_Regions.Contains(region))
            {
                m_Regions.Add(region);
                MarkFieldDirty();
            }
        }

        internal void EnsureSubAlignment(IProxyAlignmentForceSource alignment)
        {
            if (!m_Alignments.Contains(alignment))
            {
                m_Alignments.Add(alignment);
                MarkFieldDirty();
            }
        }

        public void CheckChildReferences()
        {
            if (m_HasCheckedChildRefs) return;
            m_HasCheckedChildRefs = true;

            foreach (var rf in GetComponents<IProxyRegionForceSource>())
            {
                EnsureSubRegion(rf);
            }
            foreach (var rg in GetComponentsInChildren<IProxyRegionForceSource>(true))
            {
                EnsureSubRegion(rg);
            }
            foreach (var al in GetComponents<IProxyAlignmentForceSource>())
            {
                EnsureSubAlignment(al);
            }
            foreach (var al in GetComponentsInChildren<IProxyAlignmentForceSource>())
            {
                EnsureSubAlignment(al);
            }

            CheckFieldUpdated();
        }

        internal static bool IsForceRegion(Transform t)
        {
            if (t.GetComponent<ProxyRegionForceBase>())
                return true;
            var force = t.GetComponentInParent<ProxyForces>();
            if (!force)
                return false;
            foreach (var region in force.GetComponents<ProxyRegionForceBase>())
            {
                if (region.regionTransform == t)
                    return true;
            }
            return false;
        }

        public void MarkFieldDirty()
        {
            m_FieldIsUpdated = false;
        }

        void Start()
        {
            CheckFieldUpdated();
        }

        public Pose TrySingleSolve(Pose rawPose, bool isSingleStep = false, bool isKeepNewPose=false)
        {
            CheckFieldUpdated();

            if (allowedMotion == ProxyForceMotionType.NotForced)
                return rawPose;

            var solver = ProxyForcesFieldSolverModule.instance.mainFieldSolver;

            var myId = ForceFieldId;
            var oldMotion = solver.GetProxyMotion(myId);

            var rawMotion = new ProxyForceFieldMotion(rawPose, isSingleStep ? oldMotion.velocity : Pose.identity );
            solver.UpdateProxyMotion(myId, rawMotion);

            var np = solver.IterateSingleDefault(ForceFieldId, isSingleStep, isSingleStep ? MarsTime.ScaledDeltaTime : 1.0f);

            if (!isKeepNewPose)
            {
                solver.UpdateProxyMotion(myId, oldMotion);
            }

            return np.location;
        }

        [ContextMenu("Force Update Field")]
        public void ForceUpdateField()
        {
            MarkFieldDirty();
            CheckFieldUpdated();
        }

        public void CheckFieldUpdated()
        {
            if (m_RecursionStopper)
                return;

            CheckChildReferences();

            if (m_FieldIsUpdated)
            {
                if (m_FieldDefinition.allowedMotion != allowedMotion)
                {
                    m_FieldIsUpdated = false;
                }
                if (isActiveAndEnabled != m_FieldDefinition.isActive)
                {
                    m_FieldIsUpdated = false;
                }
                if (m_LatestFieldPose != TransformPose)
                {
                    m_FieldIsUpdated = false;
                }
            }
            if (m_FieldIsUpdated)
            {
                return;
            }

            m_RecursionStopper = true;
            ProxyForceField def = new ProxyForceField();
            try
            {
                def = BuildFieldProxyDef();
            }
            catch (System.Exception ex)
            {
                m_RecursionStopper = false;
                Debug.LogException(ex);
            }
            finally
            {
                m_RecursionStopper = false;
            }

            m_FieldIsUpdated = true;
            m_LatestFieldPose = TransformPose;
            ProxyForcesFieldSolverModule.instance.mainFieldSolver.UpdateFieldProxy(def, m_LatestFieldPose);
        }

        static void EnsureListSize<T>(ref List<T> list, int count)
        {
            if (list == null)
                list = new List<T>();
            if (list.Count == count)
                return;
            while (list.Count < count)
                list.Add(default(T));
            while (list.Count > count)
                list.RemoveAt(list.Count-1);
        }

        ProxyForceField BuildFieldProxyDef()
        {
            m_FieldDefinition.isActive = isActiveAndEnabled;
            m_FieldDefinition.isNotTracking = !IsTracking;
            m_FieldDefinition.allowedMotion = allowedMotion;
            m_FieldDefinition.proxyId = m_ForceFieldId;

            EnsureListSize(ref m_FieldDefinition.regions, m_Regions.Count);
            EnsureListSize(ref m_FieldDefinition.alignments, m_Alignments.Count);

            for (var ri = 0; ri < m_Regions.Count; ri++)
            {
                m_Regions[ri].UpdateRegionDefinitionWithin(this);
                m_FieldDefinition.regions[ri] = m_UpdatingRegion;
            }
            for (var ai = 0; ai < m_Alignments.Count; ai++)
            {
                m_Alignments[ai].UpdateAlignmentDefinitionWithin(this);
                var alignment = m_UpdatingAlignment;
                if (alignment.targetProxyId.Equals(ForceFieldId)) // don't align to yourself
                    alignment.targetProxyId = ProxyForceFieldId.DefaultUnknown;
                m_FieldDefinition.alignments[ai] = alignment;
            }

            m_FieldIsUpdated = true;
            return m_FieldDefinition;
        }

        void OnDestroy()
        {
            m_FieldDefinition.Dispose();
        }

        public Pose TransformPose
        {
            get
            {
                return PoseUtils.FromTransform(transform);
            }
            set
            {
                PoseUtils.ApplyToTransform(value, transform);
            }
        }
    }
}

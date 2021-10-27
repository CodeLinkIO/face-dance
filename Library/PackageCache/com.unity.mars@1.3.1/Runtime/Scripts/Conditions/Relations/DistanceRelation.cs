using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Authoring;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    [MonoBehaviourComponentMenu(typeof(DistanceRelation), "Relation/Distance")]
    [CreateFromDataOptions(2, false)]
    [MovedFrom("Unity.MARS")]
    public class DistanceRelation : BoundedFloatRelation<Pose>, IUsesCameraOffset, IAdjustableComponent
    {
        /// <summary>
        /// Defines axes used for a distance constraint
        /// </summary>
        [Flags]
        [Serializable]
        public enum Axis
        {
            Horizontal = 1,
            Vertical = 2,
            Both = Horizontal | Vertical,
        }

        // make sure maximum is at least a centimeter greater than minimum
        const float k_MinimumRange = 0.01f;
        const float k_MinimumBoundValue = 0.01f;
        const float k_DefaultMin = 0.25f;
        const float k_DefaultMax = 1.25f;
        const float k_OptimalPadding = 0.5f;

        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Pose, TraitDefinitions.Pose };

        [SerializeField]
        [Tooltip("Which directions will be taken into account when measuring distance.")]
        Axis m_AxisMask = Axis.Both;

        // these values only change when scale or bounds change, so we cache them for re-use
        float m_RangeCenterPoint;
        float m_HalfRange;

        GameObject m_Handle;
        bool m_Adjusting;

        /// <summary>
        /// Defines which axes to use for the distance constraint
        /// </summary>
        public Axis AxisMask
        {
            get => m_AxisMask;
            set => m_AxisMask = value;
        }

        public IProvidesCameraOffset provider { get; set; }

        /// <summary>
        /// Set to true when interactively adjusting this condition
        /// </summary>
        public bool Adjusting
        {
            get { return m_Adjusting; }
            set
            {
                if (value != m_Adjusting)
                {
                    m_Adjusting = value;
                    AdjustingChanged?.Invoke(m_Adjusting);
                }
            }
        }

        public event Action<bool> AdjustingChanged;

#if UNITY_EDITOR
        public override void Reset()
        {
            base.Reset();
            m_Maximum = k_DefaultMax;
            m_Minimum = k_DefaultMin;
        }
#endif
        public override void OnValidate()
        {
            m_Minimum = m_Minimum < k_MinimumBoundValue ? k_MinimumBoundValue : m_Minimum;
            var minMax = m_Minimum + k_MinimumRange;
            m_Maximum = m_Maximum < minMax ? minMax : m_Maximum;
        }

        public void OnEnable()
        {
            CacheRange();
            AdjustingChanged += OnAdjustingChanged;
        }

        void OnDisable()
        {
            Adjusting = false;
            AdjustingChanged -= OnAdjustingChanged;
        }

        void OnAdjustingChanged(bool isAdjusting)
        {
            var handleModule = ModuleLoaderCore.instance.GetModule<RuntimeHandleContextModule>();
            if (!Application.isPlaying || handleModule == null)
                return;

            if (isAdjusting && m_Handle == null)
            {
                var prefab = MARSRuntimePrefabs.instance.DistanceHandle;
                prefab.SetActive(false);
                m_Handle = handleModule.CreateHandle(prefab);
                prefab.SetActive(true);
                var distanceHandle = m_Handle.GetComponent<DistanceHandle>();
                distanceHandle.DistanceRelation = this;
                m_Handle.SetActive(true);
            }
            else if (!isAdjusting && m_Handle != null)
            {
                handleModule.DestroyHandle(m_Handle);
            }
        }

        public override void OnRatingConfigChange()
        {
            CacheRange();
        }

        void CacheRange()
        {
            var range = m_Maximum - m_Minimum;
            m_HalfRange = range * 0.5f;
            m_RangeCenterPoint = m_Minimum + range * m_RatingConfig.center;
        }

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        public override float RateDataMatch(ref Pose child1Data, ref Pose child2Data)
        {
            var deadZone = m_RatingConfig.deadZone;
            var center = m_RatingConfig.center;
            var distance = Distance(child1Data, child2Data, m_AxisMask);

            var min = m_Minimum;
            var max = m_Maximum;
            if (m_MinBounded)
            {
                if (m_MaxBounded)
                {
                    if (distance < min || distance > max)
                        return 0f;

                    var signedMiddleDiff = distance - m_RangeCenterPoint;
                    var middleDiff = signedMiddleDiff > 0 ? signedMiddleDiff : -signedMiddleDiff;
                    var halfPortion = middleDiff / m_HalfRange;

                    // if our diff is within the dead zone and doesn't fail, we can early out with a perfect match
                    if (halfPortion < deadZone)
                        return 1f;

                    var interpolationFactor = 1f;
                    if (center != 0.5f)
                    {
                        var pointAboveCenter = signedMiddleDiff > 0f;
                        if(!pointAboveCenter)
                            interpolationFactor = center * 2f;
                        else
                            interpolationFactor = (1f - center) * 2f;
                    }

                    var adjustedRange = m_HalfRange * interpolationFactor;
                    var adjustedDeadZone = deadZone / interpolationFactor;
                    var portion = middleDiff / adjustedRange;
                    var t = (portion - adjustedDeadZone) / (1f - adjustedDeadZone);
                    if (t > 1f || t < 0f)
                        return 0f;

                    // inlined Mathf.SmoothStep(1f, min, t)
                    t = -2f * t * t * t + 3f * t * t;
                    var rating = MARSDatabase.MinimumPassingConditionRating * t + 1f * (1f - t);
                    if (rating > 1f)
                        rating = 1f;

                    return rating;
                }

                // if we're only min bounded, return a simple pass / fail
                return distance > min ? 1f : 0f;
            }
            if (m_MaxBounded)
            {
                // if we're only max bounded, return a simple pass / fail
                return distance < max ? 1f : 0f;
            }

            // if we're not bounded on either side somehow, data always matches
            return 1f;
        }

        static float Distance(Pose child1Data, Pose child2Data, Axis axisMask)
        {
            var position1 = child1Data.position;
            var position2 = child2Data.position;

            // these next 4 lines do the same thing as Vector3.Distance(), but faster
            var distX = position1.x - position2.x;
            var distY = position1.y - position2.y;
            var distZ = position1.z - position2.z;
            switch (axisMask)
            {
                case Axis.Vertical:
                    distX = 0.0f;
                    distZ = 0.0f;
                    break;
                case Axis.Horizontal:
                    distY = 0.0f;
                    break;
            }
            var distance = Mathf.Sqrt(distX * distX + distY * distY + distZ * distZ);
            return distance;
        }

        public override void OptimizeForData(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data)
        {
            child1Data.GetTraits(out Dictionary<string, Pose> poses1);
            child2Data.GetTraits(out Dictionary<string, Pose> poses2);
            var distance = Distance(poses1[k_RequiredTraits[0].TraitName], poses2[k_RequiredTraits[1].TraitName], m_AxisMask);
            m_Maximum = distance + k_OptimalPadding;
            m_Minimum = distance - k_OptimalPadding;
        }

        public override string FormatDataString(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data)
        {
            child1Data.GetTraits(out Dictionary<string, Pose> poses1);
            child2Data.GetTraits(out Dictionary<string, Pose> poses2);
            var distance = Distance(poses1[k_RequiredTraits[0].TraitName], poses2[k_RequiredTraits[1].TraitName], m_AxisMask);
            return $"{distance:0.00}m";
        }
    }
}

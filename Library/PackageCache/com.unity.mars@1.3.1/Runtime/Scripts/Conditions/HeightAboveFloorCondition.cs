using Unity.MARS.Attributes;
using Unity.MARS.Authoring;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation where a given plane must be within a certain height off the floor
    /// </summary>
    [HelpURL(DocumentationConstants.HeightAboveFloorConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object be raised above the floor.")]
    [MonoBehaviourComponentMenu(typeof(HeightAboveFloorCondition), "Condition/Height Above Floor")]
    [CreateFromDataOptions(0, false)]
    [MovedFrom("Unity.MARS")]
    public class HeightAboveFloorCondition : Condition<float>, ICreateFromData
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.HeightAboveFloor };

        [SerializeField]
        float m_IdealHeight = 1.5f;

        [SerializeField]
        float m_RangeFromIdealHeight = 2.0f;

        [SerializeField]
        bool m_RequireInRange;

        /// <summary>
        /// Gets/Sets the "ideal" height from the floor.
        /// </summary>
        public float IdealHeight
        {
            get => m_IdealHeight;
            set => m_IdealHeight = value;
        }

        /// <summary>
        /// Gets/Sets the +/- range from the ideal height.
        /// </summary>
        public float RangeFromIdealHeight
        {
            get => m_RangeFromIdealHeight;
            set => m_RangeFromIdealHeight = value;
        }

        /// <summary>
        /// Gets/Sets the requirement that the height must be within Height +/- RangeFromIdealHeight.
        /// </summary>
        public bool RequireInRange
        {
            get => m_RequireInRange;
            set => m_RequireInRange = value;
        }

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public override float RateDataMatch(ref float height)
        {
            var diff = height - m_IdealHeight;
            var absHeightDiff = diff >= 0 ? diff : -diff; // Abs
            var unitDist = absHeightDiff / m_RangeFromIdealHeight;

            if (m_RequireInRange)
                return unitDist > 1.0f ? 0f : 1.0f - unitDist;

            if (unitDist > 1.0f)
                unitDist = 1.0f;
            // shift distance from 0~1 to 0.0~0.5 range to ensure it succeeds
            unitDist *= 0.5f;
            return 1f - unitDist;
        }

        /// <inheritdoc />
        public void OptimizeForData(TraitDataSnapshot data)
        {
            if (data.TryGetTrait(TraitNames.HeightAboveFloor, out float height))
            {
                m_IdealHeight = height;
            }
        }

        /// <inheritdoc />
        public void IncludeData(TraitDataSnapshot data)
        {
            if (data.TryGetTrait(TraitNames.HeightAboveFloor, out float height))
            {
                var dist = Mathf.Abs(m_IdealHeight - height) * 2.0f;
                if (dist > m_RangeFromIdealHeight)
                {
                    m_RangeFromIdealHeight = dist;
                }
            }
        }

        /// <inheritdoc />
        public string FormatDataString(TraitDataSnapshot data)
        {
            if (!data.TryGetTrait(TraitNames.HeightAboveFloor, out float height))
            {
                height = m_IdealHeight;
            }

            return !m_RequireInRange ? $"~{height:0.00}m" : $"{height:0.00}m +/- {m_RangeFromIdealHeight:0.00}m";
        }

        /// <inheritdoc />
        public float GetConditionRatingForData(TraitDataSnapshot data)
        {
            if (data.TryGetTrait(TraitNames.HeightAboveFloor, out float height))
            {
                var rating = this.RateDataMatch(ref height);
                return rating;
            }

            return 0.0f;
        }
    }
}

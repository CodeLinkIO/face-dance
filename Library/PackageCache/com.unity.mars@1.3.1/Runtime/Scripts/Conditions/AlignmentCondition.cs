using Unity.MARS.Attributes;
using Unity.MARS.Authoring;
using Unity.MARS.Data;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using Unity.XRTools.Utils.GUI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation where a given plane must match a given set of alignments
    /// </summary>
    [HelpURL(DocumentationConstants.AlignmentConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object (a surface) to have the specified alignment (horizontal, vertical, or other).")]
    [MonoBehaviourComponentMenu(typeof(AlignmentCondition), "Condition/Alignment")]
    [CreateFromDataOptions(0, true)]
    [MovedFrom("Unity.MARS")]
    public class AlignmentCondition : Condition<int>, ICreateFromData
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Alignment };

        [FlagsProperty]
        [SerializeField]
        MarsPlaneAlignment m_Alignment = MarsPlaneAlignment.HorizontalUp;

        public MarsPlaneAlignment alignment
        {
            get { return m_Alignment; }
            set { m_Alignment = value; }
        }

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public override float RateDataMatch(ref int data)
        {
            return (data & (int) m_Alignment) != 0 ? 1f : 0f;
        }

        /// <inheritdoc />
        public void OptimizeForData(TraitDataSnapshot data)
        {
            if (data.TryGetTrait(traitName, out int value))
                m_Alignment = (MarsPlaneAlignment)value;
        }

        /// <inheritdoc />
        public void IncludeData(TraitDataSnapshot data)
        {
            if (data.TryGetTrait(traitName, out int value))
                m_Alignment = (MarsPlaneAlignment)(value | (int)m_Alignment);
        }

        /// <inheritdoc />
        public string FormatDataString(TraitDataSnapshot data)
        {
            if (!data.TryGetTrait(traitName, out int value))
                return "Unknown";

            return ((MarsPlaneAlignment)value).ToString().InsertSpacesBetweenWords();

        }

        /// <inheritdoc />
        public float GetConditionRatingForData(TraitDataSnapshot data)
        {
            if (!data.TryGetTrait(traitName, out int value))
                return 0f;

            return RateDataMatch(ref value);
        }
    }
}

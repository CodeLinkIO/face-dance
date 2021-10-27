using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Condition that ensures an entity has both a floor tag and a horizontal alignment
    /// </summary>
    [HelpURL(DocumentationConstants.FlatFloorConditionDocs)]
    [DisallowMultipleComponent]
    [MonoBehaviourComponentMenu(typeof(FlatFloorCondition), "Condition/FlatFloorCondition")]
    [MovedFrom("Unity.MARS")]
    public class FlatFloorCondition : MultiCondition<FlatFloorCondition.FloorTagSubCondition, FlatFloorCondition.HorizontalAlignmentSubCondition>
    {
        [System.Serializable]
        public class FloorTagSubCondition : SubCondition, ISemanticTagCondition
        {
            static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Floor };

            public float RateDataMatch(ref bool data)
            {
                return data ? 1f : 0f;
            }

            public string traitName { get { return k_RequiredTraits[0].TraitName; } }

            public SemanticTagMatchRule matchRule
            {
                get { return SemanticTagMatchRule.Match; }
            }

            /// <inheritdoc />
            public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
        }

        [System.Serializable]
        public class HorizontalAlignmentSubCondition : SubCondition, ICondition<int>
        {
            static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Alignment };

            public string traitName { get { return k_RequiredTraits[0].TraitName; } }

            public float RateDataMatch(ref int data)
            {
                return (data & (int)MarsPlaneAlignment.HorizontalUp) != 0 ? 1f : 0f;
            }

            /// <inheritdoc />
            public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
        }
    }
}

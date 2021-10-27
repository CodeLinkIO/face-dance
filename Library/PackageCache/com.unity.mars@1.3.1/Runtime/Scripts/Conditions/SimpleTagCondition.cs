using Unity.MARS.Attributes;
using Unity.MARS.Authoring;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Base class for any condition that just wants to check the existence for a specific semantic tag
    /// </summary>
    [ComponentTooltip("Requires the object to have a specific trait")]
    [MovedFrom("Unity.MARS")]
    public abstract class SimpleTagCondition : Condition<bool>, ISemanticTagCondition, ICreateFromData
    {
        // tag conditions have binary pass / fail answers
        public override float RateDataMatch(ref bool data)
        {
            return 1.0f;
        }

        public SemanticTagMatchRule matchRule => SemanticTagMatchRule.Match;

        public void OptimizeForData(TraitDataSnapshot data)
        {
            enabled = data.TryGetTrait(traitName, out bool _);
        }

        public void IncludeData(TraitDataSnapshot data)
        {
            enabled = data.TryGetTrait(traitName, out bool _);
        }

        public string FormatDataString(TraitDataSnapshot data)
        {
            if (data.TryGetTrait(traitName, out bool value))
                return $"Tagged {(value ? "" : "not ")}{traitName}";

            return  $"No {traitName} tag";
        }
        public float GetConditionRatingForData(TraitDataSnapshot data)
        {
            return data.TryGetTrait(traitName, out bool value) ? RateDataMatch(ref value) : 0f;
        }
    }
}

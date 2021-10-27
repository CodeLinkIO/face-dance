using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the existence of a pose
    /// </summary>
    [HelpURL(DocumentationConstants.HasPoseConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object to have a pose (position).")]
    [MonoBehaviourComponentMenu(typeof(HasPoseCondition), "Condition/Trait/Pose")]
    [MovedFrom("Unity.MARS")]
    public class HasPoseCondition : Condition<Pose>
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Pose };

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public override float RateDataMatch(ref Pose data)
        {
            return 1.0f;
        }
    }
}

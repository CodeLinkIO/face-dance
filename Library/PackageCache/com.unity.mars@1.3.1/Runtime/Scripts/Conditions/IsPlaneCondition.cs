using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the existence of a plane
    /// </summary>
    [HelpURL(DocumentationConstants.IsPlaneConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object to be a plane.")]
    [MonoBehaviourComponentMenu(typeof(IsPlaneCondition), "Condition/Trait/Plane")]
    [MovedFrom("Unity.MARS")]
    public class IsPlaneCondition : SimpleTagCondition
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Plane };

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
    }
}

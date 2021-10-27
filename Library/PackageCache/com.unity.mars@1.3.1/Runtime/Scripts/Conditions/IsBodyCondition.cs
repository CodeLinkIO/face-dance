using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the existence of a body
    /// </summary>
    [HelpURL(DocumentationConstants.IsBodyConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object to be a body.")]
    [MonoBehaviourComponentMenu(typeof(IsBodyCondition), "Condition/Trait/Body")]
    public class IsBodyCondition : SimpleTagCondition
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Body };

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
    }
}

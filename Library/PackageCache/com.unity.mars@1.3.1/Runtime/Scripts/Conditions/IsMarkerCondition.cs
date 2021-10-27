using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the existence of a marker
    /// </summary>
    [HelpURL(DocumentationConstants.IsMarkerConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object to be a marker.")]
    [MonoBehaviourComponentMenu(typeof(IsMarkerCondition), "Condition/Trait/Marker")]
    [MovedFrom("Unity.MARS")]
    public class IsMarkerCondition : SimpleTagCondition
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Marker };

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
    }
}

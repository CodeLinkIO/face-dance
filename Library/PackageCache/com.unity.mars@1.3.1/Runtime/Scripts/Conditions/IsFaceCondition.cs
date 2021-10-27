using Unity.MARS.Attributes;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the existence of a face
    /// </summary>
    [HelpURL(DocumentationConstants.IsFaceConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the object to be a human face.")]
    [MonoBehaviourComponentMenu(typeof(IsFaceCondition), "Condition/Trait/Face")]
    [MovedFrom("Unity.MARS")]
    public class IsFaceCondition : SimpleTagCondition
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Face };

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }
    }
}

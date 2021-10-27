using System;
using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    [MovedFrom("Unity.MARS")]
    public class TraitRequirement : IEquatable<TraitRequirement>, IEquatable<TraitDefinition>
    {
        /// <summary>
        /// Whether the trait is required for the query to match or Action to function.
        /// If false, this trait is optional, which means it will show up in the
        /// QueryResult only if present for the data that the query matched against.
        /// </summary>
        public readonly bool Required;

        /// <summary>
        /// The definition of the trait
        /// </summary>
        public readonly TraitDefinition Definition;

        /// <summary>
        /// The name of the trait
        /// </summary>
        public string TraitName => Definition.TraitName;

        /// <summary>
        /// The type of the trait's value
        /// </summary>
        public Type Type => Definition.Type;

        public TraitRequirement(string traitName, Type type,  bool required = true)
            : this(new TraitDefinition(traitName, type), required) { }

        public TraitRequirement(TraitDefinition definition, bool required = true)
        {
            Definition = definition;
            Required = required;
        }

        public static TraitRequirement FromSerialized(SerializedTraitRequirement requirement)
        {
            var type = Type.GetType(requirement.TypeName);
            // if we don't find a type, but it's optional, it's ok, but do warn the user.
            if (type == null && requirement.Required)
            {
                if (requirement.Required)
                {
                    Debug.LogErrorFormat("Did not find a Type for required type name {0} - " +
                        "you will get incorrect behavior / errors later!", requirement.TypeName);
                }
                else
                {
                    Debug.LogWarningFormat("Did not find a Type for optionally required type name {0} - " +
                                    "optional Actions that rely on this will not work.", requirement.TypeName);
                }

                return null;
            }

            return new TraitRequirement(requirement.TraitName, type, requirement.Required);
        }

        public static implicit operator TraitDefinition(TraitRequirement requirement) { return requirement.Definition; }

        public static implicit operator TraitRequirement(TraitDefinition definition) { return new TraitRequirement(definition); }

        /// <inheritdoc />
        public bool Equals(TraitRequirement other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Required == other.Required && Definition.Equals(other.Definition);
        }

        /// <inheritdoc />
        public bool Equals(TraitDefinition other)
        {
            if (other == null)
                return false;

            return other.Equals(Definition);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (Required.GetHashCode() * 397) ^ (Definition != null ? Definition.GetHashCode() : 0);
            }
        }

        /// <inheritdoc />
        public override string ToString() { return $"{Definition}, required: {Required}"; }
    }
}

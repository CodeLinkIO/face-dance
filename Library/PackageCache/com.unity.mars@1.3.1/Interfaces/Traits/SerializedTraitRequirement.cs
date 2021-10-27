using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public class SerializedTraitRequirement : IEquatable<SerializedTraitRequirement>
    {
        [SerializeField]
        string m_TraitName;

        [SerializeField]
        string m_TypeName;

        [SerializeField]
        bool m_Required;

        /// <summary>
        /// The name of the trait
        /// </summary>
        public string TraitName => m_TraitName;

        /// <summary>
        /// Whether the trait is required for the query to match or Action to function.
        /// </summary>
        public bool Required => m_Required;

        /// <summary>
        /// The assembly-qualified type name of the trait's value
        /// </summary>
        public string TypeName => m_TypeName;

        public SerializedTraitRequirement() { }

        public SerializedTraitRequirement(string traitName, string assemblyQualifiedTypeName, bool required = true)
        {
            m_TraitName = traitName;
            m_TypeName = assemblyQualifiedTypeName;
            m_Required = required;
        }

        public SerializedTraitRequirement(TraitRequirement requirement)
        {
            m_TraitName = requirement.TraitName;
            m_TypeName = requirement.Type.AssemblyQualifiedName;
            m_Required = requirement.Required;
        }

        /// <inheritdoc />
        public bool Equals(SerializedTraitRequirement other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            // comparison ignores whether it's required, because what we care about
            // is whether it's asking for the same trait of the same type
            return string.Equals(m_TraitName, other.TraitName) && string.Equals(TypeName, other.TypeName);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (TraitName.GetHashCode() * 397) ^ TypeName.GetHashCode();
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"trait: '{TraitName}', type: {TypeName}";
        }
    }
}

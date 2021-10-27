using System;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Base class for MARS Proxy conditions, which provide ratings for Proxy data matches
    /// In most cases, you should inherit from the generic form, Condition&lt;T&gt;
    /// </summary>
    public abstract class Condition : ConditionBase, ICondition
    {
        /// <inheritdoc />
        public string traitName
        {
            get
            {
                var traits = GetRequiredTraits();
                if (traits != null && traits.Length > 0)
                    return traits[0].TraitName;

                const string requiredTraitsFieldName = IRequiresTraitsMethods.StaticRequiredTraitsFieldName;
                Debug.LogError(
                    $"{GetType().Name}.GetRequiredTraits() must return at least one TraitRequirement. The first one defines " +
                     "the trait this Condition tests against, and any after that define an additional requirement for the simple presence of a trait." +
                    $" Your implementation of GetRequiredTraits() must return the field {requiredTraitsFieldName}.");

                return "";
            }
        }

        /// <inheritdoc />
        public abstract TraitRequirement[] GetRequiredTraits();
    }

    /// <summary>
    /// Generic form of Condition, which provides the RateDataMatch method
    /// </summary>
    /// <typeparam name="T">The type of data this condition will be rating</typeparam>
    public abstract class Condition<T> : Condition, ICondition<T>
    {
        /// <inheritdoc />
        public abstract float RateDataMatch(ref T data);
    }
}

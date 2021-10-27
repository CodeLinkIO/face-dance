using Unity.MARS.Authoring;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Base class for MARS Proxy Relations, which combine multiple data sources into a rating for ProxyGroups
    /// In most cases, you should inherit from the generic form, Relation&lt;T&gt;
    /// </summary>
    public abstract class Relation : RelationBase, IRelation
    {
        /// <summary>
        /// The trait to test against for the first child
        /// </summary>
        public string child1TraitName
        {
            get
            {
                var traits = GetRequiredTraits();
                if (traits != null && traits.Length == 2)
                    return traits[0].TraitName;

                LogRequiredTraitsError();
                return "";
            }
        }

        /// <summary>
        /// The trait to test against for the second child
        /// </summary>
        public string child2TraitName
        {
            get
            {
                var traits = GetRequiredTraits();
                if (traits != null && traits.Length == 2)
                    return traits[1].TraitName;

                LogRequiredTraitsError();
                return "";
            }
        }

        /// <inheritdoc />
        public abstract TraitRequirement[] GetRequiredTraits();

        void LogRequiredTraitsError()
        {
            const string requiredTraitsFieldName = IRequiresTraitsMethods.StaticRequiredTraitsFieldName;
            Debug.LogError(
                $"{GetType().Name}.GetRequiredTraits() must return exactly two TraitRequirements - the first " +
                "defines the trait for the Relation's first child, and the second defines the trait for the second child. " +
                $"Your implementation of GetRequiredTraits() must return the field {requiredTraitsFieldName}. " +
                "ConditionsAnalyzer should check that this field contains exactly two TraitRequirements.");
        }
    }

    /// <summary>
    /// Generic form of Relation, which provides RateDataMatch and other methods
    /// </summary>
    /// <typeparam name="T">The type of data this relation will be rating</typeparam>
    public abstract class Relation<T> : Relation, IRelation<T>, ICreateFromDataPair
    {
        /// <inheritdoc />
        public abstract float RateDataMatch(ref T child1Data, ref T child2Data);

        /// <inheritdoc />
        public virtual void OptimizeForData(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data) { }

        /// <inheritdoc />
        public virtual void ConformToData(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data) { }

        /// <inheritdoc />
        public virtual string FormatDataString(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data) { return $"{child1Data} {child2Data}"; }
    }
}

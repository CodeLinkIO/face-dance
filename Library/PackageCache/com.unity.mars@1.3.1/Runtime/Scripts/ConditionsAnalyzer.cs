using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS.Query
{
    [MovedFrom("Unity.MARS")]
    public static class ConditionsAnalyzer
    {
        static readonly Dictionary<string, List<Type>> k_ConditionTypesForTraits = new Dictionary<string, List<Type>>();
        static readonly Dictionary<string, List<Type>> k_RelationTypesForChild1Traits = new Dictionary<string, List<Type>>();
        static readonly Dictionary<string, List<Type>> k_RelationTypesForChild2Traits = new Dictionary<string, List<Type>>();

        /// <summary>
        /// Finds types of conditions that test against a given trait
        /// </summary>
        /// <param name="traitName">Name of the trait that conditions must test against</param>
        /// <param name="conditionTypes">List that will be filled out with types of conditions that use the trait</param>
        /// <returns>True if any condition types were found, false otherwise</returns>
        public static bool GetConditionTypesForTrait(string traitName, List<Type> conditionTypes)
        {
            if (!k_ConditionTypesForTraits.TryGetValue(traitName, out var types))
                return false;

            conditionTypes.AddRange(types);
            return true;
        }

        /// <summary>
        /// Finds types of relations that test against a given trait for their first child
        /// </summary>
        /// <param name="traitName">Name of the trait that relations must test against for their first child</param>
        /// <param name="relationTypes">List that will be filled out with types of relations that use the trait</param>
        /// <returns>True if any relation types were found, false otherwise</returns>
        public static bool GetRelationTypesForChild1Trait(string traitName, List<Type> relationTypes)
        {
            if (!k_RelationTypesForChild1Traits.TryGetValue(traitName, out var types))
                return false;

            relationTypes.AddRange(types);
            return true;
        }

        /// <summary>
        /// Finds types of relations that test against a given trait for their second child
        /// </summary>
        /// <param name="traitName">Name of the trait that relations must test against for their second child</param>
        /// <param name="relationTypes">List that will be filled out with types of relations that use the trait</param>
        /// <returns>True if any relation types were found, false otherwise</returns>
        public static bool GetRelationTypesForChild2Trait(string traitName, List<Type> relationTypes)
        {
            if (!k_RelationTypesForChild2Traits.TryGetValue(traitName, out var types))
                return false;

            relationTypes.AddRange(types);
            return true;
        }

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#endif
        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            CheckConditionTypes();
            CheckRelationTypes();
        }

        static void CheckConditionTypes()
        {
            k_ConditionTypesForTraits.Clear();

            // Semantic tag conditions have variable trait requirements, so we don't include them in the mapping
            var conditionTypes = new List<Type>();
            typeof(Condition).GetAssignableTypes(conditionTypes,
                type => !type.Assembly.FullName.Contains("Tests") && type != typeof(SemanticTagCondition));

            foreach (var conditionType in conditionTypes)
            {
                var requiredTraitsField = TryGetRequiredTraitsField(conditionType);
                if (requiredTraitsField == null) // No need to log an error here since IRequiresTraitAnalyzer will catch this
                    continue;

                var requiredTraits = (TraitRequirement[])requiredTraitsField.GetValue(null);

#if UNITY_EDITOR
                if (!CheckConditionRequirements(conditionType, requiredTraits))
                    continue;
#endif

                var traitName = requiredTraits[0].TraitName;
                if (k_ConditionTypesForTraits.TryGetValue(traitName, out var conditionTypesForTrait))
                    conditionTypesForTrait.Add(conditionType);
                else
                    k_ConditionTypesForTraits[traitName] = new List<Type> { conditionType };
            }
        }

        static void CheckRelationTypes()
        {
            k_RelationTypesForChild1Traits.Clear();
            k_RelationTypesForChild2Traits.Clear();

            var relationTypes = new List<Type>();
            typeof(Relation).GetAssignableTypes(relationTypes, type => !type.Assembly.FullName.Contains("Tests"));

            foreach (var relationType in relationTypes)
            {
                var requiredTraitsField = TryGetRequiredTraitsField(relationType);
                if (requiredTraitsField == null) // No need to log an error here since IRequiresTraitAnalyzer will catch this
                    continue;

                var requiredTraits = (TraitRequirement[])requiredTraitsField.GetValue(null);

#if UNITY_EDITOR
                if (!CheckRelationRequirements(relationType, requiredTraits))
                    continue;
#endif

                var child1TraitName = requiredTraits[0].TraitName;
                if (k_RelationTypesForChild1Traits.TryGetValue(child1TraitName, out var relationTypesForChild1Trait))
                    relationTypesForChild1Trait.Add(relationType);
                else
                    k_RelationTypesForChild1Traits[child1TraitName] = new List<Type> { relationType };

                var child2TraitName = requiredTraits[1].TraitName;
                if (k_RelationTypesForChild2Traits.TryGetValue(child2TraitName, out var relationTypesForChild2Trait))
                    relationTypesForChild2Trait.Add(relationType);
                else
                    k_RelationTypesForChild2Traits[child2TraitName] = new List<Type> { relationType };
            }
        }

        static FieldInfo TryGetRequiredTraitsField(Type type)
        {
            var requiredTraitsField = type.GetField(
                IRequiresTraitsMethods.StaticRequiredTraitsFieldName,
                IRequiresTraitsMethods.StaticRequiredTraitsBindingFlags);

            if (requiredTraitsField == null)
                return null;

            return typeof(TraitRequirement[]).IsAssignableFrom(requiredTraitsField.FieldType) ? requiredTraitsField : null;
        }

#if UNITY_EDITOR
        static bool CheckConditionRequirements(Type conditionType, TraitRequirement[] requiredTraits)
        {
            if (requiredTraits != null && requiredTraits.Length >= 1)
                return true;

            Debug.LogErrorFormat("Condition {0} must have at least one TraitRequirement in {1}",
                conditionType.Name, IRequiresTraitsMethods.StaticRequiredTraitsFieldName);

            return false;

        }

        static bool CheckRelationRequirements(Type relationType, TraitRequirement[] requiredTraits)
        {
            if (requiredTraits != null && requiredTraits.Length == 2)
                return true;

            Debug.LogErrorFormat("Relation {0} must have exactly two TraitRequirements in {1}. {1}[0] must be the trait " +
                                 "for child 1 and {1}[1] must be the trait for child 2.",
                relationType.Name, IRequiresTraitsMethods.StaticRequiredTraitsFieldName);

            return false;
        }
#endif
    }
}

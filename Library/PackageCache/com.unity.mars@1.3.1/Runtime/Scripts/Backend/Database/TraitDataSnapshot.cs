using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Authoring;
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [MovedFrom("Unity.MARS")]
    public partial class TraitDataSnapshot
    {
        const string k_CodeGenWarningMessage = "This method exists in order for MARS to compile before type-specific code is generated. " +
            "Make sure generated files have been created properly and use the overloads of this method";
        public int DataID { get; private set; }

        public void TakeSnapshot(object queryResult)
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
        }

        public void GetTraits<TKey, TValue>(out Dictionary<TKey, TValue> traits)
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
            traits = default;
        }

        public bool TryGetTrait(string traitName, out object value)
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
            value = default;
            return false;
        }

        public bool TryGetTrait<T>(string traitName, out T value)
            where T : struct
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
            value = default;
            return false;
        }

        public void GetPotentialConditions(object results, GameObject gameObject)
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
        }

        public void GetPotentialTags(List<PotentialCondition> results, GameObject gameObject)
        {
            GetTraits(out Dictionary<string, bool> boolTraits);
            foreach (var tagTrait in boolTraits)
            {
                if (tagTrait.Value == false)
                    continue;

                var potentialTag = new PotentialTagCondition
                {
                    order = 0,
                    gameObjectOwner = gameObject,
                    componentType = typeof(SemanticTagCondition),
                    tagName = tagTrait.Key,
                    use = true
                };

                potentialTag.UpdateComponent();
                results.Add(potentialTag);
            }
        }

        public static void GetPotentialRelations(List<PotentialChild> groupMembers, List<PotentialRelation> results, GameObject gameObject)
        {
            var childRelationTypes = new List<Type>[2];
            var traitData = new TraitDataSnapshot[2];

            // For each group member, find all relations where the relevant group member has the necessary trait
            for (var i = 0; i < 2; i++)
            {
                traitData[i] = new TraitDataSnapshot();
                childRelationTypes[i] = new List<Type>();
                traitData[i].TakeSnapshot(groupMembers[i].sourceObject.currentData);
                traitData[i].CollectPotentialRelations(childRelationTypes, i);
            }

            // Take the intersection of relations that could act on child 1 and also child 2
            // Then create a potential relation object for each relation type
            var validRelationTypes = childRelationTypes[0].Intersect(childRelationTypes[1]);
            foreach (var relationType in validRelationTypes)
            {
                if (!relationType.IsDefined(typeof(CreateFromDataOptions), true))
                    continue;

                var options = relationType.GetAttribute<CreateFromDataOptions>(true);
                var potentialRelation = new PotentialRelation
                {
                    componentType = relationType,
                    gameObjectOwner = gameObject,
                    traits1 = traitData[0],
                    traits2 = traitData[1],
                    use = options.AddByDefault,
                    order = options.Order
                };
                potentialRelation.UpdateComponent();
                results.Add(potentialRelation);
            }
        }

        void CollectPotentialConditions<T>(Dictionary<string, T> traitCollection, List<PotentialCondition> results, GameObject gameObject)
        {
            foreach (var trait in traitCollection)
            {
                var types = new List<Type>();
                ConditionsAnalyzer.GetConditionTypesForTrait(trait.Key, types);
                foreach (var conditionType in types)
                {
                    if (!conditionType.IsDefined(typeof(CreateFromDataOptions), true))
                        continue;

                    var options = conditionType.GetAttribute<CreateFromDataOptions>(true);
                    var potentialCondition = new PotentialCondition
                    {
                        componentType = conditionType,
                        data = this,
                        gameObjectOwner = gameObject,
                        createdComponent = gameObject.GetComponent(conditionType),
                        use = options.AddByDefault,
                        order = options.Order
                    };

                    potentialCondition.UpdateComponent();
                    results.Add(potentialCondition);
                }
            }
        }

        void CollectPotentialRelations(object childRelationTypes, int index)
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
        }

        static void CollectPotentialRelationsOfType<T>(Dictionary<string, T> collection, List<Type> resultTypes, int index)
        {
            foreach (var traitValue in collection)
            {
                var trait = traitValue.Key;
                switch (index) {
                    case 0:
                        ConditionsAnalyzer.GetRelationTypesForChild1Trait(trait, resultTypes);
                        break;
                    case 1:
                        ConditionsAnalyzer.GetRelationTypesForChild2Trait(trait, resultTypes);
                        break;
                }
            }
        }

        public void GetAllTraitNames(object results)
        {
            Debug.LogWarning(k_CodeGenWarningMessage);
        }
    }
}

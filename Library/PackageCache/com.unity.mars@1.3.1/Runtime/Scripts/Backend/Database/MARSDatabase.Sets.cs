using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data
{
    public partial class MARSDatabase
    {
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<IMRObject> k_ChildrenList = new List<IMRObject>();

        static void FillRelationChildResults<T>(MARSTraitDataProvider<T> traitProvider,
            Dictionary<IMRObject, QueryResult> childResults, Dictionary<IMRObject, int> dataAssignments,
            IRelation<T>[] typeRelations)
        {
            foreach (var relation in typeRelations)
            {
                var child1 = relation.child1;
                if (childResults.TryGetValue(child1, out var child1Result))
                {
                    var trait1Name = relation.child1TraitName;
                    traitProvider.TryGetTraitValue(dataAssignments[child1], trait1Name, out var value1);
                    child1Result.SetTrait(trait1Name, value1);
                }

                var child2 = relation.child2;
                if (childResults.TryGetValue(child2, out var child2Result))
                {
                    var trait2Name = relation.child2TraitName;
                    traitProvider.TryGetTraitValue(dataAssignments[child2], trait2Name, out var value2);
                    child2Result.SetTrait(trait2Name, value2);
                }
            }
        }
        
        public bool TryUpdateSetQueryMatchData(SetMatchData data,
            Relations relations, SetQueryResult result, bool failOnNonRequiredChildren = false)
        {
            var dataAssignments = data.dataAssignments;
            // if data assignments are empty, this means all the group members have been unmatched,
            // so we return false to indicate that the update has failed
            if (dataAssignments.Count == 0)
                return false;
            
            var childResults = result.childResults;
            var nonRequiredChildrenLost = result.nonRequiredChildrenLost;

            // Non-required children lost in previous updates should not have results.
            k_ChildrenList.Clear();
            k_ChildrenList.AddRange(childResults.Keys);
            foreach (var child in k_ChildrenList)
            {
                if (!dataAssignments.ContainsKey(child))
                    childResults.Remove(child);
            }

            nonRequiredChildrenLost.Clear();

            // First check ordinary conditions.
            var children = relations.children;
            foreach (var kvp in dataAssignments)
            {
                var child = kvp.Key;
                var args = children[child];
                var childResult = childResults[child];
                if (!TryUpdateQueryMatchData(dataAssignments[child], args.tryBestMatchArgs.conditions, args.TraitRequirements, childResult))
                {
                    if (args.required || failOnNonRequiredChildren)
                        return false;

                    nonRequiredChildrenLost.Add(child);
                    childResult.SetDataId((int) ReservedDataIDs.Invalid);
                }
            }

            if (!DataStillMatches(dataAssignments, relations, children, nonRequiredChildrenLost))
                return false;

            // Child results already contain the traits used for the ordinary relations,
            // now we just have to add the ones used for relations.
            FillRelationTraits(dataAssignments, relations, childResults);

            // as long as Poses need offsetting before output, they have to be special-cased
            if (relations.TryGetType(out IRelation<Pose>[] poseRelations) && poseRelations.Length > 0)
            {
                GetTraitProvider(out MARSTraitDataProvider<Pose> poseProvider);
                foreach (var relation in poseRelations)
                {
                    var child1 = relation.child1;
                    if (childResults.TryGetValue(child1, out var child1Result))
                    {
                        var trait1Name = relation.child1TraitName;
                        poseProvider.TryGetTraitValue(dataAssignments[child1], trait1Name, out var value1);
                        child1Result.SetTrait(trait1Name, this.ApplyOffsetToPose(value1));
                    }

                    var child2 = relation.child2;
                    if (childResults.TryGetValue(child2, out var child2Result))
                    {
                        var trait2Name = relation.child2TraitName;
                        poseProvider.TryGetTraitValue(dataAssignments[child2], trait2Name, out var value2);
                        child2Result.SetTrait(trait2Name, this.ApplyOffsetToPose(value2));
                    }
                }
            }

            return true;
        }
        
        // this function is used by generated code
        static bool CheckIfDataStillMatches<T>(Dictionary<IMRObject, int> dataAssignments,
            IRelation<T>[] relations, MARSTraitDataProvider<T> traitProvider,
            Dictionary<IMRObject, SetChildArgs> children, HashSet<IMRObject> nonRequiredChildrenLost)
        {
            foreach (var relation in relations)
            {

                var child1 = relation.child1;
                var child2 = relation.child2;

                // If a child is not in dataAssignments then it is a non-required child that was lost in a previous update,
                // and there's no need to check this relation.
                if (!dataAssignments.TryGetValue(child1, out var dataID1) || !dataAssignments.TryGetValue(child2, out var dataID2))
                    continue;

                var child1Required = children[child1].required;
                var child2Required = children[child2].required;
                var trait1Name = relation.child1TraitName;
                var trait2Name = relation.child2TraitName;
                var trait1Exists = traitProvider.TryGetTraitValue(dataID1, trait1Name, out var trait1Value);
                var trait2Exists = traitProvider.TryGetTraitValue(dataID2, trait2Name, out var trait2Value);

                if (!trait1Exists)
                {
                    if (child1Required)
                        return false;

                    nonRequiredChildrenLost.Add(child1);
                }

                if (!trait2Exists)
                {
                    if (child2Required)
                        return false;

                    nonRequiredChildrenLost.Add(child2);
                }

                if (trait1Exists && trait2Exists && !relation.PassesRelation(ref trait1Value, ref trait2Value))
                {
                    if (child1Required && child2Required)
                        return false;

                    if (!child1Required)
                        nonRequiredChildrenLost.Add(child1);

                    if (!child2Required)
                        nonRequiredChildrenLost.Add(child2);
                }
            }
            return true;
        }

        internal void CacheTraitReferences(List<int> indexes, List<int> filteredIndexes,
            Relations[] relations,
            ref RelationTraitCache[] references)
        {
            filteredIndexes.Clear();
            foreach (var i in indexes)
            {
                var foundTraitCollections = references[i];
                // this shouldn't happen, but has been seen in really extreme cases of toggling data and proxies on and off.
                if (foundTraitCollections == null)
                    continue;
                
                if (foundTraitCollections.Fulfilled)
                {
                    if (foundTraitCollections.CheckForDestroyedCollections())
                    {
                        foundTraitCollections.Fulfilled = false;
                        if (!FindTraitCollections(relations[i], foundTraitCollections))
                            continue;
                    }

                    filteredIndexes.Add(i);
                    continue;
                }

                // if we find all the traits we're looking for, mark this query's reference cache as fulfilled
                if (FindTraitCollections(relations[i], foundTraitCollections))
                    filteredIndexes.Add(i);
            }
        }

        bool FindTraitCollections(Relations relations, RelationTraitCache cache)
        {
            cache.Fulfilled = FindRelationTraits(relations, cache);
            return cache.Fulfilled;
        }

        // ReSharper disable once UnusedMember.Global
        internal bool FindRelationTraits(object relations, object traitCache) { return false; }

        static bool FindTraitCollections<T>(MARSTraitDataProvider<T> traitProvider,
            IRelation<T>[] conditions,
            List<RelationTraitCache.ChildTraits<T>> traitCollections)
        {
            traitCollections.Clear();
            foreach (var condition in conditions)
            {
                if (!traitProvider.TryGetAllTraitValues(condition.child1TraitName, out var traits))
                    return false;

                if (!traitProvider.TryGetAllTraitValues(condition.child2TraitName, out var traits2))
                    return false;

                traitCollections.Add(new RelationTraitCache.ChildTraits<T>()
                {
                    One = traits,
                    Two = traits2
                });
            }

            return true;
        }

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        bool DataStillMatches(object dataAssignments, object relations, object children, object nonRequiredChildrenLost)
        {
            return false;
        }

        void FillRelationTraits(object dataAssignments, object relations, object childResults) { }

        // ReSharper restore UnusedParameter.Local
        // ReSharper restore UnusedMember.Local
    }
}

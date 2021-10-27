using System;
using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Rates possible combination of data that would fulfill each Relation in each Set.
    /// </summary>
    partial class RelationRatingTransform : DataTransform<List<int>,
        RelationDataPair[][],
        Relations[],
        RelationTraitCache[],
        Dictionary<int, float>[],
        RelationRatingsData[]>
    {
        public static int CurrentRelationPairIndex;

        public RelationRatingTransform() { Process = ProcessStage; }

        static void ProcessStage(List<int> workingIndices, List<int> filteredIndices,
            RelationDataPair[][] relationIndexPairs,
            Relations[] relations,
            RelationTraitCache[] traitCaches,
            Dictionary<int, float>[] memberRatings,
            ref RelationRatingsData[] relationRatings)
        {
            foreach (var i in workingIndices)
            {
                if(TryMatchAll(relations[i], traitCaches[i], relationRatings[i], memberRatings, relationIndexPairs[i]))
                    filteredIndices.Add(i);
            }
        }

        /// <summary>
        /// Try to find matches for all Relations in a Set.
        /// </summary>
        /// <param name="relations">All relations in the set</param>
        /// <param name="traits">References to the trait values used by all relations</param>
        /// <param name="ratingData">Output list of dictionaries</param>
        /// <param name="memberRatings">The collection of all member ratings</param>
        /// <param name="relationPairs">The relation index pairs for this Set</param>
        /// <returns>True if all relations found at least 1 match, false otherwise</returns>
        public static bool TryMatchAll(Relations relations,
            RelationTraitCache traits,
            RelationRatingsData ratingData,
            Dictionary<int, float>[] memberRatings,
            RelationDataPair[] relationPairs)
        {
            CurrentRelationPairIndex = 0;
            foreach (var dictionary in ratingData)
            {
                dictionary.Clear();
            }

            return TryMatchAllInternal(relations, traits, ratingData, memberRatings, relationPairs);
        }

        /// <summary>
        /// Rate all relations of a type in a set
        /// </summary>
        /// <param name="relations">All relations of the data type in the set</param>
        /// <param name="traits">References to the trait values used by the relation members</param>
        /// <param name="relationIndexPairs">Indices for members of each Relation in relations</param>
        /// <param name="memberRatings"></param>
        /// <param name="relationRatings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>True if all relations found at least 1 match, false otherwise</returns>
        public static bool RateMatches<T>(IRelation<T>[] relations,
            List<RelationTraitCache.ChildTraits<T>> traits,
            RelationDataPair[] relationIndexPairs,
            Dictionary<int, float>[] memberRatings,
            List<Dictionary<RelationDataPair, float>> relationRatings)
        {
            for (var i = 0; i < relations.Length; i++)
            {
                var relationRating = relationRatings[CurrentRelationPairIndex];
                var childIndexPair = relationIndexPairs[CurrentRelationPairIndex];
                var child1Ratings = memberRatings[childIndexPair.Child1];
                var child2Ratings = memberRatings[childIndexPair.Child2];
                var relation = relations[i];
                var trait = traits[i];

                if (!RateMatches(relation, trait, child1Ratings, child2Ratings, relationRating))
                    return false;

                CurrentRelationPairIndex++;
            }

            return true;
        }

        /// <summary>
        /// Rate all possible matches for a single relation
        /// </summary>
        /// <param name="relation">The relation to find matches for</param>
        /// <param name="traits">References to the trait values used by relations</param>
        /// <param name="member1Ratings">Match ratings for the first member</param>
        /// <param name="member2Ratings">Match ratings for the second member</param>
        /// <param name="relationRatings">Output mapping of data pair to match rating</param>
        /// <typeparam name="T">The data type the Relation uses</typeparam>
        /// <returns>True if any matches were found, false otherwise</returns>
        public static bool RateMatches<T>(IRelation<T> relation,
            RelationTraitCache.ChildTraits<T> traits,
            Dictionary<int, float> member1Ratings,
            Dictionary<int, float> member2Ratings,
            Dictionary<RelationDataPair, float> relationRatings)
        {
            relationRatings.Clear();
            var child1TraitValues = traits.One;
            var child2TraitValues = traits.Two;

            foreach (var id1 in member1Ratings.Keys)
            {
                if (!child1TraitValues.TryGetValue(id1, out var value1))
                    continue;

                foreach (var id2 in member2Ratings.Keys)
                {
                    // matches for each child must have different IDs
                    if (id2 == id1)
                        continue;

                    // Both members must have the trait value present
                    if (!child2TraitValues.TryGetValue(id2, out var value2))
                        continue;

                    var relationRating = relation.RateDataMatch(ref value1, ref value2);
                    // if these two pieces of data did not match this relation, they cannot be used
                    if (relationRating <= 0f)
                        continue;

                    relationRatings.Add(new RelationDataPair(id1, id2), relationRating);
                }
            }

            return relationRatings.Count > 0;
        }

        // functions below here are stubs for before code generation runs
        // ReSharper disable once UnusedMember.Local
        static bool TryMatchAllInternal(object relations, object traits, object ratingData,
            object memberRatings, RelationDataPair[] relationPairs)
        {
            return false;
        }
    }

    class RelationRatingStage : QueryStage<RelationRatingTransform>
    {
        public RelationRatingStage(RelationRatingTransform transformation)
            : base("Relation Match Rating", transformation)
        {
        }
    }
}

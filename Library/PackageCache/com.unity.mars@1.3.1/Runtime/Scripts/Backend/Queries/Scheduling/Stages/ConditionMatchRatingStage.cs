using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    partial class MatchRatingDataTransform : DataTransform<
        ProxyConditions[],
        CachedTraitCollection[],
        ConditionRatingsData[]>
    {
        readonly List<int> m_IndicesToFilter = new List<int>();

        public MatchRatingDataTransform()
        {
            Process = Processor;
        }

        void Processor(List<int> indices, ProxyConditions[] conditions,
            CachedTraitCollection[] references, ref ConditionRatingsData[] ratings)
        {
            m_IndicesToFilter.Clear();
            foreach (var i in indices)
            {
                if(!RateConditionMatches(conditions[i], references[i], ratings[i]))
                    m_IndicesToFilter.Add(i);
            }

            foreach (var filteredIndex in m_IndicesToFilter)
            {
                indices.Remove(filteredIndex);
            }
        }

        internal static bool RateConditionMatches(ProxyConditions conditions, CachedTraitCollection traitCache,
            ConditionRatingsData resultData)
        {
            if (conditions.Count <= 0)
                return false;

            conditions.TryGetType(out ISemanticTagCondition[] semanticTagConditions);
            traitCache.TryGetType(out List<Dictionary<int, bool>> semanticTagTraits);

            var semanticTagsMatched = RateSemanticTagConditionMatches(semanticTagConditions,
                semanticTagTraits, resultData[typeof(bool)], resultData.MatchRuleIndexes);

            return semanticTagsMatched && RateConditionMatchesInternal(conditions, traitCache, resultData);
        }

        internal static bool RateConditionMatches<T>(ICondition<T>[] typeConditions, List<Dictionary<int, T>> traitCollections,
            List<Dictionary<int, float>> preAllocatedRatingStorage)
        {
            for (var i = 0; i < typeConditions.Length; i++)
            {
                var condition = typeConditions[i];
                var traits = traitCollections[i];
                var ratings = preAllocatedRatingStorage[i];
                ratings.Clear();
                foreach (var kvp in traits)
                {
                    var value = kvp.Value;
                    var rating = condition.RateDataMatch(ref value);
                    // exclude all failing pieces of data from the results list
                    if (rating <= 0f)
                        continue;

                    ratings.Add(kvp.Key, rating);
                }

                if (ratings.Count == 0)        // trait found, but no matches
                    return false;
            }

            return true;
        }

        internal static bool RateSemanticTagConditionMatches(ISemanticTagCondition[] conditions, List<Dictionary<int, bool>> traitCollections,
            List<Dictionary<int, float>> preAllocatedRatingStorage, List<SemanticTagMatchRule> matchRuleIndexes)
        {
            if (conditions == null)
                return true;

            matchRuleIndexes.Clear();
            for (var i = 0; i < conditions.Length; i++)
            {
                var condition = conditions[i];
                matchRuleIndexes.Add(condition.matchRule);
                var isExcluding = condition.matchRule == SemanticTagMatchRule.Exclude;

                var traits = traitCollections[i];
                // If this condition is excluding a trait, and that trait isn't found, it passes.
                if (traits == null)
                {
                    if (isExcluding)
                        continue;

                    return false;
                }

                var ratings = preAllocatedRatingStorage[i];
                ratings.Clear();
                foreach (var kvp in traits)
                {
                    var id = kvp.Key;
                    var value = kvp.Value;
                    var rating = condition.RateDataMatch(ref value);
                    if(rating > 0f)
                        ratings.Add(id, rating);
                }

                // trait found, but no matches
                if (ratings.Count == 0 && !isExcluding)
                    return false;
            }

            return true;
        }

        internal bool DataIdPassesAll(ProxyConditions conditions, CachedTraitCollection traitCache, int dataId)
        {
            conditions.TryGetType(out ISemanticTagCondition[] semanticTagConditions);
            traitCache.TryGetType(out List<Dictionary<int, bool>> semanticTagTraits);

            for (var i = 0; i < semanticTagConditions.Length; i++)
            {
                var tagCondition = semanticTagConditions[i];
                var tagTraitCollection = semanticTagTraits[i];

                if (!tagTraitCollection.TryGetValue(dataId, out var traitValue))
                {
                    switch (tagCondition.matchRule)
                    {
                        case SemanticTagMatchRule.Exclude:
                            continue;
                        case SemanticTagMatchRule.Match:
                            return false;
                    }
                }

                var rating = tagCondition.RateDataMatch(ref traitValue);

                switch (tagCondition.matchRule)
                {
                    case SemanticTagMatchRule.Exclude:
                        if (rating > 0f)
                            return false;

                        break;
                    case SemanticTagMatchRule.Match:
                        if (rating <= 0f)
                            return false;

                        break;
                }
            }

            return DataPassesAllConditionsInternal(traitCache, dataId);
        }

        static bool IdMatchesTypeConditions<T>(ICondition<T>[] typeConditions, List<Dictionary<int, T>> traitCollections, int dataId)
        {
            for (var i = 0; i < typeConditions.Length; i++)
            {
                var traitCollection = traitCollections[i];
                if (!traitCollection.TryGetValue(dataId, out var traitValue))
                    return false;

                var condition = typeConditions[i];
                if (condition.RateDataMatch(ref traitValue) <= 0f)
                    return false;
            }

            return true;
        }

        // ReSharper disable once UnusedMember.Local
        bool DataPassesAllConditionsInternal(object traitCache, object dataId) { return false; }

        // ReSharper disable once UnusedMember.Local
        static bool RateConditionMatchesInternal(object conditions, object traits, object results) { return false; }
    }

    class ConditionMatchRatingStage : QueryStage<MatchRatingDataTransform>
    {
        public ConditionMatchRatingStage(MatchRatingDataTransform transformation, int frameBudget = 1)
            : base("Condition Match Rating", transformation)
        {
        }
    }
}

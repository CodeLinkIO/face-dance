using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    partial class FindMatchProposalsTransform : DataTransform<List<int>,
        ConditionRatingsData[],
        HashSet<int>[]>
    {
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly HashSet<int> k_IDsMatchingCondition = new HashSet<int>();

        public FindMatchProposalsTransform() : base(FindConditionIntersectionStage) { }

        internal static void FindConditionIntersectionStage(List<int> indices, List<int> filteredIndices,
            ConditionRatingsData[] input, ref HashSet<int>[] output)
        {
            filteredIndices.Clear();
            foreach (var i in indices)
            {
                // if we find a match, add this query to our working set for the next step
                if(Execute(input[i], output[i]))
                {
                    filteredIndices.Add(i);
                }
            }
        }

        internal static bool Execute(ConditionRatingsData ratings, HashSet<int> matchSet)
        {
            GetStartingIdSet(ratings, matchSet);
            return FindQueryCandidateIntersection(ratings, matchSet);
        }

        static bool FindQueryCandidateIntersection(ConditionRatingsData data, HashSet<int> matchSet)
        {
            // semantic tags need special handling because of tag exclusion - all other types are in generated code
            k_IDsMatchingCondition.Clear();
            var tagRatingIndex = 0;
            var tagRatings = data[typeof(bool)];
            if (tagRatings != null)
            {
                foreach(var dictionary in tagRatings)
                {
                    k_IDsMatchingCondition.Clear();
                    if (data.MatchRuleIndexes[tagRatingIndex] == SemanticTagMatchRule.Exclude)
                    {
                        // exclusive tags fill out a list of what should be excluded, not included
                        foreach (var kvp in dictionary)
                        {
                            var id = kvp.Key;
                            matchSet.Remove(id);
                        }
                    }
                    else
                    {
                        foreach (var kvp in dictionary)
                        {
                            k_IDsMatchingCondition.Add(kvp.Key);
                        }

                        matchSet.IntersectWith(k_IDsMatchingCondition);
                    }

                    tagRatingIndex++;
                }
            }

            return matchSet.Count != 0 && FindIntersection(data, matchSet);
        }

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        internal static void GetStartingIdSet(object ratings, object matchSet) { }

        static bool FindIntersection(object conditionRatingsData, object matchSet) { return false; }
        // ReSharper restore UnusedMember.Local
        // ReSharper restore UnusedParameter.Local
    }

    class FindMatchProposalsStage : QueryStage<FindMatchProposalsTransform>
    {
        public FindMatchProposalsStage(FindMatchProposalsTransform transformation)
            : base("Condition Match Intersection", transformation)
        {
        }
    }
}

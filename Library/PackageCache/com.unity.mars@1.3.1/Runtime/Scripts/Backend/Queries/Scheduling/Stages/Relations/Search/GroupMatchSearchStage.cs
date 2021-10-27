using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.MARS.Data;
using UnityEngine;

namespace Unity.MARS.Query
{
    enum TieChoiceBehavior : byte
    {
        /// <summary>Choose the first tie for best match</summary>
        First,
        /// <summary>Choose randomly among all the ties for best match</summary>
        Random
    }

    class GroupMatchSearchTransform : DataTransform<List<int>,
        int[][],
        RelationDataPair[][],
        RelationRatingsData[],
        float[],
        GroupSearchData[],
        RelationMembership[][],
        Exclusivity[],
        Dictionary<int, float>[],
        int[]>
    {
        struct SolveSortData
        {
            public int GroupIndex;
            public sbyte Priority;
            public float SolveWeight;
        }

        class SolveOrderComparer : IComparer<SolveSortData>
        {
            public int Compare(SolveSortData x, SolveSortData y)
            {
                // sort by priority first
                if (x.Priority < y.Priority)
                    return 1;
                if(x.Priority > y.Priority)
                    return -1;

                // if equal priority, sort by solve order
                if (x.SolveWeight < y.SolveWeight)
                    return 1;

                return x.SolveWeight > y.SolveWeight ? -1 : 0;
            }
        }

        const int k_InitialCollectionCapacity = 16;

        static readonly SolveOrderComparer k_Comparer = new SolveOrderComparer();
        static readonly List<SolveSortData> k_SolveOrderList = new List<SolveSortData>();

        readonly List<KeyValuePair<int, float>> m_AllOrderPairs = new List<KeyValuePair<int, float>>(k_InitialCollectionCapacity);

        RatingMetaEnumerator m_MetaEnumerator;

        Dictionary<int, int> m_MemberAssignments = new Dictionary<int, int>(k_InitialCollectionCapacity);

        /// <summary>
        /// Entries in this array from 0 to tieCount are rating matches that tied for the highest score
        /// </summary>
        int[] m_RatingTieIndices = new int[k_InitialCollectionCapacity * 2];

        int m_TickCount;
        int m_SetsPerTick;
        int m_SolveIndex;

        public Dictionary<int, PreviousSetMatches> PreviousMatches { get; set; }

        public QueryMatchID[] SetMatchIds { get; set; }
        public MarsEntityPriority[] AllGroupPriorities { get; set; }

        public TieChoiceBehavior ChoiceBehavior { get; set; } = TieChoiceBehavior.First;

        /// <summary>
        /// The curve that determines how much of the combinations space to search at a given space size
        /// </summary>
        internal AnimationCurve SearchSpacePortionCurve { get; set; }

        internal GroupRatingConfiguration RatingConfiguration { get; set; }

        public GroupMatchSearchTransform()
        {
            Process = ProcessStage;
        }

        internal override void OnCycleStart()
        {
            m_TickCount = 0;
            m_SolveIndex = 0;
        }

        public override void Tick()
        {
            Process(WorkingIndices, Input1, Input2, Input3, Input4, Input5, Input6, Input7, Input8, Input9, ref Output);
        }

        internal static void CalculateSolveOrder(float[] weights, MarsEntityPriority[] priorities, List<int> workingIndices,
            List<KeyValuePair<int, float>> setIndexToWeight)
        {
            setIndexToWeight.Clear();
            k_SolveOrderList.Clear();

            foreach(var i in workingIndices)
            {
                k_SolveOrderList.Add(new SolveSortData()
                {
                    GroupIndex = i,
                    Priority = (sbyte) priorities[i],
                    SolveWeight = weights[i]
                });
            }

            k_SolveOrderList.Sort(k_Comparer);
            foreach (var entry in k_SolveOrderList)
            {
                setIndexToWeight.Add(new KeyValuePair<int, float>(entry.GroupIndex, entry.SolveWeight));
            }
        }

        internal static float GetNoRelationsPortionWeight(float portion)
        {
            const float minWeight = 0.2f;
            const float maxWeight = 0.5f;
            return Mathf.Lerp(maxWeight, minWeight, 1f - portion);
        }

        void ProcessStage(List<int> workingIndices, List<int> outputIndices,
            int[][] allSetMemberIndices,
            RelationDataPair[][] allLocalRelationIndexPairs,
            RelationRatingsData[] allRelationRatings,
            float[] allSetOrderWeights,
            GroupSearchData[] allGroupSearchData,
            RelationMembership[][] allRelationMemberships,
            Exclusivity[] allMemberExclusivities,
            Dictionary<int, float>[] allMemberRatings,
            ref int[] allMemberAssignments)
        {
            if (workingIndices.Count == 0)
            {
                IsComplete = true;
                return;
            }

            if (m_TickCount == 0)
            {
                outputIndices.Clear();
                m_MemberAssignments.Clear();
                // Determine the order we are going to answer Groups.
                CalculateSolveOrder(allSetOrderWeights, AllGroupPriorities, workingIndices, m_AllOrderPairs);
                var setCount = m_AllOrderPairs.Count;
                m_SetsPerTick = Mathf.Clamp(Mathf.CeilToInt(setCount / (float)FrameBudget), 1, setCount);
            }

            // if we need to force completion, setting the end index to the last one will force all groups to solve
            var endIndex = NeedsCompletion ? m_AllOrderPairs.Count
                : Mathf.Clamp(m_SolveIndex + m_SetsPerTick, m_SolveIndex, m_AllOrderPairs.Count);

            for (var solveIndex = m_SolveIndex; solveIndex < endIndex; solveIndex++)
            {
                var kvp = m_AllOrderPairs[solveIndex];
                var setIndex = kvp.Key;
                var queryId = SetMatchIds[setIndex].queryID;
                var memberIndices = allSetMemberIndices[setIndex];
                var localPairs = allLocalRelationIndexPairs[setIndex];
                var relationRatings = allRelationRatings[setIndex];
                var searchData = allGroupSearchData[setIndex];
                var matchBuffer = searchData.MatchBuffer;
                matchBuffer.Reset();

                // determine how many options we should try for each member before stopping
                var hasRelations = localPairs.Length > 0;
                var searchSpaceSize = GetGroupSearchSpaceSize(memberIndices, allMemberRatings);
                // there's no options available for this group, skip it.
                if (searchSpaceSize == 0)
                    continue;

                var portion = GetSearchPortion(searchSpaceSize, SearchSpacePortionCurve, hasRelations);

                GetIterationTargets(portion, searchData.MemberRatings, searchData.MetaEnumerator.TargetDepths);

                m_MetaEnumerator = searchData.MetaEnumerator;
                m_MetaEnumerator.RefreshEnumerators();
                m_MetaEnumerator.Reset();
                m_MetaEnumerator.MoveNext(); // get enumerator into initial valid state

                if (!PreviousMatches.TryGetValue(queryId, out var record))
                {
                    record = new PreviousSetMatches(memberIndices.Length);
                    PreviousMatches.Add(queryId, record);
                }

                /*  The critical loop where we search the set's combination space happens here, in either function.
                    There are 2 different versions of our inner combination loop.

                    1) for Sets with at least one Relation, we filter during the loop only based on whether
                       the combination satisfies all Relations. We only do duplicate assignment &
                       data availability checks later, when picking the best match.

                    2) for Sets with no Relations, we check duplicate assignment & previous use during the loop,
                       and anything that passes those checks is valid.
                */
                var matchFound = hasRelations ? TryCombinations(searchData.MatchBuffer, relationRatings, localPairs)
                                              : TryCombinationsWithoutRelations(searchData, record);

                // if we didn't find any matches for this set during our search, give up and move on.
                if (!matchFound)
                    continue;

                // if we did find matches, find the highest rated one and do any picking between ties necessary
                var chosenIndex = BestAvailableMatch(matchBuffer, record, hasRelations);
                if (chosenIndex < 0)
                    continue;

                // take our chosen match and assign its keys to set members in a staging collection -
                // this isn't final assignment, since we might have to roll back later.
                var begin = chosenIndex * matchBuffer.SetSize;
                var end = begin + matchBuffer.SetSize;
                for (var i = begin; i < end; i++)
                {
                    var assignedDataId = matchBuffer.DataIds[i];
                    var globalMemberIndex = memberIndices[i - begin];
                    m_MemberAssignments[globalMemberIndex] = assignedDataId;
                }

                matchBuffer.CombinationAtRatingIndex(chosenIndex, searchData.ClaimedCombination);

                // the following stages - marking data used & filling results - will use these as their working indices
                if(!outputIndices.Contains(setIndex))
                    outputIndices.Add(setIndex);

                // if this is anything except the last Set to be solved in the cycle,
                // we need to remove the appropriate possibilities from the remaining sets
                if (solveIndex >= m_AllOrderPairs.Count - 1)
                    continue;

                for (var i = solveIndex + 1; i < m_AllOrderPairs.Count; i++)
                {
                    var otherSetIndex = m_AllOrderPairs[i].Key;
                    RemoveClaimedData(searchData.ClaimedCombination, memberIndices,
                        allSetMemberIndices[otherSetIndex], allMemberExclusivities, allMemberRatings);
                }
            }

            m_SolveIndex = endIndex;
            m_TickCount++;

            if (endIndex == m_AllOrderPairs.Count)
            {
                // finalize our assignments
                foreach (var kvp in m_MemberAssignments)
                {
                    allMemberAssignments[kvp.Key] = kvp.Value;
                }

                IsComplete = true;
            }
        }

        /// <summary>
        /// Choose the best match we found while searching that hasn't been previously used by this set.
        /// </summary>
        /// <param name="buffer">The buffer containing every valid match found during the search</param>
        /// <param name="previous">A record of what previous matches for this set have used</param>
        /// <param name="hasRelations">Whether this Set has any Relations or not</param>
        /// <returns>The index into the match buffer where our chosen match is</returns>
        int BestAvailableMatch(SetMatchesBuffer buffer, PreviousSetMatches previous, bool hasRelations)
        {
            var chosenIndex = 0;
            if (hasRelations)
            {
                var tiesLeft = 0;
                var tieCount = 0;
                var tieIndex = 0;
                // for sets with Relations, we filter out duplicates and unavailable data
                // only for the highest-rated combinations we want to use, instead of for every combination
                do
                {
                    if (tiesLeft == 0)
                    {
                        // start by finding all matches that tie for best, then try choosing between them.
                        // if we run out of ties for the current best, we evaluate all the ties for the next best
                        var ratingToCount = buffer.FindHighestRated(ref m_RatingTieIndices);
                        // if we've looped until we discover all matches are unavailable, return -1 to indicate failure
                        if (ratingToCount.Key == 0f)
                            return -1;

                        tieCount = ratingToCount.Value;
                        tiesLeft = ratingToCount.Value;
                        tieIndex = ChoiceBehavior == TieChoiceBehavior.First ? 0
                            : UnityEngine.Random.Range(0, tiesLeft - 1);
                    }
                    else
                    {
                        tiesLeft--;
                        tieIndex = tieIndex == tieCount - 1 ? 0 : tieIndex + 1;
                    }

                    chosenIndex = m_RatingTieIndices[tieIndex];
                }
                while (!previous.IsCombinationAvailable(buffer, chosenIndex));
            }
            else
            {
                // matches for sets without relations have already been filtered for availability and duplicates
                var chosenKvp = buffer.ChooseHighestRated(m_RatingTieIndices, ChoiceBehavior);
                chosenIndex = chosenKvp.Key;
            }

            return chosenIndex;
        }

        /// <summary>
        /// For a Set with any Relations, iterate over a portion of possible combinations of member assignments.
        /// For each combination that satisfies all Relations, reduce Relation & member ratings into a single rating.
        /// </summary>
        /// <param name="matchBuffer">A buffer to record valid combinations with their ratings in</param>
        /// <param name="relationRatings">The Relation ratings for this single Set</param>
        /// <param name="localRelationPairs">The local relation index pairs for this Set</param>
        /// <returns></returns>
        bool TryCombinations(SetMatchesBuffer matchBuffer, RelationRatingsData relationRatings,
            RelationDataPair[] localRelationPairs)
        {
            var config = RatingConfiguration;
            matchBuffer.Reset();
            do
            {
                var hypothesis = m_MetaEnumerator.Current;
                // determine if a given combination of member assignments is valid according to our Relations
                if (!TryRateAssignmentSet(hypothesis, relationRatings, localRelationPairs, config, out var rating))
                    continue;

                matchBuffer.Add(hypothesis, rating);
            }
            // this call produces the next combination to rate, until we reach our iteration target
            while (m_MetaEnumerator.MoveNext());

            // for Sets with Relations, we filter by availability and duplicates only after picking a match
            return matchBuffer.Count > 0;
        }

        // The version of the search loop for Sets with no Relations.
        internal bool TryCombinationsWithoutRelations(GroupSearchData searchData, PreviousSetMatches previousMatches)
        {
            var done = false;
            var duplicateCount = 0;
            
            if (previousMatches == null || previousMatches.Count == 0)
            {
                do
                {
                    var hypothesis = m_MetaEnumerator.Current;
                    // make sure we don't have any contexts that are matches for more than one query that claims data
                    if (AnyDuplicateOrInvalid(hypothesis))
                    {
                        duplicateCount++;
                        continue;
                    }

                    // Since we have no Relations, our Set rating is derived entirely from member ratings
                    searchData.MatchBuffer.Add(hypothesis, AverageMemberRating(hypothesis));

                    // If our very first attempt has no duplicates, it's *guaranteed* to be the best possible match.
                    // This is because we are iterating through member ratings in order of descending rating.
                    if (duplicateCount == 0)
                        done = true;
                    // If we had any duplicates before our first valid match, we don't have that guarantee,
                    // because some other alternate combination may be better, so we should continue iterating
                }
                while (m_MetaEnumerator.MoveNext() && !done);
            }
            else
            {
                do
                {
                    var hypothesis = m_MetaEnumerator.Current;
                    // the first hypothesis being used by a previous match has the same effect on whether
                    // it is guaranteed to be our best possible match as if it had duplicates within itself
                    if (AnyDuplicateOrInvalid(hypothesis) || previousMatches.AssignmentPreviouslyUsed(hypothesis))
                    {
                        duplicateCount++;
                        continue;
                    }

                    searchData.MatchBuffer.Add(hypothesis, AverageMemberRating(hypothesis));
                    if (duplicateCount == 0)
                        done = true;
                }
                while (m_MetaEnumerator.MoveNext() && !done);
            }

            return searchData.MatchBuffer.Count > 0;
        }

        /// <summary>
        /// For each member of a Set that we've just frozen an assumption for,
        /// remove that member's claimed data from another set's members' matches
        /// </summary>
        /// <param name="combination">
        /// The data claimed by the frozen set. Should have length equal to the number of set members.
        /// </param>
        /// <param name="selfMemberIndices">The member indices of the group that has already been solved</param>
        /// <param name="otherGroupMemberIndices">The member indices of the group to remove matches from</param>
        /// <param name="allMemberExclusivities">The global collection of set member exclusivity values</param>
        /// <param name="allMemberRatings">The global collection of set member ratings</param>
        internal static void RemoveClaimedData(int[] combination,
            int[] selfMemberIndices,
            int[] otherGroupMemberIndices,
            Exclusivity[] allMemberExclusivities,
            Dictionary<int, float>[] allMemberRatings)
        {
            for (var i = 0; i < combination.Length; i++)
            {
                var assignedId = combination[i];
                var selfExclusivity = allMemberExclusivities[selfMemberIndices[i]];
                foreach (var mi in otherGroupMemberIndices)
                {
                    var otherExclusivity = allMemberExclusivities[mi];
                    switch (selfExclusivity)
                    {
                        case Exclusivity.ReadOnly:
                            continue;
                        case Exclusivity.Shared:
                        {
                            if (otherExclusivity == Exclusivity.Reserved)
                                allMemberRatings[mi].Remove(assignedId);

                            break;
                        }
                        case Exclusivity.Reserved:
                        {
                            if (otherExclusivity != Exclusivity.ReadOnly)
                                allMemberRatings[mi].Remove(assignedId);

                            break;
                        }
                    }
                }
            }
        }

        // this approach would be bad for large arrays, but the size here is limited by the maximum Set size
        internal static bool AnyDuplicateOrInvalid(KeyValuePair<int, float>[] hypothesis)
        {
            for (var i = 0; i < hypothesis.Length; i++)
            {
                var key1 = hypothesis[i].Key;
                if (key1 == MARSQueryBackend.InvalidDataId)
                    return true;
                
                for (var j = 0; j < hypothesis.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (key1 ==  hypothesis[j].Key)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verify that a given assignment hypothesis satisfies all Relations, and produce a rating for it if so.
        /// This function assumes that the Set has at least one Relation.
        /// For sets without relations, AverageMemberRating should be used instead.
        /// </summary>
        /// <param name="hypothesis">The assignment combination to verify the validity of</param>
        /// <param name="setRelationsRatings">The relation ratings for the Set</param>
        /// <param name="localRelationPairs">Pairs that map each relation's members within the local collections</param>
        /// <param name="ratingConfiguration">The configured weight to use for producing the final ratings</param>
        /// <param name="reducedRating">The final rating for the combination.  0 if the combination is invalid</param>
        /// <returns>True if the combination was valid, false otherwise</returns>
        internal static bool TryRateAssignmentSet(KeyValuePair<int, float>[] hypothesis,
            RelationRatingsData setRelationsRatings,
            RelationDataPair[] localRelationPairs,
            GroupRatingConfiguration ratingConfiguration,
            out float reducedRating)
        {
            // for every Relation, check if its member's assignments are valid within our hypothesis
            var relationRatings = 1f;
            for (var i = 0; i < localRelationPairs.Length; i++)
            {
                var ratings = setRelationsRatings[i];
                var indexPair = localRelationPairs[i];
                var child1 = hypothesis[indexPair.Child1].Key;
                var child2 = hypothesis[indexPair.Child2].Key;
                // if this assignment pair doesn't satisfy this relation, we know to move onto another assignment combo
                if (!ratings.TryGetValue(new RelationDataPair(child1, child2), out var pairRating))
                {
                    reducedRating = 0f;
                    return false;
                }

                relationRatings *= pairRating;
            }

            // combine our relation ratings just like our condition ones - the "inverse power" method
            var reducedRelationRating = Mathf.Pow(relationRatings, 1f / localRelationPairs.Length);

            // combine the relation & member ratings according to the configured weights
            var relationsWeighted = reducedRelationRating * (1f - ratingConfiguration.MemberMatchWeight);
            var membersWeighted = AverageMemberRating(hypothesis) * ratingConfiguration.MemberMatchWeight;
            reducedRating = relationsWeighted + membersWeighted;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float AverageMemberRating(KeyValuePair<int, float>[] hypothesis)
        {
            var accumulatedMemberRating = 0f;
            foreach (var kvp in hypothesis)
            {
                accumulatedMemberRating += kvp.Value;
            }

            return accumulatedMemberRating / hypothesis.Length;
        }

        /// <summary>
        /// the animation curve that specifies the portion of the space to evaluate works like this:
        /// for a given x, the curve specifies what portion of the combination space to evaluate
        /// when the space has 10^x combinations (this number is aka the size of the space).
        /// </summary>
        /// <param name="spaceSize">The total number of naive combinations of all set members</param>
        /// <param name="portionCurve">The curve that defines how many combinations to try</param>
        /// <param name="hasRelations">Whether the set has any Relations</param>
        /// <returns>The portion of the search space to try, as a number from 0 to 1</returns>
        internal static float GetSearchPortion(int spaceSize, AnimationCurve portionCurve, bool hasRelations = true)
        {
            var portion = portionCurve.Evaluate(Mathf.Log10(spaceSize));
            // If there's no relations in a set, it's much harder for a combination to be invalid.
            // Therefore, we can search a much smaller portion of the search space to find our best match.
            return hasRelations ? portion : portion * GetNoRelationsPortionWeight(spaceSize);
        }

        /// <summary>
        /// Find the total number of possible combinations of set members,
        /// before ruling out those made invalid, by relations, overlapping assignment, or otherwise.
        /// </summary>
        /// <param name="memberIndices">The member indices for this set</param>
        /// <param name="allMemberRatings">The global container for all set member ratings</param>
        /// <returns>The total number of possible combinations before filtering down</returns>
        internal static int GetGroupSearchSpaceSize(int[] memberIndices, Dictionary<int, float>[] allMemberRatings)
        {
            var size = 1;
            foreach (var index in memberIndices)
            {
                size *= allMemberRatings[index].Count;
            }

            return size;
        }

        /// <summary>
        /// Calculate how many of each member's options to enumerate in combinations,
        /// based on our total desired search size
        /// </summary>
        /// <param name="portion">A number from 0-1 that represents the portion of the space to search</param>
        /// <param name="ratings">The member ratings for the Set</param>
        /// <param name="targets">The output iteration targets</param>
        internal static void GetIterationTargets(float portion, Dictionary<int, float>[] ratings, int[] targets)
        {
            var inversePower = 1f / ratings.Length;
            var linearScale = Mathf.Pow(portion, inversePower);
            var deviation = 1f;

            for (var i = 0; i < ratings.Length; i++)
            {
                linearScale *= Mathf.Pow(deviation, 1 / (float)(ratings.Length - i));
                var memberRatings = ratings[i];
                var maxPossible = memberRatings.Count;
                if (maxPossible == 0)
                {
                    targets[i] = 0;
                    continue;
                }

                var linearMultiplied = linearScale * maxPossible;
                var clampedLinear = Mathf.Clamp(linearMultiplied, 1, maxPossible);

                var roundedClampedLinear = Mathf.RoundToInt(clampedLinear);
                targets[i] = roundedClampedLinear;

                var actualScale = roundedClampedLinear / (float)maxPossible;
                deviation = linearScale / actualScale;
            }
        }
    }

    class GroupMatchSearchStage : QueryStage<GroupMatchSearchTransform>
    {
        public GroupMatchSearchStage(GroupMatchSearchTransform transformation)
            : base("Set Match Search Stage", transformation)
        {
        }
    }
}

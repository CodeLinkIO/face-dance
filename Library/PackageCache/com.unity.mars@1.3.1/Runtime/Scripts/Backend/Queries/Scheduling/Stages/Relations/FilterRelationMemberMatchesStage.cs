using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using UnityEngine;

namespace Unity.MARS.Query
{
    class FilterRelationMemberMatchesTransform : DataTransform<int[][],
        RelationRatingsData[],
        RelationMembership[][],
        Dictionary<int, float>[]>
    {
        const int k_CollectionsDefaultCapacity = 128;

        int[] m_IdRemovalBuffer = new int[k_CollectionsDefaultCapacity];

        public FilterRelationMemberMatchesTransform() { Process = ProcessStage; }

        // internal for access in tests
        internal void ProcessStage(List<int> workingIndices,
            int[][] allSetMemberIndices,
            RelationRatingsData[] allRelationRatings,
            RelationMembership[][] allRelationMemberships,
            ref Dictionary<int, float>[] allMemberRatings)
        {
            foreach (var i in workingIndices)
            {
                var relationRatingSet = allRelationRatings[i];
                var setMemberIndices = allSetMemberIndices[i];

                foreach (var memberIndex in setMemberIndices)
                {
                    var memberships = allRelationMemberships[memberIndex];
                    // this means that this Set member doesn't belong to any relations.
                    if (memberships == null || memberships.Length == 0)
                        continue;

                    var memberRatings = allMemberRatings[memberIndex];

                    // it's possible that we could filter every member result, so our buffer must be at least that big
                    const int resizeHeadroom = 8;
                    if(m_IdRemovalBuffer.Length < memberRatings.Count)
                        Array.Resize(ref m_IdRemovalBuffer, memberRatings.Count + resizeHeadroom);

                    RemoveInvalidMemberMatches(memberships, relationRatingSet, memberRatings);
                }
            }
        }

        // for each Relation this member belongs to, if a data ID from member matches isn't found in that
        // relation's matches, remove that ID from the member's match ratings, because it can't work.
        internal void RemoveInvalidMemberMatches(RelationMembership[] memberships,
            RelationRatingsData allRelationRatings,
            Dictionary<int, float> memberRatings)
        {
            var memberKeys = memberRatings.Keys;
            foreach (var membership in memberships)
            {
                var removalBufferCounter = 0;
                var singleRelationRatings = allRelationRatings[membership.RelationIndex].Keys;

                // the only difference between these branches is which relation child key we check against.
                // it's organized this way so that this if check is moved out of the two inner loops.
                if (membership.FirstMember)
                {
                    foreach (var memberKey in memberKeys)
                    {
                        var memberKeyFound = false;
                        foreach (var relationPair in singleRelationRatings)
                        {
                            if (relationPair.Child1 == memberKey)
                            {
                                memberKeyFound = true;
                                break;
                            }
                        }

                        if (memberKeyFound)
                            continue;

                        m_IdRemovalBuffer[removalBufferCounter] = memberKey;
                        removalBufferCounter++;
                    }
                }
                else
                {
                    foreach (var memberKey in memberKeys)
                    {
                        var memberKeyFound = false;
                        foreach (var relationPair in singleRelationRatings)
                        {
                            if (relationPair.Child2 == memberKey)
                            {
                                memberKeyFound = true;
                                break;
                            }
                        }

                        if (memberKeyFound)
                            continue;

                        m_IdRemovalBuffer[removalBufferCounter] = memberKey;
                        removalBufferCounter++;
                    }
                }

                for (var i = 0; i < removalBufferCounter; i++)
                {
                    memberRatings.Remove(m_IdRemovalBuffer[i]);
                }
            }
        }
    }

    class FilterRelationMemberMatchesStage : QueryStage<FilterRelationMemberMatchesTransform>
    {
        public FilterRelationMemberMatchesStage(FilterRelationMemberMatchesTransform transformation)
            : base("Filter Relation Member Matches", transformation)
        {
        }
    }
}

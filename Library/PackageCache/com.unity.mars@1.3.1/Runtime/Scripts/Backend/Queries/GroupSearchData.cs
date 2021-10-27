using System;
using System.Collections.Generic;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Container for intermediate data used in SetMatchSearch stage
    /// </summary>
    class GroupSearchData : IDisposable
    {
        public SetMatchesBuffer MatchBuffer;

        public RatingMetaEnumerator MetaEnumerator;
        public int[] ClaimedCombination;
        public Dictionary<int, float>[] MemberRatings;

        public GroupSearchData(int matchBufferCapacity, int[] memberIndices, Dictionary<int, float>[] allMemberRatings)
        {
            MatchBuffer = new SetMatchesBuffer(memberIndices.Length, matchBufferCapacity);
            MemberRatings = new Dictionary<int, float>[memberIndices.Length];
            ClaimedCombination = new int[memberIndices.Length];

            // gather set member ratings from global collections & compact it into local form
            for (var i = 0; i < memberIndices.Length; i++)
            {
                MemberRatings[i] = allMemberRatings[memberIndices[i]];
            }

            MetaEnumerator = new RatingMetaEnumerator(MemberRatings);
        }

        public void Dispose()
        {
            MatchBuffer?.Dispose();
            MetaEnumerator?.Dispose();
            MatchBuffer = null;
            MetaEnumerator = null;
        }
    }
}

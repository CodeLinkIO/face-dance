using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    class MarkGroupDataUsedTransform : DataTransform<
        int[][],
        QueryMatchID[],
        HashSet<int>[],
        SetMatchData[],
        int[],
        IMRObject[],
        Exclusivity[]>
    {
    }

    /// <summary>
    /// This updates the "definitely matching this cycle" indices of Set members, which needs to be done
    /// before the next stage (filling results for members) can happen.
    /// </summary>
    class SetWorkingMembersTransform : DataTransform<int[][], List<int>>
    {
        public SetWorkingMembersTransform() { Process = SetWorkingMemberIndices; }

        static void SetWorkingMemberIndices(List<int> workingSetIndices, int[][] allMemberIndices,
            ref List<int> workingMemberIndices)
        {
            workingMemberIndices.Clear();
            foreach (var i in workingSetIndices)
            {
                var memberIndices = allMemberIndices[i];
                foreach (var mi in memberIndices)
                {
                    workingMemberIndices.Add(mi);
                }
            }
        }
    }

    class MarkSetUsedStage : QueryStage<MarkGroupDataUsedTransform, SetWorkingMembersTransform>
    {
        public MarkSetUsedStage(MarkGroupDataUsedTransform markUsed, SetWorkingMembersTransform updateIndices)
            : base("Mark Set Data Used Stage", markUsed, updateIndices)
        {
        }
    }
}

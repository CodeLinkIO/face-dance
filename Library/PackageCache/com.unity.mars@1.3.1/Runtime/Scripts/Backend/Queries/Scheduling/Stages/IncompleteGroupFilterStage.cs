using System.Collections.Generic;

namespace Unity.MARS.Query
{
    class IncompleteGroupFilterTransform : DataTransform<List<int>, int[][], List<int>>
    {
        static readonly List<int> k_ClearBuffer = new List<int>();

        public IncompleteGroupFilterTransform() { Process = FilterIncompleteGroups; }

        static void FilterIncompleteGroups(List<int> workingMemberIndices, List<int> workingGroupIndices, int[][] allGroupMemberIndices, ref List<int> filteredWorkingGroupIndices)
        {
            k_ClearBuffer.Clear();
            filteredWorkingGroupIndices.Clear();
            foreach (var groupIndex in workingGroupIndices)
            {
                var valid = true;
                var memberIndices = allGroupMemberIndices[groupIndex];
                foreach (var memberIndex in memberIndices)
                {
                    if (!workingMemberIndices.Contains(memberIndex))
                    {
                        valid = false;
                        break;
                    }
                }

                // if any of the group's members didn't make it past the match rating stage, take them all out of this cycle
                if (!valid)
                {
                    k_ClearBuffer.Add(groupIndex);
                    foreach (var memberIndex in memberIndices)
                    {
                        workingMemberIndices.Remove(memberIndex);
                    }
                }
            }

            foreach (var groupMemberIndex in workingGroupIndices)
            {
                if(!k_ClearBuffer.Contains(groupMemberIndex))
                    filteredWorkingGroupIndices.Add(groupMemberIndex);
            }
        }
    }

    class IncompleteGroupFilterStage : QueryStage<IncompleteGroupFilterTransform>
    {
        public IncompleteGroupFilterStage(IncompleteGroupFilterTransform transformation)
            : base("Incomplete Group Match Filter", transformation)
        {
        }
    }
}

using System.Collections.Generic;
using Unity.MARS.Query;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Data.Tests
{
    class MatchConflictTestInput
    {
        public Exclusivity[] exclusivities;
        public MarsEntityPriority[] priorities;
        public Dictionary<int, float>[] ratings;
        public int[] expectedAssignments;
        public List<int> workingIndices;

        public MatchConflictTestInput(Exclusivity[] exclusivities, Dictionary<int, float>[] ratings,
            int[] expectedAssignments, MarsEntityPriority[] priorities = null)
        {
            this.exclusivities = exclusivities;
            this.ratings = ratings;
            this.expectedAssignments = expectedAssignments;
            // default all priorities to Normal if not provided
            this.priorities = priorities ?? new MarsEntityPriority[exclusivities.Length];
            workingIndices = FakeWorkingIndices(exclusivities.Length);
        }

        static List<int> FakeWorkingIndices(int length, HashSet<int> inactiveIndices = null)
        {
            var indices = new List<int>();
            if (inactiveIndices != null)
            {
                for (var i = 0; i < length; i++)
                {
                    if (inactiveIndices.Contains(i))
                        continue;

                    indices.Add(i);
                }
            }
            else
            {
                for (var i = 0; i < length; i++)
                {
                    indices.Add(i);
                }
            }

            return indices;
        }
    }
}

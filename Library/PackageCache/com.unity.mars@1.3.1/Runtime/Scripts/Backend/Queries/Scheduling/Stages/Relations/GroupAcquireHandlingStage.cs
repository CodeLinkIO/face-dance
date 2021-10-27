using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Query
{
    class GroupAcquireHandlingTransform : DataTransform<SetQueryResult[], Action<SetQueryResult>[]>
    {
        public GroupQueryPipeline Pipeline { get; set; }
        public MARSQueryBackend QueryBackend { get; set; }

        public GroupAcquireHandlingTransform() { Process = CallHandlers; }

        /// <summary>
        /// Call every acquire handler with its corresponding query result
        /// </summary>
        /// <param name="indices">The indices to operate on</param>
        /// <param name="results">The collection of all query results</param>
        /// <param name="handlers">The collection of all query acquire handlers</param>
        void CallHandlers(List<int> indices, SetQueryResult[] results,
            ref Action<SetQueryResult>[] handlers)
        {
            foreach (var i in indices)
            {
                // perform a last-moment check to make sure we don't call acquire handlers for anything 
                // that has had its answer invalidated
                if (!Pipeline.QueryAnswerAtIndexIsStillValid(i))
                {
                    QueryBackend.UnmatchGroupIndex(i, true);
                    continue;
                }
                
                // call acquire handler for this query
                handlers[i](results[i]);
            }
        }
    }

    class ManageGroupIndicesTransform : DataTransform<int[][], HashSet<int>, List<int>>
    {
        public ManageGroupIndicesTransform()
        {
            Process = UpdateIndices;
        }

        static void UpdateIndices(List<int> indices, int[][] allMemberIndices, HashSet<int> updatingIndices,
            ref List<int> acquiringIndices)
        {
            foreach (var i in indices)
            {
                var memberIndices = allMemberIndices[i];
                foreach (var mi in memberIndices)
                {
                    updatingIndices.Add(mi);
                    acquiringIndices.Remove(mi);
                }
            }
        }
    }

    class GroupAcquireHandlingStage : QueryStage<GroupAcquireHandlingTransform, ManageIndicesTransform, ManageGroupIndicesTransform>
    {
        public GroupAcquireHandlingStage(GroupAcquireHandlingTransform acquireTransform,
            ManageIndicesTransform indicesTransform, ManageGroupIndicesTransform groupIndicesTransform)
            : base("Group Acquire Handling",
                acquireTransform, indicesTransform, groupIndicesTransform)
        {
        }
    }
}

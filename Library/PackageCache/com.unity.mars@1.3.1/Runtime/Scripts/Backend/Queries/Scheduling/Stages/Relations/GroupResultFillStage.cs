using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Query
{
    partial class SetResultFillTransform : DataTransform<
        int[][],
        QueryMatchID[],
        QueryResult[],
        IMRObject[],
        SetQueryResult[]>
    {
        public SetResultFillTransform()
        {
            Process = ProcessStage;
        }

        internal void ProcessStage(List<int> indices,
            int[][] allMemberIndices,
            QueryMatchID[] matchIds,
            QueryResult[] allMemberResults,
            IMRObject[] allMemberObjects,
            ref SetQueryResult[] results)
        {
            foreach (var i in indices)
            {
                var memberIndices = allMemberIndices[i];
                var result = results[i];

                result.childResults.Clear();
                foreach (var mi in memberIndices)
                {
                    var objectRef = allMemberObjects[mi];
                    result.childResults.Add(objectRef, allMemberResults[mi]);
                }
            }
        }
    }

    class GroupResultFillStage : QueryStage<SetResultFillTransform>
    {
        public GroupResultFillStage(SetResultFillTransform transformation)
             : base("Set Result Fill Stage", transformation)
        {
        }
    }
}

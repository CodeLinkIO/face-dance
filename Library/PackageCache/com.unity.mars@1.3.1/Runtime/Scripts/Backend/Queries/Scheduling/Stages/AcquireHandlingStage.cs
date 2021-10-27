using System;
using System.Collections.Generic;

namespace Unity.MARS.Query
{
    // technically this doesn't transform data, but it's easier / more consistent to put it in this format
    class AcquireHandlingTransform : DataTransform<QueryResult[], Action<QueryResult>[]>
    {
#if UNITY_EDITOR
        public readonly Dictionary<int, bool> DebugHandlerCallStates = new Dictionary<int, bool>();
#endif

        public StandaloneQueryPipeline Pipeline { get; set; }
        public MARSQueryBackend QueryBackend { get; set; }
        
        public AcquireHandlingTransform()
        {
            
            Process = CallHandlers;
        }

        /// <summary>
        /// Call every acquire handler with its corresponding query result
        /// </summary>
        /// <param name="indices">The indices to operate on</param>
        /// <param name="results">The collection of all query results</param>
        /// <param name="handlers">The collection of all query acquire handlers</param>
        void CallHandlers(List<int> indices, QueryResult[] results,
            ref Action<QueryResult>[] handlers)
        {
            foreach (var i in indices)
            {
                // perform a last-moment check to make sure we don't call acquire handlers for anything 
                // that has had its answer invalidated
                if (!Pipeline.QueryAnswerAtIndexIsStillValid(i))
                {
                    QueryBackend.UnmatchStandaloneIndex(i, true);
                    continue;
                }

                handlers[i](results[i]);
#if UNITY_EDITOR
                DebugHandlerCallStates[i] = true;
#endif
            }
        }
    }

    // this transform just moves queries that just acquired from acquiring to updating
    class ManageIndicesTransform : DataTransform<HashSet<int>, List<int>>
    {
        public ManageIndicesTransform()
        {
            Process = UpdateIndices;
        }

        static void UpdateIndices(List<int> indices, HashSet<int> updatingIndices, ref List<int> acquiringIndices)
        {
            foreach (var i in indices)
            {
                updatingIndices.Add(i);
                acquiringIndices.Remove(i);
            }
        }
    }

    class AcquireHandlingStage : QueryStage<AcquireHandlingTransform, ManageIndicesTransform>
    {
        public AcquireHandlingStage(AcquireHandlingTransform acquireTransform, ManageIndicesTransform indicesTransform)
            : base("Acquire Handling", acquireTransform, indicesTransform)
        {
        }

        public void OnCycleStart()
        {
            Transformation1.WorkingIndices.Clear();
#if UNITY_EDITOR
            Transformation1.DebugHandlerCallStates.Clear();
#endif
        }
    }
}

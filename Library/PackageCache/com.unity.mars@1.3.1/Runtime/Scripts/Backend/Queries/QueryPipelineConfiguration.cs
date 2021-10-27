using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Query
{
    public class QueryPipelineConfiguration : ScriptableSettings<QueryPipelineConfiguration>
    {
#pragma warning disable 649
        [SerializeField]
        AnimationCurve m_SearchSpacePortionCurve;

        [SerializeField]
        GroupOrderWeights m_SolveOrderWeighting;
#pragma warning restore 649

        // TODO - this should be included in the inspector
        // each entry in this defines how many frames elapse for each stage of the pipeline,
        // just like the frame budgets below.
        int[] m_SetFrameBudgets =
        {
            0,                         // empty
            0, 0,                      // cache condition & relation trait refs
            1,                         // condition match rating
            0,                         // incomplete group filter
            1,
            0,
            0,
            1,
            1,
            1,                         // filter out any member options that didn't match their relations
            3,                         // group match search - most compute-intensive
            0,
            0,
            1,
            1
        };

        [SerializeField]
        int[] m_FrameBudgets =
        {
            0,
            1,
            1,
            1,
            0,
            0,
            1,
            1,
            0,
            1,
            1
        };

        internal int[] FrameBudgets => m_FrameBudgets;
        internal int[] SetFrameBudgets => m_SetFrameBudgets;
        internal GroupOrderWeights SolveOrderWeighting => m_SolveOrderWeighting;
        internal AnimationCurve SearchSpacePortionCurve => m_SearchSpacePortionCurve;

        /// <summary>
        /// This function is called when the script is loaded or a value is changed in the Inspector (called in the editor only).
        /// </summary>
        public void OnValidate()
        {
            if (m_FrameBudgets == null)
            {
                m_FrameBudgets = new[] { 0 } ;
                return;
            }

            if (m_SolveOrderWeighting == default)
                m_SolveOrderWeighting = GroupOrderWeights.GetDefault();

            for (var i = 0; i < m_FrameBudgets.Length; i++)
            {
                if (m_FrameBudgets[i] < 0)
                    m_FrameBudgets[i] = 0;
            }

            var lastIndex = m_FrameBudgets.Length - 1;
            // the acquire handling stage should always have a frame of its own to work on,
            // since it can take significant time due to gameObject instantiation
            m_FrameBudgets[lastIndex] = 1;
        }
    }
}

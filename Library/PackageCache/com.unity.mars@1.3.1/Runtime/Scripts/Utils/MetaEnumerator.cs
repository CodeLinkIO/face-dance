using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Abstracts away the enumeration of combinations of members of enumerables.
    /// This can be enumerated over like a regular enumerable, while choosing valid combinations
    /// with the search parameters specified
    /// </summary>
    /// <typeparam name="TData">The type of data each member of the enumerable is</typeparam>
    /// <typeparam name="TEnumerator">The enumerator type for the enumerable</typeparam>
    /// <typeparam name="TEnumerable">The enumerable type to iterate over</typeparam>
    class MetaEnumerator<TData, TEnumerator, TEnumerable> : IEnumerator<TData[]>
        where TEnumerator : struct, IEnumerator<TData>
        where TEnumerable : IEnumerable<TData>
    {
        public TEnumerator[] Enumerators;
        public TEnumerable[] Enumerables;

        TData[] m_Current;

        public int[] TargetDepths;
        internal int[] MaxDepthsReached;
        internal int[] CurrentDepths;

        int m_LastIndex;

        /// <summary>
        /// The enumerator we are moving a single step before letting all higher indices enumerate to depth
        /// </summary>
        int m_LowestIterationIndex;

        int m_CurrentMiddleIterationIndex;

        /// <summary>
        /// The enumerator we are going to move next on with the next iteration
        /// </summary>
        int m_CurrentDeepIterationIndex;

        public TData[] Current => m_Current;

        object IEnumerator.Current => Current;

        public MetaEnumerator(TEnumerable[] enumerables, int[] targetDepths)
        {
            TargetDepths = targetDepths;
            MaxDepthsReached = new int[enumerables.Length];
            CurrentDepths = new int[enumerables.Length];
            m_Current = new TData[enumerables.Length];
            Enumerators = new TEnumerator[enumerables.Length];
            Enumerables = enumerables;

            m_LastIndex = enumerables.Length - 1;
            m_CurrentDeepIterationIndex = Enumerators.Length - 1;
            m_LowestIterationIndex = m_CurrentDeepIterationIndex - 1;
            m_CurrentMiddleIterationIndex = m_LowestIterationIndex;

            CurrentDepths[m_LastIndex] = -1;
        }

        public MetaEnumerator(TEnumerable[] enumerables)
        {
            TargetDepths = new int[enumerables.Length];
            MaxDepthsReached = new int[enumerables.Length];
            CurrentDepths = new int[enumerables.Length];
            m_Current = new TData[enumerables.Length];
            Enumerables = enumerables;
            Enumerators = new TEnumerator[enumerables.Length];

            m_LastIndex = enumerables.Length - 1;
            m_CurrentDeepIterationIndex = Enumerators.Length - 1;
            m_LowestIterationIndex = m_CurrentDeepIterationIndex - 1;
            m_CurrentMiddleIterationIndex = m_LowestIterationIndex;

            if(CurrentDepths.Length > 0)
                CurrentDepths[m_LastIndex] = -1;
        }

        public void RefreshEnumerators()
        {
            for (var i = 0; i < Enumerables.Length; i++)
            {
                Enumerators[i] = (TEnumerator)Enumerables[i].GetEnumerator();
            }

            for (var i = 0; i < Enumerables.Length - 1; i++)
            {
                var enumerator = Enumerators[i];
                enumerator.MoveNext();
                m_Current[i] = enumerator.Current;
                Enumerators[i] = enumerator;
            }
        }

        // This function could / should be simpler than it is
        public bool MoveNext()
        {
            if (CurrentDepths.Length == 0)
                return false;

            var currentDepth = CurrentDepths[m_CurrentDeepIterationIndex];
            var currentTargetDepth = TargetDepths[m_CurrentDeepIterationIndex];

            if (currentDepth < currentTargetDepth)
            {
                var currentEnumerator = Enumerators[m_CurrentDeepIterationIndex];
                if (currentEnumerator.MoveNext())
                    m_Current[m_CurrentDeepIterationIndex] = currentEnumerator.Current;

                Enumerators[m_CurrentDeepIterationIndex] = currentEnumerator;
                CurrentDepths[m_CurrentDeepIterationIndex] = currentDepth + 1;
                return true;
            }


            if (m_LowestIterationIndex < 0)
                return false;

            var singleIterationEnumerator = Enumerators[m_LowestIterationIndex];
            // time to reset the last enumerator and MoveNext() on m_CurrentSingleIterationIndex
            var singleIterationDepth = CurrentDepths[m_LowestIterationIndex];

            if (ShouldMoveLeft())
            {
                if (m_LowestIterationIndex > 0)
                {
                    // time to Reset() all iterators from m_CurrentSingleIterationIndex to the end,
                    // and move our single iterator one step backwards in the array
                    ResetFromIndex(m_LowestIterationIndex);
                    m_LowestIterationIndex--;

                    var enumerator = Enumerators[m_LowestIterationIndex];
                    if (enumerator.MoveNext())
                        m_Current[m_LowestIterationIndex] = enumerator.Current;

                    Enumerators[m_LowestIterationIndex] = enumerator;
                    CurrentDepths[m_LowestIterationIndex] = 1;
                    return true;
                }

                // we've iterated through everything - this is the desired exit point.
                return false;
            }

            var middleIterationDepth = CurrentDepths[m_CurrentMiddleIterationIndex];
            var middleIterationTargetDepth = TargetDepths[m_CurrentMiddleIterationIndex];
            if (middleIterationDepth < middleIterationTargetDepth)
            {
                var middleIterationEnumerator = Enumerators[m_CurrentMiddleIterationIndex];
                if (middleIterationEnumerator.MoveNext())
                    m_Current[m_CurrentMiddleIterationIndex] = middleIterationEnumerator.Current;

                CurrentDepths[m_CurrentMiddleIterationIndex] = middleIterationDepth + 1;
                Enumerators[m_CurrentMiddleIterationIndex] = middleIterationEnumerator;
                ResetFromIndex(m_CurrentMiddleIterationIndex + 1);
                return true;
            }

            var indexDiff = m_LowestIterationIndex - m_CurrentMiddleIterationIndex;
            if (indexDiff < -1)
            {
                var offset = indexDiff + 1;

                var iterIndex = m_CurrentMiddleIterationIndex + offset;
                // there could potentially be a number of entries between the lowest and middle indices,
                // so find the closest one to the middle that isn't yet at target depth
                for (var n = m_CurrentMiddleIterationIndex - 1; n > m_LowestIterationIndex; n--)
                {
                    var depth = CurrentDepths[n];
                    var target = TargetDepths[n];
                    if (depth < target)
                    {
                        iterIndex = n;
                        break;
                    }
                }
                var iterDepth = CurrentDepths[iterIndex];
                if (iterDepth < TargetDepths[iterIndex])
                {
                    var furthestLeftMiddleEnumerator = Enumerators[iterIndex];
                    if (furthestLeftMiddleEnumerator.MoveNext())
                        m_Current[iterIndex] = furthestLeftMiddleEnumerator.Current;

                    Enumerators[iterIndex] = furthestLeftMiddleEnumerator;
                    CurrentDepths[iterIndex] = CurrentDepths[iterIndex] + 1;
                    ResetFromIndex(iterIndex + 1);
                }
                else
                {
                    ResetFromIndex(iterIndex);
                    var enumerator = Enumerators[m_LowestIterationIndex];
                    if (enumerator.MoveNext())
                        m_Current[m_LowestIterationIndex] = enumerator.Current;

                    Enumerators[m_LowestIterationIndex] = enumerator;
                    CurrentDepths[m_LowestIterationIndex] = CurrentDepths[m_LowestIterationIndex] + 1;
                }

                return true;
            }

            if (singleIterationEnumerator.MoveNext())
                m_Current[m_LowestIterationIndex] = singleIterationEnumerator.Current;

            var newDepth = singleIterationDepth + 1;
            CurrentDepths[m_LowestIterationIndex] = newDepth;
            Enumerators[m_LowestIterationIndex] = singleIterationEnumerator;

            ResetFromIndex(m_LowestIterationIndex + 1);
            return true;
        }

        bool ShouldMoveLeft()
        {
            for (var i = m_LowestIterationIndex; i < Enumerators.Length; i++)
            {
                var depth = CurrentDepths[i];
                var targetDepth = TargetDepths[i];
                if (depth < targetDepth)
                    return false;
            }

            return true;
        }

        void ResetFromIndex(int leftMostIndex)
        {
            for (var i = leftMostIndex; i < Enumerators.Length; i++)
            {
                var enumerator = Enumerators[i];
                enumerator.Reset();
                enumerator.MoveNext();

                m_Current[i] = enumerator.Current;
                Enumerators[i] = enumerator;
                CurrentDepths[i] = 0;
            }

            m_CurrentDeepIterationIndex = m_LastIndex;
        }

        public void Reset()
        {
            // set to the last member
            m_CurrentDeepIterationIndex = Enumerators.Length - 1;
            m_LowestIterationIndex = m_CurrentDeepIterationIndex - 1;
            m_CurrentMiddleIterationIndex = m_LowestIterationIndex;

            var lastMoveNextIndex =  Enumerators.Length - 1;
            // get all enumerators to have their first value as Current (except the last one)
            for (var i = 0; i < Enumerators.Length; i++)
            {
                var enumerator = Enumerators[i];
                enumerator.Reset();

                // don't set the last member to the initial state - the first MoveNext() call will do this.
                if (i != lastMoveNextIndex)
                {
                    enumerator.MoveNext();
                    Enumerators[i] = enumerator;
                    m_Current[i] = enumerator.Current;
                }
                else
                {
                    m_Current[i] = default;
                }
            }

            Array.Clear(MaxDepthsReached, 0, MaxDepthsReached.Length);
            Array.Clear(CurrentDepths, 0, CurrentDepths.Length);
        }

        public void Dispose() { }
    }
}

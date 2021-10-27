using System;
using System.Collections.Generic;

namespace Unity.MARS
{
    abstract class ParallelSparseArrays
    {
        /// <summary>
        /// All indices of proxies that have not matched yet, and will be evaluated when the evaluation cycle runs.
        /// Add or remove members from here if you need to evaluate a non-standard list of proxies.
        /// </summary>
        internal readonly List<int> AcquiringIndices = new List<int>();
        /// <summary>All acquiring proxy/group indices that all required trait data has been found for</summary>
        internal readonly List<int> FilteredAcquiringIndices = new List<int>();
        /// <summary>All acquiring proxy/group indices with at least one data id found that satisfies all constraints</summary>
        internal readonly List<int> PotentialMatchAcquiringIndices = new List<int>();
        /// <summary>All acquiring proxy/group indices that we have decided on a final data match for</summary>
        internal readonly List<int> DefiniteMatchAcquireIndices = new List<int>();
        /// <summary>All indices of proxies / groups that have already matched & need update handling</summary>
        internal readonly HashSet<int> UpdatingIndices = new HashSet<int>();

        protected int m_Count;
        protected int m_Capacity;

        /// <summary>
        /// Indices of data that has been removed
        /// </summary>
        internal readonly Queue<int> FreedIndices = new Queue<int>();    // internal for testing

        /// <summary>
        /// All indices which currently contain valid data
        /// </summary>
        public readonly List<int> ValidIndices  = new List<int>();

        public int Count => m_Count;
        public int Capacity => m_Capacity;

        internal Action OnResize { get; set; }

        public int ResizeMultiplier = 2;

        internal abstract void Resize(int newSize);

        protected ParallelSparseArrays(int startingCapacity)
        {
            m_Capacity = startingCapacity;
        }

        /// <summary>
        /// Get the next array index to insert data at, using previously-freed indices before new ones.
        /// Will grow the backing arrays if necessary.
        /// </summary>
        /// <returns>The index to insert the current piece of new data at</returns>
        protected int GetInsertionIndex()
        {
            if(m_Count >= m_Capacity)
                Resize(m_Capacity * ResizeMultiplier);

            return FreedIndices.Count > 0 ? FreedIndices.Dequeue() : m_Count;
        }

        protected void FreeIndex(int index)
        {
            FreedIndices.Enqueue(index);
            ValidIndices.Remove(index);
        }
    }
}

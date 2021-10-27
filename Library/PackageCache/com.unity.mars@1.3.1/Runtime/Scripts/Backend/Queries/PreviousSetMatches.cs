using System;
using System.Collections.Generic;

namespace Unity.MARS.Query
{
    class PreviousSetMatches : IDisposable
    {
        const int k_DefaultCapacity = 4;

        static readonly HashSet<int> k_Set = new HashSet<int>();

        public readonly List<HashSet<int>> Previous = new List<HashSet<int>>(k_DefaultCapacity);

        public int SetSize { get; }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public PreviousSetMatches(int setSize, int capacity = k_DefaultCapacity)
        {
            SetSize = setSize;
            Capacity = capacity;
            Previous.Clear();
        }

        public void Dispose()
        {
            foreach (var record in Previous)
            {
                Pools.DataIdHashSets.Recycle(record);
            }

            Count = 0;
        }

        public void Add(IEnumerable<int> combination)
        {
            var set = Pools.DataIdHashSets.Get();
            foreach (var member in combination)
            {
                set.Add(member);
            }

            Previous.Add(set);
            Count++;
        }

        public void Add(HashSet<int> set)
        {
            Previous.Add(set);
            Count++;
        }

        public void Remove(HashSet<int> combination)
        {
            Previous.Remove(combination);
            Count--;
        }

        public bool AssignmentPreviouslyUsed(KeyValuePair<int, float>[] hypothesis)
        {
            k_Set.Clear();
            foreach (var kvp in hypothesis)
            {
                k_Set.Add(kvp.Key);
            }

            foreach (var previous in Previous)
            {
                if (previous.SetEquals(k_Set))
                    return true;
            }

            return false;
        }

        public bool IsCombinationAvailable(SetMatchesBuffer buffer, int index)
        {
            var start = index * buffer.SetSize;
            k_Set.Clear();
            var end = start + buffer.SetSize;
            for (var i = start; i < end; i++)
            {
                k_Set.Add(buffer.DataIds[i]);
            }

            // also filter duplicates
            if (k_Set.Count != SetSize)
            {
                buffer.Ratings[index] = 0f;
                return false;
            }

            foreach (var previous in Previous)
            {
                if (!previous.SetEquals(k_Set))
                    continue;

                // by setting the rating to 0, we ensure it won't be chosen when we look for the best match.
                buffer.Ratings[index] = 0f;
                return false;
            }

            return true;
        }
    }


}

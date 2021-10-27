using System.Collections.Generic;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Contains a hashset of indices for each data exclusivity rule, of queries in the working query set.
    /// Used in resolving match conflicts.
    /// </summary>
    class DataIdRequestMap
    {
        internal readonly HashSet<int> Reserved = new HashSet<int>();
        internal readonly HashSet<int> Shared = new HashSet<int>();
        // we don't need to do any Contains() checks for readonly data,
        // so we can use a list which is slightly faster to add to
        internal readonly List<int> ReadOnly = new List<int>();

        public void Add(int index, Exclusivity exclusivity)
        {
            switch (exclusivity)
            {
                case Exclusivity.Reserved:
                    Reserved.Add(index);
                    break;
                case Exclusivity.Shared:
                    Shared.Add(index);
                    break;
                case Exclusivity.ReadOnly:
                    ReadOnly.Add(index);
                    break;
            }
        }

        public void Clear()
        {
            Reserved.Clear();
            ReadOnly.Clear();
            Shared.Clear();
        }
    }
}

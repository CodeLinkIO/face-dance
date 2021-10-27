using System;

namespace Unity.MARS.Data
{
    /// <summary>
    /// A pair of integers , one associated with each child.
    /// The integers can represent either indices or data IDs.
    /// </summary>
    public struct RelationDataPair : IEquatable<RelationDataPair>
    {
        public readonly int Child1;
        public readonly int Child2;

        public RelationDataPair(int one, int two)
        {
            Child1 = one;
            Child2 = two;
        }

        public bool Equals(RelationDataPair other)
        {
            return Child1 == other.Child1 && Child2 == other.Child2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is RelationDataPair && Equals((RelationDataPair) obj);
        }

        public override int GetHashCode()
        {
            // the reason we use 397 is because it's a prime number, and (a * 397) ^ b
            // is a commonly accepted method for hashing two integers together.
            return unchecked((Child1 * 397) ^ Child2);
        }
    }
}

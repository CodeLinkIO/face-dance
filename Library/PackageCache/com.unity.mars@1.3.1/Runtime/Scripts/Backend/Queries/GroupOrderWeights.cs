using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.MARS.Query
{
    [Serializable]
    public struct GroupOrderWeights : IEquatable<GroupOrderWeights>
    {
        const float k_DefaultReserved = 1f;
        const float k_DefaultShared = 0.5f;
        const float k_DefaultRelation = 0.3f;

        internal const float MaxReservedWeight = 1f;
        internal const float MinReservedWeight = 0.7f;
        internal const float MaxSharedWeight = 0.6f;
        internal const float MinSharedWeight = 0.3f;
        internal const float MaxRelationWeight = 0.3f;
        internal const float MinRelationWeight = 0.1f;

        public float RelationWeight;
        public float SharedMemberWeight;
        public float ReservedMemberWeight;

        public GroupOrderWeights(float relation = k_DefaultRelation,
            float sharedMember = k_DefaultShared, float reservedMember = k_DefaultReserved)
        {
            RelationWeight = Mathf.Clamp(relation, MinRelationWeight, MaxRelationWeight);
            SharedMemberWeight = Mathf.Clamp(sharedMember, MinSharedWeight, MaxSharedWeight);
            ReservedMemberWeight = Mathf.Clamp(reservedMember, MinReservedWeight, MaxReservedWeight);
        }

        public static GroupOrderWeights GetDefault()
        {
            return new GroupOrderWeights
            {
                RelationWeight = k_DefaultRelation,
                SharedMemberWeight = k_DefaultShared,
                ReservedMemberWeight = k_DefaultReserved
            };
        }

        /// <inheritdoc />
        public bool Equals(GroupOrderWeights other)
        {
            return RelationWeight.Equals(other.RelationWeight) &&
                SharedMemberWeight.Equals(other.SharedMemberWeight) &&
                ReservedMemberWeight.Equals(other.ReservedMemberWeight);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is GroupOrderWeights other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = RelationWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ SharedMemberWeight.GetHashCode();
                hashCode = (hashCode * 397) ^ ReservedMemberWeight.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Equality operators check if their operands are equal
        /// </summary>
        /// <param name="left">Left</param>
        /// <param name="right">Right</param>
        /// <returns><c>True</c> if equal</returns>
        public static bool operator ==(GroupOrderWeights left, GroupOrderWeights right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operators check if their operands are equal
        /// </summary>
        /// <param name="left">Left</param>
        /// <param name="right">Right</param>
        /// <returns><c>True</c> if not equal</returns>
        public static bool operator !=(GroupOrderWeights left, GroupOrderWeights right)
        {
            return !left.Equals(right);
        }
    }
}

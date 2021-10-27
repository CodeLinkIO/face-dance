using System;
using System.Collections.Generic;

namespace Unity.MARS
{
    /// <summary>
    /// Solver-internal representation of Trait data types
    /// </summary>
    class MarsDataType : IComparable<MarsDataType>, IEquatable<MarsDataType>
    {
        static int s_NextTypeId = 1;
        static readonly Dictionary<string, MarsDataType> k_TypeNameToMarsType = new Dictionary<string, MarsDataType>();
        
        public int TypeId { get; }
        public Type RuntimeType { get; }

        public bool IsValid => (TypeId != 0);

        MarsDataType(Type type)
        {
            TypeId = s_NextTypeId++;
            RuntimeType = type;
        }

        public int CompareTo(MarsDataType other) => TypeId.CompareTo(other.TypeId);
        public bool Equals(MarsDataType other) => other != null && TypeId.Equals(other.TypeId);
        
        public override int GetHashCode() => TypeId.GetHashCode();

        public static explicit operator int(MarsDataType marsType) => marsType.TypeId;

        public static explicit operator MarsDataType(Type type)
        {
            return TryGetFromType(type, out var marsType) ? marsType : null;
        }

        public static bool TryGetFromType(Type type, out MarsDataType marsType)
        {
            return k_TypeNameToMarsType.TryGetValue(GetTypeName(type), out marsType);
        }

        internal static void Register<T>()
        {
            var type = typeof(T);
            var name = GetTypeName(type);
            if (!k_TypeNameToMarsType.ContainsKey(name))
                k_TypeNameToMarsType.Add(name, new MarsDataType(type));
        }
        
        internal static bool Remove<T>() => k_TypeNameToMarsType.Remove(GetTypeName(typeof(T)));

        // FullName can be null, so fall back on Name, which cannot be null
        static string GetTypeName(Type type) => type.FullName ?? type.Name;
    }
}

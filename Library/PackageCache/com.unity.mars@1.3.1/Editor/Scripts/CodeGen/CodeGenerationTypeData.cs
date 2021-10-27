using System;

namespace Unity.MARS.CodeGen
{
    class CodeGenerationTypeData : IEquatable<CodeGenerationTypeData>
    {
        public readonly Type Type;
        public readonly string MemberPrefix;
        public readonly string LocalVarPrefix;

        public CodeGenerationTypeData(Type type, string memberPrefix)
        {
            Type = type;
            MemberPrefix = memberPrefix;
            LocalVarPrefix = LowerFirstChar(memberPrefix);
        }

        public bool Equals(CodeGenerationTypeData other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Type == other.Type && string.Equals(MemberPrefix, other.MemberPrefix);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == GetType() && Equals((CodeGenerationTypeData) obj);
        }

        // make a local variable prefix from a member prefix
        static string LowerFirstChar(string input)
        {
            return char.IsUpper(input[0]) ? char.ToLower(input[0]) + input.Substring(1) : input;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0) * 397) ^
                    (MemberPrefix != null ? MemberPrefix.GetHashCode() : 0);
            }
        }

        public static bool operator ==(CodeGenerationTypeData left, CodeGenerationTypeData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CodeGenerationTypeData left, CodeGenerationTypeData right)
        {
            return !Equals(left, right);
        }
    }
}

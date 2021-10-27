using System;
using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Data returned from a particular query
    /// </summary>
    public partial class QueryResult : IEquatable<QueryResult>
    {
        public QueryMatchID queryMatchId;

        // keep this private, only allow data lookup via IUses/ProvidesMARSData functionality
        int m_DataId;

        public int DataID { get { return m_DataId; } }

        public QueryResult() { }

        public QueryResult(QueryMatchID id)
        {
            queryMatchId = id;
        }

        public void Reset()
        {
            queryMatchId = QueryMatchID.NullQuery;
            Clear();
        }

        internal void SetDataId(int id)
        {
            m_DataId = id;
        }

        /// <summary>
        /// Gets the value for a particular type of data for a given data id
        /// </summary>
        /// <typeparam name="T">The type of data to return</typeparam>
        /// <param name="dataUser">The functionality subscriber that will actually do the data lookup</param>
        /// <returns>The typed value for the given data id</returns>
        public T ResolveValue<T>(IUsesMARSData<T> dataUser)
        {
            return dataUser.GetIdValue(m_DataId);
        }

        /// <summary>
        /// Gets the value for a particular type of data for a given data id
        /// </summary>
        /// <typeparam name="T">The type of data to return</typeparam>
        /// <param name="dataUser">The functionality subscriber that will actually do the data lookup</param>
        /// <returns>The typed value for the given data id</returns>
        public T ResolveValue<T>(IUsesMARSTrackableData<T> dataUser)
            where T : IMRTrackable
        {
            return dataUser.GetIdValue(m_DataId);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (queryMatchId.GetHashCode() * 397) ^ m_DataId;
            }
        }

        /// <inheritdoc />
        public bool Equals(QueryResult other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return queryMatchId.Equals(other.queryMatchId) && m_DataId == other.m_DataId;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == typeof(QueryResult) && Equals((QueryResult) obj);
        }

        /// <summary>
        /// Equality operators check if their operands are equal
        /// </summary>
        /// <param name="left">Left</param>
        /// <param name="right">Right</param>
        /// <returns><c>True</c> if equal</returns>
        public static bool operator ==(QueryResult left, QueryResult right) { return Equals(left, right); }
        /// <summary>
        /// Inequality operators check if their operands are are not equal.
        /// </summary>
        /// <param name="left">Left</param>
        /// <param name="right">Right</param>
        /// <returns><c>True</c> if not equal</returns>
        public static bool operator !=(QueryResult left, QueryResult right) { return !Equals(left, right); }

        /// <summary>
        /// Remove all trait values from this query result and invalidate its data assigment
        /// </summary>
        internal void Clear()
        {
            m_DataId = (int) ReservedDataIDs.Invalid;
            Clear(this);
        }

        // These methods should be unused once code generation runs
        // ReSharper disable UnusedMember.Global
        /// <summary>
        /// This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method
        /// </summary>
        /// <param name="traitName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [Obsolete("This method exists in order for MARS to compile before type-specific code is generated. Use the type-specific version of this method")]
        public bool TryGetTrait(string traitName, out object value)
        {
            value = default;
            return false;
        }

        public bool TryGetTrait<T>(string traitName, out T value)
            where T: struct
        {
            value = default;
            return false;
        }

        public void SetTrait(string traitName, object value) { }
        // ReSharper restore UnusedMember.Global

        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedParameter.Local
        static void Clear(object result) { }
    }
}

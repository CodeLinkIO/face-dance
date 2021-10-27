using System;

namespace Unity.MARS.Companion.CloudStorage
{
    /// <summary>
    /// Default values for cloud data storage settings
    /// </summary>
    public readonly struct RequestHandle : IEquatable<RequestHandle>
    {
        // Start at 1 to distinguish from default RequestHandle
        const int k_InitialHandleValue = 1;
        static int s_HandleAutoIncrement = k_InitialHandleValue;

        readonly int m_Handle;
        readonly string m_Label;

        RequestHandle(int handle, string label)
        {
            m_Handle = handle;
            m_Label = label;
        }

        internal static RequestHandle Create(string label)
        {
            // Just in case we hit max value, cycle back to init value
            if (s_HandleAutoIncrement == int.MaxValue)
                s_HandleAutoIncrement = k_InitialHandleValue;

            return new RequestHandle(s_HandleAutoIncrement++, label);
        }

        /// <summary>
        /// Returns true if this handle has the same id as a given handle
        /// </summary>
        /// <param name="other">The other handle to be compared with this one</param>
        /// <returns>True if both handles have the same id</returns>
        public bool Equals(RequestHandle other)
        {
            return m_Handle == other.m_Handle;
        }

        /// <summary>
        /// Returns true if the object being compared is a RequestHandle this handle has the same id as a given handle
        /// </summary>
        /// <param name="obj">The other object to be compared with this one</param>
        /// <returns>True if both handles have the same id</returns>
        public override bool Equals(object obj)
        {
            return obj is RequestHandle other && Equals(other);
        }

        /// <summary>
        /// Get a unique hash code for this handle; this is equal to its id
        /// </summary>
        /// <returns>The unique hash code</returns>
        public override int GetHashCode()
        {
            return m_Handle;
        }

        /// <summary>
        /// Return a string representation of this handle
        /// </summary>
        /// <returns>A string representation of this handle</returns>
        public override string ToString()
        {
            return $"{m_Handle} - {m_Label}";
        }
    }
}

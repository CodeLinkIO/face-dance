using System;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// A unique identifier for trackable data in MARS - mirrors `UnityEngine.Experimental.XR.TrackableId`
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [MovedFrom("Unity.MARS")]
    public struct MarsTrackableId : IEquatable<MarsTrackableId>
    {
        const ulong k_CreationSubIdOne = ulong.MaxValue;

        static readonly MarsTrackableId k_InvalidId;
        static readonly ulong k_StringSubIdOne = 1ul;
        static ulong s_IdTwoCounter;

        [SerializeField]
        [Tooltip("The first sub-component of the id.")]
        ulong m_SubId1;

        [SerializeField]
        [Tooltip("The second sub-component of the id.")]
        ulong m_SubId2;

        /// <summary>
        /// Represents an invalid id.
        /// </summary>
        public static MarsTrackableId InvalidId => k_InvalidId;

        /// <summary>
        /// The first sub-component of the id.
        /// </summary>
        public ulong subId1 => m_SubId1;

        /// <summary>
        /// The second sub-component of the id.
        /// </summary>
        public ulong subId2 => m_SubId2;

        /// <summary>
        /// Generates a nicely formatted version of the id
        /// </summary>
        /// <returns>A string unique to this id</returns>
        public override string ToString()
        {
            return string.Format("{0}-{1}", m_SubId1.ToString("X16", CultureInfo.InvariantCulture),
                m_SubId2.ToString("X16", CultureInfo.InvariantCulture));
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return m_SubId1.GetHashCode() ^ m_SubId2.GetHashCode();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is MarsTrackableId && Equals((MarsTrackableId) obj);
        }

        /// <inheritdoc />
        public bool Equals(MarsTrackableId other)
        {
            return m_SubId1 == other.m_SubId1 && m_SubId2 == other.m_SubId2;
        }

        /// <summary>
        /// Equality operators check if their operands are equal
        /// </summary>
        /// <param name="id1">id 1</param>
        /// <param name="id2">id 2</param>
        /// <returns><c>True</c> if equal</returns>
        public static bool operator ==(MarsTrackableId id1, MarsTrackableId id2)
        {
            return id1.m_SubId1 == id2.m_SubId1 && id1.m_SubId2 == id2.m_SubId2;
        }

        /// <summary>
        /// Inequality operators check if their operands are equal
        /// </summary>
        /// <param name="id1">Id 1</param>
        /// <param name="id2">Id 2</param>
        /// <returns><c>True</c> if not equal</returns>
        public static bool operator !=(MarsTrackableId id1, MarsTrackableId id2)
        {
            return id1.m_SubId1 != id2.m_SubId1 || id1.m_SubId2 != id2.m_SubId2;
        }

        /// <summary>
        /// Create a unique identifier for trackable data in MARS
        /// </summary>
        /// <param name="idOne">Id 1</param>
        /// <param name="idTwo">Id 2</param>
        public MarsTrackableId(ulong idOne, ulong idTwo)
        {
            m_SubId1 = idOne;
            m_SubId2 = idTwo;
        }

        /// <summary>
        /// Create a unique identifier for trackable data in MARS
        /// </summary>
        /// <param name="trackableKey">Trackable's key</param>
        public MarsTrackableId(string trackableKey)
        {
            // the idea with this is that since we won't ever reach this id with the negative counter,
            // then it's safe to use it as a complementary key to the string's hash code
            m_SubId1 = k_StringSubIdOne;
            m_SubId2 = (ulong) trackableKey.GetHashCode();
        }

        /// <summary>
        /// Create a new trackable identifier
        /// </summary>
        /// <returns>A new session-unique trackable ID</returns>
        public static MarsTrackableId Create()
        {
            return new MarsTrackableId(k_CreationSubIdOne, s_IdTwoCounter++);
        }
    }
}

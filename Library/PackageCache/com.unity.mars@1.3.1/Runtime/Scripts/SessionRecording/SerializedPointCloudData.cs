using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Serialized container for recorded point cloud data
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS.Recording")]
    public struct SerializedPointCloudData
    {
        [SerializeField]
        MarsTrackableId m_Id;

        [SerializeField]
        ulong[] m_Identifiers;

        [SerializeField]
        Vector3[] m_Positions;

        [SerializeField]
        float[] m_ConfidenceValues;

        /// <summary>
        /// The id of this point cloud segment
        /// </summary>
        public MarsTrackableId Id { get { return m_Id; } set { m_Id = value; } }

        /// <summary>
        /// List of identifiers for points in this point cloud
        /// </summary>
        public ulong[] Identifiers { get { return m_Identifiers; } set { m_Identifiers = value; } }

        /// <summary>
        /// List of positions for points in this point cloud
        /// </summary>
        public Vector3[] Positions { get { return m_Positions; } set { m_Positions = value; } }

        /// <summary>
        /// List of confidence values for points in this point cloud
        /// </summary>
        public float[] ConfidenceValues { get { return m_ConfidenceValues; } set { m_ConfidenceValues = value; } }
    }
}

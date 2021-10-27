using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked marker data
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public struct MRMarker : IMRTrackable, IEquatable<MRMarker>
    {
        [SerializeField]
        MarsTrackableId m_TrackableId;

        [SerializeField]
        Pose m_Pose;

        [SerializeField]
        Guid m_MarkerId;

        [SerializeField]
        Vector2 m_Extents;

        [SerializeField]
        MARSTrackingState m_TrackingState;

        [SerializeField]
        Texture2D m_Texture;

        /// <summary>
        /// The id of this tracked marker as determined by the provider
        /// </summary>
        public MarsTrackableId id
        {
            get { return m_TrackableId; }
            set { m_TrackableId = value; }
        }

        /// <summary>
        /// The pose of this marker
        /// </summary>
        public Pose pose
        {
            get { return m_Pose; }
            set { m_Pose = value; }
        }

        /// <summary>
        /// The guid of this marker
        /// </summary>
        public Guid markerId
        {
            get { return m_MarkerId; }
            set { m_MarkerId = value; }
        }

        /// <summary>
        /// The extents of this marker
        /// </summary>
        public Vector2 extents
        {
            get { return m_Extents; }
            set { m_Extents = value; }
        }

        /// <summary>
        /// The current quality of spatial tracking of this marker
        /// </summary>
        public MARSTrackingState trackingState
        {
            get => m_TrackingState;
            set => m_TrackingState = value;
        }

        /// <summary>
        /// The texture of this marker
        /// </summary>
        public Texture2D texture
        {
            get => m_Texture;
            set => m_Texture = value;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"marker: {m_MarkerId}\npose: {m_Pose},\ntracking state: {m_TrackingState}";
        }

        /// <inheritdoc />
        public override int GetHashCode() { return id.GetHashCode(); }

        /// <inheritdoc />
        public bool Equals(MRMarker other) { return id.Equals(other.id); }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Providers;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked plane data
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public struct MRPlane : IMRTrackable, IEquatable<MRPlane>
    {
        static readonly Vector3[] k_Corners = new Vector3[2];

        [SerializeField]
        MarsTrackableId m_ID;

        [SerializeField]
        MarsPlaneAlignment m_Alignment;

        [SerializeField]
        Pose m_Pose;

        [SerializeField]
        Vector3 m_Center;

        [SerializeField]
        Vector2 m_Extents;

        /// <summary>
        /// The id of this plane as determined by the provider
        /// </summary>
        public MarsTrackableId id
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        /// <summary>
        /// The alignment of this plane (e.g. Horizontal, Vertical)
        /// </summary>
        public MarsPlaneAlignment alignment
        {
            get { return m_Alignment; }
            set { m_Alignment = value; }
        }

        /// <summary>
        /// The pose of this plane
        /// </summary>
        public Pose pose
        {
            get { return m_Pose; }
            set { m_Pose = value; }
        }

        /// <summary>
        /// The center of this plane, in local space
        /// </summary>
        public Vector3 center
        {
            get { return m_Center; }
            set { m_Center = value; }
        }

        /// <summary>
        /// The extents of this plane
        /// </summary>
        public Vector2 extents
        {
            get { return m_Extents; }
            set { m_Extents = value; }
        }

        /// <summary>
        /// (Optional) vertices for polygon extents
        /// </summary>
        public List<Vector3> vertices;

        /// <summary>
        /// (Optional) texture coordinates (UVs) for polygon extents
        /// Will be present if vertices are present
        /// </summary>
        public List<Vector2> textureCoordinates;

        /// <summary>
        /// (Optional) normal vectors for polygon extents
        /// Will be present if vertices are present
        /// </summary>
        public List<Vector3> normals;

        /// <summary>
        /// (Optional) indices (triangles) for polygon extents
        /// Will be present if vertices are present
        /// </summary>
        public List<int> indices;

        /// <inheritdoc />
        public override string ToString()
        {
            const string str = "ID: {0}, Extents: {1} Pose: {2}";
            return String.Format(str, m_ID, m_Extents, m_Pose);
        }

        /// <inheritdoc />
        public override int GetHashCode() { return m_ID.GetHashCode(); }

        /// <inheritdoc />
        public bool Equals(MRPlane other) { return m_ID.Equals(other.m_ID); }

        /// <summary>
        /// Get the bounds of the <c>MRPlane</c>
        /// </summary>
        /// <param name="cameraOffset">Camera offset</param>
        /// <param name="minBound">Minimum bounds size</param>
        /// <returns>Bounds of the <c>MRPlane</c></returns>
        public Bounds GetWorldBounds(IUsesCameraOffset cameraOffset, float minBound)
        {
            var worldPose = cameraOffset.ApplyOffsetToPose(pose);
            var worldCenter = worldPose.position + worldPose.rotation * center;

            var size = new Vector3(extents.x * 0.5f, 0, extents.y * 0.5f);
            k_Corners[0] = size;
            size.x *= -1;
            k_Corners[1] = size;

            var rotation = pose.rotation;
            var position = pose.position + rotation * center;
            size = Vector3.zero;
            foreach (var corner in k_Corners)
            {
                // Get corner position in plane space
                var localVertex = rotation * corner + position;
                // Get corner position in session space
                localVertex = cameraOffset.ApplyOffsetToPosition(localVertex) - worldCenter;
                var val = localVertex.x;
                var absVal = val > 0 ? val : -val;
                if (absVal > size.x)
                    size.x = absVal;

                val = localVertex.y;
                absVal = val > 0 ? val : -val;
                if (absVal > size.y)
                    size.y = absVal;

                val = localVertex.z;
                absVal = val > 0 ? val : -val;
                if (absVal > size.z)
                    size.z = absVal;
            }

            size *= 2;

            if (size.x < minBound)
                size.x = minBound;

            if (size.y < minBound)
                size.y = minBound;

            if (size.z < minBound)
                size.z = minBound;

            return new Bounds(worldCenter, size);
        }
    }
}

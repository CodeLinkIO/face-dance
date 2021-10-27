using System;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public struct MarsMarkerDefinition : IEquatable<MarsMarkerDefinition>
    {
#pragma warning disable 649
        [SerializeField]
        bool m_SpecifySize;

        [SerializeField]
        Vector2 m_Size;

        [SerializeField]
        string m_Label;

        [SerializeField]
        Texture2D m_Texture;

        [SerializeField]
        SerializableGuid m_MarkerDefinitionId;
#pragma warning restore 649

        internal SerializableGuid MarkerDefinitionId { set => m_MarkerDefinitionId = value; }

        /// <summary>
        /// The <c>Guid</c> associated with this marker. The guid is generated for each new marker definition created.
        /// </summary>
        public Guid MarkerId => m_MarkerDefinitionId.guid;

        /// <summary>
        /// The size of the marker image, in meters. This can improve marker detection,
        /// and may be required by some platforms.
        /// </summary>
        public Vector2 Size
        {
            get => m_Size;
            set => m_Size = value;
        }

        /// <summary>
        /// The source texture whose image this marker represents.
        /// </summary>
        public Texture2D Texture
        {
            get => m_Texture;
            set => m_Texture = value;
        }

        /// <summary>
        /// An optional label associated with this marker, for a user to identify a particular marker from script in
        /// the case of a condition that matches multiple images.
        /// </summary>
        public string Label
        {
            get => m_Label;
            set => m_Label = value;
        }

        /// <summary>
        /// Must be set to true for <see cref="Size"/> to be used.
        /// </summary>
        public bool SpecifySize
        {
            get => m_SpecifySize;
            internal set => m_SpecifySize = value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is MarsMarkerDefinition other && Equals(other);
        }

        /// <inheritdoc />
        public bool Equals(MarsMarkerDefinition other)
        {
            return MarkerId == other.MarkerId;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = m_Size.GetHashCode();
                hashCode = (hashCode * 397) ^ (m_Label != null ? m_Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (m_Texture != null ? m_Texture.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}

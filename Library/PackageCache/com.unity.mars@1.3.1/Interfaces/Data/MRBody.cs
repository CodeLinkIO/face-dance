using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked body data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    [Obsolete(k_ObsoleteMessage)]
    public struct MRBody : IMRTrackable, IEquatable<MRBody>
    {
        const string k_ObsoleteMessage = "MRBody is obsolete. Use MarsBody instead";

        /// <summary>
        /// The ID of this body as determined by the provider
        /// </summary>
        public MarsTrackableId id { get; set; }

        /// <summary>
        /// The pose of this body
        /// </summary>
        public Pose pose { get; set; }

        /// <summary>
        /// World poses of available body landmarks
        /// </summary>
        public Dictionary<MRBodyLandmark, Pose> landmarkPoses { get; set; }

        /// <summary>
        /// Bounds of available body landmarks
        /// </summary>
        public Dictionary<MRBodyLandmark, Rect> landmarkBounds { get; set; }

        /// <summary>
        /// Create a trackable <c>MRBody</c> data in MARS
        /// </summary>
        /// <param name="pose">Pose of the trackable <c>MRBody</c>.</param>
        public MRBody(Pose pose) : this()
        {
            this.pose = pose;
        }

        /// <inheritdoc />
        public override int GetHashCode() { return id.GetHashCode(); }

        /// <inheritdoc />
        public bool Equals(MRBody other) { return id.Equals(other.id); }
    }
}

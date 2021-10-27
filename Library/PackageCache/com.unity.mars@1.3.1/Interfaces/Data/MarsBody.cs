using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked body data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public struct MarsBody : IMarsBody
    {
        /// <summary>
        /// The height for a stand-in human body, used as a basis for scaling
        /// </summary>
        public static float BodyDefaultHeight = 1.7216285067479f; // Estimate of the Unity default avatar height that also matches with the ARKit control rig

        /// <summary>
        /// The trackable ID of this body
        /// </summary>
        public MarsTrackableId id { get; set; }

        /// <summary>
        /// The pose of the root bone of this body
        /// </summary>
        public Pose pose { get; set; }

        /// <summary>
        /// The Mecanim muscle data for this body
        /// </summary>
        public HumanPose BodyPose { get; set; }

        /// <summary>
        /// The height of this body
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// (Optional) Lengths of each bone of this body, corresponding to the Mecanim humanoid
        /// </summary>
        public List<float> BoneLengths { get; set; }
    }
}

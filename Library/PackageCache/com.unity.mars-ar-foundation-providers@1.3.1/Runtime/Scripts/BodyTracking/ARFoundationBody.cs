#if ARFOUNDATION_4_OR_NEWER
using System.Collections.Generic;
using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Data for a human body tracked by AR Foundation
    /// </summary>
    public class ARFoundationBody : IMarsBody
    {
        readonly MarsTrackableId m_Id;
        readonly List<float> m_BoneLengths = new List<float>();

        internal HumanPose BodyPoseInternal;

        /// <summary>
        /// The trackable ID of this body
        /// </summary>
        public MarsTrackableId id { get { return m_Id; } }

        /// <summary>
        /// The Pose for the root of this body's rig
        /// </summary>
        public Pose pose { get; internal set; }

        /// <summary>
        /// The HumanPose struct containing Mecanim data for this body
        /// </summary>
        public HumanPose BodyPose { get { return BodyPoseInternal; }  }

        /// <summary>
        /// The height of this body in meters
        /// </summary>
        public float Height { get; internal set; }

        /// <summary>
        /// The lengths of this body's bones in meters
        /// </summary>
        public List<float> BoneLengths { get { return m_BoneLengths; } }

        /// <summary>
        /// The AR Foundation Trackable this body is based off of
        /// </summary>
        public ARHumanBody DeviceData { get; internal set; }

        /// <summary>
        /// Create a new ARFoundationBody
        /// </summary>
        /// <param name="id">The trackable ID of this body</param>
        public ARFoundationBody(MarsTrackableId id) { m_Id = id; }
    }
}
#endif

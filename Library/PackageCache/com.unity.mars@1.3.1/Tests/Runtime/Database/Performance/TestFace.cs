using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    class TestFace : IMRFace
    {
        readonly Dictionary<MRFaceLandmark, Pose> m_LandmarkPoses = new Dictionary<MRFaceLandmark, Pose>();
        readonly Dictionary<MRFaceExpression, float> m_Expressions = new Dictionary<MRFaceExpression, float>();

        /// <summary>
        /// The id of this face as determined by the provider
        /// </summary>
        public MarsTrackableId id { get; internal set; }

        /// <summary>
        /// The pose of this face
        /// </summary>
        public Pose pose { get; internal set; }

        /// <summary>
        /// A mesh for this face, if one exists
        /// </summary>
        public Mesh Mesh { get; internal set; }

        /// <summary>
        /// World poses of available face landmarks
        /// </summary>
        public Dictionary<MRFaceLandmark, Pose> LandmarkPoses { get { return m_LandmarkPoses; } }

        /// <summary>
        /// 0-1 coefficients representing the display of available facial expressions
        /// </summary>
        public Dictionary<MRFaceExpression, float> Expressions { get { return m_Expressions; } }
    }
}

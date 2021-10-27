using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Data.ARFoundation
{
    class ARFoundationFace : IMRFace
    {
        readonly MarsTrackableId m_Id;
        readonly Mesh m_Mesh = new Mesh();
        readonly Dictionary<MRFaceLandmark, Pose> m_LandmarkPoses = new Dictionary<MRFaceLandmark, Pose>();
        readonly Dictionary<MRFaceExpression, float> m_Expressions = new Dictionary<MRFaceExpression, float>();

        public MarsTrackableId id { get { return m_Id; } }
        public Pose pose { get; internal set; }
        public Mesh Mesh { get { return m_Mesh; } }
        public Dictionary<MRFaceLandmark, Pose> LandmarkPoses { get { return m_LandmarkPoses; } }
        public Dictionary<MRFaceExpression, float> Expressions { get { return m_Expressions; } }
        public MARSTrackingState TrackingState { get; internal set; }

        public ARFoundationFace(MarsTrackableId id) { m_Id = id; }
    }
}

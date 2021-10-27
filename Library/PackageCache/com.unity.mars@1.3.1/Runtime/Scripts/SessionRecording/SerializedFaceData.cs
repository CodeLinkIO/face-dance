using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Serialized container for recorded face data
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS.Recording")]
    public struct SerializedFaceData
    {
        [SerializeField]
        MarsTrackableId m_ID;

        [SerializeField]
        Pose m_Pose;

        [SerializeField]
        Mesh m_Mesh;

        [SerializeField]
        Pose[] m_LandmarkPoses;

        [SerializeField]
        float[] m_ExpressionValues;

        /// <summary>
        /// The id of this face
        /// </summary>
        public MarsTrackableId ID => m_ID;

        /// <summary>
        /// The pose of this face
        /// </summary>
        public Pose Pose => m_Pose;

        /// <summary>
        /// A mesh for this face, if one exists
        /// </summary>
        public Mesh Mesh => m_Mesh;

        /// <summary>
        /// Array of world poses of available face landmarks
        /// </summary>
        public Pose[] LandmarkPoses => m_LandmarkPoses;

        /// <summary>
        /// Array of 0-1 coefficients representing the display of available facial expressions
        /// </summary>
        public float[] ExpressionValues => m_ExpressionValues;

        /// <summary>
        /// Constructs a <see cref="SerializedFaceData"/> from an <see cref="IMRFace"/>
        /// </summary>
        /// <param name="face">Face data to serialize</param>
        /// <param name="landmarkEnumValues">Enumeration values to map 1:1 with serialized array of face landmark poses</param>
        /// <param name="expressionEnumValues">Enumeration values to map 1:1 with serialized array of face expression coefficients</param>
        public SerializedFaceData(IMRFace face, MRFaceLandmark[] landmarkEnumValues, MRFaceExpression[] expressionEnumValues)
        {
            m_ID = face.id;
            m_Pose = face.pose;
            m_Mesh = face.Mesh;

            var landmarksCount = landmarkEnumValues.Length;
            m_LandmarkPoses = new Pose[landmarksCount];
            for (var i = 0; i < landmarksCount; i++)
            {
                m_LandmarkPoses[i] = face.LandmarkPoses[landmarkEnumValues[i]];
            }

            var expressionsCount = expressionEnumValues.Length;
            m_ExpressionValues = new float[expressionsCount];
            for (var i = 0; i < expressionsCount; i++)
            {
                m_ExpressionValues[i] = face.Expressions[expressionEnumValues[i]];
            }
        }
    }
}

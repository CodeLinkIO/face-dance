using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked face data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IMRFace : IMRTrackable
    {
        /// <summary>
        /// A mesh for this face, if one exists
        /// </summary>
        Mesh Mesh { get; }

        /// <summary>
        /// World poses of available face landmarks
        /// </summary>
        Dictionary<MRFaceLandmark, Pose> LandmarkPoses { get; }

        /// <summary>
        /// 0-1 coefficients representing the display of available facial expressions
        /// </summary>
        Dictionary<MRFaceExpression, float> Expressions { get; }
    }
}

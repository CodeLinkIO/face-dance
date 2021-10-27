using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Event for facial expression recordings
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public struct FaceExpressionDataEvent
    {
        public double Time;
        public MRFaceExpression Expression;
        public float Coefficient;
        public bool Engaged;
    }
}

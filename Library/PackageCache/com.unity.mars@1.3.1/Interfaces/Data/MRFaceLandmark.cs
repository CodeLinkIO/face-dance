using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Enumerates the types of tracked face landmarks
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum MRFaceLandmark
    {
        /// <summary>Left eye</summary>
        LeftEye,
        /// <summary>Right eye</summary>
        RightEye,
        /// <summary>Left eyebrow</summary>
        LeftEyebrow,
        /// <summary>Right eyebrow</summary>
        RightEyebrow,
        /// <summary>Nose bridge</summary>
        NoseBridge,
        /// <summary>Nose tip</summary>
        NoseTip,
        /// <summary>Mouth</summary>
        Mouth,
        /// <summary>Upper lip</summary>
        UpperLip,
        /// <summary>Lower lip</summary>
        LowerLip,
        /// <summary>Left ear</summary>
        LeftEar,
        /// <summary>Right ear</summary>
        RightEar,
        /// <summary>Chin</summary>
        Chin
    }

    /// <summary>
    /// Use to compare <c>MRFaceLandmark</c> types
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class MRFaceLandmarkComparer : IEqualityComparer<MRFaceLandmark>
    {
        /// <inheritdoc />
        public bool Equals(MRFaceLandmark x, MRFaceLandmark y)
        {
            return x == y;
        }

        /// <inheritdoc />
        public int GetHashCode(MRFaceLandmark obj)
        {
            return (int)obj;
        }
    }
}

using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Enumerates the types of tracked body landmarks
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum MRBodyLandmark
    {
        /// <summary>Head landmark</summary>
        Head,
        /// <summary>Body Landmark</summary>
        Body
    }

    /// <summary>
    /// Use to compare <c>MRBodyLandmark</c> types
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class MRBodyLandmarkComparer : IEqualityComparer<MRBodyLandmark>
    {
        /// <inheritdoc />
        public bool Equals(MRBodyLandmark x, MRBodyLandmark y)
        {
            return x == y;
        }

        /// <inheritdoc />
        public int GetHashCode(MRBodyLandmark obj)
        {
            return (int)obj;
        }
    }
}

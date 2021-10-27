using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for hit test results
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public struct MRHitTestResult
    {
        /// <summary>
        /// The position and orientation of the surface that was hit
        /// </summary>
        public Pose pose { get; set; }
    }
}

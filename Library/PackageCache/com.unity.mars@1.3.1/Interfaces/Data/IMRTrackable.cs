using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked object data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IMRTrackable
    {
        /// <summary>
        /// The id of this tracked object
        /// </summary>
        MarsTrackableId id { get; }

        /// <summary>
        /// The pose of this tracked object
        /// </summary>
        Pose pose { get; }
    }
}

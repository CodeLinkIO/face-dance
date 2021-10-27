using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Interface for a representation of a single real-world thing
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IMRObject
    {
        /// <summary>
        /// The name of the object
        /// </summary>
        string name { get; set; }
    }
}

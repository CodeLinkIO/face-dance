using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Interface for a recorded MR data provider
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public interface IRecordedDataProvider
    {
        /// <summary>
        /// Remove all provided data. This is called when a looping recording reaches its duration.
        /// </summary>
        void ClearData();
    }
}

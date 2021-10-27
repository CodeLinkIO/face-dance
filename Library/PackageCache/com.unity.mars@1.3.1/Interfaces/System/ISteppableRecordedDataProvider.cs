using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Interface for a recorded MR data provider that updates its data each time the Timeline PlayableGraph is evaluated
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public interface ISteppableRecordedDataProvider : IRecordedDataProvider
    {
        /// <summary>
        /// Update provided data. This is called after the Timeline PlayableGraph is evaluated, due to either a
        /// Mars Update or a manual change in time.
        /// </summary>
        void StepRecordedData();
    }
}

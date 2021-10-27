using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Records data from an MR session
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class DataRecorder
    {
        float m_StartTime;

        public bool IsRecording { get; private set; }

        /// <summary>
        /// Time since the start of recording
        /// </summary>
        protected float TimeFromStart { get { return Time.time - m_StartTime; } }

        /// <summary>
        /// If not recording, starts recording data.
        /// If recording, records any last data if needed and then stops recording data.
        /// </summary>
        public void ToggleRecording()
        {
            IsRecording = !IsRecording;
            if (IsRecording)
            {
                m_StartTime = Time.time;
                Setup();
            }
            else
            {
                FinalizeRecording();
                TearDown();
            }
        }

        /// <summary>
        /// If recording, stops recording data
        /// </summary>
        public void CancelRecording()
        {
            if (!IsRecording)
                return;

            IsRecording = false;
            TearDown();
        }

        /// <summary>
        /// Try to add recorded data to a Timeline and create an object that references this recorded data
        /// </summary>
        /// <param name="timeline">The Timeline that holds recorded data</param>
        /// <param name="newAssets">List to be filled out with newly created Assets other than the Data Recording</param>
        /// <returns>Object that references Timeline data for the recording, or null if creation fails</returns>
        public abstract DataRecording TryCreateDataRecording(TimelineAsset timeline, List<Object> newAssets);

        /// <summary>
        /// Setup upon the start of recording
        /// </summary>
        protected virtual void Setup() { }

        /// <summary>
        /// Tear down upon the end of recording. MR data is not guaranteed to exist upon tear down, so this
        /// method should not record any data.
        /// </summary>
        protected virtual void TearDown() { }

        /// <summary>
        /// Records any last data if needed before tear down
        /// </summary>
        protected virtual void FinalizeRecording() { }
    }
}

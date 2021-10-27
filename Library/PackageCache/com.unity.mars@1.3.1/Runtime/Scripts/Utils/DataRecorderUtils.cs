using System;
using Unity.MARS.MARSUtils;
using Unity.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS.Recording
{
    static class DataRecorderUtils
    {
        const float k_TimeStepOffsetFactor = 0.25f;

        public static double? TryGetAppendedDataTimestamp()
        {
            // Subtracting some fraction of time step is a way to accommodate a quirk of recording while a recording is playing.
            // Recordings are played back at increments of MarsTime.TimeStep. So when we append data to a recording
            // we have to make sure the timestamps are not on exact increments, otherwise the data could get played back
            // at the wrong frame in MarsTime due to rounding errors.
#if UNITY_EDITOR
            var recordingDirector = EditorOnlyDelegates.GetCurrentRecordingDirector();
            if (recordingDirector != null)
                return Math.Max(recordingDirector.CurrentTime - MarsTime.TimeStep * k_TimeStepOffsetFactor, 0d);
#endif
            return null;
        }
    }
}

using Unity.MARS.Data.Recorded;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace UnityEditor.MARS.Data.Recorded
{
    /// <summary>
    /// Utility methods for session recording
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public static class SessionRecordingUtils
    {
        /// <summary>
        /// Create a blank <c>TimelineAsset</c> containing a <c>SessionRecordingInfo</c> asset at a location
        /// </summary>
        /// <param name="path">Path to create the asset at</param>
        /// <returns>New blank <c>SessionRecordingInfo</c> asset</returns>
        public static SessionRecordingInfo CreateSessionRecordingAsset(string path)
        {
            var timeline = ScriptableObject.CreateInstance<TimelineAsset>();
            AssetDatabase.CreateAsset(timeline, path);
            var recordingInfo = SessionRecordingInfo.Create(timeline);
            AssetDatabase.AddObjectToAsset(recordingInfo, timeline);
            return recordingInfo;
        }
    }
}

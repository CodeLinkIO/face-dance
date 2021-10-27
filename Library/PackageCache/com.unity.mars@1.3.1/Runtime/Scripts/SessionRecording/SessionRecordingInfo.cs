using System.Collections.Generic;
using Unity.MARS.Recording;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// Holds metadata about an MR session recording
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class SessionRecordingInfo : ScriptableObject
    {
        [SerializeField]
        TimelineAsset m_Timeline;

        [SerializeField]
        List<DataRecording> m_DataRecordings = new List<DataRecording>();

        [SerializeField]
        List<GameObject> m_SyntheticEnvironments = new List<GameObject>();

        [SerializeField]
        [Tooltip("Sets the wrap mode that the Playable Director will be set to use when the recording is set up in simulation.")]
        DirectorWrapMode m_DefaultExtrapolationMode;

        [SerializeField]
        string m_CloudResourceId;

        /// <summary>
        /// The <see cref="TimelineAsset"/> containing data recording tracks
        /// </summary>
        public TimelineAsset Timeline => m_Timeline;

        public string CloudResourceId
        {
            get { return m_CloudResourceId; }
            set { m_CloudResourceId = value; }
        }

        /// <summary>
        /// Whether the time in recording playback maps 1:1 with MARS Time in Simulation
        /// </summary>
        public bool ControlsMarsLifecycle => m_DataRecordings.Count > 0;

        /// <summary>
        /// The wrap mode that the Playable Director will be set to use when the recording is set up in simulation
        /// </summary>
        public DirectorWrapMode DefaultExtrapolationMode
        {
            get => m_DefaultExtrapolationMode;
            set => m_DefaultExtrapolationMode = value;
        }

        /// <summary>
        /// Name of the timeline to use as the display name
        /// </summary>
        public string DisplayName { get => Timeline.name; }

        /// <summary>
        /// Whether this recording has a MarsVideoPlayableTrack
        /// </summary>
        public bool HasVideo
        {
            get
            {
                var tracks = m_Timeline.GetOutputTracks();
                foreach (var track in tracks)
                {
                    if (track is MarsVideoPlayableTrack)
                        return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Creates an instance of a <see cref="SessionRecordingInfo"/> referencing a <see cref="TimelineAsset"/>
        /// </summary>
        /// <param name="timeline">The <see cref="TimelineAsset"/> containing data recording tracks</param>
        /// <returns>The created <see cref="SessionRecordingInfo"/> instance</returns>
        public static SessionRecordingInfo Create(TimelineAsset timeline)
        {
            var recordingInfo = CreateInstance<SessionRecordingInfo>();
            recordingInfo.name = timeline.name + " Info";
            recordingInfo.m_Timeline = timeline;
            return recordingInfo;
        }

        public void AddDataRecording(DataRecording recording) { m_DataRecordings.Add(recording); }

        public void GetDataRecordings(List<DataRecording> dataRecordings) { dataRecordings.AddRange(m_DataRecordings); }

        public void AddSyntheticEnvironment(GameObject environmentPrefab) { m_SyntheticEnvironments.Add(environmentPrefab); }

        public void GetSyntheticEnvironments(List<GameObject> environments) { environments.AddRange(m_SyntheticEnvironments); }
    }
}

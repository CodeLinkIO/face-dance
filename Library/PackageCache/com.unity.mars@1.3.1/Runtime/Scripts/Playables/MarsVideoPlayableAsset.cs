using System;
using Unity.MARS.Recording;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Timeline;
using UnityEngine.Video;

namespace Unity.MARS.Data.Recorded
{
    /// <summary>
    /// A Playable Asset for a Video Clip that plays in MARS simulation
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS.Recording")]
    public class MarsVideoPlayableAsset : PlayableAsset
    {
        [SerializeField, NotKeyable]
        [Tooltip("The Video Clip to play")]
        VideoClip m_VideoClip;

        [SerializeField, NotKeyable]
        [Tooltip("The focal length of the camera used to record the video, in pixels")]
        float m_FocalLength = SimulationVideoContextSettings.DefaultFocalLength;

        [SerializeField, NotKeyable]
        [Tooltip("The facing direction of the camera used to record the video")]
        CameraFacingDirection m_FacingDirection = CameraFacingDirection.User;

        [SerializeField, NotKeyable]
        [Tooltip("Rotation about the forward axis, in degrees, to apply to the quad rendering the video")]
        float m_ZRotation;

        /// <summary>
        /// The Video Clip to play
        /// </summary>
        public VideoClip VideoClip
        {
            get => m_VideoClip;
            set => m_VideoClip = value;
        }

        /// <summary>
        /// The amount of time, in seconds, to wait at the start of the Timeline Clip before playing the video.
        /// This should be enough time for the Video Player to prepare for playback.
        /// </summary>
        [Obsolete("PreparationTime is no longer used and is being deprecated", false)]
        public double PreparationTime { get; set; }

        /// <summary>
        /// The focal length of the camera used to record the video, in pixels
        /// </summary>
        public float FocalLength
        {
            get => m_FocalLength;
            set => m_FocalLength = value;
        }

        /// <summary>
        /// Rotation about the forward axis, in degrees, to apply to the quad rendering the video
        /// </summary>
        public float ZRotation
        {
            get => m_ZRotation;
            set => m_ZRotation = value;
        }

        /// <summary>
        /// The facing direction of the camera used to record the video
        /// </summary>
        public CameraFacingDirection FacingDirection
        {
            get => m_FacingDirection;
            set => m_FacingDirection = value;
        }

        /// <summary>
        /// Inject a Mars Video Playable Behaviour into the given graph
        /// </summary>
        /// <param name="graph">The graph to inject playables into</param>
        /// <param name="owner">The game object which initiated the build. This must have a RecordedSessionDirector component.</param>
        /// <returns>The playable injected into the graph</returns>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<MarsVideoPlayableBehaviour>.Create(graph);
            var sessionDirector = owner.GetComponent<RecordedSessionDirector>();
            playable.GetBehaviour().Setup(sessionDirector, this);
            return playable;
        }
    }
}

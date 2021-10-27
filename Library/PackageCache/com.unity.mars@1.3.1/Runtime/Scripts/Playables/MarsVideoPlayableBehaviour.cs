using Unity.MARS.Recording;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Video;

namespace Unity.MARS.Data.Recorded
{
    [MovedFrom("Unity.MARS.Recording")]
    public class MarsVideoPlayableBehaviour : PlayableBehaviour
    {
        RecordedSessionDirector m_SessionDirector;
        SimulationVideoContextManager m_VideoContextManager;
        VideoPlayer m_VideoPlayer;
        double m_VideoLength;

        internal void Setup(RecordedSessionDirector sessionDirector, MarsVideoPlayableAsset videoPlayableAsset)
        {
            if (sessionDirector == null)
            {
                Debug.LogWarning($"{nameof(MarsVideoPlayableBehaviour)} must be used with a {nameof(RecordedSessionDirector)}");
                return;
            }

            var videoClip = videoPlayableAsset.VideoClip;
            if (videoClip == null)
            {
                Debug.LogWarning($"Video Clip is null. You must assign the Video Clip on the {nameof(MarsVideoPlayableAsset)}");
                return;
            }

            m_VideoContextManager = ModuleLoaderCore.instance.GetModule<SimulationVideoContextManager>();
            if (m_VideoContextManager == null)
                return;

            m_SessionDirector = sessionDirector;
            m_VideoPlayer = m_VideoContextManager.VideoPlayer;

            if (sessionDirector.IsStarting)
            {
                // The playable behavior can get destroyed and recreated while the recording is playing.
                // Only set up the video player and render texture if the recording is about to start playing.
                m_VideoContextManager.SetupFromVideoPlayable(videoPlayableAsset);
                m_VideoPlayer.timeReference = VideoTimeReference.ExternalTime;
                m_VideoPlayer.isLooping = false;

                m_VideoPlayer.Prepare();
            }

            m_VideoLength = m_VideoPlayer.length;
            m_SessionDirector.Played += OnSessionDirectorPlayed;
            m_SessionDirector.Paused += OnSessionDirectorPaused;
            m_SessionDirector.Stopping += OnSessionDirectorStopping;
            m_SessionDirector.TimeCorrected += OnSessionDirectorTimeCorrected;
            m_VideoPlayer.prepareCompleted += OnVideoPlayerPrepared;
        }

        void OnVideoPlayerPrepared(VideoPlayer player)
        {
            if (m_SessionDirector == null || m_SessionDirector.IsSyncing)
                return;

            m_VideoPlayer.time = m_SessionDirector.CurrentTime;
        }

        public override void OnPlayableDestroy(Playable playable)
        {
            if (m_VideoPlayer != null)
                m_VideoPlayer.prepareCompleted -= OnVideoPlayerPrepared;

            if (m_SessionDirector == null)
                return;

            m_SessionDirector.Played -= OnSessionDirectorPlayed;
            m_SessionDirector.Paused -= OnSessionDirectorPaused;
            m_SessionDirector.Stopping -= OnSessionDirectorStopping;
            m_SessionDirector.TimeCorrected -= OnSessionDirectorTimeCorrected;
        }

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            // The playable graph can sometimes evaluate outside of our control, due to the way the Timeline Window
            // takes control of playback, so we check if this is a manual evaluation from RecordedSessionDirector
            if (m_VideoPlayer == null || !m_VideoPlayer.isPrepared || !m_SessionDirector.IsEvaluating || m_SessionDirector.IsSyncing)
                return;

            var time = playable.GetTime();
            if (time >= m_VideoLength)
            {
                m_VideoPlayer.time = m_VideoLength;
                return;
            }

            var videoTime = time;
            m_VideoPlayer.externalReferenceTime = videoTime;

            if (!m_VideoPlayer.isPlaying)
            {
                m_VideoPlayer.time = videoTime;
                if (playable.GetGraph().IsPlaying())
                    m_VideoPlayer.Play();
            }
        }

        void OnSessionDirectorPlayed()
        {
            if (m_VideoPlayer == null || m_VideoPlayer.time >= m_VideoLength || !m_VideoPlayer.isPrepared)
                return;

            m_VideoPlayer.Play();
        }

        void OnSessionDirectorPaused()
        {
            if (m_VideoPlayer == null)
                return;

            m_VideoPlayer.time = m_SessionDirector.CurrentTime;
            m_VideoPlayer.Pause();
        }

        void OnSessionDirectorStopping()
        {
            if (m_VideoPlayer == null)
                return;

            m_VideoPlayer.Stop();
            m_VideoPlayer.clip = null;
        }

        void OnSessionDirectorTimeCorrected()
        {
            if (m_VideoPlayer == null)
                return;

            var videoTime = m_SessionDirector.CurrentTime;
            m_VideoPlayer.externalReferenceTime = videoTime;
            if (!m_VideoPlayer.isPlaying)
                m_VideoPlayer.time = videoTime;
        }
    }
}

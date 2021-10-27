using System;
using System.Collections.Generic;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Unity.MARS.Recording
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(PlayableDirector))]
    class RecordedSessionDirector : MonoBehaviour, ISimulatable
    {
        struct NotificationData
        {
            public INotification Notification;
            public double Time;
            public Playable Origin;
        }

        double m_Duration;
        bool m_Paused;
        bool m_ControlsMarsLifecycle;
        bool m_ShouldResume;

        readonly List<IRecordedDataProvider> m_RecordedDataProviders = new List<IRecordedDataProvider>();

        int m_NotificationsSent;
        readonly List<NotificationData> m_TimelineNotifications = new List<NotificationData>();
        readonly Dictionary<Playable, List<INotificationReceiver>> m_NotificationReceivers =
            new Dictionary<Playable, List<INotificationReceiver>>();

        public PlayableDirector Director { get; private set; }

        public double PlaybackPauseTime { get; private set; }

        public double CurrentTime { get; set; }

        public bool IsStarting { get; private set; }

        public bool IsPlaying { get; private set; }

        public bool IsEvaluating { get; private set; }
        public bool IsSyncing { get; private set; }

        public event Action<double> TimeUpdated;
        public event Action Played;
        public event Action Paused;
        public event Action Stopping;
        public event Action TimeCorrected;
        public event Action EndReached;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<DataRecording> k_DataRecordings = new List<DataRecording>();

        public void SetupFromRecordingInfo(SessionRecordingInfo recordingInfo, List<IFunctionalityProvider> providers)
        {
            k_DataRecordings.Clear();
            Director = GetComponent<PlayableDirector>();
            Director.playableAsset = recordingInfo.Timeline;
            Director.timeUpdateMode = DirectorUpdateMode.Manual;
            Director.extrapolationMode = recordingInfo.DefaultExtrapolationMode;
            m_Duration = Director.duration;
            m_ControlsMarsLifecycle = recordingInfo.ControlsMarsLifecycle;
            recordingInfo.GetDataRecordings(k_DataRecordings);
            foreach (var recording in k_DataRecordings)
            {
                recording.SetupDataProviders(Director, providers);
            }

            m_RecordedDataProviders.Clear();
            foreach (var provider in providers)
            {
                var recordedProvider = provider as IRecordedDataProvider;
                if (recordedProvider != null)
                    m_RecordedDataProviders.Add(recordedProvider);
            }

            k_DataRecordings.Clear();
        }

        public void SetPlaybackParams(float timeScale, double pauseTime, bool syncing)
        {
            MarsTime.TimeScale = timeScale;
            PlaybackPauseTime = pauseTime;
            IsSyncing = syncing;
        }

        void OnEnable()
        {
            if (Director == null || Director.playableAsset == null)
            {
                Debug.LogError(
                    $"You must call {nameof(SetupFromRecordingInfo)} on {nameof(RecordedSessionDirector)} before enabling it");

                enabled = false;
                return;
            }

            IsStarting = true;
            m_Paused = false;
            Director.RebuildGraph(); // Ensure new playables are created
            SetTime(0d);
            Director.Play();
            Director.played += OnResumed;
            Director.paused += OnPaused;
            Director.stopped += OnStopped;
            IsPlaying = true;
            IsStarting = false;
            Played?.Invoke();

            // Notifications do not fire from manual timeline updates.
            // https://answers.unity.com/questions/1665172/markers-and-signal-emitters-not-working-when-timel.html
            // We must sort notifications by time and then directly send them to receivers for manual evaluation.
            var playableGraph = Director.playableGraph;
            var outputCount = playableGraph.GetOutputCount();
            m_TimelineNotifications.Clear();
            m_NotificationReceivers.Clear();
            m_NotificationsSent = 0;
            for (var i = 0; i < outputCount; i++)
            {
                var output = playableGraph.GetOutput(i);
                var playable = output.GetSourcePlayable().GetInput(i);
                var track = output.GetReferenceObject() as TrackAsset;
                if (track == null || !(track is MarkerTrack))
                    continue;

                var targetObject = Director.GetGenericBinding(track);
                if (targetObject == null)
                    continue;

                var targetGameObject = targetObject as GameObject;
                var targetComponent = targetObject as Component;
                if (targetGameObject == null && targetComponent == null)
                    continue;

                var notificationReceivers = new List<INotificationReceiver>();
                if (targetGameObject != null)
                    targetGameObject.GetComponents(notificationReceivers);
                else
                    targetComponent.GetComponents(notificationReceivers);

                m_NotificationReceivers[playable] = notificationReceivers;

                foreach (var marker in track.GetMarkers())
                {
                    if (!(marker is INotification notification))
                        continue;

                    m_TimelineNotifications.Add(new NotificationData
                    {
                        Notification = notification,
                        Time = marker.time,
                        Origin = playable
                    });
                }
            }

            m_TimelineNotifications.Sort((first, second) => first.Time.CompareTo(second.Time));
        }

        void OnDisable()
        {
            // OnDisable can get called before OnEnable when starting simulation, so we have to make sure not to
            // reset state that is set right before this behavior runs.
            if (Director == null || !IsPlaying)
                return;

            m_ShouldResume = false;
            IsPlaying = false;
            IsSyncing = false;

            Stopping?.Invoke();
            Director.played -= OnResumed;
            Director.paused -= OnPaused;
            Director.stopped -= OnStopped;
            Director.Stop();
            SetTime(0d);
        }

        void OnResumed(PlayableDirector director)
        {
            if (m_ControlsMarsLifecycle)
                MarsTime.Play();

            PlaybackPauseTime = m_Duration;
            m_Paused = false;
            Played?.Invoke();
        }

        void OnPaused(PlayableDirector director)
        {
            m_Paused = true;
            IsSyncing = false;
            if (m_ControlsMarsLifecycle)
                MarsTime.Pause();

            Paused?.Invoke();
        }

        void OnStopped(PlayableDirector director)
        {
            if (Application.isPlaying)
                return;

            // Director can get stopped when the Timeline Editor's master director changes or when preview mode is disabled.
            // These should not interrupt the simulation, so we keep the director playing (or paused if it was paused).
            // We cannot do this immediately in case the Timeline Window is closing when we try to play.
            m_ShouldResume = true;
        }

        void Update()
        {
            if (!m_ShouldResume)
                return;

            m_ShouldResume = false;
            if (Director == null)
                return;

            // Temporarily unsubscribe from these events to avoid interfering with time scale during fast simulation
            Director.played -= OnResumed;
            Director.paused -= OnPaused;

            var wasPaused = m_Paused;
            SetTimeToCurrent(); // Time is set to 0 when the director stops, so we need to set it back to the expected time
            Director.Play();
            if (wasPaused)
                Director.Pause();

            Director.played += OnResumed;
            Director.paused += OnPaused;
            TimeCorrected?.Invoke();
        }

        public bool UpdateTimeAndEvaluate()
        {
            var playableGraph = Director.playableGraph;
            if (!playableGraph.IsValid() || !playableGraph.IsPlaying())
                return false;

            var loop = Director.extrapolationMode == DirectorWrapMode.Loop && !IsSyncing;
            var newTime = Director.time + MarsTime.TimeStep;
            var reachedDuration = newTime >= m_Duration;
            if (reachedDuration && loop)
            {
                foreach (var provider in m_RecordedDataProviders)
                {
                    provider.ClearData();
                }

                newTime -= m_Duration;
                m_NotificationsSent = 0;
            }

            var reachedPauseTime = newTime >= PlaybackPauseTime;
            if (reachedPauseTime)
                newTime = PlaybackPauseTime;

            SetTime(newTime);
            Evaluate();
            for (var i = m_NotificationsSent; i < m_TimelineNotifications.Count; i++)
            {
                var notificationData = m_TimelineNotifications[i];
                if (notificationData.Time > newTime)
                    break;

                SendNotification(notificationData);
            }

            if (reachedPauseTime)
                Director.Pause();

            if (reachedDuration)
                EndReached?.Invoke();

            return true;
        }

        public void Evaluate()
        {
            IsEvaluating = true;
            Director.Evaluate();
            IsEvaluating = false;
        }

        public void SetTimeToCurrent()
        {
            SetTime(CurrentTime);
        }

        void SetTime(double time)
        {
            Director.time = time;
            CurrentTime = time;
            TimeUpdated?.Invoke(time);
        }

        void SendNotification(NotificationData notificationData)
        {
            var origin = notificationData.Origin;
            var notification = notificationData.Notification;
            foreach (var receiver in m_NotificationReceivers[origin])
            {
                receiver.OnNotify(origin, notification, null);
            }

            m_NotificationsSent++;
        }
    }
}

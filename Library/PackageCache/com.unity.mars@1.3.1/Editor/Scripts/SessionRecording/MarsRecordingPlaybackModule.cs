using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.MARS;
using Unity.MARS.Data.Recorded;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Recording;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.Timeline;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Describes the state of Simulation in relation to the current time in the session recording Timeline
    /// </summary>
    [MovedFrom("Unity.MARS.Recording")]
    public enum SimulationTimeSyncState
    {
        /// <summary>
        /// Simulation is not using a Timeline
        /// </summary>
        NoTimeline,

        /// <summary>
        /// The state of Simulation reflects the current time in the Timeline
        /// </summary>
        Synced,

        /// <summary>
        /// The state of Simulation does not reflect the current time in the Timeline, and Simulation is primed to restart
        /// </summary>
        OutOfSync,

        /// <summary>
        /// Simulation has restarted and is running until it has reached the time in the Timeline at the moment of restart
        /// </summary>
        Syncing
    }

    /// <summary>
    /// Module that controls playback of a session recording Timeline in Simulation
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS.Recording")]
    public class MarsRecordingPlaybackModule : EditorScriptableSettings<MarsRecordingPlaybackModule>,
        IModuleDependency<QuerySimulationModule>, IModuleDependency<MARSSceneModule>, IModuleDependency<SimulationRecordingManager>,
        IModuleMarsUpdate, IModuleBehaviorCallbacks
    {
        /// <summary>
        /// Tooltip for when auto sync is enabled
        /// </summary>
        public const string AutoSyncTooltip = "When enabled, Simulation will automatically restart when the time in the session recording Timeline is changed";

        const int k_IgnoreTimeChangeEndFrame = 2;
        const string k_StubProvidersName = "Stub Providers";
        const string k_TimelineEditorAssemblyName = "Unity.Timeline.Editor";
        const string k_TimelineWindowTypeName = "UnityEditor.Timeline.TimelineWindow";
        const string k_TimelineEditorStatePropertyName = "state";
        const string k_PreviewModePropertyName = "previewMode";
        const string k_MasterSequencePropertyName = "masterSequence";
        const string k_SequenceStateTimePropertyName = "time";
        const BindingFlags k_TimelineEditorStatePropertyBindingFlags = BindingFlags.Static | BindingFlags.NonPublic;
        const BindingFlags k_PreviewModePropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public;
        const BindingFlags k_MasterSequencePropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public;
        const BindingFlags k_SequenceStateTimePropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public;

        static readonly Type k_TimelineWindowType;
        static readonly PropertyInfo k_TimelineEditorStateProperty;
        static readonly PropertyInfo k_PreviewModeProperty;
        static readonly PropertyInfo k_MasterSequenceProperty;
        static readonly PropertyInfo k_SequenceStateTimeProperty;

        [SerializeField]
        [Tooltip("Sets the amount of time to wait after changing time in the Timeline before restarting Simulation. " +
            "If another change happens during this time then the timer is reset.")]
        double m_TimeToFinalizeTimelineChange = 0.5d;

        [SerializeField]
        [Tooltip("Sets the scale at which Simulation time passes when syncing with the Timeline")]
        float m_TimelineSyncTimeScale = 60f;

        [SerializeField]
        [Tooltip(AutoSyncTooltip)]
        bool m_AutoSyncWithTimeChanges = true;

        QuerySimulationModule m_QuerySimulationModule;
        MARSSceneModule m_MarsSceneModule;
        SimulationRecordingManager m_SimulationRecordingManager;

        RecordedSessionDirector m_CurrentSessionDirector;
        SessionRecordingInfo m_CurrentRecordingInfo;
        EditorSlowTask m_ManualTimeChangeTask;
        PlayableDirector m_PreviousMasterDirector;
        bool m_ShouldShowTimelineOnSimStart;
        bool m_IgnoreTimeChangeFromWindow;
        int m_IgnoreTimeChangeFrame;

        readonly List<ISteppableRecordedDataProvider> m_SteppableDataProviders = new List<ISteppableRecordedDataProvider>();

        internal bool DisableRecordingPlayback { get; set; }

        /// <summary>
        /// Whether Simulation should automatically restart when the time in the session recording Timeline is changed
        /// </summary>
        public bool AutoSyncWithTimeChanges
        {
            get
            {
                return m_AutoSyncWithTimeChanges;
            }
            set
            {
                m_AutoSyncWithTimeChanges = value;
                EditorUtility.SetDirty(this);
                if (value && IsRecordingAvailable && TimelineSyncState == SimulationTimeSyncState.OutOfSync)
                {
                    m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);
                    m_QuerySimulationModule.RestartSimulationIfNeeded();
                }
            }
        }

        /// <summary>
        /// Whether Simulation is currently using a session recording
        /// </summary>
        public bool IsRecordingAvailable => m_CurrentSessionDirector != null;

        /// <summary>
        /// Whether the session recording for Simulation is currently playing
        /// </summary>
        public bool IsRecordingPlaying
        {
            get { return m_CurrentSessionDirector != null && m_CurrentSessionDirector.Director.state == PlayState.Playing; }
        }

        /// <summary>
        /// Whether there is an active session recording for Simulation and it is currently paused
        /// </summary>
        public bool IsRecordingPaused
        {
            get
            {
                return m_QuerySimulationModule != null && m_QuerySimulationModule.simulatingTemporal &&
                    m_CurrentSessionDirector != null && m_CurrentSessionDirector.Director.state == PlayState.Paused;
            }
        }

        /// <summary>
        /// The state of Simulation in relation to the current time in the session recording Timeline
        /// </summary>
        public SimulationTimeSyncState TimelineSyncState { get; private set; }

        /// <summary>
        /// Progress of time while Simulation is syncing with the Timeline. This is a value between 0 and 1 where 0 means
        /// Simulation has just started syncing and time is 0, and 1 means Simulation is done syncing and time is <see cref="SyncEndTime"/>.
        /// </summary>
        public float TimelineSyncProgress { get; private set; }

        /// <summary>
        /// The time at which Simulation finishes syncing with the Timeline. This is the time in the Timeline at the
        /// moment before Simulation automatically restarted.
        /// </summary>
        public double SyncEndTime { get; private set; }

        /// <summary>
        /// Called when recording playback has reached the end of the Timeline
        /// </summary>
        public event Action RecordingEndReached;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<IFunctionalityProvider> k_RecordedDataProviders = new List<IFunctionalityProvider>();

        static MarsRecordingPlaybackModule()
        {
            k_TimelineWindowType = ReflectionUtils.FindTypeInAssemblyByFullName(
                k_TimelineEditorAssemblyName, k_TimelineWindowTypeName);

            k_TimelineEditorStateProperty = typeof(TimelineEditor).GetProperty(
                k_TimelineEditorStatePropertyName, k_TimelineEditorStatePropertyBindingFlags);

            var windowStateType = k_TimelineEditorStateProperty.PropertyType;
            k_PreviewModeProperty = windowStateType.GetProperty(
                k_PreviewModePropertyName, k_PreviewModePropertyBindingFlags);

            k_MasterSequenceProperty = windowStateType.GetProperty(
                k_MasterSequencePropertyName, k_MasterSequencePropertyBindingFlags);

            k_SequenceStateTimeProperty = k_MasterSequenceProperty.PropertyType.GetProperty(
                k_SequenceStateTimePropertyName, k_SequenceStateTimePropertyBindingFlags);
        }

        /// <inheritdoc />
        void IModuleDependency<QuerySimulationModule>.ConnectDependency(QuerySimulationModule dependency) { m_QuerySimulationModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<MARSSceneModule>.ConnectDependency(MARSSceneModule dependency) { m_MarsSceneModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<SimulationRecordingManager>.ConnectDependency(SimulationRecordingManager dependency) { m_SimulationRecordingManager = dependency; }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            EditorApplication.update += EditorUpdate;
            QuerySimulationModule.BeforeTemporalSimulationRestart += OnBeforeTemporalSimulationRestart;
            QuerySimulationModule.addCustomProviders += OnBeforeSetupDefaultProviders;
            QuerySimulationModule.onTemporalSimulationStop += OnTemporalSimulationStop;
            QuerySimulationModule.BeforeCleanupProviders += OnBeforeCleanupProviders;
            QuerySimulationModule.OnOneShotSimulationStart += OnOneShotSimulationStart;
            m_MarsSceneModule.BeforeSetupDefaultProviders += OnBeforeSetupDefaultProviders;
            m_SimulationRecordingManager.RecordingOptionChanged += OnRecordingOptionChanged;
            EditorOnlyDelegates.GetCurrentRecordingDirector = () => m_CurrentSessionDirector;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            EditorApplication.update -= EditorUpdate;
            QuerySimulationModule.BeforeTemporalSimulationRestart -= OnBeforeTemporalSimulationRestart;
            QuerySimulationModule.addCustomProviders -= OnBeforeSetupDefaultProviders;
            QuerySimulationModule.onTemporalSimulationStop -= OnTemporalSimulationStop;
            QuerySimulationModule.BeforeCleanupProviders -= OnBeforeCleanupProviders;
            QuerySimulationModule.OnOneShotSimulationStart -= OnOneShotSimulationStart;
            m_MarsSceneModule.BeforeSetupDefaultProviders -= OnBeforeSetupDefaultProviders;
            m_SimulationRecordingManager.RecordingOptionChanged -= OnRecordingOptionChanged;
            EditorOnlyDelegates.GetCurrentRecordingDirector = () => null;
            m_CurrentRecordingInfo = null;
            m_ManualTimeChangeTask = null;
            TimelineSyncState = SimulationTimeSyncState.NoTimeline;
            TimelineSyncProgress = 0f;
            SyncEndTime = 0d;
            m_PreviousMasterDirector = null;
            m_ShouldShowTimelineOnSimStart = false;
            m_IgnoreTimeChangeFromWindow = false;
            m_IgnoreTimeChangeFrame = 0;
        }

        /// <inheritdoc />
        void IModuleMarsUpdate.OnMarsUpdate()
        {
            if (m_CurrentSessionDirector == null)
                return;

            if (!m_CurrentSessionDirector.UpdateTimeAndEvaluate())
                return;

            foreach (var provider in m_SteppableDataProviders)
            {
                provider.StepRecordedData();
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
            if (!MarsEditorUtils.SimulatingDiscovery)
                return;

            var showTimeline = m_ShouldShowTimelineOnSimStart && TimelineEditor.masterDirector != m_CurrentSessionDirector.Director;
            m_ShouldShowTimelineOnSimStart = false;
            if (m_CurrentSessionDirector == null)
                return;

            switch (TimelineSyncState)
            {
                case SimulationTimeSyncState.Synced:
                    m_CurrentSessionDirector.SetPlaybackParams(1f, m_CurrentSessionDirector.Director.duration, false);
                    break;
                case SimulationTimeSyncState.OutOfSync:
                    TimelineSyncState = SimulationTimeSyncState.Syncing;
                    TimelineSyncProgress = 0f;
                    m_CurrentSessionDirector.SetPlaybackParams(m_TimelineSyncTimeScale, SyncEndTime, true);
                    break;
            }

            if (showTimeline)
                Selection.activeGameObject = m_CurrentSessionDirector.gameObject;
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }

        void OnRecordingOptionChanged()
        {
            if (!Application.isPlaying)
                return;

            var simulationSettings = SimulationSettings.instance;
            var nextRecordingInfo = simulationSettings.GetCurrentRecording();

            // Using a different recording option means we can't just clear out data and add new data - we need to reset
            // the whole MARS lifecycle to setup new providers and reset Mars Time
            if (nextRecordingInfo != m_CurrentRecordingInfo)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        void OnBeforeTemporalSimulationRestart()
        {
            if (m_CurrentSessionDirector == null || !SimulationSettings.instance.IsUsingRecording)
                return;

            // Keep the recording director shown in the Timeline Window when restarting simulation
            var director = m_CurrentSessionDirector.Director;
            if (director == TimelineEditor.masterDirector)
                m_ShouldShowTimelineOnSimStart = true;

            // If simulation restarts and the recording has not changed, we want to catch up to the time we left off at
            if (m_CurrentRecordingInfo.ControlsMarsLifecycle && m_CurrentRecordingInfo == SimulationSettings.instance.GetCurrentRecording())
            {
                TimelineSyncState = SimulationTimeSyncState.OutOfSync;
                TimelineSyncProgress = 0f;
                SyncEndTime = Math.Min(director.time, director.duration);
                m_QuerySimulationModule.KeepDataBetweenSimulations = false;
            }
        }

        void OnBeforeSetupDefaultProviders(List<IFunctionalityProvider> providers)
        {
            var simulationSettings = SimulationSettings.instance;
            if (DisableRecordingPlayback || !simulationSettings.IsUsingRecording || !MarsEditorUtils.SimulatingDiscovery)
            {
                m_CurrentRecordingInfo = null;
                TimelineSyncState = SimulationTimeSyncState.NoTimeline;
                return;
            }

            var sessionDirectorGO = GameObjectUtils.Create("Session Director");

            // Deactivate until we've set up so that the session director does not receive OnEnable immediately
            sessionDirectorGO.SetActive(false);
            m_CurrentSessionDirector = sessionDirectorGO.AddComponent<RecordedSessionDirector>();
            var recordingInfo = simulationSettings.GetCurrentRecording();
            if (recordingInfo != m_CurrentRecordingInfo)
            {
                m_CurrentRecordingInfo = recordingInfo;
                SetStateToSynced();
            }

            k_RecordedDataProviders.Clear();
            m_CurrentSessionDirector.SetupFromRecordingInfo(recordingInfo, k_RecordedDataProviders);
            m_CurrentSessionDirector.TimeUpdated += OnDirectorTimeUpdated;
            m_CurrentSessionDirector.EndReached += OnDirectorEndReached;
            var director = m_CurrentSessionDirector.Director;
            director.played += OnDirectorPlayed;
            director.paused += OnDirectorPaused;
            director.stopped += OnDirectorStopped;
            sessionDirectorGO.SetActive(true);

            providers.AddRange(k_RecordedDataProviders);
            m_SteppableDataProviders.Clear();
            var hasPlanesProvider = false;
            var hasPointCloudProvider = false;
            foreach (var provider in k_RecordedDataProviders)
            {
                if (provider is ISteppableRecordedDataProvider steppableDataProvider)
                    m_SteppableDataProviders.Add(steppableDataProvider);

                if (provider is IProvidesPlaneFinding)
                    hasPlanesProvider = true;
                else if (provider is IProvidesPointCloud)
                    hasPointCloudProvider = true;
            }

            // If there are recorded planes or point cloud providers, we need to set up stub providers to make sure
            // the simulated discovery provider game object doesn't get created.
            if (hasPlanesProvider || hasPointCloudProvider)
            {
                var stubProvidersObj = GameObjectUtils.Create(k_StubProvidersName);
                var sessionProvider = stubProvidersObj.AddComponent<StubSessionProvider>();
                sessionProvider.SuppressWarnings = true;
                providers.Add(sessionProvider);
                if (!hasPlanesProvider)
                {
                    var planesProvider = stubProvidersObj.AddComponent<StubPlanesProvider>();
                    planesProvider.SuppressWarnings = true;
                    providers.Add(planesProvider);
                }
                else if (!hasPointCloudProvider)
                {
                    var pointCloudProvider = stubProvidersObj.AddComponent<StubPointCloudProvider>();
                    pointCloudProvider.SuppressWarnings = true;
                    providers.Add(pointCloudProvider);
                }
            }
        }

        void OnOneShotSimulationStart() { m_ShouldShowTimelineOnSimStart = false; }

        void OnTemporalSimulationStop()
        {
            if (m_CurrentSessionDirector == null || TimelineSyncState == SimulationTimeSyncState.OutOfSync)
                return;

            SetStateToSynced();
            SaveDirectorWindowTime();
        }

        void OnBeforeCleanupProviders()
        {
            if (m_CurrentSessionDirector == null)
                return;

            m_CurrentSessionDirector.TimeUpdated -= OnDirectorTimeUpdated;
            m_CurrentSessionDirector.EndReached -= OnDirectorEndReached;
            var director = m_CurrentSessionDirector.Director;
            director.played -= OnDirectorPlayed;
            director.paused -= OnDirectorPaused;
            director.stopped -= OnDirectorStopped;
            m_SteppableDataProviders.Clear();
        }

        internal void OpenRecordingTimeline()
        {
            EditorWindow.GetWindow(k_TimelineWindowType);
            Selection.activeGameObject = m_CurrentSessionDirector.gameObject;

            // The Timeline Window will automatically change the current time, but not always immediately. So for a few
            // frames we need to avoid checking for manual time changes so we don't get a false positive.
            StartIgnoringWindowTimeChanges();
        }

        void OnDirectorTimeUpdated(double time)
        {
            if (m_CurrentSessionDirector.Director == TimelineEditor.masterDirector)
                TimelineEditor.Refresh(RefreshReason.WindowNeedsRedraw);

            if (TimelineSyncState != SimulationTimeSyncState.Syncing)
                return;

            var endTime = (float)m_CurrentSessionDirector.PlaybackPauseTime;
            TimelineSyncProgress = endTime > 0f ? (float)time / endTime : 1f;
        }

        void OnDirectorEndReached()
        {
            RecordingEndReached?.Invoke();
        }

        void OnDirectorPlayed(PlayableDirector director)
        {
            if (TimelineEditor.masterDirector != null && director == TimelineEditor.masterDirector)
            {
                // If our director is the master director we want to start preview mode to ensure that the
                // Timeline Window reflects the state of our director.
                // Setting preview mode to true does not do anything if preview mode is already active.
                var timelineEditorState = k_TimelineEditorStateProperty.GetValue(null);
                k_PreviewModeProperty.SetValue(timelineEditorState, true);
            }

            if (!m_QuerySimulationModule.simulatingTemporal)
                m_QuerySimulationModule.StartTemporalSimulation();
        }

        void OnDirectorPaused(PlayableDirector director)
        {
            if (TimelineSyncState == SimulationTimeSyncState.Syncing)
                SetStateToSynced();
        }

        void OnDirectorStopped(PlayableDirector director) { StartIgnoringWindowTimeChanges(); }

        void StartIgnoringWindowTimeChanges()
        {
            m_IgnoreTimeChangeFromWindow = true;
            m_IgnoreTimeChangeFrame = 0;
        }

        internal void PausePlayback()
        {
            m_CurrentSessionDirector.Director.Pause();
            SaveDirectorWindowTime();
        }

        internal void ResumePlayback() { m_CurrentSessionDirector.Director.Resume(); }

        void EditorUpdate()
        {
            PollMasterDirectorChange();

            m_ManualTimeChangeTask?.Update();

            if (m_CurrentSessionDirector == null)
                return;

            if (m_IgnoreTimeChangeFromWindow)
            {
                m_IgnoreTimeChangeFrame++;
                if (m_IgnoreTimeChangeFrame == k_IgnoreTimeChangeEndFrame)
                    m_IgnoreTimeChangeFromWindow = false;

                return;
            }

            // If the actual director time differs from the expected time (the time last saved by the RecordedSessionDirector),
            // treat that as a manual change
            var director = m_CurrentSessionDirector.Director;
            var directorTime = director.time;
            if (Math.Abs(directorTime - m_CurrentSessionDirector.CurrentTime) > double.Epsilon)
            {
                m_CurrentSessionDirector.CurrentTime = directorTime;
                OnTimeManuallyChanged(Math.Min(director.time, director.duration));
            }
        }

        void PollMasterDirectorChange()
        {
            var masterDirector = TimelineEditor.masterDirector;
            if (m_CurrentSessionDirector != null)
            {
                var currentDirector = m_CurrentSessionDirector.Director;
                if (m_PreviousMasterDirector != currentDirector && masterDirector == currentDirector)
                {
                    // When the master Director changes the Timeline Editor sets time to its last saved window time,
                    // which might not be in sync with our current time.
                    m_CurrentSessionDirector.SetTimeToCurrent();
                    SaveDirectorWindowTime();
                }
            }

            m_PreviousMasterDirector = masterDirector;
        }

        void OnTimeManuallyChanged(double time)
        {
            if (IsRecordingPlaying)
                PausePlayback();

            // Steppable data providers update their data whenever time changes, even manually. This makes it possible
            // for some tracks to provide feedback in Simulation as the user scrubs through the Timeline.
            m_CurrentSessionDirector.Evaluate();
            foreach (var provider in m_SteppableDataProviders)
            {
                provider.StepRecordedData();
            }

            if (!m_CurrentRecordingInfo.ControlsMarsLifecycle)
                return;

            TimelineSyncState = SimulationTimeSyncState.OutOfSync;
            SyncEndTime = time;
            m_ManualTimeChangeTask = new EditorSlowTask(OnManualTimeChangeFinalized, m_TimeToFinalizeTimelineChange);
        }

        void OnManualTimeChangeFinalized()
        {
            m_ManualTimeChangeTask = null;
            if (m_CurrentSessionDirector == null || !AutoSyncWithTimeChanges)
                return;

            // When time is manually changed we must rerun the simulation to get it in sync with the current time
            m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);
            m_QuerySimulationModule.RestartSimulationIfNeeded();
        }

        void SetStateToSynced()
        {
            TimelineSyncProgress = 1f;
            TimelineSyncState = SimulationTimeSyncState.Synced;
        }

        void SaveDirectorWindowTime()
        {
            // The Timeline Editor internally keeps track of the "window time" for the master director.  The Timeline Editor uses
            // this window time to position the trackhead when it is not in preview mode, and to set the time of the master
            // director when it starts preview mode.  Ordinarily window time is only saved when the user interacts with the
            // Timeline Window, which is a problem because we update time without interaction with the Timeline Window, and even
            // when the window is not open.
            // We can save the window time for our recorded session director by reflecting into the master sequence state
            // and setting its time value.  This only works when our director is the master director.
            var currentDirector = m_CurrentSessionDirector.Director;
            if (TimelineEditor.masterDirector == null || currentDirector != TimelineEditor.masterDirector)
                return;

            var timelineEditorState = k_TimelineEditorStateProperty.GetValue(null);
            var masterSequence = k_MasterSequenceProperty.GetValue(timelineEditorState);
            k_SequenceStateTimeProperty.SetValue(masterSequence, currentDirector.time);
        }
    }
}

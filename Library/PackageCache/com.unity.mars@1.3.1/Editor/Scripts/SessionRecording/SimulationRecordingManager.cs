using System;
using System.Collections.Generic;
using Unity.MARS.Data.Recorded;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Data.Recorded;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Module responsible for setting up MR session recordings as data sources for simulation
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class
        SimulationRecordingManager : IModuleDependency<SessionRecordingModule>, IModuleDependency<QuerySimulationModule>,
        IModuleDependency<MARSEnvironmentManager>, IModuleAssetCallbacks
    {
        const string k_SessionRecordingFilter = "t:SessionRecordingInfo";

        SessionRecordingModule m_SessionRecordingModule;
        QuerySimulationModule m_QuerySimulationModule;
        MARSEnvironmentManager m_EnvironmentManager;

        readonly Dictionary<GameObject, List<SessionRecordingInfo>> m_SyntheticRecordingsMap =
            new Dictionary<GameObject, List<SessionRecordingInfo>>();

        readonly List<SessionRecordingInfo> m_CurrentSyntheticRecordings = new List<SessionRecordingInfo>();
        readonly List<SessionRecordingInfo> m_IndependentRecordings = new List<SessionRecordingInfo>();
        readonly List<string> m_IndependentRecordingPaths = new List<string>();

        bool IndependentRecordingsExist { get { return m_IndependentRecordings.Count > 0; } }

        internal GUIContent[] IndependentRecordingContents { get; private set; }

        internal int CurrentIndependentRecordingIndex { get; private set; }

        internal string CurrentIndependentRecordingName
        {
            get
            {
                var simulationSettings = SimulationSettings.instance;
                if (simulationSettings.EnvironmentMode != EnvironmentMode.Recorded || simulationSettings.IndependentRecording == null)
                    return string.Empty;

                return simulationSettings.IndependentRecording.DisplayName;
            }
        }

        internal GUIContent[] SyntheticRecordingOptionContents { get; private set; }

        internal int CurrentSyntheticRecordingOptionIndex { get; private set; }

        internal int CurrentSyntheticRecordingsCount { get { return m_CurrentSyntheticRecordings.Count; } }

        internal string CurrentSyntheticRecordingName
        {
            get
            {
                if (CurrentSyntheticRecordingOptionIndex < 1 || CurrentSyntheticRecordingOptionIndex > CurrentSyntheticRecordingsCount)
                    return string.Empty;

                var currentRecording = m_CurrentSyntheticRecordings[CurrentSyntheticRecordingOptionIndex - 1];
                return currentRecording != null ? currentRecording.DisplayName : string.Empty;
            }
        }

        /// <summary>
        /// Callback for when a recording option has changed
        /// </summary>
        public event Action RecordingOptionChanged;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<GameObject> k_EnvironmentPrefabs = new List<GameObject>();
        static readonly List<DataRecording> k_DataRecordings = new List<DataRecording>();
        static readonly List<UnityObject> k_NewAssets = new List<UnityObject>();

        /// <inheritdoc />
        void IModuleDependency<SessionRecordingModule>.ConnectDependency(SessionRecordingModule dependency) { m_SessionRecordingModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<QuerySimulationModule>.ConnectDependency(QuerySimulationModule dependency) { m_QuerySimulationModule = dependency; }

        /// <inheritdoc />
        void IModuleDependency<MARSEnvironmentManager>.ConnectDependency(MARSEnvironmentManager dependency) { m_EnvironmentManager = dependency; }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            UpdateIndependentRecordings();

            MARSEnvironmentManager.onEnvironmentSetup += UpdateCurrentSyntheticRecordings;
            GetSyntheticRecordings();
            if (m_EnvironmentManager.EnvironmentSetup)
                UpdateCurrentSyntheticRecordings();
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            MARSEnvironmentManager.onEnvironmentSetup -= UpdateCurrentSyntheticRecordings;
            m_SyntheticRecordingsMap.Clear();
            m_CurrentSyntheticRecordings.Clear();
            m_IndependentRecordings.Clear();
            m_IndependentRecordingPaths.Clear();
            SyntheticRecordingOptionContents = null;
            IndependentRecordingContents = null;
        }

        /// <inheritdoc />
        void IModuleAssetCallbacks.OnWillCreateAsset(string path) { }

        /// <inheritdoc />
        string[] IModuleAssetCallbacks.OnWillSaveAssets(string[] paths)
        {
            foreach (var path in paths)
            {
                var recording = AssetDatabase.LoadAssetAtPath<SessionRecordingInfo>(path);
                if (recording != null)
                {
                    RefreshSessionRecordings();
                    break;
                }
            }

            return paths;
        }

        /// <inheritdoc />
        AssetDeleteResult IModuleAssetCallbacks.OnWillDeleteAsset(string path, RemoveAssetOptions options) { return AssetDeleteResult.DidNotDelete; }

        /// <summary>
        /// Prompts to save a Timeline of the current session recording and add it to the current synthetic environment
        /// </summary>
        public void TrySaveSyntheticRecording()
        {
            var simulationSettings = SimulationSettings.instance;
            if (simulationSettings.EnvironmentMode != EnvironmentMode.Synthetic)
                return;

            var environmentPrefab = simulationSettings.EnvironmentPrefab;
            var defaultName = $"{environmentPrefab.name} Recording";
            var recordingPath = EditorUtility.SaveFilePanelInProject("Save Recording", defaultName, "playable", "");
            if (recordingPath.Length == 0)
                return;

            var recordingInfo = SessionRecordingUtils.CreateSessionRecordingAsset(recordingPath);
            AddDataFromRecordingSession(recordingInfo);
            recordingInfo.AddSyntheticEnvironment(environmentPrefab);
            AssetDatabase.SaveAssets();

            m_CurrentSyntheticRecordings.Add(recordingInfo);
            if (m_SyntheticRecordingsMap.TryGetValue(environmentPrefab, out var recordings))
                recordings.Add(recordingInfo);
            else
                m_SyntheticRecordingsMap[environmentPrefab] = new List<SessionRecordingInfo> { recordingInfo };

            var newOptionsCount = SyntheticRecordingOptionContents.Length + 1;
            var newOptionContents = new GUIContent[newOptionsCount];
            SyntheticRecordingOptionContents.CopyTo(newOptionContents, 0);
            newOptionContents[newOptionsCount - 1] = new GUIContent(recordingInfo.DisplayName);
            SyntheticRecordingOptionContents = newOptionContents;
        }

        /// <summary>
        /// Adds data from the most recent recording session to the given recording
        /// </summary>
        /// <param name="recordingInfo">The session recording to add data to</param>
        public void AddDataFromRecordingSession(SessionRecordingInfo recordingInfo)
        {
            k_DataRecordings.Clear();
            k_NewAssets.Clear();

            var timeline = recordingInfo.Timeline;
            m_SessionRecordingModule.CreateDataRecordings(timeline, k_DataRecordings, k_NewAssets);
            foreach (var dataRecording in k_DataRecordings)
            {
                recordingInfo.AddDataRecording(dataRecording);
                dataRecording.name = dataRecording.GetType().Name;
                AssetDatabase.AddObjectToAsset(dataRecording, timeline);
            }

            foreach (var newAsset in k_NewAssets)
            {
                AssetDatabase.AddObjectToAsset(newAsset, timeline);
            }

            k_DataRecordings.Clear();
            k_NewAssets.Clear();
        }

        /// <summary>
        /// Sets an optional recording to use with the current environment and triggers simulation restart
        /// </summary>
        /// <param name="optionIndex">Index of the recording to use, where 0 means no recording should be used</param>
        public void SetRecordingOptionAndRestartSimulation(int optionIndex)
        {
            if (optionIndex < 0 || optionIndex > CurrentSyntheticRecordingsCount)
                optionIndex = 0;

            // An optionIndex of 0 means no recording is used, so the index into current recordings is optionIndex - 1
            var useRecording = optionIndex > 0;
            CurrentSyntheticRecordingOptionIndex = optionIndex;
            var simulationSettings = SimulationSettings.instance;
            if (useRecording)
            {
                simulationSettings.UseSyntheticRecording = true;
                simulationSettings.SetRecordingForCurrentSyntheticEnvironment(m_CurrentSyntheticRecordings[optionIndex - 1]);
            }
            else
            {
                simulationSettings.UseSyntheticRecording = false;
            }

            RecordingOptionChanged?.Invoke();

            if (useRecording)
                m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

            m_QuerySimulationModule.RestartSimulationIfNeeded(true);
        }

        /// <summary>
        /// Sets up the previous recording for the current environment and triggers simulation restart
        /// </summary>
        public void SetupPrevRecordingAndRestartSimulation()
        {
            var simulationSettings = SimulationSettings.instance;
            var recordingsCount = m_CurrentSyntheticRecordings.Count;
            if (recordingsCount <= 1 || !simulationSettings.UseSyntheticRecording)
                return;

            if (CurrentSyntheticRecordingOptionIndex == 1)
                CurrentSyntheticRecordingOptionIndex = recordingsCount;
            else
                CurrentSyntheticRecordingOptionIndex--;

            simulationSettings.SetRecordingForCurrentSyntheticEnvironment(m_CurrentSyntheticRecordings[CurrentSyntheticRecordingOptionIndex - 1]);
            RecordingOptionChanged?.Invoke();

            m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);
            m_QuerySimulationModule.RestartSimulationIfNeeded(true);
        }

        /// <summary>
        /// Sets up the next recording for the current environment and triggers simulation restart
        /// </summary>
        public void SetupNextRecordingAndRestartSimulation()
        {
            var simulationSettings = SimulationSettings.instance;
            var recordingsCount = m_CurrentSyntheticRecordings.Count;
            if (recordingsCount <= 1 || !simulationSettings.UseSyntheticRecording)
                return;

            if (CurrentSyntheticRecordingOptionIndex >= recordingsCount)
                CurrentSyntheticRecordingOptionIndex = 1;
            else
                CurrentSyntheticRecordingOptionIndex++;

            simulationSettings.SetRecordingForCurrentSyntheticEnvironment(m_CurrentSyntheticRecordings[CurrentSyntheticRecordingOptionIndex - 1]);
            RecordingOptionChanged?.Invoke();

            m_QuerySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);
            m_QuerySimulationModule.RestartSimulationIfNeeded(true);
        }

        /// <summary>
        /// Validate a recording of a synthetic environment session
        /// </summary>
        public void ValidateSyntheticRecordings()
        {
            var simulationSettings = SimulationSettings.instance;
            if (simulationSettings.EnvironmentMode != EnvironmentMode.Synthetic)
                return;

            if (SyntheticRecordingOptionContents == null || AnySyntheticRecordingsDestroyed())
            {
                var wasUsingRecording = simulationSettings.UseSyntheticRecording;
                GetSyntheticRecordings();
                UpdateCurrentSyntheticRecordings();
                if (wasUsingRecording && !simulationSettings.UseSyntheticRecording)
                {
                    // The current recording was invalidated while it was being used, so stop simulating and trigger a one-shot
                    m_QuerySimulationModule.StopTemporalSimulationInternal();
                    m_QuerySimulationModule.RestartSimulationIfNeeded();
                }
            }
        }

        bool AnySyntheticRecordingsDestroyed()
        {
            foreach (var kvp in m_SyntheticRecordingsMap)
            {
                foreach (var recordingInfo in kvp.Value)
                {
                    if (recordingInfo == null)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Refresh the list of available recordings
        /// </summary>
        [MenuItem(MenuConstants.DevMenuPrefix + "Refresh Session Recordings", priority = MenuConstants.RefreshSessionRecordingsPriority)]
        public static void RefreshSessionRecordings()
        {
            var recordingManager = ModuleLoaderCore.instance.GetModule<SimulationRecordingManager>();
            recordingManager.GetSyntheticRecordings();
            recordingManager.UpdateCurrentSyntheticRecordings();
            recordingManager.UpdateIndependentRecordings();
        }

        void GetSyntheticRecordings()
        {
            m_SyntheticRecordingsMap.Clear();
            var recordingGUIDs = AssetDatabase.FindAssets(k_SessionRecordingFilter);
            foreach (var guid in recordingGUIDs)
            {
                k_EnvironmentPrefabs.Clear();
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var recording = AssetDatabase.LoadAssetAtPath<SessionRecordingInfo>(path);
                recording.GetSyntheticEnvironments(k_EnvironmentPrefabs);
                foreach (var environmentPrefab in k_EnvironmentPrefabs)
                {
                    if (m_SyntheticRecordingsMap.TryGetValue(environmentPrefab, out var recordings))
                        recordings.Add(recording);
                    else
                        m_SyntheticRecordingsMap[environmentPrefab] = new List<SessionRecordingInfo> { recording };
                }
            }

            k_EnvironmentPrefabs.Clear();
        }

        void UpdateCurrentSyntheticRecordings()
        {
            m_CurrentSyntheticRecordings.Clear();
            var simulationSettings = SimulationSettings.instance;
            if (simulationSettings.EnvironmentMode != EnvironmentMode.Synthetic)
                return;

            var environmentPrefab = simulationSettings.EnvironmentPrefab;
            if (environmentPrefab != null && m_SyntheticRecordingsMap.TryGetValue(environmentPrefab, out var recordings))
                m_CurrentSyntheticRecordings.AddRange(recordings);

            var recordingsCount = m_CurrentSyntheticRecordings.Count;
            SyntheticRecordingOptionContents = new GUIContent[recordingsCount + 1];
            SyntheticRecordingOptionContents[0] = new GUIContent("No Recording (Manual)");
            for (var i = 0; i < recordingsCount; i++)
            {
                SyntheticRecordingOptionContents[i + 1] = new GUIContent(m_CurrentSyntheticRecordings[i].DisplayName);
            }

            var currentRecording = simulationSettings.GetRecordingForCurrentSyntheticEnvironment();
            if (currentRecording == null)
            {
                if (recordingsCount > 0)
                {
                    // The current environment has recordings but it does not have a valid recording assigned
                    // in simulation settings, so assign one now
                    currentRecording = m_CurrentSyntheticRecordings[0];
                    simulationSettings.SetRecordingForCurrentSyntheticEnvironment(currentRecording);
                }
                else if (simulationSettings.UseSyntheticRecording)
                {
                    // The current environment does not have recordings but the previous environment was using
                    // a recording, so make sure the next simulation is one-shot
                    m_QuerySimulationModule.NextSimModeSelection = SimulationModeSelection.SingleFrameMode;
                    simulationSettings.UseSyntheticRecording = false;
                }
            }

            CurrentSyntheticRecordingOptionIndex = simulationSettings.UseSyntheticRecording ?
                1 + m_CurrentSyntheticRecordings.IndexOf(currentRecording) : 0;

            RecordingOptionChanged?.Invoke();
        }

        void UpdateIndependentRecordings()
        {
            m_IndependentRecordings.Clear();
            var recordingGUIDs = AssetDatabase.FindAssets(k_SessionRecordingFilter);
            foreach (var guid in recordingGUIDs)
            {
                k_EnvironmentPrefabs.Clear();
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var recording = AssetDatabase.LoadAssetAtPath<SessionRecordingInfo>(path);
                recording.GetSyntheticEnvironments(k_EnvironmentPrefabs);
                if (k_EnvironmentPrefabs.Count == 0)
                    m_IndependentRecordings.Add(recording);
            }

            k_EnvironmentPrefabs.Clear();

            m_IndependentRecordings.Sort((a, b) => a.DisplayName.CompareTo(b.DisplayName));
            m_IndependentRecordingPaths.Clear();
            foreach (var recording in m_IndependentRecordings)
            {
                m_IndependentRecordingPaths.Add(AssetDatabase.GetAssetPath(recording));
            }

            var simulationSettings = SimulationSettings.instance;
            IndependentRecordingContents = m_IndependentRecordings.ConvertAll(recording => new GUIContent(recording.DisplayName)).ToArray();
            var currentRecordingAssetPath = AssetDatabase.GetAssetPath(simulationSettings.IndependentRecording);
            CurrentIndependentRecordingIndex = Mathf.Max(m_IndependentRecordingPaths.IndexOf(currentRecordingAssetPath), 0);

            if (simulationSettings.IndependentRecording == null && IndependentRecordingsExist)
                SetIndependentRecording(0);
        }

        internal void SetNextIndependentRecording()
        {
            TrySetIndependentRecording(CurrentIndependentRecordingIndex + 1);
        }

        internal void SetPreviousIndependentRecording()
        {
            TrySetIndependentRecording(CurrentIndependentRecordingIndex - 1);
        }

        internal void TrySetIndependentRecording(int index)
        {
            if (index < 0)
                index = m_IndependentRecordings.Count - 1;
            else if (index >= m_IndependentRecordings.Count)
                index = 0;

            if (!IndependentRecordingsExist)
            {
                UpdateIndependentRecordings();
                return;
            }

            if (m_IndependentRecordings[index] == null)
            {
                UpdateIndependentRecordings();
                TrySetIndependentRecording(index);
                return;
            }

            SetIndependentRecording(index);
        }

        void SetIndependentRecording(int index)
        {
            CurrentIndependentRecordingIndex = index;
            SimulationSettings.instance.IndependentRecording = m_IndependentRecordings[index];
            RecordingOptionChanged?.Invoke();
        }

        /// <summary>
        /// Validate an independent recording session
        /// </summary>
        public void ValidateIndependentRecordings()
        {
            if (IndependentRecordingContents == null || AnyIndependentRecordingsDestroyed())
            {
                if (m_QuerySimulationModule.simulatingTemporal && !SimulationSettings.instance.IsSpatialContextAvailable)
                    m_QuerySimulationModule.StopTemporalSimulationInternal();

                UpdateIndependentRecordings();
            }
        }

        bool AnyIndependentRecordingsDestroyed()
        {
            foreach (var recording in m_IndependentRecordings)
            {
                if (recording == null)
                    return true;
            }

            return false;
        }
    }
}

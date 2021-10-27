using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Settings for simulation of content
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS.Simulation")]
    public class SimulationSettings : EditorScriptableSettings<SimulationSettings>, ISerializationCallbackReceiver
    {
        internal const string AutoSyncTooltip = "When enabled, Simulation will automatically restart when changes are made to the active scene";
        const EnvironmentMode k_DefaultUserFacingEnvironmentMode = EnvironmentMode.Recorded;
        const EnvironmentMode k_DefaultWorldFacingEnvironmentMode = EnvironmentMode.Synthetic;

#pragma warning disable 649
        [SerializeField]
        EnvironmentMode m_EnvironmentMode;

        [SerializeField]
        GameObject m_EnvironmentPrefab;

        [SerializeField]
        SessionRecordingInfo m_IndependentRecording;

        [SerializeField]
        int m_WebCamDeviceIndex;

        [SerializeField]
        bool m_UseSyntheticRecording;

        [SerializeField]
        [Tooltip("When enabled, simulation will check for all data that would match a query, even if that data doesn't get used")]
        bool m_FindAllMatchingDataPerQuery;

        [SerializeField]
        [Tooltip("When enabled, the simulated device will reset back to its default starting pose after each simulation")]
        bool m_AutoResetDevicePose;
#pragma warning restore 649

        [SerializeField]
        [Tooltip(AutoSyncTooltip)]
        bool m_AutoSyncWithSceneChanges = true;

        [SerializeField]
        [Tooltip("Sets the amount of time to wait after changing query-related data before re-simulating. " +
            "If another change happens during this time then the timer is reset.")]
        float m_TimeToFinalizeSceneModification = 0.3f;

        [SerializeField]
        [Tooltip("When enabled, the simulated environment will be visualized")]
        bool m_ShowSimulatedEnvironment = true;

        [SerializeField]
        [Tooltip("When enabled, AR data for the simulated environment will be visualized")]
        bool m_ShowSimulatedData = true;

        [SerializeField]
        List<GameObject> m_SyntheticPrefabs = new List<GameObject>();

        [SerializeField]
        List<SessionRecordingInfo> m_SyntheticRecordings = new List<SessionRecordingInfo>();

        [SerializeField]
        EnvironmentMode m_UserFacingEnvironmentMode = k_DefaultUserFacingEnvironmentMode;

        [SerializeField]
        EnvironmentMode m_WorldFacingEnvironmentMode = k_DefaultWorldFacingEnvironmentMode;

        Dictionary<GameObject, SessionRecordingInfo> m_SyntheticRecordingsMap = new Dictionary<GameObject, SessionRecordingInfo>();

        /// <summary>
        /// The current simulated environment mode
        /// </summary>
        public EnvironmentMode EnvironmentMode
        {
            get => m_EnvironmentMode;
            internal set
            {
                m_EnvironmentMode = value;
                EditorUtility.SetDirty(instance);
            }
        }

        /// <summary>
        /// The prefab for the current synthetic environment
        /// </summary>
        public GameObject EnvironmentPrefab
        {
            get => m_EnvironmentPrefab;
            set
            {
                m_EnvironmentPrefab = value;
                EditorUtility.SetDirty(instance);
            }
        }

        /// <summary>
        /// The current recording being used for Recorded Environment Mode
        /// </summary>
        public SessionRecordingInfo IndependentRecording
        {
            get => m_IndependentRecording;
            set
            {
                m_IndependentRecording = value;
                EditorUtility.SetDirty(instance);
            }
        }

        /// <summary>
        /// Index of the current web cam device being used for Live Environment Mode
        /// </summary>
        public int WebCamDeviceIndex
        {
            get => m_WebCamDeviceIndex;
            set
            {
                m_WebCamDeviceIndex = value;
                EditorUtility.SetDirty(instance);
            }
        }

        /// <summary>
        /// Checks whether the current environment is video-based.
        /// Future environment modes that support video controls (play/pause, etc) should be added here.
        /// </summary>
        public bool IsVideoEnvironment => m_EnvironmentMode == EnvironmentMode.Recorded || m_EnvironmentMode == EnvironmentMode.Live;

        /// <summary>
        /// Whether there is any spatial context set up from which the simulation can receive data
        /// </summary>
        public bool IsSpatialContextAvailable
        {
            get
            {
                switch (m_EnvironmentMode)
                {
                    case EnvironmentMode.Synthetic:
                        return m_EnvironmentPrefab != null;
                    case EnvironmentMode.Recorded:
                        return m_IndependentRecording != null;
                    case EnvironmentMode.Live:
                        return m_WebCamDeviceIndex >= 0;
                    default:
                        return true;
                }
            }
        }

        /// <summary>
        /// When enabled, simulation will check for all data that would match a query, even if that data doesn't get used
        /// </summary>
        public bool FindAllMatchingDataPerQuery => m_FindAllMatchingDataPerQuery;

        /// <summary>
        /// The amount of time to wait after modifying the active scene before the simulation is marked as Out of Sync.
        /// If another change happens during this time then the timer is reset.
        /// </summary>
        public float TimeToFinalizeSceneModification => m_TimeToFinalizeSceneModification;

        /// <summary>
        /// When enabled, AR data for the simulated environment will be visualized
        /// </summary>
        public bool ShowSimulatedData
        {
            get => m_ShowSimulatedData;
            set
            {
                if (value == m_ShowSimulatedData)
                    return;

                m_ShowSimulatedData = value;
                EditorUtility.SetDirty(instance);

                MARSEnvironmentManager.SetSimDataVisibility(value);
            }
        }

        /// <summary>
        /// When enabled, the simulated environment will be visualized
        /// </summary>
        public bool ShowSimulatedEnvironment
        {
            get => m_ShowSimulatedEnvironment;
            set
            {
                if (value == m_ShowSimulatedEnvironment)
                    return;

                m_ShowSimulatedEnvironment = value;
                EditorUtility.SetDirty(instance);

                MARSEnvironmentManager.SetSimEnvironmentVisibility(value);
            }
        }

        /// <summary>
        /// When enabled, the simulated device will reset back to its default starting pose after each simulation
        /// </summary>
        public bool AutoResetDevicePose { get { return m_AutoResetDevicePose; } }

        /// <summary>
        /// When enabled, Simulation will automatically restart when changes are made to the active scene
        /// </summary>
        public bool AutoSyncWithSceneChanges
        {
            get => m_AutoSyncWithSceneChanges;
            set
            {
                m_AutoSyncWithSceneChanges = value;
                EditorUtility.SetDirty(instance);

                if (value)
                {
                    var simObjectsManager = ModuleLoaderCore.instance.GetModule<SimulatedObjectsManager>();
                    var querySimulationModule = QuerySimulationModule.instance;
                    if (simObjectsManager != null && querySimulationModule != null && !simObjectsManager.SimulationSyncedWithScene)
                        querySimulationModule.RestartSimulationIfNeeded();
                }
            }
        }

        /// <summary>
        /// If enabled, simulation will use the currently selected synthetic recording
        /// </summary>
        public bool UseSyntheticRecording
        {
            get => m_UseSyntheticRecording;
            set
            {
                m_UseSyntheticRecording = value;
                EditorUtility.SetDirty(instance);
            }
        }

        /// <summary>
        /// Returns true if simulation is currently using a recording
        /// </summary>
        public bool IsUsingRecording
        {
            get
            {
                return m_EnvironmentMode == EnvironmentMode.Recorded || (m_EnvironmentMode == EnvironmentMode.Synthetic && m_UseSyntheticRecording);
            }
        }

        /// <inheritdoc />
        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            m_SyntheticPrefabs.Clear();
            m_SyntheticRecordings.Clear();
            foreach (var kvp in m_SyntheticRecordingsMap)
            {
                m_SyntheticPrefabs.Add(kvp.Key);
                m_SyntheticRecordings.Add(kvp.Value);
            }
        }

        /// <inheritdoc />
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            m_SyntheticRecordingsMap.Clear();
            for (var i = 0; i < m_SyntheticPrefabs.Count; i++)
            {
                m_SyntheticRecordingsMap[m_SyntheticPrefabs[i]] = m_SyntheticRecordings[i];
            }
        }

        /// <summary>
        /// Set the recording for the current synthetic environment
        /// </summary>
        /// <param name="recording">The recording to set for the current synthetic environment</param>
        public void SetRecordingForCurrentSyntheticEnvironment(SessionRecordingInfo recording)
        {
            m_SyntheticRecordingsMap[m_EnvironmentPrefab] = recording;
            EditorUtility.SetDirty(this);
        }

        /// <summary>
        /// Get the current recording for a given synthetic environment
        /// </summary>
        /// <returns>The current synthetic environment recording</returns>
        public SessionRecordingInfo GetRecordingForCurrentSyntheticEnvironment()
        {
            if (m_EnvironmentPrefab == null)
                return null;

            return m_SyntheticRecordingsMap.ContainsKey(m_EnvironmentPrefab) ?
                m_SyntheticRecordingsMap[m_EnvironmentPrefab] : null;
        }

        /// <summary>
        /// Get the current recording being used for simulation
        /// </summary>
        /// <returns>The current recording</returns>
        public SessionRecordingInfo GetCurrentRecording()
        {
            switch (m_EnvironmentMode)
            {
                case EnvironmentMode.Synthetic:
                    return m_UseSyntheticRecording ? GetRecordingForCurrentSyntheticEnvironment() : null;
                case EnvironmentMode.Recorded:
                    return m_IndependentRecording;
            }

            return null;
        }

        /// <summary>
        /// Set the current environment mode to the mode associated with the given camera facing direction
        /// </summary>
        /// <param name="cameraFacing">The camera facing direction that determines which mode is used</param>
        internal void ApplyEnvironmentModeFromCameraFacing(CameraFacingDirection cameraFacing)
        {
            switch (cameraFacing)
            {
                case CameraFacingDirection.User:
                    EnvironmentMode = m_UserFacingEnvironmentMode;
                    break;
                case CameraFacingDirection.World:
                    EnvironmentMode = m_WorldFacingEnvironmentMode;
                    break;
            }
        }

        /// <summary>
        /// Set the environment mode to associate with the given camera facing direction to the current environment mode
        /// </summary>
        /// <param name="cameraFacing">The camera facing direction to associate with the current environment mode</param>
        internal void UpdateEnvironmentModeForCameraFacing(CameraFacingDirection cameraFacing)
        {
            switch (cameraFacing)
            {
                case CameraFacingDirection.User:
                    m_UserFacingEnvironmentMode = m_EnvironmentMode;
                    break;
                case CameraFacingDirection.World:
                    m_WorldFacingEnvironmentMode = m_EnvironmentMode;
                    break;
            }

            EditorUtility.SetDirty(instance);
        }
    }
}

using System.Linq;
using Unity.MARS.Data.Recorded;
using Unity.MARS.MARSEditor;
using Unity.MARS.Providers;
using Unity.MARS.Recording;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEngine.UIElements;

namespace Unity.MARS
{
    class MarsSimulationSettingsProvider : SettingsProvider
    {
        SerializedObject m_SimulationSettingsObject;
        SimulationSettingsDrawer m_SimulationSettingsDrawer;

        SerializedObject m_QuerySimulationModuleObject;
        QuerySimulationModuleDrawer m_QuerySimulationModuleDrawer;

        SerializedObject m_EnvironmentManagerObject;
        MarsEnvironmentManagerDrawer m_EnvironmentManagerDrawer;

        SerializedObject m_SimulationEnvironmentSettingsObject;
        SimulationEnvironmentSettingsDrawer m_SimulationEnvironmentSettingsDrawer;

        SerializedObject m_RecordingPlaybackModuleObject;
        MarsRecordingPlaybackModuleDrawer m_RecordingPlaybackModule;

        SerializedObject m_TimeModuleObject;
        MarsTimeModuleDrawer m_TimeModuleDrawer;

        SerializedObject m_SessionRecordingSettingsObject;
        SessionRecordingSettingsDrawer m_SessionRecordingSettingsDrawer;

        SerializedObject m_SceneModuleObject;
        MarsSceneModuleSimulationSettingsDrawer m_SceneModuleSimulationSettingsDrawer;

        SerializedObject m_SimulationVideoContextSettingsObject;
        SimulationVideoContextSettingsDrawer m_VideoContextSettingsDrawer;

        SerializedObject m_GeoLocationModuleObject;
        GeoLocationModuleSimulationDrawer m_GeoLocationModuleSimulationDrawer;

        [SettingsProvider]
        public static SettingsProvider CreateMARSPreferencesProvider()
        {
            var keywordsList = GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(SimulationSettings.instance)).ToList();
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(QuerySimulationModule.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MARSEnvironmentManager.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MarsRecordingPlaybackModule.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MarsTimeModule.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(SessionRecordingSettings.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MARSSceneModule.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(SimulationVideoContextSettings.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(GeoLocationModule.instance)));

            var provider = new MarsSimulationSettingsProvider{ keywords = keywordsList };

            return provider;
        }

        MarsSimulationSettingsProvider(string path = MARSCore.ProjectSettingsRootPath + "/Simulation", SettingsScope scope = SettingsScope.Project)
            : base(path, scope) { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);

            var simulationSettings = SimulationSettings.instance;
            m_SimulationSettingsObject = new SerializedObject(simulationSettings);
            m_SimulationSettingsDrawer = new SimulationSettingsDrawer(m_SimulationSettingsObject);

            var querySimulationModule = QuerySimulationModule.instance;
            m_QuerySimulationModuleObject = new SerializedObject(querySimulationModule);
            m_QuerySimulationModuleDrawer = new QuerySimulationModuleDrawer(m_QuerySimulationModuleObject);

            var environmentManager = MARSEnvironmentManager.instance;
            m_EnvironmentManagerObject = new SerializedObject(environmentManager);
            m_EnvironmentManagerDrawer = new MarsEnvironmentManagerDrawer(m_EnvironmentManagerObject);

            var simulationEnvironmentSettings = SimulationEnvironmentSettings.instance;
            m_SimulationEnvironmentSettingsObject = new SerializedObject(simulationEnvironmentSettings);
            m_SimulationEnvironmentSettingsDrawer = new SimulationEnvironmentSettingsDrawer(m_SimulationEnvironmentSettingsObject);

            var recordingPlaybackModule = MarsRecordingPlaybackModule.instance;
            m_RecordingPlaybackModuleObject = new SerializedObject(recordingPlaybackModule);
            m_RecordingPlaybackModule = new MarsRecordingPlaybackModuleDrawer(m_RecordingPlaybackModuleObject);

            var marsTimeModule = MarsTimeModule.instance;
            m_TimeModuleObject = new SerializedObject(marsTimeModule);
            m_TimeModuleDrawer = new MarsTimeModuleDrawer(m_TimeModuleObject);

            var sessionRecordingSettings = SessionRecordingSettings.instance;
            m_SessionRecordingSettingsObject = new SerializedObject(sessionRecordingSettings);
            m_SessionRecordingSettingsDrawer = new SessionRecordingSettingsDrawer(m_SessionRecordingSettingsObject);

            var sceneModule = MARSSceneModule.instance;
            m_SceneModuleObject = new SerializedObject(sceneModule);
            m_SceneModuleSimulationSettingsDrawer = new MarsSceneModuleSimulationSettingsDrawer(m_SceneModuleObject);

            var simulationVideoContextSettings = SimulationVideoContextSettings.instance;
            m_SimulationVideoContextSettingsObject = new SerializedObject(simulationVideoContextSettings);
            m_VideoContextSettingsDrawer = new SimulationVideoContextSettingsDrawer(m_SimulationVideoContextSettingsObject);

            var geoLocationModule = GeoLocationModule.instance;
            m_GeoLocationModuleObject = new SerializedObject(geoLocationModule);
            m_GeoLocationModuleSimulationDrawer = new GeoLocationModuleSimulationDrawer(m_GeoLocationModuleObject);
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            EditorGUILayout.LabelField("Simulation Settings", EditorStyles.boldLabel);
            m_SimulationSettingsDrawer.InspectorGUI(m_SimulationSettingsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Query Simulation Module", EditorStyles.boldLabel);
            m_QuerySimulationModuleDrawer.InspectorGUI(m_QuerySimulationModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Environment Manager", EditorStyles.boldLabel);
            m_EnvironmentManagerDrawer.InspectorGUI(m_EnvironmentManagerObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Environment Settings", EditorStyles.boldLabel);
            m_SimulationEnvironmentSettingsDrawer.InspectorGUI(m_SimulationEnvironmentSettingsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Recording Playback Module", EditorStyles.boldLabel);
            m_RecordingPlaybackModule.InspectorGUI(m_RecordingPlaybackModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Time Module", EditorStyles.boldLabel);
            m_TimeModuleDrawer.InspectorGUI(m_TimeModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Session Recording", EditorStyles.boldLabel);
            m_SessionRecordingSettingsDrawer.InspectorGUI(m_SessionRecordingSettingsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Scene Module", EditorStyles.boldLabel);
            m_SceneModuleSimulationSettingsDrawer.InspectorGUI(m_SceneModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Video Context", EditorStyles.boldLabel);
            m_VideoContextSettingsDrawer.InspectorGUI(m_SimulationVideoContextSettingsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Simulated Geolocation", EditorStyles.boldLabel);
            m_GeoLocationModuleSimulationDrawer.InspectorGUI(m_GeoLocationModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }
}

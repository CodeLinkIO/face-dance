using Unity.MARS.Data.Reasoning;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Data;
using UnityEditor.MARS.Simulation;

namespace Unity.MARS.Providers
{
    [CustomEditor(typeof(GeoLocationModule))]
    class GeoLocationModuleEditor : Editor
    {
        GeoLocationModuleRuntimeDrawer m_GeoLocationModuleRuntimeDrawer;
        GeoLocationModuleSimulationDrawer m_GeoLocationModuleSimulationDrawer;

        public void OnEnable()
        {
            m_GeoLocationModuleRuntimeDrawer = new GeoLocationModuleRuntimeDrawer(serializedObject);
            m_GeoLocationModuleSimulationDrawer = new GeoLocationModuleSimulationDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Runtime Options", EditorStyles.boldLabel);
            m_GeoLocationModuleRuntimeDrawer.InspectorGUI(serializedObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Simulated Options", EditorStyles.boldLabel);
            m_GeoLocationModuleSimulationDrawer.InspectorGUI(serializedObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }

    class GeoLocationModuleRuntimeDrawer
    {
        SerializedProperty m_AutoStartLocationServiceProperty;
        SerializedProperty m_DesiredAccuracyProperty;
        SerializedProperty m_UpdateDistanceProperty;
        SerializedProperty m_ContinuousUpdatesProperty;
        SerializedProperty m_UpdateIntervalProperty;

        internal GeoLocationModuleRuntimeDrawer(SerializedObject serializedObject)
        {
            m_AutoStartLocationServiceProperty = serializedObject.FindProperty("m_AutoStartLocationService");
            m_DesiredAccuracyProperty = serializedObject.FindProperty("m_DesiredAccuracy");
            m_ContinuousUpdatesProperty = serializedObject.FindProperty("m_ContinuousUpdates");
            m_UpdateDistanceProperty = serializedObject.FindProperty("m_UpdateDistance");
            m_UpdateIntervalProperty = serializedObject.FindProperty("m_UpdateInterval");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;
            serializedObject.Update();

            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                if (!m_AutoStartLocationServiceProperty.boolValue)
                    EditorGUILayout.HelpBox("GeoLocation service is NOT set to start automatically.",
                        MessageType.Info);

                EditorGUILayout.PropertyField(m_AutoStartLocationServiceProperty);
                EditorGUILayout.PropertyField(m_DesiredAccuracyProperty);
                EditorGUILayout.PropertyField(m_ContinuousUpdatesProperty);
                using (new EditorGUI.DisabledScope(!m_ContinuousUpdatesProperty.boolValue))
                {
                    EditorGUILayout.PropertyField(m_UpdateDistanceProperty);
                    EditorGUILayout.PropertyField(m_UpdateIntervalProperty);
                }

                if (changeCheck.changed)
                {
                    serializedObject.ApplyModifiedProperties();
                    GeoLocationModuleDrawerUtils.PropagateGeoLocationChanges();
                }
            }
        }
    }

    class GeoLocationModuleSimulationDrawer
    {
        SerializedProperty m_LatitudeProperty;
        SerializedProperty m_LongitudeProperty;
        bool m_ShortcutButtonsFoldout = true;

        internal GeoLocationModuleSimulationDrawer(SerializedObject serializedObject)
        {
            m_LatitudeProperty = serializedObject.FindProperty("m_CurrentLocation.latitude");
            m_LongitudeProperty = serializedObject.FindProperty("m_CurrentLocation.longitude");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;
            serializedObject.Update();

            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.HelpBox(
                    "Change lat/long here to simulate different testing locations.\nValues here have no effect in builds.",
                    MessageType.Info);

                    EditorGUILayout.PropertyField(m_LatitudeProperty);
                    EditorGUILayout.PropertyField(m_LongitudeProperty);


                m_ShortcutButtonsFoldout = GeoLocationShortcutButtons.DrawShortcutButtons("Debug Geolocation Shortcuts",
                    (latitude, longitude) =>
                {
                    m_LatitudeProperty.doubleValue = latitude;
                    m_LongitudeProperty.doubleValue = longitude;
                    serializedObject.ApplyModifiedProperties();
                    GeoLocationModuleDrawerUtils.PropagateGeoLocationChanges();
                }, true, m_ShortcutButtonsFoldout);

                if (changeCheck.changed)
                {
                    m_LatitudeProperty.doubleValue = MathUtility.Clamp(m_LatitudeProperty.doubleValue, -GeoLocationModule.MaxLatitude, GeoLocationModule.MaxLatitude);
                    m_LongitudeProperty.doubleValue = MathUtility.Clamp(m_LongitudeProperty.doubleValue, -GeoLocationModule.MaxLongitude, GeoLocationModule.MaxLongitude);
                    serializedObject.ApplyModifiedProperties();
                    GeoLocationModuleDrawerUtils.PropagateGeoLocationChanges();
                }
            }
        }
    }

    static class GeoLocationModuleDrawerUtils
    {
        internal static void PropagateGeoLocationChanges()
        {
            GeoLocationModule.instance.AddOrUpdateLocationTrait();
            var foundReasoningApi = ReasoningModule.instance.FindReasoningAPI<GeoDuplicationReasoningAPI>();
            if (foundReasoningApi)
                foundReasoningApi.ProcessScene();

            QuerySimulationModule.instance.RestartSimulationIfNeeded();
        }
    }
}

using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(MarsDebugSettings))]
    class MarsDebugSettingsEditor : Editor
    {
        MarsDebugLoggingSettingsDrawer m_MarsDebugLoggingSettingsDrawer;
        MarsDebugVisualsSettingsDrawer m_MarsDebugVisualsSettingsDrawer;

        void OnEnable()
        {
            m_MarsDebugLoggingSettingsDrawer = new MarsDebugLoggingSettingsDrawer(serializedObject);
            m_MarsDebugVisualsSettingsDrawer = new MarsDebugVisualsSettingsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Enable Logging", EditorStyles.boldLabel);
            m_MarsDebugLoggingSettingsDrawer.InspectorGUI(serializedObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Simulated Data Discovery", EditorStyles.boldLabel);
            m_MarsDebugVisualsSettingsDrawer.InspectorGUI(serializedObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }

    class MarsDebugLoggingSettingsDrawer
    {
        SerializedProperty m_SceneModuleLoggingProperty;
        SerializedProperty m_QuerySimulationModuleLoggingProperty;
        SerializedProperty m_SimObjectsManagerLoggingProperty;
        SerializedProperty m_SimPlaneFindingLoggingProperty;

        internal MarsDebugLoggingSettingsDrawer(SerializedObject serializedObject)
        {
            m_SceneModuleLoggingProperty = serializedObject.FindProperty("m_SceneModuleLogging");
            m_QuerySimulationModuleLoggingProperty = serializedObject.FindProperty("m_QuerySimulationModuleLogging");
            m_SimObjectsManagerLoggingProperty = serializedObject.FindProperty("m_SimObjectsManagerLogging");
            m_SimPlaneFindingLoggingProperty = serializedObject.FindProperty("m_SimPlaneFindingLogging");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(
                    m_SceneModuleLoggingProperty, new GUIContent("Scene Module"));
                EditorGUILayout.PropertyField(
                    m_QuerySimulationModuleLoggingProperty, new GUIContent("Query Simulation Module"));
                EditorGUILayout.PropertyField(
                    m_SimObjectsManagerLoggingProperty, new GUIContent("Simulated Objects Manager"));
                EditorGUILayout.PropertyField(
                    m_SimPlaneFindingLoggingProperty, new GUIContent("Simulated Plane Finding"));

                if (changeCheckScope.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }

    class MarsDebugVisualsSettingsDrawer
    {
        const string k_SimDiscoveryHelpText = "These settings control debug drawing for all processes involved in " +
            "simulating the discovery of AR world data in Synthetic environments";

        SerializedProperty m_SimDiscoveryPointCloudDebugProperty;
        SerializedProperty m_SimDiscoveryPointCloudRayGizmoTimeProperty;
        SerializedProperty m_SimDiscoveryPlaneVerticesDebugProperty;
        SerializedProperty m_SimDiscoveryPlaneExtentsDebugProperty;
        SerializedProperty m_SimDiscoveryPlaneCenterDebugProperty;
        SerializedProperty m_SimDiscoveryVoxelsDebugProperty;
        SerializedProperty m_SimDiscoveryImageMarkerDebugProperty;

        SerializedProperty m_InteractionTargetSelectionProperty;

        GUIContent m_DebugVoxelsContent;

        internal MarsDebugVisualsSettingsDrawer(SerializedObject serializedObject)
        {
            m_SimDiscoveryPointCloudDebugProperty = serializedObject.FindProperty("m_SimDiscoveryPointCloudDebug");
            m_SimDiscoveryPointCloudRayGizmoTimeProperty = serializedObject.FindProperty("m_SimDiscoveryPointCloudRayGizmoTime");
            m_SimDiscoveryPlaneVerticesDebugProperty = serializedObject.FindProperty("m_SimDiscoveryPlaneVerticesDebug");
            m_SimDiscoveryPlaneExtentsDebugProperty = serializedObject.FindProperty("m_SimDiscoveryPlaneExtentsDebug");
            m_SimDiscoveryPlaneCenterDebugProperty = serializedObject.FindProperty("m_SimDiscoveryPlaneCenterDebug");
            m_SimDiscoveryVoxelsDebugProperty = serializedObject.FindProperty("m_SimDiscoveryVoxelsDebug");
            m_SimDiscoveryImageMarkerDebugProperty = serializedObject.FindProperty("m_SimDiscoveryImageMarkerDebug");

            m_InteractionTargetSelectionProperty = serializedObject.FindProperty("m_AllowInteractionTargetSelection");

            m_DebugVoxelsContent = new GUIContent(
                "Voxels", "Discovered planes are created from discrete voxels containing the simulated " +
                "point cloud. This debug option shows the most recently updated voxels as points are discovered.");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;
            using (var changeCheckScope = new EditorGUI.ChangeCheckScope())
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    EditorGUILayout.HelpBox(k_SimDiscoveryHelpText, MessageType.Info);

                    EditorGUILayout.LabelField("Point Cloud Drawing", EditorStyles.boldLabel);
                    using (new EditorGUI.IndentLevelScope())
                    {
                        m_SimDiscoveryPointCloudDebugProperty.boolValue =
                            EditorGUILayout.ToggleLeft("Raycasts", m_SimDiscoveryPointCloudDebugProperty.boolValue);
                        EditorGUILayout.PropertyField(m_SimDiscoveryPointCloudRayGizmoTimeProperty, new GUIContent("Raycast Draw Time"));
                    }

                    EditorGUILayout.LabelField("Plane Drawing", EditorStyles.boldLabel);
                    using (new EditorGUI.IndentLevelScope())
                    {
                        m_SimDiscoveryPlaneVerticesDebugProperty.boolValue =
                            EditorGUILayout.ToggleLeft("Vertices", m_SimDiscoveryPlaneVerticesDebugProperty.boolValue);
                        m_SimDiscoveryPlaneExtentsDebugProperty.boolValue =
                            EditorGUILayout.ToggleLeft("2D Bounding boxes", m_SimDiscoveryPlaneExtentsDebugProperty.boolValue);
                        m_SimDiscoveryPlaneCenterDebugProperty.boolValue =
                            EditorGUILayout.ToggleLeft("Center Points", m_SimDiscoveryPlaneCenterDebugProperty.boolValue);
                        m_SimDiscoveryVoxelsDebugProperty.boolValue =
                            EditorGUILayout.ToggleLeft(m_DebugVoxelsContent, m_SimDiscoveryVoxelsDebugProperty.boolValue);
                    }

                    EditorGUILayout.LabelField("Image Marker Drawing", EditorStyles.boldLabel);
                    using (new EditorGUI.IndentLevelScope())
                    {
                        m_SimDiscoveryImageMarkerDebugProperty.boolValue =
                            EditorGUILayout.ToggleLeft("Camera Tracking", m_SimDiscoveryImageMarkerDebugProperty.boolValue);
                    }
                }

                EditorGUIUtils.DrawBoxSplitter();

                EditorGUILayout.LabelField("Scene View", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(
                    m_InteractionTargetSelectionProperty, new GUIContent("Allow interaction target selection"));

                if (changeCheckScope.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

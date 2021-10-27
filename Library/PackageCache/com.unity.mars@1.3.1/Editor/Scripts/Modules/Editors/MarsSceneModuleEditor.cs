using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;

namespace Unity.MARS
{
    [CustomEditor(typeof(MARSSceneModule))]
    class MarsSceneModuleEditor : Editor
    {
        MarsSceneModuleSceneTrackingDrawer m_SceneModuleSceneTrackingDrawer;
        MarsSceneModuleSimulationSettingsDrawer m_SceneModuleSimulationSettingsDrawer;

        void OnEnable()
        {
            m_SceneModuleSceneTrackingDrawer = new MarsSceneModuleSceneTrackingDrawer(serializedObject);
            m_SceneModuleSimulationSettingsDrawer = new MarsSceneModuleSimulationSettingsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Scene Tracking", EditorStyles.boldLabel);
            m_SceneModuleSceneTrackingDrawer.InspectorGUI(serializedObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Simulation Settings", EditorStyles.boldLabel);
            m_SceneModuleSimulationSettingsDrawer.InspectorGUI(serializedObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }

    class MarsSceneModuleSceneTrackingDrawer
    {
        SerializedProperty m_BlockEnsureSessionProperty;

        internal MarsSceneModuleSceneTrackingDrawer(SerializedObject serializedObject)
        {
            m_BlockEnsureSessionProperty = serializedObject.FindProperty("m_BlockEnsureSession");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_BlockEnsureSessionProperty);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }

    class MarsSceneModuleSimulationSettingsDrawer
    {
        SerializedProperty m_SimulateInPlayModeProperty;
        SerializedProperty m_SimulationIslandProperty;
        SerializedProperty m_SimulateDiscoveryProperty;
        SerializedProperty m_SimulatedDiscoveryIslandProperty;
        bool m_Advanced;

        internal MarsSceneModuleSimulationSettingsDrawer(SerializedObject serializedObject)
        {
            m_SimulateInPlayModeProperty = serializedObject.FindProperty("m_SimulateInPlayMode");
            m_SimulationIslandProperty = serializedObject.FindProperty("m_SimulationIsland");
            m_SimulateDiscoveryProperty = serializedObject.FindProperty("m_SimulateDiscovery");
            m_SimulatedDiscoveryIslandProperty = serializedObject.FindProperty("m_SimulatedDiscoveryIsland");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_SimulateInPlayModeProperty);
                var simulateInPlayMode = m_SimulateInPlayModeProperty.boolValue;
                using (new EditorGUI.DisabledScope(!simulateInPlayMode))
                {
                    EditorGUILayout.PropertyField(m_SimulateDiscoveryProperty);
                }

                m_Advanced = EditorGUILayout.Foldout(m_Advanced, "Advanced");
                if (m_Advanced)
                {
                    using (new EditorGUI.IndentLevelScope())
                    {
                        using (new EditorGUI.DisabledScope(!simulateInPlayMode))
                        {
                            EditorGUILayout.PropertyField(m_SimulationIslandProperty);
                        }

                        using (new EditorGUI.DisabledScope(!simulateInPlayMode || !m_SimulateDiscoveryProperty.boolValue))
                        {
                            EditorGUILayout.PropertyField(m_SimulatedDiscoveryIslandProperty);
                        }
                    }
                }

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

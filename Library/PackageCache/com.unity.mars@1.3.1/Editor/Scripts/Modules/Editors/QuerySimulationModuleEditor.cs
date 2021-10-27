using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(QuerySimulationModule))]
    class QuerySimulationModuleEditor : Editor
    {
        QuerySimulationModuleDrawer m_QuerySimulationModuleDrawer;

        void OnEnable()
        {
            m_QuerySimulationModuleDrawer = new QuerySimulationModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_QuerySimulationModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class QuerySimulationModuleDrawer
    {
        SerializedProperty m_SimulationPollTimeProperty;
        SerializedProperty m_SimulationIslandProperty;
        SerializedProperty m_SimulatedDiscoveryIslandProperty;

        internal QuerySimulationModuleDrawer(SerializedObject serializedObject)
        {
            m_SimulationPollTimeProperty = serializedObject.FindProperty("m_SimulationPollTime");
            m_SimulationIslandProperty = serializedObject.FindProperty("m_SimulationIsland");
            m_SimulatedDiscoveryIslandProperty = serializedObject.FindProperty("m_SimulatedDiscoveryIsland");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_SimulationPollTimeProperty);
                EditorGUILayout.PropertyField(m_SimulationIslandProperty);
                EditorGUILayout.PropertyField(m_SimulatedDiscoveryIslandProperty);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

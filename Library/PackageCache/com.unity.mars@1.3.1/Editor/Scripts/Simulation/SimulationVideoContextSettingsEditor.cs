using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS.Simulation
{
    [CustomEditor(typeof(SimulationVideoContextSettings))]
    class SimulationVideoContextSettingsEditor : Editor
    {
        SimulationVideoContextSettingsDrawer m_VideoContextSettingsDrawer;

        void OnEnable()
        {
            m_VideoContextSettingsDrawer = new SimulationVideoContextSettingsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_VideoContextSettingsDrawer.InspectorGUI(serializedObject);
        }
    }

    class SimulationVideoContextSettingsDrawer
    {
        SerializedProperty m_SimulatedFocalLength;
        SerializedProperty m_VideoBackgroundScale;

        internal SimulationVideoContextSettingsDrawer(SerializedObject serializedObject)
        {
            m_SimulatedFocalLength = serializedObject.FindProperty("m_SimulatedFocalLength");
            m_VideoBackgroundScale = serializedObject.FindProperty("m_VideoBackgroundScale");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_SimulatedFocalLength);
                EditorGUILayout.PropertyField(m_VideoBackgroundScale);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

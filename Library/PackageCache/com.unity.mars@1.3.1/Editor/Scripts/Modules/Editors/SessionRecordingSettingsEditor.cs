using Unity.MARS.Data.Recorded;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(SessionRecordingSettings))]
    class SessionRecordingSettingsEditor : Editor
    {
        SessionRecordingSettingsDrawer m_RecordingSettingsDrawer;

        void OnEnable()
        {
            m_RecordingSettingsDrawer = new SessionRecordingSettingsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_RecordingSettingsDrawer.InspectorGUI(serializedObject);
        }
    }

    class SessionRecordingSettingsDrawer
    {
        SerializedProperty m_CameraPoseIntervalProperty;

        public SessionRecordingSettingsDrawer(SerializedObject serializedObject)
        {
            m_CameraPoseIntervalProperty = serializedObject.FindProperty("m_CameraPoseInterval");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_CameraPoseIntervalProperty);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

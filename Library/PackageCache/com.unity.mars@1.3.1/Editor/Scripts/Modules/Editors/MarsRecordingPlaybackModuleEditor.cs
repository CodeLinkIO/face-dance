using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS.Recording
{
    [CustomEditor(typeof(MarsRecordingPlaybackModule))]
    class MarsRecordingPlaybackModuleEditor : Editor
    {
        MarsRecordingPlaybackModuleDrawer m_RecordingPlaybackModuleDrawer;

        void OnEnable()
        {
            m_RecordingPlaybackModuleDrawer = new MarsRecordingPlaybackModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_RecordingPlaybackModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class MarsRecordingPlaybackModuleDrawer
    {
        SerializedProperty m_TimeToFinalizeTimelineChange;
        SerializedProperty m_TimelineSyncTimeScale;
        SerializedProperty m_AutoSyncWithTimeChanges;

        public MarsRecordingPlaybackModuleDrawer(SerializedObject serializedObject)
        {
            m_TimeToFinalizeTimelineChange = serializedObject.FindProperty("m_TimeToFinalizeTimelineChange");
            m_TimelineSyncTimeScale = serializedObject.FindProperty("m_TimelineSyncTimeScale");
            m_AutoSyncWithTimeChanges = serializedObject.FindProperty("m_AutoSyncWithTimeChanges");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_TimeToFinalizeTimelineChange);
                EditorGUILayout.PropertyField(m_TimelineSyncTimeScale);
                EditorGUILayout.PropertyField(m_AutoSyncWithTimeChanges);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

using Unity.MARS.Data.Recorded;
using UnityEditor;

namespace Unity.MARS
{
    [CustomEditor(typeof(SessionRecordingInfo))]
    class SessionRecordingInfoEditor : Editor
    {
        SerializedProperty m_TimelineProperty;
        SerializedProperty m_DataRecordingsProperty;
        SerializedProperty m_SyntheticEnvironmentsProperty;
        SerializedProperty m_DefaultExtrapolationModeProperty;

        void OnEnable()
        {
            m_TimelineProperty = serializedObject.FindProperty("m_Timeline");
            m_DataRecordingsProperty = serializedObject.FindProperty("m_DataRecordings");
            m_SyntheticEnvironmentsProperty = serializedObject.FindProperty("m_SyntheticEnvironments");
            m_DefaultExtrapolationModeProperty = serializedObject.FindProperty("m_DefaultExtrapolationMode");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.PropertyField(m_TimelineProperty);
                EditorGUILayout.PropertyField(m_DataRecordingsProperty, true);
            }

            EditorGUILayout.PropertyField(m_SyntheticEnvironmentsProperty, true);
            EditorGUILayout.PropertyField(m_DefaultExtrapolationModeProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

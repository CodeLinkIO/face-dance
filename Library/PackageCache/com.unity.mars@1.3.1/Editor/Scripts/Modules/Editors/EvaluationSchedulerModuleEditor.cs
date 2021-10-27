using Unity.MARS.Query;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(EvaluationSchedulerModule))]
    class EvaluationSchedulerModuleEditor : Editor
    {
        EvaluationSchedulerModuleDrawer m_EvaluationSchedulerModuleDrawer;

        void OnEnable()
        {
            m_EvaluationSchedulerModuleDrawer = new EvaluationSchedulerModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_EvaluationSchedulerModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class EvaluationSchedulerModuleDrawer
    {
        SerializedProperty m_StartupMode;
        SerializedProperty m_EvaluationInterval;
        SerializedProperty m_MinimumEvaluationInterval;

        internal EvaluationSchedulerModuleDrawer(SerializedObject serializedObject)
        {
            m_StartupMode = serializedObject.FindProperty("m_StartupMode");
            m_EvaluationInterval = serializedObject.FindProperty("m_EvaluationInterval");
            m_MinimumEvaluationInterval = serializedObject.FindProperty("m_MinimumEvaluationInterval");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_StartupMode);
                EditorGUILayout.PropertyField(m_EvaluationInterval);
                EditorGUILayout.PropertyField(m_MinimumEvaluationInterval);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

using Unity.MARS.Data.Reasoning;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(ReasoningModule))]
    class ReasoningModuleEditor : Editor
    {
        ReasoningModuleDrawer m_ReasoningModuleDrawer;

        void OnEnable()
        {
            m_ReasoningModuleDrawer = new ReasoningModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_ReasoningModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class ReasoningModuleDrawer
    {
        SerializedProperty m_AddDefaultReasoningApis;
        SerializedProperty m_ReasoningApis;

        internal ReasoningModuleDrawer(SerializedObject serializedObject)
        {
            m_AddDefaultReasoningApis = serializedObject.FindProperty("m_AddDefaultReasoningApis");
            m_ReasoningApis = serializedObject.FindProperty("m_ReasoningApis");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_AddDefaultReasoningApis);
                EditorGUILayout.PropertyField(m_ReasoningApis);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

using Unity.MARS.Simulation;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(MarsTimeModule))]
    class MarsTimeModuleEditor : Editor
    {
        MarsTimeModuleDrawer m_TimeModuleDrawer;

        void OnEnable()
        {
            m_TimeModuleDrawer = new MarsTimeModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_TimeModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class MarsTimeModuleDrawer
    {
        SerializedProperty m_TimeStep;

        public MarsTimeModuleDrawer(SerializedObject serializedObject)
        {
            m_TimeStep = serializedObject.FindProperty("m_TimeStep");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_TimeStep);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

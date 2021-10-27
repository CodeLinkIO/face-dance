using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS.Forces
{
    [CustomEditor(typeof(ProxyForcesFieldSolverModule))]
    class ProxyForcesFieldSolverModuleEditor : Editor
    {
        ProxyForcesFieldSolverModuleDrawer m_ProxyForcesFieldSolverModuleDrawer;

        void OnEnable()
        {
            m_ProxyForcesFieldSolverModuleDrawer = new ProxyForcesFieldSolverModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_ProxyForcesFieldSolverModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class ProxyForcesFieldSolverModuleDrawer
    {
        SerializedProperty m_ShowForcesInSceneView;

        public ProxyForcesFieldSolverModuleDrawer(SerializedObject serializedObject)
        {
            m_ShowForcesInSceneView = serializedObject.FindProperty("m_ShowForcesInSceneView");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_ShowForcesInSceneView);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

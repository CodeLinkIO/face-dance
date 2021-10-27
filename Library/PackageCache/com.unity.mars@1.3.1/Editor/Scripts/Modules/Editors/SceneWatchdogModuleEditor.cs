using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(SceneWatchdogModule))]
    class SceneWatchdogModuleEditor : Editor
    {
        SceneWatchdogModuleDrawer m_SceneWatchdogModuleDrawer;

        void OnEnable()
        {
            m_SceneWatchdogModuleDrawer = new SceneWatchdogModuleDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_SceneWatchdogModuleDrawer.InspectorGUI(serializedObject);
        }
    }

    class SceneWatchdogModuleDrawer
    {
        SerializedProperty m_PollingIntervalProperty;

        public SceneWatchdogModuleDrawer(SerializedObject serializedObject)
        {
            m_PollingIntervalProperty = serializedObject.FindProperty("m_PollingInterval");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_PollingIntervalProperty);

                if (changed.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

using System;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS.MARSEditor
{
    [CustomEditor(typeof(MARSEnvironmentManager))]
    class MarsEnvironmentManagerEditor : Editor
    {
        MarsEnvironmentManagerDrawer m_EnvironmentManagerDrawer;

        void OnEnable()
        {
            m_EnvironmentManagerDrawer = new MarsEnvironmentManagerDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_EnvironmentManagerDrawer.InspectorGUI(serializedObject);
        }
    }

    class MarsEnvironmentManagerDrawer
    {
        SerializedProperty m_SimulationEnvironmentModeSettingsProperty;

        internal MarsEnvironmentManagerDrawer(SerializedObject serializedObject)
        {
            m_SimulationEnvironmentModeSettingsProperty = serializedObject.FindProperty("m_SimulationEnvironmentModeSettings");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var change = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_SimulationEnvironmentModeSettingsProperty);

                if (change.changed)
                {
                    serializedObject.ApplyModifiedProperties();

                    var envManager = serializedObject.targetObject as MARSEnvironmentManager;
                    if (envManager != null)
                        envManager.UpdateSimulatedEnvironmentCandidates();
                }
            }
        }
    }
}

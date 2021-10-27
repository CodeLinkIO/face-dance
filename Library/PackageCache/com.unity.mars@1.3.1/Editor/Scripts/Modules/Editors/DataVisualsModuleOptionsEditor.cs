using Unity.MARS.Authoring;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(DataVisualsModuleOptions))]
    class DataVisualsModuleOptionsEditor : Editor
    {
        DataVisualsModuleOptionsDrawer m_DataVisualsModuleOptionsDrawer;

        void OnEnable()
        {
            m_DataVisualsModuleOptionsDrawer = new DataVisualsModuleOptionsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_DataVisualsModuleOptionsDrawer.InspectorGUI(serializedObject);
        }
    }

    class DataVisualsModuleOptionsDrawer
    {
        SerializedProperty m_ShowDataVisualsInHierarchy;
        SerializedProperty m_DisableSimulationDataVisuals;
        SerializedProperty m_RatingGradient;

        internal DataVisualsModuleOptionsDrawer(SerializedObject serializedObject)
        {
            m_ShowDataVisualsInHierarchy = serializedObject.FindProperty("m_ShowDataVisualsInHierarchy");
            m_DisableSimulationDataVisuals = serializedObject.FindProperty("m_DisableSimulationDataVisuals");
            m_RatingGradient = serializedObject.FindProperty("m_RatingGradient");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            serializedObject.Update();
            EditorGUILayout.PropertyField(m_ShowDataVisualsInHierarchy);
            EditorGUILayout.PropertyField(m_DisableSimulationDataVisuals);
            EditorGUILayout.PropertyField(m_RatingGradient);

            if (serializedObject.ApplyModifiedProperties())
                ModuleLoaderCore.instance.ReloadModules(); // Reload modules is needed for changes to take effect.

            if (GUILayout.Button("Reset Defaults"))
            {
                var options = serializedObject.targetObject as DataVisualsModuleOptions;
                if (options != null)
                    options.ResetDefaultPreferences();

                AssetDatabase.SaveAssets(); // Save assets so that default values are applied to the asset and update immediately in all drawers
            }
        }
    }
}

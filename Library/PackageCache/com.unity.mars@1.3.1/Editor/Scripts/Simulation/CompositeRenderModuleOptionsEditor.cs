using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Unity.MARS
{
    [CustomEditor(typeof(CompositeRenderModuleOptions))]
    class CompositeRenderModuleOptionsEditor : Editor
    {
        CompositeRenderModuleOptionsDrawer m_CompositeRenderModuleOptionsDrawer;

        void OnEnable()
        {
            m_CompositeRenderModuleOptionsDrawer = new CompositeRenderModuleOptionsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_CompositeRenderModuleOptionsDrawer.InspectorGUI(serializedObject);
        }
    }

    class CompositeRenderModuleOptionsDrawer
    {
        SerializedProperty m_UseFallbackCompositeRenderingProperty;

        internal CompositeRenderModuleOptionsDrawer(SerializedObject serializedObject)
        {
            m_UseFallbackCompositeRenderingProperty = serializedObject.FindProperty("m_UseFallbackCompositeRendering");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (new EditorGUI.DisabledScope(Application.isPlaying))
            {
                using (var changed = new EditorGUI.ChangeCheckScope())
                {
                    using (new EditorGUI.DisabledScope(RenderPipelineManager.currentPipeline != null))
                    {
                        EditorGUILayout.PropertyField(m_UseFallbackCompositeRenderingProperty);
                    }

                    if (changed.changed)
                    {
                        serializedObject.ApplyModifiedProperties();

                        if (ModuleLoaderCore.instance != null)
                            ModuleLoaderCore.instance.ReloadModules();
                    }
                }
            }
        }
    }
}

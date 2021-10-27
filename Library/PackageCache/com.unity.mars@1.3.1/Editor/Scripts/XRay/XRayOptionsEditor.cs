using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Unity.MARS
{
    [CustomEditor(typeof(XRayOptions))]
    class XRayOptionsEditor : Editor
    {
        XRayOptionsDrawer m_XRayOptionsDrawer;

        void OnEnable()
        {
            m_XRayOptionsDrawer = new XRayOptionsDrawer(serializedObject);
        }

        public override void OnInspectorGUI()
        {
            m_XRayOptionsDrawer.InspectorGUI(serializedObject);
        }
    }

    class XRayOptionsDrawer
    {
        SerializedProperty m_FlipXRayDirectionProperty;

        internal XRayOptionsDrawer(SerializedObject serializedObject)
        {
            m_FlipXRayDirectionProperty = serializedObject.FindProperty("m_FlipXRayDirection");
        }

        internal void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PrefixLabel("URP Options", EditorStyles.boldLabel);
                using (new EditorGUI.DisabledScope(RenderPipelineManager.currentPipeline == null))
                {
                    EditorGUILayout.PropertyField(m_FlipXRayDirectionProperty);
                }

                if (changed.changed)
                {
                    serializedObject.ApplyModifiedProperties();
                    XRayModule.SetXRayDirectionKeyword();
                }
            }
        }
    }
}

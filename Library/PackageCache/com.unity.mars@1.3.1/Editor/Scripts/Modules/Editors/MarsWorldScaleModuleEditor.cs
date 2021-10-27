using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(MarsWorldScaleModule))]
    class MarsWorldScaleModuleEditor : Editor
    {
        SerializedProperty m_MinScaleExponentProperty;
        SerializedProperty m_MaxScaleExponentProperty;
        SerializedProperty m_ScaleIconsProperty;
        SerializedProperty m_ScaleReferenceMaterialProperty;

        GUIContent[] m_ScaleVisualLabels;

        void OnEnable()
        {
            m_MinScaleExponentProperty = serializedObject.FindProperty("m_MinScaleExponent");
            m_MaxScaleExponentProperty = serializedObject.FindProperty("m_MaxScaleExponent");

            m_ScaleIconsProperty = serializedObject.FindProperty("m_ScaleVisuals");

            m_ScaleReferenceMaterialProperty = serializedObject.FindProperty("m_ScaleReferenceMaterial");

            var scaleModule = MarsWorldScaleModule.instance;

            UpdateScaleVisualLabels(scaleModule.minScaleExponent,scaleModule.maxScaleExponent);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            int minExponent;
            int maxExponent;

            using (var change = new EditorGUI.ChangeCheckScope())
            {
                minExponent = EditorGUILayout.DelayedIntField(m_MinScaleExponentProperty.displayName, m_MinScaleExponentProperty.intValue);
                maxExponent = EditorGUILayout.DelayedIntField(m_MaxScaleExponentProperty.displayName, m_MaxScaleExponentProperty.intValue);
                if (change.changed)
                {
                    if (maxExponent <= minExponent)
                        maxExponent = minExponent + 1;

                    m_MinScaleExponentProperty.intValue = minExponent;
                    m_MaxScaleExponentProperty.intValue = maxExponent;
                }
            }

            var count = maxExponent - minExponent + 1;

            if (m_ScaleIconsProperty.arraySize != count || m_ScaleVisualLabels.Length != m_ScaleIconsProperty.arraySize)
                UpdateScaleVisualLabels(minExponent, maxExponent);

            EditorGUILayout.PropertyField(m_ScaleReferenceMaterialProperty);

            EditorGUILayout.LabelField("Scale Visuals", EditorStyles.boldLabel);

            var scaleIconProperty = m_ScaleIconsProperty.GetArrayElementAtIndex(0);
            for (var i = 0; i < count; i++)
            {
                EditorGUILayout.PropertyField(scaleIconProperty, m_ScaleVisualLabels[i]);
                scaleIconProperty.NextVisible(false);
            }

            serializedObject.ApplyModifiedProperties();
        }

        void UpdateScaleVisualLabels(int minExponent, int maxExponent)
        {
            var count = maxExponent - minExponent + 1;

            m_ScaleIconsProperty.arraySize = count;

            m_ScaleVisualLabels = new GUIContent[count];

            for (int i = minExponent, j = 0; j < count; i++, j++)
            {
                string label;
                if (j == 0)
                    label = " Smallest";
                else if (j == count - 1)
                    label = " Largest";
                else if (i == 0)
                    label = " 1 : 1";
                else
                    label = string.Empty;

                label = string.Format("{0}{1}{2}", i < 0 ? "1e" : "1e+", i, label);

                m_ScaleVisualLabels[j] = new GUIContent(label);
            }

            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }
}

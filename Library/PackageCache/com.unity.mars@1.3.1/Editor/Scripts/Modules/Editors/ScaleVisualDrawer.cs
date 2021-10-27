using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomPropertyDrawer(typeof(MarsWorldScaleModule.ScaleVisual))]
    class ScaleVisualDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var itemStep = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            using (new EditorGUI.PropertyScope(position, label, property))
            {
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

                var indent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                position.height = EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(position, property.FindPropertyRelative("m_ScaleVisual"), new GUIContent("Visual"));

                position.y += itemStep;
                EditorGUI.PropertyField(position, property.FindPropertyRelative("m_ScaleIcon"), new GUIContent("Icon"));

                EditorGUI.indentLevel = indent;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 3 + EditorGUIUtility.standardVerticalSpacing * 2;
        }
    }
}

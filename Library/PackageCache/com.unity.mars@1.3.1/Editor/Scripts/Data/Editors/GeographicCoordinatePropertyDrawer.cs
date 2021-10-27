using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Data
{
    [CustomPropertyDrawer(typeof(GeographicCoordinate))]
    class GeographicCoordinatePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var lineHeight = EditorGUIUtility.singleLineHeight;

            var latRect = new Rect(position.x, position.y, position.width, lineHeight);
            var longRect = new Rect(position.x, position.y + lineHeight, position.width, lineHeight);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PropertyField(latRect, property.FindPropertyRelative("latitude"));
            EditorGUI.PropertyField(longRect, property.FindPropertyRelative("longitude"));
            EditorGUI.EndProperty();

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2;
        }
    }
}

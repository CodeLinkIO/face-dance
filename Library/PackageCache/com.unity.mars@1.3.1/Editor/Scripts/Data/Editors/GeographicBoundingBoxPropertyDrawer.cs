using UnityEditor;
using UnityEngine;

namespace Unity.MARS.Data
{
    [CustomPropertyDrawer(typeof(GeographicBoundingBox))]
    class GeographicBoundingBoxPropertyDrawer : PropertyDrawer
    {
        readonly GUIContent m_CenterContent = new GUIContent("Center");
        readonly GUIContent m_ExtentsContent = new GUIContent("Extents");
        readonly GUIContent m_LatitudeContent = new GUIContent("Latitude");
        readonly GUIContent m_LongitudeContent = new GUIContent("Longitude");

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var lineHeight = EditorGUIUtility.singleLineHeight;

            var firstRect = new Rect(position.x, position.y, position.width, lineHeight);
            var centerLatRect = new Rect(position.x, position.y + lineHeight, position.width, lineHeight);
            var centerLongRect = new Rect(position.x, position.y + lineHeight * 2, position.width, lineHeight);
            var extentsLabelRect = new Rect(position.x, position.y + lineHeight * 3, position.width, lineHeight);

            EditorGUI.PrefixLabel(firstRect, GUIUtility.GetControlID(FocusType.Passive), m_CenterContent);
            using (new EditorGUI.IndentLevelScope())
            {
                EditorGUI.PropertyField(centerLatRect, property.FindPropertyRelative("center.latitude"));
                EditorGUI.PropertyField(centerLongRect, property.FindPropertyRelative("center.longitude"));
            }

            EditorGUI.PrefixLabel(extentsLabelRect, GUIUtility.GetControlID(FocusType.Passive), m_ExtentsContent);

            var latExtentsRect = new Rect(position.x, position.y + lineHeight * 4, position.width, lineHeight);
            var longExtentsRect = new Rect(position.x, position.y + lineHeight * 5, position.width, lineHeight);
            using (new EditorGUI.IndentLevelScope())
            {
                EditorGUI.PropertyField(latExtentsRect, property.FindPropertyRelative("latitudeExtents"),
                    m_LatitudeContent);
                EditorGUI.PropertyField(longExtentsRect, property.FindPropertyRelative("longitudeExtents"),
                    m_LongitudeContent);
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 6;
        }
    }
}

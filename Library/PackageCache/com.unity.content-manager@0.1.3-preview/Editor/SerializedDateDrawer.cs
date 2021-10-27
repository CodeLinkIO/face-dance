using System;
using UnityEditor;
using UnityEngine;

namespace Unity.ContentManager
{
    [CustomPropertyDrawer(typeof(SerializedDate))]
    class SerializedDateDrawer : PropertyDrawer
    {
        const string k_TickId = "m_Ticks";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var tickProperty = property.FindPropertyRelative(k_TickId);
            if (tickProperty == null)
                return;

            var tickCount = tickProperty.longValue;
            var dateString = EditorGUI.DelayedTextField(position, label, new DateTime(tickCount).ToShortDateString());

            if (DateTime.TryParse(dateString, out var newDate))
            {
                tickProperty.longValue = newDate.Ticks;
            }
        }
    }
}

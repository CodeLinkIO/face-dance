using System;
using Unity.MARS.Query;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomPropertyDrawer(typeof(CommonQueryData))]
    class SharedQueryDataEditor : PropertyDrawer
    {
        const string k_OverrideName = "overrideTimeout";
        const string k_TimeoutName = "timeOut";
        const string k_IntervalName = "updateMatchInterval";
        const string k_ReacquireName = "reacquireOnLoss";
        const string k_PriorityName = "priority";

        const string k_PriorityDisabledInGroupText = "Priority for proxies that are in a Proxy Group is controlled by the group";
        const string k_PriorityDisabledExclusivityText = "Priority has no effect for proxies that don't have exclusivity set to Reserved";

        static readonly GUIContent k_PriorityDisabledInGroupContent = new GUIContent("Priority", k_PriorityDisabledInGroupText);
        static readonly GUIContent k_PriorityDisabledExclusivityContent = new GUIContent("Priority", k_PriorityDisabledExclusivityText);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, property, label, false);
            if (property.isExpanded)
            {
                var overrideData = EditorGUIUtils.FindSerializedPropertyData(property.FindPropertyRelative(k_OverrideName));
                var timeout = EditorGUIUtils.FindSerializedPropertyData(property.FindPropertyRelative(k_TimeoutName));

                position.y += EditorGUIUtility.singleLineHeight;
                EditorGUIUtils.PropertyFieldInRect(position, overrideData, timeout);
                position.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(position, property.FindPropertyRelative(k_IntervalName));
                position.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.PropertyField(position, property.FindPropertyRelative(k_ReacquireName));
                position.y += EditorGUIUtility.singleLineHeight;

                DrawPriority(ref position, property);
            }

            EditorGUI.EndProperty();
        }

        static void DrawPriority(ref Rect position, SerializedProperty property)
        {
            // doing this group check every GUI call is not ideal performance wise,
            // but it's the simplest way to make the UI always show the right thing
            var inGroup = false;
            var isNotReserved = false;
            var hostObject = property.serializedObject;
            var asProxy = hostObject.targetObject as Proxy;
            if (asProxy != null)
            {
                // read only & shared proxies not in groups have no use for priority.
                isNotReserved = asProxy.exclusivity != Exclusivity.Reserved;
                inGroup = asProxy.GetComponentInParent<ProxyGroup>() != null;
            }

            var isDisabled = isNotReserved || inGroup;
            using (new EditorGUI.DisabledScope(isDisabled))
            {
                var priorityProperty = property.FindPropertyRelative(k_PriorityName);

                // if we're disabling the priority control, set the tooltip to show the reason why
                if (isDisabled)
                {
                    var priority = FromEnumIndex(priorityProperty.enumValueIndex);
                    var content = inGroup ? k_PriorityDisabledInGroupContent : k_PriorityDisabledExclusivityContent;
                    priority = (MarsEntityPriority) EditorGUI.EnumPopup(position, content, priority);
                    priorityProperty.enumValueIndex = ToEnumIndex(priority);
                }
                else
                {
                    EditorGUI.PropertyField(position, priorityProperty);
                }
            }
        }

        static MarsEntityPriority FromEnumIndex(int index)
        {
            switch (index)
            {
                case 0: return MarsEntityPriority.Minimum;
                case 1: return MarsEntityPriority.Low;
                case 2: return MarsEntityPriority.Normal;
                case 3: return MarsEntityPriority.High;
                case 4: return MarsEntityPriority.Maximum;
                default: return MarsEntityPriority.Normal;
            }
        }

        static int ToEnumIndex(MarsEntityPriority index)
        {
            switch (index)
            {
                case MarsEntityPriority.Minimum : return 0;
                case MarsEntityPriority.Low : return 1;
                case MarsEntityPriority.Normal : return 2;
                case MarsEntityPriority.High : return 3;
                case MarsEntityPriority.Maximum : return 4;
                default: return 0;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.isExpanded)
            {
                return EditorGUIUtility.singleLineHeight * 5;
            }
            else
            {
                return EditorGUIUtility.singleLineHeight;
            }
        }
    }
}

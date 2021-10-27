using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.MARS.Attributes;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Stores the data for drawing UnityEvent inspectors with the reflection data needed to find and modify the event.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class EventInspectorData
    {
        /// <summary>
        /// Collection of <c>UnityEventBase</c>s for a serialized property
        /// </summary>
        public UnityEventBase[] unityEvents;
        /// <summary>
        /// Serialized property for unity events
        /// </summary>
        public SerializedProperty property;
        /// <summary>
        /// Is the event property shown in an expanded form
        /// </summary>
        public bool show;
        /// <summary>
        /// Is the property hidden since no events are attached
        /// </summary>
        public bool hidden;
    }

    /// <summary>
    /// Collection of editor tools for drawing and using <c>EventInspectorData</c>
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class EventInspectorUtils
    {
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<FieldInfo> k_Fields = new List<FieldInfo>();

        /// <summary>
        /// Determines what events are displayed and when not displayed removes the listeners.
        /// </summary>
        /// <param name="serializedObject">Serialized Object from inspector.</param>
        /// <param name="eventInspectorData">Collection of data needed to draw and manage custom event inspectors.</param>
        public static void SyncEventDrawers(
            SerializedObject serializedObject, Dictionary<FieldInfo, EventInspectorData> eventInspectorData)
        {
            foreach (var kvp in eventInspectorData)
            {
                var fieldInfo = kvp.Key;
                var fieldName = fieldInfo.Name;
                var property = serializedObject.FindProperty(fieldName);
                UnityEventBase[] events = null;
                if (property != null)
                {
                    events = serializedObject.targetObjects.Select(
                        t => fieldInfo.GetValue(t) as UnityEventBase).ToArray();
                }

                var inspectorDatum = kvp.Value;
                inspectorDatum.property = property;
                inspectorDatum.unityEvents = events;

                if (property == null)
                    inspectorDatum.hidden = true;
                else if (events.Length > 0 && events.GetPersistentEventGreatestCount() > 0)
                    inspectorDatum.show = true;
            }
        }

        /// <summary>
        /// Draws the visible events area.
        /// </summary>
        /// <param name="serializedObject">Serialized Object from inspector.</param>
        /// <param name="eventInspectorData">Collection of data needed to draw and manage custom event inspectors.</param>
        public static void OnEventDrawerGUI(
            SerializedObject serializedObject, Dictionary<FieldInfo, EventInspectorData> eventInspectorData)
        {
            // Need to first check and see if any data was lost on domain reload.
            foreach (var kvp in eventInspectorData)
            {
                var data = kvp.Value;
                if (!data.hidden && (data.property == null || data.unityEvents == null))
                {
                    SyncEventDrawers(serializedObject, eventInspectorData);
                    break;
                }
            }

            EditorGUI.BeginChangeCheck();

            serializedObject.Update();
            foreach (var kvp in eventInspectorData)
            {
                var data = kvp.Value;
                if (data.hidden)
                    continue;

                if (data.show)
                {
                    var remove = DrawEventPropertyField(data);
                    if (remove != null)
                    {
                        remove.show = false;
                    }
                }
            }
            serializedObject.ApplyModifiedProperties();

            var addButtonPosition = GUILayoutUtility.GetRect(MarsEditorGUI.Styles.AddButtonContent, GUI.skin.button);
            const float addButtonWidth = 200f;
            addButtonPosition.x = addButtonPosition.x + (addButtonPosition.width - addButtonWidth) / 2;
            addButtonPosition.width = addButtonWidth;

            if (GUI.Button(addButtonPosition, MarsEditorGUI.Styles.AddButtonContent))
            {
                ShowAddEventMenu(eventInspectorData);
            }

            if (EditorGUI.EndChangeCheck())
            {
                SyncEventDrawers(serializedObject, eventInspectorData);
            }
        }

        /// <summary>
        /// Draws the event property with a minus button to remove the event.
        /// </summary>
        /// <param name="inspectorData">Event we are drawing.</param>
        /// <returns>Returns EventInspectorData of the field that needs to be removed</returns>
        static EventInspectorData DrawEventPropertyField(EventInspectorData inspectorData)
        {
            if (inspectorData.hidden)
                return null;

            var eventProperty = inspectorData.property;
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var callsProperty = eventProperty.FindPropertyRelative("m_PersistentCalls.m_Calls");
                var prevCallsCount = callsProperty.arraySize;
                EditorGUILayout.PropertyField(inspectorData.property, false);
                if (check.changed)
                {
                    var callsCount = callsProperty.arraySize;
                    if (callsCount > prevCallsCount)
                    {
                        // For each new call that was added, default to Editor And Runtime for compatibility with simulation
                        var callIndex = prevCallsCount;
                        while (callIndex < callsCount)
                        {
                            var callState = callsProperty.GetArrayElementAtIndex(callIndex).FindPropertyRelative("m_CallState");
                            callState.enumValueIndex = 1;
                            callIndex++;
                        }
                    }
                }
            }

            var callbackRect = GUILayoutUtility.GetLastRect();
            var removeButtonSize = MarsEditorGUI.Styles.IconToolbarMinusSize;

            const float edgePaddingScale = 1.5f;
            const float topPadding = 1f;
            var removeButtonPos = new Rect(callbackRect.xMax - removeButtonSize.x * edgePaddingScale,
                callbackRect.y + topPadding, removeButtonSize.x, removeButtonSize.y);

            EventInspectorData returnType = null;
            if (GUI.Button(removeButtonPos, MarsEditorGUI.Styles.IconToolbarMinus, GUIStyle.none))
            {
                returnType = inspectorData;
                var remove = eventProperty.FindPropertyRelative("m_PersistentCalls.m_Calls");
                remove.arraySize = 0;
            }

            EditorGUILayout.Space();
            return returnType;
        }

        /// <summary>
        /// Draws the menu to add event of field name.
        /// </summary>
        /// <param name="eventInspectorData">Collection of data needed to draw and manage custom event inspectors.</param>
        static void ShowAddEventMenu(Dictionary<FieldInfo, EventInspectorData> eventInspectorData)
        {
            var menu = new GenericMenu();
            foreach (var kvp in eventInspectorData)
            {
                var data = kvp.Value;
                if (data.hidden)
                    continue;

                var label = new GUIContent(data.property.displayName);
                if (!data.show)
                {
                    var closureData = data;
                    menu.AddItem(label, false, () =>
                    {
                        closureData.show = true;
                    });
                }
                else
                    menu.AddDisabledItem(label);
            }
            menu.ShowAsContext();
            Event.current.Use();
        }

        /// <summary>
        /// Returns the largest persistent event count from events array.
        /// </summary>
        /// <param name="unityEvents"> UnityEvents we are getting the persistent count of.</param>
        /// <returns>Largest persistent event count from UnityEvents array.</returns>
        public static int GetPersistentEventGreatestCount(this UnityEventBase[] unityEvents)
        {
            if (unityEvents.Length <= 0)
                return 0;

            var greatestCount = unityEvents[0].GetPersistentEventCount();
            foreach (var unityEvent in unityEvents)
            {
                if (unityEvent == null)
                    continue;

                if (greatestCount < unityEvent.GetPersistentEventCount())
                    greatestCount = unityEvent.GetPersistentEventCount();
            }
            return greatestCount;
        }

        /// <summary>
        /// Collect FieldInfo for fields marked with EventAttribute
        /// </summary>
        /// <param name="type">The type from which fields will be collected</param>
        /// <param name="fields">An empty list to which fields will be appended</param>
        public static void GetEvents(Type type, List<FieldInfo> fields)
        {
            k_Fields.Clear();
            type.GetFieldsRecursively(k_Fields);
            foreach (var field in k_Fields)
            {
                var fieldType = field.FieldType;
                if (fieldType.IsDefined(typeof(EventAttribute), true))
                {
                    var attributeType = fieldType.GetAttribute<EventAttribute>();
                    if (attributeType.type.IsAssignableFrom(fieldType))
                        fields.Add(field);
                }
            }
        }
    }
}

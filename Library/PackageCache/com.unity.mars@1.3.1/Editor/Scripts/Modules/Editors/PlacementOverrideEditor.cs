using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Authoring;
using UnityEditor;

namespace Unity.MARS
{
    /// <summary>
    /// Custom editor for PlacementOverride component that will hide or disable properties that are not needed for the current settings
    /// </summary>
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PlacementOverride))]
    class PlacementOverrideEditor : Editor
    {
        static readonly List<AxisEnum> k_AxisEnums;

        SerializedProperty m_SnapToPivotOverride;
        SerializedProperty m_OrientToSurfaceOverride;
        SerializedProperty m_AxisOverride;
        SerializedProperty m_CustomAxisOverride;

        static PlacementOverrideEditor()
        {
            k_AxisEnums = Enum.GetValues(typeof(AxisEnum)).Cast<AxisEnum>().ToList();
            k_AxisEnums.Sort((a, b) => a.CompareTo(b));
        }

        void OnEnable()
        {
            m_SnapToPivotOverride = serializedObject.FindProperty("m_SnapToPivotOverride");
            m_OrientToSurfaceOverride = serializedObject.FindProperty("m_OrientToSurfaceOverride");
            m_AxisOverride = serializedObject.FindProperty("m_AxisOverride");
            m_CustomAxisOverride = serializedObject.FindProperty("m_CustomAxisOverride");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_SnapToPivotOverride);
            EditorGUILayout.PropertyField(m_OrientToSurfaceOverride);
            EditorGUILayout.PropertyField(m_AxisOverride);
            using (new EditorGUI.IndentLevelScope())
            {
                if (k_AxisEnums[m_AxisOverride.enumValueIndex] == AxisEnum.Custom)
                    EditorGUILayout.PropertyField(m_CustomAxisOverride);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

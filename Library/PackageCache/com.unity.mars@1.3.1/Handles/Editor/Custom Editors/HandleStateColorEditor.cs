using UnityEngine;
using Unity.MARS.MARSHandles;
using UnityEditor;

namespace Unity.MARS.HandlesEditor
{
    [CustomEditor(typeof(HandleStateColors))]
    class HandleStateColorsEditor : Editor
    {
        static class Content
        {
            public static readonly GUIContent targetRendererPreview = EditorGUIUtility.TrTextContent("Target Renderer");
            public static readonly GUIContent hoverTitle = EditorGUIUtility.TrTextContent("Hover Color", "The color used when the parent handle is hovered");
            public static readonly GUIContent dragTitle = EditorGUIUtility.TrTextContent("Drag Color", "The color used when the parent handle is dragged");
            public static readonly GUIContent disableTitle = EditorGUIUtility.TrTextContent("Disable Color", "The color used when another handle is dragged");
            public static readonly GUIContent useDisableTitle = EditorGUIUtility.TrTextContent("Use Disable Color", "Should the disable color be used");
        }

        protected SerializedProperty hoverColor;
        protected SerializedProperty dragColor;
        protected SerializedProperty disableColor;
        protected SerializedProperty useDisableColor;

        protected Renderer targetRenderer => ((HandleStateColors)target).GetComponent<Renderer>();

        protected virtual void OnEnable()
        {
            hoverColor = serializedObject.FindProperty("m_HoverColor");
            dragColor = serializedObject.FindProperty("m_DragColor");
            disableColor = serializedObject.FindProperty("m_DisableColor");
            useDisableColor = serializedObject.FindProperty("m_UseDisableColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DoTargetRendererPreview();

            EditorGUILayout.Space();

            hoverColor.colorValue = EditorGUILayout.ColorField(Content.hoverTitle, hoverColor.colorValue);
            dragColor.colorValue = EditorGUILayout.ColorField(Content.dragTitle, dragColor.colorValue);

            useDisableColor.boolValue = EditorGUILayout.Toggle(Content.useDisableTitle, useDisableColor.boolValue);
            if (useDisableColor.boolValue)
            {
                ++EditorGUI.indentLevel;
                disableColor.colorValue = EditorGUILayout.ColorField(Content.disableTitle, disableColor.colorValue);
                --EditorGUI.indentLevel;
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected void DoTargetRendererPreview()
        {
            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.ObjectField(Content.targetRendererPreview, targetRenderer, typeof(Renderer), false);
            }
        }
    }
}

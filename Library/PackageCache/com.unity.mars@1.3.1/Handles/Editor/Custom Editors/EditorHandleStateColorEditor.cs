using UnityEngine;
using Unity.MARS.MARSHandles;
using UnityEditor;

namespace Unity.MARS.HandlesEditor
{
    [CustomEditor(typeof(EditorHandleStateColors))]
    sealed class EditorHandleStateColorEditor : HandleStateColorsEditor
    {
        static class Content
        {
            public static readonly string warningBox = L10n.Tr("This component only works in the editor. To change color based on state at runtime, use Handle State Color component instead.");
        }

        SerializedProperty m_IdleColorProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_IdleColorProperty = serializedObject.FindProperty("m_IdleColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.HelpBox(Content.warningBox, MessageType.Warning);

            DoTargetRendererPreview();

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_IdleColorProperty);
            EditorGUILayout.PropertyField(useDisableColor);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

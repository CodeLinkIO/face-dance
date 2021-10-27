using Unity.MARS.Attributes;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [ComponentEditor(typeof(ProxyGroup))]
    class ProxyGroupInspector : ComponentInspector
    {
        public const string childNameString = "({0}) {1}";
        const string k_InsufficientChildrenWarning = "This set must have at least 2 child Real World Objects for any of its relations to apply.";

        ProxyGroup m_Set;
        SerializedProperty m_ChildObjectsProperty;


        public override void OnEnable()
        {
            base.OnEnable();

            m_Set = target as ProxyGroup;
            m_ChildObjectsProperty = serializedObject.FindProperty("m_ChildObjects");
        }

        public override void OnInspectorGUI()
        {
            // Refresh Child Objects
            m_Set.RepopulateChildList();
            serializedObject.Update();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                DrawDefaultInspector();

                var childCount = m_ChildObjectsProperty.arraySize;
                if (childCount < 2)
                    EditorGUIUtils.Warning(k_InsufficientChildrenWarning);
                else
                {
                    EditorGUI.indentLevel ++;
                    EditorGUILayout.LabelField("Required Children");
                    EditorGUI.indentLevel ++;
                    var childIndex = 0;
                    while (childIndex < childCount)
                    {
                        var currentChild = m_ChildObjectsProperty.GetArrayElementAtIndex(childIndex);
                        var childObject = currentChild.FindPropertyRelative("arObject").objectReferenceValue as Component;
                        var childName = childObject != null ?
                            string.Format(childNameString, childObject.transform.GetSiblingIndex(), childObject.name) : "";
                        var requiredProperty = currentChild.FindPropertyRelative("required");

                        EditorGUILayout.PropertyField(requiredProperty, new GUIContent(childName));
                        childIndex++;
                    }
                    EditorGUI.indentLevel -= 2;
                }

                if (check.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

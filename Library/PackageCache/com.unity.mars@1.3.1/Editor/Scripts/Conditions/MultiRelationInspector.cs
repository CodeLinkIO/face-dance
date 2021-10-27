using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Editor that handles in-lining up to three member relation inspectors of a multi-relation into a single inspector
    /// </summary>
    [ComponentEditor(typeof(MultiRelationBase), true)]
    class MultiRelationInspector : RelationInspector
    {
        const string k_Relation1Name = "m_Relation1";
        const string k_Relation2Name = "m_Relation2";
        const string k_Relation3Name = "m_Relation3";
        const string k_RelationLabelRemoveString = "SubRelation";

        SerializedPropertyData m_Relation1Property;
        SerializedPropertyData m_Relation2Property;
        SerializedPropertyData m_Relation3Property;

        static Dictionary<IMRObject, SetChildArgs> s_TempChildArgs;

        GUIContent m_Relation1Label;
        GUIContent m_Relation2Label;
        GUIContent m_Relation3Label;

        protected MultiRelationBase multiRelation { get; private set; }
        public override void OnEnable()
        {
            base.OnEnable();
            multiRelation = (MultiRelationBase)target;

            InitializeSubRelationEditor(ref m_Relation1Property, ref m_Relation1Label, k_Relation1Name);
            InitializeSubRelationEditor(ref m_Relation2Property, ref m_Relation2Label, k_Relation2Name);
            InitializeSubRelationEditor(ref m_Relation3Property, ref m_Relation3Label, k_Relation3Name);

            RefreshChildren();
            SetChildren();
        }

        void SetChildren()
        {
            var child1 = (Proxy) m_Child1Property.objectReferenceValue;
            var child2 = (Proxy) m_Child2Property.objectReferenceValue;
            var child1Index = k_ChildObjects.IndexOf(child1);
            var child2Index = k_ChildObjects.IndexOf(child2);
            if (child1Index == -1 || child2Index == -1)
                return;

            multiRelation.SetChildren(k_ChildObjects[child1Index], k_ChildObjects[child2Index]);
            serializedObject.Update();
        }

        protected override void OnConditionInspectorGUI()
        {
            relation.EnsureChildClients();
            serializedObject.Update();

            if (DrawChildOptions())
            {
                SetChildren();
                serializedObject.ApplyModifiedProperties();
            }

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                ShowSubRelationEditor(m_Relation1Property, m_Relation1Label);
                ShowSubRelationEditor(m_Relation2Property, m_Relation2Label);
                ShowSubRelationEditor(m_Relation3Property, m_Relation3Label);

                if (check.changed)
                {
                    if (m_HandleMode == HandleMode.Hidden)
                        m_HandleMode = HandleMode.Preview;

                    serializedObject.ApplyModifiedProperties();
                }
            }
        }

        protected override void OnConditionSceneGUI() { }

        void InitializeSubRelationEditor(ref SerializedPropertyData subRelation, ref GUIContent label, string propertyName)
        {
            var property = serializedObject.FindProperty(propertyName);

            if (property == null)
                return;

            subRelation = serializedObject.FindSerializedPropertyData(propertyName);
            var typeName = subRelation.Type.Name.Replace(k_RelationLabelRemoveString, "");
            label = new GUIContent(typeName);
        }

        static void ShowSubRelationEditor(SerializedPropertyData subRelation, GUIContent label)
        {
            if (subRelation == null)
                return;

            EditorGUIUtils.PropertyField(subRelation, label,true);
        }
    }
}

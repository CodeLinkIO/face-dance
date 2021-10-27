using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Editor that handles in-lining up to 3 member condition inspectors of a multi-condition into a single inspector
    /// </summary>
    [ComponentEditor(typeof(MultiConditionBase), true)]
    class MultiConditionInspector : ConditionBaseInspector
    {
        const string k_Condition1Name = "m_Condition1";
        const string k_Condition2Name = "m_Condition2";
        const string k_Condition3Name = "m_Condition3";
        const string k_ConditionLabelRemoveString = "SubCondition";

        SerializedPropertyData m_Condition1Property;
        SerializedPropertyData m_Condition2Property;
        SerializedPropertyData m_Condition3Property;

        GUIContent m_Condition1Label;
        GUIContent m_Condition2Label;
        GUIContent m_Condition3Label;

        protected MultiConditionBase multiCondition { get; private set; }

        public override void OnEnable()
        {
            base.OnEnable();
            multiCondition = (MultiConditionBase)target;

            InitializeSubConditionEditor(ref m_Condition1Property, ref m_Condition1Label, k_Condition1Name);
            InitializeSubConditionEditor(ref m_Condition2Property, ref m_Condition2Label, k_Condition2Name);
            InitializeSubConditionEditor(ref m_Condition3Property, ref m_Condition3Label, k_Condition3Name);
        }

        protected override void OnConditionInspectorGUI()
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                serializedObject.Update();

                ShowSubConditionEditor(m_Condition1Property, m_Condition1Label);
                ShowSubConditionEditor(m_Condition2Property, m_Condition2Label);
                ShowSubConditionEditor(m_Condition3Property, m_Condition3Label);

                if (check.changed)
                {
                    if (m_HandleMode == HandleMode.Hidden)
                        m_HandleMode = HandleMode.Preview;

                    serializedObject.ApplyModifiedProperties();
                }
            }
        }

        protected override void OnConditionSceneGUI() { }

        void InitializeSubConditionEditor(ref SerializedPropertyData subCondition, ref GUIContent label, string propertyName)
        {
            var property = serializedObject.FindProperty(propertyName);

            if (property == null)
                return;

            subCondition = serializedObject.FindSerializedPropertyData(propertyName);
            var typeName = subCondition.Type.Name.Replace(k_ConditionLabelRemoveString, "");
            label = new GUIContent(typeName);
        }

        static void ShowSubConditionEditor(SerializedPropertyData subCondition, GUIContent label)
        {
            if (subCondition == null)
                return;

            EditorGUIUtils.PropertyField(subCondition, label,true);
        }
    }
}

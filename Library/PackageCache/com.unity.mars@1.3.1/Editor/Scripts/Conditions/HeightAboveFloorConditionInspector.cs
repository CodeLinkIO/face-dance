using System;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using UnityEditor.MARS.Authoring;
using UnityEngine;

namespace UnityEditor.MARS
{
    [ComponentEditor(typeof(HeightAboveFloorCondition))]
    class HeightAboveFloorConditionInspector : ComponentInspector
    {
        public override void OnInspectorGUI()
        {
            if (isDirty)
                CleanUp();

            serializedObject.Update();

            DrawDefaultInspector();

            MarsCompareTool.DrawComponentControls(target as HeightAboveFloorCondition);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

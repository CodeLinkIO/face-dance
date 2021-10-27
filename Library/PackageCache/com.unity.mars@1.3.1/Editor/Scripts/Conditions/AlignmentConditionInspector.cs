using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Authoring;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Inspector and scene handles for angle and axis condition
    /// </summary>
    [CanEditMultipleObjects]
    [ComponentEditor(typeof(AlignmentCondition))]
    class AlignmentConditionInspector : ComponentInspector
    {
        const float k_HorizontalThreshold = 0.1f;
        const string k_RotateObjectsUndoString = "Rotate Objects";
        static readonly Quaternion k_DefaultVerticalRotation = Quaternion.Euler(-90f, 0f, 0f);
        static readonly GUIContent k_AlignButtonContent = new GUIContent("Set Rotation:", "Set the rotation of this object in the scene, as a visual convenience");

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var alignmentCondition = (AlignmentCondition)target;
            MarsCompareTool.DrawComponentControls(alignmentCondition);

            GUILayout.Space(5);
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUIUtils.DrawCheckboxFillerRect();
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.Label(k_AlignButtonContent);
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button("Horizontal", EditorStyles.miniButtonLeft))
                        RotateTargetsHorizontal();
                    if (GUILayout.Button("Vertical", EditorStyles.miniButtonMid))
                        RotateTargetsVertical();
                    if (GUILayout.Button("Default", EditorStyles.miniButtonRight))
                        RotateTargetsDefault();
                }
            }
        }

        void RotateTargetsVertical()
        {
            foreach (var targetObj in serializedObject.targetObjects)
            {
                var condition = (AlignmentCondition)targetObj;
                Undo.RecordObject(condition.transform, k_RotateObjectsUndoString);

                var projectedUp = Vector3.ProjectOnPlane(condition.transform.up, Vector3.up);
                if (projectedUp.sqrMagnitude < k_HorizontalThreshold)
                    projectedUp = -condition.transform.forward;

                condition.transform.rotation =
                    Quaternion.FromToRotation(condition.transform.up, projectedUp.normalized) * condition.transform.rotation;
            }
        }

        void RotateTargetsHorizontal()
        {
            foreach (var targetObj in serializedObject.targetObjects)
            {
                var condition = (AlignmentCondition)targetObj;
                Undo.RecordObject(condition.transform, k_RotateObjectsUndoString);
                condition.transform.rotation =
                    Quaternion.FromToRotation(condition.transform.up, Vector3.up) * condition.transform.rotation;
            }
        }

        void RotateTargetsDefault()
        {
            foreach (var targetObj in serializedObject.targetObjects)
            {
                var condition = (AlignmentCondition)targetObj;
                Undo.RecordObject(condition.transform, k_RotateObjectsUndoString);
                condition.transform.rotation =
                    condition.alignment == MarsPlaneAlignment.Vertical ? k_DefaultVerticalRotation : Quaternion.identity;
            }
        }
    }
}

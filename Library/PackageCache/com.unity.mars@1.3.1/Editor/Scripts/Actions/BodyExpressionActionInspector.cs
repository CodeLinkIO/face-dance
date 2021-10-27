using Unity.MARS;
using Unity.MARS.Actions;
using Unity.MARS.Attributes;
using Unity.MARS.Data;
using UnityEngine;

namespace UnityEditor.MARS
{
    [ComponentEditor(typeof(BodyExpressionAction))]
    class BodyExpressionActionInspector : ComponentInspector
    {
        const float k_MinAngle = 0;
        const float k_MaxAngle = 90;

        const float k_MinRecommendedAngle = 30;
        const float k_MaxRecommendedAngle = 60;

        const string k_CreatePoseButtonLabel = "Create Body Pose";
        const string k_DegreesLabel = "degrees";

        const int k_IndentationOffset = -20;
        
        const string k_BodyPoseMatchTolerancePropName = "m_BodyPoseDotProductMatchTolerance";

        static readonly string k_BodyPoseMatchingAngleOutOfRange =
            "The current angle tolerance is out of the recommended bounds.This could make your poses not match on " +
            "device builds or generate false positives. It is recommended to use an angle tolerance between" +
            $" ~{k_MinRecommendedAngle} to {k_MaxRecommendedAngle} degrees";

        readonly GUIContent m_ToleranceContent = new GUIContent("Angle Tolerance",
            "Refers to the maximum permitted bone angles between the current tracked human and the pose " +
            "being compared against. 0 means the pose has to match exactly. A good matching value would be " +
            $"~{k_MinRecommendedAngle} - {k_MaxRecommendedAngle} degrees");

        SerializedProperty m_ToleranceProperty;

        float m_ToleranceAngleDegrees;

        GUIStyle m_ResetLabelMarginStyle;

        public override void OnEnable()
        {
            serializedObject.Update();

            base.OnEnable();

            BodyExpressionAction.EnsureBodyPoseMatchingRig();

            m_ToleranceProperty = serializedObject.FindProperty(k_BodyPoseMatchTolerancePropName);
            m_ToleranceAngleDegrees = Mathf.Acos(m_ToleranceProperty.floatValue) * Mathf.Rad2Deg;

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            if (m_ResetLabelMarginStyle == null)
            {
                m_ResetLabelMarginStyle = MarsEditorGUI.Styles.ResetLabelMarginStyle;
                m_ResetLabelMarginStyle.margin.top = 2;
            }

            serializedObject.Update();

            GUILayout.Space(4);

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label(k_CreatePoseButtonLabel, m_ResetLabelMarginStyle, GUILayout.Width(EditorGUIUtility.labelWidth));

                if (GUILayout.Button(MarsUIResources.instance.BodyIconData.BodyPoseIcon.Icon, MarsEditorGUI.Styles.IconButtonStyle, MarsEditorGUI.MarsStyles.BindingButtonGUIOptions))
                {
                    BodyTrackingModule.OpenAvatarEditor(MarsBodySettings.instance.DefaultPreviewBodyAvatar, true);
                }
            }

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                using (new GUILayout.HorizontalScope(GUILayout.ExpandWidth(true)))
                {
                    m_ToleranceAngleDegrees = EditorGUILayout.Slider(m_ToleranceContent,
                        m_ToleranceAngleDegrees, k_MinAngle, k_MaxAngle);
                    GUILayout.Label(k_DegreesLabel, GUILayout.ExpandWidth(false));
                }

                if (m_ToleranceAngleDegrees < k_MinRecommendedAngle || m_ToleranceAngleDegrees > k_MaxRecommendedAngle)
                    EditorGUILayout.HelpBox(k_BodyPoseMatchingAngleOutOfRange, MessageType.Info);

                if (check.changed)
                {
                    var targetDotProductValue = Mathf.Cos(Mathf.Deg2Rad * m_ToleranceAngleDegrees);
                    m_ToleranceProperty.floatValue = targetDotProductValue;

                    serializedObject.ApplyModifiedProperties();
                }
            }

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Space(k_IndentationOffset);
                using (new GUILayout.VerticalScope())
                {
                    base.OnInspectorGUI();
                }
            }
        }
    }
}

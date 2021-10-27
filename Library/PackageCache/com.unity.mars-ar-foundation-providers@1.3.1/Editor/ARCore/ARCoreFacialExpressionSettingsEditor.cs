using Unity.MARS.Data.ARFoundation;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.ARFoundation
{
    [CustomEditor(typeof(ARCoreFacialExpressionSettings))]
    [MovedFrom("Unity.MARS.Providers")]
    public class ARCoreFacialExpressionSettingsEditor : Editor
    {
        SerializedProperty m_ThresholdsProperty;
        SerializedProperty m_ExpressionDistanceMinimumsProperty;
        SerializedProperty m_ExpressionDistanceMaximumsProperty;
        SerializedProperty m_ExpressionDistanceReverseStatesProperty;
        SerializedProperty m_CooldownProperty;
        SerializedProperty m_SmoothingFilter;

        SerializedProperty m_MaxHeadXProperty;
        SerializedProperty m_MaxHeadYProperty;
        SerializedProperty m_MaxHeadZProperty;

        void OnEnable()
        {
            m_ThresholdsProperty = serializedObject.FindProperty("m_Thresholds");
            m_CooldownProperty = serializedObject.FindProperty("m_EventCooldownInSeconds");
            m_SmoothingFilter = serializedObject.FindProperty("m_ExpressionChangeSmoothingFilter");
            m_ExpressionDistanceMinimumsProperty = serializedObject.FindProperty("m_ExpressionDistanceMinimums");
            m_ExpressionDistanceMaximumsProperty = serializedObject.FindProperty("m_ExpressionDistanceMaximums");
            m_ExpressionDistanceReverseStatesProperty = serializedObject.FindProperty("m_ExpressionDistanceReverseStates");
            m_MaxHeadXProperty = serializedObject.FindProperty("m_MaxHeadAngleX");
            m_MaxHeadYProperty = serializedObject.FindProperty("m_MaxHeadAngleY");
            m_MaxHeadZProperty = serializedObject.FindProperty("m_MaxHeadAngleZ");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Maximum Head Angles", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Beyond these angles, expressions will not be calculated because the landmark data is less reliable", MessageType.Info);
            EditorGUILayout.PropertyField(m_MaxHeadXProperty);
            EditorGUILayout.PropertyField(m_MaxHeadYProperty);
            EditorGUILayout.PropertyField(m_MaxHeadZProperty);

            EditorGUILayout.Separator();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var cooldown = EditorGUILayout.FloatField("Event Cooldown In Seconds", m_CooldownProperty.floatValue);
                if (check.changed)
                    m_CooldownProperty.floatValue = cooldown;
            }

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var smoothing = EditorGUILayout.FloatField("Expression Change Smoothing Filter", m_SmoothingFilter.floatValue);
                if (check.changed)
                    m_SmoothingFilter.floatValue = smoothing;
            }

            EditorGUILayout.Separator();

            ARCoreFaceEditorUtils.ExpressionThresholdFields(m_ThresholdsProperty);

            EditorGUILayout.Separator();

            ARCoreFaceEditorUtils.ExpressionDistanceRangeFields(m_ExpressionDistanceReverseStatesProperty,
                m_ExpressionDistanceMinimumsProperty, m_ExpressionDistanceMaximumsProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}

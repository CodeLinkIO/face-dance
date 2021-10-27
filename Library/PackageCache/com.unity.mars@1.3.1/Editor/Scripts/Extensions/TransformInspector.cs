using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.MARS.Simulation;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;

namespace Unity.MARS
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Transform))]
    class TransformInspector : Editor
    {
        static readonly GUIContent k_PositionContent = new GUIContent("Position", "The local position of this GameObject relative to the parent.");
        static readonly GUIContent k_ScaleContent = new GUIContent("Scale", "The local scaling of this GameObject relative to the parent.");
        const string k_FloatingPointWarning = "Due to floating-point precision limitations, it is recommended to bring the world coordinates of the GameObject within a smaller range.";
        const string k_WorldScaleHint = "Consider setting World Scale rather than scaling Transforms directly.";
        const string k_WorldScaleHintAnalyticsLabel = "TransformInspector World Scale";
        const string k_DisabledComponentHint = "Non-synced components in the simulation are disabled in the inspector. Changes to these components are not reflected in the main scene.";
        const string k_DisableComponentHintAnalyticsLabel = "TransformInspector Disabled Component";
        static readonly GUIContent k_LearnAboutScale = new GUIContent("?", "Learn more about World Scale in AR");
        static readonly GUIContent k_StopShowingHints = new GUIContent("X", "Stop showing this hint");

        const string k_SessionScaleHint = "Use the slider in the MARSSession inspector below to adjust the scale of this object";

        static readonly Type k_RotationGUIType;
        static readonly MethodInfo k_RotationFieldMethod;
        static readonly MethodInfo k_OnEnableMethod;

        Transform m_Transform;
        SerializedProperty m_Position;
        SerializedProperty m_Scale;
        object m_RotationGUI;
        bool m_IsMarsScene;
        bool m_IsMarsSession;
        bool m_SettingHideFlags;

        List<Component> m_Components = new List<Component>();

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<MARSEntity> k_MARSEntities = new List<MARSEntity>();

        static TransformInspector()
        {
            k_RotationGUIType = ReflectionUtils.FindType(type => type.Name.Contains("TransformRotationGUI"));
            k_RotationFieldMethod = k_RotationGUIType.GetMethod("RotationField", new Type[0], null);
            k_OnEnableMethod = k_RotationGUIType.GetMethod("OnEnable");
        }

        public void OnEnable()
        {
            m_Transform = target as Transform;
            if (serializedObject.targetObject == null)
                return;

            m_Position = serializedObject.FindProperty("m_LocalPosition");
            m_Scale = serializedObject.FindProperty("m_LocalScale");

            m_IsMarsSession = m_Transform.GetComponent<MARSSession>();

            if (m_RotationGUI == null)
                m_RotationGUI = Activator.CreateInstance(k_RotationGUIType);

            k_OnEnableMethod.Invoke(m_RotationGUI, new object[] { serializedObject.FindProperty("m_LocalRotation"),
                new GUIContent("Rotation", "The local rotation of this GameObject relative to the parent.") });

            var session = MARSSession.Instance;
            var simSceneModule = SimulationSceneModule.instance;
            if (session == null || simSceneModule == null)
            {
                m_SettingHideFlags = false;
                return;
            }

            var scene = m_Transform.gameObject.scene;

            m_IsMarsScene = session.gameObject.scene == scene ||
                (simSceneModule.IsSimulationReady && m_Transform.IsChildOf(simSceneModule.ContentRoot.transform));

            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                m_SettingHideFlags = false;
                return;
            }

            if (simSceneModule.IsSimulationReady && m_Transform.IsChildOf(simSceneModule.ContentRoot.transform))
            {
                // k_MARSEntities is cleared by GetComponents
                m_Transform.gameObject.GetComponents(k_MARSEntities);
                m_Transform.gameObject.GetComponents(m_Components);

                // Hide Simulatables that are synced by the MARS Entity Editor
                // TODO update to always removed simulatables when the syncing is done outside of an inspector.
                if (k_MARSEntities.Count > 0)
                    m_Components = m_Components.Where(c => c is ISimulatable == false).ToList();

                foreach (var monoBehaviour in m_Components)
                {
                    if (monoBehaviour == null)
                        continue;

                    if ((monoBehaviour.hideFlags & HideFlags.None) == 0)
                        monoBehaviour.hideFlags |= HideFlags.NotEditable;
                }

                m_SettingHideFlags = true;
            }
        }

        public void OnDisable()
        {
            if (!m_SettingHideFlags)
                return;

            foreach (var monoBehaviour in m_Components)
            {
                if (monoBehaviour == null)
                    continue;

                monoBehaviour.hideFlags |= HideFlags.NotEditable;
            }
        }

        bool ShouldDisableScaleTransformField()
        {
            return m_IsMarsSession;
        }

        public override void OnInspectorGUI()
        {
            if (!EditorGUIUtility.wideMode)
            {
                EditorGUIUtility.wideMode = true;
                EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth - 212;
            }

            serializedObject.Update();

            EditorGUILayout.PropertyField(m_Position, k_PositionContent);
            k_RotationFieldMethod.Invoke(m_RotationGUI, null);

            using (new EditorGUI.DisabledScope(ShouldDisableScaleTransformField()))
            {
                EditorGUILayout.PropertyField(m_Scale, k_ScaleContent);
            }

            using (new EditorGUI.DisabledScope(EditorApplication.isPlayingOrWillChangePlaymode))
            {
                // Warning if global position is too large for floating point errors.
                // SanitizeBounds function doesn't even support values beyond 100000
                var pos = m_Transform.position;

                var absX = pos.x > 0f ? pos.x : -pos.x;
                var absY = pos.y > 0f ? pos.y : -pos.y;
                var absZ = pos.z > 0f ? pos.z : -pos.z;
                if (absX > 100000 || absY > 100000 || absZ > 100000)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.HelpBox(k_FloatingPointWarning, MessageType.Warning);
                }
            }

            if (m_IsMarsSession)
            {
                EditorGUILayout.HelpBox(k_SessionScaleHint, MessageType.Info);
            }
            else
            {
                MarsEditorUtils.HintBox(m_IsMarsScene && MarsHints.ShowWorldScaleHint, k_WorldScaleHint,
                    k_WorldScaleHintAnalyticsLabel, k_LearnAboutScale, MarsHelpURLs.WorldScaleHelpURL, k_StopShowingHints, () =>
                {
                    MarsHints.ShowWorldScaleHint = false;
                });
            }

            if (m_SettingHideFlags)
            {
                MarsEditorUtils.HintBox(MarsHints.ShowDisabledSimulationComponentsHint, k_DisabledComponentHint,
                    k_DisableComponentHintAnalyticsLabel, null, MarsHelpURLs.WorldScaleHelpURL, k_StopShowingHints, () =>
                {
                    MarsHints.ShowDisabledSimulationComponentsHint = false;
                });
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

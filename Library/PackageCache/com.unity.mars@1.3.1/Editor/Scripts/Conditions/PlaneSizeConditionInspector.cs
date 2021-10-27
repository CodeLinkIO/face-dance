using Unity.MARS;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using UnityEngine;
using Unity.MARS.HandlesEditor;
using Unity.MARS.Settings;
using UnityEditor.MARS.Authoring;
using UnityEditor.SceneManagement;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Inspector and scene handles for plane size condition
    /// </summary>
    [ComponentEditor(typeof(PlaneSizeCondition))]
    class PlaneSizeConditionInspector : SpatialConditionInspector
    {
        PlaneSizeCondition m_PlaneSizeCondition;
        SerializedPropertyData m_MinSizeProperty;
        SerializedPropertyData m_MaxSizeProperty;
        SerializedPropertyData m_MinBoundedProperty;
        SerializedPropertyData m_MaxBoundedProperty;

        PlaneSizeHandle m_Handle;
        bool m_HandleChanged;

        public override void OnEnable()
        {
            base.OnEnable();
            m_PlaneSizeCondition = (PlaneSizeCondition) target;

            m_MinSizeProperty = serializedObject.FindSerializedPropertyData("m_MinimumSize");
            m_MaxSizeProperty = serializedObject.FindSerializedPropertyData("m_MaximumSize");
            m_MinBoundedProperty = serializedObject.FindSerializedPropertyData("m_MinBounded");
            m_MaxBoundedProperty = serializedObject.FindSerializedPropertyData("m_MaxBounded");

            m_PlaneSizeCondition.AdjustingChanged += OnAdjustingChanged;
            CleanUp();
        }

        void OnAdjustingChanged(bool isAdjusting)
        {
            if (isAdjusting)
            {
                var prefab = MARSRuntimePrefabs.instance.PlaneSizeHandle;
                prefab.SetActive(false);
                var handleInstance = SceneViewContext.activeViewContext.CreateHandle(prefab);
                prefab.SetActive(true);
                m_Handle = handleInstance.GetComponent<PlaneSizeHandle>();
                m_Handle.PlaneSizeCondition = m_PlaneSizeCondition;
                m_Handle.HandleChanged += () => m_HandleChanged = true;
                handleInstance.SetActive(true);
            }
            else
            {
                if (m_Handle != null)
                    SceneViewContext.activeViewContext.DestroyHandle(m_Handle.gameObject);
            }
        }

        public override void OnDisable()
        {
            if (m_PlaneSizeCondition != null)
            {
                m_PlaneSizeCondition.Adjusting = false;
                m_PlaneSizeCondition.AdjustingChanged -= OnAdjustingChanged;
            }
            else
            {
                OnAdjustingChanged(false);
            }
        }

        protected override void OnConditionSceneGUI()
        {
            UpdateHandleMode();
            SetHandleVisibility();

            if (m_HandleChanged)
            {
                m_HandleChanged = false;
                GUI.changed = true;
            }
        }

        void SetHandleVisibility()
        {
            if (m_Handle == null || m_PlaneSizeCondition == null)
                return;

            m_Handle.gameObject.SetActive(
                m_PlaneSizeCondition.isActiveAndEnabled &&
                m_HandleMode != HandleMode.Hidden &&
                StageUtility.IsGameObjectRenderedByCamera(m_PlaneSizeCondition.gameObject, SceneView.lastActiveSceneView.camera));
        }

        protected override void OnConditionInspectorGUI()
        {
            UpdateHandleMode();
            SetHandleVisibility();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                EditorGUIUtils.PropertyField(m_MinBoundedProperty, m_MinSizeProperty);
                EditorGUIUtils.PropertyField(m_MaxBoundedProperty, m_MaxSizeProperty);

                MarsCompareTool.DrawComponentControls(m_PlaneSizeCondition);

                if (check.changed)
                {
                    if (m_HandleMode == HandleMode.Hidden)
                        m_HandleMode = HandleMode.Preview;

                    serializedObject.ApplyModifiedProperties();
                }
            }

            if (m_PlaneSizeCondition.noMinMaxWarning)
                EditorGUIUtils.Warning(k_NoMinOrMaxWarning);
            else if (m_PlaneSizeCondition.smallMinMaxRangeWarning)
                EditorGUIUtils.Warning(k_SmallMinMaxRangeWarning);
        }
    }
}

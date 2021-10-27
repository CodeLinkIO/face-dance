using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.MARS.Query;
using Unity.XRTools.Utils.GUI;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Base inspector for a condition that can be drawn in a component list editor.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public abstract class ConditionBaseInspector : ComponentInspector
    {
        class Styles
        {
            public GUIStyle editButton;

            public Styles()
            {
                editButton = new GUIStyle("Button");
                editButton.padding = new RectOffset(2, 2, 2, 2);
            }
        }

        const int k_WarningIconSize = 40;
        /// <summary>
        /// GUI label text for unbounded
        /// </summary>
        protected const string k_UnboundedLabel = "Unbounded";
        /// <summary>
        /// Warning text for minimum or maximum set
        /// </summary>
        protected const string k_NoMinOrMaxWarning =
            "This condition has neither a minimum nor a maximum, and therefore it has no effect.";
        /// <summary>
        /// Warning text for small range between the minimum and maximum values
        /// </summary>
        protected const string k_SmallMinMaxRangeWarning =
            "This condition's min/max range is very small, and therefore it will be hard to satisfy.";

        /// <summary>
        /// Button label for editing a condition
        /// </summary>
        protected const string k_ButtonLabel = "Edit Condition";
        /// <summary>
        /// Button tooltip for editing a condition
        /// </summary>
        protected const string k_ButtonTooltip = "Toggle scene handles for this condition.";

        const float k_EditButtonWidth = 33;
        const float k_EditButtonHeight = 23;
        const float k_SpaceBetweenLabelAndButton = 5;

        static Styles s_Styles;
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        bool m_ConditionChecked;
        bool m_FlagObjSelectedFirstTime;

        /// <summary>
        /// Interaction mode of a handle
        /// </summary>
        public enum HandleMode
        {
            /// <summary>
            /// The handle is hidden
            /// </summary>
            Hidden = 0,
            /// <summary>
            /// The handle is visible but not interactable
            /// </summary>
            Preview,
            /// <summary>
            /// The handle is visible and interactable
            /// </summary>
            Interactive
        }

        /// <summary>
        /// The current interaction mode for the condition
        /// </summary>
        protected HandleMode m_HandleMode;
        IAdjustableComponent m_AdjustableComponent;

        /// <summary>
        /// Base condition object for the inspected condition
        /// </summary>
        protected ConditionBase conditionBase { get; private set; }
        /// <summary>
        /// Transform of the inspected condition
        /// </summary>
        protected Transform targetTransform { get; private set; }
        /// <summary>
        /// MARS entity attached to the inspected condition
        /// </summary>
        protected MARSEntity entity { get; private set; }

        /// <inheritdoc />
        public override void OnEnable()
        {
            conditionBase = (ConditionBase)target;
            m_AdjustableComponent = target as IAdjustableComponent;
            targetTransform = conditionBase.transform;
            entity = targetTransform.GetComponent<MARSEntity>();

            base.OnEnable();
        }

        /// <inheritdoc />
        public sealed override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (isDirty)
                CleanUp();

            DrawEditConditionButton();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                // Stops preview after sliding a field value in the inspector
                if (Event.current.type == EventType.MouseUp && Event.current.button == 0)
                    m_HandleMode = HandleMode.Hidden;

                OnConditionInspectorGUI();

                if (check.changed)
                {
                    isDirty = true;
                    serializedObject.ApplyModifiedProperties();
                }
            }
        }

        /// <summary>
        /// Used to wrap the property drawers of the inspector inside a change check for Query updating.
        /// </summary>
        protected abstract void OnConditionInspectorGUI();

        /// <summary>
        /// Update the condition inspector's handle mode based on the adjusting state of the component
        /// </summary>
        protected void UpdateHandleMode()
        {
            if (m_AdjustableComponent == null)
                return;

            if (m_AdjustableComponent.Adjusting && m_HandleMode != HandleMode.Interactive)
            {
                m_HandleMode = HandleMode.Interactive;
            }
            else if (!m_AdjustableComponent.Adjusting && m_HandleMode == HandleMode.Interactive)
                m_HandleMode = HandleMode.Hidden;
        }

        void DrawEditConditionButton()
        {
            if (m_AdjustableComponent == null)
                return;

            using(new EditorGUILayout.HorizontalScope())
            {
                EditorGUIUtils.DrawCheckboxFillerRect();

                var rect = EditorGUILayout.GetControlRect(true, k_EditButtonHeight, styles.editButton);
                var buttonRect = new Rect(rect.xMin, rect.yMin, k_EditButtonWidth, k_EditButtonHeight);

                var labelContent = new GUIContent(k_ButtonLabel, k_ButtonTooltip);
                var labelSize = GUI.skin.label.CalcSize(labelContent);

                var labelRect = new Rect(
                    buttonRect.xMax + k_SpaceBetweenLabelAndButton,
                    rect.yMin + (rect.height - labelSize.y) * .5f,
                    labelSize.x,
                    rect.height);

                var hasEditIcon = MarsUIResources.instance.ConditionIcons.TryGetValue(target.GetType(), out var iconData);
                var buttonContent = hasEditIcon ? new GUIContent(iconData.Inactive.Icon, k_ButtonTooltip) : new GUIContent("Edit", k_ButtonTooltip) ;

                m_AdjustableComponent.Adjusting = GUI.Toggle(buttonRect, m_AdjustableComponent.Adjusting, buttonContent, styles.editButton);
                GUI.Label(labelRect, k_ButtonLabel);
            }

            EditorGUILayout.Space();

        }

        void DeselectConditionIfAdjustingWhenOtherObjectSelected()
        {
            if (m_FlagObjSelectedFirstTime)
                return;

            if (m_AdjustableComponent != null && m_AdjustableComponent.Adjusting)
                m_AdjustableComponent.Adjusting = false;

            m_FlagObjSelectedFirstTime = true;
        }

        /// <inheritdoc />
        public sealed override void OnSceneGUI()
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                DeselectConditionIfAdjustingWhenOtherObjectSelected();

                OnConditionSceneGUI();

                base.OnSceneGUI();

                var currentEvent = Event.current;
                if (currentEvent.type == EventType.MouseUp && currentEvent.button == 0 && m_HandleMode == HandleMode.Preview
                    || target == null)                  // catch case where component has been destroyed
                {
                    m_HandleMode = HandleMode.Hidden;
                }

                if (check.changed)
                    Repaint();
            }
        }

        /// <summary>
        /// Condition specific on scene GUI drawing and interaction
        /// </summary>
        protected abstract void OnConditionSceneGUI();

        [DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.InSelectionHierarchy)]
        static void DrawGizmos(ConditionBase condition, GizmoType gizmoType)
        {
            if (!condition.drawWarning)
                return;

            if (SceneView.currentDrawingSceneView is SimulationView)
                return;

            var transform = condition.transform;
            var screenPoint = Camera.current.WorldToScreenPoint(transform.position) / EditorGUIUtility.pixelsPerPoint;
            if (screenPoint.z >= Camera.current.nearClipPlane && screenPoint.z <= Camera.current.farClipPlane)
            {
                Handles.BeginGUI();
                screenPoint.x -= k_WarningIconSize;
                var pointHeight = ScreenGUIUtils.pointHeight;
                screenPoint.y = pointHeight - screenPoint.y - k_WarningIconSize * 2f;
                GUI.DrawTexture(new Rect(screenPoint, Vector2.one * k_WarningIconSize), MarsUIResources.instance.WarningTexture);
                Handles.EndGUI();
            }
        }
    }
}

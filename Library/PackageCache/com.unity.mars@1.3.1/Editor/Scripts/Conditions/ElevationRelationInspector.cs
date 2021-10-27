using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using UnityEditor;
using Unity.MARS.HandlesEditor;
using Unity.MARS.Settings;
using UnityEditor.MARS;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unity.MARS
{
    [ComponentEditor(typeof(ElevationRelation))]
    class ElevationRelationInspector : RelationInspector
    {
        static readonly GUIContent k_Child1Content = new GUIContent("Upper", "Specifies the upper object in this relation");
        static readonly GUIContent k_Child2Content = new GUIContent("Lower", "Specifies the lower object in this relation");

        const string k_MinElevationLabel = "Minimum Elevation";
        const string k_MaxElevationLabel = "Maximum Elevation";

        ElevationRelation m_ElevationRelation;
        SerializedPropertyData m_MinElevationProperty;
        SerializedPropertyData m_MaxElevationProperty;
        SerializedPropertyData m_MinBoundedProperty;
        SerializedPropertyData m_MaxBoundedProperty;
        Vector3 m_ElevationHandleStartPos;

        ElevationHandle m_Handle;
        bool m_HandleChanged;

        protected override GUIContent child1Content { get { return k_Child1Content; } }
        protected override GUIContent child2Content { get { return k_Child2Content; } }

        public override void OnEnable()
        {
            base.OnEnable();

            m_ElevationRelation = (ElevationRelation)target;
            m_MinElevationProperty = serializedObject.FindSerializedPropertyData("m_Minimum");
            m_MaxElevationProperty = serializedObject.FindSerializedPropertyData("m_Maximum");
            m_MinBoundedProperty = serializedObject.FindSerializedPropertyData("m_MinBounded");
            m_MaxBoundedProperty = serializedObject.FindSerializedPropertyData("m_MaxBounded");

            m_ElevationRelation.AdjustingChanged += OnAdjustingChanged;
            CleanUp();
        }

        void OnAdjustingChanged(bool isAdjusting)
        {
            if (isAdjusting)
            {
                var prefab = MARSRuntimePrefabs.instance.ElevationHandle;
                prefab.SetActive(false);
                var handleInstance = SceneViewContext.activeViewContext.CreateHandle(prefab);
                m_Handle = handleInstance.GetComponent<ElevationHandle>();
                m_Handle.ElevationRelation = m_ElevationRelation;
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
            if (m_ElevationRelation != null)
            {
                m_ElevationRelation.Adjusting = false;
                m_ElevationRelation.AdjustingChanged -= OnAdjustingChanged;
            }
            else
            {
                OnAdjustingChanged(false);
            }
        }

        protected override void OnConditionInspectorGUI()
        {
            base.OnConditionInspectorGUI();

            UpdateHandleMode();
            SetHandleVisibility();

            serializedObject.Update();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                EditorGUIUtils.PropertyField(m_MinBoundedProperty, m_MinElevationProperty, k_MinElevationLabel);
                EditorGUIUtils.PropertyField(m_MaxBoundedProperty, m_MaxElevationProperty, k_MaxElevationLabel);

                if (check.changed)
                {
                    if (m_HandleMode == HandleMode.Hidden)
                        m_HandleMode = HandleMode.Preview;

                    serializedObject.ApplyModifiedProperties();
                }
            }

            if (m_ElevationRelation.noMinMaxWarning)
                EditorGUIUtils.Warning(k_NoMinOrMaxWarning);
            if (m_ElevationRelation.smallMinMaxRangeWarning)
                EditorGUIUtils.Warning(k_SmallMinMaxRangeWarning);
        }

        protected override void OnConditionSceneGUI()
        {
            base.OnConditionSceneGUI();

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
            if (m_Handle == null)
                return;

            m_Handle.gameObject.SetActive(
                m_ElevationRelation.isActiveAndEnabled &&
                m_HandleMode != HandleMode.Hidden &&
                StageUtility.IsGameObjectRenderedByCamera(m_ElevationRelation.gameObject, SceneView.lastActiveSceneView.camera));
        }
    }
}

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
    [ComponentEditor(typeof(DistanceRelation))]
    class DistanceRelationInspector : RelationInspector
    {
        const string k_MinDistanceLabel = "Minimum Distance";
        const string k_MaxDistanceLabel = "Maximum Distance";
        const string k_AxisMaskLabel = "Active Planes";

        DistanceRelation m_DistanceRelation;
        SerializedPropertyData m_MinDistanceProperty;
        SerializedPropertyData m_MaxDistanceProperty;
        SerializedPropertyData m_MinBoundedProperty;
        SerializedPropertyData m_MaxBoundedProperty;
        SerializedPropertyData m_AxisMaskProperty;

        DistanceHandle m_Handle;
        bool m_HandleChanged;

        public override void OnEnable()
        {
            base.OnEnable();

            m_DistanceRelation = (DistanceRelation)target;
            m_MinDistanceProperty = serializedObject.FindSerializedPropertyData("m_Minimum");
            m_MaxDistanceProperty = serializedObject.FindSerializedPropertyData("m_Maximum");
            m_MinBoundedProperty = serializedObject.FindSerializedPropertyData("m_MinBounded");
            m_MaxBoundedProperty = serializedObject.FindSerializedPropertyData("m_MaxBounded");
            m_AxisMaskProperty = serializedObject.FindSerializedPropertyData("m_AxisMask");

            m_DistanceRelation.AdjustingChanged += OnAdjustingChanged;
            CleanUp();
        }

        void OnAdjustingChanged(bool isAdjusting)
        {
            if (isAdjusting)
            {
                var prefab = MARSRuntimePrefabs.instance.DistanceHandle;
                prefab.SetActive(false);
                var handleInstance = SceneViewContext.activeViewContext.CreateHandle(prefab);
                prefab.SetActive(true);

                m_Handle = handleInstance.GetComponent<DistanceHandle>();
                m_Handle.DistanceRelation = m_DistanceRelation;
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
            if (m_DistanceRelation != null)
            {
                m_DistanceRelation.Adjusting = false;
                m_DistanceRelation.AdjustingChanged -= OnAdjustingChanged;
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
                EditorGUIUtils.PropertyField(m_MinBoundedProperty, m_MinDistanceProperty, k_MinDistanceLabel);
                EditorGUIUtils.PropertyField(m_MaxBoundedProperty, m_MaxDistanceProperty, k_MaxDistanceLabel);
                EditorGUIUtils.PropertyField(m_AxisMaskProperty, m_AxisMaskProperty, k_AxisMaskLabel);

                if (check.changed)
                    serializedObject.ApplyModifiedProperties();
            }
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
                m_DistanceRelation.isActiveAndEnabled &&
                m_HandleMode != HandleMode.Hidden &&
                StageUtility.IsGameObjectRenderedByCamera(m_DistanceRelation.gameObject, SceneView.lastActiveSceneView.camera));
        }
    }
}

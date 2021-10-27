using System;
using UnityEngine;
using Unity.MARS.MARSHandles;
using TMPro;
using Unity.MARS.Conditions;
using Unity.MARS.MARSUtils;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.MARS
{
    [AddComponentMenu("")]
    [ExecuteInEditMode]
    class PlaneSizeHandle : HandleBehaviour
    {
        const string k_UndoString = "Edit plane size condition";
        const string k_LabelFormat = "{0}: {1:0.00}m x {2:0.00}m";
        const float k_MidHandleLerp = 0.5f; // How far from min to max the middle handle is

#pragma warning disable 649
        [SerializeField]
        Slider2DHandle m_MinHandle;

        [SerializeField]
        Slider2DHandle m_MidHandle;

        [SerializeField]
        Slider2DHandle m_MaxHandle;

        [SerializeField]
        LineRenderer m_InnerLine;

        [SerializeField]
        LineRenderer m_MidLine;

        [SerializeField]
        LineRenderer m_OuterLine;

        [SerializeField]
        RectTransform m_LabelTransform;

        [SerializeField]
        TextMeshProUGUI m_LabelTextRenderer;
#pragma warning restore 649

        readonly Vector3[] k_InnerLinePositions = new Vector3[4];
        readonly Vector3[] k_MidLinePositions = new Vector3[4];
        readonly Vector3[] k_OuterLinePositions = new Vector3[4];

        Transform m_LabelWorldTarget;
        PlaneSizeCondition m_PlaneSizeCondition;

        public event Action HandleChanged;
        public event Action HandleChangeEnded;

        public PlaneSizeCondition PlaneSizeCondition
        {
            get => m_PlaneSizeCondition;
            set
            {
                m_PlaneSizeCondition = value;
                UpdateHandle();
            }
        }

        void OnEnable()
        {
            m_MinHandle.translationUpdated += MinHandleUpdated;
            m_MidHandle.translationUpdated += MidHandleUpdated;
            m_MaxHandle.translationUpdated += MaxHandleUpdated;

            m_MinHandle.translationBegun += MinHandleOnTranslationBegun;
            m_MidHandle.translationBegun += MidHandleOnTranslationBegun;
            m_MaxHandle.translationBegun += MaxHandleOnTranslationBegun;

            m_MinHandle.translationEnded += HandleOnTranslationEnded;
            m_MidHandle.translationEnded += HandleOnTranslationEnded;
            m_MaxHandle.translationEnded += HandleOnTranslationEnded;

            m_LabelTransform.gameObject.SetActive(false);
#if UNITY_EDITOR
            EditorOnlyEvents.BlockSimulationSync(m_PlaneSizeCondition, true);
#endif
        }

        void OnDisable()
        {
            m_MinHandle.translationUpdated -= MinHandleUpdated;
            m_MidHandle.translationUpdated -= MidHandleUpdated;
            m_MaxHandle.translationUpdated -= MaxHandleUpdated;

            m_MinHandle.translationBegun -= MinHandleOnTranslationBegun;
            m_MidHandle.translationBegun -= MidHandleOnTranslationBegun;
            m_MaxHandle.translationBegun -= MaxHandleOnTranslationBegun;

            m_MinHandle.translationEnded -= HandleOnTranslationEnded;
            m_MidHandle.translationEnded -= HandleOnTranslationEnded;
            m_MaxHandle.translationEnded -= HandleOnTranslationEnded;
#if UNITY_EDITOR
            EditorOnlyEvents.BlockSimulationSync(m_PlaneSizeCondition, false);
#endif
        }
        void MinHandleOnTranslationBegun(TranslationBeginInfo info)
        {
            m_LabelTransform.gameObject.SetActive(true);
            m_LabelWorldTarget = m_MinHandle.transform;
            DisplayMinLabel();
        }

        void MidHandleOnTranslationBegun(TranslationBeginInfo info)
        {
            m_LabelTransform.gameObject.SetActive(true);
            m_LabelWorldTarget = m_MidHandle.transform;
            DisplayMidLabel();
        }

        void MaxHandleOnTranslationBegun(TranslationBeginInfo info)
        {
            m_LabelTransform.gameObject.SetActive(true);
            m_LabelWorldTarget = m_MaxHandle.transform;
            DisplayMaxLabel();
        }

        void HandleOnTranslationEnded(TranslationEndInfo info)
        {
            m_LabelTransform.gameObject.SetActive(false);
            if (HandleChangeEnded != null)
                HandleChangeEnded();
        }

        void MinHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            m_PlaneSizeCondition.minimumSize = handlePosition;
            DisplayMinLabel();

            FinalizeHandleUpdate();
        }

        void MidHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            var midHandleValue = handlePosition;
            var midSize = Vector2.Lerp(m_PlaneSizeCondition.minimumSize, m_PlaneSizeCondition.maximumSize,
                k_MidHandleLerp);
            var difference = midHandleValue - midSize;

            // Don't allow the mid handle to collapse on the minimum size when at zero
            // This ensures the "padding" between min and max is maintained when moving the mid handle
            difference = Vector2.Max(difference, -m_PlaneSizeCondition.minimumSize);
            m_PlaneSizeCondition.minimumSize += difference;
            m_PlaneSizeCondition.maximumSize += difference;

            DisplayMidLabel();

            FinalizeHandleUpdate();
        }

        void MaxHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            m_PlaneSizeCondition.maximumSize = handlePosition;
            DisplayMaxLabel();

            FinalizeHandleUpdate();
        }

        bool SetupHandleUpdate(TranslationUpdateInfo info, out Vector2 handlePosition)
        {
            handlePosition = Vector2.zero;

            if (m_PlaneSizeCondition == null)
                return false;

#if UNITY_EDITOR
            Undo.RecordObject(m_PlaneSizeCondition, k_UndoString);
#endif

            var marsSessionScale = MARSSession.GetWorldScale();
            var currentHandlePosition = info.local.initialPosition + info.local.total;

            handlePosition = new Vector2(currentHandlePosition.x, currentHandlePosition.y) * 2f / marsSessionScale;

            return true;
        }

        void FinalizeHandleUpdate()
        {
            m_PlaneSizeCondition.OnValidate();
            UpdateHandle();
            if (HandleChanged != null)
                HandleChanged();
        }

        void DisplayMinLabel()
        {
            m_LabelTextRenderer.text = string.Format(k_LabelFormat, "Min", m_PlaneSizeCondition.minimumSize.x,
                m_PlaneSizeCondition.minimumSize.y);
        }

        void DisplayMidLabel()
        {
            var midSize = Vector2.Lerp(m_PlaneSizeCondition.minimumSize,
                m_PlaneSizeCondition.maximumSize, k_MidHandleLerp);
            m_LabelTextRenderer.text = string.Format(k_LabelFormat, "Mid", midSize.x, midSize.y);
        }

        void DisplayMaxLabel()
        {
            m_LabelTextRenderer.text = string.Format(k_LabelFormat, "Max", m_PlaneSizeCondition.maximumSize.x,
                m_PlaneSizeCondition.maximumSize.y);
        }

        void UpdateHandle()
        {
            var handleRootTransform = transform;
            var conditionTransform = m_PlaneSizeCondition.transform;
            var marsSessionScale = MARSSession.GetWorldScale();

            handleRootTransform.position = conditionTransform.position;
            handleRootTransform.rotation = conditionTransform.rotation;

            var hasMin = m_PlaneSizeCondition.minBounded;
            m_MinHandle.gameObject.SetActive(hasMin);
            m_InnerLine.gameObject.SetActive(hasMin);
            if (hasMin)
            {
                var scaledMinimumSize = marsSessionScale * 0.5f * m_PlaneSizeCondition.minimumSize;

                k_InnerLinePositions[0] = new Vector3(scaledMinimumSize.x, 0f, scaledMinimumSize.y);
                k_InnerLinePositions[1] = new Vector3(scaledMinimumSize.x, 0f, -scaledMinimumSize.y);
                k_InnerLinePositions[2] = new Vector3(-scaledMinimumSize.x, 0f, -scaledMinimumSize.y);
                k_InnerLinePositions[3] = new Vector3(-scaledMinimumSize.x, 0f, scaledMinimumSize.y);
                m_InnerLine.SetPositions(k_InnerLinePositions);
                m_MinHandle.transform.localPosition = new Vector3(scaledMinimumSize.x, 0f, scaledMinimumSize.y);
            }

            var hasMax = m_PlaneSizeCondition.maxBounded;
            m_MaxHandle.gameObject.SetActive(hasMax);
            m_OuterLine.gameObject.SetActive(hasMax);
            if (hasMax)
            {
                var scaledMaximumSize = marsSessionScale * 0.5f * m_PlaneSizeCondition.maximumSize;

                k_OuterLinePositions[0] = new Vector3(scaledMaximumSize.x, 0f, scaledMaximumSize.y);
                k_OuterLinePositions[1] = new Vector3(scaledMaximumSize.x, 0f, -scaledMaximumSize.y);
                k_OuterLinePositions[2] = new Vector3(-scaledMaximumSize.x, 0f, -scaledMaximumSize.y);
                k_OuterLinePositions[3] = new Vector3(-scaledMaximumSize.x, 0f, scaledMaximumSize.y);
                m_OuterLine.SetPositions(k_OuterLinePositions);
                m_MaxHandle.transform.localPosition = new Vector3(scaledMaximumSize.x, 0f, scaledMaximumSize.y);
            }

            var hasMinAndMax = hasMin && hasMax;
            m_MidHandle.gameObject.SetActive(hasMinAndMax);
            m_MidLine.gameObject.SetActive(hasMinAndMax);
            if (hasMinAndMax)
            {
                var midSize = Vector2.Lerp(m_PlaneSizeCondition.minimumSize, m_PlaneSizeCondition.maximumSize, k_MidHandleLerp);
                var scaledMidSize = marsSessionScale * 0.5f * midSize;
                k_MidLinePositions[0] = new Vector3(scaledMidSize.x, 0f, scaledMidSize.y);
                k_MidLinePositions[1] = new Vector3(scaledMidSize.x, 0f, -scaledMidSize.y);
                k_MidLinePositions[2] = new Vector3(-scaledMidSize.x, 0f, -scaledMidSize.y);
                k_MidLinePositions[3] = new Vector3(-scaledMidSize.x, 0f, scaledMidSize.y);
                m_MidLine.SetPositions(k_MidLinePositions);
                m_MidHandle.transform.localPosition = new Vector3(scaledMidSize.x, 0f, scaledMidSize.y);
            }
        }

        void LateUpdate()
        {
            if (m_PlaneSizeCondition == null || !isActiveAndEnabled)
                return;

            UpdateLabel();
            UpdateHandle();
        }

        void UpdateLabel()
        {
            if (m_LabelTransform.gameObject.activeInHierarchy && m_LabelWorldTarget != null)
                m_LabelTransform.position = m_LabelWorldTarget.position;
        }

    }
}

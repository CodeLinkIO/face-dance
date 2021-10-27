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
    class ElevationHandle : HandleBehaviour
    {
        const string k_UndoString = "Edit elevation relation";
        const float k_MidHandleLerp = 0.5f; // How far from min to max the middle handle is

#pragma warning disable 649
        [SerializeField]
        Slider1DHandle m_MinHandle;

        [SerializeField]
        Slider1DHandle m_MidHandle;

        [SerializeField]
        Slider1DHandle m_MaxHandle;

        [SerializeField]
        LineRenderer m_MinLine;

        [SerializeField]
        LineRenderer m_RangeLine;

        [SerializeField]
        RectTransform m_LabelTransform;

        [SerializeField]
        TextMeshProUGUI m_LabelTextRenderer;
#pragma warning restore 649

        readonly Vector3[] k_ReferenceLinePositions = new Vector3[2];
        readonly Vector3[] k_RangeLinePositions = new Vector3[2];

        Transform m_LabelWorldTarget;
        ElevationRelation m_ElevationRelation;

        public event Action HandleChanged;

        public ElevationRelation ElevationRelation
        {
            get => m_ElevationRelation;
            set
            {
                m_ElevationRelation = value;
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
            EditorOnlyEvents.BlockSimulationSync(m_ElevationRelation, true);
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
            EditorOnlyEvents.BlockSimulationSync(m_ElevationRelation, false);
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
        }

        void MinHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            m_ElevationRelation.minimum = handlePosition.z;

            DisplayMinLabel();
            FinalizeHandleUpdate();
        }

        void MidHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            var midHandleValue = handlePosition.z;
            var mid = Mathf.Lerp(m_ElevationRelation.minimum, m_ElevationRelation.maximum,
                k_MidHandleLerp);
            var difference = midHandleValue - mid;
            m_ElevationRelation.minimum += difference;
            m_ElevationRelation.maximum += difference;

            DisplayMidLabel();
            FinalizeHandleUpdate();
        }

        void MaxHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            m_ElevationRelation.maximum = handlePosition.z;

            DisplayMaxLabel();
            FinalizeHandleUpdate();
        }

        bool SetupHandleUpdate(TranslationUpdateInfo info, out Vector3 handlePosition)
        {
            handlePosition = Vector2.zero;

            if (m_ElevationRelation == null)
                return false;
#if UNITY_EDITOR
            Undo.RecordObject(m_ElevationRelation, k_UndoString);
#endif
            var marsSessionScale = MARSSession.GetWorldScale();
            handlePosition = (info.local.initialPosition + info.local.total) / marsSessionScale;

            return true;
        }

        void FinalizeHandleUpdate()
        {
            m_ElevationRelation.OnValidate();
            UpdateHandle();
            if (HandleChanged != null)
                HandleChanged();
        }

        void DisplayMinLabel()
        {
            m_LabelTextRenderer.text = string.Format("Min: {0:0.00}m", m_ElevationRelation.minimum);
        }

        void DisplayMidLabel()
        {
            var mid = Mathf.Lerp(m_ElevationRelation.minimum,
                m_ElevationRelation.maximum, k_MidHandleLerp);
            m_LabelTextRenderer.text = string.Format("Mid: {0:0.00}m", mid);
        }

        void DisplayMaxLabel()
        {
            m_LabelTextRenderer.text = string.Format("Max: {0:0.00}m", m_ElevationRelation.maximum);
        }

        public void UpdateHandle()
        {
            var handleRootTransform = transform;
            var relationTransform = m_ElevationRelation.transform;
            var marsSessionScale = MARSSession.GetWorldScale();

            var child1Transform = m_ElevationRelation.child1Transform;
            var child2Transform = m_ElevationRelation.child2Transform;
            if (child1Transform != null && child2Transform != null)
            {
                var child1Position = child1Transform.position;
                var verticalDelta = new Vector3(0f, child2Transform.position.y - child1Position.y, 0f);
                handleRootTransform.position = child1Position + verticalDelta;
            }
            else
            {
                handleRootTransform.position = relationTransform.position;
            }

            var hasMin = m_ElevationRelation.minBounded;
            m_MinHandle.gameObject.SetActive(hasMin);
            if (hasMin)
            {
                var scaledMinimum = marsSessionScale * m_ElevationRelation.minimum;
                m_MinHandle.transform.localPosition = new Vector3(0f, scaledMinimum, 0f);
            }

            var hasMax = m_ElevationRelation.maxBounded;
            m_MaxHandle.gameObject.SetActive(hasMax);
            if (hasMax)
            {
                var scaledMaximum = marsSessionScale * m_ElevationRelation.maximum;
                m_MaxHandle.transform.localPosition = new Vector3(0f, scaledMaximum, 0f);
            }

            var hasMinAndMax = hasMin && hasMax;
            m_MidHandle.gameObject.SetActive(hasMinAndMax);
            if (hasMinAndMax)
            {
                var mid = Mathf.Lerp(m_ElevationRelation.minimum, m_ElevationRelation.maximum, k_MidHandleLerp);
                var scaledMid = marsSessionScale * mid;
                m_MidHandle.transform.localPosition = new Vector3(0f, scaledMid, 0f);
            }

            // Line between min and max, or between 0 and end of passing range
            m_RangeLine.gameObject.SetActive(hasMin || hasMax);
            var min = hasMin ? m_ElevationRelation.minimum : Mathf.Min(0f, m_ElevationRelation.maximum);
            var max = hasMax ? m_ElevationRelation.maximum : Mathf.Max(0f, m_ElevationRelation.minimum);

            k_RangeLinePositions[0] = new Vector3(0f, marsSessionScale * min, 0f);
            k_RangeLinePositions[1] = new Vector3(0f, marsSessionScale * max, 0f);
            m_RangeLine.SetPositions(k_RangeLinePositions);

            // Line that connects 0 elevation to the beginning of the passing range
            m_MinLine.gameObject.SetActive(hasMin || hasMax);
            var endPoint = 0f;
            if (hasMinAndMax
                && m_ElevationRelation.maximum > 0 == m_ElevationRelation.minimum > 0) // Show line only if min and max are on the same side of zero
                endPoint = Mathf.Abs(m_ElevationRelation.maximum) < Mathf.Abs(m_ElevationRelation.minimum) ? m_ElevationRelation.maximum : m_ElevationRelation.minimum;
            else if (hasMin)
                endPoint = Mathf.Max(0f, m_ElevationRelation.minimum);
            else if (hasMax)
                endPoint = Mathf.Min(0f, m_ElevationRelation.maximum);

            k_ReferenceLinePositions[0] = Vector3.zero;
            k_ReferenceLinePositions[1] = new Vector3(0, marsSessionScale * endPoint, 0f);
            m_MinLine.SetPositions(k_ReferenceLinePositions);
        }

        void LateUpdate()
        {
            if (m_ElevationRelation == null || !isActiveAndEnabled)
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

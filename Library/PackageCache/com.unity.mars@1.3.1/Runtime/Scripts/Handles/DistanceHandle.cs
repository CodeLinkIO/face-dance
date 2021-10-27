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
    class DistanceHandle : HandleBehaviour
    {
        const string k_UndoString = "Edit distance relation";
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
        DistanceRelation m_DistanceRelation;

        public event Action HandleChanged;

        public DistanceRelation DistanceRelation
        {
            get => m_DistanceRelation;
            set
            {
                m_DistanceRelation = value;
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
            EditorOnlyEvents.BlockSimulationSync(m_DistanceRelation, true);
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
            EditorOnlyEvents.BlockSimulationSync(m_DistanceRelation, false);
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

            m_DistanceRelation.minimum = Mathf.Max(0f, handlePosition.z);

            DisplayMinLabel();

            FinalizeHandleUpdate();
        }

        void MidHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            var midHandleValue = handlePosition.z;
            var mid = Mathf.Lerp(m_DistanceRelation.minimum, m_DistanceRelation.maximum,
                k_MidHandleLerp);
            var difference = midHandleValue - mid;

            // Don't allow the mid handle to collapse on the minimum when at zero
            // This ensures the "padding" between min and max is maintained when moving the mid handle
            difference  = Mathf.Max(difference, -m_DistanceRelation.minimum);
            m_DistanceRelation.minimum += difference;
            m_DistanceRelation.maximum += difference;


            DisplayMidLabel();

            FinalizeHandleUpdate();
        }

        void MaxHandleUpdated(TranslationUpdateInfo info)
        {
            if (!SetupHandleUpdate(info, out var handlePosition))
                return;

            m_DistanceRelation.maximum = Mathf.Max(0f, handlePosition.z);

            DisplayMaxLabel();

            FinalizeHandleUpdate();
        }

        bool SetupHandleUpdate(TranslationUpdateInfo info, out Vector3 handlePosition)
        {
            handlePosition = Vector2.zero;

            if (m_DistanceRelation == null)
                return false;
#if UNITY_EDITOR
            Undo.RecordObject(m_DistanceRelation, k_UndoString);
#endif
            var marsSessionScale = MARSSession.GetWorldScale();
            handlePosition = (info.local.initialPosition + info.local.total) / marsSessionScale;

            return true;
        }

        void FinalizeHandleUpdate()
        {
            m_DistanceRelation.OnValidate();
            UpdateHandle();
            if (HandleChanged != null)
                HandleChanged();
        }

        void DisplayMinLabel()
        {
            m_LabelTextRenderer.text = string.Format("Min: {0:0.00}m", m_DistanceRelation.minimum);
        }

        void DisplayMidLabel()
        {
            var mid = Mathf.Lerp(m_DistanceRelation.minimum,
                m_DistanceRelation.maximum, k_MidHandleLerp);
            m_LabelTextRenderer.text = string.Format("Mid: {0:0.00}m", mid);
        }

        void DisplayMaxLabel()
        {
            m_LabelTextRenderer.text = string.Format("Max: {0:0.00}m", m_DistanceRelation.maximum);
        }

        public void UpdateHandle()
        {
            var handleRootTransform = transform;
            var relationTransform = m_DistanceRelation.transform;
            var marsSessionScale = MARSSession.GetWorldScale();

            var child1Transform = m_DistanceRelation.child1Transform;
            var child2Transform = m_DistanceRelation.child2Transform;
            if (child1Transform != null)
            {
                var child1Pos = child1Transform.position;
                handleRootTransform.position = child1Pos;
                if (child2Transform != null)
                {
                    var delta = child2Transform.position - child1Pos;
                    if (delta != Vector3.zero)
                        handleRootTransform.rotation = Quaternion.LookRotation(delta.normalized);
                    else
                        handleRootTransform.rotation = relationTransform.rotation;
                }
            }
            else
            {
                handleRootTransform.position = relationTransform.position;
                handleRootTransform.rotation = relationTransform.rotation;
            }

            var hasMin = m_DistanceRelation.minBounded;
            m_MinHandle.gameObject.SetActive(hasMin);
            if (hasMin)
            {
                var scaledMinimum = marsSessionScale * m_DistanceRelation.minimum;
                m_MinHandle.transform.localPosition = new Vector3(0f, 0f, scaledMinimum);
            }

            var hasMax = m_DistanceRelation.maxBounded;
            m_MaxHandle.gameObject.SetActive(hasMax);
            if (hasMax)
            {
                var scaledMaximum = marsSessionScale * m_DistanceRelation.maximum;
                m_MaxHandle.transform.localPosition = new Vector3(0f, 0f, scaledMaximum);
            }

            var hasMinAndMax = hasMin && hasMax;
            m_MidHandle.gameObject.SetActive(hasMinAndMax);
            if (hasMinAndMax)
            {
                var mid = Mathf.Lerp(m_DistanceRelation.minimum, m_DistanceRelation.maximum, k_MidHandleLerp);
                var scaledMid = marsSessionScale * mid;
                m_MidHandle.transform.localPosition = new Vector3(0f, 0f, scaledMid);
            }

            // Line between min and max, or between 0 and max if there is no min
            m_RangeLine.gameObject.SetActive(hasMax);
            if (hasMax)
            {
                var start = hasMin ? m_DistanceRelation.minimum : 0f;
                k_RangeLinePositions[0] = new Vector3(0f, 0f, marsSessionScale * start);
                k_RangeLinePositions[1] = new Vector3(0f, 0f, marsSessionScale * m_DistanceRelation.maximum);
                m_RangeLine.SetPositions(k_RangeLinePositions);
            }

            // Line that connects to the minimum of the passing range
            m_MinLine.gameObject.SetActive(hasMin);
            if (hasMin)
            {
                k_ReferenceLinePositions[0] = Vector3.zero;
                k_ReferenceLinePositions[1] = new Vector3(0, 0f, marsSessionScale * m_DistanceRelation.minimum);
                m_MinLine.SetPositions(k_ReferenceLinePositions);
            }
        }

        void LateUpdate()
        {
            if (m_DistanceRelation == null || !isActiveAndEnabled)
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

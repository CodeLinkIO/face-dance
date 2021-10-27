using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.MARS.Companion.Core
{
    class IssueHandlingDialogView : MonoBehaviour
    {
#pragma warning disable 649
        [Header("Labels")]
        [SerializeField]
        TextMeshProUGUI m_TitleLabel;

        [SerializeField]
        TextMeshProUGUI m_DescriptionLabel;

        [SerializeField]
        TextMeshProUGUI m_CancelLabel;

        [SerializeField]
        TextMeshProUGUI m_AcceptLabel;

        [SerializeField]
        TextMeshProUGUI m_ToggleLabel;

        [Header("Buttons")]
        [SerializeField]
        Button m_CancelButton;

        [SerializeField]
        Toggle m_Toggle;
#pragma warning restore 649

        IssueHandledCallback m_CurrentHandledCallback;

        public void Show(in IssueHandlingRequest request)
        {
            // Handle overlapping requests as canceled for now
            if (gameObject.activeInHierarchy)
            {
                request.HandledCallback?.Invoke(new IssueHandlingResult
                {
                    Accept = false,
                    Toggled = request.ToggleCurrentStatus,
                });

                return;
            }

            m_CurrentHandledCallback = request.HandledCallback;

            m_TitleLabel.text = request.Settings.Title;
            m_DescriptionLabel.text = request.Settings.Description;
            m_CancelLabel.text = request.Settings.CancelText;
            m_AcceptLabel.text = request.Settings.AcceptText;

            m_CancelButton.gameObject.SetActive(!string.IsNullOrEmpty(m_CancelLabel.text));

            m_Toggle.gameObject.SetActive(request.Settings.HasToggle);
            m_Toggle.SetIsOnWithoutNotify(request.ToggleCurrentStatus);
            m_ToggleLabel.text = request.Settings.ToggleText;

            m_CurrentHandledCallback = request.HandledCallback;

            gameObject.SetActive(true);

            UIUtils.UpdateConstrainedTextLayout(m_TitleLabel.gameObject);
            UIUtils.UpdateConstrainedTextLayout(m_DescriptionLabel.gameObject);
        }

        public void OnAcceptClick() => Close(true);

        public void OnCancelClick() => Close(false);

        void Close(bool accepted)
        {
            var result = new IssueHandlingResult
            {
                Accept = accepted,
                Toggled = m_Toggle.isOn,
            };

            m_CurrentHandledCallback?.Invoke(result);

            gameObject.SetActive(false);
        }
    }
}

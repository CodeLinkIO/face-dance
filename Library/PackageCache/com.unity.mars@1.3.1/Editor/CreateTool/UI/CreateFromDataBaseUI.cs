using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Base UI for creating a MARS entity from data
    /// </summary>
    class CreateFromDataBaseUI : VisualElement
    {
        bool m_NameIsCustom;
        string m_CurrentName;
        TextField m_NameField;
        protected IntegerField m_CountField;

        internal event Action<int> CountChanged;
        internal event Action Create;
        internal event Action Cancel;
        internal event Action<string> NameChanged;

        internal event Func<string> GetDefaultName;

        internal void RefreshName()
        {
            if (m_NameIsCustom)
                return;

            if (GetDefaultName != null)
                m_CurrentName = GetDefaultName();

            m_NameField?.SetValueWithoutNotify(m_CurrentName);

            if (NameChanged != null)
                NameChanged(m_CurrentName);
        }

        internal virtual void Refresh()
        {
            RefreshName();
        }

        protected void BindBaseCreateElements(Button cancelButton, Button createButton, TextField nameField, IntegerField countField, Toggle maxCountToggle)
        {
            cancelButton.clickable.clicked += OnCancelClicked;
            createButton.clickable.clicked += OnCreateClicked;

            if (GetDefaultName != null)
                m_CurrentName = GetDefaultName();

            m_NameField = nameField;
            m_NameField.isDelayed = true;
            m_NameField.SetValueWithoutNotify(m_CurrentName);
            m_NameIsCustom = false;
            m_NameField.RegisterValueChangedCallback(evt =>
            {
                if (evt.newValue.Length > 0)
                {
                    m_CurrentName = evt.newValue;
                    m_NameIsCustom = true;
                }
                else if (GetDefaultName != null)
                {
                    m_CurrentName = GetDefaultName();
                    m_NameField?.SetValueWithoutNotify(m_CurrentName);
                    m_NameIsCustom = false;
                }

                if (NameChanged != null)
                    NameChanged(m_CurrentName);
            });

            maxCountToggle.RegisterValueChangedCallback(evt =>
            {
                m_CountField.value = evt.newValue ? 1 : 0;
                m_CountField.SetEnabled(evt.newValue);
            });

            m_CountField = countField;
            m_CountField.RegisterValueChangedCallback(evt =>
            {
                var newValue = evt.newValue;
                if (newValue < 0)
                {
                    newValue = 0;
                    m_CountField.SetValueWithoutNotify(newValue);
                }

                var maxEnabled = newValue > 0;
                maxCountToggle.SetValueWithoutNotify(maxEnabled);
                m_CountField.SetEnabled(maxEnabled);

                CountChanged?.Invoke(newValue);
            });
        }

        internal void StartEditingNameField()
        {
            var textInput = m_NameField.Q("unity-text-input");
            textInput.Focus();
            m_NameField.SelectAll();
        }

        internal void WasForceClosed() { OnCancelClicked(); }

        void OnCreateClicked() { Create?.Invoke(); }

        void OnCancelClicked() { Cancel?.Invoke(); }
    }
}

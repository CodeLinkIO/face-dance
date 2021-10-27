using System;
using Unity.MARS.Authoring;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Authoring;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS
{
    /// <summary>
    /// UI for a single row within the list of suggested conditions. This visual element can be bound to a
    /// potential condition object to display the value and enabled/disable it.
    /// </summary>
    class PotentialConditionUI : VisualElement
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CreateTool/UI/PotentialCondition.uxml";

        public new class UxmlFactory : UxmlFactory<PotentialConditionUI> { }

        PotentialComponent m_PotentialComponent;

        Label m_NameLabel;
        Label m_ValueLabel;
        Toggle m_Toggle;

        /// <summary>
        /// Event fired when the condition is toggled
        /// </summary>
        public event Action toggled;

        public PotentialConditionUI() { SetupFromTemplate(); }

        void SetupFromTemplate()
        {
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_UxmlPath);
            template.CloneTree(this);
            m_NameLabel = this.Q<Label>("Name");
            m_ValueLabel = this.Q<Label>("Value");
            m_Toggle = this.Q<Toggle>();
            this.AddManipulator(new Clickable(OnRowClicked));
        }

        void OnRowClicked(EventBase obj)
        {
            m_Toggle.value = !m_Toggle.value;
        }

        /// <summary>
        /// Bind the potential condition object to the UI
        /// </summary>
        /// <param name="potentialComponent">The potential component object that contains the data to display in this UI</param>
        internal void BindToPotentialCondition(PotentialComponent potentialComponent)
        {
            m_PotentialComponent = potentialComponent;
            m_Toggle.SetValueWithoutNotify(m_PotentialComponent.use);
            m_Toggle.RegisterValueChangedCallback(evt =>
            {
                if (m_PotentialComponent != null)
                    m_PotentialComponent.use = evt.newValue;

                UpdateTextLabels();
                if (toggled != null)
                    toggled();

                if (potentialComponent.gameObjectOwner == null)
                    return;

                var entityOwner = potentialComponent.gameObjectOwner.GetComponent<MARSEntity>();
                var entityVisualModule = ModuleLoaderCore.instance.GetModule<EntityVisualsModule>();
                if (entityOwner != null && entityVisualModule != null)
                {
                    entityVisualModule.InvalidateVisual(entityOwner);
                }
            });

            UpdateTextLabels();
        }

        void UpdateTextLabels()
        {
            if (m_PotentialComponent is PotentialTagCondition potentialTagCondition)
            {
                m_NameLabel.text = ObjectNames.NicifyVariableName(potentialTagCondition.tagName).FirstToUpper();
                m_ValueLabel.text = string.Empty;
            }
            else
            {
                var conditionTypeName = m_PotentialComponent.componentType.Name;
                var lastIndexOf = conditionTypeName.LastIndexOf("Condition");
                if (lastIndexOf > 0)
                    conditionTypeName = conditionTypeName.Remove(lastIndexOf);

                m_NameLabel.text = ObjectNames.NicifyVariableName(conditionTypeName);
                m_ValueLabel.text = m_PotentialComponent.valueString;
            }
        }
    }
}

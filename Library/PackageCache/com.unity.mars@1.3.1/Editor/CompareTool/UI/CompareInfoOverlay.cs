using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// UI for overlay box in simulation view when using MARS Compare Tool
    /// </summary>
    class CompareInfoOverlay : VisualElement
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CompareTool/UI/CompareInfoOverlay.uxml";

        bool m_SubHeaderVisible = true;

        public new class UxmlFactory : UxmlFactory<CompareInfoOverlay> { }
        internal Label HeaderLabel { get; private set; }
        Label SubHeaderLabel { get; set; }
        VisualElement ConditionsSection { get; set; }

        internal bool ShowSelectInstruction
        {
            set
            {
                if (value == m_SubHeaderVisible)
                    return;

                m_SubHeaderVisible = value;
                SubHeaderLabel.style.display = new StyleEnum<DisplayStyle>(m_SubHeaderVisible ? DisplayStyle.Flex : DisplayStyle.None);
            }
        }

        public CompareInfoOverlay()
        {
            SetupFromTemplate();
            pickingMode = PickingMode.Ignore;
        }

        void SetupFromTemplate()
        {
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_UxmlPath);
            template.CloneTree(this);
            this.StretchToParentSize();
            HeaderLabel = this.Q<Label>("Header");
            SubHeaderLabel = this.Q<Label>("SubHeader");
            ConditionsSection = this.Q<VisualElement>("ConditionsSection");
        }

        internal void SetConditionRatings(List<KeyValuePair<string, float>> conditionRatings)
        {
            ConditionsSection.Clear();

            foreach (var kvp in conditionRatings)
            {
                var row = new VisualElement();
                row.style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
                var conditionName = new Label($"{kvp.Key.Remove(kvp.Key.IndexOf("Condition"))}: ");
                conditionName.ClearClassList(); // Remove default label formatting so text color is not set by skin
                row.Add(conditionName);
                var ratingFloat = kvp.Value;
                var rating = new Label();
                rating.ClearClassList(); // Remove default label formatting so text color is not set by skin
                var passes = ratingFloat > 0f;
                rating.text = passes ? $"Pass ({ratingFloat * 100:0}%)" : "Fail";

                row.Add(rating);
                ConditionsSection.Add(row);
            }
        }
    }
}

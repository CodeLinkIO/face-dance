using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.MARS.Conditions;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// UI for creating a proxy from data
    /// </summary>
    class CreateProxyFromDataUI : CreateFromDataBaseUI
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CreateTool/UI/CreateProxyWindow.uxml";

        public new class UxmlFactory : UxmlFactory<CreateProxyFromDataUI> {}

        List<PotentialCondition> m_TagsListItemsSource;
        List<PotentialCondition> m_NonTagConditionsListItemsSource;
        ListView m_ConditionsListView;
        ListView m_TagsListView;

        public CreateProxyFromDataUI()
        {
            Setup();
        }

        void Setup()
        {
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_UxmlPath);
            template.CloneTree(this);
            BindBaseCreateElements(
                this.Q<Button>("CancelButton"),
                this.Q<Button>("CreateButton"),
                this.Q<TextField>("NameField"),
                this.Q<IntegerField>("MaxCount"),
                this.Q<Toggle>("MaxCountToggle"));
        }

        internal void BindData(CreateProxyFromData createData)
        {
            BindPotentialConditions(createData.PotentialConditions);
            GetDefaultName += createData.GenerateProxyName;
            NameChanged += createData.SetProxyName;
            Create += () =>
            {
                if (createData.CreatedGameObject != null && !createData.EditMode)
                {
                    Undo.RegisterCreatedObjectUndo(createData.CreatedGameObject, "Create Proxy");
                    EditorGUIUtility.PingObject(createData.CreatedGameObject);
                }

                createData.ConfirmCreate();

            };
            Cancel += createData.CancelCreate;
            var countFieldDisplayStyle = new StyleEnum<DisplayStyle>(createData.EditMode ? DisplayStyle.None : DisplayStyle.Flex);
            m_CountField.value = createData.MaxCount;
            m_CountField.parent.style.display = countFieldDisplayStyle; // Hide parent of the count field to hide the entire row including checkbox
            RefreshName();
        }

        void BindPotentialConditions(List<PotentialCondition> allPotentialConditions)
        {
            m_ConditionsListView = this.Q<ListView>("ConditionsList");
            m_ConditionsListView.bindItem = BindConditionListItem;
            m_ConditionsListView.makeItem = () => new PotentialConditionUI();
            m_ConditionsListView.selectionType = SelectionType.None;

            m_TagsListView = this.Q<ListView>("TagsList");
            m_TagsListView.bindItem = BindTagsListItem;
            m_TagsListView.makeItem = () => new PotentialConditionUI();
            m_TagsListView.selectionType = SelectionType.None;

            m_TagsListItemsSource = allPotentialConditions.FindAll(x => x.componentType == typeof(SemanticTagCondition));
            m_NonTagConditionsListItemsSource = allPotentialConditions.FindAll(x => x.componentType != typeof(SemanticTagCondition));

            m_ConditionsListView.itemsSource = m_NonTagConditionsListItemsSource;
            m_TagsListView.itemsSource = m_TagsListItemsSource;

            m_ConditionsListView.Refresh();
            m_TagsListView.Refresh();
        }

        void BindConditionListItem(VisualElement rowItem, int index)
        {
            var suggestion = m_NonTagConditionsListItemsSource[index];
            var conditionSuggestion = (PotentialConditionUI)rowItem;
            conditionSuggestion.BindToPotentialCondition(suggestion);
            conditionSuggestion.toggled += RefreshName;
        }

        void BindTagsListItem(VisualElement rowItem, int index)
        {
            var suggestion = m_TagsListItemsSource[index];
            var conditionSuggestion = (PotentialConditionUI)rowItem;
            conditionSuggestion.BindToPotentialCondition(suggestion);
            conditionSuggestion.toggled += RefreshName;
        }
    }
}

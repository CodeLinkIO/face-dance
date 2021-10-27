using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Authoring;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// UI for creating a proxy group from data
    /// </summary>
    class CreateProxyGroupFromDataUI : CreateFromDataBaseUI
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CreateTool/UI/CreateProxyGroupWindow.uxml";

        public new class UxmlFactory : UxmlFactory<CreateProxyGroupFromDataUI> {}

        ListView m_RelationList;
        VisualElement m_ChildrenSection;
        List<PotentialRelation> m_PotentialRelations;

        public event Action<CreateProxyFromData> OnChildModified;

        public CreateProxyGroupFromDataUI()
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

        internal void BindData(CreateProxyGroupFromData createGroupData)
        {
            BindPotentialRelations(createGroupData.PotentialRelations);
            BindPotentialChildren(createGroupData.PotentialGroupMembers);
            GetDefaultName += createGroupData.GenerateProxyGroupName;
            NameChanged += createGroupData.SetProxyGroupName;
            Create += () =>
            {
                if (createGroupData.CreatedGameObject != null)
                {
                    Undo.RegisterCreatedObjectUndo(createGroupData.CreatedGameObject, "Create Proxy Group");
                    EditorGUIUtility.PingObject(createGroupData.CreatedGameObject);
                }
            };

            m_CountField.value = createGroupData.MaxCount;

            Cancel += createGroupData.CancelCreate;
            RefreshName();
        }

        void BindPotentialRelations(List<PotentialRelation> potentialRelations)
        {
            m_RelationList = this.Q<ListView>("RelationsList");
            m_RelationList.bindItem = BindRelationListItem;
            m_RelationList.makeItem = () => new PotentialConditionUI();
            m_RelationList.selectionType = SelectionType.None;
            m_RelationList.itemsSource = potentialRelations;
            m_PotentialRelations = potentialRelations;
        }

        void BindPotentialChildren(List<PotentialChild> potentialChildren)
        {
            m_ChildrenSection = this.Q<VisualElement>("ChildrenList");
            m_ChildrenSection.Clear();
            for (var index = 0; index < potentialChildren.Count; index++)
            {
                var potentialChild = potentialChildren[index];
                var ui = new PotentialChildUI(potentialChild, index);
                ui.Button.clickable.clicked += () => OnChildModified?.Invoke(potentialChild.createProxyFromData);
                m_ChildrenSection.Add(ui);
            }
        }

        /// <summary>
        /// Refreshes the names of the children and the relations' child references
        /// </summary>
        internal override void Refresh()
        {
            base.Refresh();
            foreach (var child in m_ChildrenSection.Children())
            {
                (child as PotentialChildUI)?.UpdateName();
            }

            foreach (var relation in m_PotentialRelations)
            {
                (relation.createdComponent as Relation)?.ResetChildrenReferences();
            }
        }

        void BindRelationListItem(VisualElement rowItem, int index)
        {
            var suggestion = m_PotentialRelations[index];
            ((PotentialConditionUI)rowItem).BindToPotentialCondition(suggestion);
        }
    }
}

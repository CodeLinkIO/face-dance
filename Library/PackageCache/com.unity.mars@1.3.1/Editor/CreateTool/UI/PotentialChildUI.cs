using Unity.MARS.Authoring;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// UI for a potential child in a proxy group that is being created.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    class PotentialChildUI : VisualElement
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CreateTool/UI/ProxyGroupChildField.uxml";

        public new class UxmlFactory : UxmlFactory<PotentialChildUI> { }

        PotentialChild m_PotentialChild;

        Label m_NameLabel;
        Button m_Button;
        int m_Index;

        internal Button Button { get { return m_Button; } }

        public PotentialChildUI()
        {
            SetupFromTemplate();
        }

        public PotentialChildUI(PotentialChild child, int index)
        {
            m_PotentialChild = child;
            m_Index = index;
            SetupFromTemplate();
            UpdateName();

            m_Button.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
        }

        void SetupFromTemplate()
        {
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_UxmlPath);
            template.CloneTree(this);
            m_NameLabel = this.Q<Label>("Name");
            m_Button = this.Q<Button>("Button");
        }

        internal void UpdateName()
        {
            if (m_PotentialChild.createProxyFromData.CreatedGameObject != null)
                m_NameLabel.text = $"{m_Index + 1}. {m_PotentialChild.createProxyFromData.CreatedGameObject.name}";
        }
    }
}

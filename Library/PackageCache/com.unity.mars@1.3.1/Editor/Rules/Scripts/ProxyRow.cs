using UnityEditor;
using UnityEditor.MARS.Simulation;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS.Rules.RulesEditor
{
    class ProxyRow : EntityRow
    {
        const string k_ProxyRowPath = k_Directory + "ProxyRow.uxml";

        const string k_SimMatchCountName = "simMatchCount";
        const string k_ContentContainerName = "contentContainer";

        const string k_AddButtonProxyAnalyticsLabel = "Margin add button (Proxy row)";

        Transform m_Transform;
        Transform m_SimulatedObject;

        Label m_SimMatchCount;

        internal override Transform ContainerObject => m_Transform;
        internal override GameObject BackingObject => m_Entity.gameObject;

        public ProxyRow(Proxy proxy)
        {
            m_Entity = proxy;
            m_Transform = m_Entity.transform;
            m_SimulatedObject = SimulatedObjectsManager.instance.GetCopiedTransform(m_Transform);

            SetupUI();
        }

        protected sealed override void SetupUI()
        {
            var proxyRowAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_ProxyRowPath);
            proxyRowAsset.CloneTree(this);

            base.SetupUI();

            SetupProxyPresetUI(m_Entity);
            m_ProxyField.value = m_Entity;

            m_SimMatchCount = this.Q<Label>(k_SimMatchCountName);
            if (m_SimulatedObject == null)
                m_SimMatchCount.style.display = DisplayStyle.None;

            m_ContentContainer = this.Q<VisualElement>(k_ContentContainerName);

            m_ContentRows = new ContentRow[m_Transform.childCount];
            for (int i = 0; i < m_Transform.childCount; i++)
            {
                var child = m_Transform.GetChild(i);

                if (!ContentRow.IsApplicableToTransform(child))
                    continue;

                var contentRow = new ContentRow(m_Transform, child);
                m_ContentContainer.Add(contentRow);
                m_ContentRows[i] = contentRow;
            }

            CreateAddContentButton();
        }

        internal sealed override bool HasChanged(MARSEntity entity)
        {
            var entityTransform = entity.transform;
            if (base.HasChanged(entity) || entityTransform.childCount != m_ContentRows.Length)
                return true;

            for (int i = 0; i < entityTransform.childCount; i++)
            {
                var contentRow = m_ContentRows[i];
                var content = entityTransform.GetChild(i);
                if (contentRow.HasChanged(content))
                    return true;
            }

            return false;
        }

        internal override void Select()
        {
            base.Select(m_Entity, m_Transform, m_Transform.gameObject);
        }

        protected override void OnAddButton()
        {
            RulesModule.AddContent(m_Entity.transform);

            EditorEvents.RulesUiUsed.Send(new RuleUiArgs
            {
                label = k_AddButtonProxyAnalyticsLabel
            });
        }
    }
}

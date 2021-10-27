using System;
using Unity.XRTools.Utils;
using UnityEditor.MARS;
using UnityEditor.XRTools.Utils;

namespace Unity.MARS
{
    [Serializable]
    [PanelOrder(PanelOrders.ContentHierarchyOrder)]
    class ContentHierarchyPanel : HierarchyPanel
    {
        const string k_SimulationViewPaneLabel = "Content Hierarchy";
        static readonly string k_TypeName = typeof(ContentHierarchyPanel).FullName;

        protected override bool IsEnvironmentHierarchy => false;

        /// <inheritdoc />
        public override string PanelLabel => k_SimulationViewPaneLabel;

        /// <inheritdoc />
        public override bool PanelExpanded
        {
            get => EditorPrefsUtils.GetBool(k_TypeName, true);
            set => EditorPrefsUtils.SetBool(k_TypeName, value);
        }

        public override void OnEnable()
        {
            base.OnEnable();
            enabled = true;
            m_TreeViewSmallSize = 120f;
        }
    }
}

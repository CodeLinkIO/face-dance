using System;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    [Serializable]
    [PanelOrder(PanelOrders.EnvironmentHierarchyOrder)]
    class EnvironmentHierarchyPanel : HierarchyPanel
    {
        const string k_SimulationViewPaneLabel = "Environment Hierarchy";

        static readonly string k_TypeName = typeof(EnvironmentHierarchyPanel).FullName;

        protected override bool IsEnvironmentHierarchy => true;

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
            hideFlags = HideFlags.DontSave;
            enabled = true;
        }

        public override void OnGUI()
        {
            using (var verticalScope = new EditorGUILayout.VerticalScope())
            {
                if (Event.current.type == EventType.Repaint)
                {
                    // Extend this panel down to the bottom of the multi panel view
                    if (!DrawAsWindow)
                    {
                        var panelHeight = PanelWindow.position.height - verticalScope.rect.yMin;
                        var targetTreeSize = Mathf.Max(panelHeight, 60f);
                        if (Math.Abs(targetTreeSize - m_TreeViewSmallSize) > float.Epsilon)
                        {
                            m_TreeViewSmallSize = targetTreeSize;
                            Repaint();
                        }
                    }
                    else
                    {
                        m_TreeViewSmallSize = 60f;
                    }
                }

                base.OnGUI();
            }
        }
    }
}

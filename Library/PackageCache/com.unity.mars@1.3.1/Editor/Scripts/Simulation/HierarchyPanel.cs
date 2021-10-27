using System;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    [Serializable]
    abstract class HierarchyPanel : PanelView
    {
        static readonly Vector2 k_PrefSize = new Vector2(240f, 280f);
        static readonly Vector2 k_MinSize = new Vector2(240f, 160f);
        static readonly Vector2 k_MaxSize = new Vector2(MarsEditorGUI.MaxWindowSize, MarsEditorGUI.MaxWindowSize);

        [SerializeField]
        protected TreeViewState m_TreeViewState;

        [SerializeField]
        protected HierarchyState m_HierarchyViewState;

        [SerializeField]
        protected Vector2 m_ScrollPosition;

        protected float m_TreeViewSmallSize = 60f;
        bool m_ScrollToSelected;
        HierarchyTreeView m_HierarchyTreeView;
        bool m_NeedsReload = true;

        internal static bool enabled { get; set; }

        internal HierarchyTreeView HierarchyTreeView => m_HierarchyTreeView;

        protected virtual bool IsEnvironmentHierarchy => false;

        /// <inheritdoc />
        public override bool DrawAsWindow { get; set; }

        /// <inheritdoc />
        public override bool AutoRepaintOnSceneChange => false;

        /// <inheritdoc />
        public override bool UsePrefSize => false;

        /// <inheritdoc />
        public override Vector2 PreferredSize => k_PrefSize;

        /// <inheritdoc />
        public override Vector2 MinSize => k_MinSize;

        /// <inheritdoc />
        public override Vector2 MaxSize => k_MaxSize;

        public override void OnEnable()
        {
            base.OnEnable();
            hideFlags = HideFlags.DontSave;
            CreateTreeView();
            HierarchyTreeView.StyleName = PanelLabel;
        }

        /// <inheritdoc />
        public override void OnGUI()
        {
            var minHeight = m_HierarchyTreeView.totalHeight > m_TreeViewSmallSize ? k_PrefSize.y : m_TreeViewSmallSize;
            var maxHeight = DrawAsWindow ? EditorWindow.position.height : minHeight;
            using (new EditorGUILayout.VerticalScope(GUILayout.MinHeight(minHeight), GUILayout.MaxHeight(maxHeight)))
            {
                m_HierarchyTreeView.MaxHeight = maxHeight;
                DrawHierarchy();
            }
        }

        /// <inheritdoc />
        public override void Repaint()
        {
            if (EditorWindow != null)
                EditorWindow.Repaint();

            if (PanelWindow != null)
                PanelWindow.Repaint();
        }

        /// <inheritdoc />
        public override void OnSelectionChanged()
        {
            var ids = Selection.instanceIDs;
            m_HierarchyTreeView.SetSelection(ids);
            m_HierarchyTreeView.Reload();
            if (ids.Length > 0)
            {
                m_HierarchyTreeView.FrameItem(Selection.activeInstanceID);
                m_ScrollToSelected = true;
            }

            Repaint();
        }

        protected virtual void DrawHierarchy()
        {
            if (Event.current.type == EventType.Layout)
            {
                var simSceneModule = ModuleLoaderCore.instance.GetModule<SimulationSceneModule>();
                if (simSceneModule == null || !simSceneModule.IsSimulationReady)
                {
                    enabled = false;
                    m_NeedsReload = true;
                }
                else if (m_NeedsReload)
                {
                    Reload();
                    enabled = true;
                    m_NeedsReload = false;
                }
            }

            using (new EditorGUI.DisabledScope(!enabled))
            {
                m_ScrollPosition = m_HierarchyTreeView.DrawScrollingTreeView(m_ScrollPosition, ref m_ScrollToSelected, enabled);
            }
        }

        public void CacheState()
        {
            if (m_HierarchyTreeView != null)
                m_HierarchyTreeView.CacheState();
        }

        public void RestoreState()
        {
            if (m_HierarchyTreeView != null)
                m_HierarchyTreeView.RestoreState();
        }

        protected virtual void CreateTreeView()
        {
            if (m_TreeViewState == null)
                m_TreeViewState = new TreeViewState();

            var needsCacheState = false;
            if (m_HierarchyViewState == null)
            {
                m_HierarchyViewState = new HierarchyState();
                needsCacheState = true;
            }

            m_HierarchyTreeView = new HierarchyTreeView(m_TreeViewState, m_HierarchyViewState, IsEnvironmentHierarchy, needsCacheState);

            Reload();
        }

        /// <summary>
        /// Reload and repaint the tree view
        /// </summary>
        void Reload()
        {
            if (m_HierarchyTreeView == null)
                return;

            m_HierarchyTreeView.Reload();
            m_HierarchyTreeView.Repaint();
        }
    }
}

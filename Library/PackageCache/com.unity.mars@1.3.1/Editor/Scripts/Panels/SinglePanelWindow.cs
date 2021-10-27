using Unity.XRTools.Utils;
using UnityEngine;

namespace UnityEditor.MARS
{
    internal class SinglePanelWindow : EditorWindow, IHasCustomMenu
    {
        [SerializeField]
        PanelView m_PanelView;

        Vector2 m_ScrollView = Vector2.zero;
        bool m_VerticalScrollActive;
        bool m_HorizontalScrollActive;

        public void InitWindow(PanelView panelView)
        {
            titleContent = new GUIContent(panelView.PanelLabel);

            panelView.EditorWindow = this;
            panelView.DrawAsWindow = true;

            autoRepaintOnSceneChange = panelView.AutoRepaintOnSceneChange;

            // Force the window to the preferred size before drawing
            if (panelView.UsePrefSize)
            {
                minSize = panelView.PreferredSize;
                maxSize = panelView.PreferredSize;
            }
            else
            {
                minSize = panelView.MinSize;
                maxSize = panelView.MaxSize;
            }

            m_PanelView = panelView;

            Show();
            panelView.Repaint();

            // After window starts drawing allow for normal min and max sizes
            if (panelView.UsePrefSize)
            {
                minSize = panelView.MinSize;
                maxSize = panelView.MaxSize;
            }

            if (!m_PanelView.PanelPopoutCanScroll)
            {
                m_VerticalScrollActive = false;
                m_HorizontalScrollActive = false;
            }
        }

        public void AddItemsToMenu(GenericMenu menu)
        {
            this.MarsCustomMenuOptions(menu);
            m_PanelView.AddItemsToTabMenu(menu);
        }

        void OnGUI()
        {
            if (Event.current.type == EventType.Layout && m_PanelView == null)
            {
                Close();
                return;
            }

            m_PanelView.EditorWindow = this;
            m_PanelView.DrawAsWindow = true;

            var hasHelp = m_PanelView.HelpButtonAction != null;
            var hasSettings = m_PanelView.SettingsButtonFunc?.Invoke() != null;

            using (var outerArea = new EditorGUILayout.VerticalScope(GUIStyle.none))
            {
                // Used Begin & End instead of scope for optional scrolling
                if (m_PanelView.PanelPopoutCanScroll)
                    m_ScrollView = EditorGUILayout.BeginScrollView(m_ScrollView, GUIStyle.none);

                using (var innerArea = new EditorGUILayout.VerticalScope(GUIStyle.none))
                {
                    if (Event.current.type == EventType.Repaint && m_PanelView.PanelPopoutCanScroll)
                    {
                        m_VerticalScrollActive = outerArea.rect.height <= innerArea.rect.height;
                        m_HorizontalScrollActive = outerArea.rect.width <= innerArea.rect.width;
                    }

                    if (hasHelp || hasSettings)
                    {
                        EditorGUIUtils.DrawFoldoutUI(
                            true,
                            false,
                            string.Empty,
                            GUIStyle.none,
                            GUIStyle.none,
                            m_PanelView.OnGUI,
                            null,
                            m_PanelView.HelpButtonAction,
                            m_PanelView.SettingsButtonFunc,
                            null);
                    }
                    else
                        m_PanelView.OnGUI();

                    m_PanelView.ScrollingVertical = m_VerticalScrollActive;
                    m_PanelView.ScrollingHorizontal = m_HorizontalScrollActive;
                }

                if (m_PanelView.PanelPopoutCanScroll)
                    EditorGUILayout.EndScrollView();
            }
        }

        void OnSelectionChange()
        {
            m_PanelView.OnSelectionChanged();
        }

        void OnDestroy()
        {
            if (m_PanelView == null)
                return;

            if (m_PanelView.PanelWindow != null)
            {
                m_PanelView.EditorWindow = null;
                m_PanelView.Repaint();
            }
            else
            {
                UnityObjectUtils.Destroy(m_PanelView);
            }
        }
    }
}

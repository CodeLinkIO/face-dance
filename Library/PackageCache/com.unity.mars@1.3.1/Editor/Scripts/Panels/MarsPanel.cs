using System;
using System.Collections.Generic;
using Unity.MARS;
using UnityEngine;

namespace UnityEditor.MARS
{
    class MarsPanel : EditorWindow, IHasCustomMenu
    {
        public const string WindowTitle = "MARS Panel";
        static readonly Vector2 k_MinSize = new Vector2(275f, 512f);
        static readonly List<Type> k_PanelTypes = new List<Type>();
        static readonly GUIContent k_CollectPanelsContent = new GUIContent("Collect Panels");

        Vector2 m_ScrollView = Vector2.zero;
        bool m_VerticalScrollActive;
        bool m_HorizontalScrollActive;

        readonly List<PanelView> m_PanelViews = new List<PanelView>();

        static MarsPanel()
        {
            foreach (var type in TypeCache.GetTypesDerivedFrom<PanelView>())
            {
                if (type.IsAbstract)
                    continue;

                k_PanelTypes.Add(type);
            }

            var orders = new Dictionary<Type, int>(k_PanelTypes.Count);
            foreach (var type in k_PanelTypes)
            {
                // Panels without an order go to the bottom
                orders[type] = PanelOrders.DefaultOrder;
                var attributes = type.GetCustomAttributes(typeof(PanelOrderAttribute), true);
                if (attributes.Length > 0)
                    orders[type] = ((PanelOrderAttribute)attributes[0]).Order;
            }

            k_PanelTypes.Sort((a, b) => orders[a].CompareTo(orders[b]));
        }

        [MenuItem(MenuConstants.MenuPrefix + WindowTitle, priority = MenuConstants.PanelPriority)]
        internal static void Init()
        {
            GetWindow(typeof(MarsPanel), false, WindowTitle);
            EditorEvents.UiComponentUsed.Send(new UiComponentArgs { label = WindowTitle, active = true });
        }

        internal static void NewTab(object userData)
        {
            if (!(MarsEditorUtils.CustomAddTabToHere(userData) is MarsPanel window))
                return;

            EditorEvents.UiComponentUsed.Send(new UiComponentArgs { label = WindowTitle, active = true });
            window.titleContent.text = WindowTitle;
        }

        public void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(k_CollectPanelsContent, false, CloseAllPanelWindows);
            menu.AddSeparator(string.Empty);
            this.MarsCustomMenuOptions(menu);
        }

        void OnEnable()
        {
            minSize = k_MinSize;
            autoRepaintOnSceneChange = true;

            foreach (var panelType in k_PanelTypes)
            {
                var panels = Resources.FindObjectsOfTypeAll(panelType);
                if (panels.Length > 0)
                {
                    var panel = (PanelView)panels[0];
                    panel.OnEnable();
                    m_PanelViews.Add(panel);
                }
                else
                    m_PanelViews.Add((PanelView)CreateInstance(panelType));
            }

            foreach (var panelView in m_PanelViews)
            {
                panelView.RecordFoldoutAnalyticsEvent = expanded => RecordFoldoutAnalyticsEvent(expanded, panelView.PanelLabel);
            }
        }

        void OnDisable()
        {
            foreach (var panelView in m_PanelViews)
            {
                panelView.OnDisable();
            }
            m_PanelViews.Clear();
        }

        void OnGUI()
        {
            if (!MARSEntitlements.instance.EntitlementsCheckGUI(position.width))
                return;

            if (EditorApplication.isPlayingOrWillChangePlaymode && !Application.isPlaying)
                GUIUtility.ExitGUI();

            var headerToggle = MarsEditorGUI.Styles.HeaderToggle;
            var headerLabel = MarsEditorGUI.Styles.HeaderLabel;

            using (var outerArea = new EditorGUILayout.VerticalScope(GUIStyle.none))
            {
                using (var scrollView = new EditorGUILayout.ScrollViewScope(m_ScrollView))
                {
                    using (var innerArea = new EditorGUILayout.VerticalScope(GUIStyle.none))
                    {
                        if (Event.current.type == EventType.Repaint)
                        {
                            m_VerticalScrollActive = outerArea.rect.height <= innerArea.rect.height;
                            m_HorizontalScrollActive = outerArea.rect.width <= innerArea.rect.width;
                        }

                        EditorGUIUtils.DrawSplitter();
                        foreach (var panelView in m_PanelViews)
                        {
                            var drawAsWindow = DrawAsWindow(panelView);

                            var panelExpanded = panelView.PanelExpanded;
                            panelExpanded = EditorGUIUtils.DrawFoldoutUI(
                                panelExpanded && !drawAsWindow,
                                !drawAsWindow,
                                panelView.PanelLabel,
                                headerToggle,
                                headerLabel,
                                panelView.OnGUI,
                                panelView.RecordFoldoutAnalyticsEvent,
                                panelView.HelpButtonAction,
                                panelView.SettingsButtonFunc,
                                panelView.TabMenuFunc);

                            // Don't want to set panel these values if not the parent of the panel
                            if (!drawAsWindow)
                            {
                                panelView.PanelExpanded = panelExpanded;
                                panelView.ScrollingVertical = m_VerticalScrollActive;
                                panelView.ScrollingHorizontal = m_HorizontalScrollActive;
                            }
                        }
                    }

                    m_ScrollView = scrollView.scrollPosition;
                }
            }
        }

        void OnSelectionChange()
        {
            Repaint();
            foreach (var panel in m_PanelViews)
            {
                panel.OnSelectionChanged();
            }
        }

        bool DrawAsWindow(PanelView panelView)
        {
            if (panelView.PanelWindow != this)
                panelView.PanelWindow = this;

            if (panelView.EditorWindow == null)
                panelView.DrawAsWindow = false;

            return panelView.DrawAsWindow;
        }

        static void RecordFoldoutAnalyticsEvent(bool expanded, string label)
        {
            EditorEvents.UiComponentUsed.Send(new UiComponentArgs { label = $"{WindowTitle} / {label}", active = expanded });
        }

        void CloseAllPanelWindows()
        {
            foreach (var panelView in m_PanelViews)
            {
                if (panelView.EditorWindow != null)
                    panelView.EditorWindow.Close();
            }
        }
    }
}

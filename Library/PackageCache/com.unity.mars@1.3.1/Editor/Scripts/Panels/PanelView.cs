using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Common base class for gui drawn in panels and window tear off.
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public abstract class PanelView : ScriptableObject
    {
        /// <summary>
        /// Single menu item for a generic menu in the panel view.
        /// </summary>
        protected struct MenuItemData
        {
            GUIContent m_Content;
            bool m_On;
            GenericMenu.MenuFunction m_Func;

            /// <summary>
            /// The GUIContent to add as a menu item.
            /// </summary>
            public GUIContent Content => m_Content;

            /// <summary>
            /// Specifies whether to show the item is currently activated (i.e. a tick next to the item in the menu).
            /// </summary>
            public bool On => m_On;

            /// <summary>
            /// Callback function, called when a menu item is selected.
            /// </summary>
            public GenericMenu.MenuFunction Func => m_Func;

            /// <summary>
            /// Creates Menu Item Data for use in a generic menu in the panel view
            /// </summary>
            /// <param name="content">The GUIContent to add as a menu item.</param>
            /// <param name="on">Specifies whether to show the item is currently activated (i.e. a tick next to the item in the menu).</param>
            /// <param name="func">Callback function, called when a menu item is selected.</param>
            public MenuItemData(GUIContent content, bool on, GenericMenu.MenuFunction func)
            {
                m_Content = content;
                m_On = on;
                m_Func = func;
            }
        }

        static readonly GUIContent k_OpenWindowContent = new GUIContent("Open as window");
        static readonly GUIContent k_ReturnWindowContent = new GUIContent("Return Panel");

        /// <summary>
        /// Name of the panel used in the header and for tear off window name.
        /// </summary>
        public abstract string PanelLabel { get; }

        /// <summary>
        /// Is the panel currently expanded under the header.
        /// </summary>
        public virtual bool PanelExpanded { get; set; }

        /// <summary>
        /// Is the panel being drawn in a tear off window.
        /// </summary>
        public abstract bool DrawAsWindow { get; set; }

        /// <summary>
        /// Should the panel cause the tear off window to auto repaint on scene change
        /// </summary>
        public abstract bool AutoRepaintOnSceneChange { get; }

        /// <summary>
        /// Should the panel use the preferred size when initially drawing as a window.
        /// </summary>
        public abstract bool UsePrefSize { get; }

        /// <summary>
        /// Size of panel when opening as a window
        /// </summary>
        public abstract Vector2 PreferredSize { get; }

        /// <summary>
        /// Minimum size of the panel
        /// </summary>
        public abstract Vector2 MinSize { get; }

        /// <summary>
        /// Maximum sized of the panel
        /// </summary>
        public abstract Vector2 MaxSize { get; }

        /// <summary>
        /// Tear off editor window the panel is attached to.
        /// </summary>
        public virtual EditorWindow EditorWindow { get; set; }

        /// <summary>
        /// Panel window the panel is attached to.
        /// </summary>
        public virtual EditorWindow PanelWindow { get; set; }

        /// <summary>
        /// Does the panel popout support scrolling
        /// </summary>
        public virtual bool PanelPopoutCanScroll { get; } = false;

        /// <summary>
        /// Does the panel scroll horizontally
        /// </summary>
        public bool ScrollingHorizontal { get; set; }

        /// <summary>
        /// Does the panel scroll Vertically
        /// </summary>
        public bool ScrollingVertical { get; set; }

        /// <summary>
        /// Draws the panel contents
        /// </summary>
        public virtual void OnGUI()
        {
            if (!DrawAsWindow)
                EditorGUIUtils.DrawSplitter();
        }

        /// <summary>
        /// Calls repaint on the panel and the parent window(s).
        /// </summary>
        public abstract void Repaint();

        /// <summary>
        /// Callback for on selection change.
        /// </summary>
        public abstract void OnSelectionChanged();

        /// <summary>
        /// Callback for help button Action.
        /// </summary>
        public virtual Action HelpButtonAction { get; private set; }

        /// <summary>
        /// Callback for popup settings panel view.
        /// </summary>
        public virtual Func<GenericMenu> SettingsButtonFunc { get; private set; }

        /// <summary>
        /// Callback for Tab panel view. Override with Null if you want not drawn.
        /// </summary>
        public virtual Func<GenericMenu> TabMenuFunc { get; private set; }

        /// <summary>
        /// Action called when panel expanded has changed.
        /// </summary>
        internal Action<bool> RecordFoldoutAnalyticsEvent;

        /// <summary>
        /// This function is called when the object is loaded.
        /// </summary>
        public virtual void OnEnable()
        {
            name = $"{GetType().Name}_{GetInstanceID()}";
            HelpButtonAction = null;
            SettingsButtonFunc = null;
            TabMenuFunc = () => AddItemsToTabMenu(new GenericMenu());
        }

        /// <summary>
        /// This function is called when the scriptable object goes out of scope.
        /// </summary>
        public virtual void OnDisable() { }

        /// <summary>
        /// Draws the basic panel tab options. Override to add more Options to the menu popup.
        /// </summary>
        public virtual GenericMenu AddItemsToTabMenu(GenericMenu menu)
        {
            menu = CreatePanelMenu(this, menu);
            return menu;
        }

        /// <summary>
        /// Creates the generic menu for popping out the panel and returning it to the panel view.
        /// </summary>
        /// <returns>generic menu with options for active panel</returns>
        static GenericMenu CreatePanelMenu(PanelView view, GenericMenu menu)
        {
            if (!view.DrawAsWindow)
            {
                menu.AddItem(k_OpenWindowContent, false, () =>
                {
                    var window = CreateInstance<SinglePanelWindow>();
                    window.InitWindow(view);
                });
            }
            else
            {
                menu.AddItem(k_ReturnWindowContent, false, () =>
                {
                    if (view.EditorWindow != null)
                        view.EditorWindow.Close();
                });
            }

            var viewMenuItems = view.MenuItems();
            if (viewMenuItems != null)
            {
                foreach (var menuItem in viewMenuItems)
                {
                    menu.AddItem(menuItem.Content, menuItem.On, menuItem.Func);
                }
            }

            return menu;
        }

        /// <summary>
        /// Used to add extra menu items to the panel view's create panel menu.
        /// </summary>
        /// <returns>The menu items to be added to the generic menu</returns>
        protected virtual MenuItemData[] MenuItems()
        {
            return null;
        }
    }
}

using Unity.MARS;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Editor window for creating MARS objects. Window holds visual element "pages" that inherit from CreateFromDataBaseUI
    /// When a new page is added, the current shown page will be hidden. When the page is closed, the previous page is shown.
    /// If there is no previous page, the window closes.
    /// </summary>
    sealed class CreateFromDataWindow : EditorWindow
    {
        static readonly Vector2 k_WindowSize = new Vector2(400, 275);

        int m_PageIndex = -1;
        bool m_WasForceClosed;

        GUIContent WindowTitle { get; } = new GUIContent("Create");

        void OnEnable()
        {
            titleContent = WindowTitle;
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = WindowTitle.text, active = true });
        }

        /// <summary>
        /// Opens the create window as a Modal window.
        /// </summary>
        internal void Open(Vector2 clickPosition)
        {
            m_WasForceClosed = true;
            position = new Rect(clickPosition - k_WindowSize * 0.5f, k_WindowSize);
            ShowAuxWindow();
        }

        /// <summary>
        /// Adds a new page to the window, hiding any previous UI inside the window. When the page is closed, the previous page will be
        /// shown again.
        /// </summary>
        /// <param name="newPage"> The UI for the new page. </param>
        internal void AddNewPage(CreateFromDataBaseUI newPage)
        {
            if (rootVisualElement.childCount == 0)
                m_PageIndex = -1;

            if (m_PageIndex >= 0)
                rootVisualElement.ElementAt(m_PageIndex).style.display = new StyleEnum<DisplayStyle>(DisplayStyle.None);

            newPage.style.flexGrow = 1f;
            rootVisualElement.Add(newPage);
            m_PageIndex++;

            newPage.Create += ClosePage;
            newPage.Cancel += ClosePage;
        }

        void ClosePage()
        {
            if (m_PageIndex >= 0)
            {
                rootVisualElement.RemoveAt(m_PageIndex);
                m_PageIndex--;
                if (m_PageIndex >= 0)
                {
                    var childElement = rootVisualElement.ElementAt(m_PageIndex);
                    childElement.style.display = new StyleEnum<DisplayStyle>(DisplayStyle.Flex);
                    (childElement as CreateFromDataBaseUI)?.Refresh();
                }
                else
                {
                    m_WasForceClosed = false;
                    Close();
                }
            }
        }

        void OnDestroy()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = WindowTitle.text, active = false });
            if (m_WasForceClosed)
            {
                foreach (var child in rootVisualElement.Children())
                {
                    var pageUI = (child as CreateFromDataBaseUI);
                    if (pageUI == null)
                        continue;

                    // Unsubscribe from close event because the window is already being destroyed
                    pageUI.Cancel -= ClosePage;
                    pageUI.WasForceClosed();
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// UI for button overlay for creating in simulation view
    /// </summary>
    class CreateButtonsOverlay : VisualElement
    {
        const string k_UxmlPath = MarsUIResources.EditorFolderPath + "CreateTool/UI/CreateButtonsOverlay.uxml";
        const float k_OffsetHeight = 22f; // Vertical offset from the top of the layout to the top of the rendered view

        VisualElement m_ButtonRoot;

        public new class UxmlFactory : UxmlFactory<CreateButtonsOverlay> { }

        public Button CreateButton { get; private set; }

        public CreateButtonsOverlay()
        {
            SetupFromTemplate();
            pickingMode = PickingMode.Ignore;
        }

        void SetupFromTemplate()
        {
            var template = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_UxmlPath);
            template.CloneTree(this);
            this.StretchToParentSize();
            CreateButton = this.Q<Button>("CreateButton");
            m_ButtonRoot = this.Q<VisualElement>("ButtonsRoot");
        }

        public void SetButtonsPosition(Vector2 viewportPoint)
        {
            if (m_ButtonRoot == null)
                return;

            // Convert from viewport point to layout position
            var layoutPosition = new Vector2(layout.width * viewportPoint.x, (layout.height - k_OffsetHeight) * (1f - viewportPoint.y));

            // Centered
            var boundSize = m_ButtonRoot.localBound.size;
            layoutPosition -= boundSize * 0.5f;

            // Stay within view bounds
            layoutPosition.x = Mathf.Clamp(layoutPosition.x, 0, layout.width - boundSize.x);
            layoutPosition.y = Mathf.Clamp(layoutPosition.y, 0, layout.height - k_OffsetHeight - boundSize.y);

            m_ButtonRoot.style.left = layoutPosition.x;
            m_ButtonRoot.style.top = layoutPosition.y + k_OffsetHeight;
        }

        public void SetButtonsVisible(bool visibility) { m_ButtonRoot.visible = visibility; }
    }
}

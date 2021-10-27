using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    [RequireComponent(typeof(Renderer))]
    [DisallowMultipleComponent]
    [AddComponentMenu("")]
    class HandleStateColors : HandleBehaviour
    {
        [SerializeField] Color m_HoverColor = new Color(1f, 0.98f, 0.69f);
        [SerializeField] Color m_DragColor = Color.yellow;
        [SerializeField] Color m_DisableColor = Color.grey;
        [SerializeField] bool m_UseDisableColor = true;

        Color m_IdleColor;
        Renderer m_TargetRenderer;

        /// <summary>
        /// The renderer affected by the color transitions
        /// </summary>
        public Renderer targetRenderer => m_TargetRenderer;

        /// <summary>
        /// The color used when the handle is idle
        /// </summary>
        public virtual Color idleColor
        {
            get => m_IdleColor;
            set
            {
                m_IdleColor = value;
                UpdateIdleColor();
            }
        }

        /// <summary>
        /// The color used when the handle is hovered
        /// </summary>
        public virtual Color hoverColor
        {
            get => m_HoverColor;
            set => m_HoverColor = value;
        }

        /// <summary>
        /// The color used when the handle is dragged
        /// </summary>
        public virtual Color dragColor
        {
            get => m_DragColor;
            set => m_DragColor = value;
        }

        /// <summary>
        /// The color used when another handle is dragged
        /// </summary>
        public virtual Color disableColor
        {
            get => m_DisableColor;
            set => m_DisableColor = value;
        }

        bool m_IsHovered = false;

        protected virtual void Awake()
        {
            m_TargetRenderer = GetComponent<Renderer>();
            if (m_TargetRenderer != null && m_TargetRenderer.sharedMaterial != null)
                m_IdleColor = m_TargetRenderer.sharedMaterial.color;
            else
                m_IdleColor = Color.white;
        }

        protected override void HoverBegin(InteractiveHandle target, HoverBeginInfo info)
        {
            if (ownerHandle != target)
                return;

            m_IsHovered = true;
            SetColor(hoverColor);
        }

        protected override void HoverEnd(InteractiveHandle target, HoverEndInfo info)
        {
            if (ownerHandle != target)
                return;

            m_IsHovered = false;
            SetColor(idleColor);
        }

        protected override void DragBegin(InteractiveHandle target, DragBeginInfo info)
        {
            if (ownerHandle == target)
            {
                SetColor(dragColor);
            }
            else if (m_UseDisableColor)
            {
                SetColor(disableColor);
            }
        }

        protected override void DragEnd(InteractiveHandle target, DragEndInfo info)
        {
            SetColor(m_IsHovered ? hoverColor : idleColor);
        }

        protected void UpdateIdleColor()
        {
            if (!m_IsHovered)
                SetColor(m_IdleColor);
        }

        void SetColor(Color color)
        {
            if (m_TargetRenderer != null && m_TargetRenderer.sharedMaterial != null)
                m_TargetRenderer.sharedMaterial.color = color;
        }
    }
}

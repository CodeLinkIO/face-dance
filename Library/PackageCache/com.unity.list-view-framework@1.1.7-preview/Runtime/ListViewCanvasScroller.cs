using UnityEngine;

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
using UnityEngine.EventSystems;
#endif

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Use this behavior with Unity UI to scroll list views that are part of canvases
    /// </summary>
    public class ListViewCanvasScroller : ListViewScroller
#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        , IBeginDragHandler, IDragHandler, IEndDragHandler
#endif
    {
#pragma warning disable 649
        [SerializeField]
        bool m_Horizontal;
#pragma warning restore 649

        RectTransform m_RectTransform;
        Camera m_Camera;

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        void Awake()
        {
            m_RectTransform = GetComponent<RectTransform>();
            var canvas = GetComponentInParent<Canvas>();
            m_Camera = canvas.worldCamera;
        }

        /// <inheritdoc/>
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RectTransform, eventData.position, m_Camera, out localPoint);
            OnScrollStarted(localPoint);
        }

        /// <inheritdoc/>
        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (m_Scrolling)
            {
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RectTransform, eventData.position, m_Camera, out localPoint);
                if (m_Horizontal)
                    m_ListView.scrollOffset = m_StartOffset - (m_StartPosition.x - localPoint.x);
                else
                    m_ListView.scrollOffset = m_StartOffset - (localPoint.y - m_StartPosition.y);
            }
        }

        /// <inheritdoc/>
        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            OnScrollEnded();
        }
#endif
    }
}

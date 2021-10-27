using UnityEngine;

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
using UnityEngine.EventSystems;
#endif

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Base class for behaviors which handle input and scroll list views
    /// </summary>
    public class ListViewScroller : MonoBehaviour
#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        , IScrollHandler
#endif
    {
#pragma warning disable 649
        /// <summary>
        /// The target list view which will be scrolled
        /// </summary>
        [SerializeField]
        protected ListViewControllerBase m_ListView;
#pragma warning restore 649

        /// <summary>
        /// Whether or not the list is being scrolled
        /// </summary>
        protected bool m_Scrolling;

        /// <summary>
        /// The starting position of the pointer or interactor for the current scroll interaction
        /// </summary>
        protected Vector3 m_StartPosition;

        /// <summary>
        /// The value of the target list's startOffset property at the start of the current interaction
        /// </summary>
        protected float m_StartOffset;

        /// <summary>
        /// Call this method when starting a scroll interaction
        /// </summary>
        /// <param name="start">The staring position of the pointer or interactor</param>
        public virtual void OnScrollStarted(Vector3 start)
        {
            if (m_Scrolling)
                return;

            m_Scrolling = true;
            m_StartPosition = start;
            m_StartOffset = m_ListView.scrollOffset;
            m_ListView.OnScrollStarted();
        }

        /// <summary>
        /// Call this method every frame during a scroll interaction (including the first frame)
        /// This is called by the EventSystem on this class if it receives any scroll events
        /// </summary>
        /// <param name="position">The position of the pointer or interactor</param>
        public virtual void OnScroll(Vector3 position)
        {
            if (m_Scrolling)
                m_ListView.scrollOffset = m_StartOffset + position.x - m_StartPosition.x;
        }

        /// <summary>
        /// Call this method after a scroll interaction has ended
        /// </summary>
        public virtual void OnScrollEnded()
        {
            m_Scrolling = false;
            m_ListView.OnScrollEnded();
        }

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        /// <inheritdoc/>
        void IScrollHandler.OnScroll(PointerEventData eventData)
        {
            m_ListView.OnScroll(eventData);
        }
#endif
    }
}

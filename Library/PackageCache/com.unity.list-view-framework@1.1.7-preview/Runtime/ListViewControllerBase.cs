using System;
using UnityEngine;

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
using UnityEngine.EventSystems;
#endif

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Provides base List View Controller functionality which does not require generic arguments
    /// Allows reference to any ListViewController type without specifying generic arguments
    /// </summary>
    public abstract class ListViewControllerBase : MonoBehaviour
#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        , IScrollHandler
#endif
    {
        /// <summary>
        /// Distance we have scrolled from initial position
        /// </summary>
        [Tooltip("Distance we have scrolled from initial position")]
        [SerializeField]
        protected float m_ScrollOffset;

        /// <summary>
        /// Padding between items
        /// </summary>
        [Tooltip("Padding between items")]
        [SerializeField]
        protected float m_Padding = 0.01f;

        [Tooltip("How quickly scroll momentum fades")]
        [SerializeField]
        float m_ScrollDamping = 5f;

        [Tooltip("How quickly scroll momentum fades when scrolled past extents")]
        [SerializeField]
        float m_OverScrollDamping = 25f;

        [Tooltip("Maximum velocity for scroll momentum")]
        [SerializeField]
        float m_MaxMomentum = 2f;

        /// <summary>
        /// Speed at which items settle
        /// </summary>
        [Tooltip("Speed at which items settle")]
        [SerializeField]
        protected float m_SettleSpeed = 0.4f;

        [Tooltip("Speed of fixed-speed scrolling")]
        [SerializeField]
        float m_ScrollSpeed = 0.3f;

        /// <summary>
        /// Item template prefabs (at least one is required)
        /// </summary>
        [Tooltip("Item template prefabs (at least one is required)")]
        [SerializeField]
        protected GameObject[] m_Templates;

        /// <summary>
        /// Whether to interpolate item positions
        /// </summary>
        [Tooltip("Whether to interpolate item positions")]
        [SerializeField]
        protected bool m_EnableSettling = true;

        float m_LastScrollOffset;
        event Action settlingCompleted;

        /// <summary>
        /// Whether the items in this list are currently settling
        /// </summary>
        protected bool m_Settling;

        /// <summary>
        /// The size of each item
        /// </summary>
        protected Vector3 m_ItemSize;

        /// <summary>
        /// The starting position from which to offset items
        /// </summary>
        protected Vector3 m_StartPosition;

        /// <summary>
        /// Whether this list is currently scrolling
        /// </summary>
        protected bool m_Scrolling;

        /// <summary>
        /// The offset to which this list will return when it stops scrolling
        /// Set to float.MaxValue if the list should stay where it is
        /// </summary>
        protected float m_ScrollReturn = float.MaxValue;

        /// <summary>
        /// The current amount of scroll momentum
        /// </summary>
        protected float m_ScrollDelta;

        /// <summary>
        /// The size of the list area
        /// </summary>
        protected Vector3 m_Size;

        /// <summary>
        /// The extents (half the size) of the list area
        /// </summary>
        protected Vector3 m_Extents;

        /// <summary>
        /// The total height of all list rows, used to determine the maximum amount of scroll offset before snapping back
        /// </summary>
        protected abstract float listHeight { get; }

        /// <summary>
        /// The distance we have scrolled from initial position
        /// </summary>
        public float scrollOffset
        {
            get { return m_ScrollOffset; }
            set { m_ScrollOffset = value; }
        }

        /// <summary>
        /// The speed of fixed-speed scrolling
        /// </summary>
        public float scrollSpeed
        {
            get { return m_ScrollSpeed; }
            set { m_ScrollSpeed = value; }
        }

        /// <summary>
        /// The size of each item
        /// </summary>
        public Vector3 itemSize
        {
            get { return m_ItemSize; }
        }

        /// <summary>
        /// The size of the list area
        /// </summary>
        public virtual Vector3 size
        {
            set
            {
                m_Size = value;
                m_Extents = m_Size * 0.5f;
            }
        }

        /// <summary>
        /// Called when the script instance is being loaded
        /// </summary>
        protected virtual void Awake()
        {
            if (m_Templates.Length > 0)
                m_ItemSize = GetObjectSize(m_Templates[0]);
            else
                Debug.LogWarning("List View Error: At least one template is required", this);
        }

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled
        /// </summary>
        protected virtual void Update()
        {
            UpdateView();
        }

        /// <summary>
        /// Update the list view, called once per frame
        /// </summary>
        protected virtual void UpdateView()
        {
            if (!HasData())
                return;

            ComputeConditions();
            UpdateItems();
        }

        /// <summary>
        /// Called by UpdateView to update fields which control the state of the entire list
        /// </summary>
        protected virtual void ComputeConditions()
        {
            var itemHeight = m_ItemSize.z;
            m_StartPosition = (m_Extents.z - itemHeight * 0.5f) * Vector3.forward;

            if (m_Scrolling)
            {
                m_ScrollDelta = Mathf.Clamp((m_ScrollOffset - m_LastScrollOffset) / Time.deltaTime, -m_MaxMomentum, m_MaxMomentum);
                m_LastScrollOffset = m_ScrollOffset;
            }
            else
            {
                //Apply scrolling momentum
                m_ScrollOffset += m_ScrollDelta * Time.deltaTime;
                var pastExtents = m_ScrollReturn < float.MaxValue || m_ScrollOffset > 0;
                var damping = pastExtents ? m_OverScrollDamping : m_ScrollDamping;
                if (m_ScrollDelta > 0)
                {
                    m_ScrollDelta -= damping * Time.deltaTime;
                    if (m_ScrollDelta < 0)
                        m_ScrollDelta = 0;
                }
                else if (m_ScrollDelta < 0)
                {
                    m_ScrollDelta += damping * Time.deltaTime;
                    if (m_ScrollDelta > 0)
                        m_ScrollDelta = 0;
                }
                else if (pastExtents)
                {
                    if (m_ScrollOffset > 0)
                    {
                        if (m_EnableSettling)
                        {
                            m_ScrollOffset = Mathf.Lerp(m_ScrollOffset, 0, m_SettleSpeed);
                            if (Mathf.Approximately(m_ScrollOffset, 0))
                                m_ScrollDelta = 0;
                        }
                        else
                        {
                            m_ScrollOffset = 0;
                        }
                    }

                    if (m_ScrollReturn < float.MaxValue)
                    {
                        var target = m_ScrollReturn + m_ItemSize.z;
                        if (m_EnableSettling)
                        {
                            m_ScrollOffset = Mathf.Lerp(m_ScrollOffset, target, m_SettleSpeed);
                            if (Mathf.Approximately(m_ScrollOffset, target))
                            {
                                m_ScrollReturn = float.MaxValue;
                                m_ScrollDelta = 0;
                            }
                        }
                        else
                        {
                            m_ScrollOffset = target;
                        }
                    }
                }
            }

            m_ScrollReturn = float.MaxValue;

            // Snap back if list scrolled too far
            if (listHeight > 0)
            {
                var visibleSize = m_Size.z;
                if (listHeight < visibleSize)
                {
                    if (m_ScrollOffset < 0)
                        m_ScrollReturn = 0;
                }
                else
                {
                    if (-m_ScrollOffset >= listHeight - visibleSize)
                        m_ScrollReturn = -(listHeight - visibleSize);
                }
            }
        }

        /// <summary>
        /// Called by UpdateView to update the list items
        /// </summary>
        protected abstract void UpdateItems();

        /// <summary>
        /// Scroll the next item
        /// </summary>
        public virtual void ScrollNext()
        {
            m_ScrollOffset -= m_ItemSize.z;
        }

        /// <summary>
        /// Scroll to the previous item
        /// </summary>
        public virtual void ScrollPrevious()
        {
            m_ScrollOffset += m_ItemSize.z;
        }

        /// <summary>
        /// Scroll to an item  based on its index in the list order (not its data index)
        /// </summary>
        /// <param name="index"></param>
        public virtual void ScrollTo(int index)
        {
            m_ScrollOffset = index * m_ItemSize.z;
        }

        /// <summary>
        /// Update a single item
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <param name="order">The order of this item, among the other visible items</param>
        /// <param name="offset">The offset at which to position this item</param>
        /// <param name="dontSettle">Whether to bypass settling behavior</param>
        /// <param name="doneSettling">Whether all items are done settling</param>
        protected virtual void UpdateItem(IListViewItem item, int order, float offset, bool dontSettle, ref bool doneSettling)
        {
            var targetPosition = m_StartPosition + offset * Vector3.back;
            var targetRotation = Quaternion.identity;
            UpdateItemTransform(item, order, targetPosition, targetRotation, dontSettle, ref doneSettling);
        }

        /// <summary>
        /// Update the transform of a single item
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <param name="order">The order of this item, among the other visible items</param>
        /// <param name="targetPosition">The target position</param>
        /// <param name="targetRotation">The target rotation</param>
        /// <param name="dontSettle">Whether to bypass settling behavior</param>
        /// <param name="doneSettling">Whether all items are done settling</param>
        protected virtual void UpdateItemTransform(IListViewItem item, int order, Vector3 targetPosition,
            Quaternion targetRotation, bool dontSettle, ref bool doneSettling)
        {
            if (m_Settling && !dontSettle && m_EnableSettling)
            {
                var localPosition = Vector3.Lerp(item.localPosition, targetPosition, m_SettleSpeed);
                item.localPosition = localPosition;
                if (localPosition != targetPosition)
                    doneSettling = false;

                var localRotation = Quaternion.Lerp(item.localRotation, targetRotation, m_SettleSpeed);
                item.localRotation = localRotation;
                if (localRotation != targetRotation)
                    doneSettling = false;
            }
            else
            {
                item.localPosition = targetPosition;
                item.localRotation = targetRotation;
            }

            item.SetSiblingIndex(order);
        }

        /// <summary>
        /// Get the size of a given GameObject
        /// </summary>
        /// <param name="g">The GameObject</param>
        /// <returns>The size of the GameObject, which by default is the size of the renderer returned by
        /// GetComponentInChildren, if any exists</returns>
        protected virtual Vector3 GetObjectSize(GameObject g)
        {
            var objectSize = Vector3.one;
            var rend = g.GetComponentInChildren<Renderer>();
            if (rend)
                objectSize = Vector3.Scale(g.transform.lossyScale, rend.bounds.extents) * 2 + Vector3.one * m_Padding;

            return objectSize;
        }

        /// <summary>
        /// Called when scrolling is started
        /// </summary>
        public virtual void OnScrollStarted()
        {
            m_Scrolling = true;
        }

        /// <summary>
        /// Called when scrolling ends
        /// </summary>
        public virtual void OnScrollEnded()
        {
            m_Scrolling = false;
        }

#if !UNITY_2019_2_OR_NEWER || INCLUDE_UGUI
        /// <summary>
        /// Called every frame while scrolling this list
        /// </summary>
        /// <param name="eventData">The input event data</param>
        public virtual void OnScroll(PointerEventData eventData)
        {
            if (m_Settling)
                return;

            m_ScrollOffset += eventData.scrollDelta.y * m_ScrollSpeed * Time.deltaTime;
        }
#endif

        /// <summary>
        /// Start the process of letting the list items settle into place
        /// </summary>
        /// <param name="onComplete">Called when all items are done settling</param>
        protected virtual void StartSettling(Action onComplete = null)
        {
            m_Settling = true;

            if (onComplete != null)
                settlingCompleted += onComplete;
        }

        /// <summary>
        /// Called when items are done settling
        /// </summary>
        protected virtual void EndSettling()
        {
            m_Settling = false;

            if (settlingCompleted != null)
            {
                settlingCompleted();
                settlingCompleted = null;
            }
        }

        /// <summary>
        /// Check whether the m_Data array is null
        /// </summary>
        /// <returns>True if m_Data is not null</returns>
        protected abstract bool HasData();
    }
}

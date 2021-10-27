using System;
using System.Collections.Generic;
using UnityEngine;

#if LISTVIEW_TESTS
using System.Diagnostics;
#endif

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Extended ListViewController for representing nested/hierarchical data
    /// </summary>
    /// <typeparam name="TData">The type of object in the list of data</typeparam>
    /// <typeparam name="TItem">The base type of all list items</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public abstract class NestedListViewController<TData, TItem, TIndex> : ListViewController<TData, TItem, TIndex>
        where TData : class, INestedListViewItemData<TData, TIndex>
        where TItem : class, INestedListViewItem<TData, TIndex>
    {
        /// <summary>
        /// Stack frame struct for unwound recursive UpdateNestedItems method
        /// </summary>
        protected struct UpdateData
        {
            /// <summary>
            /// Data list for this level of nesting
            /// </summary>
            public List<TData> data;

            /// <summary>
            /// Current level of nesting
            /// </summary>
            public int depth;

            /// <summary>
            /// Current index into data array
            /// </summary>
            public int index;
        }

        /// <summary>
        /// The total height of all list rows, used to determine the maximum amount of scroll offset before snapping back
        /// </summary>
        protected override float listHeight
        {
            get { return m_ExpandedDataLength; }
        }

        /// <summary>
        /// The total height of all list rows, taking into account which rows are expanded
        /// </summary>
        protected float m_ExpandedDataLength;

        /// <summary>
        /// Dictionary of item expanded state, keyed by index
        /// </summary>
        protected readonly Dictionary<TIndex, bool> m_ExpandStates = new Dictionary<TIndex, bool>();

        /// <summary>
        /// The list of data
        /// </summary>
        public override List<TData> data
        {
            get { return base.data; }
            set
            {
                foreach (var kvp in new Dictionary<TIndex, TItem>(m_ListItems))
                {
                    Recycle(kvp.Key);
                }

                m_ListItems.Clear();

                m_Data = value;
                scrollOffset = 0;
            }
        }

        Action<TData> m_ToggleExpanded;

        /// <summary>
        /// Re-usable stack of "stack frame" structs for recursive loop unwinding
        /// </summary>
        protected readonly Stack<UpdateData> m_UpdateStack = new Stack<UpdateData>();

        /// <summary>
        /// Called when the script instance is being loaded
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            m_ToggleExpanded = ToggleExpanded;
        }

        static TData GetRowRecursive(List<TData> data, TIndex index)
        {
            foreach (var datum in data)
            {
                if (datum.index.Equals(index))
                    return datum;

                var children = datum.children;
                if (children != null)
                {
                    var result = GetRowRecursive(children, index);
                    if (result != null)
                        return result;
                }
            }

            return default(TData);
        }

        /// <summary>
        /// Called by UpdateView to update the list items
        /// </summary>
        protected override void UpdateItems()
        {
            var doneSettling = true;
            var offset = 0f;
            var order = 0;

            UpdateNestedItems(ref order, ref offset, ref doneSettling);
            m_ExpandedDataLength = offset;

            if (m_Settling && doneSettling)
                EndSettling();
        }

        /// <summary>
        /// Called by UpdateItems to update the list of nested items
        /// </summary>
        /// <param name="order">The order of the starting item item</param>
        /// <param name="offset">The offset of the starting item</param>
        /// <param name="doneSettling">Whether all items are done settling</param>
        /// <param name="depth">The level of nesting</param>
        protected virtual void UpdateNestedItems(ref int order, ref float offset, ref bool doneSettling, int depth = 0)
        {
#if LISTVIEW_TESTS
            Debug.Assert(m_UpdateStack.Count == 0);
#endif

            // We assume that this stack is empty because of the while loop below;
            // It is possible for it to contain data if an exception is thrown inside the loop
            m_UpdateStack.Push(new UpdateData
            {
                data = m_Data,
                depth = depth
            });

            var itemWidth = m_ItemSize.z;
            var listWidth = m_Size.z;
            while (m_UpdateStack.Count > 0)
            {
                var stackData = m_UpdateStack.Pop();
                var nestedData = stackData.data;
                depth = stackData.depth;

                var i = stackData.index;
                for (; i < nestedData.Count; i++)
                {
                    var datum = nestedData[i];

                    var index = datum.index;
                    bool expanded;
                    if (!m_ExpandStates.TryGetValue(index, out expanded))
                        m_ExpandStates[index] = false;

                    var localOffset = offset + m_ScrollOffset;
                    if (localOffset + itemWidth < 0 || localOffset > listWidth)
                        Recycle(index);
                    else
                        UpdateNestedItem(datum, order++, localOffset, depth, ref doneSettling);

                    offset += itemWidth;

                    if (datum.children != null)
                    {
                        if (expanded)
                        {
                            m_UpdateStack.Push(new UpdateData
                            {
                                data = nestedData,
                                depth = depth,
                                index = i + 1
                            });

                            m_UpdateStack.Push(new UpdateData
                            {
                                data = datum.children,
                                depth = depth + 1
                            });
                            break;
                        }

                        RecycleChildren(datum);
                    }
                }
            }
        }

        /// <summary>
        /// Update a visible list item
        /// </summary>
        /// <param name="datum">The datum representing this list item</param>
        /// <param name="order">The order of this item, among the other visible items</param>
        /// <param name="offset">The offset at which to position this item</param>
        /// <param name="depth">The level of nesting</param>
        /// <param name="doneSettling">Whether all items are done settling</param>
        protected virtual void UpdateNestedItem(TData datum, int order, float offset, int depth, ref bool doneSettling)
        {
            UpdateVisibleItem(datum, order, offset, ref doneSettling);
        }

        /// <summary>
        /// Recycle the list items for all children of the given datum
        /// </summary>
        /// <param name="datum">The datum whose children to recycle</param>
        protected void RecycleChildren(TData datum)
        {
            var children = datum.children;
            foreach (var child in children)
            {
                Recycle(child.index);

                if (child.children != null)
                    RecycleChildren(child);
            }
        }

        /// <summary>
        /// Get the expanded state for the item at the given index
        /// </summary>
        /// <param name="index">The index for which to get the expanded state</param>
        /// <returns>The expanded state for the given index</returns>
        protected bool GetExpanded(TIndex index)
        {
            bool expanded;
            m_ExpandStates.TryGetValue(index, out expanded);
            return expanded;
        }

        /// <summary>
        /// Set the expanded state for the item at the given index
        /// </summary>
        /// <param name="index">The index for which to set the expanded state</param>
        /// <param name="expanded">The expanded state to set at the given index</param>
        protected void SetExpanded(TIndex index, bool expanded)
        {
            m_ExpandStates[index] = expanded;
            StartSettling();
        }

        /// <summary>
        /// Scroll the list to the item at the given index
        /// </summary>
        /// <param name="container">The container data within which to search</param>
        /// <param name="targetIndex">The index for which to search</param>
        /// <param name="scrollHeight">The offset to which the list will be scrolled</param>
        protected void ScrollToIndex(TData container, TIndex targetIndex, ref float scrollHeight)
        {
            var index = container.index;
            if (index.Equals(targetIndex))
            {
                if (-m_ScrollOffset > scrollHeight || -m_ScrollOffset + m_Size.z < scrollHeight)
                    m_ScrollOffset = -scrollHeight;

                return;
            }

            scrollHeight += m_ItemSize.z;

            if (GetExpanded(index))
            {
                var children = container.children;
                if (children != null)
                {
                    foreach (var child in children)
                    {
                        ScrollToIndex(child, targetIndex, ref scrollHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Get a view item for a given datum, either from its template's pool, or by creating a new one
        /// </summary>
        /// <param name="datum">The datum for the desired view item</param>
        /// <param name="item">The view item</param>
        /// <returns>True if a new item was instantiated, false if the view item came from the item pool</returns>
        protected override bool GetNewItem(TData datum, out TItem item)
        {
            var instantiated = base.GetNewItem(datum, out item);
            if (instantiated)
                item.toggleExpanded += m_ToggleExpanded;

            return instantiated;
        }

        /// <summary>
        /// Toggle the expanded state of the given datum
        /// </summary>
        /// <param name="datum">The datum whose expanded state will be toggled</param>
        protected virtual void ToggleExpanded(TData datum)
        {
            bool expanded;
            m_ExpandStates.TryGetValue(datum.index, out expanded);
            m_ExpandStates[datum.index] = !expanded;
            StartSettling();
        }
    }
}

using System;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Base class for components which can be added to GameObjects used as items in a nested list view
    /// </summary>
    /// <typeparam name="TData">The type of data backing each list item</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public abstract class NestedListViewItem<TData, TIndex> : ListViewItem<TData, TIndex>,
        INestedListViewItem<TData, TIndex> where TData : IListViewItemData<TIndex>
    {
        /// <summary>
        /// Invoked when ToggleExpanded is called
        /// </summary>
        public event Action<TData> toggleExpanded;

        /// <summary>
        /// Toggle the expanded state of this item
        /// </summary>
        public void ToggleExpanded()
        {
            if (toggleExpanded != null)
                toggleExpanded(data);
        }
    }
}

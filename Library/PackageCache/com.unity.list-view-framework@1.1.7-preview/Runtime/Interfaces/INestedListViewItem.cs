using System;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Implement to define view logic for a nested list view item
    /// </summary>
    public interface INestedListViewItem : IListViewItem
    {
        /// <summary>
        /// Toggle the expanded state of this item
        /// </summary>
        void ToggleExpanded();
    }

    /// <summary>
    /// Implement to define view logic for a nested list view item
    /// </summary>
    /// <typeparam name="TData">The type of data backing each list item</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public interface INestedListViewItem<TData, TIndex> : INestedListViewItem, IListViewItem<TData, TIndex>
        where TData : IListViewItemData<TIndex>
    {
        /// <summary>
        /// Invoked when ToggleExpanded is called
        /// </summary>
        event Action<TData> toggleExpanded;
    }
}

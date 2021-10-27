using System;
using System.Collections.Generic;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Implement to create data for a nested list view
    /// </summary>
    /// <typeparam name="TChild">The type of data in the list of children</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public interface INestedListViewItemData<TChild, TIndex> : IListViewItemData<TIndex>
    {
        /// <summary>
        /// The list of children
        /// </summary>
        List<TChild> children { get; }

        /// <summary>
        /// Invoked when setting the list of children
        /// </summary>
        event Action<INestedListViewItemData<TChild, TIndex>, List<TChild>> childrenChanging;
    }
}

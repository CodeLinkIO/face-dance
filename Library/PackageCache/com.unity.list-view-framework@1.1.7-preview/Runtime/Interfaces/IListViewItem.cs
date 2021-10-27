using System;
using UnityEngine;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Implement to define view logic for a list view item
    /// </summary>
    public interface IListViewItem
    {
        /// <summary>
        /// The local position of this list item
        /// </summary>
        Vector3 localPosition { get; set; }

        /// <summary>
        /// The local rotation of this list item
        /// </summary>
        Quaternion localRotation { get; set; }

        /// <summary>
        /// Called when this item starts settling
        /// Action argument is called when the item is done settling
        /// </summary>
        Action<Action> startSettling { set; }

        /// <summary>
        /// Called when this item is done settling
        /// </summary>
        Action endSettling { set; }

        /// <summary>
        /// Converts the List View Item into a multiselect mode, for use with combined actions
        /// </summary>
        bool multiSelectMode { get; set; }

        /// <summary>
        /// Set the active state of this list item
        /// </summary>
        /// <param name="active">The active state</param>
        void SetActive(bool active);

        /// <summary>
        /// Set the sibling index of this list item
        /// </summary>
        /// <param name="index">The sibling index</param>
        void SetSiblingIndex(int index);
    }

    /// <summary>
    /// Implement to define view logic for a list view item
    /// </summary>
    /// <typeparam name="TData">The type of data backing each list item</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public interface IListViewItem<TData, TIndex> : IListViewItem where TData : IListViewItemData<TIndex>
    {
        /// <summary>
        /// The data for this item
        /// </summary>
        TData data { get; set; }

        /// <summary>
        /// Called once when this list item becomes visible
        /// </summary>
        /// <param name="datum">The data backing this list item</param>
        /// <param name="firstTime">Whether this is the first time this item is being set up;
        /// This will be false when the item is re-used from the template pool</param>
        void Setup(TData datum, bool firstTime);
    }
}

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Implement to create data for a list view
    /// </summary>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public interface IListViewItemData<TIndex>
    {
        /// <summary>
        /// The index for this data
        /// </summary>
        TIndex index { get; }

        /// <summary>
        /// The template for this data
        /// </summary>
        string template { get; }

        /// <summary>
        /// True if the item is currently selected. Used by multiselect to track items.
        /// </summary>
        bool selected { get; }
    }
}

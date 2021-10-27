using System;
using System.Collections.Generic;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Base class for nested list view item data
    /// </summary>
    /// <typeparam name="TChild">The type of data in the list of children</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public abstract class NestedListViewItemData<TChild, TIndex> : INestedListViewItemData<TChild, TIndex>
    {
        /// <summary>
        /// The list of children
        /// </summary>
        protected List<TChild> m_Children;

        /// <summary>
        /// The index for this data
        /// </summary>
        public abstract TIndex index { get; }

        /// <summary>
        /// The template for this data
        /// </summary>
        public abstract string template { get; }

        /// <summary>
        /// True if the item is currently selected. Used by multiselect to track items.
        /// </summary>
        public virtual bool selected { get; set; }

        /// <summary>
        /// Invoked when setting the list of children
        /// </summary>
        public event Action<INestedListViewItemData<TChild, TIndex>, List<TChild>> childrenChanging;

        /// <summary>
        /// The list of children
        /// </summary>
        public List<TChild> children
        {
            get { return m_Children; }
            set
            {
                if (childrenChanging != null)
                    childrenChanging(this, value);

                m_Children = value;
            }
        }
    }
}

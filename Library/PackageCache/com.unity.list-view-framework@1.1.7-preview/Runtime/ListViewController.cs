using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Core class of the list view framework
    /// The list view controller and its variants provide a starting point for scrollable list views which update a set
    /// of visible items once per frame based on a list of data objects. Extensions of this class will determine behavior
    /// like whether to scroll vertically or horizontally, or whether to present list items in a grid.
    /// </summary>
    /// <typeparam name="TData">The type of object in the list of data</typeparam>
    /// <typeparam name="TItem">The base type of all list items</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public abstract class ListViewController<TData, TItem, TIndex> : ListViewControllerBase
        where TData : class, IListViewItemData<TIndex>
        where TItem : class, IListViewItem<TData, TIndex>
    {
        /// <summary>
        /// The list of data
        /// </summary>
        protected List<TData> m_Data;
        IListViewItem<TData, TIndex> m_LastUpdatedItemItem;

        /// <summary>
        /// A dictionary for providing constant-time access to ListViewItemTemplates based on the name of the template prefab
        /// </summary>
        protected readonly Dictionary<string, ListViewItemTemplate<TItem>> m_TemplateDictionary = new Dictionary<string, ListViewItemTemplate<TItem>>();

        /// <summary>
        /// The currently-visible list items
        /// </summary>
        protected readonly Dictionary<TIndex, TItem> m_ListItems = new Dictionary<TIndex, TItem>();

        /// <summary>
        /// Items which are currently "grabbed" and temporarily removed from the list
        /// </summary>
        protected readonly Dictionary<TIndex, Transform> m_GrabbedRows = new Dictionary<TIndex, Transform>();

        Action<Action> m_StartSettling;
        Action m_EndSettling;
        bool m_MultiSelectMode;

        /// <summary>
        /// The list of data
        /// </summary>
        public virtual List<TData> data
        {
            get { return m_Data; }
            set
            {
                foreach (var kvp in m_ListItems)
                {
                    var item = kvp.Value;
                    RecycleItem(item.data.template, item);
                }

                m_ListItems.Clear();

                m_Data = value;
                scrollOffset = 0;
            }
        }

        /// <summary>
        /// The total height of all list rows, used to determine the maximum amount of scroll offset before snapping back
        /// </summary>
        protected override float listHeight
        {
            get { return m_Data == null ? 0 : m_Data.Count * m_ItemSize.z; }
        }

        /// <summary>
        /// Converts the List View Item into a multiselect mode, for use with combined actions
        /// </summary>
        protected bool multiSelectMode { get => m_MultiSelectMode; set => SetMultiSelectMode(value); }

        /// <summary>
        /// Called when the script instance is being loaded
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_StartSettling = StartSettling;
            m_EndSettling = EndSettling;
        }

        /// <summary>
        /// Called on the frame when a script is enabled just before any of the Update methods are called the first time
        /// </summary>
        protected virtual void Start()
        {
            m_TemplateDictionary.Clear();
            if (m_Templates.Length < 1)
                Debug.LogError("No templates!");

            foreach (var template in m_Templates)
            {
                var templateName = template.name;
                if (m_TemplateDictionary.ContainsKey(templateName))
                    Debug.LogError("Two templates cannot have the same name");

                m_TemplateDictionary[templateName] = new ListViewItemTemplate<TItem>(template);
            }
        }

        /// <summary>
        /// Called by UpdateView to update the list items
        /// </summary>
        protected override void UpdateItems()
        {
            var doneSettling = true;

            var offset = 0f;
            var order = 0;
            var itemWidth = m_ItemSize.z;
            var listWidth = m_Size.z;
            var count = m_Data.Count;
            for (var i = 0; i < count; i++)
            {
                var datum = m_Data[i];
                var localOffset = offset + scrollOffset;
                if (localOffset + itemWidth < 0 || localOffset > listWidth)
                    Recycle(datum.index);
                else
                    UpdateVisibleItem(datum, order++, localOffset, ref doneSettling);

                offset += itemWidth;
            }

            if (m_Settling && doneSettling)
                EndSettling();
        }

        /// <summary>
        /// Recycle a list item by index
        /// </summary>
        /// <param name="index">The index of the list item to be recycled</param>
        protected virtual void Recycle(TIndex index)
        {
            if (m_GrabbedRows.ContainsKey(index))
                return;

            TItem item;
            if (m_ListItems.TryGetValue(index, out item))
            {
                RecycleItem(item.data.template, item);
                m_ListItems.Remove(index);
            }
        }

        /// <summary>
        /// Recycle a list item into its template's pool
        /// </summary>
        /// <param name="template">The template of this list item</param>
        /// <param name="item">The list item</param>
        protected virtual void RecycleItem(string template, TItem item)
        {
            if (item == null || template == null)
                return;

            m_TemplateDictionary[template].pool.Enqueue(item);
            item.SetActive(false);
        }

        /// <summary>
        /// Update a visible list item
        /// </summary>
        /// <param name="datum">The datum representing this list item</param>
        /// <param name="order">The order of this item, among the other visible items</param>
        /// <param name="offset">The offset at which to position this item</param>
        /// <param name="doneSettling">Whether all items are done settling</param>
        /// <returns>The item associated with this datum</returns>
        protected virtual TItem UpdateVisibleItem(TData datum, int order, float offset, ref bool doneSettling)
        {
            TItem item;
            var index = datum.index;
            if (!m_ListItems.TryGetValue(index, out item))
            {
                GetNewItem(datum, out item);
                var done = false;
                UpdateItem(item, order, offset, true, ref done);
            }

            m_LastUpdatedItemItem = item;
            UpdateItem(item, order, offset, false, ref doneSettling);

            return item;
        }

        /// <inheritdoc/>
        protected override void UpdateItem(IListViewItem item, int order, float offset, bool dontSettle, ref bool doneSettling)
        {
            base.UpdateItem(item, order, offset, dontSettle, ref doneSettling);
            item.multiSelectMode = multiSelectMode;
        }

        /// <summary>
        /// Set the grabbed state of the list item at a given index
        /// </summary>
        /// <param name="index">The index of the list item/data</param>
        /// <param name="rayOrigin">The ray origin used to grab this list item</param>
        /// <param name="grabbed">Whether the item is grabbed or not</param>
        protected virtual void SetRowGrabbed(TIndex index, Transform rayOrigin, bool grabbed)
        {
            if (grabbed)
                m_GrabbedRows[index] = rayOrigin;
            else
                m_GrabbedRows.Remove(index);
        }

        /// <summary>
        /// Get a list item grabbed by the given ray origin
        /// </summary>
        /// <param name="rayOrigin">The ray origin used to grab a list item</param>
        /// <returns>The item which is grabbed</returns>
        protected virtual TItem GetGrabbedRow(Transform rayOrigin)
        {
            foreach (var row in m_GrabbedRows)
            {
                if (row.Value == rayOrigin)
                    return GetListItem(row.Key);
            }

            return default(TItem);
        }

        /// <summary>
        /// Get the list item for a given index
        /// </summary>
        /// <param name="index">The index of the list item</param>
        /// <returns>The item, if one exists</returns>
        protected TItem GetListItem(TIndex index)
        {
            TItem item;
            return m_ListItems.TryGetValue(index, out item) ? item : default(TItem);
        }

        /// <summary>
        /// Get a view item for a given datum, either from its template's pool, or by creating a new one
        /// </summary>
        /// <param name="datum">The datum for the desired view item</param>
        /// <param name="item">The view item</param>
        /// <returns>True if a new item was instantiated, false if the view item came from the item pool</returns>
        protected virtual bool GetNewItem(TData datum, out TItem item)
        {
            if (datum == null)
            {
                Debug.LogWarning("Tried to get item with null datum");
                item = default(TItem);
                return false;
            }

            var templateName = datum.template;
            ListViewItemTemplate<TItem> template;
            if (!m_TemplateDictionary.TryGetValue(templateName, out template))
            {
                Debug.LogWarning(string.Format("Cannot get item, template {0} doesn't exist", templateName));
                item = default(TItem);
                return false;
            }

            var pool = template.pool;
            var pooled = pool.Count > 0;
            if (pooled)
            {
                item = pool.Dequeue();
                item.SetActive(true);
                item.Setup(datum, false);
            }
            else
            {
                item = InstantiateItem(datum);
                item.Setup(datum, true);
                item.startSettling = m_StartSettling;
                item.endSettling = m_EndSettling;
            }

            m_ListItems[datum.index] = item;

            if (m_LastUpdatedItemItem != null)
                item.localPosition = m_LastUpdatedItemItem.localPosition;

            return !pooled;
        }

        /// <summary>
        /// Instantiate the list item for a given datum
        /// </summary>
        /// <param name="datum">The datum for a list item</param>
        /// <returns>The instantiated list item</returns>
        protected virtual TItem InstantiateItem(TData datum)
        {
            return Instantiate(m_TemplateDictionary[datum.template].prefab, transform, false).GetComponent<TItem>();
        }

        /// <summary>
        /// Override and call base function to add custom behaviour when entering or exiting multiselect mode.
        /// </summary>
        /// <param name="mode">If true, multi-select is enabling, false otherwise.</param>
        protected virtual void SetMultiSelectMode(bool mode)
        {
            m_MultiSelectMode = mode;
        }

        /// <inheritdoc/>
        protected sealed override bool HasData()
        {
            return m_Data != null;
        }
    }
}

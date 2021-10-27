using System;
using UnityEngine;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Base class for components which can be added to GameObjects used as items in a list view
    /// </summary>
    /// <typeparam name="TData">The type of data backing each list item</typeparam>
    /// <typeparam name="TIndex">The type which is used as a unique index to map data to list items</typeparam>
    public abstract class ListViewItem<TData, TIndex> : MonoBehaviour, IListViewItem<TData, TIndex> where TData : IListViewItemData<TIndex>
    {
        Transform m_Transform;
        GameObject m_GameObject;

        /// <summary>
        /// The local position of this list item
        /// </summary>
        public Vector3 localPosition
        {
            get => m_Transform.localPosition;
            set => m_Transform.localPosition = value;
        }

        /// <summary>
        /// The local rotation of this list item
        /// </summary>
        public Quaternion localRotation
        {
            get => m_Transform.localRotation;
            set => m_Transform.localRotation = value;
        }

        /// <summary>
        /// Called when this item starts settling
        /// Action argument is called when the list item is done settling
        /// </summary>
        public Action<Action> startSettling { get; set; }

        /// <summary>
        /// Called when the list item is done settling
        /// </summary>
        public Action endSettling { get; set; }

        /// <summary>
        /// The data backing this list item
        /// </summary>
        public TData data { get; set; }

        /// <summary>
        /// Converts the List View Item into a multiselect mode, for use with combined actions
        /// </summary>
        public virtual bool multiSelectMode
        {
            get => false;
            set
            {
                if (value)
                    throw new NotSupportedException("This ListViewItem does not support multiple selection.");
            }
        }

        /// <summary>
        /// Set the active state of this list item
        /// </summary>
        /// <param name="active">The active state to set on this list item</param>
        public virtual void SetActive(bool active)
        {
            m_GameObject.SetActive(active);
        }

        /// <summary>
        /// Set the sibling index of this list item
        /// </summary>
        /// <param name="index">The sibling index</param>
        public void SetSiblingIndex(int index)
        {
            m_Transform.SetSiblingIndex(index);
        }

        /// <summary>
        /// Called once when this list item becomes visible
        /// </summary>
        /// <param name="datum">The data backing this list item</param>
        /// <param name="firstTime">Whether this is the first time this item is being set up;
        /// This will be false when the item is re-used from the template pool</param>
        public virtual void Setup(TData datum, bool firstTime = false)
        {
            data = datum;
            if (firstTime)
            {
                m_Transform = transform;
                m_GameObject = gameObject;
            }
        }
    }
}

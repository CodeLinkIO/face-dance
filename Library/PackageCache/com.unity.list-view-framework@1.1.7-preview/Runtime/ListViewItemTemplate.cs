using UnityEngine;
using System.Collections.Generic;

namespace Unity.ListViewFramework
{
    /// <summary>
    /// Used to store list item template prefabs and object pools
    /// </summary>
    /// <typeparam name="TItem">Type of list item being pooled</typeparam>
    public sealed class ListViewItemTemplate<TItem>
    {
        /// <summary>
        /// The prefab for this template
        /// </summary>
        public readonly GameObject prefab;

        /// <summary>
        /// Object pool for storing inactive instances for later re-use
        /// </summary>
        public readonly Queue<TItem> pool = new Queue<TItem>();

        /// <summary>
        /// Initialize a ListViewItemTemplate with a given prefab
        /// </summary>
        /// <param name="prefab">The prefab for the template</param>
        public ListViewItemTemplate(GameObject prefab)
        {
            if (prefab == null)
                Debug.LogError("Template prefab cannot be null");

            this.prefab = prefab;
        }
    }
}

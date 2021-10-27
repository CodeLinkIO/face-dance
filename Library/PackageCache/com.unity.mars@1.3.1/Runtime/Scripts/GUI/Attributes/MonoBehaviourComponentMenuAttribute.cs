using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Used to define the menu item and they type of MonoBehaviour component it will add.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public sealed class MonoBehaviourComponentMenuAttribute : ComponentMenuAttribute
    {
        /// <summary>
        /// Create an individual Menu item that is connected to MonoBehaviour component type.
        /// </summary>
        /// <param name="componentType">Type of MonoBehaviour component to add.</param>
        /// <param name="menuItem">Menu path for the item.</param>
        public MonoBehaviourComponentMenuAttribute(Type componentType, string menuItem)
            : base(componentType, menuItem) { }
    }
}

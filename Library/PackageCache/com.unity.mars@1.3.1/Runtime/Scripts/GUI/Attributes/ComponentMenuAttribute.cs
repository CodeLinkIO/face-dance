using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Used to define the menu item and the type of component it will add.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public abstract class ComponentMenuAttribute : Attribute
    {
        /// <summary>
        /// Type of component the menu will add.
        /// </summary>
        public readonly Type componentType;

        /// <summary>
        /// The menu item path.
        /// </summary>
        public readonly string menuItem;

        /// <summary>
        /// Create an individual Menu item that is connected to component type.
        /// </summary>
        /// <param name="componentType">Type of component to add.</param>
        /// <param name="menuItem">Menu path for the item.</param>
        protected ComponentMenuAttribute(Type componentType, string menuItem)
        {
            this.componentType = componentType;
            this.menuItem = menuItem;
        }
    }
}

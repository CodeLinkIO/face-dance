using System;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;
using Object = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Interface for object containing a component list. This is used to store component data on an object.
    /// </summary>
    /// <typeparam name="TObject">Type of component collection is to store</typeparam>
    public interface IComponentList<TObject> where TObject : Object
    {
        /// <summary>
        /// List of components this interface provides.
        /// </summary>
        List<TObject> components { get; }

        /// <summary>
        /// If the components list has been modified in a way that the list and objects that use the list need to be validated.
        /// </summary>
        bool isDirty { get; set; }

        /// <summary>
        /// Reference back to the object that implements the interface.
        /// </summary>
        Object self { get; }

        /// <summary>
        /// Does the Settings contain a item of type.
        /// </summary>
        /// <param name="type">Type of item to check if the components has.</param>
        /// <returns>True if components contains an item of type.</returns>
        bool HasComponents(Type type);
    }
}

using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Tells the component editor which run-time type the editor is for.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public class ComponentEditorAttribute : Attribute
    {
        /// <summary>
        /// The run-time type.
        /// </summary>
        public readonly Type ComponentType;

        /// <summary>
        /// If child classes of inspectedType will also show this editor.
        /// </summary>
        public readonly bool EditorForChildClasses;

        /// <summary>
        /// Tells the component editor which run-time type the editor is for.
        /// </summary>
        /// <param name="componentType">The run-time type.</param>
        /// <param name="editorForChildClasses">If true, child classes of inspectedType will also show this editor. Defaults to false.</param>
        public ComponentEditorAttribute(Type componentType, bool editorForChildClasses = false)
        {
            ComponentType = componentType;
            EditorForChildClasses = editorForChildClasses;
        }
    }
}

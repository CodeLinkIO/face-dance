using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Used to define the tooltip of a MARS Component.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public class ComponentTooltipAttribute : Attribute
    {
        /// <summary>
        /// The tooltip to be displayed with the class label.
        /// </summary>
        public readonly string tooltip;

        public ComponentTooltipAttribute(string tooltip) { this.tooltip = tooltip; }
    }
}

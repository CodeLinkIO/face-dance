using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Attribute used to set a custom display name in a property decorator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [MovedFrom("Unity.MARS")]
    public sealed class DisplayNameAttribute : Attribute
    {
        /// <summary>
        /// The display name to be used in a property decorator.
        /// </summary>
        public readonly string displayName;

        /// <summary>
        /// Attribute used to set a custom display name in a property decorator.
        /// </summary>
        /// <param name="displayName">The display name to be used in a property decorator.</param>
        public DisplayNameAttribute(string displayName)
        {
            this.displayName = displayName;
        }
    }
}

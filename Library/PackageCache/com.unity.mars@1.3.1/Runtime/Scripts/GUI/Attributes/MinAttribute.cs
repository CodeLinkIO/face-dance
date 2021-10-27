using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Attribute used to clamp a float or in variable to a min value in a property decorator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [MovedFrom("Unity.MARS")]
    public sealed class MinAttribute : Attribute
    {
        /// <summary>
        /// Min value that can be set in a property decorator.
        /// </summary>
        public float min;

        /// <summary>
        /// Attribute used to clamp a float or in variable to a min value in a property decorator.
        /// </summary>
        /// <param name="min">Min value that can be set in a property decorator.</param>
        public MinAttribute(float min)
        {
            this.min = min;
        }
    }
}

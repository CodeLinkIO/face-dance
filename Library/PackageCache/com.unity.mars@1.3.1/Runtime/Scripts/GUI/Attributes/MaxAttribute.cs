using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Attribute used to clamp a float or in variable to a max value in a property decorator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [MovedFrom("Unity.MARS")]
    public sealed class MaxAttribute : Attribute
    {
        /// <summary>
        /// Max value that can be set in a property decorator.
        /// </summary>
        public float max;

        /// <summary>
        /// Attribute used to clamp a float or in variable to a max value in a property decorator.
        /// </summary>
        /// <param name="max">Max value that can be set in a property decorator.</param>
        public MaxAttribute(float max)
        {
            this.max = max;
        }
    }
}

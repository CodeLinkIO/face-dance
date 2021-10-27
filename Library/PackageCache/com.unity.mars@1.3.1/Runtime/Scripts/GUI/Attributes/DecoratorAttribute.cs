using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Used for Drawing custom decorator property drawers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public sealed class DecoratorAttribute : Attribute
    {
        /// <summary>
        /// Type of attribute decorator is being applied to.
        /// </summary>
        public readonly Type attributeType;

        /// <summary>
        /// Used for Drawing custom decorator property drawers.
        /// </summary>
        /// <param name="attributeType"></param>
        public DecoratorAttribute(Type attributeType)
        {
            this.attributeType = attributeType;
        }
    }
}

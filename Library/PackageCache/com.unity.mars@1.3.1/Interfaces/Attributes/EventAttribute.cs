using System;

namespace Unity.MARS.Attributes
{
    /// <summary>
    /// Used to decorate event fields for advanced inspectors
    /// </summary>
    public sealed class EventAttribute : Attribute
    {
        /// <summary>
        /// The field type
        /// </summary>
        public readonly Type type;

        /// <summary>
        /// Initialize a new EventAttribute
        /// </summary>
        /// <param name="type">The type of the decorated field</param>
        public EventAttribute(Type type)
        {
            this.type = type;
        }
    }
}

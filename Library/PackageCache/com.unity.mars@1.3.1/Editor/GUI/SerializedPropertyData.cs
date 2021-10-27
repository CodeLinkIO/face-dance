using System;
using System.Linq;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Container class that holds a `SerializedProperty` together with its `Attribute`(s).
    /// Used to easily get and modify the attribute in an editor.
    /// </summary>
    // Related to SerializedParameterOverride in PostProcessing
    [MovedFrom("Unity.MARS")]
    public sealed class SerializedPropertyData
    {
        /// <summary>
        /// The serialized property stored in the parameter.
        /// </summary>
        public SerializedProperty Value { get; private set; }
        /// <summary>
        /// The attributes of the property.
        /// </summary>
        public Attribute[] Attributes { get; private set; }
        /// <summary>
        ///  Value type of serialized property.
        /// </summary>
        public Type Type { get; private set; }
        /// <summary>
        /// The display name of the serialized property value.
        /// </summary>
        public string DisplayName
        {
            get { return Value.displayName; }
        }

        /// <summary>
        /// Creates a Serialized Parameter with the Serialized property at it's current iterator state.
        /// </summary>
        /// <param name="property">SerializedProperty value to store.</param>
        /// <param name="type">Value type of serialized property.</param>
        /// <param name="attributes">The attributes of the property being stored.</param>
        public SerializedPropertyData(SerializedProperty property, Type type, Attribute[] attributes)
        {
            Value = property.Copy();
            Attributes = attributes;
            Type = type;
        }

        SerializedPropertyData(SerializedPropertyData propertyData)
        {
            Value = propertyData.Value.Copy();
            Attributes = propertyData.Attributes.ToArray();
            Type = propertyData.Type;
        }

        /// <summary>
        /// Returns a copy of the SerializedParameter with the SerializedProperty in it's current iterator state.
        /// </summary>
        /// <returns></returns>
        public SerializedPropertyData Copy()
        {
            return new SerializedPropertyData(this);
        }

        /// <summary>
        /// Adds an attribute to the `Attributes` array.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute to be added</typeparam>
        /// <param name="attribute">Attribute to add to the `Attributes` array.</param>
        public void AddAttribute<TAttribute>(TAttribute attribute) where TAttribute : Attribute
        {
            var attributeList = Attributes.ToList();
            attributeList.Add(attribute);
            Attributes = attributeList.ToArray();
        }

        /// <summary>
        /// Returns the first instance of the attribute type in the `Attributes` array.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns>First attribute of type in the `Attributes` array, null if no attribute.</returns>
        public TAttribute GetAttribute<TAttribute>()
            where TAttribute : Attribute
        {
            return (TAttribute)Attributes.FirstOrDefault(x => x is TAttribute);
        }
    }
}

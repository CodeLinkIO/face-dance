using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.XRTools.Utils.GUI
{
    [CustomPropertyDrawer(typeof(FlagsPropertyAttribute))]
    sealed class FlagsPropertyDrawer : PropertyDrawer
    {
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<string> k_ValidEnumNames = new List<string>();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var type = EditorUtils.SerializedPropertyToType(property);
            k_ValidEnumNames.Clear();
            var names = property.enumNames;
            var length = names.Length;
            var values = (int[])Enum.GetValues(type);
            for (var i = 0; i < length; i++)
            {
                if (MathUtility.IsPositivePowerOfTwo(values[i]))
                    k_ValidEnumNames.Add(names[i]);
            }

            property.intValue = EditorUtils.MaskField(position, label, property.intValue, k_ValidEnumNames.ToArray(), type);
        }
    }
}

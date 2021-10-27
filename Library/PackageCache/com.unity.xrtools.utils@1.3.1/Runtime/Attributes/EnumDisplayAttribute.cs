using System;
using UnityEngine;

namespace Unity.XRTools.Utils.GUI
{
    /// <inheritdoc />
    /// <summary>
    /// Used with a special property drawer that can limit which enum options are displayed
    /// </summary>
    public sealed class EnumDisplayAttribute : PropertyAttribute
    {
        /// <summary>
        /// The names of the enum values used to initialize this attribute
        /// </summary>
        public string[] names;

        /// <summary>
        /// The int values of the enum values used to initialize this attribute
        /// </summary>
        public int[] values;

        /// <summary>
        /// Initialize a new EnumDisplayAttribute
        /// </summary>
        /// <param name="enumValues">The enum values which should be displayed</param>
        public EnumDisplayAttribute(params object[] enumValues)
        {
            names = new string[enumValues.Length];
            values = new int[enumValues.Length];

            var valueCounter = 0;
            while (valueCounter < values.Length)
            {
                var asEnum = enumValues[valueCounter] as Enum;

                if (asEnum == null)
                {
                    Debug.LogErrorFormat("Not-enum passed into EnumDisplay Attribute: {0}", enumValues[valueCounter]);
                    continue;
                }

                names[valueCounter] = asEnum.ToString();
                values[valueCounter] = Convert.ToInt32(asEnum);
                valueCounter++;
            }
        }
    }
}

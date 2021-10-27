using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Defines an identifiable piece of an object. The definition includes a name, the acceptable output type (types that inherit from ILandmarkOutput)
    /// and an option settings type (type that inherits from ILandmarkSettings).
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class LandmarkDefinition
    {
        public string name;
        public Type[] outputTypes;
        public Type settingsType;

        /// <summary>
        /// Create a definition with a single output type
        /// </summary>
        /// <param name="name">The landmark name. </param>
        /// <param name="outputType">The output type. </param>
        /// <param name="settingsType">The settings type, defaults to none if not specified. </param>
        public LandmarkDefinition(string name, Type outputType, Type settingsType = null)
        {
            this.name = name;
            outputTypes = new [] { outputType };
            this.settingsType = settingsType;
        }

        /// <summary>
        /// Create a definition with multiple types of outputs
        /// </summary>
        /// <param name="name">The landmark name. </param>
        /// <param name="outputTypes">The output types. </param>
        /// <param name="settingsType">The settings type, defaults to none if not specified. </param>
        public LandmarkDefinition(string name, Type[] outputTypes, Type settingsType = null)
        {
            this.name = name;
            this.outputTypes = outputTypes;
            this.settingsType = settingsType;
        }

        /// <summary>
        /// Gets the name of a landmark parsed into a certain enum type
        /// </summary>
        /// <param name="ignoreCase"> Whether case should be ignored (default it true) </param>
        /// <typeparam name="TEnum"> The enum type </typeparam>
        /// <returns> The name as the given enum type </returns>
        public TEnum GetEnumName<TEnum>(bool ignoreCase = true) where TEnum : struct
        {
            TEnum enumOut;
            Enum.TryParse(name, ignoreCase, out enumOut);
            return enumOut;
        }
    }
}

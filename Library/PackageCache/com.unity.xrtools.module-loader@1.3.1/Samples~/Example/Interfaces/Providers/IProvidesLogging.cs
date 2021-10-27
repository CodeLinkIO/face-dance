using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    /// <summary>
    /// Provide the ability to log information to the console
    /// </summary>
    public interface IProvidesLogging : IFunctionalityProvider
    {
        /// <summary>
        /// Log a string representation of an object to the console
        /// </summary>
        /// <param name="obj">The object to be converted to a string and logged</param>
        void Log(object obj);
    }
}

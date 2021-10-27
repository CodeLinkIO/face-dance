using System;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Suggests the order for this module in the list of build callback modules
    /// This affects the order in which build callbacks are called
    /// </summary>
    public class ModuleBuildCallbackOrderAttribute : ModuleOrderAttribute
    {
        /// <summary>
        /// Initializes a new instance of ModuleBuildCallbackOrderAttribute
        /// </summary>
        /// <param name="order">The sorting order for when this module should respond to build callbacks</param>
        public ModuleBuildCallbackOrderAttribute(int order) : base (order) { }
    }
}

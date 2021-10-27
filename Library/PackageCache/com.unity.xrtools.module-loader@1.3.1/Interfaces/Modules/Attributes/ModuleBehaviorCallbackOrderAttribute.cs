using System;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Suggests the order for this module in the list of update modules
    /// This affects the order in which update is called
    /// </summary>
    public class ModuleBehaviorCallbackOrderAttribute : ModuleOrderAttribute
    {
        /// <summary>
        /// Initializes a new instance of ModuleBehaviorCallbackOrderAttribute
        /// </summary>
        /// <param name="order">The sorting order for when this module should respond to behavior callbacks</param>
        public ModuleBehaviorCallbackOrderAttribute(int order) : base(order) { }
    }
}

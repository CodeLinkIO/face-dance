using System;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Suggests the order for this module in the list of scene callback modules
    /// This affects the order in which scene callbacks are called
    /// </summary>
    public class ModuleSceneCallbackOrderAttribute : ModuleOrderAttribute
    {
        /// <summary>
        /// Initializes a new instance of ModuleSceneCallbackOrderAttribute
        /// </summary>
        /// <param name="order">The sorting order for when this module should respond to scene callbacks</param>
        public ModuleSceneCallbackOrderAttribute(int order) : base(order) { }
    }
}

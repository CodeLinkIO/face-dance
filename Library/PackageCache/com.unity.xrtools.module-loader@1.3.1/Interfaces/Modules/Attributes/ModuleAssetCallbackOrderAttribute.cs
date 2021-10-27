using System;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Suggests the order for this module in the list of asset callback modules
    /// This affects the order in which asset callbacks are called
    /// </summary>
    public class ModuleAssetCallbackOrderAttribute : ModuleOrderAttribute
    {
        /// <summary>
        /// Initializes a new instance of ModuleAssetCallbackOrderAttribute
        /// </summary>
        /// <param name="order">The sorting order for when this module should respond to asset callbacks</param>
        public ModuleAssetCallbackOrderAttribute(int order) : base(order) { }
    }
}

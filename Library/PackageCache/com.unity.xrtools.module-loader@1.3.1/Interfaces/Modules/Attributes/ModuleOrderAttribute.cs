using System;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Specifies the order for this module in the list of all modules
    /// This affects the order in which Load and ConnectDependency are called, and the order of modules in `ModuleLoaderCore.modules`
    /// </summary>
    public class ModuleOrderAttribute : Attribute
    {
        /// <summary>
        /// The sorting order for when this module should be loaded (or respond to callbacks in extensions of this attribute)
        /// </summary>
        public int order { get; private set; }

        /// <summary>
        /// Initializes a new instance of ModuleOrderAttribute
        /// </summary>
        /// <param name="order">The sorting order for when this module should be loaded (or respond to callbacks in extensions of this attribute)</param>
        public ModuleOrderAttribute(int order)
        {
            this.order = order;
        }
    }
}

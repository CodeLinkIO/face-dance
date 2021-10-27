namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Suggests the order for this module during unloading
    /// </summary>
    public class ModuleUnloadOrderAttribute : ModuleOrderAttribute
    {
        /// <summary>
        /// Initializes a new instance of ModuleUnloadOrderAttribute
        /// </summary>
        /// <param name="order">The sorting order for when this module should be unloaded</param>
        public ModuleUnloadOrderAttribute(int order) : base (order) { }
    }
}

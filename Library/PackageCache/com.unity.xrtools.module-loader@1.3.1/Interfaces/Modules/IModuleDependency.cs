using UnityEngine.Scripting;

namespace Unity.XRTools.ModuleLoader
{
    /// <inheritdoc />
    /// <summary>
    /// Provides access to another module
    /// </summary>
    /// <typeparam name="T">The type of module provided</typeparam>
    public interface IModuleDependency<in T> : IModule where T : IModule
    {
        /// <summary>
        /// Called by the system after all modules are instantiated if a module of the right type exists
        /// </summary>
        /// <param name="dependency">The provided module</param>
        [Preserve]
        void ConnectDependency(T dependency);
    }
}

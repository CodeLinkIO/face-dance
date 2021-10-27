using Unity.XRTools.ModuleLoader;

namespace Unity.MARS
{
    /// <summary>
    /// Define this module as one that needs MARS lifecycle update callbacks
    /// </summary>
    public interface IModuleMarsUpdate : IModule
    {
        /// <summary>
        /// Called at fixed intervals while the MARS lifecycle is running
        /// </summary>
        void OnMarsUpdate();
    }
}

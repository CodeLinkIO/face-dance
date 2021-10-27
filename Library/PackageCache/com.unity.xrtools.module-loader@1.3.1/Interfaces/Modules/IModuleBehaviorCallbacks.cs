namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Define this module as one that needs behavior callbacks
    /// These methods provide entry points for scene load and unload operations during MonoBehaviour callback phases,
    /// i.e. using capabilities to create required providers
    /// These methods are called by methods in ModuleLoaderCore of the same name on all modules, in the order specified
    /// by their `ModuleBehaviorCallbackOrderAttribute`. The recommended setup is to include a `ModuleCallbacksBehaviour`
    /// in the scene which may optionally run in edit mode to provide MonoBehaviour callbacks in edit mode. The
    /// `ExecutionOrderSetter` class ensures that `ModuleCallbacksBehaviour` has a very low execution order so that
    /// these methods are called on modules before other MonoBehaviours in the scene. Some projects may need to tie
    /// these updates to an existing MonoBehaviour or provide an alternative entry point for these methods.
    /// </summary>
    public interface IModuleBehaviorCallbacks : IModule
    {
        /// <summary>
        /// Called by ModuleLoaderCore Awake as early as possible (using a very low Script Execution Order)
        /// </summary>
        void OnBehaviorAwake();

        /// <summary>
        /// Called by ModuleLoaderCore OnEnable as early as possible (using a very low Script Execution Order)
        /// </summary>
        void OnBehaviorEnable();

        /// <summary>
        /// Called by ModuleLoaderCore Start as early as possible (using a very low Script Execution Order)
        /// </summary>
        void OnBehaviorStart();

        /// <summary>
        /// Called by ModuleLoaderCore Update as early as possible (using a very low Script Execution Order)
        /// </summary>
        void OnBehaviorUpdate();

        /// <summary>
        /// Called by ModuleLoaderCore OnDisable as early as possible (using a very low Script Execution Order)
        /// </summary>
        void OnBehaviorDisable();

        /// <summary>
        /// Called by ModuleLoaderCore OnDestroy as early as possible (using a very low Script Execution Order)
        /// </summary>
        void OnBehaviorDestroy();
    }
}

using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    // Use this attribute to control loading order
    // ReSharper disable once ClassNeverInstantiated.Global
    [ModuleOrder(0)]
    class VanillaModule : IModule
    {
        void IModule.LoadModule()
        {
            // We would normally use a module dependency but to keep this class simple, we just use the Settings Module instance directly
            if (SettingsModule.instance.logging)
                Debug.Log("VanillaModule loaded");
        }

        void IModule.UnloadModule()
        {
            if (SettingsModule.instance.logging)
                Debug.Log("VanillaModule unloaded");
        }
    }
}

using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    // ReSharper disable once UnusedType.Global
    [ModuleOrder(1)]
    class DependentModule : IModuleDependency<SettingsModule>, IModuleDependency<VanillaModule>
    {
        VanillaModule m_Vanilla;
        SettingsModule m_SettingsModule;

        void IModuleDependency<VanillaModule>.ConnectDependency(VanillaModule dependency)
        {
            m_Vanilla = dependency;
            if (m_SettingsModule.logging)
                Debug.LogFormat("Connecting Dependency Module with {0}", dependency);
        }

        void IModuleDependency<SettingsModule>.ConnectDependency(SettingsModule dependency)
        {
            m_SettingsModule = dependency;
        }

        void IModule.LoadModule()
        {
            if (m_SettingsModule.logging)
                Debug.LogFormat("DependentModule loaded with {0}", m_Vanilla);
        }

        void IModule.UnloadModule()
        {
            if (m_SettingsModule.logging)
                Debug.LogFormat("DependentModule unloaded with {0}", m_Vanilla);
        }
    }
}

using Unity.XRTools.ModuleLoader;
using Unity.XRTools.ModuleLoader.Example;
using UnityEngine;

namespace UnityEditor.XRTools.ModuleLoader.Example
{
    // Some modules only need to exist in the editor assembly
    // ReSharper disable once UnusedMember.Global
    class EditorModule : IModuleDependency<SettingsModule>
    {
        SettingsModule m_SettingsModule;

        void IModuleDependency<SettingsModule>.ConnectDependency(SettingsModule dependency)
        {
            m_SettingsModule = dependency;
        }

        void IModule.LoadModule()
        {
            if (m_SettingsModule.logging)
                Debug.Log("EditorModule loaded");
        }

        void IModule.UnloadModule()
        {
            if (m_SettingsModule.logging)
                Debug.Log("EditorModule unloaded");
        }
    }
}

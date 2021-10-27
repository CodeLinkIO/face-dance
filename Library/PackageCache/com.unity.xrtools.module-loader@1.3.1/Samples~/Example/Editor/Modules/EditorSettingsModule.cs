using Unity.XRTools.ModuleLoader;
using Unity.XRTools.ModuleLoader.Example;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace UnityEditor.XRTools.ModuleLoader.Example
{
    // Some editor modules want serialized settings--but we don't want these assets to go into builds!
    [ScriptableSettingsPath(SettingsModule.SettingsPath)]
    class EditorSettingsModule : EditorScriptableSettings<EditorSettingsModule>, IModuleDependency<SettingsModule>
    {
        [SerializeField]
        int m_Setting = 1337;

        SettingsModule m_SettingsModule;

        void IModuleDependency<SettingsModule>.ConnectDependency(SettingsModule dependency)
        {
            m_SettingsModule = dependency;
        }

        void IModule.LoadModule()
        {
            if (m_SettingsModule.logging)
                Debug.LogFormat("Editor Settings Module loaded. Setting is: {0}", m_Setting);
        }

        void IModule.UnloadModule()
        {
            if (m_SettingsModule.logging)
                Debug.LogFormat("Editor Settings Module unloaded. Setting is: {0}", m_Setting);
        }
    }
}

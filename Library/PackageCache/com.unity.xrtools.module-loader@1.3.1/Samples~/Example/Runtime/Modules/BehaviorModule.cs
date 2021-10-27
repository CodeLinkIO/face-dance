using UnityEngine;

namespace Unity.XRTools.ModuleLoader.Example
{
    class BehaviorModule : MonoBehaviour, IModuleDependency<SettingsModule>
    {
        SettingsModule m_SettingsModule;

        void IModuleDependency<SettingsModule>.ConnectDependency(SettingsModule dependency)
        {
            m_SettingsModule = dependency;
        }

        void Awake()
        {
            // We don't see this method called with default HideAndDontSave HideFlags
            if (m_SettingsModule.logging)
                Debug.Log("BehaviorModule Awake");
        }

        void Update()
        {
            if (m_SettingsModule.logging)
                Debug.Log("BehaviorModule Update");
        }

        void OnDestroy()
        {
            // We don't see this method called with default HideAndDontSave HideFlags
            if (m_SettingsModule.logging)
                Debug.Log("BehaviorModule OnDestroy");
        }

        void IModule.LoadModule()
        {
            if (m_SettingsModule.logging)
                Debug.Log("BehaviorModule loaded");
        }

        void IModule.UnloadModule()
        {
            if (m_SettingsModule.logging)
                Debug.Log("BehaviorModule unloaded");
        }
    }
}

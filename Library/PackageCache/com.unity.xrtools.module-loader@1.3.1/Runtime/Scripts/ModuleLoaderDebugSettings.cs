using System;
using Unity.XRTools.Utils;
using Unity.XRTools.Utils.GUI;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// ScriptableSettings class for storing debug settings for Module Loader
    /// </summary>
    [ScriptableSettingsPath(ModuleLoaderCore.UserSettingsFolder)]
    public class ModuleLoaderDebugSettings : ScriptableSettings<ModuleLoaderDebugSettings>
    {
#pragma warning disable 649
        [Tooltip("Write information about functionality injection to the console")]
        [SerializeField]
        bool m_FunctionalityInjectionModuleLogging;

        [Tooltip("The set of hideflags which will be applied to instances of MonoBehaviour modules")]
        [FlagsProperty]
        [SerializeField]
        HideFlags m_ModuleHideFlags = HideFlags.HideAndDontSave;

        [Tooltip("Override the current platform to test provider selection in playmode")]
        [SerializeField]
        bool m_OverridePlatformInPlaymode;

        [Tooltip("If enabled, use this platform to decide what providers are excluded in playmode")]
        [SerializeField]
        RuntimePlatform m_PlaymodePlatformOverride;
#pragma warning restore 649

        /// <summary>
        /// True if debug information regarding functionality injection should be logged
        /// </summary>
        public bool functionalityInjectionModuleLogging { get { return m_FunctionalityInjectionModuleLogging; } }

        /// <summary>
        /// Hideflags which will be applied to GameObjects which are created to support MonoBehaviour modules
        /// </summary>
        public HideFlags moduleHideFlags { get { return m_ModuleHideFlags; } }

        internal bool overridePlatformInPlaymode { get { return m_OverridePlatformInPlaymode; } }
        internal RuntimePlatform playmodePlatformOverride { get { return m_PlaymodePlatformOverride; } }

        void OnValidate()
        {
            if ((m_ModuleHideFlags | HideFlags.DontSave) != m_ModuleHideFlags)
                Debug.LogWarning("You must have at least HideFlags.DontSave in module hide flags");

            m_ModuleHideFlags |= HideFlags.DontSave;
        }

        /// <summary>
        /// Change the ModuleHideFlags setting, which controls HideFlags for GameObjects used to support MonoBehaviour
        /// modules. Calling this method will change the HideFlags on existing modules
        /// </summary>
        /// <param name="newHideFlags">The new HideFlags value</param>
        public void SetModuleHideFlags(HideFlags newHideFlags)
        {
            m_ModuleHideFlags = newHideFlags;
            ModuleLoaderCore.instance.GetModuleParent().hideFlags = newHideFlags;
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
}

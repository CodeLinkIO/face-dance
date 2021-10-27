using System.Reflection;
using Unity.MARS.MARSUtils;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor.MARS
{
    class MarsEditorBackend : IModule
    {
        const string k_PresetMismatch = "Preset Mismatch: Cannot build player because scenes {0} and {1} have mismatching build presets";

        static readonly MethodInfo k_PlayerSettingsGetSerializedObject =
            typeof(PlayerSettings).GetMethod("GetSerializedObject", BindingFlags.NonPublic | BindingFlags.Static);

        void IModule.LoadModule()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
            EditorSceneManager.sceneSaving += OnSceneSaving;
            EditorSceneManager.sceneSaved += OnSceneSaved;
            PrefabStage.prefabSaving += OnPrefabSaving;
        }

        static void OnPlayModeStateChanged(PlayModeStateChange stateChange)
        {
            if (stateChange != PlayModeStateChange.ExitingEditMode)
                return;

            // TODO: What to do about dirtying the scene when you enter play mode?
            // Update current scene info in case capabilities have changed
            var session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (session == null)
                return;

            session.CheckCapabilities();
        }

        void IModule.UnloadModule()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorSceneManager.sceneSaving -= OnSceneSaving;
            PrefabStage.prefabSaving -= OnPrefabSaving;
        }

        static void OnSceneSaving(Scene scene, string path)
        {
            // Creating a new scene can trigger this callback with an invalid scene
            if (!scene.IsValid())
                return;

            // Hide the OnDestroyNotifier so it is not saved
            foreach (var root in scene.GetRootGameObjects())
            {
                var notifier = root.GetComponentInChildren<OnDestroyNotifier>();
                if (notifier != null)
                    notifier.gameObject.hideFlags = HideFlags.HideAndDontSave;
            }

            var session = MarsRuntimeUtils.GetMarsSessionInScene(scene);
            if (session)
                session.CheckCapabilities();
        }

        static void OnSceneSaved(Scene scene)
        {
            if (!scene.IsValid())
                return;

            // Restore OnDestroyNotifier HideFlags so that it is discoverable
            foreach (var root in scene.GetRootGameObjects())
            {
                var notifier = root.GetComponentInChildren<OnDestroyNotifier>();
                if (notifier != null)
                    notifier.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }
        }

        static void OnPrefabSaving(GameObject prefab)
        {
            var environmentSettings = prefab.GetComponent<MARSEnvironmentSettings>();
            if (environmentSettings != null)
                environmentSettings.UpdatePrefabInfo();
        }
    }
}

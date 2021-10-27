using System;
using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.MARSUtils
{
    /// <summary>
    /// Utility methods for the MARS Runtime
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class MarsRuntimeUtils
    {
        static Scene s_CachedScene;
        static MARSSession s_CachedSession;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<MonoBehaviour> k_Behaviors = new List<MonoBehaviour>();

        internal static Func<Camera> TryGetActiveCamera { private get; set; }

        /// <summary>
        /// Returns the first MarsSession found in the active scene
        /// </summary>
        /// <returns>The first MarsSession found in the active scene, or null if none exists</returns>
        public static MARSSession GetMarsSessionInActiveScene()
        {
            return GetMarsSessionInScene(SceneManager.GetActiveScene());
        }

        /// <summary>
        /// Returns the first MarsSession found in the given scene
        /// </summary>
        /// <param name="scene">The scene to search</param>
        /// <returns>The first MarsSession found in the given scene, or null if none exists</returns>
        public static MARSSession GetMarsSessionInScene(Scene scene)
        {
            if (s_CachedScene == scene && s_CachedSession != null)
                return s_CachedSession;

            if (s_CachedScene != scene || s_CachedSession == null)
            {
                foreach (var root in scene.GetRootGameObjects())
                {
                    var session = root.GetComponentInChildren<MARSSession>();
                    if (session != null)
                    {
                        s_CachedScene = scene;
                        s_CachedSession = session;
                        return session;
                    }
                }
            }

            s_CachedScene = default;
            s_CachedSession = null;
            return null;
        }

        /// <summary>
        /// If simulating in edit mode, returns the simulated camera else
        /// returns the camera associated to the MarsSession through the MarsCamera camera reference.
        /// </summary>
        /// <param name="findFallbackCamera">If the active session camera is null,
        /// then it will try and return the main camera and if that is null will find a Camera object.</param>
        /// <returns>The active mars camera.</returns>
        public static Camera GetActiveCamera(bool findFallbackCamera = false)
        {
            if (TryGetActiveCamera != null)
            {
                var activeMarsCamera = TryGetActiveCamera();
                if (activeMarsCamera != null)
                    return activeMarsCamera;
            }

            return findFallbackCamera ? GetBestCameraFallback() : null;
        }

        /// <summary>
        /// Returns the camera associated to the MARS Session through the MarsCamera camera reference.
        /// </summary>
        /// <param name="findFallbackCamera">If the active session camera is null,
        /// then it will try and return the main camera and if that is null will find a Camera object.</param>
        /// <returns>The camera associated with the MARS Session</returns>
        public static Camera GetSessionAssociatedCamera(bool findFallbackCamera = false)
        {
            var session = MARSSession.Instance;
            if (session == null)
                session = GetMarsSessionInActiveScene();

            if (session != null)
                return session.TryGetSessionCamera();

            return findFallbackCamera ? GetBestCameraFallback() : null;
        }

        static Camera GetBestCameraFallback()
        {
            var main = Camera.main;
            return main != null ? main : UnityObject.FindObjectOfType<Camera>();
        }

        /// <summary>
        /// Checks if the given scene contains any MARS behaviors
        /// </summary>
        /// <param name="scene">The scene to check</param>
        /// <returns>True if the scene has any MARS behaviors, false otherwise</returns>
        public static bool HasMarsBehaviors(Scene scene)
        {
            k_Behaviors.Clear();
            GameObjectUtils.GetComponentsInScene(scene, k_Behaviors, true);
            foreach (var behavior in k_Behaviors)
            {
                if (behavior == null)
                    continue;

                if ((behavior.gameObject.hideFlags & HideFlags.DontSave) != 0)
                    continue;

                if (behavior is MARSEntity || behavior is IFunctionalitySubscriber)
                    return true;
            }

            return false;
        }
    }
}

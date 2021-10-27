#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Unity.MARS.Recording;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.MARSUtils
{
    [MovedFrom("Unity.MARS")]
    public static class EditorOnlyDelegates
    {
        internal static Func<GameObject, bool> IsEnvironmentPrefab { get; set; }
        internal static Func<GameObject> GetSimulatedContentRoot { get; set; }
        internal static Func<GameObject> GetSimulatedEnvironmentRoot { get; set; }
        internal static Func<Scene> GetSimulatedContentScene { get; set; }
        internal static Func<Scene> GetSimulatedEnvironmentScene { get; set; }
        internal static Action<Scene> CullEnvironmentFromSceneLights { get; set; }
        internal static Func<RecordedSessionDirector> GetCurrentRecordingDirector { get; set; }
        public static Action<List<Camera>> GetAllSimulationSceneCameras { get; set; }
        public static Func<bool> IsEnvironmentSetup { get; set; }
        public static Action<bool> SwitchToNextEnvironment { get; set; }
        public static Action OpenSimulationScene { get; set; }
        public static Action<Transform, Transform> AddSpawnedTransformToSimulationManager { get; set; }
        public static Action<ISimulatable, ISimulatable> AddSpawnedSimulatableToSimulationManager { get; set; }
        public static Func<Camera, bool> IsGizmosCamera { get; set; }
        public static Action DirtySimulatableScene { get; set; }
        public static Func<bool> IsSimulatingTemporal { get; set; }
        public static Func<bool,bool> IsEntitled { get; set; }
        public static Func<bool, bool> PerformCameraPermissionCheck { get; set; }

        /// <summary>
        /// Get the root GameObject for GameObjects in the simulated content scene that were copied from the active scene
        /// </summary>
        public static Func<GameObject> GetSimulatedObjectsRoot { get; set; }

#if INCLUDE_XR_MOCK
        public static Func<bool> IsRemoteActive { get; set; }
#endif
    }
}
#endif

using System;
using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using Unity.XRTools.Utils;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor.MARS.Simulation
{
    public partial class SimulationSceneModule
    {
        //Adapted from PreviewRenderUtility.cs PreviewScene
        class SimulationScene : IDisposable
        {
            const string k_SimulatedContentSceneName = "Simulated Content Scene";
            const string k_SimulatedEnvironmentSceneName = "Simulated Environment Scene";
            static readonly CreateSceneParameters k_EnvironmentSceneParameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);

            readonly HashSet<Camera> m_Cameras = new HashSet<Camera>();

            internal Scene contentScene { get; private set; }
            internal Scene environmentScene { get; private set; }
            internal GameObject contentRoot { get; private set; }
            internal GameObject environmentRoot { get; private set; }
            static bool useFallbackRendering => CompositeRenderModuleOptions.instance.UseFallbackCompositeRendering;

            internal SimulationScene()
            {
                // When not in play mode, use a preview scene for simulation
                var isPlaying = EditorApplication.isPlayingOrWillChangePlaymode;
                if (isPlaying)
                {
                    contentScene = SceneManager.CreateScene(k_SimulatedContentSceneName);
                }
                else
                {
                    var previewScene = EditorSceneManager.NewPreviewScene();
                    previewScene.name = k_SimulatedContentSceneName;
                    contentScene = previewScene;
                }

                if (!contentScene.IsValid())
                    throw new InvalidOperationException("Content scene could not be created");

                contentRoot = new GameObject("Simulated Content Root");
                SceneManager.MoveGameObjectToScene(contentRoot, contentScene);

                if (isPlaying)
                {
                    environmentScene = SceneManager.CreateScene(k_SimulatedEnvironmentSceneName, k_EnvironmentSceneParameters);
                }
                else if (useFallbackRendering)
                {
                    environmentScene = contentScene;
                }
                else
                {
                    var previewScene = EditorSceneManager.NewPreviewScene();
                    previewScene.name = k_SimulatedEnvironmentSceneName;
                    environmentScene = previewScene;
                }

                if (!environmentScene.IsValid())
                    throw new InvalidOperationException("Environment scene could not be created");

                environmentRoot = new GameObject("Simulated Environment Root");
                SceneManager.MoveGameObjectToScene(environmentRoot, environmentScene);

                EditorOnlyDelegates.GetAllSimulationSceneCameras = GetAllSimulationSceneCameras;
            }

            internal void AddSimulatedGameObject(GameObject go, bool isContent, bool keepAtRoot)
            {
                if (keepAtRoot)
                {
                    go.transform.parent = null;
                    SceneManager.MoveGameObjectToScene(go, isContent ? contentScene : environmentScene);
                }
                else
                {
                    go.transform.SetParent(isContent ? contentRoot.transform : environmentRoot.transform, true);
                }
            }

            internal bool IsCameraAssignedToSimulationScene(Camera camera)
            {
                var cameraScene = camera.scene;
                return m_Cameras.Contains(camera) && (cameraScene == contentScene || cameraScene == environmentScene);
            }

            internal void AssignCameraToSimulation(Camera camera)
            {
                if (IsCameraAssignedToSimulationScene(camera))
                {
                    Debug.LogWarning($"{camera.name} is already assigned to Sim View.");
                    return;
                }

                m_Cameras.Add(camera);
            }

            internal void RemoveCameraFromSimulationScene(Camera camera, bool dispose = false)
            {
                if (dispose || !m_Cameras.Remove(camera))
                    return;

                camera.scene = SceneManager.GetActiveScene();
            }

            public void Dispose()
            {
                if (m_Cameras != null && m_Cameras.Count > 0)
                {
                    foreach (var camera in m_Cameras)
                    {
                        if (camera != null)
                            RemoveCameraFromSimulationScene(camera, true);
                    }
                    m_Cameras.Clear();
                }

                CloseScene(contentScene, contentRoot);
                contentRoot = null;
                CloseScene(environmentScene, environmentRoot);
                environmentRoot = null;

                EditorOnlyDelegates.GetAllSimulationSceneCameras = null;
                contentScene = new Scene();
                environmentScene = new Scene();
            }

            static void CloseScene(Scene scene, GameObject root)
            {
                if (!scene.IsValid())
                    return;

                if (root != null)
                    UnityObjectUtils.Destroy(root);

                if (EditorSceneManager.IsPreviewScene(scene))
                    EditorSceneManager.ClosePreviewScene(scene);
                else
                    SceneManager.UnloadSceneAsync(scene);
            }

            void GetAllSimulationSceneCameras(List<Camera> cameras)
            {
                cameras.AddRange(m_Cameras);
            }
        }
    }
}

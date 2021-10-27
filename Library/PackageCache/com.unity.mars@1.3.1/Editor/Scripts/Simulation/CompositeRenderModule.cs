using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.MARSUtils;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

#if INCLUDE_POST_PROCESSING
using UnityEngine.Rendering.PostProcessing;
#endif

namespace UnityEditor.MARS.Simulation.Rendering
{
    /// <summary>
    /// Module that manages the composite render context for all active views.
    /// This allows the composting of multiple scenes with different render settings in a view.
    /// </summary>
    [ModuleOrder(ModuleOrders.CompositeRenderLoadOrder)]
    [ModuleUnloadOrder(ModuleOrders.CompositeRenderUnloadOrder)]
    [MovedFrom("Unity.MARS")]
    public class CompositeRenderModule : IModuleDependency<SimulationSceneModule>, IModuleBehaviorCallbacks
    {
        SimulationSceneModule m_SimulationSceneModule;

        Camera m_MarsSessionCamera;
        CompositeRenderContext m_SessionRenderContext;
        GameObject m_ImageEffectsVolume;
        bool m_HoldForGameView;
        PlayModeStateChange m_ModeStateChange;
        RenderPipeline m_RenderPipeline;
        bool m_PipelineChanged;
        bool m_DisposingAllSceneViews;

        readonly HashSet<SceneView> m_SceneViews = new HashSet<SceneView>();
        readonly Dictionary<ScriptableObject, CompositeRenderContext> m_CompositeViewRenderContexts =
            new Dictionary<ScriptableObject, CompositeRenderContext>();

        internal bool SimulationSceneReady => !BuildPipeline.isBuildingPlayer && m_SimulationSceneModule != null
            && m_SimulationSceneModule.IsSimulationReady;

        internal bool HoldForGameView
        {
            get
            {
                return m_HoldForGameView;
            }
            set
            {
                if (m_ModeStateChange == PlayModeStateChange.ExitingEditMode && !value)
                    return;

                m_HoldForGameView = value;

                if (!HoldForGameView && m_ImageEffectsVolume != null)
                    m_ImageEffectsVolume.SetActive(true);
            }
        }

        /// <summary>
        /// Event callback for before composite cameras render in the Composite Render Context
        /// </summary>
        public event Action<CompositeRenderContext> BeforeBackgroundCameraRender;

        /// <inheritdoc />
        void IModuleDependency<SimulationSceneModule>.ConnectDependency(SimulationSceneModule dependency)
        {
            m_SimulationSceneModule = dependency;
        }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            if (Application.isPlaying)
                m_HoldForGameView = true;

            CompositeRenderRuntimeUtils.OnImageEffectSettingsSet += SetImageEffectsProfile;
            CompositeRenderRuntimeUtils.OnImageEffectSettingsUnset += TearDownImageEffectsProfile;
            EditorApplication.playModeStateChanged += EditorApplicationPlayModeStateChanged;

            if (CompositeRenderRuntimeUtils.ImageEffectSettings != null)
            {
                SetImageEffectsProfile(CompositeRenderRuntimeUtils.ImageEffectSettings);
            }

            foreach (var contextPair in m_CompositeViewRenderContexts)
            {
                if (contextPair.Key is SceneView)
                    contextPair.Value.Dispose();
            }

            m_CompositeViewRenderContexts.Clear();
            m_SceneViews.Clear();

            SceneView.beforeSceneGui += OnBeforeSceneGui;
            SceneView.duringSceneGui += OnDuringSceneGui;

            // Cache render pipeline to catch if it changes when the composite render module is running.
            m_RenderPipeline = RenderPipelineManager.currentPipeline;

            CompositeRenderEditorUtils.SetupRenderShaderGlobals();
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            // Set pipeline changes to false first to early out of delay call that disposes of scene views.
            m_DisposingAllSceneViews = false;

            CompositeRenderRuntimeUtils.OnImageEffectSettingsSet -= SetImageEffectsProfile;
            CompositeRenderRuntimeUtils.OnImageEffectSettingsUnset -= TearDownImageEffectsProfile;
            SceneView.beforeSceneGui -= OnBeforeSceneGui;
            SceneView.duringSceneGui -= OnDuringSceneGui;
            EditorApplication.playModeStateChanged -= EditorApplicationPlayModeStateChanged;

            foreach (var sceneViewData in m_CompositeViewRenderContexts)
            {
                RemoveView(sceneViewData.Key, sceneViewData.Value, true);
            }

            TearDownGameView();
            m_SimulationSceneModule = null;
            m_CompositeViewRenderContexts.Clear();
            m_SceneViews.Clear();
        }

        /// <summary>
        /// Get the active Composite Render Module for the Module Loader Core
        /// </summary>
        /// <returns>True if there is a loaded Composite Render Module.</returns>
        /// <param name="compositeRenderModule">The active Composite Render Module.</param>
        public static bool GetActiveCompositeRenderModule(out CompositeRenderModule compositeRenderModule)
        {
            compositeRenderModule = null;
            var moduleLoader = ModuleLoaderCore.instance;
            if (moduleLoader == null)
                return false;

            compositeRenderModule = moduleLoader.GetModule<CompositeRenderModule>();
            return compositeRenderModule != null;
        }

        /// <summary>
        /// Try to get a Composite Render Context associated with the Scriptable Object
        /// from the active Composite Render Module.
        /// </summary>
        /// <param name="scriptableObject">Scriptable object we want the context for.</param>
        /// <param name="context">The Composite Render Context associated with the scriptable object.</param>
        /// <returns>Returns True if there is a context associated with the scriptable object.</returns>
        public static bool TryGetCompositeRenderContext(ScriptableObject scriptableObject, out CompositeRenderContext context)
        {
            context = null;
            if (!GetActiveCompositeRenderModule(out var renderModule))
                return false;

            return renderModule.m_CompositeViewRenderContexts.TryGetValue(scriptableObject, out context);
        }

        internal void OnBeforeBackgroundCameraRender(CompositeRenderContext compositeRenderContext)
        {
            if (BeforeBackgroundCameraRender != null)
                BeforeBackgroundCameraRender.Invoke(compositeRenderContext);
        }

        void OnBeforeSceneGui(SceneView sceneView)
        {
            if (m_PipelineChanged)
                return;

            if (Event.current.type != EventType.Repaint)
            {
                // Check if the pipeline changed at the start of layout.
                // This will cause early out of composite rendering for all the scene views if it is changed.
                // It also means at the start of every scene view we are checking if changed.
                CheckRenderPipelineChanged();
                return;
            }

            if (m_CompositeViewRenderContexts.TryGetValue(sceneView, out var context))
            {
                var sceneTargetTexture = sceneView.GetSceneTargetTexture();
                if (sceneTargetTexture != null)
                    context.SetRenderTextureDescriptor(sceneTargetTexture.descriptor);

                context.PreCompositeCullTargetCamera();
            }
        }

        void OnDuringSceneGui(SceneView sceneView)
        {
            if (Event.current.type != EventType.Repaint)
                return;

            // If the pipeline has change this will start the dispose process and early out the extra composite rendering.
            if (m_PipelineChanged)
            {
                CheckRenderPipelineChanged();
                return;
            }

            if (m_CompositeViewRenderContexts.TryGetValue(sceneView, out var context))
            {
                context.ShowImageEffects = sceneView.sceneViewState.showImageEffects;
                context.BackgroundClearFlag = sceneView.sceneViewState.showSkybox ? CameraClearFlags.Skybox : CameraClearFlags.SolidColor;

                context.PostCompositeRenderTargetCamera();
            }
            // Add the the SceneView after it has been able to render once
            else if (!m_SceneViews.Contains(sceneView))
            {
                m_SceneViews.Add(sceneView);
                AddView(sceneView);
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
            if (!Application.isPlaying)
                return;

            var sessionCamera = MarsRuntimeUtils.GetActiveCamera(true);
            if (sessionCamera != null)
                SetupGameView(sessionCamera);
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate()
        {
            var options = CompositeRenderModuleOptions.instance;
            if (options.UseFallbackCompositeRendering && m_SessionRenderContext != null)
            {
                m_SessionRenderContext.PostCompositeRenderTargetCamera();
                m_SessionRenderContext.PostCompositeRenderTargetCamera();
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable()
        {
            if (!Application.isPlaying)
                return;

            TearDownGameView();
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }

        void EditorApplicationPlayModeStateChanged(PlayModeStateChange playModeState)
        {
            m_ModeStateChange = playModeState;
            switch (playModeState)
            {
                case PlayModeStateChange.EnteredEditMode:
                    m_HoldForGameView = false;
                    break;
                case PlayModeStateChange.ExitingEditMode:
                case PlayModeStateChange.EnteredPlayMode:
                    m_HoldForGameView = true;
                    break;
            }
        }

        /// <summary>
        /// Add a viewport to use the composite render module using the viewport's base <c>ScriptableObject</c>
        /// </summary>
        /// <param name="scriptableObject">The viewport to add the composite to.</param>
        public void AddView(ScriptableObject scriptableObject)
        {
            var environmentLayerMask = SimulationConstants.SimulatedEnvironmentLayerMask;
            CompositeRenderContext compositeRenderContext;
            if (scriptableObject is ICompositeView compositeView)
            {
                compositeRenderContext = new CompositeRenderContext(compositeView.ContextViewType,
                    compositeView.TargetCamera, compositeView.CameraTargetDescriptor,compositeView.BackgroundColor,
                    environmentLayerMask, compositeView.ShowImageEffects, compositeView.BackgroundSceneActive,
                    compositeView.DesaturateComposited, compositeView.UseXRay);

                if (!Application.isPlaying)
                    m_SimulationSceneModule?.RegisterSimulationUser(scriptableObject);
            }
            else if (scriptableObject is SceneView sceneView)
            {
                var simView = scriptableObject as SimulationView;
                var isSimView = simView != null;

                compositeRenderContext = new CompositeRenderContext(isSimView ? ContextViewType.SimulationView : ContextViewType.NormalSceneView,
                    sceneView.camera, sceneView.GetSceneTargetTexture() != null ? sceneView.GetSceneTargetTexture().descriptor : new RenderTextureDescriptor(),
                    SimulationView.EditorBackgroundColor, environmentLayerMask, isSimView && sceneView.sceneViewState.showImageEffects,
                    isSimView && simView.EnvironmentSceneActive, isSimView && simView.DesaturateInactive,
                    isSimView ? simView.UseXRay : true);

                if (isSimView)
                {
                    compositeRenderContext.BeforeCompositeCameraUpdate += simView.UpdateCamera;

                    // Simulation view should not try to open a simulation in play mode.
                    // This is handled in MonoBehaviour Awake of the MARSSession.
                    if (!Application.isPlaying)
                        m_SimulationSceneModule?.RegisterSimulationUser(scriptableObject);
                }
            }
            else
            {
                Debug.LogWarningFormat("{0} is not a Scene View or Contains ICompositeView! Cannot add to Composite View Module", scriptableObject.name);
                return;
            }

            compositeRenderContext.CompositeLayerMask = environmentLayerMask;
            m_CompositeViewRenderContexts.Add(scriptableObject, compositeRenderContext);
        }

        /// <summary>
        /// Removes a view from being used in the composite render module
        /// and disposes of the CompositeRenderContext for that view.
        /// </summary>
        /// <param name="scriptableObject">ScriptableObject to be removed.</param>
        public void RemoveView(ScriptableObject scriptableObject)
        {
            if (m_CompositeViewRenderContexts.TryGetValue(scriptableObject, out var context))
                RemoveView(scriptableObject, context, false);

            if (scriptableObject is SceneView sceneView)
                m_SceneViews.Remove(sceneView);
        }

        /// <summary>
        /// Removes a view from being used in the composite render module
        /// and disposes of the CompositeRenderContext for that view.
        /// </summary>
        /// <param name="scriptableObject">ScriptableObject to be removed.</param>
        /// <param name="compositeRenderContext">The render context to remove.</param>
        /// <param name="removeFromCollection">Should the view be removed from the collection.</param>
        void RemoveView(ScriptableObject scriptableObject, CompositeRenderContext compositeRenderContext, bool removeFromCollection)
        {
            m_SimulationSceneModule?.UnregisterSimulationUser(scriptableObject);

            compositeRenderContext?.Dispose();

            if (!removeFromCollection)
                m_CompositeViewRenderContexts.Remove(scriptableObject);
        }

        /// <summary>
        /// Sets up a GameView for composite rendering of the content and simulation environment.
        /// </summary>
        /// <param name="camera">Game view main camera</param>
        void SetupGameView(Camera camera)
        {
            // Game view is a special case since it GameView is an internal class
            // so we cannot associate a Scriptable object as the parent of the context
            m_MarsSessionCamera = camera;

            // This is to fix an issue with the camera texture flipping in the composite of the game view.
            // The issue is only present on OSX using Metal rendering
            // and may not be needed in a later version of the editor.
#if UNITY_EDITOR_OSX
            if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Metal)
                m_MarsSessionCamera.forceIntoRenderTexture = true;
#endif

            var sessionCameraDescriptor = new RenderTextureDescriptor(camera.pixelWidth, camera.pixelHeight);
            m_SessionRenderContext = new CompositeRenderContext(ContextViewType.GameView, m_MarsSessionCamera,
                sessionCameraDescriptor, Color.black, SimulationConstants.SimulatedEnvironmentLayerMask, true);
            m_SessionRenderContext.AssignCameraToSimulation();
            m_SessionRenderContext.CompositeLayerMask = SimulationConstants.SimulatedEnvironmentLayerMask;
        }

        /// <summary>
        /// Removes the GameView from being used in the composite render module
        /// and disposes of the CompositeRenderContext for that view.
        /// </summary>
        void TearDownGameView()
        {
            m_MarsSessionCamera = null;

            if (m_SessionRenderContext != null)
            {
                m_SessionRenderContext.Dispose();
                m_SessionRenderContext = null;
            }
        }

        void SetImageEffectsProfile(ScriptableObject imageEffectProfile)
        {
            if ((m_SimulationSceneModule==null) || !m_SimulationSceneModule.IsSimulationReady)
                return;

            if (m_ImageEffectsVolume != null)
            {
                UnityObjectUtils.Destroy(m_ImageEffectsVolume);
            }

            m_ImageEffectsVolume = new GameObject("Image Effects Volume")
            {
                layer = SimulationConstants.SimulatedEnvironmentLayerIndex,
                hideFlags = HideFlags.HideAndDontSave
            };

            SceneManager.MoveGameObjectToScene(m_ImageEffectsVolume, m_SimulationSceneModule.EnvironmentScene);

            if (HoldForGameView)
                m_ImageEffectsVolume.SetActive(false);

#if INCLUDE_POST_PROCESSING
            if (imageEffectProfile is PostProcessProfile postProcessProfile)
            {
                var volume = m_ImageEffectsVolume.AddComponent<PostProcessVolume>();
                volume.hideFlags = HideFlags.HideAndDontSave;

                volume.isGlobal = true;
                volume.profile = postProcessProfile;
            }
#endif
        }

        void TearDownImageEffectsProfile()
        {
            if (m_ImageEffectsVolume != null)
                UnityObjectUtils.Destroy(m_ImageEffectsVolume);
        }

        void CheckRenderPipelineChanged()
        {
            // Check to see if pipeline changed in first scene view layout
            if (Event.current.type != EventType.Repaint)
            {
                if (m_PipelineChanged)
                    return;

                var activeRenderPipeline = RenderPipelineManager.currentPipeline;
                m_PipelineChanged = activeRenderPipeline != m_RenderPipeline;
                m_RenderPipeline = activeRenderPipeline;
            }
            // In first repaint (render) of scene view ready the dispose
            // if the render pipeline has changed
            else
            {
                if (m_PipelineChanged && !m_DisposingAllSceneViews)
                {
                    EditorApplication.delayCall += DisposeAllSceneViews;
                    m_DisposingAllSceneViews = true;
                }
            }
        }

        void DisposeAllSceneViews()
        {
            if (!m_DisposingAllSceneViews)
                return;

            foreach (var sceneView in m_SceneViews)
            {
                if (m_CompositeViewRenderContexts.TryGetValue(sceneView, out var context))
                    RemoveView(sceneView, context, false);
            }

            m_SceneViews.Clear();
            m_PipelineChanged = false;
        }
    }
}

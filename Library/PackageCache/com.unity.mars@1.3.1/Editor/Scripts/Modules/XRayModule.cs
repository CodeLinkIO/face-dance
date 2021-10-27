using System.Collections.Generic;
using Unity.MARS.Simulation.Rendering;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObject = UnityEngine.Object;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Authoring;
using UnityEditor.MARS.Simulation;
using UnityEditor.MARS.Simulation.Rendering;

namespace Unity.MARS
{
    /// <summary>
    /// Module that handles cutting out a region of the simulation environment so the interiors of rooms and
    /// buildings can be viewed and interacted with while lighting stays the same
    /// </summary>
    internal class XRayModule : IModuleDependency<ScenePlacementModule>, IModuleDependency<SimulationSceneModule>,
        IModuleDependency<CompositeRenderModule>, IModuleDependency<MARSEnvironmentManager>
    {
        // Default values for the XRay shader if no region is set
        const float k_DefaultFloorHeight = 0.0f;
        const float k_DefaultCeilingHeight = 2.5f;
        const float k_DefaultThickness = 0.5f;
        const float k_DefaultRoomWidth = 3.0f;
        const float k_DefaultScale = 1.0f;
        const string k_XRayEnabledKeyword = "XRAY_ENABLED";
        const string k_FlipXRayDirectionKeyword = "XRAY_FLIP_DEPTH";

        // Shader IDs for the same properties
        static readonly int k_RoomCenterShaderID = Shader.PropertyToID("_RoomCenter");
        static readonly int k_FloorHeightShaderID = Shader.PropertyToID("_FloorHeight");
        static readonly int k_CeilingHeightShaderID = Shader.PropertyToID("_CeilingHeight");
        static readonly int k_ClipOffsetShaderID = Shader.PropertyToID("_RoomClipOffset");
        static readonly int k_FadeThicknessShaderID = Shader.PropertyToID("_FadeThickness");
        static readonly int k_XRayScaleID = Shader.PropertyToID("_XRayScale");

        // Clipping data for the collider disabling
        const float k_VerticalClipOffset = 1.0f;
        const float k_VerticalClipRange = 0.95f;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly Collider[] k_Colliders = new Collider[128];

        XRayRegion m_LastXRay;

        Vector3 m_XRayCenter = Vector3.zero;
        float m_XRayFloorHeight = k_DefaultFloorHeight;
        float m_XRayCeilingHeight = k_DefaultCeilingHeight;
        float m_XRayThickness = k_DefaultThickness;
        float m_XRayRoomWidth = k_DefaultRoomWidth;
        float m_XRayScale = k_DefaultScale;

        bool m_PhysicsInitialized;
        List<Collider> m_DisabledColliders = new List<Collider>();

        ScenePlacementModule m_ScenePlacementModule;
        SimulationSceneModule m_SimulationSceneModule;
        CompositeRenderModule m_CompositeRenderModule;
        MARSEnvironmentManager m_EnvironmentManager;

        void IModuleDependency<ScenePlacementModule>.ConnectDependency(ScenePlacementModule dependency) { m_ScenePlacementModule = dependency; }
        void IModuleDependency<SimulationSceneModule>.ConnectDependency(SimulationSceneModule dependency) { m_SimulationSceneModule = dependency; }
        void IModuleDependency<MARSEnvironmentManager>.ConnectDependency(MARSEnvironmentManager dependency) { m_EnvironmentManager = dependency; }

        void IModuleDependency<CompositeRenderModule>.ConnectDependency(CompositeRenderModule dependency)
        {
            m_CompositeRenderModule = dependency;
            m_CompositeRenderModule.BeforeBackgroundCameraRender += OnBeforeCompositeCamerasRender;
        }

        /// <summary>
        /// Ensures the module gets all events that change potential XRay regions or objects that interact with them
        /// </summary>
        void IModule.LoadModule()
        {
            MARSEnvironmentManager.onEnvironmentSetup += OnEnvironmentSetup;
            EditorSceneManager.sceneSaving += OnSceneSaving;
            PrefabStage.prefabSaving += OnPrefabSaving;
            Selection.selectionChanged += OnSelectionChanged;
            m_EnvironmentManager.EnvironmentOffsetChanged += OnEnvironmentOffsetChanged;
        }

        /// <summary>
        /// Undoes any temporary collider changes and unhooks from any events
        /// </summary>
        void IModule.UnloadModule()
        {
            if (m_CompositeRenderModule != null)
                m_CompositeRenderModule.BeforeBackgroundCameraRender -= OnBeforeCompositeCamerasRender;

            ClearColliderChanges();

            MARSEnvironmentManager.onEnvironmentSetup -= OnEnvironmentSetup;
            Selection.selectionChanged -= OnSelectionChanged;
            EditorSceneManager.sceneSaving -= OnSceneSaving;
            PrefabStage.prefabSaving -= OnPrefabSaving;
            m_EnvironmentManager.EnvironmentOffsetChanged -= OnEnvironmentOffsetChanged;
        }

        void OnSelectionChanged()
        {
            // If the active object has an XRay region, we clear all the environments so the XRay set up gets refreshed
            var selectedObject = Selection.activeGameObject;
            if (selectedObject == null)
                return;

            var selectedXRay = selectedObject.GetComponentInChildren<XRayRegion>();
            if (selectedXRay == null)
                return;

            ClearColliderChanges();
        }

        void OnBeforeCompositeCamerasRender(CompositeRenderContext compositeRenderContext)
        {
            if (!compositeRenderContext.UseXRay)
            {
                Shader.DisableKeyword(k_XRayEnabledKeyword);
                ClearColliderChanges();
                return;
            }

            // Determine which type of scene is being operated on, regular scene view, simulation view, or prefab isolation
            var camera = compositeRenderContext.IsBaseSceneView || !compositeRenderContext.UseCompositeCamera?
                compositeRenderContext.TargetCamera :
                compositeRenderContext.CompositeCamera;
            var cameraScene = camera.scene;

            // camera using default scene
            if (cameraScene.handle == 0)
                cameraScene = SceneManager.GetActiveScene();

            // Game view and sim views use the sim env scene
            if (!compositeRenderContext.IsBaseSceneView && m_SimulationSceneModule.IsSimulationReady
                && compositeRenderContext.UseCompositeCamera)
            {
                cameraScene = m_SimulationSceneModule.EnvironmentScene;
            }

            if (!XRayRuntimeUtils.XRayRegions.TryGetValue(cameraScene, out var activeXRay))
            {
                Shader.DisableKeyword(k_XRayEnabledKeyword);
                ClearColliderChanges();
                return;
            }

            // If the selected XRay data has changed, update the active X-Ray values for physics and shader
            if (m_LastXRay != activeXRay)
            {
                m_LastXRay = activeXRay;

                if (activeXRay != null)
                {
                    var transform = activeXRay.transform;
                    // Scale can vary between views and prefabs, so we grab 'ground truth' from the active XRay Region
                    m_XRayScale = transform.lossyScale.x;

                    m_XRayCenter = transform.position;
                    m_XRayFloorHeight = activeXRay.FloorHeight;
                    m_XRayCeilingHeight = activeXRay.CeilingHeight;
                    m_XRayThickness = activeXRay.ClipOffset;
                    m_XRayRoomWidth = Mathf.Max( activeXRay.ViewBounds.x,  activeXRay.ViewBounds.z);
                }
                else
                {
                    m_XRayScale = k_DefaultScale;
                    m_XRayCenter = Vector3.zero;
                    m_XRayFloorHeight = k_DefaultFloorHeight;
                    m_XRayCeilingHeight = k_DefaultCeilingHeight;
                    m_XRayThickness = k_DefaultThickness;
                    m_XRayRoomWidth = k_DefaultRoomWidth;
                }
            }

            Shader.SetGlobalVector(k_RoomCenterShaderID, m_XRayCenter);
            Shader.SetGlobalFloat(k_FloorHeightShaderID, m_XRayFloorHeight);
            Shader.SetGlobalFloat(k_CeilingHeightShaderID, m_XRayCeilingHeight);
            Shader.SetGlobalFloat(k_ClipOffsetShaderID, m_XRayThickness);
            Shader.SetGlobalFloat(k_XRayScaleID, m_XRayScale);
            Shader.EnableKeyword(k_XRayEnabledKeyword);
            SetXRayDirectionKeyword();

            // Do not disable XRay colliders in environment scene because reverting those changes causes the environment prefab instance
            // to stop running in edit mode. There is no need to disable these colliders when dragging into the Simulation view
            // because the Simulation view only supports dropping assets onto simulated data interaction targets.
            if (cameraScene.handle == m_SimulationSceneModule.EnvironmentScene.handle)
                return;

            // Is there an object being dragged?
            // If so, do collision logic
            // Otherwise, cancel it
            if (!m_ScenePlacementModule.isDragging || compositeRenderContext.ContextViewType == ContextViewType.GameView)
            {
                ClearColliderChanges();
            }
            else
            {
                if (m_PhysicsInitialized)
                    return;

                m_PhysicsInitialized = true;

                // Ensure we are operating in isolation physics scene if in prefab mode
                var physicsScene = cameraScene.IsValid() ? cameraScene.GetPhysicsScene() : Physics.defaultPhysicsScene;

                var scaledFloor = m_XRayScale * m_XRayFloorHeight;
                var scaledCeiling = m_XRayScale * m_XRayCeilingHeight;
                var scaledThickness = m_XRayScale * m_XRayThickness;
                var scaledWidth = m_XRayScale * m_XRayRoomWidth;

                // Create a physics box that lines up with the clipping plane the XRay Shader uses
                // Get all the colliders inside of that and temporarily disable them
                var roomHeight = scaledCeiling - scaledFloor;
                var roomOffset = (scaledFloor + scaledCeiling)*0.5f;

                var cameraToCenter = camera.transform.position - m_XRayCenter;
                if (cameraToCenter.y > scaledCeiling)
                {
                    roomHeight += k_VerticalClipRange;
                    roomOffset += k_VerticalClipOffset;
                }

                if (cameraToCenter.y < scaledFloor)
                {
                    roomHeight += k_VerticalClipRange;
                    roomOffset -= k_VerticalClipOffset;
                }
                cameraToCenter.y = 0.0f;
                var cameraDistance = cameraToCenter.magnitude;
                cameraToCenter.Normalize();

                // Offset towards the camera half the camera distance as the box is centered
                var boxCenter = m_XRayCenter + ((cameraDistance*0.5f + scaledThickness) * cameraToCenter);
                boxCenter.y = m_XRayCenter.y + roomOffset;

                var boxExtents = new Vector3(scaledWidth, roomHeight, cameraDistance)*0.5f;
                var boxOrientation = Quaternion.LookRotation(cameraToCenter.normalized, Vector3.up);
                var collisionCount = physicsScene.OverlapBox(boxCenter, boxExtents, k_Colliders, boxOrientation);

                // Go through colliders and disable - only if they have the XRay collider component
                for (var i = 0; i < collisionCount; i++)
                {
                    var currentCollider = k_Colliders[i];

                    if (!currentCollider.enabled || !currentCollider.TryGetComponent(out XRayCollider _))
                        continue;

                    currentCollider.enabled = false;
                    m_DisabledColliders.Add(currentCollider);
                }
            }
        }

        void ClearColliderChanges()
        {
            if (!m_PhysicsInitialized)
                return;

            foreach (var collider in m_DisabledColliders)
            {
                if (collider != null)
                    PrefabUtility.RevertObjectOverride(collider, InteractionMode.AutomatedAction);
            }

            m_PhysicsInitialized = false;
            m_DisabledColliders.Clear();
        }

        void OnEnvironmentSetup()
        {
            ClearColliderChanges();
        }

        void OnSceneSaving(Scene scene, string path)
        {
            ClearColliderChanges();
        }

        void OnPrefabSaving(GameObject prefab)
        {
            ClearColliderChanges();
        }

        void OnEnvironmentOffsetChanged()
        {
            // Force update of X-Ray values for new position/scale
            m_LastXRay = null;
            ClearColliderChanges();
        }

        internal static void SetXRayDirectionKeyword()
        {
            if (XRayOptions.instance.FlipXRayDirection)
                Shader.EnableKeyword(k_FlipXRayDirectionKeyword);
            else
                Shader.DisableKeyword(k_FlipXRayDirectionKeyword);
        }
    }
}

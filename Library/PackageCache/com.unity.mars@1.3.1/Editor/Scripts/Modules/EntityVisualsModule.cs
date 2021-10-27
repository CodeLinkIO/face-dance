using System;
using System.Collections.Generic;
using System.Linq;
using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.MARS.Conditions;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
#if UNITY_EDITOR
#if UNITY_2021_2_OR_NEWER
using UnityEditor.SceneManagement;
#else
using UnityEditor.Experimental.SceneManagement;
#endif
#endif

namespace UnityEditor.MARS.Authoring
{
    /// <summary>
    /// Create and manages visuals for MARS Entities
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public sealed class EntityVisualsModule : EditorScriptableSettings<EntityVisualsModule>, IModuleDependency<SlowTaskModule>
    {
        [Serializable]
        struct EntityVisualMapping
        {
#pragma warning disable 649
            public string trait;
            public GameObject visualPrefab;
#pragma warning restore 649
        }

        enum SceneType
        {
            Scene,
            Simulation,
            Prefab
        }

        // The root has HideInHierarchy and the child visuals do not because that also disables scene picking.
        // Also does not use HideAndDontSave because that also disables unloading of the object
        const HideFlags k_VisualsRootHideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy;
        const HideFlags k_VisualHideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor;
        // Set hide flags to hide and dont save since the prefab stage will force these flags on modification of the scene.
        const HideFlags k_PrefabStageHideFlags = HideFlags.HideAndDontSave;
        const string k_VisualsRootName = "MARS Entity Visuals (NOT SAVED)";

#pragma warning disable 649
        [SerializeField]
        bool m_ShowVisualsInPlayMode;

        [SerializeField]
        bool m_ShowVisualsInSimulation;

        [SerializeField]
        bool m_ShowVisualsInPrefabScene = true;

        [SerializeField]
        GameObject m_DefaultVisual;
#pragma warning restore 649

        [SerializeField]
        List<EntityVisualMapping> m_VisualMappings = new List<EntityVisualMapping>();

        readonly Dictionary<MARSEntity, EntityVisual> m_EntityVisuals = new Dictionary<MARSEntity, EntityVisual>();
        readonly HashSet<Camera> m_GizmosCameras = new  HashSet<Camera>();
        SlowTaskModule m_SlowTaskModule;

        EditorSlowTask m_UpdateTask;
        EditorSlowTask m_RescanTask;

        GameObject m_MainSceneVisualsRoot;
        GameObject m_SimulationSceneVisualsRoot;
        GameObject m_PrefabStageVisualsRoot;

        Scene m_PrefabStageScene;

        bool m_Loaded;

        readonly Dictionary<EntityVisual, PlaneSizeCondition> m_SizeConditions = new Dictionary<EntityVisual, PlaneSizeCondition>();
        readonly Dictionary<EntityVisual, MarkerCondition> m_ImageMarkerConditions = new Dictionary<EntityVisual, MarkerCondition>();
        readonly List<Transform> m_FaceVisuals = new List<Transform>();
        readonly HashSet<EntityVisual> m_DisabledCollisionVisuals = new HashSet<EntityVisual>();

        /// <summary>
        /// If the module is set to create visuals for simulation, it will look for entities under this transform root.
        /// </summary>
        internal Transform simEntitiesRoot { get; set; }

        internal IProvidesCameraOffset provider { get; set; }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly HashSet<MARSEntity> k_MARSEntities = new HashSet<MARSEntity>();
        static readonly HashSet<MARSEntity> k_SimEntities = new HashSet<MARSEntity>();
        static readonly HashSet<MARSEntity> k_PrefabStageEntities = new HashSet<MARSEntity>();
        static readonly List<MARSEntity> k_EntitiesToRemove = new List<MARSEntity>();

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            CleanupVisuals();

            const float rescanSleepTime = 0.5f;
            const float updateSleepTime = 0.03f;

            m_RescanTask = new EditorSlowTask(ScanEntitiesAndCreateVisuals, rescanSleepTime);
            m_UpdateTask = new EditorSlowTask(UpdateVisuals, updateSleepTime);

            m_SlowTaskModule.AddSlowTask(ScanEntitiesAndCreateVisuals, rescanSleepTime, true);
            m_SlowTaskModule.AddSlowTask(UpdateVisuals, updateSleepTime, true);

            m_Loaded = true;

#if UNITY_EDITOR
            EditorApplication.delayCall += () =>
            {
                if (m_Loaded && !EditorApplication.isPlayingOrWillChangePlaymode)
                    EditorApplication.update += EditorUpdateSlowTask;
            };

            EditorOnlyDelegates.IsGizmosCamera = IsGizmosCamera;
            Selection.selectionChanged += OnSelectionChanged;
#endif
        }

#if UNITY_EDITOR
        void EditorUpdateSlowTask()
        {
            if (!m_Loaded)
                return;

            m_RescanTask.Update();
            m_UpdateTask.Update();
        }
#endif

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            CleanupVisuals();

            m_SlowTaskModule.RemoveSlowTask(UpdateVisuals);
            m_SlowTaskModule.RemoveSlowTask(ScanEntitiesAndCreateVisuals);
            m_FaceVisuals.Clear();

#if UNITY_EDITOR
            EditorApplication.update -= EditorUpdateSlowTask;
            EditorOnlyDelegates.IsGizmosCamera = null;
            Selection.selectionChanged -= OnSelectionChanged;
#endif

            m_PrefabStageScene = default(Scene);
            simEntitiesRoot = null;

            m_UpdateTask = null;
            m_RescanTask = null;
            m_Loaded = false;
        }

        void ScanEntitiesAndCreateVisuals()
        {
            k_MARSEntities.Clear();
            k_SimEntities.Clear();
            k_PrefabStageEntities.Clear();

#if UNITY_EDITOR
            if (!EditorApplication.isPlayingOrWillChangePlaymode || m_ShowVisualsInPlayMode)
#else
            if (m_ShowVisualsInPlayMode)
#endif
            {
                foreach (var foundEntity in FindObjectsOfType<Proxy>())
                {
#if UNITY_EDITOR
                    if (simEntitiesRoot != null && foundEntity.gameObject.scene == simEntitiesRoot.gameObject.scene)
                        continue;
#endif
                    k_MARSEntities.Add(foundEntity);
                }
            }

#if UNITY_EDITOR
            if (!m_PrefabStageScene.IsValid())
            {
                var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
                if (m_ShowVisualsInPrefabScene && prefabStage != null && prefabStage.scene.IsValid())
                    m_PrefabStageScene = prefabStage.scene;
            }
            else
            {
                foreach (var roots in m_PrefabStageScene.GetRootGameObjects())
                {
                    // We use RealWorldObject not MARSEntity because we don't want the default visuals
                    // for replicators and proxy groups.
                    foreach (var foundEntity in roots.GetComponentsInChildren<Proxy>())
                    {
                        k_PrefabStageEntities.Add(foundEntity);
                    }
                }
            }
#endif

            if (m_ShowVisualsInSimulation && simEntitiesRoot != null)
            {
                foreach (var foundEntity in simEntitiesRoot.GetComponentsInChildren<Proxy>())
                {
                    k_SimEntities.Add(foundEntity);
                }
            }

            k_EntitiesToRemove.Clear();

            // Check if any entity no longer exists, or is not contained in the desired sets, then destroy and remove their visuals
            foreach (var kvp in m_EntityVisuals)
            {
                var entity = kvp.Key;
                if (entity != null)
                {
                    if (k_MARSEntities.Contains(entity))
                        continue;

                    if (k_SimEntities.Contains(entity))
                        continue;

                    if (k_PrefabStageEntities.Contains(entity))
                        continue;
                }

                var entityVisual = kvp.Value;
                if (entityVisual != null)
                    UnityObjectUtils.Destroy(kvp.Value.gameObject);

                k_EntitiesToRemove.Add(entity);
            }

            foreach (var entity in k_EntitiesToRemove)
            {
                m_EntityVisuals.Remove(entity);
            }

            // Create a sim view visual for any entity that doesn't have one
            foreach (var entity in k_SimEntities)
            {
                EntityVisual visual;
                if (!m_EntityVisuals.TryGetValue(entity, out visual))
                    m_EntityVisuals.Add(entity, CreateVisual(entity, SceneType.Simulation));
                else if (visual == null)
                    m_EntityVisuals[entity] = CreateVisual(entity, SceneType.Simulation);
            }

            // Create a visual for any entity that doesn't have one
            foreach (var entity in k_MARSEntities)
            {
                EntityVisual visual;
                if (!m_EntityVisuals.TryGetValue(entity, out visual))
                    m_EntityVisuals.Add(entity, CreateVisual(entity, SceneType.Scene));
                else if (visual == null)
                    m_EntityVisuals[entity] = CreateVisual(entity, SceneType.Scene);
            }

            foreach (var entity in k_PrefabStageEntities)
            {
                EntityVisual visual;
                if (!m_EntityVisuals.TryGetValue(entity, out visual))
                    m_EntityVisuals.Add(entity, CreateVisual(entity, SceneType.Prefab));
                else if (visual == null)
                    m_EntityVisuals[entity] = CreateVisual(entity, SceneType.Prefab);
            }
        }

#if UNITY_EDITOR
        void OnSelectionChanged()
        {
            if (Selection.gameObjects.Length == 0)
                return;

            foreach (var entityVisual in m_EntityVisuals)
            {
                if (entityVisual.Key == null)
                    return;

                var selected = Selection.gameObjects.Contains(entityVisual.Key.gameObject);
                entityVisual.Value.InteractionTarget.SetSelected(selected);
            }
        }
#endif

        /// <summary>
        /// Removes the current visual for an entity so that it will be recreated.
        /// </summary>
        /// <param name="entity"> The entity for which the visual is invalid</param>
        public void InvalidateVisual(MARSEntity entity)
        {
            EntityVisual visual;
            if (m_EntityVisuals.TryGetValue(entity, out visual))
            {
                m_EntityVisuals.Remove(entity);
                if (visual != null)
                    UnityObjectUtils.Destroy(visual.gameObject);
            }
        }

        /// <summary>
        /// Update the visual color for an entity
        /// </summary>
        /// <param name="entity">The entity that needs its visual to be updated</param>
        public void UpdateColor(MARSEntity entity)
        {
            EntityVisual visual;
            if (m_EntityVisuals.TryGetValue(entity, out visual))
            {
                visual.ApplyColors();
            }
        }

        /// <summary>
        /// Get the <c>EntityVisual</c> associated with a <c>MARSEntity</c>
        /// </summary>
        /// <param name="entity">Entity to get the visual of</param>
        /// <returns>Visual associated with the given entity</returns>
        public EntityVisual GetVisual(MARSEntity entity)
        {
            return m_EntityVisuals.TryGetValue(entity, out var visual) ? visual : null;
        }

        /// <summary>
        /// Disable the collider for an entity's visual. Used for preventing an entity from attaching to its own visual.
        /// </summary>
        /// <param name="entity"> The entity for which the visual should be disabled.</param>
        public void DisableVisualCollision(MARSEntity entity)
        {
            if (entity == null)
                return;

            EntityVisual visual;
            if (m_EntityVisuals.TryGetValue(entity, out visual))
            {
                if (visual == null || m_DisabledCollisionVisuals.Contains(visual))
                    return;

                foreach (var collider in visual.GetComponentsInChildren<Collider>())
                {
                    collider.enabled = false;
                }

                m_DisabledCollisionVisuals.Add(visual);
            }
        }

        /// <summary>
        /// Reset all collision with entity visuals that had previously been disabled using DisableVisualCollision
        /// </summary>
        public void ResetVisualCollision()
        {
            foreach (var visual in m_DisabledCollisionVisuals)
            {
                if (visual == null)
                    continue;

                foreach (var collider in visual.GetComponentsInChildren<Collider>())
                {
                    collider.enabled = true;
                }
            }

            m_DisabledCollisionVisuals.Clear();
        }

        EntityVisual CreateVisual(MARSEntity entity, SceneType sceneType)
        {
            EntityVisual visual = null;

            // Collect all traits from conditions
            var traits = new HashSet<string>();
            var conditions = entity.GetComponents<ICondition>();
            foreach (var condition in conditions)
            {
                if (!condition.enabled)
                    continue;

                var tagCondition = condition as ISemanticTagCondition; // Skip traits from exclude tag conditions
                if (tagCondition != null && tagCondition.matchRule == SemanticTagMatchRule.Exclude)
                    continue;

                traits.Add(condition.traitName);
            }

            // Also collect traits from multi-conditions
            var multiconditions = entity.GetComponents<MultiConditionBase>();
            foreach (var multicondition in multiconditions)
            {
                if (multicondition.HostedComponents != null)
                {
                    foreach (var subcondition in multicondition.HostedComponents)
                    {
                        var tagCondition = subcondition as ISemanticTagCondition; // Skip traits from exclude tag conditions
                        if (tagCondition != null && tagCondition.matchRule == SemanticTagMatchRule.Exclude)
                            continue;

                        traits.Add(subcondition.traitName);
                    }
                }
            }

            // First check mappings, the first matching trait in the mappings list will determine the visual
            foreach (var visualMapping in m_VisualMappings)
            {
                var prefab = visualMapping.visualPrefab;
                var traitName = visualMapping.trait;
                if (prefab != null && traits.Contains(traitName))
                {
                    visual = CreateVisualFromPrefab(entity, prefab);
                    break;
                }
            }

            // If there is no prefab for the entity's traits, create the default
            if (visual == null)
            {
                visual = CreateVisualFromPrefab(entity, m_DefaultVisual);
            }

            if (visual == null)
                return null;

#if UNITY_EDITOR
            var selected = Selection.gameObjects.Contains(entity.gameObject);
            visual.InteractionTarget.SetSelected(selected);
#endif

            // Check that the scene type we are using has a visuals root and set the visuals to that root
            switch (sceneType)
            {
                case SceneType.Simulation:
                    if (m_SimulationSceneVisualsRoot == null)
                    {
                        m_SimulationSceneVisualsRoot = new GameObject(k_VisualsRootName);
                        m_SimulationSceneVisualsRoot.transform.SetParent(simEntitiesRoot);
                        m_SimulationSceneVisualsRoot.hideFlags = k_VisualsRootHideFlags;
                    }

                    visual.transform.SetParent(m_SimulationSceneVisualsRoot.transform, true);
                    visual.gameObject.SetLayerAndHideFlagsRecursively(entity.gameObject.layer, k_VisualHideFlags);
                    break;
                case SceneType.Scene:
                    if (m_MainSceneVisualsRoot == null)
                    {
                        m_MainSceneVisualsRoot = new GameObject(k_VisualsRootName);
                        m_MainSceneVisualsRoot.hideFlags = k_VisualsRootHideFlags;
                    }

                    visual.transform.SetParent(m_MainSceneVisualsRoot.transform);
                    visual.gameObject.SetLayerAndHideFlagsRecursively(entity.gameObject.layer, k_VisualHideFlags);
                    break;
                case SceneType.Prefab:
#if UNITY_EDITOR
                    if (m_PrefabStageScene.IsValid())
                    {
                        // Prefab stage root needs to be recreated for new prefab stages
                        if (m_PrefabStageVisualsRoot == null)
                        {
                            // Needs different hide flags for proper selection, hiding and not modifying
                            // the prefab scene in prefab mode.
                            m_PrefabStageVisualsRoot = new GameObject(k_VisualsRootName){ hideFlags = k_PrefabStageHideFlags };
                            SceneManager.MoveGameObjectToScene(m_PrefabStageVisualsRoot, m_PrefabStageScene);
                        }

                        visual.transform.SetParent(m_PrefabStageVisualsRoot.transform);
                        visual.gameObject.SetLayerAndHideFlagsRecursively(entity.gameObject.layer, k_PrefabStageHideFlags);
                    }
#endif
                    break;
            }

            var sizeCondition = entity.GetComponent<PlaneSizeCondition>(); // PlaneSizeConditions will control scale
            if (sizeCondition != null)
                m_SizeConditions.Add(visual, sizeCondition);

            var markerCondition = entity.GetComponent<MarkerCondition>();
            if(markerCondition != null)
                m_ImageMarkerConditions.Add(visual, markerCondition);

            if (traits.Contains(TraitNames.Face))
                m_FaceVisuals.Add(visual.transform);

            return visual;
        }

        static EntityVisual CreateVisualFromPrefab(MARSEntity entity, GameObject prefab)
        {
            if (prefab == null)
                return null;

            // Set the prefab root to not active so that OnEnable will not be called yet when instantiated.
            // This allows scripts on the prefab to reference the entity on the visual script which is assigned after instantiate
            prefab.SetActive(false);
            var go = Instantiate(prefab);
            go.name = entity.gameObject.name;

            var visual = go.GetComponent<EntityVisual>();
            if (visual == null)
                visual = go.AddComponent<EntityVisual>();

            visual.entity = entity;

            var interactionTargets = visual.GetComponentsInChildren<InteractionTarget>();
            foreach (var target in interactionTargets)
            {
                target.AttachTarget = entity.transform;
            }

            // Now set it active will enable all its components
            go.SetActive(true);

            return visual;
        }

        void CleanupVisuals()
        {
            if (m_MainSceneVisualsRoot)
                UnityObjectUtils.Destroy(m_MainSceneVisualsRoot);

            if (m_SimulationSceneVisualsRoot)
                UnityObjectUtils.Destroy(m_SimulationSceneVisualsRoot);

            if (m_PrefabStageVisualsRoot)
                UnityObjectUtils.Destroy(m_PrefabStageVisualsRoot);

            m_EntityVisuals.Clear();
            m_DisabledCollisionVisuals.Clear();
            m_SizeConditions.Clear();
        }

        void CleanupVisualsForDestroyedEntities()
        {
            k_EntitiesToRemove.Clear();

            // Check if any entity no longer exists, then destroy and remove their visuals
            foreach (var kvp in m_EntityVisuals)
            {
                var entity = kvp.Key;
                if (entity != null)
                    continue;

                var entityVisual = kvp.Value;
                if (entityVisual != null)
                    UnityObjectUtils.Destroy(entityVisual.gameObject);

                k_EntitiesToRemove.Add(entity);
            }

            foreach (var entity in k_EntitiesToRemove)
            {
                m_EntityVisuals.Remove(entity);
            }
        }

        void UpdateVisuals()
        {
            TrackVisualPoses();
            ScalePlaneSizeConditionVisuals();
            UpdateImageMarkerConditionVisuals();
            UpdateSimVisualsForQueryState();
            UpdateGizmosCameras();
        }

        void UpdateImageMarkerConditionVisuals()
        {
            // There is no guarantee that the MarsSession singleton is going to be available at this stage so we need to get it like this
            var loadedMARSSession = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            if (!loadedMARSSession)
                return;

            var loadedMarkerLibrary = loadedMARSSession.MarkerLibrary;
            if (loadedMarkerLibrary == null)
                return;

            foreach (var entityVisualMarkerConditionKeyValuePair in m_ImageMarkerConditions)
            {
                if (entityVisualMarkerConditionKeyValuePair.Key == null || entityVisualMarkerConditionKeyValuePair.Value == null)
                    continue;

                var foundMarkerId = false;
                MarkerCondition currentMarkerCondition = entityVisualMarkerConditionKeyValuePair.Value;
                for (var i = 0; i < loadedMarkerLibrary.Count; i++)
                {
                    if (loadedMarkerLibrary[i].MarkerId.ToString() == currentMarkerCondition.MarkerGuid)
                    {
                        entityVisualMarkerConditionKeyValuePair.Key.SetScale(new Vector3(loadedMarkerLibrary[i].Size.x, loadedMarkerLibrary[i].Size.y, 0.01f));
                        entityVisualMarkerConditionKeyValuePair.Key.SetTextureForImageMarker(loadedMarkerLibrary[i].Texture, MarsUserPreferences.TintImageMarkers);
                        foundMarkerId = true;
                        break;
                    }
                }

                // Case when the user removes from the marker library an image marker already assigned.
                if (!foundMarkerId)
                {
                    // TODO: Perhaps tint this with magenta color? (Since no marker image is assigned anymore to this visual)
                    entityVisualMarkerConditionKeyValuePair.Key.SetTextureForImageMarker(Texture2D.whiteTexture, MarsUserPreferences.TintImageMarkers);
                }
            }
        }

        void ScalePlaneSizeConditionVisuals()
        {
            // Scale visuals to match their respective size condition
            foreach (var kvp in m_SizeConditions)
            {
                if (kvp.Key == null || kvp.Value == null)
                    continue;

                var planeSizeCondition = kvp.Value;
                if (planeSizeCondition != null)
                {
                    var planeSize = Vector2.one;
                    if (planeSizeCondition.maxBounded && planeSizeCondition.minBounded)
                    {
                        planeSize = 0.5f * (planeSizeCondition.minimumSize + planeSizeCondition.maximumSize);
                    }
                    else if (planeSizeCondition.maxBounded)
                    {
                        planeSize = planeSizeCondition.maximumSize;
                    }
                    else if (planeSizeCondition.minBounded)
                    {
                        planeSize = planeSizeCondition.minimumSize;
                    }

                    kvp.Key.SetScale(new Vector3(planeSize.x, 1f, planeSize.y));
                }
            }
        }

        void TrackVisualPoses()
        {
            CleanupVisualsForDestroyedEntities();

            // Move visuals to the entity they should track
            foreach (var visual in m_EntityVisuals)
            {
                if (visual.Value == null)
                    continue;

                var entity = visual.Key;
                if (entity != null)
                {
                    visual.Value.transform.SetWorldPose(entity.transform.GetWorldPose());
                    visual.Value.transform.localScale = Vector3.one * MarsWorldScaleModule.GetWorldScale();
                }

            }
        }

        void UpdateSimVisualsForQueryState()
        {
            if (m_SimulationSceneVisualsRoot == null)
                return;

            foreach (var visual in m_SimulationSceneVisualsRoot.GetComponentsInChildren<EntityVisual>())
            {
                var realWorldObject = visual.entity as Proxy;
                if (realWorldObject != null)
                    visual.UpdateForQueryState(realWorldObject.queryState);

            }
        }

        /// <inheritdoc />
        void IModuleDependency<SlowTaskModule>.ConnectDependency(SlowTaskModule dependency)
        {
            m_SlowTaskModule = dependency;
        }

        void UpdateGizmosCameras()
        {
            m_GizmosCameras.Clear();
            foreach (var sceneViewObj in SceneView.sceneViews)
            {
                if (sceneViewObj is SceneView sceneView && sceneView.drawGizmos)
                {
                    m_GizmosCameras.Add(sceneView.camera);
                }
            }
        }

        bool IsGizmosCamera(Camera camera)
        {
            return m_GizmosCameras.Contains(camera);
        }
    }
}

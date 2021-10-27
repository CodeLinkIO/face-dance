using System.Collections.Generic;
using System.Linq;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Module that creates MARS proxies in the simulation to visualize data and control those objects
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class DataVisualsModule : ScriptableSettings<DataVisualsModule>, IUsesFunctionalityInjection, IModule
    {
        const string k_ScaleShaderVariable = "_WorldScale";
        const string k_DataVisualsRootName = "Editor Data Visuals";
        static readonly int k_WorldScaleShaderVariable = Shader.PropertyToID(k_ScaleShaderVariable);

#pragma warning disable 649
        [SerializeField]
        GameObject m_PlaneVisualizerPrefab;
#pragma warning restore 649

        DataVisualsModuleOptions m_Options;
        GameObject m_VisualsRoot;
        List<IDataVisual> m_DataVisuals = new List<IDataVisual>();

        /// <summary>
        /// The root gameobject of all the data visual gameobjects.
        /// </summary>
        public GameObject VisualsRoot { get => m_VisualsRoot; set => m_VisualsRoot = value; }

        /// <summary>
        /// The standard gradient that can be used for coloring visuals based on their rating.
        /// </summary>
        public Gradient RatingGradient => m_Options.RatingGradient;

        /// <summary>
        /// Disable data visuals from being generated in simulation
        /// </summary>
        public bool DisableSimulationDataVisuals
        {
            get => m_Options.DisableSimulationDataVisuals;
            set
            {
                m_Options.DisableSimulationDataVisuals = value;
                if (m_Options.DisableSimulationDataVisuals)
                {
                    UnsubscribeToSimulationEvents();
                    DestroyDataVisuals();
                }
                else
                {
                    SubscribeToSimulationEvents();
                }
            }
        }

        /// <summary>
        /// If enabled, the data visuals will be shown in the hierarchy
        /// </summary>
        public bool ShowDataVisualsInHierarchy
        {
            get => m_Options.ShowDataVisualsInHierarchy;
            set => m_Options.ShowDataVisualsInHierarchy = value;
        }

        /// <inheritdoc />
        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }
        GameObject PlaneVisualizer { get; set; }

        readonly HashSet<object> m_DataVisualsUsers = new HashSet<object>();

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            m_VisualsRoot = null;

            if (m_Options == null)
                m_Options = DataVisualsModuleOptions.instance;

            if (!DisableSimulationDataVisuals)
                SubscribeToSimulationEvents();

            m_DataVisualsUsers.Clear();
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            UnsubscribeToSimulationEvents();
            DestroyDataVisuals();
        }

        void UnsubscribeToSimulationEvents()
        {
#if UNITY_EDITOR
            EditorOnlyEvents.onSimulationStart -= OnSimulationStart;
            EditorOnlyEvents.onSetupSimulatables -= OnSetupSimulatables;
#endif
        }

        void SubscribeToSimulationEvents()
        {
#if UNITY_EDITOR
            EditorOnlyEvents.onSimulationStart += OnSimulationStart;
            EditorOnlyEvents.onSetupSimulatables += OnSetupSimulatables;
#endif
        }

        void OnSetupSimulatables(List<MonoBehaviour> simulatableMonoBehaviours)
        {
            Shader.SetGlobalFloat(k_WorldScaleShaderVariable, MARSSession.GetWorldScale());
            var simulatablesList = CollectionPool<List<ISimulatable>, ISimulatable>.GetCollection();
            m_VisualsRoot.GetComponentsInChildren(simulatablesList);
            simulatableMonoBehaviours.AddRange(simulatablesList.Cast<MonoBehaviour>());
        }

        void OnSimulationStart(List<IFunctionalitySubscriber> functionalitySubscribers, HashSet<TraitRequirement> traitRequirements)
        {
#if UNITY_EDITOR
            DestroyDataVisuals();
            CreateDataVisuals(functionalitySubscribers, traitRequirements);
#endif
        }

        void DestroyDataVisuals()
        {
            if (m_VisualsRoot != null)
            {
                UnityObjectUtils.Destroy(m_VisualsRoot);
            }
        }

#if UNITY_EDITOR
        void CreateDataVisuals(List<IFunctionalitySubscriber> functionalitySubscribers, HashSet<TraitRequirement> traitRequirements)
        {
            var simScene = EditorOnlyDelegates.GetSimulatedContentScene.Invoke();
            if (!simScene.IsValid())
                return;

            if (m_VisualsRoot != null)
                UnityObjectUtils.Destroy(m_VisualsRoot);

            m_VisualsRoot = new GameObject(k_DataVisualsRootName);
            SceneManager.MoveGameObjectToScene(m_VisualsRoot, simScene);
            var root = EditorOnlyDelegates.GetSimulatedContentRoot?.Invoke();
            if (root != null)
                m_VisualsRoot.transform.SetParent(root.transform);

            if (m_PlaneVisualizerPrefab != null)
                PlaneVisualizer = GameObjectUtils.Instantiate(m_PlaneVisualizerPrefab, m_VisualsRoot.transform, false);

            functionalitySubscribers.AddRange(m_VisualsRoot.GetComponentsInChildren<IFunctionalitySubscriber>(true));
            traitRequirements.Add(new TraitRequirement(TraitDefinitions.Plane));
            traitRequirements.Add(new TraitRequirement(TraitDefinitions.Floor));
            traitRequirements.Add(new TraitRequirement(TraitDefinitions.HeightAboveFloor));

            if (!ShowDataVisualsInHierarchy)
                m_VisualsRoot.hideFlags = HideFlags.HideInHierarchy;

            UpdateAllRenderersAndColliders();
        }
#endif

        /// <summary>
        /// Trigger the data visualizers to change their state based on a given rating. If no rating is given for
        /// a particular ID, the rating is considered 0. All implementations of IDataVisual in the children of the
        /// VisualsRoot gameobject will be affected.
        /// </summary>
        /// <param name="ratingsForDataIDs">The ratings for each piece of data as a float, keyed by data ID</param>
        public void VisualizeRatingsForData(Dictionary<int, float> ratingsForDataIDs)
        {
            if (m_VisualsRoot == null || ratingsForDataIDs == null)
                return;

            m_VisualsRoot.GetComponentsInChildren(m_DataVisuals);

            foreach (var dataVisual in m_DataVisuals)
            {
                var currentData = ((Component)dataVisual).GetComponent<Proxy>().currentData;
                if (currentData == null)
                    continue;

                var dataID = currentData.DataID;
                dataVisual.ShowRating(ratingsForDataIDs.TryGetValue(dataID, out var rating) ? rating : 0f);
            }
        }

        /// <summary>
        /// Clear the visualization of data ratings back to the default state.
        /// </summary>
        public void ClearDataRatings()
        {
            if (m_VisualsRoot == null)
                return;

            m_VisualsRoot.GetComponentsInChildren(m_DataVisuals);
            foreach (var dataVisual in m_DataVisuals)
            {
                dataVisual.ClearRating();
            }
        }

        /// <summary>
        /// Add or remove an object that needs data visuals. If there is at least one user requesting data visuals, they will be enabled.
        /// </summary>
        /// <param name="user">The object that is using data visuals, used to avoid duplicate requests.</param>
        /// <param name="enable">Whether the object needs data visuals enabled or not.</param>
        public void RequestDataVisuals(object user, bool enable)
        {
            if (DisableSimulationDataVisuals && enable)
                Debug.LogWarning("Simulation data visuals are disabled. You will not be able to interact with data. Data visuals can be re-enabled in via Edit -> Project Settings -> MARS -> Visual Settings");

            if (enable && !m_DataVisualsUsers.Contains(user))
            {
                m_DataVisualsUsers.Add(user);
            }
            else if (!enable && m_DataVisualsUsers.Contains(user))
            {
                m_DataVisualsUsers.Remove(user);
            }

            UpdateAllRenderersAndColliders();
        }

        void UpdateAllRenderersAndColliders()
        {
            if (m_VisualsRoot == null)
                return;

            var enable = m_DataVisualsUsers.Count > 0;

            var allRenderers = new List<Renderer>();
            m_VisualsRoot.GetComponentsInChildren(allRenderers);
            foreach (var renderer in allRenderers)
            {
                renderer.enabled = enable;
            }

            var allColliders = new List<Collider>();
            m_VisualsRoot.GetComponentsInChildren(allColliders);
            foreach (var collider in allColliders)
            {
                collider.enabled = enable;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS;
using Unity.MARS.Authoring;
using Unity.MARS.MARSUtils;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor.XRTools.Utils;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// Window that allows you to run one shot simulation against all the synthetic environments
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class SimulationTestRunner : EditorWindow, IHasCustomMenu
    {
        class ResultData
        {
            public GUIContent nameLabel;
            public Texture preview;
            public int unmatchedCount;
            public int matchedCount;
        }

        /// <summary>
        /// Window title
        /// </summary>
        public const string WindowTitle = "Sim Test Runner";
        const string k_NotSceneModeString = "Please switch the Simulation View environment mode to Synthetic to simulate";
        const string k_NoMARSSessionString = "The active scene is not a MARS scene, so we can't simulate it. " +
            "To begin, add a MARS Session.";

        static readonly Vector2Int k_OneOneRatio = new Vector2Int(256, 256);
        static readonly Vector2Int k_FourThreeRatio = new Vector2Int(342, 256);

        static readonly string[] k_PreviewRatioOptions = {"1:1", "4:3"};

        static readonly string k_TypeName = typeof(SimulationTestRunner).FullName;

        static SimulationTestRunner s_Instance;

        static bool s_HasRunSimulation;
        static int s_VisitedCount;
        static Vector2Int s_TextureSize;
        static Texture s_FallbackTexture;

        static readonly GUILayoutOption k_MatchLabelWidth = GUILayout.Width(84);
        static readonly GUILayoutOption k_MatchCountWidth = GUILayout.Width(32);

        readonly Dictionary<string, ResultData> m_PreviewTextures = new Dictionary<string, ResultData>();

        Vector2 m_ScrollPosition;
        [NonSerialized]
        bool m_CurrentlySimulating;
        Material m_OriginalSkybox;

        MARSSession m_Session;

        MiniSimulationView m_MiniSimulationView;
        int m_CachedSceneIndex;
        bool m_CachedDataVisualsModuleEnabled;

        readonly Dictionary<int, KeyValuePair<string, bool>> m_IconEnabledOriginalStates = new Dictionary<int, KeyValuePair<string, bool>>();

        static int previewRatioIndex
        {
            get { return EditorPrefsUtils.GetInt(k_TypeName); }
            set { EditorPrefsUtils.SetInt(k_TypeName, value); }
        }

        /// <summary>
        /// Create the <c>SimulationTestRunner</c> window
        /// </summary>
        [MenuItem(MenuConstants.MenuPrefix + WindowTitle, priority = MenuConstants.SimTestRunnerPriority)]
        public static void InitWindow()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = WindowTitle, active = true});
            var instance = GetWindow<SimulationTestRunner>("SimulationTestRunner");
            instance.Show();
        }

        /// <summary>
        /// Add the window to the MARS menu
        /// </summary>
        /// <param name="menu">Menu to add the window option too</param>
        public void AddItemsToMenu(GenericMenu menu) { this.MarsCustomMenuOptions(menu); }

        /// <summary>
        /// This function is called when the object is loaded.
        /// </summary>
        public void OnEnable()
        {
            titleContent.text = WindowTitle;
            SwitchRatio();
            m_OriginalSkybox = RenderSettings.skybox;
            m_Session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            EditorApplication.delayCall += SetupTextures;
            EditorSceneManager.activeSceneChangedInEditMode += OnActiveSceneChange;
        }

        void OnDestroy()
        {
            EditorSceneManager.activeSceneChangedInEditMode -= OnActiveSceneChange;
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = WindowTitle, active = false});
        }

        void OnActiveSceneChange(Scene previous, Scene current)
        {
            SetupTextures();
        }

        void SetupTextures()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            s_FallbackTexture = new Texture2D(s_TextureSize.x, s_TextureSize.y);
            m_PreviewTextures.Clear();
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            if (environmentManager == null)
            {
                EditorApplication.delayCall += SetupTextures;
                return;
            }

            environmentManager.UpdateSimulatedEnvironmentCandidates();
            var environments = environmentManager.EnvironmentPrefabPaths;
            foreach (var path in environments)
            {
                var texture = new Texture2D(s_TextureSize.x, s_TextureSize.y);
                var result = new ResultData
                {
                    nameLabel = new GUIContent(),
                    preview = texture,
                    unmatchedCount = 0
                };

                m_PreviewTextures.Add(path, result);
            }

            var widthMultiplier = s_TextureSize.x + 10;
            minSize = new Vector2(widthMultiplier * 3, 312);
            maxSize = new Vector2(widthMultiplier * environments.Count, 320);
        }

        void StartPreview()
        {
            s_HasRunSimulation = false;
            s_VisitedCount = 0;

            var dataVisualsModule = ModuleLoaderCore.instance.GetModule<DataVisualsModule>();
            m_CachedDataVisualsModuleEnabled = dataVisualsModule.DisableSimulationDataVisuals;
            dataVisualsModule.DisableSimulationDataVisuals = true;

            m_MiniSimulationView = CreateInstance<MiniSimulationView>();
            m_MiniSimulationView.InitMiniSimulationView(s_TextureSize.x, s_TextureSize.y);

            QuerySimulationModule.simulationDone += SaveScreenTask;
            m_CurrentlySimulating = true;
            m_IconEnabledOriginalStates.Clear();
            EditorUtils.ToggleCommonIcons(false, m_IconEnabledOriginalStates);

            EditorEvents.MultiSimulationStarted.Send(new MultiSimulationStartedArgs());

            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            m_CachedSceneIndex = environmentManager.CurrentSyntheticEnvironmentIndex;
            environmentManager.TrySetupNextEnvironmentAndRestartSimulation(true); // start the loop
        }

        void StopPreview()
        {
            s_HasRunSimulation = true;
            s_VisitedCount = int.MaxValue;

            // Need to dispose of mini sim view this also stops usage of sim scene
            UnityObjectUtils.Destroy(m_MiniSimulationView);

            RenderSettings.skybox = m_OriginalSkybox;
            m_CurrentlySimulating = false;
            EditorUtils.ToggleClassIcons(m_IconEnabledOriginalStates);
            QuerySimulationModule.simulationDone -= SaveScreenTask;
            if (RenderSettings.skybox == null)
                RenderSettings.skybox = m_OriginalSkybox;

            var dataVisualsModule = ModuleLoaderCore.instance.GetModule<DataVisualsModule>();
            dataVisualsModule.DisableSimulationDataVisuals = m_CachedDataVisualsModuleEnabled;

            Repaint();

            // Reopen starting scene environment
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            if (environmentManager != null)
            {
                environmentManager.SetSyntheticEnvironment(m_CachedSceneIndex);
                environmentManager.TryRefreshEnvironmentAndRestartSimulation();
            }
        }

        /// <summary>
        /// Window's GUI is drawn here
        /// </summary>
        public void OnGUI()
        {
            if (m_Session == null)
                m_Session = MarsRuntimeUtils.GetMarsSessionInActiveScene();

            var isMarsScene = m_Session != null;
            var isPrefabScene = SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic;

            // Need a active sim view to use the camera.
            var isSimViewActive = SimulationSceneModule.instance != null;
            var isPlaying = Application.isPlaying;

            using (new GUILayout.HorizontalScope())
            {
                using (new EditorGUI.DisabledScope(m_CurrentlySimulating || !isMarsScene || !isPrefabScene || !isSimViewActive || isPlaying))
                {
                    if (GUILayout.Button("Simulate Environments", GUILayout.Width(188)))
                    {
                        var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
                        if (environmentManager != null && environmentManager.TrySetModeAndRestartSimulation(EnvironmentMode.Synthetic))
                            StartPreview();
                    }

                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        previewRatioIndex =
                            EditorGUILayout.Popup(previewRatioIndex, k_PreviewRatioOptions, GUILayout.Width(48));

                        if (check.changed)
                            SwitchRatio();
                    }
                }

                if (!isPrefabScene)
                    EditorGUILayout.HelpBox(k_NotSceneModeString, MessageType.Info);

                if (MarsEditorUtils.NoActiveSessionHintBox(!isMarsScene, k_NoMARSSessionString, MessageType.Info))
                    m_Session = MarsRuntimeUtils.GetMarsSessionInActiveScene();
            }

            using (var scrollScope = new EditorGUILayout.ScrollViewScope(m_ScrollPosition))
            {
                m_ScrollPosition = scrollScope.scrollPosition;

                using (new GUILayout.HorizontalScope())
                {
                    using (new EditorGUI.DisabledScope(!isMarsScene || !isPrefabScene))
                    {
                        var envManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
                        if (envManager == null)
                            return;

                        var envScenes =envManager.EnvironmentPrefabPaths;
                        foreach (var environment in envScenes)
                        {
                            DrawSceneResult(environment);
                            GUILayout.Box("", GUILayout.Width(1), GUILayout.ExpandHeight(true));
                        }
                    }
                }
            }
        }

        // this gets called every time a new environment is done evaluating until all are done
        void SaveScreenTask()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            if (s_VisitedCount >= environmentManager.EnvironmentPrefabPaths.Count)
            {
                StopPreview();
                return;
            }

            var path = environmentManager.EnvironmentPrefabPaths[environmentManager.CurrentSyntheticEnvironmentIndex];
            var result = m_PreviewTextures[path];

            // save the current sim view output as a texture
            result.preview = RenderTextureToPreview(m_MiniSimulationView.SingleFrameRepaint(true));

            result.nameLabel.text = environmentManager.SyntheticEnvironmentName;

            var pipelines = moduleLoader.GetModule<QueryPipelinesModule>();
            var data = pipelines.StandalonePipeline.Data;
            var groupData = pipelines.GroupPipeline.Data;
            // include both standalone proxies and groups as 1 match each
            result.matchedCount = data.UpdatingIndices.Count + groupData.UpdatingIndices.Count;
            result.unmatchedCount = data.CountUnmatched() + groupData.CountUnmatched();

            s_VisitedCount++;
            Repaint();
            environmentManager.TrySetupNextEnvironmentAndRestartSimulation(true);
        }

        void DrawSceneResult(string path)
        {
            using (new GUILayout.VerticalScope())
            {
                ResultData result;
                if (!m_PreviewTextures.TryGetValue(path, out result))
                    return;

                EditorGUILayout.LabelField(result.nameLabel, EditorStyles.boldLabel);

                using (new GUILayout.HorizontalScope(GUILayout.Width(240)))
                {
                    using (new EditorGUI.IndentLevelScope())
                    {
                        EditorGUILayout.LabelField("Matched", k_MatchLabelWidth);
                        EditorGUILayout.LabelField(result.matchedCount.ToString(), k_MatchCountWidth);
                        EditorGUILayout.LabelField("Unmatched", k_MatchLabelWidth);
                        EditorGUILayout.LabelField(result.unmatchedCount.ToString(), k_MatchCountWidth);
                    }
                }

                var rect = GUILayoutUtility.GetRect(s_TextureSize.x, s_TextureSize.y, GUILayout.ExpandWidth(false));
                m_PreviewTextures[path] = result;
                var previewTexture = result.preview != null ? result.preview : s_FallbackTexture;

                GUIContent content;
                if (s_HasRunSimulation)
                    content = new GUIContent(previewTexture, "Click to open this environment scene");
                else
                    content = new GUIContent(previewTexture, "After running simulations, click to open this environment scene");

                if (GUI.Button(rect, content, GUIStyle.none) && s_HasRunSimulation)
                {
                    var marsEnvironmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
                    if (marsEnvironmentManager != null)
                        marsEnvironmentManager.TrySetupSyntheticEnvironmentAndRestartSimulation(path);
                }
            }
        }

        /// <summary>
        /// Converts a render texture to a <c>Texture2D</c> for use in the window
        /// </summary>
        /// <param name="rt">Render texture to convert to a Texture 2D</param>
        /// <returns>New <c>Texture2D</c> from a <c>RenderTexture</c></returns>
        public static Texture2D RenderTextureToPreview(RenderTexture rt)
        {
            var currentRenderTexture = RenderTexture.active;
            var texture = new Texture2D(rt.width, rt.height);
            RenderTexture.active = rt;
            texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            texture.Apply();
            RenderTexture.active = currentRenderTexture;
            return texture;
        }

        void SwitchRatio()
        {
            switch (previewRatioIndex)
            {
                case 0:
                    s_TextureSize = k_OneOneRatio;
                    break;
                case 1:
                    s_TextureSize = k_FourThreeRatio;
                    break;
            }

            SetupTextures();
        }
    }
}

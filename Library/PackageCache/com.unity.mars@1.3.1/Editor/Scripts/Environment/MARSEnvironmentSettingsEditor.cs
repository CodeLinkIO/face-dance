using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.MARS.Data.Synthetic;
using UnityEditor.MARS.Simulation;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(MARSEnvironmentSettings))]
    class MARSEnvironmentSettingsEditor : Editor
    {
        static readonly GUIContent k_AddToSyntheticEnvironmentsContent = new GUIContent("Add to Synthetic Environments",
            "Add the prefab asset for this environment to the set of Synthetic simulation environments " +
            "by adding the 'Environment' label and refreshing simulation environments.");

        static readonly GUIContent k_SaveViewContent = new GUIContent("Save Environment View",
            "Save the default camera settings for this environment scene to match your current scene or sim view camera.");

        static readonly GUIContent k_SaveSimStartingPoseContent = new GUIContent("Save Simulation Starting Pose",
            "Save the simulated device starting pose for this environment to match your current scene or sim view camera.");

        static readonly GUIContent k_SavePlanesFromSimContent = new GUIContent("Save Planes From Simulation",
            "Overwrite generated planes with planes from the current simulation.");

        SerializedProperty m_EnvironmentInfoProperty;
        SerializedProperty m_DefaultCameraWorldPoseProperty;
        SerializedProperty m_DefaultCameraPivotProperty;
        SerializedProperty m_DefaultCameraSizeProperty;
        SerializedProperty m_SimulationStartingPoseProperty;
        SerializedProperty m_EnvironmentBoundsProperty;

        SerializedProperty m_RenderSettingsProperty;
#if INCLUDE_POST_PROCESSING
        SerializedProperty m_PostProcessProfileProperty;
#endif

        void OnEnable()
        {
            m_EnvironmentInfoProperty = serializedObject.FindProperty("m_EnvironmentInfo");
            m_DefaultCameraWorldPoseProperty = m_EnvironmentInfoProperty.FindPropertyRelative("m_DefaultCameraWorldPose");
            m_DefaultCameraPivotProperty = m_EnvironmentInfoProperty.FindPropertyRelative("m_DefaultCameraPivot");
            m_DefaultCameraSizeProperty = m_EnvironmentInfoProperty.FindPropertyRelative("m_DefaultCameraSize");
            m_SimulationStartingPoseProperty = m_EnvironmentInfoProperty.FindPropertyRelative("m_SimulationStartingPose");
            m_EnvironmentBoundsProperty = m_EnvironmentInfoProperty.FindPropertyRelative("m_EnvironmentBounds");

            m_RenderSettingsProperty = serializedObject.FindProperty("m_RenderSettings");
#if INCLUDE_POST_PROCESSING
            m_PostProcessProfileProperty = serializedObject.FindProperty("m_PostProcessProfile");
#endif
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var settings = target as MARSEnvironmentSettings;
            var environmentObject = settings.gameObject;
            var environmentPrefabStage = PrefabStageUtility.GetPrefabStage(environmentObject);

            var prefabAssetPath = environmentPrefabStage != null ?
#if UNITY_2020_1_OR_NEWER
                environmentPrefabStage.assetPath :
#else
                environmentPrefabStage.prefabAssetPath :
#endif
                PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(settings);

            var hasPrefabAsset = !string.IsNullOrEmpty(prefabAssetPath);
            var environmentAsset = hasPrefabAsset ? AssetDatabase.LoadAssetAtPath<Object>(prefabAssetPath) : null;
            var environmentManager = MARSEnvironmentManager.instance;
            using (new EditorGUI.DisabledScope(!hasPrefabAsset || MarsEnvironmentUtils.IsDefaultEnvironment(environmentAsset) ||
                environmentManager.EnvironmentPrefabPaths.Contains(prefabAssetPath)))
            {
                if (GUILayout.Button(k_AddToSyntheticEnvironmentsContent))
                {
                    MarsEnvironmentUtils.EnsureAssetHasEnvironmentLabel(environmentAsset);
                    EditorUtility.SetDirty(environmentAsset);
                    environmentManager.UpdateSimulatedEnvironmentCandidates();
                }
            }

            EditorGUILayout.Separator();

            var sceneView = SceneView.lastActiveSceneView;
            var isSimView = false;
            if (sceneView != null)
                isSimView = sceneView is SimulationView;

            using (var change = new EditorGUI.ChangeCheckScope())
            {
                m_EnvironmentInfoProperty.isExpanded = EditorGUILayout.Foldout(m_EnvironmentInfoProperty.isExpanded,
                    m_EnvironmentInfoProperty.displayName, true);

                if (m_EnvironmentInfoProperty.isExpanded)
                {
                    using (new EditorGUI.IndentLevelScope())
                    {
                        EditorGUILayout.PropertyField(m_DefaultCameraWorldPoseProperty, true);
                        EditorGUILayout.PropertyField(m_DefaultCameraPivotProperty);
                        EditorGUILayout.PropertyField(m_DefaultCameraSizeProperty);
                        using (new EditorGUI.DisabledScope(sceneView == null))
                        {
                            if (GUILayout.Button(k_SaveViewContent))
                            {
                                settings.SetDefaultEnvironmentCamera(sceneView, isSimView);
                                EditorSceneManager.MarkSceneDirty(settings.gameObject.scene);
                            }
                        }

                        EditorGUILayout.PropertyField(m_SimulationStartingPoseProperty, true);
                        EditorGUILayout.PropertyField(m_EnvironmentBoundsProperty);
                        using (new EditorGUI.DisabledScope(sceneView == null))
                        {
                            if (GUILayout.Button(k_SaveSimStartingPoseContent))
                            {
                                settings.SetSimulationStartingPose(sceneView.camera.transform.GetWorldPose(), isSimView);
                                EditorSceneManager.MarkSceneDirty(settings.gameObject.scene);
                            }
                        }
                    }
                }

                EditorGUILayout.PropertyField(m_RenderSettingsProperty, true);

#if INCLUDE_POST_PROCESSING
                EditorGUILayout.PropertyField(m_PostProcessProfileProperty, true);
#endif

                var simulationSettings = SimulationSettings.instance;
                var currentEnvironmentPath = AssetDatabase.GetAssetPath(simulationSettings.EnvironmentPrefab);
                var environmentIsInSimulation = SimulationSceneModule.UsingSimulation &&
                                                simulationSettings.EnvironmentMode == EnvironmentMode.Synthetic &&
                                                environmentPrefabStage != null &&
#if UNITY_2020_1_OR_NEWER
                                                currentEnvironmentPath == environmentPrefabStage.assetPath;
#else
                                                currentEnvironmentPath == environmentPrefabStage.prefabAssetPath;
#endif

                if (!environmentIsInSimulation)
                {
                    EditorGUILayout.HelpBox(
                        "Planes from simulation can only be saved to this environment if it is the active simulation environment.",
                        MessageType.Info);
                }

                using (new EditorGUI.DisabledScope(!environmentIsInSimulation))
                {
                    if (GUILayout.Button(k_SavePlanesFromSimContent))
                        ModuleLoaderCore.instance.GetModule<PlaneGenerationModule>().SavePlanesFromSimulation(environmentObject);
                }

                if (change.changed)
                    serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

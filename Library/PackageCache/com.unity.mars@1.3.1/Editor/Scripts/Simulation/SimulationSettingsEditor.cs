using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(SimulationSettings))]
    class SimulationSettingsEditor : Editor
    {
        SimulationSettingsDrawer m_SettingsDrawer;

        [MenuItem(MenuConstants.MenuPrefix + "Simulation Settings", priority = MenuConstants.SimSettingsPriority)]
        static void SelectSimulationSettings()
        {
            Selection.activeObject = SimulationSettings.instance;
        }

        void OnEnable()
        {
            m_SettingsDrawer = new SimulationSettingsDrawer(serializedObject);

            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
            AssemblyReloadEvents.afterAssemblyReload += Repaint;
            AssemblyReloadEvents.beforeAssemblyReload += Repaint;
        }

        void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            AssemblyReloadEvents.afterAssemblyReload -= Repaint;
            AssemblyReloadEvents.beforeAssemblyReload -= Repaint;
        }

        void OnPlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            Repaint();
        }

        public override void OnInspectorGUI()
        {
            m_SettingsDrawer.InspectorGUI(serializedObject);
        }
    }

    class SimulationSettingsDrawer
    {
        SerializedProperty m_EnvironmentModeProperty;
        SerializedProperty m_EnvironmentPrefabProperty;
        SerializedProperty m_IndependentRecordingProperty;
        SerializedProperty m_FindAllMatchingDataPerQueryProperty;
        SerializedProperty m_TimeToFinalizeQueryDataChangeProperty;
        SerializedProperty m_ShowSimulatedDataProperty;
        SerializedProperty m_ShowSimulatedEnvironmentProperty;
        SerializedProperty m_AutoResetDevicePoseProperty;
        SerializedProperty m_AutoSyncWithSceneChangesProperty;

        static readonly GUIContent k_RecordingContent = new GUIContent("Recording");

        public SimulationSettingsDrawer(SerializedObject serializedObject)
        {
            m_EnvironmentModeProperty = serializedObject.FindProperty("m_EnvironmentMode");
            m_EnvironmentPrefabProperty = serializedObject.FindProperty("m_EnvironmentPrefab");
            m_IndependentRecordingProperty = serializedObject.FindProperty("m_IndependentRecording");
            m_FindAllMatchingDataPerQueryProperty = serializedObject.FindProperty("m_FindAllMatchingDataPerQuery");
            m_TimeToFinalizeQueryDataChangeProperty = serializedObject.FindProperty("m_TimeToFinalizeSceneModification");
            m_ShowSimulatedEnvironmentProperty = serializedObject.FindProperty("m_ShowSimulatedEnvironment");
            m_ShowSimulatedDataProperty = serializedObject.FindProperty("m_ShowSimulatedData");
            m_AutoResetDevicePoseProperty = serializedObject.FindProperty("m_AutoResetDevicePose");
            m_AutoSyncWithSceneChangesProperty = serializedObject.FindProperty("m_AutoSyncWithSceneChanges");
        }

        public void InspectorGUI(SerializedObject serializedObject)
        {
            serializedObject.Update();
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            using (new EditorGUI.DisabledScope(EditorApplication.isPlayingOrWillChangePlaymode))
            {
                using (var change = new EditorGUI.ChangeCheckScope())
                {
                    EnvironmentMode environmentMode;

                    using (new EditorGUILayout.HorizontalScope())
                    {
                        GUILayout.Label(new GUIContent(m_EnvironmentModeProperty.displayName,
                            m_EnvironmentModeProperty.tooltip), GUILayout.Width(MarsEditorGUI.SettingsLabelWidth));

                        environmentMode = (EnvironmentMode) EditorGUILayout.Popup(
                            m_EnvironmentModeProperty.enumValueIndex,
                            MARSEnvironmentManager.ModeTypes, MarsEditorGUI.InternalEditorStyles.Popup);
                    }

                    if (change.changed)
                    {
                        var environmentModule = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
                        if (environmentModule == null)
                        {
                            m_EnvironmentModeProperty.enumValueIndex = (int)environmentMode;
                            serializedObject.ApplyModifiedProperties();
                        }
                        else if (environmentModule.TrySetModeAndRestartSimulation(environmentMode))
                        {
                            m_EnvironmentModeProperty.enumValueIndex = (int)environmentMode;
                            serializedObject.ApplyModifiedProperties();
                        }
                    }
                }

                switch (m_EnvironmentModeProperty.enumValueIndex)
                {
                    case (int)EnvironmentMode.Synthetic:
                        DrawSyntheticEnvironmentGUI(serializedObject);
                        break;

                    case (int)EnvironmentMode.Live:
                        DrawLiveVideoGUI();
                        break;

                    case (int)EnvironmentMode.Recorded:
                        DrawCapturedVideoGUI(serializedObject);
                        break;

                    case (int)EnvironmentMode.Custom:
                        DrawCustomEnvironmentGUI();
                        break;
                }
            }

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(m_FindAllMatchingDataPerQueryProperty);
            EditorGUILayout.PropertyField(m_TimeToFinalizeQueryDataChangeProperty);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_ShowSimulatedEnvironmentProperty);
            EditorGUILayout.PropertyField(m_ShowSimulatedDataProperty);
            if (EditorGUI.EndChangeCheck())
            {
                MARSEnvironmentManager.SetSimDataVisibility(m_ShowSimulatedDataProperty.boolValue);
                MARSEnvironmentManager.SetSimEnvironmentVisibility(m_ShowSimulatedEnvironmentProperty.boolValue);
            }

            EditorGUILayout.PropertyField(m_AutoResetDevicePoseProperty);
            EditorGUILayout.PropertyField(m_AutoSyncWithSceneChangesProperty);

            serializedObject.ApplyModifiedProperties();
        }

        void DrawSyntheticEnvironmentGUI(SerializedObject serializedObject)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            if (environmentManager == null)
                return;

            using (var change = new EditorGUI.ChangeCheckScope())
            {
                var envPrefab = EditorGUILayout.ObjectField(
                    new GUIContent(m_EnvironmentPrefabProperty.displayName, m_EnvironmentPrefabProperty.tooltip),
                    m_EnvironmentPrefabProperty.objectReferenceValue, typeof(GameObject), false) as GameObject;

                if (change.changed && environmentManager.TrySaveEnvironmentModificationsDialog())
                {
                    m_EnvironmentPrefabProperty.objectReferenceValue = envPrefab;
                    serializedObject.ApplyModifiedProperties();
                    environmentManager.ForceRefreshEnvironmentAndRestartSimulation();
                }
            }

            if (!environmentManager.SyntheticEnvironmentsExist)
                EditorGUILayout.HelpBox("Mark prefab in your project with the 'Environment' asset label " +
                    "for them to appear as simulation scenes. These prefabs should contain objects with " +
                    "SimulatedPlane components, or another simulated data type.", MessageType.Info);

            if (GUILayout.Button("Update Simulated Prefab Candidates"))
                environmentManager.UpdateSimulatedEnvironmentCandidates();

            var recordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            if (recordingManager == null)
                return;

            recordingManager.ValidateSyntheticRecordings();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var index = EditorGUILayout.Popup(k_RecordingContent, recordingManager.CurrentSyntheticRecordingOptionIndex,
                    recordingManager.SyntheticRecordingOptionContents);

                if (check.changed)
                    recordingManager.SetRecordingOptionAndRestartSimulation(index);
            }
        }

        static void DrawLiveVideoGUI()
        {
            DrawCommonVideoGUI();
        }

        void DrawCapturedVideoGUI(SerializedObject serializedObject)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_IndependentRecordingProperty, new GUIContent("Recording"));
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                MARSEnvironmentManager.instance.TryRefreshEnvironmentAndRestartSimulation();
            }

            DrawCommonVideoGUI();
        }

        static void DrawCommonVideoGUI()
        {
            if (!SceneWatchdogModule.instance.currentSceneIsFaceScene)
            {
                EditorGUILayout.HelpBox("To use the WebCam, open a scene with face subscribers.", MessageType.Info);
            }
            else
            {
                var querySimulationModule = QuerySimulationModule.instance;
                if (querySimulationModule.simulatingTemporal)
                {
                    if (GUILayout.Button("Stop"))
                    {
                        querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.SingleFrameMode);
                        querySimulationModule.RestartSimulationIfNeeded(true);
                    }
                }
                else
                {
                    if (GUILayout.Button("Start"))
                        querySimulationModule.StartTemporalSimulation();
                }
            }
        }

        static void DrawCustomEnvironmentGUI()
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            if (environmentManager == null || !environmentManager.HasCustomModeSettings)
                return;

            var customModeSettings = environmentManager.CustomModeSettings;

            using (var change = new EditorGUI.ChangeCheckScope())
            {
                var index = EditorGUILayout.Popup(new GUIContent(customModeSettings.EnvironmentModeName),
                    customModeSettings.ActiveEnvironmentIndex, customModeSettings.EnvironmentSwitchingContents);

                if (change.changed)
                {
                    environmentManager.TrySetupEnvironmentAndRestartSimulation(index);
                    EditorUtility.SetDirty(SimulationSettings.instance);
                }
            }
        }
    }
}

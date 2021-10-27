using System;
using Unity.MARS;
using Unity.MARS.Data;
using Unity.MARS.Landmarks;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Authoring;
using UnityEngine;

namespace UnityEditor.MARS
{
    [CustomEditor(typeof(LandmarkController))]
    class LandmarkControllerEditor : Editor
    {
        const string k_SettingsDataField = "m_Settings";
        const string k_OutputDataField = "m_Output";
        const string k_SourceDataField = "m_Source";
        const string k_DefinitionNameField = "m_LandmarkDefinitionName";
        const string k_SettingsFoldoutLabel = "Update Settings";
        const string k_OutputTypeLabel = "Type";
        const string k_OutputDropdownButtonDefaultLabel = "Output";
        const string k_DefinitionNameLabel = "Location";
        const string k_DefinitionDropdownButtonDefaultLabel = "None";
        const string k_SourceActionNoParentWarning = "The source action is not a child of a Real World Object and will not get any data.";
        const string k_NoSourceWarningLabel = "There is no source set for this landmark.";
        const string k_ModifyUndoLabel = "Modify landmark";
        const string k_AddLandmarkButtonText = "Add Landmark...";

        const int k_AddDefaultComponentButtonHeight = 38;
        static readonly string[] k_DontDraw = { "m_Script", k_SettingsDataField, k_OutputDataField, k_SourceDataField, k_DefinitionNameField };

        SerializedProperty m_SourceProperty;
        SerializedProperty m_SettingsProperty;
        SerializedProperty m_OutputProperty;

        class Styles
        {
            public GUIContent noLandmarksMenuItemContent;
            public GUIContent addDefaultCompButtonContent;

            public Styles()
            {
                noLandmarksMenuItemContent = new GUIContent("No landmarks defined");
                addDefaultCompButtonContent = new GUIContent("Add Default", "Add a new component that is the correct type for this landmark.");
            }
        }

        static Styles s_Styles;
        static Styles styles { get { return s_Styles ?? (s_Styles = new Styles()); } }
        static bool s_ShowSettingsFoldout;

        public void OnEnable()
        {
            m_SourceProperty = serializedObject.FindProperty(k_SourceDataField);
            m_SettingsProperty = serializedObject.FindProperty(k_SettingsDataField);
            m_OutputProperty = serializedObject.FindProperty(k_OutputDataField);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_SourceProperty);

            var landmarkController = (LandmarkController)target;
            var sourceComponent = (m_SourceProperty.objectReferenceValue as Component);
            DrawSourceInfo(sourceComponent, landmarkController);

            var sourceInterface = landmarkController.source; // Using property because it converts the reference to interface
            var output = m_OutputProperty.objectReferenceValue as Component;
            if (sourceInterface != null)
            {
                DrawLandmarkDefinitionDropdownButton(sourceInterface, landmarkController);
                DrawLandmarkOutputDropdownButton(output, landmarkController);
                using (new EditorGUI.IndentLevelScope())
                {
                    DrawOutputInfo(m_OutputProperty, landmarkController);
                    DrawSettingsInfo(m_SettingsProperty, landmarkController);
                }
            }

            DrawControllerSettings(serializedObject);
            DrawAddNewLandmarkButtonForOutput(output);

            serializedObject.ApplyModifiedProperties();
        }

        static void DrawAddNewLandmarkButtonForOutput(Component output)
        {
            if (output != null)
            {
                var outputAsLandmarkSource = output as ICalculateLandmarks;
                if (outputAsLandmarkSource != null)
                    DrawAddLandmarkButton(outputAsLandmarkSource);
            }
        }

        static void DrawControllerSettings(SerializedObject controllerObject)
        {
            s_ShowSettingsFoldout = EditorGUILayout.Foldout(s_ShowSettingsFoldout, k_SettingsFoldoutLabel, true);
            if (s_ShowSettingsFoldout)
            {
                using (new EditorGUI.IndentLevelScope())
                    DrawPropertiesExcluding(controllerObject, k_DontDraw);
            }
        }

        static void DrawSettingsInfo(SerializedProperty settingsProperty, LandmarkController landmarkController)
        {
            var definition = landmarkController.landmarkDefinition;
            if (definition != null && definition.settingsType != null)
            {
                EditorGUILayout.PropertyField(settingsProperty);
                var landmarkSettings = settingsProperty.objectReferenceValue as Component;
                if (landmarkSettings != null && landmarkSettings.GetType() != definition.settingsType)
                {
                    // Settings is the wrong type, try to get component on it to find the right type
                    landmarkSettings = landmarkSettings.GetComponent(definition.settingsType);
                    settingsProperty.objectReferenceValue = landmarkSettings;
                }

                if (landmarkSettings == null)
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.HelpBox("Settings component is invalid.", MessageType.Error);
                        if (GUILayout.Button(styles.addDefaultCompButtonContent, GUILayout.Height(k_AddDefaultComponentButtonHeight)))
                            settingsProperty.objectReferenceValue = Undo.AddComponent(landmarkController.gameObject, definition.settingsType);
                    }
                }
            }
        }

        static void DrawOutputInfo(SerializedProperty outputProperty, LandmarkController landmarkController)
        {
            EditorGUILayout.PropertyField(outputProperty);
            var output = outputProperty.objectReferenceValue as Component;
            var validOutputType = false;
            var definition = landmarkController.landmarkDefinition;
            if (definition == null)
                return;

            if (output != null && definition.outputTypes != null)
            {
                var currentOutputType = output.GetType();
                foreach (var validType in definition.outputTypes)
                {
                    if (validType == currentOutputType)
                        validOutputType = true;
                }
            }

            if (!validOutputType)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.HelpBox("Output component is invalid.", MessageType.Error);
                    if (GUILayout.Button(styles.addDefaultCompButtonContent, GUILayout.Height(k_AddDefaultComponentButtonHeight)))
                    {
                        EditorApplication.delayCall += () =>
                        {
                            Undo.RegisterFullObjectHierarchyUndo(landmarkController.gameObject, k_ModifyUndoLabel);
                            landmarkController.SetOutputType(definition.outputTypes[0]);
                        };
                    }
                }
            }
        }

        static void DrawSourceInfo(Component sourceComponent, LandmarkController landmarkController)
        {
            if (sourceComponent == null)
            {
                EditorGUILayout.HelpBox(k_NoSourceWarningLabel, MessageType.Warning);
            }
            else
            {
                var sourceAction = sourceComponent as IAction;
                if (sourceAction != null && sourceComponent.gameObject == landmarkController.gameObject)
                {
                    var rwoInParent = sourceComponent.GetComponentInParent<Proxy>();
                    if (rwoInParent == null)
                        EditorGUILayout.HelpBox(k_SourceActionNoParentWarning, MessageType.Warning);
                }
            }
        }

        static void DrawLandmarkDefinitionDropdownButton(ICalculateLandmarks landmarkSource, LandmarkController landmarkController)
        {
            var definition = landmarkController.landmarkDefinition;
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PrefixLabel(k_DefinitionNameLabel);

                var buttonLabel = ObjectNames.NicifyVariableName(definition == null ? k_DefinitionDropdownButtonDefaultLabel : definition.name);
                if (EditorGUILayout.DropdownButton(new GUIContent(buttonLabel), FocusType.Keyboard))
                {
                    var menu = new GenericMenu();
                    const string baseTitle = "";
                    foreach (var availableDefinition in landmarkSource.AvailableLandmarkDefinitions)
                    {
                        var title = baseTitle + ObjectNames.NicifyVariableName(availableDefinition.name);

                        var currentlySelected = definition != null && string.Equals(availableDefinition.name, definition.name);
                        menu.AddItem(new GUIContent(title), currentlySelected, () =>
                        {
                            Undo.RegisterFullObjectHierarchyUndo(landmarkController.gameObject, k_ModifyUndoLabel);
                            landmarkController.source = landmarkSource;
                            landmarkController.landmarkDefinition = availableDefinition;
                        });
                    }

                    menu.ShowAsContext();
                }
            }
        }

        static void DrawLandmarkOutputDropdownButton(Component currentOutput, LandmarkController landmarkController)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.PrefixLabel(k_OutputTypeLabel);
                var buttonLabel = ObjectNames.NicifyVariableName(currentOutput != null ? TrimLandmarkOutputName(currentOutput.GetType().Name) : k_OutputDropdownButtonDefaultLabel);

                if (EditorGUILayout.DropdownButton(new GUIContent(buttonLabel), FocusType.Keyboard))
                {
                    var menu = new GenericMenu();
                    var definition = landmarkController.landmarkDefinition;
                    if (definition != null)
                    {
                        foreach (var outputType in definition.outputTypes)
                        {
                            var showChecked = currentOutput != null && currentOutput.GetType() == outputType;
                            var outputTypeName = TrimLandmarkOutputName(outputType.Name);
                            menu.AddItem(new GUIContent(outputTypeName), showChecked, () =>
                            {
                                Undo.RegisterFullObjectHierarchyUndo(landmarkController.gameObject, k_ModifyUndoLabel);
                                landmarkController.SetOutputType(outputType);
                            });
                        }

                        menu.ShowAsContext();
                    }
                }
            }
        }

        internal static string TrimLandmarkOutputName(string fullTypeName)
        {
            const string remove = "LandmarkOutput";
            return fullTypeName.StartsWith(remove) ? fullTypeName.Substring(remove.Length) : fullTypeName;
        }

        public static void DrawAddLandmarkButton(ICalculateLandmarks landmarkSource)
        {
            if (landmarkSource == null)
                return;

            if (GUILayout.Button(k_AddLandmarkButtonText))
            {
                ShowLandmarksMenu(landmarkSource);
            }
        }

        internal static void ShowLandmarksMenu(ICalculateLandmarks landmarkSource, Action<LandmarkController> onLandmarkCreated = null)
        {
            if (landmarkSource == null)
                return;

            var landmarkMenu = new GenericMenu();
            var definitions = landmarkSource.AvailableLandmarkDefinitions;
            if (definitions == null || definitions.Count == 0)
            {
                landmarkMenu.AddDisabledItem(styles.noLandmarksMenuItemContent);
            }
            else
            {
                for (var i = 0; i < definitions.Count; i++)
                {
                    var definition = definitions[i];
                    foreach (var outputType in definition.outputTypes)
                    {
                        var outputName = TrimLandmarkOutputName(outputType.Name);
                        var subMenuName = definition.outputTypes.Length > 1 ? "/" + outputName : "";
                        var title = EditorGUIUtils.GetContent(ObjectNames.NicifyVariableName(definition.name) + subMenuName);
                        landmarkMenu.AddItem(title, false, () =>
                        {
                            var landmark = landmarkSource.CreateLandmarkAsChild(definition, outputType);

                            var entityVisualsModule = ModuleLoaderCore.instance.GetModule<EntityVisualsModule>();
                            var marsEntity = (landmarkSource as MonoBehaviour)?.GetComponentInParent<MARSEntity>();
                            if (entityVisualsModule != null && marsEntity != null)
                                entityVisualsModule.InvalidateVisual(marsEntity);

                            EditorGUIUtility.PingObject(landmark.gameObject);
                            onLandmarkCreated?.Invoke(landmark);
                        });
                    }
                }
            }

            landmarkMenu.ShowAsContext();
        }
    }
}

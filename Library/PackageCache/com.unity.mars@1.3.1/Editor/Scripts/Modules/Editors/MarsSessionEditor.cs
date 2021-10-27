using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(MARSSession))]
    class MARSSessionEditor : Editor
    {
        class Styles
        {
            public readonly GUIContent scaleEntityPositionsContent;
            public readonly GUIContent scaleEntityChildrenContent;
            public readonly GUIContent scaleSceneAudioContent;
            public readonly GUIContent scaleSceneLightingContent;
            public readonly GUIContent scaleClippingPlanesContent;
            public readonly GUIContent advancedSettingsContent;
            public readonly GUIContent functionalityIslandContent;
            public readonly GUIContent requestedMaximumFaceCountContent;
            public readonly GUIContent deleteButtonContent;

            public Styles()
            {
                scaleEntityPositionsContent = new GUIContent("Scale entity positions",
                    "When enabled, changing the world scale will also scale the world positions of all MARSEntities in the scene.");
                scaleEntityChildrenContent = new GUIContent("Scale entity children",
                    "When enabled, changing the world scale will also scale the local positions and scales of all children of MARSEntities in the scene.");
                scaleSceneAudioContent = new GUIContent("Scale audio",
                    "When enabled, changing the world scale will also scale the range of audio sources and reverb zones in the scene.");
                scaleSceneLightingContent = new GUIContent("Scale lighting",
                    "When enabled, changing the world scale will also scale the range of lights in the scene.");
                scaleClippingPlanesContent = new GUIContent("Scale clipping planes",
                    "When enabled, changing the world scale will also scale the MARS camera's clipping planes.");
                advancedSettingsContent = new GUIContent("Advanced", "Advanced settings.");
                functionalityIslandContent = new GUIContent("Functionality island", "Set this to override the default Functionality Island when this scene is loaded.");
                requestedMaximumFaceCountContent = new GUIContent("Requested Max Face Count",
                    "Sets the requested number of faces to track when face tracking is available. -1 for Platform Maximum.");
                deleteButtonContent = new GUIContent("Delete");
            }
        }

        static readonly string k_TypeName = typeof(MARSSessionEditor).FullName;

        const string k_WorldScaleLabel = "World Scale";
        const float k_IconSize = 32f;
        const float k_ScaleInputWidth = 52f;
        const float k_ScaleSliderSnapThreshold = 0.015f;
        const int k_ScalePrecision = 1000;
        const int k_LabelOffset = 2; // Foldout elements are indented 2px farther than Label elements.

        const string k_NoSessionMessage = "Current scene does not have a MARS Session. Add a MARS Session to set world scale";

        const string k_EntityScaleWarning = "In order to preserve the relationships between entity positions and their condition parameters, " +
                                            "changing the world scale without scaling entity positions will scale all spatial condition parameters.";

       

        const string k_NoImageMessage = "\n\n      None    ";
        const string k_TexturePropName = "m_Texture";
        const string k_GuidLowPropName = "m_MarkerDefinitionId.m_GuidLow";
        const string k_GuidHighPropName = "m_MarkerDefinitionId.m_GuidHigh";

        static Styles s_Styles;

        bool m_DisplayingAdvancedOptions;
        bool m_DisplayingImageMarkerLibrary;

        int[] m_MarkerSizeOptionIndices = {};

        SerializedObject m_MARSWorldScaleSettingsObject;
        SerializedObject m_LibrarySerializedObject;
        SerializedProperty m_ScaleEntityPositionsProperty;
        SerializedProperty m_ScaleEntityChildrenProperty;
        SerializedProperty m_ScaleSceneAudioProperty;
        SerializedProperty m_ScaleSceneLightingProperty;
        SerializedProperty m_ScaleClippingPlanesProperty;
        SerializedProperty m_RequirementsProperty;
        SerializedProperty m_IslandProperty;
        SerializedProperty m_MarkerLibraryProperty;
        SerializedProperty m_LibraryMarkersProperty;
        SerializedProperty m_RequestedMaximumFaceCountProperty;


        // Delay creation of Styles till first access
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        static bool worldScaleExpanded
        {
            get => EditorPrefsUtils.GetBool(k_TypeName, true);
            set => EditorPrefsUtils.SetBool(k_TypeName, value);
        }

        void OnEnable()
        {
            m_MARSWorldScaleSettingsObject = new SerializedObject(MarsWorldScaleSettings.instance);
            m_ScaleEntityPositionsProperty = m_MARSWorldScaleSettingsObject.FindProperty("m_ScaleEntityPositions");
            m_ScaleEntityChildrenProperty = m_MARSWorldScaleSettingsObject.FindProperty("m_ScaleEntityChildren");
            m_ScaleSceneAudioProperty = m_MARSWorldScaleSettingsObject.FindProperty("m_ScaleSceneAudio");
            m_ScaleSceneLightingProperty = m_MARSWorldScaleSettingsObject.FindProperty("m_ScaleSceneLighting");
            m_ScaleClippingPlanesProperty = m_MARSWorldScaleSettingsObject.FindProperty("m_ScaleClippingPlanes");
            m_RequirementsProperty = serializedObject.FindProperty("m_Requirements");
            m_IslandProperty = serializedObject.FindProperty("m_Island");
            m_MarkerLibraryProperty = serializedObject.FindProperty("m_MarkerLibrary");
            m_RequestedMaximumFaceCountProperty = serializedObject.FindProperty("m_RequestedMaximumFaceCount");

            var loadedMarkerLibrary = m_MarkerLibraryProperty.objectReferenceValue as MarsMarkerLibrary;
            if (loadedMarkerLibrary != null)
                UpdateMarkerLibraryData(loadedMarkerLibrary);
        }

        void OnDisable()
        {
            MarsWorldScaleModule.worldScaleControlsShown = false;
            Tools.hidden = false;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            Tools.hidden = Selection.activeGameObject == ((MARSSession)target).gameObject && Tools.current == Tool.Scale;

            EditorGUILayout.Space();
            EditorGUIUtils.DrawSplitter();

            worldScaleExpanded = EditorGUIUtils.DrawFoldoutUI(
                worldScaleExpanded,
                true,
                k_WorldScaleLabel,
                MarsEditorGUI.Styles.HeaderToggle,
                MarsEditorGUI.Styles.HeaderLabel,
                OnWorldScaleGUI,
                RecordWorldScaleFoldoutAnalyticsEvent,
                OpenWorldScaleHelp,
                OpenWorldScalePopupOptions,
                AddWorldScaleItemsToTabMenu
            );

            MarsWorldScaleModule.worldScaleControlsShown = worldScaleExpanded;

            EditorGUIUtils.DrawSplitter();

            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.PropertyField(m_RequirementsProperty, true);
            }

            m_DisplayingAdvancedOptions = EditorGUILayout.Foldout(m_DisplayingAdvancedOptions,
                styles.advancedSettingsContent, true);
            if (m_DisplayingAdvancedOptions)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    EditorGUILayout.PropertyField(m_IslandProperty, styles.functionalityIslandContent);
                }
            }

            Rect labelWidthRect;
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("", GUILayout.Width(EditorGUIUtility.labelWidth));
                labelWidthRect = GUILayoutUtility.GetLastRect();
                EditorGUILayout.PropertyField(m_MarkerLibraryProperty, new GUIContent(""));
            }

            if (m_MarkerLibraryProperty.objectReferenceValue != null)
            {
                m_DisplayingImageMarkerLibrary = EditorGUI.Foldout(labelWidthRect, m_DisplayingImageMarkerLibrary,
                    m_MarkerLibraryProperty.displayName, true);

                if (m_DisplayingImageMarkerLibrary)
                {
                    GUILayout.Space(5);
                    EditorGUIUtils.DrawSplitter();
                    GUILayout.Space(2);

                    DrawMarkerLibrary();
                }
            }
            else
            {
                labelWidthRect.x += k_LabelOffset;
                GUI.Label(labelWidthRect, m_MarkerLibraryProperty.displayName);
            }

            DrawRequestedMaximumFaceCount();

            serializedObject.ApplyModifiedProperties();
        }

        void SyncMarkerLibraryOptionIndexesWithLoadedLibrary(MarsMarkerLibrary loadedLib)
        {
            if (m_MarkerSizeOptionIndices.Length != loadedLib.Count)
                m_MarkerSizeOptionIndices = new int[loadedLib.Count];

            for (var i = 0; i < loadedLib.Count; i++)
            {
                m_MarkerSizeOptionIndices[i] = MarkerConstants.GetSelectedMarsMarkerSizeOption(
                    loadedLib[i].Size);
            }
        }

        void DrawRequestedMaximumFaceCount()
        {
            EditorGUILayout.PropertyField(m_RequestedMaximumFaceCountProperty, styles.requestedMaximumFaceCountContent);
            if (m_RequestedMaximumFaceCountProperty.intValue < -1)
            {
                m_RequestedMaximumFaceCountProperty.intValue = -1;
            }
        }

        void DrawMarkerLibrary()
        {
            const int imageMarkerTextureSize = 70;
            const int spaceBetweenGUISplitters = 5;

            var loadedMarkerLibrary = m_MarkerLibraryProperty.objectReferenceValue as MarsMarkerLibrary;
            if (loadedMarkerLibrary == null)
                return;

            if (m_LibrarySerializedObject == null || loadedMarkerLibrary != m_LibrarySerializedObject.targetObject as MarsMarkerLibrary)
            {
                UpdateMarkerLibraryData(loadedMarkerLibrary);
            }
            else if (m_MarkerSizeOptionIndices.Length != loadedMarkerLibrary.Count)
            {
                // Sync selected options with current image marker library in case user has other inspector and adds/removes
                // image markers from the current library.
                SyncMarkerLibraryOptionIndexesWithLoadedLibrary(loadedMarkerLibrary);
            }

            m_LibrarySerializedObject.Update();
            if (m_LibraryMarkersProperty == null)
                return;

            using (var changed = new EditorGUI.ChangeCheckScope())
            {
                for (var i = 0; i < m_LibraryMarkersProperty.arraySize; i++)
                {
                    GUILayout.Space(spaceBetweenGUISplitters);

                    using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                    {
                        var markerSizeOptionIndex = m_MarkerSizeOptionIndices[i];
                        var markerDefinitionProperty = m_LibraryMarkersProperty.GetArrayElementAtIndex(i);

                        var markerTextureProperty = markerDefinitionProperty.FindPropertyRelative(k_TexturePropName);
                        var textureToDraw = markerTextureProperty.objectReferenceValue as Texture;

                        var imageRect = EditorGUILayout.GetControlRect(false, imageMarkerTextureSize,
                            GUILayout.Width(imageMarkerTextureSize));
                        if (textureToDraw != null)
                            GUI.DrawTexture(imageRect, textureToDraw, ScaleMode.ScaleToFit);
                        else
                            EditorGUI.HelpBox(imageRect, k_NoImageMessage, MessageType.None);

                        using (new EditorGUILayout.VerticalScope(GUIStyle.none))
                        {
                            markerSizeOptionIndex = ImageMarkerEditorUtils.DrawImageMarkerInfoContentsAtIndex(
                                markerDefinitionProperty, markerSizeOptionIndex);
                            m_MarkerSizeOptionIndices[i] = markerSizeOptionIndex;

                            // Draw read only image marker id
                            var guidLow = (ulong)markerDefinitionProperty.FindPropertyRelative(k_GuidLowPropName).longValue;
                            var guidHigh = (ulong)markerDefinitionProperty.FindPropertyRelative(k_GuidHighPropName).longValue;
                            var guidComp = GuidUtil.Compose(guidLow, guidHigh);

                            MarkerDefinitionSelectorDrawer.DrawGuid(guidComp.ToString());
                        }
                    }

                    if (GUILayout.Button(styles.deleteButtonContent, GUILayout.Width(imageMarkerTextureSize)))
                    {
                        m_LibraryMarkersProperty.DeleteArrayElementAtIndex(i);
                        SyncMarkerLibraryOptionIndexesWithLoadedLibrary(loadedMarkerLibrary);
                    }

                    GUILayout.Space(spaceBetweenGUISplitters);
                    EditorGUIUtils.DrawSplitter();
                }

                if (changed.changed)
                {
                    m_LibrarySerializedObject.ApplyModifiedProperties();
                    serializedObject.ApplyModifiedProperties();

                    var markerLibraryModule = ModuleLoaderCore.instance.GetModule<MARSMarkerLibraryModule>();
                    if (changed.changed && markerLibraryModule != null)
                        markerLibraryModule.UpdateMarkerDataFromLibraries();
                }
            }
        }

        void OnWorldScaleGUI()
        {
            m_MARSWorldScaleSettingsObject.Update();
            using (new EditorGUILayout.VerticalScope(MarsEditorGUI.Styles.NoMarginScopeAlignment))
            {
                var isSession = MarsRuntimeUtils.GetMarsSessionInActiveScene() != null;
                var spacePadding = MarsEditorGUI.Styles.AreaAlignmentWithPadding.padding.vertical;

                GUILayout.Space(spacePadding);

                if (isSession )
                    DrawScaleArea();

                DrawWorldScaleHelpArea(isSession);
                GUILayout.Space(spacePadding);
            }
        }

        static void DrawScaleArea()
        {
            using (new EditorGUILayout.VerticalScope(MarsEditorGUI.Styles.NoVerticalMarginScopeAlignment))
            {
                var scaleModule = MarsWorldScaleModule.instance;

                var worldScale = MarsWorldScaleModule.GetWorldScale();
                using (new EditorGUI.DisabledScope(EditorApplication.isPlayingOrWillChangePlaymode))
                {
                    using (new EditorGUILayout.HorizontalScope(MarsEditorGUI.Styles.NoVerticalMarginScopeAlignment))
                    {
                        using (new EditorGUILayout.VerticalScope())
                        {
                            Rect minScaleIconRect, maxScaleIconRect;
                            using (new EditorGUILayout.HorizontalScope())
                            {
                                GUILayoutOption[] layoutOptions = { GUILayout.Width(k_IconSize), GUILayout.Height(k_IconSize) };
                                GUILayout.Box(scaleModule.smallScaleIcon.scaleIcon, GUIStyle.none, layoutOptions);
                                minScaleIconRect = GUILayoutUtility.GetLastRect();
                                GUILayout.FlexibleSpace();
                                GUILayout.Box(scaleModule.largeScaleIcon.scaleIcon, GUIStyle.none, layoutOptions);
                                maxScaleIconRect = GUILayoutUtility.GetLastRect();
                            }

                            // Since the user can override their min & max scale exponents, here we calculate the fraction
                            // between min & max where 0 falls, so we know where to position the 1:1 scale icon & slider snap.
                            var scaleExponentRange = (float)Mathf.Abs(scaleModule.maxScaleExponent - scaleModule.minScaleExponent);
                            var zeroPoint = Mathf.Abs(scaleModule.minScaleExponent) / scaleExponentRange;
                            var scaleOneIconRect = minScaleIconRect;
                            scaleOneIconRect.x = minScaleIconRect.x + (maxScaleIconRect.x - minScaleIconRect.x) * zeroPoint;

                            if (scaleModule.visualsZeroIndex > -1)
                                GUI.Box(scaleOneIconRect, scaleModule.scaleOneIcon.scaleIcon, GUIStyle.none);

                            using (var change = new EditorGUI.ChangeCheckScope())
                            {
                                var sliderValue = GUILayout.HorizontalSlider(Mathf.InverseLerp(
                                    scaleModule.minScaleExponent, scaleModule.maxScaleExponent,
                                    Mathf.Log10(worldScale)), 0f, 1f);

                                if (Mathf.Abs(sliderValue - zeroPoint) < k_ScaleSliderSnapThreshold)
                                    sliderValue = zeroPoint;

                                if (change.changed)
                                {
                                    worldScale = Mathf.Pow(10f, Mathf.Lerp(scaleModule.minScaleExponent,
                                        scaleModule.maxScaleExponent, sliderValue));
                                    scaleModule.AdjustWorldScale(worldScale);
                                }
                            }
                        }

                        using (new EditorGUILayout.VerticalScope())
                        {
                            GUILayout.Space(k_IconSize + MarsEditorGUI.Styles.SingleLineButton.padding.vertical);

                            using (var change = new EditorGUI.ChangeCheckScope())
                            {
                                var roundScale = Mathf.Round(worldScale * k_ScalePrecision) / k_ScalePrecision;
                                var fieldValue = EditorGUILayout.DelayedFloatField(roundScale,
                                    GUILayout.Width(k_ScaleInputWidth));

                                if (change.changed)
                                {
                                    worldScale = Mathf.Clamp(fieldValue, scaleModule.MinScale, scaleModule.MaxScale);
                                    scaleModule.AdjustWorldScale(worldScale);
                                }
                            }
                        }
                    }

                    scaleModule.UpdateScaleReference();
                }
            }
        }

        static void DrawWorldScaleHelpArea(bool isMARSSession)
        {
            using (new EditorGUILayout.VerticalScope(MarsEditorGUI.Styles.NoVerticalMarginScopeAlignment))
            {
                if (!isMARSSession)
                    EditorGUILayout.HelpBox(k_NoSessionMessage, MessageType.Info);
                else if (!MarsWorldScaleSettings.instance.scaleEntityPositions)
                    EditorGUILayout.HelpBox(k_EntityScaleWarning, MessageType.Info);
            }
        }

        GenericMenu OpenWorldScalePopupOptions()
        {
            var menu = new GenericMenu();
            var settings = MarsWorldScaleSettings.instance;

            menu.AddItem(styles.scaleEntityPositionsContent, settings.scaleEntityPositions, () =>
            {
                m_ScaleEntityPositionsProperty.boolValue = !settings.scaleEntityPositions;
                m_MARSWorldScaleSettingsObject.ApplyModifiedProperties();
            });

            menu.AddItem(styles.scaleSceneAudioContent, settings.scaleSceneAudio, () =>
            {
                m_ScaleSceneAudioProperty.boolValue = !settings.scaleSceneAudio;
                m_MARSWorldScaleSettingsObject.ApplyModifiedProperties();
            });

            menu.AddItem(styles.scaleEntityChildrenContent, settings.scaleEntityChildren, () =>
            {
                m_ScaleEntityChildrenProperty.boolValue = !settings.scaleEntityChildren;
                m_MARSWorldScaleSettingsObject.ApplyModifiedProperties();
            });

            menu.AddItem(styles.scaleSceneLightingContent, settings.scaleSceneLighting, () =>
            {
                m_ScaleSceneLightingProperty.boolValue = !settings.scaleSceneLighting;
                m_MARSWorldScaleSettingsObject.ApplyModifiedProperties();
            });

            menu.AddItem(styles.scaleClippingPlanesContent, settings.scaleClippingPlanes, () =>
            {
                m_ScaleClippingPlanesProperty.boolValue = !settings.scaleClippingPlanes;
                m_MARSWorldScaleSettingsObject.ApplyModifiedProperties();
            });

            return menu;
        }

        void OpenWorldScaleHelp()
        {
            Help.BrowseURL(DocumentationConstants.WorldScaleManualURL);
        }

        static GenericMenu AddWorldScaleItemsToTabMenu()
        {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Select World Scale Module"), false, () =>
            {
                Selection.activeObject = MarsWorldScaleModule.instance;
                EditorGUIUtility.PingObject(Selection.activeObject);
            } );
            return menu;
        }

        static void RecordWorldScaleFoldoutAnalyticsEvent(bool expanded)
        {
            EditorEvents.UiComponentUsed.Send(new UiComponentArgs
            {
                label = string.Format("MARS Session / {0}", k_WorldScaleLabel),
                active = expanded
            });
        }

        void UpdateMarkerLibraryData(MarsMarkerLibrary markerLibrary)
        {
            m_MarkerLibraryProperty = serializedObject.FindProperty("m_MarkerLibrary");

            m_LibrarySerializedObject = new SerializedObject(markerLibrary);
            m_LibraryMarkersProperty = m_LibrarySerializedObject.FindProperty("m_Markers");

            SyncMarkerLibraryOptionIndexesWithLoadedLibrary(markerLibrary);
        }
    }
}

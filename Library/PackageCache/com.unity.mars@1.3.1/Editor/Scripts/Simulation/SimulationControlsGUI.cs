using System;
using System.Linq;
using Unity.MARS;
using Unity.MARS.Data.Recorded;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEditor.MARS.Authoring;
using UnityEngine.Scripting.APIUpdating;

#if !UNITY_2020_2_OR_NEWER
using ToolManager = UnityEditor.EditorTools.EditorTools;
#else
using UnityEditor.EditorTools;
#endif

 namespace UnityEditor.MARS.Simulation
{
    /// <summary>
    /// GUI for the simulation controls
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class SimulationControlsGUI
    {
        /// <summary>
        /// GUI Styles, content and resources for the MARS Simulation View Header.
        /// </summary>
        class Styles
        {
            const string k_NoSwitchingTooltip = "Switching not available in this mode";

            public const string TimelineSyncingLabel = "Syncing";

            internal const string CompareToolNoProxyTooltip = "Select a Proxy to use the Compare Tool";

            public const float LabelWidth = 78f;
            public const float ColumnWidth = 36f;
            public const float ElementHeight = 19f;
            public const int ToolbarVerticalOffset = 32;
            public const int ViewGizmoWidth = 100;

            public const float ElementsHeightAdjust = -4f;
            public const float ButtonWidthAdjust = 2f;
            public const float ElementSpacingAdjust = -4f;
            public const float CarouselWidth = 32f;
            public const int CarouselPadding = 1;

            public readonly GUIContent showDisplayOptionsGUIContent;

            public readonly GUIContent[] viewSceneTypes;
            public readonly GUIContent[] selectSceneTypes;

            public readonly GUIContent modeTypeContent;
            public readonly GUIContent viewMenuContent;
            public readonly GUIContent recordingPopupButtonContent;

            public readonly GUIContent environmentLabelContent;
            public readonly GUIContent webCamDeviceLabelContent;
            public readonly GUIContent recordingLabelContent;
            public readonly GUIContent modeLabelContent;
            public readonly GUIContent controlsLabelContent;
            public readonly GUIContent viewTypeLabelContent;
            public readonly GUIContent selectTypeLabelContent;

            public readonly GUIContent previousItemContent;
            public readonly GUIContent nextItemContent;

            public readonly GUIContent modeNotAvailableContent;
            public readonly GUIContent remoteEnvironmentContent;
            public readonly GUIContent recordedEnvironmentContent;
            public readonly GUIContent liveRecordingContent;
            public readonly GUIContent remoteRecordingContent;
            public readonly GUIContent customRecordingContent;

            public readonly GUIContent statusLabelContent;
            public readonly GUIContent syncedStatusContent;
            public readonly GUIContent outOfSyncStatusContent;
            public readonly GUIContent playModeStatusContent;
            public readonly GUIContent resyncButtonContent;
            public readonly GUIContent resyncTextButtonContent;

            public readonly GUIContent autoSyncLabelContent;
            public readonly GUIContent autoSyncWithSceneContent;
            public readonly GUIContent autoSyncWithTimeContent;

            public readonly GUIContent openRecordingTimelineContent;
            public readonly GUIContent recordingWindowPlaybackLabelContent;
            public readonly GUIContent enableMarsButtonContent;

            public readonly GUIContent compareToolContent;
            public readonly GUIContent createToolContent;

            public readonly GUIStyle toolButton;
            public readonly GUIStyle popupWindow;

            public readonly Color PlayButtonActiveColor;

            readonly GUIContent m_RecordingButtonContentInactive;
            readonly GUIContent m_RecordingButtonContentActive;
            readonly GUIContent m_PlayButtonContentInactive;
            readonly GUIContent m_PlayButtonContentActive;
            readonly GUIContent m_PauseButtonContentInactive;
            readonly GUIContent m_PauseButtonContentActive;

            readonly GUIContent m_RecordingTextButtonContentInactive;
            readonly GUIContent m_RecordingTextButtonContentActive;
            readonly GUIContent m_PlayTextButtonContentInactive;
            readonly GUIContent m_PlayTextButtonContentActive;
            readonly GUIContent m_PauseTextButtonContentInactive;
            readonly GUIContent m_PauseTextButtonContentActive;

            public Styles()
            {
                showDisplayOptionsGUIContent = EditorGUIUtility.TrIconContent("animationvisibilitytoggleon", "Show Simulation View display options");

                viewSceneTypes = (
                    from viewType in Enum.GetNames(typeof(ViewSceneType))
                    where viewType != "None"
                    select new GUIContent(viewType.ToString()
                        .Replace(ViewSceneType.Device.ToString(),"Device (Camera controls)")
                        .Replace(ViewSceneType.Simulation.ToString(), "Simulation (Scene controls)"))).ToArray();


                selectSceneTypes = new[] {
                    new GUIContent("Content"),
                    new GUIContent("Environment"),
                };

                modeTypeContent = new GUIContent("Mode",
                    "The Simulation Mode changes how Simulation behaves." +
                    "\n\nChoose 'Synthetic' for working with modeled environments." +
                    "\n\nChoose 'Recorded' for testing against recorded data (recorded video or recordings of synthetic environments)." +
                    "\n\nChoose 'Live' for testing against live video data (not available for all AR functionality.");
#if UNITY_2019_3_OR_NEWER
                viewMenuContent = EditorGUIUtility.TrIconContent("_Popup", "Simulation View Controls");

                m_RecordingButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon( string.Empty, "Start Record Session", "TimelineAutokey@2x");
                m_RecordingButtonContentActive = EditorGUIUtility.TrTextContentWithIcon( string.Empty, "Stop Record Session", "TimelineAutokey_active@2x");
#else
                viewMenuContent = EditorGUIUtility.TrIconContent("pane options", "Simulation View Controls");

                recordingButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon( string.Empty, "Start Record Session", "TimelineAutokey");
                recordingButtonContentActive = EditorGUIUtility.TrTextContentWithIcon( string.Empty, "Stop Record Session", "TimelineAutokey_active");
#endif
                recordingPopupButtonContent = new GUIContent(MarsUIResources.instance.SimulationIconData.CameraControls.Icon, "Recording playback controls");
                m_PlayButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon(string.Empty, "Start Simulation", "PlayButton");
                m_PlayButtonContentActive = EditorGUIUtility.TrTextContentWithIcon(string.Empty, "Stop Simulation", "PlayButton On");
                m_PauseButtonContentInactive = EditorGUIUtility.TrIconContent("PauseButton", "Pause");
                m_PauseButtonContentActive = EditorGUIUtility.TrIconContent("PauseButton On", "Unpause");

#if UNITY_2019_3_OR_NEWER
                m_RecordingTextButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon( "Rec", "Start Record Session", "TimelineAutokey@2x");
                m_RecordingTextButtonContentActive = EditorGUIUtility.TrTextContentWithIcon( "Rec", "Stop Record Session", "TimelineAutokey_active@2x");
#else
                recordingTextButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon( "Rec", "Start Record Session", "TimelineAutokey");
                recordingTextButtonContentActive = EditorGUIUtility.TrTextContentWithIcon( "Rec", "Stop Record Session", "TimelineAutokey_active");
#endif
                m_PlayTextButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon("Play", "Start Simulation", "PlayButton");
                m_PlayTextButtonContentActive = EditorGUIUtility.TrTextContentWithIcon("Play", "Stop Simulation", "PlayButton On");
                m_PauseTextButtonContentInactive = EditorGUIUtility.TrTextContentWithIcon("Pause", "Pause Simulation", "PauseButton");
                m_PauseTextButtonContentActive = EditorGUIUtility.TrTextContentWithIcon("Pause", "Unpause Simulation", "PauseButton On");

                previousItemContent = EditorGUIUtility.TrIconContent("tab_prev", "Previous Item");
                nextItemContent = EditorGUIUtility.TrIconContent("tab_next", "Next Item");

                environmentLabelContent = new GUIContent("Environment", "The selected environment for Simulation");
                webCamDeviceLabelContent = new GUIContent("Device");
                recordingLabelContent = new GUIContent("Recording", "The selected recording of the simulated environment");
                modeLabelContent = new GUIContent("Mode");
                controlsLabelContent = new GUIContent("Controls");
                viewTypeLabelContent = new GUIContent("View Type",
                    "The perspective and controls of the Simulation.\n\n" +
                    "Use 'Simulation' for Scene-style camera control.\n\n" +
                    "Use 'Device' for first-person device-style behavior emulating AR phone or headset movement.");
                selectTypeLabelContent = new GUIContent("Select Type", "The Select Type changes which objects can be picked in the view.\n\nUse Content to select Unity MARS generated objects.\n\nUse Environment to select objects into the simulated environment.");

                modeNotAvailableContent = new GUIContent("Not Available", k_NoSwitchingTooltip);
                recordedEnvironmentContent = new GUIContent("Recorded Environment", k_NoSwitchingTooltip);
                remoteEnvironmentContent = new GUIContent("Remote Environment", k_NoSwitchingTooltip);
                liveRecordingContent = new GUIContent("Live", k_NoSwitchingTooltip);
                remoteRecordingContent = new GUIContent("Remote", k_NoSwitchingTooltip);
                customRecordingContent = new GUIContent("Custom", k_NoSwitchingTooltip);

                statusLabelContent = new GUIContent("Status", "The current status of the Simulation");
                syncedStatusContent = new GUIContent("Synced", "Simulation reflects the state of the active scene");
                outOfSyncStatusContent = new GUIContent("Out of Sync", "Simulation does not reflect the state of the active scene");
                playModeStatusContent = new GUIContent("Play Mode");
                resyncButtonContent = EditorGUIUtility.TrIconContent("preAudioLoopOff", "Resync Simulation");
                resyncTextButtonContent = EditorGUIUtility.TrTextContentWithIcon("Resync", "Resync Simulation", "preAudioLoopOff");

                autoSyncLabelContent = new GUIContent("Auto Sync", "Options for how the Auto Sync should behave");
                autoSyncWithSceneContent = new GUIContent("With Scene", SimulationSettings.AutoSyncTooltip);
                autoSyncWithTimeContent = new GUIContent("With Time", MarsRecordingPlaybackModule.AutoSyncTooltip);

                openRecordingTimelineContent = new GUIContent("Open Timeline", "Open session recording Timeline");

                recordingWindowPlaybackLabelContent = new GUIContent("Playback in Game View");
                enableMarsButtonContent = new GUIContent("MARS Advanced Tools",
                    "A MARS Session will be added to your scene, enabling Proxy authoring workflows and edit-time simulation.");
                compareToolContent = new GUIContent(MarsUIResources.instance.CompareToolIcon.Icon, MarsCompareTool.Tooltip);
                createToolContent = new GUIContent(MarsUIResources.instance.CreateToolIcon.Icon, "Create Proxies from Simulation data");

                toolButton = MarsEditorGUI.InternalEditorStyles.ButtonIcon;
                toolButton.padding = new RectOffset(1, 1, 1, 1);

                popupWindow = new GUIStyle { padding = new RectOffset(6, 6, 6, 6) };

                PlayButtonActiveColor = EditorGUIUtility.isProSkin
                    ? new Color(0.29f, 0.58f, 0.88f)
                    : new Color(0.2f, 0.52f, 0.73f);
            }

            public GUIContent recordingButtonContent(bool isRecording)
            {
                return !isRecording ? m_RecordingButtonContentInactive : m_RecordingButtonContentActive;
            }

            public GUIContent playButtonContent(bool isPlaying)
            {
                return !isPlaying ? m_PlayButtonContentInactive : m_PlayButtonContentActive;
            }

            public GUIContent pauseButtonContent(bool isPaused)
            {
                return !isPaused ? m_PauseButtonContentInactive : m_PauseButtonContentActive;
            }

            public GUIContent recordingTextButtonContent(bool isRecording)
            {
                return !isRecording ? m_RecordingTextButtonContentInactive : m_RecordingTextButtonContentActive;
            }

            public GUIContent playTextButtonContent(bool isPlaying)
            {
                return !isPlaying ? m_PlayTextButtonContentInactive : m_PlayTextButtonContentActive;
            }

            public GUIContent pauseTextButtonContent(bool isPaused)
            {
                return !isPaused ? m_PauseTextButtonContentInactive : m_PauseTextButtonContentActive;
            }
        }

        const string k_SceneNotSimulatableMessage =
            "Current scene can't be simulated in Edit mode. Add a MARSSession to the scene to start edit-time simulation (Create -> MARS -> Session).";

        const string k_NoMarsSubscription = "Please update your MARS subscription.";
        const string k_NoEnvironmentMessage = "There is no environment available. Try selecting a different mode for the simulation.";
        const string k_NoLiveFaceProviderMessage =
            "Live face tracking requires a custom provider. See the Face Tracking section of the MARS documentation for more information.";

        const string k_NoRemoteActiveMessage = "Remote connection is not yet available.";
        const string k_TimelineOutOfSyncMessage = "Simulation is out of sync with the current time in the session recording Timeline. ";
        const string k_TimelineAutoResyncMessage = "Simulation will reset and fast-forward to time {0:0.00}s.";
        const string k_TimelineManualResyncMessage = "You must resync for Simulation to catch up to time {0:0.00}s.";
        const string k_TimelineResyncingMessage = "Simulation is resyncing to time {0:0.00}s.";
        const string k_ResyncingPlayModeMessage = "Resyncing is not supported in Play Mode.";

        const string k_NameHeader = "Simulation";
        const string k_ControlsName = k_NameHeader + "/Controls";
        const string k_ModeName = k_NameHeader + "/Mode";
        const string k_EnvironmentName = k_NameHeader + "/Environment";
        const string k_EnvironmentPrevName = k_EnvironmentName + "/Previous";
        const string k_EnvironmentNextName = k_EnvironmentName + "/Next";
        const string k_RecordingName = k_NameHeader + "/Recording";
        const string k_RecordingPrevName = k_RecordingName + "/Previous";
        const string k_RecordingNextName = k_RecordingName + "/Next";
        const string k_RecordName = k_NameHeader + "/Record";
        const string k_PlayName = k_NameHeader + "/Play";
        const string k_PauseName = k_NameHeader + "/Pause";
        const string k_RefreshName = k_NameHeader + "/Refresh";
        const string k_OptionsName = k_NameHeader + "/Options";

        static Styles s_Styles;

        // Delay creation of Styles till first access
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        /// <summary>
        /// Draw the simulation view toolbar
        /// </summary>
        /// <param name="view"></param>
        public static void DrawSimulationViewToolbar(this SimulationView view)
        {
            if (SceneWatchdogModule.instance.onlyARFSessionExists)
                DrawNonMarsSimulationToolbar(view);
            else
                DrawMarsSimulationToolbar(view);
        }

        static Rect GetToolbarRect(SimulationView view, int toolbarWidth)
        {
            var toolbarStyle = MarsEditorGUI.Styles.ToolbarNew;
            float toolbarStart;
            var fullWidth = toolbarWidth + Styles.ViewGizmoWidth * 2;

            if (view.position.width < toolbarWidth + Styles.ViewGizmoWidth)
            {
                toolbarStart = 0f;
            }
            else if (view.position.width < fullWidth)
            {
                var offset = (view.position.width - fullWidth);
                toolbarStart = (view.position.width + offset) * 0.5f;
                toolbarStart -= toolbarWidth * 0.5f;
            }
            else
            {
                toolbarStart = (view.position.width * 0.5f) - (toolbarWidth * 0.5f);
            }

            var toolbarRect = new Rect(
                toolbarStart,
                Styles.ToolbarVerticalOffset,
                toolbarWidth,
                toolbarStyle.fixedHeight);

            if (Event.current.type == EventType.Repaint)
                toolbarStyle.Draw(toolbarRect, GUIContent.none, false, false, false, false);

            return toolbarRect;
        }

        static void DrawMarsSimulationToolbar(SimulationView view)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var sessionRecordingModule = moduleLoader.GetModule<SessionRecordingModule>();
            var recordingPlaybackModule = moduleLoader.GetModule<MarsRecordingPlaybackModule>();

            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            const int toolbarWidth = 360;
            var toolbarRect = GetToolbarRect(view, toolbarWidth);

            using (new GUILayout.AreaScope(toolbarRect))
            {
                using (new EditorGUILayout.HorizontalScope(MarsEditorGUI.Styles.AreaAlignment))
                {
                    var isPlaying = querySimulationModule != null && querySimulationModule.simulating;
                    var isRecording = sessionRecordingModule != null && sessionRecordingModule.IsRecording;
                    var isPaused = recordingPlaybackModule != null && recordingPlaybackModule.IsRecordingPaused;

                    var recordingButtonContent = styles.recordingButtonContent(isRecording);
                    var playButtonContent = styles.playButtonContent(isPlaying);
                    var pauseButtonContent = styles.pauseButtonContent(isPaused);

                    var elementsHeight = toolbarRect.height + Styles.ElementsHeightAdjust;
                    var buttonWidth = toolbarRect.height + Styles.ButtonWidthAdjust;

                    DrawViewSelector(view, elementsHeight);

                    EnvironmentSelectElement(elementsHeight);

                    var areaRect = GUILayoutUtility.GetRect(Styles.CarouselWidth, elementsHeight, editorStyles.Button, GUILayout.ExpandWidth(false));
                    areaRect.xMin += Styles.ElementSpacingAdjust;
                    EnvironmentSelectCarousel(areaRect);

                    PlaybackControlsElement(recordingButtonContent, playButtonContent, pauseButtonContent, view.SceneType == ViewSceneType.Device,
                        GUILayout.Width(buttonWidth), GUILayout.Height(elementsHeight));

                    MarsEditorGUI.DrawReloadButton(styles.resyncButtonContent, editorStyles.Button,
                        GUILayout.Width(buttonWidth), GUILayout.Height(elementsHeight));

                    DrawDisplayOptions(view, elementsHeight);

                    DrawCompareToolButton(elementsHeight);
                    DrawCreateToolButton(elementsHeight);
                }
            }

            var current = Event.current;
            if (current.type == EventType.MouseDown)
            {
                if (toolbarRect.Contains(current.mousePosition))
                    current.Use();
            }
        }

        static void DrawNonMarsSimulationToolbar(SimulationView view)
        {
            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            const int toolbarWidth = 250;
            var toolbarRect = GetToolbarRect(view, toolbarWidth);

            using (new GUILayout.AreaScope(toolbarRect))
            {
                using (new EditorGUILayout.HorizontalScope(MarsEditorGUI.Styles.AreaAlignment))
                {
                    var elementsHeight = toolbarRect.height + Styles.ElementsHeightAdjust;

                    var dropdownStyle = MarsEditorGUI.InternalEditorStyles.Button;

                    var foldoutRect = MarsEditorGUI.GetDropDownButtonRect(styles.viewMenuContent, dropdownStyle, elementsHeight);
                    if (EditorGUI.DropdownButton(foldoutRect, styles.viewMenuContent, FocusType.Passive, dropdownStyle))
                    {
                        var popupRect = foldoutRect;
                        popupRect.y += dropdownStyle.padding.bottom;
                        PopupWindow.Show(popupRect, new EnableMarsWindow());
                        GUIUtility.ExitGUI();
                    }

                    EnvironmentSelectElement(elementsHeight);

                    var areaRect = GUILayoutUtility.GetRect(Styles.CarouselWidth, elementsHeight, editorStyles.Button, GUILayout.ExpandWidth(false));
                    areaRect.xMin += Styles.ElementSpacingAdjust;
                    EnvironmentSelectCarousel(areaRect);

                    MinifiedPlaybackControlsElement(elementsHeight);

                    DrawDisplayOptions(view, elementsHeight);
                }
            }

            var current = Event.current;
            if (current.type == EventType.MouseDown)
            {
                if (toolbarRect.Contains(current.mousePosition))
                    current.Use();
            }
        }

        /// <summary>
        /// Draw the simulation view controls window popup
        /// </summary>
        /// <param name="showPlaybackControls">Show the playback controls in the window</param>
        /// <param name="recordingSupported">Show the recording controls in the window </param>
        public static void DrawControlsWindow(bool showPlaybackControls = true, bool recordingSupported = true)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var simSceneModule = moduleLoader.GetModule<SimulationSceneModule>();
            var sessionRecordingModule = moduleLoader.GetModule<SessionRecordingModule>();
            var recordingPlaybackModule = MarsRecordingPlaybackModule.instance;
            var playMode = EditorApplication.isPlayingOrWillChangePlaymode;

            using (new EditorGUILayout.VerticalScope(MarsEditorGUI.Styles.AreaAlignment))
            {
                var labelStyle = MarsEditorGUI.Styles.SingleLineAlignment;
                var labelSize = labelStyle.CalcSize(styles.modeLabelContent);
                labelSize.x = Styles.LabelWidth;

                const float columnWidth = Styles.ColumnWidth;
                const float alignedHeight = Styles.ElementHeight;

                var editorStyles = MarsEditorGUI.InternalEditorStyles;

                if (showPlaybackControls)
                {
                    using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                    {
                        GUILayout.Label(styles.modeTypeContent, GUILayout.Width(labelSize.x));
                        ModeSelectElement(alignedHeight);
                    }
                }

                using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                {
                    var labelContent = SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Live ?
                        styles.webCamDeviceLabelContent : styles.environmentLabelContent;

                    GUILayout.Label(labelContent, GUILayout.Width(labelSize.x));
                    EnvironmentSelectElement(alignedHeight);

                    var areaRect = GUILayoutUtility.GetRect(columnWidth, alignedHeight, editorStyles.Button, GUILayout.ExpandWidth(false));
                    EnvironmentSelectCarousel(areaRect);
                }

                using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                {
                    GUILayout.Label(styles.recordingLabelContent, GUILayout.Width(labelSize.x));

                    using (new EditorGUI.DisabledScope(playMode && !MARSSceneModule.simulatedDiscoveryInPlayMode))
                    {
                        RecordingSelectElement(alignedHeight);

                        var areaRect = GUILayoutUtility.GetRect(columnWidth, alignedHeight, editorStyles.Button, GUILayout.ExpandWidth(false));
                        RecordingSelectCarousel(areaRect);
                    }
                }

                using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                {
                    GUILayout.Label("", GUILayout.Width(labelSize.x));
                    OpenRecordingTimelineButton();
                }

                EditorGUIUtils.DrawSplitter();

                using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                {
                    GUILayout.Label(styles.statusLabelContent, GUILayout.Width(labelSize.x));
                    SyncStatusLabel();
                    GUI.SetNextControlName(k_RefreshName);
                    MarsEditorGUI.DrawReloadButton(styles.resyncTextButtonContent, editorStyles.Button,
                        GUILayout.Height(labelSize.y), GUILayout.ExpandWidth(false));
                }

                using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
                {
                    GUILayout.Label(styles.autoSyncLabelContent, GUILayout.Width(labelSize.x));

                    var simulationSettings = SimulationSettings.instance;
                    var autoSyncWithScene = simulationSettings.AutoSyncWithSceneChanges;
                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        autoSyncWithScene = GUILayout.Toggle(autoSyncWithScene, styles.autoSyncWithSceneContent);
                        if (check.changed)
                        {
                            simulationSettings.AutoSyncWithSceneChanges = autoSyncWithScene;
                            EditorEvents.AutoSyncWithSceneToggled.Send(new AutoSyncToggledArgs { enabled = autoSyncWithScene });
                        }
                    }

                    var autoSyncWithTime = recordingPlaybackModule.AutoSyncWithTimeChanges;
                    using (var check = new EditorGUI.ChangeCheckScope())
                    {
                        autoSyncWithTime = GUILayout.Toggle(autoSyncWithTime, styles.autoSyncWithTimeContent);
                        if (check.changed)
                        {
                            recordingPlaybackModule.AutoSyncWithTimeChanges = autoSyncWithTime;
                            EditorEvents.AutoSyncWithTimeToggled.Send(new AutoSyncToggledArgs { enabled = autoSyncWithTime });
                        }
                    }
                }

                if (!showPlaybackControls)
                    return;

                using (var horizontalScope = new EditorGUILayout.HorizontalScope(GUIStyle.none))
                {
                    var horizontalRect = horizontalScope.rect;
                    GUILayout.Label(styles.controlsLabelContent, GUILayout.Width(labelSize.x));

                    var internalStyles = MarsEditorGUI.InternalEditorStyles;

                    var isPlaying = querySimulationModule != null && querySimulationModule.simulating;
                    var isRecording = sessionRecordingModule != null && sessionRecordingModule.IsRecording;
                    var isPaused = recordingPlaybackModule != null && recordingPlaybackModule.IsRecordingPaused;

                    GUI.SetNextControlName(k_RecordName);
                    var recordingButtonContent = styles.recordingTextButtonContent(isRecording);
                    GUI.SetNextControlName(k_PlayName);
                    var playButtonContent = styles.playTextButtonContent(isPlaying);
                    GUI.SetNextControlName(k_PauseName);
                    var pauseButtonContent = styles.pauseTextButtonContent(isPaused);

                    var recordTextContentWidth = internalStyles.ButtonLeft.CalcSize(recordingButtonContent).x;
                    var playTextContentWidth = internalStyles.ButtonMid.CalcSize(playButtonContent).x;
                    var pauseTextContentWidth = internalStyles.ButtonRight.CalcSize(pauseButtonContent).x;

                    var minFullWidth = labelSize.x + recordTextContentWidth + playTextContentWidth
                        + pauseTextContentWidth + columnWidth;

                    var playbackEnabled = querySimulationModule != null && simSceneModule != null && simSceneModule.IsSimulationReady;

                    var anyDeviceViewExists = false;
                    foreach (var simView in SimulationView.SimulationViews)
                    {
                        if (simView.SceneType != ViewSceneType.Device)
                            continue;

                        anyDeviceViewExists = true;
                        break;
                    }

                    recordingSupported &= anyDeviceViewExists;

                    using (new EditorGUI.DisabledScope(!playbackEnabled))
                    {
                        if (horizontalRect.width < minFullWidth)
                        {
                            recordingButtonContent = styles.recordingButtonContent(isRecording);
                            playButtonContent = styles.playButtonContent(isPlaying);
                            pauseButtonContent = styles.pauseButtonContent(isPaused);
                            PlaybackControlsElement(recordingButtonContent,
                                playButtonContent, pauseButtonContent, recordingSupported, GUILayout.Height(labelSize.y));
                        }
                        else
                        {
                            PlaybackControlsElement(recordingButtonContent, playButtonContent, pauseButtonContent,
                                recordingSupported, GUILayout.Height(labelSize.y));
                        }
                    }
                }
            }
        }

        static void DrawViewSelector(ISimulationView view, float height)
        {
            var dropdownStyle = MarsEditorGUI.InternalEditorStyles.Button;
            var viewSceneButton = MarsEditorGUI.GetDropDownButtonRect(styles.viewMenuContent, dropdownStyle, height);

            GUI.SetNextControlName(k_ControlsName);
            if (EditorGUI.DropdownButton(viewSceneButton, styles.viewMenuContent, FocusType.Passive, dropdownStyle))
            {
                var popupWindowRect = viewSceneButton;
                popupWindowRect.x -= dropdownStyle.padding.left / 2f;
                popupWindowRect.y += dropdownStyle.padding.bottom;

                PopupWindow.Show(popupWindowRect, new MarsEditorGUI.SceneTypeWindow(view, styles.viewSceneTypes));
                GUIUtility.ExitGUI();
            }
        }

        static void DrawDisplayOptions(SimulationView view, float height)
        {
            var dropdownStyle = MarsEditorGUI.InternalEditorStyles.Button;

            var foldoutRect = MarsEditorGUI.GetDropDownButtonRect(styles.showDisplayOptionsGUIContent, dropdownStyle, height);
            GUI.SetNextControlName(k_OptionsName);
            if (EditorGUI.DropdownButton(foldoutRect, styles.showDisplayOptionsGUIContent, FocusType.Passive, dropdownStyle))
            {
                var popupRect = foldoutRect;
                popupRect.y += dropdownStyle.padding.bottom;
                PopupWindow.Show(popupRect, new SimulationViewDisplayOptionsWindow(view));
                GUIUtility.ExitGUI();
            }
        }

        static void DrawCompareToolButton(float size)
        {
            var selection = Selection.activeGameObject;
            var proxySelected = selection != null && selection.GetComponent<Proxy>();

            using (new EditorGUI.DisabledScope(!proxySelected))
            {
                var compareToolContent = styles.compareToolContent;
                compareToolContent.tooltip = proxySelected ? MarsCompareTool.Tooltip : Styles.CompareToolNoProxyTooltip;

                if (GUILayout.Button(compareToolContent, styles.toolButton, GUILayout.Width(size), GUILayout.Height(size)))
                {
                    ToolManager.SetActiveTool<MarsCompareTool>();
                }
            }
        }

        static void DrawCreateToolButton(float size)
        {
            if (GUILayout.Button(styles.createToolContent, styles.toolButton, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ToolManager.SetActiveTool<MarsCreateTool>();
            }
        }

        /// <summary>
        /// Draw help dialogs for a simulated device view
        /// </summary>
        /// <param name="sceneType">Current scene scene view type</param>
        /// <returns>True if any help message was displayed; false if no message was displayed.</returns>
        public static bool DrawHelpArea(ViewSceneType sceneType)
        {
            if (sceneType == ViewSceneType.None)
                return false;

            var simObjectsManager = SimulatedObjectsManager.instance;
            var blockCount = simObjectsManager != null ? simObjectsManager.SimulatableBehavioursBlockingResyncCount : 0;
            var displayResyncBlockedMessage = blockCount > 0;

            var recordingPlaybackModule = ModuleLoaderCore.instance.GetModule<MarsRecordingPlaybackModule>();
            var displayOutOfSyncMessage = recordingPlaybackModule != null &&
                (recordingPlaybackModule.TimelineSyncState == SimulationTimeSyncState.OutOfSync ||
                 recordingPlaybackModule.TimelineSyncState == SimulationTimeSyncState.Syncing);

            var displayNoMarsSubscription = (!MARSEntitlements.instance.IsEntitled(true));
            var displayNotSimulatableMessage = (!EditorApplication.isPlayingOrWillChangePlaymode && !QuerySimulationModule.sceneIsSimulatable) || MARSSession.Instance == null;
            var displayNoEnvironmentMessage = !SimulationSettings.instance.IsSpatialContextAvailable;

            var liveEnvironemtMode = SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Live;
            var displayNoLiveFaceProvider = liveEnvironemtMode && !IsFaceTrackingAvailable();

            var remoteEnvironmentMode = SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Remote;
            var displayNoRemoteAvailable = remoteEnvironmentMode && !IsRemoteAvailable();

            if (!displayNotSimulatableMessage &&
                !displayOutOfSyncMessage &&
                !displayResyncBlockedMessage &&
                !displayNoEnvironmentMessage &&
                !displayNoMarsSubscription &&
                !displayNoLiveFaceProvider &&
                !displayNoRemoteAvailable)
            {
                return false;
            }

            GUILayout.FlexibleSpace();
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();
                const float helpBoxWidth = 300f;
                const float helpBoxHeight = 42f;
                const float helpBackgroundFade = 0.75f;

                var helpRect = GUILayoutUtility.GetRect(helpBoxWidth, helpBoxHeight, EditorStyles.helpBox);
                string helpMessage;
                var messageType = MessageType.Info;

                if (displayNoMarsSubscription)
                {
                    helpMessage = k_NoMarsSubscription;
                    messageType = MessageType.Warning;
                }
                else if (displayNotSimulatableMessage)
                {
                    helpMessage = k_SceneNotSimulatableMessage;
                    messageType = MessageType.Warning;
                }
                else if (displayNoLiveFaceProvider)
                {
                    helpMessage = k_NoLiveFaceProviderMessage;
                    messageType = MessageType.Warning;
                }
                else if (displayNoRemoteAvailable)
                {
                    helpMessage = k_NoRemoteActiveMessage;
                    messageType = MessageType.Warning;
                }
                else if (displayNoEnvironmentMessage)
                {
                    helpMessage = k_NoEnvironmentMessage;
                    messageType = MessageType.Warning;
                }
                else if (displayOutOfSyncMessage)
                {
                    string timelineHelpMessage;
                    if (recordingPlaybackModule.TimelineSyncState == SimulationTimeSyncState.Syncing)
                    {
                        timelineHelpMessage = k_TimelineResyncingMessage;
                    }
                    else
                    {
                        string additionalMessage;
                        if (Application.isPlaying)
                        {
                            additionalMessage = k_ResyncingPlayModeMessage;
                            messageType = MessageType.Warning;
                        }
                        else
                        {
                            additionalMessage = recordingPlaybackModule.AutoSyncWithTimeChanges ?
                                k_TimelineAutoResyncMessage : k_TimelineManualResyncMessage;
                        }

                        timelineHelpMessage = k_TimelineOutOfSyncMessage + additionalMessage;
                    }

                    helpMessage = string.Format(timelineHelpMessage, recordingPlaybackModule.SyncEndTime);
                }
                else
                {
                    helpMessage = $"Resync blocked by {blockCount} handle{(blockCount > 1 ? "s" : "")}";
                }

                EditorGUI.DrawRect(helpRect, EditorGUIUtils.GetSceneBackgroundColor() * helpBackgroundFade);
                EditorGUI.HelpBox(helpRect, helpMessage, messageType);

                GUILayout.FlexibleSpace();
            }
            GUILayout.Space(24f);

            return true;
        }

        static bool IsFaceTrackingAvailable()
        {
            var functionalityIsland = ModuleLoaderCore.instance.GetModule<FunctionalityInjectionModule>()?.activeIsland;
            if (functionalityIsland == null)
                return false;

            var faceTrackingProvider = false;
            foreach (var pair in functionalityIsland.providers)
            {
                if (pair.Value is IProvidesFaceTracking)
                {
                    if (pair.Value.GetType().GetAttribute<ProviderSelectionOptionsAttribute>().Priority == ProviderPriorities.StubProviderPriority)
                        continue; // Stub face tracking provider will be loaded when there is no other face tracking provider available in project

                    faceTrackingProvider = true;
                    break;
                }
            }

            return faceTrackingProvider;
        }

        static bool IsRemoteAvailable()
        {
            var marsRemoteModule = ModuleLoaderCore.instance.GetModule<MARSRemoteModule>();
            if (marsRemoteModule == null)
                return false;

            return marsRemoteModule.RemoteActive;
        }

        static void ModeSelectElement(float height)
        {
            var environmentManager = ModuleLoaderCore.instance.GetModule<MARSEnvironmentManager>();
            var guiEnabled = environmentManager != null;
            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            using (new EditorGUI.DisabledScope(!guiEnabled))
            {
                if (!guiEnabled)
                {
                    var rect = EditorGUILayout.GetControlRect(false, height, editorStyles.Popup);
                    GUI.Button(rect, styles.modeNotAvailableContent);
                    return;
                }

                var simulationSettings = SimulationSettings.instance;
                using (var change = new EditorGUI.ChangeCheckScope())
                {
                    GUI.SetNextControlName(k_ModeName);
                    var environmentMode = (EnvironmentMode)EditorGUILayout.Popup((int)simulationSettings.EnvironmentMode,
                        MARSEnvironmentManager.ModeTypes, editorStyles.Popup, GUILayout.Height(height));

                    if (change.changed && environmentMode != simulationSettings.EnvironmentMode)
                        environmentManager.TrySetModeAndRestartSimulation(environmentMode);
                }
            }
        }

        static void EnvironmentSelectElement(float height)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            var simulationRecordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var videoContextManager = moduleLoader.GetModule<SimulationVideoContextManager>();
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var simSceneModule = moduleLoader.GetModule<SimulationSceneModule>();
            var simulationSettings = SimulationSettings.instance;

            var cycleButtonsEnabled = environmentManager != null && simulationRecordingManager != null &&
                videoContextManager != null && querySimulationModule != null && simSceneModule != null && simSceneModule.IsSimulationReady
                && (simulationSettings.EnvironmentMode != EnvironmentMode.Custom || simulationSettings.EnvironmentMode == EnvironmentMode.Custom
                && environmentManager.HasCustomModeSettings && environmentManager.CustomModeSettings.HasEnvironmentSwitching);

            var simulatingTemporal = cycleButtonsEnabled && querySimulationModule.simulatingTemporal;

            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            using (new EditorGUI.DisabledScope(!cycleButtonsEnabled))
            {
                if (!cycleButtonsEnabled)
                {
                    var rect = EditorGUILayout.GetControlRect(false, height, editorStyles.Popup);
                    GUI.Button(rect, styles.modeNotAvailableContent);
                    return;
                }

                GUI.SetNextControlName(k_EnvironmentName);
                switch (simulationSettings.EnvironmentMode)
                {
                    case EnvironmentMode.Synthetic:
                    {
                        var index = EditorGUILayout.Popup(environmentManager.CurrentSyntheticEnvironmentIndex,
                            environmentManager.EnvironmentGUIContents, editorStyles.Popup, GUILayout.Height(height));

                        if (index != environmentManager.CurrentSyntheticEnvironmentIndex)
                        {
                            if (simulatingTemporal)
                                querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

                            environmentManager.TrySetupEnvironmentAndRestartSimulation(index);
                        }

                        break;
                    }
                    case EnvironmentMode.Recorded:
                    {
                        if (Event.current.type == EventType.Repaint)
                            simulationRecordingManager.ValidateIndependentRecordings();

                        var index = EditorGUILayout.Popup(simulationRecordingManager.CurrentIndependentRecordingIndex,
                            simulationRecordingManager.IndependentRecordingContents, editorStyles.Popup, GUILayout.Height(height));

                        if (index != simulationRecordingManager.CurrentIndependentRecordingIndex)
                        {
                            if (simulatingTemporal)
                                querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

                            environmentManager.TrySetupEnvironmentAndRestartSimulation(index);
                        }

                        break;
                    }
                    case EnvironmentMode.Live:
                    {
                        var index = EditorGUILayout.Popup(simulationSettings.WebCamDeviceIndex,
                            videoContextManager.WebCamDeviceContents, editorStyles.Popup, GUILayout.Height(height));

                        if (index != simulationSettings.WebCamDeviceIndex)
                        {
                            if (simulatingTemporal)
                                querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

                            environmentManager.TrySetupEnvironmentAndRestartSimulation(index);
                        }

                        break;
                    }
                    case EnvironmentMode.Custom:
                    {
                        var customModeSettings = environmentManager.CustomModeSettings;
                        var index = EditorGUILayout.Popup(customModeSettings.ActiveEnvironmentIndex,
                            customModeSettings.EnvironmentSwitchingContents, editorStyles.Popup, GUILayout.Height(height));

                        if (index != customModeSettings.ActiveEnvironmentIndex)
                        {
                            if (simulatingTemporal)
                                querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

                            environmentManager.TrySetupEnvironmentAndRestartSimulation(index);
                        }

                        break;
                    }
                    case EnvironmentMode.Remote:
                    {
                        using (new EditorGUI.DisabledScope(true))
                        {
                            var rect = EditorGUILayout.GetControlRect(false, height, editorStyles.Popup);
                            GUI.Button(rect, styles.remoteEnvironmentContent);
                            break;
                        }
                    }
                }
            }
        }

        static void EnvironmentSelectCarousel(Rect rect)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var simSceneModule = moduleLoader.GetModule<SimulationSceneModule>();
            var environmentMode = SimulationSettings.instance.EnvironmentMode;
            var hasModules = environmentManager != null && querySimulationModule != null && simSceneModule != null;
            var customMode = environmentMode == EnvironmentMode.Custom;
            var remoteMode = environmentMode == EnvironmentMode.Remote;
            var customSwitching = false;
            if (customMode && environmentManager != null)
                customSwitching = environmentManager.HasCustomModeSettings && environmentManager.CustomModeSettings.HasEnvironmentSwitching;

            var cycleButtonsEnabled = hasModules && simSceneModule.IsSimulationReady && !remoteMode && (!customMode || customSwitching);
            if (environmentMode == EnvironmentMode.Live)
            {
                var videoContextManager = moduleLoader.GetModule<SimulationVideoContextManager>();
                var deviceCount = 0;
                if (videoContextManager != null)
                    deviceCount = videoContextManager.WebCamDeviceContents.Length;

                if (deviceCount == 0)
                    cycleButtonsEnabled = false;
            }

            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            using (new EditorGUI.DisabledScope(!cycleButtonsEnabled))
            {
                GUI.SetNextControlName(k_EnvironmentPrevName);
                rect.x += Styles.CarouselPadding;
                rect.width *= 0.5f;
                if (GUI.Button(rect, styles.previousItemContent, editorStyles.ButtonLeftIcon))
                {
                    EnvironmentCycleButtonAction(false);
                }

                GUI.SetNextControlName(k_EnvironmentNextName);
                rect.x += rect.width;
                if (GUI.Button(rect, styles.nextItemContent, editorStyles.ButtonRightIcon))
                {
                    EnvironmentCycleButtonAction(true);
                }
            }
        }

        static void RecordingSelectElement(float height)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var recordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var simSceneModule = moduleLoader.GetModule<SimulationSceneModule>();
            var simulationSettings = SimulationSettings.instance;

            var cycleButtonsEnabled = recordingManager != null && simSceneModule != null && simSceneModule.IsSimulationReady
                && simulationSettings.EnvironmentMode != EnvironmentMode.Custom;

            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            if (cycleButtonsEnabled)
                recordingManager.ValidateSyntheticRecordings();

            var rect = EditorGUILayout.GetControlRect(false, height, editorStyles.Popup);

            using (new EditorGUI.DisabledScope(!cycleButtonsEnabled))
            {
                if (!cycleButtonsEnabled)
                {
                    GUI.Button(rect, styles.modeNotAvailableContent);
                    return;
                }

                GUI.SetNextControlName(k_RecordingName);
                switch (simulationSettings.EnvironmentMode)
                {
                    case EnvironmentMode.Synthetic:
                    {
                        if (recordingManager.SyntheticRecordingOptionContents != null)
                        {
                            using (var check = new EditorGUI.ChangeCheckScope())
                            {
                                var index = EditorGUI.Popup(rect, recordingManager.CurrentSyntheticRecordingOptionIndex,
                                    recordingManager.SyntheticRecordingOptionContents, editorStyles.Popup);

                                if (check.changed)
                                    recordingManager.SetRecordingOptionAndRestartSimulation(index);
                            }
                        }

                        break;
                    }
                    case EnvironmentMode.Recorded:
                    {
                        using (new EditorGUI.DisabledScope(true))
                        {
                            GUI.Button(rect, styles.recordedEnvironmentContent);
                            break;
                        }
                    }
                    case EnvironmentMode.Live:
                    {
                        using (new EditorGUI.DisabledScope(true))
                        {
                            GUI.Button(rect, styles.liveRecordingContent);
                            break;
                        }
                    }
                    case EnvironmentMode.Remote:
                    {
                        using (new EditorGUI.DisabledScope(true))
                        {
                            GUI.Button(rect, styles.remoteRecordingContent);
                            break;
                        }
                    }
                    case EnvironmentMode.Custom:
                    {
                        using (new EditorGUI.DisabledScope(true))
                        {
                            GUI.Button(rect, styles.customRecordingContent);
                            break;
                        }
                    }
                }
            }
        }

        static void RecordingSelectCarousel(Rect rect)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var recordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var simSceneModule = moduleLoader.GetModule<SimulationSceneModule>();

            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            var cycleButtonsEnabled = recordingManager != null && simSceneModule != null
                && simSceneModule.IsSimulationReady && recordingManager.CurrentSyntheticRecordingsCount > 0
                && SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic
                && recordingManager.CurrentSyntheticRecordingOptionIndex != 0;

            using (new EditorGUI.DisabledScope(!cycleButtonsEnabled))
            {
                GUI.SetNextControlName(k_RecordingPrevName);
                rect.width *= 0.5f;
                if (GUI.Button(rect, styles.previousItemContent, editorStyles.ButtonLeftIcon))
                {
                    RecordingCycleButtonAction(false);
                }

                GUI.SetNextControlName(k_RecordingNextName);
                rect.x += rect.width;
                if (GUI.Button(rect, styles.nextItemContent, editorStyles.ButtonRightIcon))
                {
                    RecordingCycleButtonAction(true);
                }
            }
        }

        static void SyncStatusLabel()
        {
            GUIContent statusContent;
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                statusContent = styles.playModeStatusContent;
            }
            else
            {
                var simObjectsManager = SimulatedObjectsManager.instance;
                var recordingPlaybackModule = MarsRecordingPlaybackModule.instance;
                var syncedWithScene = simObjectsManager != null && simObjectsManager.SimulationSyncedWithScene;
                statusContent = syncedWithScene ? styles.syncedStatusContent : styles.outOfSyncStatusContent;

                if (recordingPlaybackModule != null)
                {
                    switch (recordingPlaybackModule.TimelineSyncState)
                    {
                        case SimulationTimeSyncState.OutOfSync:
                            statusContent = styles.outOfSyncStatusContent;
                            break;
                        case SimulationTimeSyncState.Syncing:
                            var progress = (int)(recordingPlaybackModule.TimelineSyncProgress * 100);
                            statusContent = new GUIContent($"{Styles.TimelineSyncingLabel} {progress}%");
                            break;
                    }
                }
            }

            GUILayout.Label(statusContent);
        }

        static void OpenRecordingTimelineButton()
        {
            var recordingPlaybackModule = MarsRecordingPlaybackModule.instance;
            using (new EditorGUI.DisabledScope(recordingPlaybackModule == null || !recordingPlaybackModule.IsRecordingAvailable))
            {
                if (GUILayout.Button(styles.openRecordingTimelineContent))
                {
                    EditorEvents.RecordingTimelineOpened.Send(new RecordingTimelineOpenedArgs());
                    recordingPlaybackModule.OpenRecordingTimeline();
                }
            }
        }

        static bool ButtonToggle(bool active, GUIContent content, GUIStyle guiStyle, params GUILayoutOption[] options)
        {
            var value = GUILayout.Toggle(active, content, guiStyle, options);
            return value != active;
        }

        static void PlaybackControlsElement(GUIContent recordingContent, GUIContent playContent,
            GUIContent pauseContent, bool recodingSupported, params GUILayoutOption[] options)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var recordingPlaybackModule = moduleLoader.GetModule<MarsRecordingPlaybackModule>();
            var sessionRecordingModule = moduleLoader.GetModule<SessionRecordingModule>();
            var recordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();

            var simulationSettings = SimulationSettings.instance;
            var mode = simulationSettings.EnvironmentMode;
            var isPlaying = querySimulationModule != null && querySimulationModule.simulating;
            var isRecording = sessionRecordingModule != null && sessionRecordingModule.IsRecording;
            var isPaused = recordingPlaybackModule != null && recordingPlaybackModule.IsRecordingPaused;
            var spatialContextAvailable = simulationSettings.IsSpatialContextAvailable;

            if (querySimulationModule == null)
            {
                StopPlayingSimulation(isRecording);
                StopRecording();

                isPaused = false;
                isPlaying = false;
                isRecording = false;
            }

            var internalStyles = MarsEditorGUI.InternalEditorStyles;

            GUI.backgroundColor = isRecording ? styles.PlayButtonActiveColor : Color.white;

            var playMode = EditorApplication.isPlayingOrWillChangePlaymode;
            using (new EditorGUI.DisabledScope(!recodingSupported || recordingManager == null ||
                environmentManager == null || mode != EnvironmentMode.Synthetic || MARSSession.Instance == null ||
                !spatialContextAvailable))
            {
                GUI.SetNextControlName(k_RecordName);
                if (ButtonToggle(isRecording, recordingContent, internalStyles.ButtonLeft, options))
                {
                    isPaused = false;

                    if (playMode)
                    {
                        // Don't start or stop simulation in play mode, just record
                        if (!isRecording)
                            StartRecording();
                        else
                            StopRecording();
                    }
                    else
                    {
                        if (!isRecording) // start recording
                        {
                            StartPlayingSimulation(true);
                        }
                        else
                        {
                            StopPlayingSimulation(true);
                            isRecording = false;
                            isPlaying = false;
                        }
                    }
                }
            }

            GUI.backgroundColor = isPlaying ? styles.PlayButtonActiveColor : Color.white;

            using (new EditorGUI.DisabledScope(playMode || recordingManager == null || MARSSession.Instance == null ||
                !spatialContextAvailable))
            {
                GUI.SetNextControlName(k_PlayName);
                if (ButtonToggle(isPlaying, playContent, internalStyles.ButtonMid, options))
                {
                    if (!isPlaying) // start playing
                    {
                        StartPlayingSimulation(isRecording);
                        isPlaying = true;
                    }
                    else
                    {
                        StopPlayingSimulation(isRecording);
                        isPlaying = false;
                        isPaused = false;
                    }
                }
            }

            GUI.backgroundColor = isPaused ? styles.PlayButtonActiveColor : Color.white;

            using (new EditorGUI.DisabledScope(!isPlaying || recordingPlaybackModule == null || !recordingPlaybackModule.IsRecordingAvailable))
            {
                GUI.SetNextControlName(k_PauseName);
                if (ButtonToggle(isPaused, pauseContent, internalStyles.ButtonRight, options ))
                {
                    if (isPaused)
                        recordingPlaybackModule.ResumePlayback();
                    else
                        recordingPlaybackModule.PausePlayback();
                }
            }

            GUI.backgroundColor =  Color.white;
        }

        static void MinifiedPlaybackControlsElement(float height)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var sessionRecordingModule = moduleLoader.GetModule<SessionRecordingModule>();
            var recordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();

            var simulationSettings = SimulationSettings.instance;
            var mode = simulationSettings.EnvironmentMode;
            var isRecording = sessionRecordingModule != null && sessionRecordingModule.IsRecording;
            var spatialContextAvailable = simulationSettings.IsSpatialContextAvailable;

            if (querySimulationModule == null)
            {
                StopPlayingSimulation(isRecording);
                StopRecording();
            }

            using (new EditorGUI.DisabledScope(recordingManager == null ||
                mode != EnvironmentMode.Synthetic || !spatialContextAvailable))
            {
                var dropdownStyle = MarsEditorGUI.InternalEditorStyles.Button;
                var recordingPopupRect = MarsEditorGUI.GetDropDownButtonRect(styles.viewMenuContent,
                    dropdownStyle, height);

                if (EditorGUI.DropdownButton(recordingPopupRect, styles.recordingPopupButtonContent, FocusType.Passive, dropdownStyle))
                {
                    var popupWindowRect = new Rect(recordingPopupRect.x, recordingPopupRect.yMax + dropdownStyle.padding.bottom, 0, 0);
                    PopupWindow.Show(popupWindowRect, new RecordingWindow());
                    GUIUtility.ExitGUI();
                }
            }
        }

        /// <summary>
        /// GUI for selecting the view type
        /// </summary>
        /// <param name="view">View to change type on</param>
        /// <param name="contents">View type contents</param>
        public static void ViewSelectionElement(ISimulationView view, GUIContent[] contents)
        {
            var editorStyles = MarsEditorGUI.InternalEditorStyles;

            using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
            {
                var labelStyle = MarsEditorGUI.Styles.SingleLineAlignment;
                var labelSize = labelStyle.CalcSize(styles.modeLabelContent);
                labelSize.x = Styles.LabelWidth;

                const float alignedHeight = Styles.ElementHeight;

                GUILayout.Label(styles.modeTypeContent, GUILayout.Width(labelSize.x));
                ModeSelectElement(alignedHeight);
            }

            using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
            {
                GUILayout.Label(styles.viewTypeLabelContent, GUILayout.Width(Styles.LabelWidth));

                var index = EditorGUILayout.Popup((int)view.SceneType,
                    contents, editorStyles.Popup, GUILayout.Height(Styles.ElementHeight));

                if (index != (int)view.SceneType)
                    view.SceneType = (ViewSceneType)index;
            }

            var simView = (view as SimulationView);
            if (!simView)
                return;

            using (new EditorGUILayout.HorizontalScope(GUIStyle.none))
            {
                GUILayout.Label(styles.selectTypeLabelContent, GUILayout.Width(Styles.LabelWidth));

                var previousIndex = simView.EnvironmentSceneActive ? 1 : 0;

                var index = EditorGUILayout.Popup(previousIndex,
                    styles.selectSceneTypes, editorStyles.Popup, GUILayout.Height(Styles.ElementHeight));

                if (index != previousIndex)
                    simView.EnvironmentSceneActive = (index != 0);
            }
        }

        static void EnvironmentCycleButtonAction(bool forward)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            var simulationRecordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var videoContextManager = moduleLoader.GetModule<SimulationVideoContextManager>();
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            if (environmentManager == null || simulationRecordingManager == null || videoContextManager == null || querySimulationModule == null)
                return;

            if (querySimulationModule.simulatingTemporal)
                querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

            var simulationSettings = SimulationSettings.instance;
            switch (simulationSettings.EnvironmentMode)
            {
                case EnvironmentMode.Synthetic:
                    environmentManager.TrySetupNextEnvironmentAndRestartSimulation(forward);
                    EditorEvents.EnvironmentCycle.Send(new EnvironmentCycleArgs
                    {
                        label = environmentManager.SyntheticEnvironmentName,
                        mode = (int)simulationSettings.EnvironmentMode
                    });
                    break;
                case EnvironmentMode.Recorded:
                    environmentManager.TrySetupNextEnvironmentAndRestartSimulation(forward);
                    EditorEvents.EnvironmentCycle.Send(new EnvironmentCycleArgs
                    {
                        label = simulationRecordingManager.CurrentIndependentRecordingName,
                        mode = (int)simulationSettings.EnvironmentMode
                    });
                    break;
                case EnvironmentMode.Live:
                    environmentManager.TrySetupNextEnvironmentAndRestartSimulation(forward);
                    EditorEvents.EnvironmentCycle.Send(new EnvironmentCycleArgs
                    {
                        label = videoContextManager.WebCamDeviceContents[simulationSettings.WebCamDeviceIndex].text,
                        mode = (int)simulationSettings.EnvironmentMode
                    });
                    break;
                case EnvironmentMode.Remote:
                    break;
                case EnvironmentMode.Custom:
                    if (!environmentManager.HasCustomModeSettings)
                        return;

                    var customModeSettings = environmentManager.CustomModeSettings;
                    environmentManager.TrySetupNextEnvironmentAndRestartSimulation(forward);
                    EditorEvents.EnvironmentCycle.Send(new EnvironmentCycleArgs
                    {
                        label = customModeSettings.EnvironmentSwitchingContents[customModeSettings.ActiveEnvironmentIndex].text,
                        mode = (int)simulationSettings.EnvironmentMode
                    });
                    break;
            }
        }

        static void RecordingCycleButtonAction(bool forward)
        {
            var recordingManager = ModuleLoaderCore.instance.GetModule<SimulationRecordingManager>();
            if (recordingManager == null)
                return;

            switch (SimulationSettings.instance.EnvironmentMode)
            {
                case EnvironmentMode.Synthetic:
                {
                    if (forward)
                        recordingManager.SetupNextRecordingAndRestartSimulation();
                    else
                        recordingManager.SetupPrevRecordingAndRestartSimulation();

                    EditorEvents.SyntheticRecordingCycle.Send(new SyntheticRecordingCycleArgs
                    {
                        label = recordingManager.CurrentSyntheticRecordingName
                    });
                    break;
                }
                case EnvironmentMode.Recorded:
                    break;
                case EnvironmentMode.Live:
                    break;
                case EnvironmentMode.Remote:
                    break;
            }
        }

        static void StartPlayingSimulation(bool isRecording)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();

            if (querySimulationModule == null || environmentManager == null)
                return;

            var remoteModule = moduleLoader.GetModule<MARSRemoteModule>();
            var recordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            var recordingPlaybackModule = moduleLoader.GetModule<MarsRecordingPlaybackModule>();
            var mode = SimulationSettings.instance.EnvironmentMode;

            var useRemote = remoteModule != null && mode == EnvironmentMode.Remote &&
                !SceneWatchdogModule.instance.currentSceneIsFaceScene;

            if (isRecording && recordingManager != null)
            {
                if (recordingPlaybackModule != null)
                    recordingPlaybackModule.DisableRecordingPlayback = true;
            }
            else if (isRecording)
            {
                isRecording = false;
            }

            if (useRemote)
                remoteModule.RemoteConnect();

            querySimulationModule.StartTemporalSimulation();

            if (isRecording)
                StartRecording();
        }

        static void StopPlayingSimulation(bool isRecording)
        {
            var moduleLoader = ModuleLoaderCore.instance;
            var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
            var remoteModule = moduleLoader.GetModule<MARSRemoteModule>();

            if (querySimulationModule == null || environmentManager == null)
                return;

            var simulationSettings = SimulationSettings.instance;
            var mode = simulationSettings.EnvironmentMode;

            var useRemote = remoteModule != null && mode == EnvironmentMode.Remote &&
                !SceneWatchdogModule.instance.currentSceneIsFaceScene;

            if (useRemote)
                remoteModule.RemoteDisconnect();

            if (simulationSettings.AutoResetDevicePose)
                environmentManager.ResetDeviceStartingPose();
            else
                environmentManager.UpdateDeviceStartingPose();

            if (isRecording)
                StopRecording();

            querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.SingleFrameMode);
            querySimulationModule.RestartSimulationIfNeeded(true);
        }

        static void StartRecording()
        {
            var sessionRecordingModule = ModuleLoaderCore.instance.GetModule<SessionRecordingModule>();
            if (sessionRecordingModule == null)
                return;

            sessionRecordingModule.RegisterRecorderType<CameraPoseRecorder>();
            sessionRecordingModule.RegisterRecorderType<PlaneFindingRecorder>();
            sessionRecordingModule.ToggleRecording();

            // Discard recording if simulation stops without the user explicitly clicking stop
            QuerySimulationModule.onTemporalSimulationStop += CancelRecording;
        }

        static void StopRecording()
        {
            QuerySimulationModule.onTemporalSimulationStop -= CancelRecording;

            var moduleLoader = ModuleLoaderCore.instance;
            var sessionRecordingModule = moduleLoader.GetModule<SessionRecordingModule>();
            var simRecordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            if (sessionRecordingModule == null || simRecordingManager == null || !sessionRecordingModule.IsRecording)
                return;

            var recordingPlaybackModule = moduleLoader.GetModule<MarsRecordingPlaybackModule>();
            if (recordingPlaybackModule != null)
                recordingPlaybackModule.DisableRecordingPlayback = false;

            sessionRecordingModule.ToggleRecording();

            simRecordingManager.TrySaveSyntheticRecording();
        }

        static void CancelRecording()
        {
            QuerySimulationModule.onTemporalSimulationStop -= CancelRecording;

            var moduleLoader = ModuleLoaderCore.instance;
            var sessionRecordingModule = moduleLoader.GetModule<SessionRecordingModule>();
            var simRecordingManager = moduleLoader.GetModule<SimulationRecordingManager>();
            if (sessionRecordingModule == null || simRecordingManager == null)
                return;

            var recordingPlaybackModule = moduleLoader.GetModule<MarsRecordingPlaybackModule>();
            if (recordingPlaybackModule != null)
                recordingPlaybackModule.DisableRecordingPlayback = false;

            sessionRecordingModule.CancelRecording();
        }

        class RecordingWindow : MarsEditorGUI.MarsPopupWindow
        {
            static readonly Vector2 k_PopupSize = new Vector2(180f, 50f);

            protected override void Draw()
            {
                using (new GUILayout.VerticalScope(styles.popupWindow))
                {
                    GUILayout.Label(styles.recordingWindowPlaybackLabelContent);

                    var playMode = EditorApplication.isPlayingOrWillChangePlaymode;
                    using (new EditorGUI.DisabledScope(playMode && !MARSSceneModule.simulatedDiscoveryInPlayMode))
                    {
                        RecordingSelectElement(Styles.ElementHeight);
                    }
                }
            }

            public override Vector2 GetWindowSize()
            {
                return k_PopupSize;
            }
        }

        class EnableMarsWindow : MarsEditorGUI.MarsPopupWindow
        {
            static readonly Vector2 k_PopupSize = new Vector2(200f, 30f);

            protected override void Draw()
            {
                using (new GUILayout.HorizontalScope(styles.popupWindow))
                {
                    if (GUILayout.Button(styles.enableMarsButtonContent))
                    {
                        MARSSession.EnsureSessionInActiveScene();
                        editorWindow.Close();
                        GUIUtility.ExitGUI();
                    }
                }
            }

            public override Vector2 GetWindowSize()
            {
                return k_PopupSize;
            }
        }
    }
}

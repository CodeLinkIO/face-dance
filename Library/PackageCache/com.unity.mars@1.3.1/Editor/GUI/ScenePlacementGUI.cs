using System;
using Unity.MARS.Authoring;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Authoring;
using UnityEngine;

#if UNITY_2019_3 || UNITY_2019_4 // 19.3 & 19.4 specific.
using System.Reflection;
#endif

namespace Unity.MARS
{
    static class ScenePlacementGUI
    {
        enum LayoutSize
        {
            Normal = 0,
            Small,
            Hide
        }

        static class Styles
        {
            const string k_SnapToPivotToolTip =
                "Snap dragged prefab to pivot (Alt to invert).\n" +
                "Existing scene objects: use Move tool & hold Shift to snap.";
            const string k_OrientToSurfaceToolTip =
                "Orient dragged prefab to surface (Control to invert).\n" +
                "Existing scene objects: use Move tool & hold Shift to orient to surface.";
            const string k_NoDropTargetsHelpMessage =
                "No Drop Targets present. Create a new interactable MARS object " +
                "(eg. a Proxy with an IsFaceCondition or PlaneSizeCondition), or open a Simulation scene containing Drop Targets.";
            const string k_OverrideHelpMessage = "Some options overridden";

            public static readonly GUIContent orientToSurfaceContent;
            public static readonly GUIContent orientToSurfaceNoDropContent;
            public static readonly GUIContent orientToSurfaceOverrideContent;
            public static readonly GUIContent pivotSnappingContent;
            public static readonly GUIContent pivotSnappingNoDropContent;
            public static readonly GUIContent pivotSnappingOverrideContent;
            public static readonly GUIContent[] axisIcons;
            public static readonly GUIContent axisNoDropContent;
            public static readonly GUIContent axisOverrideContent;

            static Styles()
            {
                var uiResources = MarsUIResources.instance;
                orientToSurfaceContent = new GUIContent(uiResources.OrientToSurfaceIcon, k_OrientToSurfaceToolTip);
                orientToSurfaceNoDropContent = new GUIContent(uiResources.OrientToSurfaceIcon, k_NoDropTargetsHelpMessage);
                orientToSurfaceOverrideContent = new GUIContent(uiResources.OrientToSurfaceIcon, k_OverrideHelpMessage);
                pivotSnappingContent = new GUIContent(uiResources.PivotSnappingIcon, k_SnapToPivotToolTip);
                pivotSnappingNoDropContent = new GUIContent(uiResources.PivotSnappingIcon, k_NoDropTargetsHelpMessage);
                pivotSnappingOverrideContent = new GUIContent(uiResources.PivotSnappingIcon, k_OverrideHelpMessage);
                axisIcons = new[]
                {
                    new GUIContent(uiResources.XUpIcon, "Positive X is oriented out from surface"),
                    new GUIContent(uiResources.XDownIcon, "Negative X is oriented out from surface"),
                    new GUIContent(uiResources.YUpIcon, "Positive Y is oriented out from surface"),
                    new GUIContent(uiResources.YDownIcon, "Negative Y is oriented out from surface"),
                    new GUIContent(uiResources.ZUpIcon, "Positive Z is oriented out from surface"),
                    new GUIContent(uiResources.ZDownIcon, "Negative Z is oriented out from surface")
                };

                axisNoDropContent = new GUIContent(uiResources.YUpIcon, k_NoDropTargetsHelpMessage);
                axisOverrideContent = new GUIContent(uiResources.YUpIcon, k_OverrideHelpMessage);
            }
        }

        class ScenePlacementWindow : MarsEditorGUI.MarsPopupWindow
        {
            public override Vector2 GetWindowSize()
            {
                var appCommandStyle = MarsEditorGUI.InternalEditorStyles.AppCommand;
                return new Vector2(appCommandStyle.fixedWidth * 3f + appCommandStyle.margin.horizontal,
                    appCommandStyle.fixedHeight + appCommandStyle.margin.vertical);
            }

            protected override void Draw()
            {
                var scenePlacementModule = ModuleLoaderCore.instance.GetModule<ScenePlacementModule>();
                if (scenePlacementModule == null)
                    return;

                var internalStyles = MarsEditorGUI.InternalEditorStyles;
                var rect = new Rect();
                CalculateDropTargetButtonsGrid(rect, internalStyles.AppCommand, out var buttonWidth,
                    out var buttonHeight, out var totalWidth);
                rect = EditorGUILayout.GetControlRect(GUILayout.Width(totalWidth));

                DrawDropTargetButtonsGrid(rect, scenePlacementModule, internalStyles.AppCommandLeft,
                    internalStyles.AppCommandMid, internalStyles.AppCommandRight, buttonWidth, buttonHeight);
            }
        }

        class AxisSelectWindow : MarsEditorGUI.MarsPopupWindow
        {
            const int k_AxisCount = 6;
            const int k_SpacingCount = k_AxisCount + 2; // + 2 for menu top and bottom spacing
            public int currentAxis;

            protected override void Draw()
            {
                var placementModule = ModuleLoaderCore.instance.GetModule<ScenePlacementModule>();

                using (new GUILayout.VerticalScope(GUIStyle.none))
                {
                    for (var i = 0; i < Styles.axisIcons.Length; i++)
                    {
                        AxisSelectButton(i, placementModule);
                    }
                }
            }

            public override Vector2 GetWindowSize()
            {
                var appCommandStyle = MarsEditorGUI.InternalEditorStyles.AppCommand;

                var buttonSize = appCommandStyle.CalcSize(Styles.axisIcons[0]);
                buttonSize.x += appCommandStyle.margin.horizontal;
                var minHeight = buttonSize.y * k_AxisCount + appCommandStyle.margin.vertical * 0.5f * k_SpacingCount;

                return new Vector2(buttonSize.x, minHeight);
            }

            void AxisSelectButton(int index, ScenePlacementModule placementModule)
            {
                using (var change = new EditorGUI.ChangeCheckScope())
                {
                    if (GUILayout.Toggle( currentAxis == index, Styles.axisIcons[index],
                        MarsEditorGUI.InternalEditorStyles.AppCommand) && change.changed)
                    {
                        placementModule.orientAxis = (AxisEnum)index;
                        editorWindow.Close();
                    }
                }
            }
        }

#if UNITY_2019_3 || UNITY_2019_4 // 19.3 specific.
                                 // New approach will be necessary for 2021.
                                 // Not supported in 2020.
        class ToolbarReflectionData
        {
            const BindingFlags k_BindingFlags = BindingFlags.Default | BindingFlags.Static | BindingFlags.Instance
                | BindingFlags.NonPublic | BindingFlags.Public;
            const string k_EditorToolbarAssembly = "UnityEditor.Toolbar";
            const string k_ToolbarSettingEvent = "toolSettingsGui";

            public MethodInfo ToolSettingGUIAddMethod;
            public MethodInfo ToolSettingGUIRemoveMethod;

            public ToolbarReflectionData()
            {
                CreatePlacementToolsReflectionData();
            }

            void CreatePlacementToolsReflectionData()
            {
                var editorAssembly = typeof(EditorWindow).Assembly;
                var toolbar = editorAssembly.GetType(k_EditorToolbarAssembly);
                var toolSettingsGuiInfo = toolbar.GetEvent(k_ToolbarSettingEvent,k_BindingFlags);

                Debug.Assert(toolSettingsGuiInfo != null, $"{k_EditorToolbarAssembly}.{k_ToolbarSettingEvent} is null!");

                ToolSettingGUIAddMethod = toolSettingsGuiInfo.GetAddMethod(true);
                ToolSettingGUIRemoveMethod = toolSettingsGuiInfo.GetRemoveMethod(true);
            }

            public void CheckNeedsToolReflectionData()
            {
                if (ToolSettingGUIAddMethod == null || ToolSettingGUIRemoveMethod == null)
                    CreatePlacementToolsReflectionData();
            }
        }
#endif

        static AxisSelectWindow s_AxisSelectWindow;
        static LayoutSize s_LayoutSize;

#if UNITY_2019_3 || UNITY_2019_4 // 19.3 & 19.4 specific.
        static ToolbarReflectionData s_ToolbarReflectionData;
        static ToolbarReflectionData toolbarReflectionData => s_ToolbarReflectionData ?? (s_ToolbarReflectionData = new ToolbarReflectionData());
#endif

        static void CalculateDropTargetButtonsGrid(Rect rect, GUIStyle gridStyle, out float buttonWidth,
            out float buttonHeight, out float totalWidth)
        {
            // layout and style usage based on `GUI.DoButtonGrid()`
            buttonWidth = rect.width / 3;
            if (gridStyle.fixedWidth > float.Epsilon)
                buttonWidth = gridStyle.fixedWidth;

            buttonHeight = rect.height;
            if (gridStyle.fixedHeight > float.Epsilon)
                buttonHeight = gridStyle.fixedHeight;

            totalWidth = buttonWidth * 3;
        }

        static void DrawDropTargetButtonsGrid(Rect rect, ScenePlacementModule scenePlacementModule,
            GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, float buttonWidth, float buttonHeight)
        {
            var dropTargetsExist = InteractionTarget.AllTargets.Count > 0;

            using (new EditorGUI.DisabledScope(scenePlacementModule.isDragging || !dropTargetsExist))
            {
                var overrides = scenePlacementModule.PlacementOverrides;
                var snapOverride = overrides.useSnapToPivotOverride;

                using (var change = new EditorGUI.ChangeCheckScope())
                {
                    bool snapToPivot;
                    bool orientToSurface;

                    using (new EditorGUI.DisabledScope(snapOverride))
                    {
                        var snapOverrideRect = new Rect(rect.x, rect.y, buttonWidth, buttonHeight);
                        var pivotSnappingContent = !dropTargetsExist ? Styles.pivotSnappingNoDropContent :
                            snapOverride ? Styles.pivotSnappingOverrideContent : Styles.pivotSnappingContent;
                        snapToPivot = GUI.Toggle(snapOverrideRect, scenePlacementModule.snapToPivot,
                            pivotSnappingContent, firstStyle);
                    }

                    var orientOverride = overrides.useOrientToSurfaceOverride;

                    using (new EditorGUI.DisabledScope(orientOverride))
                    {
                        var orientOverrideRect = new Rect(rect.x + buttonWidth, rect.y, buttonWidth, buttonHeight);
                        var orientToSurfaceContent = !dropTargetsExist ? Styles.orientToSurfaceNoDropContent :
                            orientOverride ? Styles.orientToSurfaceOverrideContent : Styles.orientToSurfaceContent;
                        orientToSurface = GUI.Toggle(orientOverrideRect, scenePlacementModule.orientToSurface,
                            orientToSurfaceContent, midStyle);
                    }

                    using (new EditorGUI.DisabledScope(!scenePlacementModule.orientToSurface))
                    {
                        var axisOverride = overrides.useAxisOverride;

                        using (new EditorGUI.DisabledScope(axisOverride))
                        {
                            var axisIndex = (int)scenePlacementModule.orientAxis;
                            var stylesAxisIcon = !dropTargetsExist ? Styles.axisNoDropContent :
                                axisOverride ? Styles.axisOverrideContent : Styles.axisIcons[axisIndex];

                            if (s_AxisSelectWindow == null)
                                s_AxisSelectWindow = new AxisSelectWindow();

                            s_AxisSelectWindow.currentAxis = axisIndex;

                            var axisRect = new Rect(rect.x + buttonWidth * 2, rect.y, buttonWidth, buttonHeight);

                            if (GUI.Button(axisRect, stylesAxisIcon, lastStyle))
                            {
                                PopupWindow.Show(axisRect, s_AxisSelectWindow);
                                GUIUtility.ExitGUI();
                            }
                        }
                    }

                    if (change.changed)
                    {
                        scenePlacementModule.snapToPivot = snapToPivot;
                        scenePlacementModule.orientToSurface = orientToSurface;
                    }
                }
            }
        }

        public static void DrawPlacementToolSettings(Rect rect)
        {
            DrawPlacementToolSettings(rect, true);
        }

        public static void DrawPlacementToolSettings(Rect rect, bool CalculateWidth)
        {
            const float smallSpace = 6f;

            var scenePlacementModule = ModuleLoaderCore.instance.GetModule<ScenePlacementModule>();
            if (scenePlacementModule == null)
                return;

            var internalStyles = MarsEditorGUI.InternalEditorStyles;
            var placementToolSettingsRect = rect;

            CalculateDropTargetButtonsGrid(placementToolSettingsRect, internalStyles.AppCommand, out var buttonWidth,
                out var buttonHeight, out var totalWidth);

            switch (s_LayoutSize)
            {
                case LayoutSize.Normal:
                {
                    DrawDropTargetButtonsGrid(placementToolSettingsRect, scenePlacementModule,
                        internalStyles.AppCommandLeft, internalStyles.AppCommandMid, internalStyles.AppCommandRight,
                        buttonWidth, buttonHeight);
                    break;
                }
                case LayoutSize.Small:
                {
                    if (!CalculateWidth)
                        goto case LayoutSize.Normal;

                    var foldoutRect = new Rect(placementToolSettingsRect.x, placementToolSettingsRect.y,
                        buttonWidth + smallSpace, buttonHeight);
                    if (EditorGUI.DropdownButton(foldoutRect, Styles.pivotSnappingContent, FocusType.Passive,
                        internalStyles.Dropdown))
                    {
                        PopupWindow.Show(foldoutRect, new ScenePlacementWindow());
                    }
                    break;
                }
                default:
                {
                    if (!CalculateWidth)
                        goto case LayoutSize.Normal;

                    break;
                }
            }

            if (CalculateWidth)
            {
                var smallWidth = totalWidth + smallSpace;

                if (smallWidth <= rect.width)
                    s_LayoutSize = LayoutSize.Normal;
                else if (buttonWidth > rect.width)
                    s_LayoutSize = LayoutSize.Hide;
                else
                    s_LayoutSize = LayoutSize.Small;
            }
        }

        public static void AddPlacementSettingsToToolbar()
        {
#if UNITY_2019_3 || UNITY_2019_4 // 19.3 & 19.4 specific.
            Action<Rect> guiAction = DrawPlacementToolSettings;
            toolbarReflectionData.CheckNeedsToolReflectionData();
            toolbarReflectionData.ToolSettingGUIAddMethod.Invoke(null, new object[]{ guiAction });
#endif
        }

        public static void RemovePlacementSettingsFromToolbar()
        {
#if UNITY_2019_3 || UNITY_2019_4 // 19.3 & 19.4 specific.
            Action<Rect> guiAction = DrawPlacementToolSettings;
            toolbarReflectionData.CheckNeedsToolReflectionData();
            toolbarReflectionData.ToolSettingGUIRemoveMethod.Invoke(null, new object[]{ guiAction });
#endif
        }
    }
}

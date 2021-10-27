using System.Reflection;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEngine;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Custom editor styles used in the MARS Editor
    /// </summary>
    static class MarsEditorGUI
    {
        /// <summary>
        /// Editor GUI Styles and resources for the MARS Editor
        /// </summary>
        internal class MarsStyles
        {
            const int k_AreaHorizontalMargin = 0;
            const int k_AreaHorizontalLargeMargin = 4;
            const int k_AreaVerticalMargin = 5;
            const int k_ElementHorizontalMargin = 5;
            const int k_ElementVerticalMargin = 5;
            const int k_ElementHorizontalPadding = 2;
            const int k_ElementVerticalPadding = 2;

            internal const int EditBindingsButtonWidth = 32;
            internal const int EditBindingsButtonHeight = 24;
            internal static readonly int LabelOffsetHalfBindingsButtonWidth = (int) EditorGUIUtility.labelWidth - EditBindingsButtonWidth / 2;
            internal static readonly GUILayoutOption[] BindingButtonGUIOptions = {GUILayout.Width(EditBindingsButtonWidth), GUILayout.Height(EditBindingsButtonHeight)};

            public const int ButtonElementSeparation = 5;

            public readonly RectOffset imagePaddingRect = new RectOffset(1, 1, 1, 1);
            readonly RectOffset m_ZeroRectOffset = new RectOffset(0,0,0,0);
            readonly RectOffset m_AreaMargin = new RectOffset(k_AreaHorizontalMargin,
                k_AreaHorizontalMargin, k_AreaVerticalMargin, k_AreaVerticalMargin);
            readonly RectOffset m_AreaLargeMargin = new RectOffset(k_AreaHorizontalLargeMargin,
                k_AreaHorizontalLargeMargin, k_AreaVerticalMargin, k_AreaVerticalMargin);

            public readonly RectOffset elementMargin = new RectOffset(k_ElementHorizontalMargin,
                k_ElementHorizontalMargin, k_ElementVerticalMargin, k_ElementVerticalMargin);
            public readonly RectOffset elementPadding = new RectOffset(k_ElementHorizontalPadding,
                k_ElementHorizontalPadding, k_ElementVerticalPadding, k_ElementVerticalPadding);

            /// <summary>
            /// Will use the margins from all sides elements within this scope.
            /// This works differently than default / no style for area scopes.
            /// </summary>
            public readonly GUIStyle NoMarginScopeAlignment;
            public readonly GUIStyle NoVerticalMarginScopeAlignment;

            public readonly GUIStyle SingleLineAlignment;
            public readonly GUIStyle AreaAlignment;
            public readonly GUIStyle AreaAlignmentLargeMargin;
            public readonly GUIStyle AreaAlignmentWithPadding;

            public readonly GUIStyle Button;
            public readonly GUIStyle SingleLineButton;
            public readonly GUIStyle MiniFontButton;
            public readonly GUIStyle DropDownButton;
            public readonly GUIStyle LabelLeftAligned;

            public readonly GUIStyle ToolbarButton;
            public readonly GUIStyle ToolbarDropDown;
            public readonly GUIStyle ToolbarLabel;

            public readonly GUIStyle HeaderToggle;
            public readonly GUIStyle HeaderLabel;

            public readonly GUIStyle LeftAlignedWrapLabel;
            public readonly GUIStyle BoldFoldout;

            public readonly Texture AnimationVisibilityToggleOn;
            public readonly Texture AnimationVisibilityToggleOff;

            public readonly Texture HelpIcon;
            public readonly Texture SettingsIcon;

            public readonly Texture TabNext;

            // Derived from Styling in PostProcessing
            public readonly GUIStyle SmallTickBox;
            public readonly GUIStyle MiniLabelButton;
            public readonly GUIStyle LabelHeader;
            public readonly GUIContent AddButtonContent;
            public readonly GUIContent IconToolbarMinus;
            public readonly Vector2 IconToolbarMinusSize;
            // Derived from RuntimeUtilities in PostProcessing
            public readonly Texture2D TransparentTexture;
            public readonly float ToolbarHeight;
            public readonly float ToolbarHeightNew;

            public readonly GUIStyle Toolbar;
            public readonly GUIStyle ToolbarNew;
            public readonly Texture2D PaneOptionsIcon;
            public readonly Color BlueText;

            public readonly GUIStyle TopMarkerLibraryStyle;

            internal readonly GUIStyle ResetLabelMarginStyle;
            internal readonly GUIStyle ResetButtonMarginStyle;
            internal readonly GUIStyle IconButtonStyle;
            internal readonly GUIStyle IconButtonNoMarginStyle;

            internal MarsStyles()
            {
                var isProStyle = EditorGUIUtility.isProSkin;

                TopMarkerLibraryStyle = GUI.skin.GetStyle("Box");
                TopMarkerLibraryStyle.alignment = TextAnchor.MiddleLeft;
                TopMarkerLibraryStyle.normal.textColor = Color.white;

                TransparentTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false) { name = "Transparent Texture" };
                TransparentTexture.SetPixel(0, 0, Color.clear);
                TransparentTexture.Apply();

                AnimationVisibilityToggleOn = EditorGUIUtility.IconContent("animationvisibilitytoggleon").image;
                AnimationVisibilityToggleOff = EditorGUIUtility.IconContent("animationvisibilitytoggleoff").image;
                HelpIcon = EditorGUIUtility.TrIconContent("_Help").image;
                SettingsIcon = EditorGUIUtility.TrIconContent("_Popup").image;

                SmallTickBox = new GUIStyle("ShurikenCheckMark");

                MiniLabelButton = new GUIStyle(EditorStyles.miniLabel);
                MiniLabelButton.normal = new GUIStyleState
                {
                    background = TransparentTexture,
                    scaledBackgrounds = null,
                    textColor = Color.grey
                };
                BlueText = isProStyle ? new Color(0.3f, 0.5f, 0.85f, 1f) :
                    new Color(0f, 0.15625f, 0.515625f, 1f);

                var activeState = new GUIStyleState
                {
                    background = TransparentTexture,
                    scaledBackgrounds = null,
                    textColor = Color.white
                };
                TabNext = isProStyle ? EditorGUIUtility.IconContent("d_tab_next").image : EditorGUIUtility.IconContent("tab_next").image;

                MiniLabelButton.active = activeState;
                MiniLabelButton.onNormal = activeState;
                MiniLabelButton.onActive = activeState;

                PaneOptionsIcon = isProStyle ?
                    (Texture2D) EditorGUIUtility.Load("Builtin Skins/DarkSkin/Images/pane options.png") :
                    (Texture2D) EditorGUIUtility.Load("Builtin Skins/LightSkin/Images/pane options.png");

                LabelHeader = new GUIStyle(EditorStyles.miniLabel);

                AddButtonContent = new GUIContent("Add Event");
                IconToolbarMinus =  new GUIContent(EditorGUIUtility.IconContent("Toolbar Minus"))
                {
                    tooltip = "Remove all events in this list."
                };
                IconToolbarMinusSize = GUIStyle.none.CalcSize(IconToolbarMinus);

                NoMarginScopeAlignment = new GUIStyle(GUIStyle.none)
                {
                    margin = m_ZeroRectOffset,
                    padding = m_ZeroRectOffset,
                };

                AreaAlignment = new GUIStyle(GUIStyle.none)
                {
                    margin = m_AreaMargin,
                    padding = m_ZeroRectOffset
                };

                AreaAlignmentLargeMargin = new GUIStyle(GUIStyle.none)
                {
                    margin = m_AreaLargeMargin,
                    padding = m_ZeroRectOffset
                };

                AreaAlignmentWithPadding = new GUIStyle(GUIStyle.none)
                {
                    margin = m_AreaMargin,
                    padding = m_AreaMargin
                };

                NoVerticalMarginScopeAlignment = new GUIStyle(GUIStyle.none)
                {
                    margin = new RectOffset(k_AreaHorizontalMargin, k_AreaHorizontalMargin, 0, 0),
                    padding = m_ZeroRectOffset
                };

                SingleLineAlignment = new GUIStyle(GUI.skin.label)
                {
                    stretchHeight = false,
                    stretchWidth = false,
                    alignment = TextAnchor.MiddleLeft,
                    margin = elementMargin,
                    padding = elementPadding,
                    wordWrap = false,
                    clipping = TextClipping.Overflow
                };

                Button = new GUIStyle(GUI.skin.button)
                {
                    margin = elementMargin,
                    padding = elementPadding
                };

                SingleLineButton = new GUIStyle(Button)
                {
                    fixedHeight = SingleLineAlignment.fixedHeight,
                    margin = SingleLineAlignment.margin,
                    wordWrap = false,
                    alignment = TextAnchor.MiddleCenter
                };

                MiniFontButton = new GUIStyle(Button)
                {
                    padding = new RectOffset(8, 8, 4, 4),
                    alignment = TextAnchor.MiddleCenter,
                    font = EditorStyles.miniFont
                };

                var dropDown = new GUIStyle("DropDownButton");
                var dropDownPadding = dropDown.padding;

                // Current UI images for have drop shadow baked in so margin and overflow need to account for that.
                // This done to keep the text for a label inline with the dropdown.
                DropDownButton = new GUIStyle(dropDown)
                {
                    margin = new RectOffset(elementMargin.left, elementMargin.right, elementMargin.top + 1, elementMargin.bottom),
                    overflow = m_ZeroRectOffset,
                    padding = new RectOffset(dropDownPadding.left, dropDownPadding.right, dropDownPadding.top - 1, dropDownPadding.bottom + 1),
                    alignment = TextAnchor.MiddleLeft
                };

                LabelLeftAligned = new GUIStyle(GUI.skin.label)
                {
                    fixedHeight = SingleLineAlignment.fixedHeight,
                    margin = SingleLineAlignment.margin,
                    padding = SingleLineAlignment.padding,
                    imagePosition = ImagePosition.TextOnly,

                    stretchHeight = SingleLineAlignment.stretchHeight,
                    alignment = TextAnchor.MiddleLeft
                };

                var toolbarBackground = MarsUIResources.instance.ToolbarBackground;
                var toolbarBackgroundScaled = new []{ MarsUIResources.instance.ToolbarBackground2X };
                var toolbarButtonImage = MarsUIResources.instance.ToolbarButton;
                var toolbarButtonScaledImage = new[] { MarsUIResources.instance.ToolbarButton2X };
                var toolbarDropdownImage = MarsUIResources.instance.ToolbarDropdown;
                HeaderToggle = new GUIStyle(EditorStyles.foldout);
                HeaderLabel = new GUIStyle(EditorStyles.boldLabel);

                LeftAlignedWrapLabel = new GUIStyle(EditorStyles.label)
                {
                    clipping = TextClipping.Overflow,
                    alignment = TextAnchor.MiddleLeft,
                    wordWrap = true
                };

                BoldFoldout = new GUIStyle(EditorStyles.foldout)
                {
                    fontStyle = FontStyle.Bold,
                    stretchWidth = true,
                    clipping = TextClipping.Overflow
                };

                Toolbar = new GUIStyle(EditorStyles.toolbar)
                {
                    fixedHeight = 22,
                    stretchHeight = false,
                    normal =
                    {
                        background = toolbarBackground,
                        scaledBackgrounds = toolbarBackgroundScaled
                    }
                };

                ToolbarHeight = Toolbar.CalcHeight(GUIContent.none, 1);

#if UNITY_2019_3_OR_NEWER
                var appCommand = GUI.skin.GetStyle("AppCommand");
#else
                var appCommand = GUI.skin.GetStyle("Toolbar");
#endif
                var toolBarStyleState = new GUIStyleState
                {
                    background = appCommand.normal.background,
                    scaledBackgrounds = appCommand.normal.scaledBackgrounds
                };

                ToolbarNew = new GUIStyle(appCommand)
                {
                    fixedHeight = 28,
                    fixedWidth = 0,
                    stretchHeight = true,
                    stretchWidth = true,
                    normal = toolBarStyleState,
                };

                ToolbarHeightNew = ToolbarNew.CalcHeight(GUIContent.none, 1);

                ToolbarButton = new GUIStyle(EditorStyles.toolbarButton)
                {
                    richText = true,
                    fixedHeight = Toolbar.fixedHeight,
                    stretchHeight = Toolbar.stretchHeight,
                    normal =
                    {
                        background = toolbarButtonImage,
                        scaledBackgrounds = toolbarButtonScaledImage
                    }
                };

                ToolbarLabel = new GUIStyle(EditorStyles.toolbarButton)
                {
                    richText = true,
                    fixedHeight = Toolbar.fixedHeight,
                    stretchHeight = Toolbar.stretchHeight,
                    normal =
                    {
                        background = toolbarBackground,
                        scaledBackgrounds = toolbarBackgroundScaled
                    }
                };

                ToolbarDropDown = new GUIStyle(EditorStyles.toolbarDropDown)
                {
                    richText = true,
                    contentOffset = Vector2.zero,
                    fixedHeight = Toolbar.fixedHeight,
                    stretchHeight = Toolbar.stretchHeight,
                    normal =
                    {
                        background = toolbarDropdownImage,
                        scaledBackgrounds = toolbarButtonScaledImage
                    }
                };

                HeaderToggle = new GUIStyle(EditorStyles.foldout);
                HeaderLabel = new GUIStyle(EditorStyles.boldLabel);

                LeftAlignedWrapLabel = new GUIStyle(EditorStyles.label)
                {
                    clipping = TextClipping.Overflow,
                    alignment = TextAnchor.MiddleLeft,
                    wordWrap = true
                };

                BoldFoldout = new GUIStyle(EditorStyles.foldout)
                {
                    fontStyle = FontStyle.Bold,
                    stretchWidth = true,
                    clipping = TextClipping.Overflow
                };

                ResetLabelMarginStyle = new GUIStyle(GUI.skin.label) {
                    margin = new RectOffset(0, 0, 0, 0)
                };

                ResetButtonMarginStyle = new GUIStyle(GUI.skin.button) {
                    margin = new RectOffset(0, 0, 0, 0)
                };

                IconButtonStyle = new GUIStyle(GUI.skin.button) {
                    padding = new RectOffset(4, 4, 4, 4)
                };

                IconButtonNoMarginStyle = new GUIStyle(GUI.skin.button) {
                    padding = new RectOffset(4, 4, 4, 4),
                    margin = new RectOffset(0, 0, 0, 0)
                };
            }
        }

        /// <summary>
        /// Exposes internal editor GUIStyles and layout values
        /// </summary>
        internal class InternalEditorStylesSettings
        {
            public readonly GUIStyle AppCommand;
            public readonly GUIStyle AppCommandLeft;
            public readonly GUIStyle AppCommandMid;
            public readonly GUIStyle AppCommandRight;

            public readonly GUIStyle AppToolbarButtonLeft;
            public readonly GUIStyle AppToolbarButtonRight;

            public readonly GUIStyle Dropdown;

            public readonly GUIStyle Button;
            public readonly GUIStyle ButtonLeft;
            public readonly GUIStyle ButtonMid;
            public readonly GUIStyle ButtonRight;

            public readonly GUIStyle ButtonIcon;
            public readonly GUIStyle ButtonLeftIcon;
            public readonly GUIStyle ButtonMidIcon;
            public readonly GUIStyle ButtonRightIcon;

            public readonly GUIStyle TreeViewSelection;
            public readonly GUIStyle TreeViewLine;

            public readonly GUIStyle Popup;
            public readonly GUIStyle InLock;

            public readonly GUIStyle FooterButtonStyle;

            // From `SceneVisibilityHierarchyGUI.cs`
            public readonly Color TreeViewBackgroundColor;
            public readonly Color TreeViewHoveredBackgroundColor;
            public readonly Color TreeViewSelectedBackgroundColor;
            public readonly Color TreeViewSelectedNoFocusBackgroundColor;

            internal InternalEditorStylesSettings()
            {
#if UNITY_2019_3_OR_NEWER
                AppCommand = GUI.skin.GetStyle("AppCommand");
                AppCommandLeft = GUI.skin.GetStyle("AppCommandLeft");
                AppCommandMid = GUI.skin.GetStyle("AppCommandMid");
                AppCommandRight = GUI.skin.GetStyle("AppCommandRight");
#else
                AppCommand = GUI.skin.GetStyle("Button");
                AppCommandLeft = GUI.skin.GetStyle("ButtonLeft");
                AppCommandMid = GUI.skin.GetStyle("ButtonMid");
                AppCommandRight = GUI.skin.GetStyle("ButtonRight");
#endif

                AppToolbarButtonLeft = GUI.skin.GetStyle("AppToolbarButtonLeft");
                AppToolbarButtonRight = GUI.skin.GetStyle("AppToolbarButtonRight");

                Dropdown = GUI.skin.GetStyle("Dropdown");

                Button = GUI.skin.GetStyle("Button");
                ButtonLeft = new GUIStyle(GUI.skin.GetStyle("ButtonLeft"));
                ButtonLeft.margin.top = Button.margin.top;
                ButtonLeft.border = Button.border;

                ButtonMid = new GUIStyle(GUI.skin.GetStyle("ButtonMid"));
                ButtonMid.margin.top = Button.margin.top;
                ButtonMid.border = Button.border;

                ButtonRight = new GUIStyle(GUI.skin.GetStyle("ButtonRight"));
                ButtonRight.margin.top = Button.margin.top;
                ButtonRight.border = Button.border;

                FooterButtonStyle = new GUIStyle("RL FooterButton");

                Popup = new GUIStyle(EditorStyles.popup)
                {
                    fixedHeight = 0,
                };

                InLock = new GUIStyle("IN LockButton");

                var buttonIconOffset = new RectOffset(0, 0, 0, 0);
                ButtonIcon = new GUIStyle(Button)
                {
                    imagePosition = ImagePosition.ImageOnly,
                    alignment = TextAnchor.MiddleCenter,
                    padding = buttonIconOffset
                };

                ButtonLeftIcon = new GUIStyle(ButtonLeft)
                {
                    imagePosition = ImagePosition.ImageOnly,
                    alignment = TextAnchor.MiddleCenter,
                    padding = buttonIconOffset
                };

                ButtonMidIcon = new GUIStyle(ButtonMid)
                {
                    imagePosition = ImagePosition.ImageOnly,
                    alignment = TextAnchor.MiddleCenter,
                    padding = buttonIconOffset
                };

                ButtonRightIcon = new GUIStyle(ButtonRight)
                {
                    imagePosition = ImagePosition.ImageOnly,
                    alignment = TextAnchor.MiddleCenter,
                    padding = buttonIconOffset
                };

                // SceneVisibilityHierarchyGUI reflection
                const BindingFlags bindingFlags = BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic
                    | BindingFlags.Static | BindingFlags.Instance;
                var editorAssembly = typeof(EditorWindow).Assembly;
                var hierarchyGUI = editorAssembly.GetType("UnityEditor.SceneVisibilityHierarchyGUI");
                var hierarchyGUIStyles = hierarchyGUI.GetNestedType("Styles", bindingFlags);
                // Color GetItemBackgroundColor(bool isHovered, bool isSelected, bool isFocused)
                var getItemBackgroundColor = hierarchyGUIStyles.GetMethod("GetItemBackgroundColor", bindingFlags);

                Debug.Assert(getItemBackgroundColor != null, nameof(getItemBackgroundColor) + " != null");
                TreeViewBackgroundColor = (Color)getItemBackgroundColor.Invoke(null,
                    new object[] { false, false, false });
                TreeViewHoveredBackgroundColor = (Color)getItemBackgroundColor.Invoke(null,
                    new object[] { true, false, false });
                TreeViewSelectedBackgroundColor = (Color)getItemBackgroundColor.Invoke(null,
                    new object[] { false, true, true });
                TreeViewSelectedNoFocusBackgroundColor = (Color)getItemBackgroundColor.Invoke(null,
                    new object[] { false, true, false });

                TreeViewLine = GUI.skin.GetStyle("TV Line");
                TreeViewSelection = GUI.skin.GetStyle("TV Selection");
            }

            public Color GetTreeViewItemBackgroundColor(bool isHovered, bool isSelected, bool isFocused)
            {
                if (isSelected)
                {
                    if (isFocused)
                        return TreeViewSelectedBackgroundColor;

                    return TreeViewSelectedNoFocusBackgroundColor;
                }

                if (isHovered)
                    return TreeViewHoveredBackgroundColor;

                return TreeViewBackgroundColor;
            }
        }

        /// <summary>
        /// Base class for custom popup windows in MARS
        /// </summary>
        internal abstract class MarsPopupWindow : PopupWindowContent
        {
            public override void OnGUI(Rect rect)
            {
                // Content
                Draw();

                // Use mouse move so we get hover state correctly in the menu item rows
                if (Event.current.type == EventType.MouseMove)
                    Event.current.Use();

                // Escape closes the window
                if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
                {
                    editorWindow.Close();
                    GUIUtility.ExitGUI();
                }
            }

            protected virtual void Draw() { }
        }

        /// <summary>
        /// Custom Popup Window for selecting Simulation Scene Type
        /// </summary>
        /// <inheritdoc />
        internal class SceneTypeWindow : MarsPopupWindow
        {
            static readonly Vector2 k_PopupSize = new Vector2(280f, 194f);
            readonly ISimulationView m_SimView;
            readonly GUIContent[] m_Contents;

            public SceneTypeWindow(ISimulationView view, GUIContent[] contents)
            {
                m_SimView = view;
                m_Contents = contents;
            }

            protected override void Draw()
            {
                if (m_SimView == null || m_SimView.SceneType == ViewSceneType.None)
                    return;

                using (new EditorGUILayout.VerticalScope(Styles.AreaAlignmentLargeMargin))
                {
                    SimulationControlsGUI.ViewSelectionElement(m_SimView, m_Contents);

                    EditorGUIUtils.DrawSplitter();

                    SimulationControlsGUI.DrawControlsWindow(false);
                }
            }

            public override Vector2 GetWindowSize()
            {
                return k_PopupSize;
            }
        }

        /// <summary>
        /// Value to use for Max window size that is larger than can be reasonably used
        /// but does not lock the window resizing functionality.
        /// </summary>
        internal const float MaxWindowSize = 1000000f;

        internal const float IndentSize = 15f;
        internal const float SettingsLabelWidth = 215;

        static MarsStyles s_Styles;

        /// <summary>
        ///  Editor GUI Styles and resources for the MARS Editor.
        /// </summary>
        internal static MarsStyles Styles => s_Styles ?? (s_Styles = new MarsStyles());

        static InternalEditorStylesSettings s_InternalEditorStyles;

        /// <summary>
        /// Editor GUI Styles from Unity's managed gui.
        /// </summary>
        internal static InternalEditorStylesSettings InternalEditorStyles
        {
            get { return s_InternalEditorStyles ?? (s_InternalEditorStyles = new InternalEditorStylesSettings()); }
        }

        internal static void ButtonSpacer()
        {
            GUILayout.Space(MarsStyles.ButtonElementSeparation);
        }

        internal static Rect GetDropDownButtonRect(GUIContent content, GUIStyle style, float height)
        {
            var size = style.CalcSize(content);
            return EditorGUILayout.GetControlRect(false, height, style, GUILayout.Width(size.x));
        }

        internal static void DrawReloadButton(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            using (new EditorGUI.DisabledScope(EditorApplication.isPlayingOrWillChangePlaymode))
            {
                if (GUILayout.Button(content, style, options))
                {
                    var moduleLoader = ModuleLoaderCore.instance;
                    var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
                    var querySimulationModule = moduleLoader.GetModule<QuerySimulationModule>();
                    if (querySimulationModule.simulatingTemporal)
                        querySimulationModule.RequestSimulationModeSelection(SimulationModeSelection.TemporalMode);

                    environmentManager.TryRefreshEnvironmentAndRestartSimulation();
                }
            }
        }
    }
}

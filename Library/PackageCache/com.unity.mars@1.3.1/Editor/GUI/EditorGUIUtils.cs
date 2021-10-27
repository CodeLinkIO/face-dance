using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.MARS.Attributes;
using Unity.XRTools.Utils;
using UnityEditor.Callbacks;
using UnityEditor.MARS.Attributes;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Scripting.APIUpdating;

using UnityObject = UnityEngine.Object;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Collection of Editor GUI Utility methods.
    /// </summary>
    // Derived from EditorUtilities from PostProcessing
    [MovedFrom("Unity.MARS")]
    public static class EditorGUIUtils
    {
        const string k_PreviewGUIClassName = "PreviewGUI";
        const string k_Drag2DMethodName = "Drag2D";
        const int k_BackgroundRectX = 1;
        const int k_BackgroundRectY = 17;
        const int k_LabelMarginLeft = 20;
        const int k_LabelMarginRight = 20;
        const int k_ToggleMargin = 2;
        const int k_ToggleSize = 13;
        const int k_MenuMargin = 2;
        const int k_CheckboxRectSize = 17;
        const int k_CheckboxVerticalOffset = 4;
        const float k_BackgroundTintDark = 0.1f;
        const float k_BackgroundTintLight = 1f;
        const float k_BackgroundAlpha = 0.2f;
        const string k_SceneBackgroundPrefsKey = "Scene/Background";

        static readonly Vector2 k_MouseLabelOffset = new Vector2(15, 15);

        static Dictionary<string, GUIContent> s_GUIContentCache = new Dictionary<string, GUIContent>();
        static Dictionary<Type, AttributeDecorator> s_AttributeDecorators = new Dictionary<Type, AttributeDecorator>();

        static object s_PreviewGUI;
        static MethodInfo s_Drag2DMethodInfo;

        static readonly PropertyInfo s_ObjectFieldButtonStyleProperty =
            typeof(EditorStyles).GetProperty("objectFieldButton",BindingFlags.NonPublic | BindingFlags.Static);

        static readonly GUIStyle s_ObjectFieldButtonStyle;

        static EditorGUIUtils()
        {
            ReloadDecoratorTypes();
        }

        [DidReloadScripts]
        static void OnEditorReload()
        {
            ReloadDecoratorTypes();
        }

        static void ReloadDecoratorTypes()
        {
            s_AttributeDecorators.Clear();

            // Look for all the valid attribute decorators
            var types = new List<Type>();

            typeof(AttributeDecorator).GetAssignableTypes(types, type =>
                type.IsDefined(typeof(DecoratorAttribute), false) && !type.IsAbstract);

            // Store them
            foreach (var type in types)
            {
                var attr = type.GetAttribute<DecoratorAttribute>();
                var decorator = (AttributeDecorator)Activator.CreateInstance(type);
                s_AttributeDecorators.Add(attr.attributeType, decorator);
            }
        }

        /// <summary>
        /// Draw a thin line, for use between component stack headers
        /// </summary>
        internal static void DrawSplitter()
        {
            var rect = GUILayoutUtility.GetRect(1f, 1f);

            // Splitter rect should be full-width
            rect.xMin = 0f;
            rect.width = EditorGUIUtility.currentViewWidth;

            if (Event.current.type != EventType.Repaint)
                return;

            EditorGUI.DrawRect(rect, !EditorGUIUtility.isProSkin
                ? new Color(0.6f, 0.6f, 0.6f, 1.333f)
                : new Color(0.12f, 0.12f, 0.12f, 1.333f));
        }

        /// <summary>
        /// Draw a splitter using the style of a 1pixel box.
        /// </summary>
        internal static void DrawBoxSplitter()
        {
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1f));
        }

        /// <summary>
        /// Reserve a checkbox-sized rectangle
        /// </summary>
        /// <returns>The reserved rectangle</returns>
        internal static Rect DrawCheckboxFillerRect()
        {
            var overrideRect = GUILayoutUtility.GetRect(k_CheckboxRectSize, k_CheckboxRectSize, GUILayout.ExpandWidth(false));
            overrideRect.yMin += k_CheckboxVerticalOffset;
            return overrideRect;
        }

        /// <summary>
        /// Reserve a checkbox-sized rectangle, given a max bounding region
        /// </summary>
        /// <param name="source">The source rect to fit this checkbox within</param>
        /// <returns>The reserved rectangle</returns>
        internal static Rect DrawCheckboxFillerRect(ref Rect source)
        {
            var overrideRect = new Rect(source.xMin, source.yMin + k_CheckboxVerticalOffset, k_CheckboxRectSize, k_CheckboxRectSize);
            source.xMin += Mathf.Min(k_CheckboxRectSize, source.width);
            return overrideRect;
        }

        /// <summary>
        /// Draw a component stack style checkbox, showing the value of <paramref name="property"/>
        /// </summary>
        /// <param name="rect">Rect in which to draw the checkbox</param>
        /// <param name="property">Property to reflect in the checkbox (must be a Boolean)</param>
        internal static void DrawOverrideCheckbox(Rect rect, SerializedPropertyData property)
        {
            if (property == null || property.Value.propertyType != SerializedPropertyType.Boolean)
                return;
            DrawOverrideCheckbox(rect, property.Value);
        }

        /// <summary>
        /// Draw a component stack style checkbox, showing the value of <paramref name="property"/>
        /// </summary>
        /// <param name="rect">Rect in which to draw the checkbox</param>
        /// <param name="property">Property to reflect in the checkbox (must be a Boolean)</param>
        internal static void DrawOverrideCheckbox(Rect rect, SerializedProperty property)
        {
            if (property == null || property.propertyType != SerializedPropertyType.Boolean)
                return;
            var oldColor = GUI.color;
            GUI.color = new Color(0.6f, 0.6f, 0.6f, 0.75f);
            property.boolValue = GUI.Toggle(rect, property.boolValue, GetContent(property.tooltip),
                MarsEditorGUI.Styles.SmallTickBox);
            GUI.color = oldColor;
        }

        /// <summary>
        /// Draw a component stack style header
        /// </summary>
        /// <param name="title">Label to display on the header</param>
        /// <param name="propertyGroup">Property representing the component</param>
        /// <param name="activeField">Property representing if the component is active</param>
        /// <param name="resetAction">Action to reset the component from the header context menu</param>
        /// <param name="removeAction">Action to remove the component from the header context menu</param>
        /// <param name="copyAction">Action to copy the component from the header context menu</param>
        /// <param name="pasteAction">Action to paste the component from the header context menu</param>
        /// <param name="canPaste">Can the copied component be pasted</param>
        /// <param name="drawFoldout">Draw the foldout drop down and do foldout behavior</param>
        /// <returns>Returns true if the header is expanded</returns>
        internal static bool DrawHeader(string title, SerializedProperty propertyGroup, SerializedProperty activeField,
            Action resetAction, Action removeAction, Action copyAction, Action pasteAction, bool canPaste, bool drawFoldout,
            Action helpButton)
        {
            Assert.IsNotNull(propertyGroup);
            Assert.IsNotNull(activeField);

            var backgroundRect = GUILayoutUtility.GetRect(k_BackgroundRectX, k_BackgroundRectY);
            
            var hasHelp = helpButton != null;
            var helpRect = default(Rect);
            
            var labelRect = backgroundRect;
            labelRect.xMin += k_LabelMarginLeft;
            labelRect.xMax -= k_LabelMarginRight;

            var toggleRect = backgroundRect;
            toggleRect.width = k_ToggleSize;
            toggleRect.height = k_ToggleSize;

            var foldoutRect = toggleRect;
            toggleRect.x = labelRect.x - toggleRect.width;
            toggleRect.y += k_ToggleMargin;

            var menuIcon = MarsEditorGUI.Styles.PaneOptionsIcon;

            var menuRect = new Rect(labelRect.xMax + k_MenuMargin, labelRect.y + k_MenuMargin -1, menuIcon.width,
                menuIcon.height);

            // Background
            var backgroundTint = EditorGUIUtility.isProSkin
                ? k_BackgroundTintDark
                : k_BackgroundTintLight;

            // Background rect should be full-width
            backgroundRect.xMin = 0f;
            backgroundRect.xMax = EditorGUIUtility.currentViewWidth;
            EditorGUI.DrawRect(backgroundRect, new Color(backgroundTint, backgroundTint, backgroundTint,
                k_BackgroundAlpha));

            // Title
            using (new EditorGUI.DisabledScope(!activeField.boolValue))
                EditorGUI.LabelField(labelRect, GetContent(title), EditorStyles.boldLabel);

            // Active checkbox
            activeField.serializedObject.Update();
            activeField.boolValue = GUI.Toggle(toggleRect, activeField.boolValue, GUIContent.none,
                MarsEditorGUI.Styles.SmallTickBox);

            // Foldout
            if (drawFoldout)
                propertyGroup.isExpanded = EditorGUI.Foldout(foldoutRect, propertyGroup.isExpanded, GUIContent.none, true, EditorStyles.foldout);

            activeField.serializedObject.ApplyModifiedProperties();

            if (hasHelp)
            {
                labelRect.xMax -= k_LabelMarginRight;

                var helpIcon = MarsEditorGUI.Styles.HelpIcon;
                helpRect = new Rect(labelRect.xMax + k_MenuMargin, labelRect.y, Mathf.Min(labelRect.height,helpIcon.width),
                    Mathf.Min(labelRect.height,helpIcon.height));
                GUI.DrawTexture(helpRect, helpIcon);
            }
            
            // Dropdown menu icon
            GUI.DrawTexture(menuRect, menuIcon);

            // Handle events
            var e = Event.current;

            if (e.type == EventType.MouseDown)
            {
                if (hasHelp && helpRect.Contains(e.mousePosition))
                {
                    helpButton.Invoke();
                    e.Use();
                }
                else if (menuRect.Contains(e.mousePosition))
                {
                    ShowHeaderContextMenu(new Vector2(menuRect.x, menuRect.yMax), resetAction, removeAction, copyAction,
                        pasteAction, canPaste);
                    e.Use();
                }
                else if (backgroundRect.Contains(e.mousePosition))
                {
                    if (e.button == 0)
                        propertyGroup.isExpanded = !propertyGroup.isExpanded;
                    else
                        ShowHeaderContextMenu(e.mousePosition, resetAction, removeAction, copyAction, pasteAction,
                            canPaste);

                    e.Use();
                }
            }

            return propertyGroup.isExpanded && drawFoldout;
        }

        /// <summary>
        /// Draw a component stack style header with an expandable GUI method
        /// </summary>
        /// <param name="expanded">Expanded state of the foldout</param>
        /// <param name="showToggle">Is the toggle for expanding the panel visible.</param>
        /// <param name="title">The title to display on the foldout header</param>
        /// <param name="toggleStyle">GUI Style to be applied to the toggle button in the header</param>
        /// <param name="labelStyle">GUI Style to be applied to the label in the header</param>
        /// <param name="drawFoldoutUI">Function to draw UI when expanded. Function returns the rect of the panel.</param>
        /// <param name="onExpandedChanged">Action called when expanded state changes</param>
        /// <param name="helpButton">Action called when help button is pressed. If Null no help button is drawn.</param>
        /// <param name="settingsButtonFn">GenericMenu method to define the popup options menu. If no function
        /// is provided or function returns null no button is drawn.</param>
        /// <param name="menuFn">GenericMenu method to define the header's menu. If no menuFn is provided
        /// other menuFn returns null, a menu icon won't be drawn</param>
        /// <returns>Returns true if the foldout is expanded and enabled</returns>
        internal static bool DrawFoldoutUI(bool expanded, bool showToggle, string title, GUIStyle toggleStyle,
            GUIStyle labelStyle, Action drawFoldoutUI, Action<bool> onExpandedChanged, Action helpButton,
            Func<GenericMenu> settingsButtonFn, Func<GenericMenu> menuFn)
        {
            var hasMenu = menuFn != null && menuFn() != null;
            var menuRect = default(Rect);
            var hasSettings = settingsButtonFn != null && settingsButtonFn() != null;
            var settingsRect = default(Rect);
            var hasHelp = helpButton != null;
            var helpRect = default(Rect);

            var backgroundRect = GUILayoutUtility.GetRect(k_BackgroundRectX, k_BackgroundRectY);

            var labelRect = backgroundRect;
            labelRect.xMin += k_LabelMarginLeft;

            // Generic menu button is right most item in header
            if (hasMenu)
            {
                labelRect.xMax -= k_LabelMarginRight;

                var menuIcon = MarsEditorGUI.Styles.PaneOptionsIcon;

                menuRect = new Rect(labelRect.xMax + k_MenuMargin, labelRect.y, Mathf.Min(labelRect.height,menuIcon.width),
                    Mathf.Min(labelRect.height,menuIcon.height));
                GUI.DrawTexture(menuRect, menuIcon);
            }

            // Generic menu button for options.
            if (hasSettings)
            {
                labelRect.xMax -= k_LabelMarginRight;

                var popupIcon = MarsEditorGUI.Styles.SettingsIcon;
                settingsRect = new Rect(labelRect.xMax + k_MenuMargin, labelRect.y, Mathf.Min(labelRect.height,popupIcon.width),
                    Mathf.Min(labelRect.height,popupIcon.height));
                GUI.DrawTexture(settingsRect, popupIcon);
            }

            // Help button draws to the left of generic menu button
            if (hasHelp)
            {
                labelRect.xMax -= k_LabelMarginRight;

                var helpIcon = MarsEditorGUI.Styles.HelpIcon;
                helpRect = new Rect(labelRect.xMax + k_MenuMargin, labelRect.y, Mathf.Min(labelRect.height,helpIcon.width),
                    Mathf.Min(labelRect.height,helpIcon.height));
                GUI.DrawTexture(helpRect, helpIcon);
            }

            // Background rect should be full-width
            backgroundRect.xMin = 0f;
            backgroundRect.width += k_MenuMargin;

            // Background
            var backgroundTint = EditorGUIUtility.isProSkin
                ? k_BackgroundTintDark
                : k_BackgroundTintLight;

            EditorGUI.DrawRect(backgroundRect, new Color(backgroundTint, backgroundTint, backgroundTint,
                k_BackgroundAlpha));

            var toggleRect = backgroundRect;
            toggleRect.x += toggleStyle.margin.left;
            var toggleSize = toggleStyle.CalcSize(GUIContent.none);
            toggleRect.width = toggleSize.x;
            toggleRect.height = toggleSize.y;

            // Foldout dropdown area
            if (showToggle)
            {
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    expanded = GUI.Toggle(toggleRect, expanded, GUIContent.none, toggleStyle);
                    if (check.changed && onExpandedChanged != null)
                        onExpandedChanged(expanded);
                }
            }
            else
                EditorGUI.LabelField(toggleRect, GUIContent.none);

            // Foldout title
            EditorGUI.LabelField(labelRect, GetContent(title), labelStyle);

            // Handle events
            var e = Event.current;

            if (e.type == EventType.MouseDown)
            {
                if (hasHelp && helpRect.Contains(e.mousePosition))
                {
                    helpButton.Invoke();
                    e.Use();
                }
                else if (hasSettings && settingsRect.Contains(e.mousePosition))
                {
                    settingsButtonFn().DropDown(new Rect(e.mousePosition, Vector3.zero));
                    e.Use();
                }
                else if (hasMenu && menuRect.Contains(e.mousePosition))
                {
                    menuFn().DropDown(new Rect(e.mousePosition, Vector3.zero));
                    e.Use();
                }
                else if (labelRect.Contains(e.mousePosition))
                {
                    if (e.button == 0)
                    {
                        if (showToggle)
                        {
                            expanded = !expanded;

                            if (onExpandedChanged != null)
                                onExpandedChanged(expanded);
                        }
                    }
                    else if (hasMenu)
                    {
                        menuFn().DropDown(new Rect(e.mousePosition, Vector3.zero));
                    }

                    e.Use();
                }
            }

            DrawSplitter();

            if (expanded)
                drawFoldoutUI();

            return expanded;
        }

        static void ShowHeaderContextMenu(Vector2 position, Action resetAction, Action removeAction, Action copyAction,
            Action pasteAction, bool canPaste)
        {
            Assert.IsNotNull(resetAction);
            Assert.IsNotNull(removeAction);

            var menu = new GenericMenu();
            menu.AddItem(GetContent("Reset"), false, () => resetAction());
            menu.AddItem(GetContent("Remove"), false, () => removeAction());
            menu.AddSeparator(string.Empty);
            menu.AddItem(GetContent("Copy Settings"), false, () => copyAction());

            if (canPaste)
                menu.AddItem(GetContent("Paste Settings"), false, () => pasteAction());
            else
                menu.AddDisabledItem(GetContent("Paste Settings"));

            menu.DropDown(new Rect(position, Vector2.zero));
        }

        /// <summary>
        /// Draw a property field, with no checkbox
        /// </summary>
        /// <param name="property">The property being drawn</param>
        public static void PropertyField(SerializedPropertyData property)
        {
            var title = GetContent(property.DisplayName);
            PropertyField(property, title, false, true);
        }

        /// <summary>
        /// Draw a property field, with no checkbox
        /// </summary>
        /// <param name="property">The property being drawn</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        public static void PropertyField(SerializedPropertyData property, bool onlyHideToggle, bool showHideInInspector)
        {
            var title = GetContent(property.DisplayName);
            PropertyField(property, title, onlyHideToggle, showHideInInspector);
        }

        /// <summary>
        /// Draw a property field, with checkbox if appropriate
        /// </summary>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        public static void PropertyField(SerializedPropertyData toggleProperty, SerializedPropertyData property)
        {
            var title = GetContent(property.DisplayName);
            PropertyField(toggleProperty, property, title, false, true);
        }

        /// <summary>
        /// Draw a property field, with checkbox if appropriate
        /// </summary>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="overrideColor"> The color to use, or null for no override</param>
        public static void PropertyField(SerializedPropertyData toggleProperty, SerializedPropertyData property,
            Color? overrideColor)
        {
            PropertyField(toggleProperty, property, false, true, overrideColor);
        }

        /// <summary>
        /// Draw a property field, with checkbox if appropriate
        /// </summary>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        /// <param name="overrideColor"> The color to use, or null for no override</param>
        public static void PropertyField(SerializedPropertyData toggleProperty, SerializedPropertyData property,
            bool onlyHideToggle, bool showHideInInspector, Color? overrideColor)
        {
            var title = GetContent(property.DisplayName);
            if (overrideColor.HasValue)
            {
                var color = overrideColor.Value;
                var cacheColorPopupNormal = EditorStyles.popup.normal.textColor;
                var cacheColorPopupFocused = EditorStyles.popup.focused.textColor;
                var cacheColorNumberFieldNormal = EditorStyles.numberField.normal.textColor;
                var cacheColorNumberFieldFocused = EditorStyles.numberField.focused.textColor;

                EditorStyles.popup.normal.textColor = color;
                EditorStyles.popup.focused.textColor = color;
                EditorStyles.numberField.normal.textColor = color;
                EditorStyles.numberField.focused.textColor = color;

                PropertyField(toggleProperty, property, title, onlyHideToggle, showHideInInspector);

                EditorStyles.popup.normal.textColor = cacheColorPopupNormal;
                EditorStyles.popup.focused.textColor = cacheColorPopupFocused;
                EditorStyles.numberField.normal.textColor = cacheColorNumberFieldNormal;
                EditorStyles.numberField.focused.textColor = cacheColorNumberFieldFocused;
            }
            else
            {
                PropertyField(toggleProperty, property, title, onlyHideToggle, showHideInInspector);
            }
        }


        /// <summary>
        /// Draw component inspector's default inspector but with values in an override color
        /// </summary>
        /// <param name="componentInspector"> The inspector to draw </param>
        /// <param name="overrideColor"> The color to use, or null for no override </param>
        internal static void DrawDefaultInspectorWithColor(this ComponentInspector componentInspector, Color? overrideColor)
        {
            if (overrideColor.HasValue)
            {
                var color = overrideColor.Value;
                var cacheColorPopupNormal = EditorStyles.popup.normal.textColor;
                var cacheColorPopupFocused = EditorStyles.popup.focused.textColor;
                var cacheColorNumberFieldNormal = EditorStyles.numberField.normal.textColor;
                var cacheColorNumberFieldFocused = EditorStyles.numberField.focused.textColor;

                EditorStyles.popup.normal.textColor = color;
                EditorStyles.popup.focused.textColor = color;
                EditorStyles.numberField.normal.textColor = color;
                EditorStyles.numberField.focused.textColor = color;

                componentInspector.DrawDefaultInspector();

                EditorStyles.popup.normal.textColor = cacheColorPopupNormal;
                EditorStyles.popup.focused.textColor = cacheColorPopupFocused;
                EditorStyles.numberField.normal.textColor = cacheColorNumberFieldNormal;
                EditorStyles.numberField.focused.textColor = cacheColorNumberFieldFocused;
            }
            else
            {
                componentInspector.DrawDefaultInspector();
            }
        }

        /// <summary>
        /// Draw a property field, with no checkbox
        /// </summary>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        /// <param name="onlyHideToggle"></param>
        public static void PropertyField(SerializedPropertyData property, GUIContent title, bool onlyHideToggle)
        {
            PropertyField(null, property, title, onlyHideToggle, true);
        }

        /// <summary>
        /// Draw a property field, with no checkbox
        /// </summary>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        public static void PropertyField(SerializedPropertyData property, GUIContent title, bool onlyHideToggle, bool showHideInInspector)
        {
            PropertyField(null, property, title, onlyHideToggle, showHideInInspector);
        }

        /// <summary>
        /// Draw a property field, with checkbox if appropriate
        /// </summary>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        public static void PropertyField(SerializedPropertyData toggleProperty, SerializedPropertyData property, string title)
        {
            var content = new GUIContent(title);
            PropertyField(toggleProperty, property, content, false, true);
        }

        /// <summary>
        /// Draw a property field, with checkbox if appropriate
        /// </summary>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        public static void PropertyField(SerializedPropertyData toggleProperty, SerializedPropertyData property,
            string title, bool onlyHideToggle, bool showHideInInspector)
        {
            var content = new GUIContent(title);
            PropertyField(toggleProperty, property, content, onlyHideToggle, showHideInInspector);
        }

        /// <summary>
        /// Draw a property field, with checkbox if appropriate
        /// </summary>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        // Derived from PostProcessEffectBaseEditor from PostProcessing
        public static void PropertyField(SerializedPropertyData toggleProperty, SerializedPropertyData property,
            GUIContent title, bool onlyHideToggle, bool showHideInInspector)
        {
            // Skip hidden properties
            if (!showHideInInspector && property.GetAttribute<HideInInspector>() != null)
                return;

            var guiEnabled = GUI.enabled;

            // Check for DisplayNameAttribute first
            var displayNameAttr = property.GetAttribute<DisplayNameAttribute>();
            if (displayNameAttr != null)
                title.text = displayNameAttr.displayName;

            // Add tooltip if it's missing and an attribute is available
            if (string.IsNullOrEmpty(title.tooltip))
            {
                var tooltipAttr = property.GetAttribute<TooltipAttribute>();
                if (tooltipAttr != null)
                    title.tooltip = tooltipAttr.tooltip;
            }

            // Look for a compatible attribute decorator
            AttributeDecorator decorator = null;
            Attribute attribute = null;

            foreach (var attr in property.Attributes)
            {
                // Use the first decorator we found
                if (decorator == null)
                {
                    decorator = GetDecorator(attr.GetType());
                    attribute = attr;
                }

                // Draw unity built-in Decorators (Space, Header)
                if (attr is PropertyAttribute)
                {
                    var spaceAttribute = attr as SpaceAttribute;
                    if (spaceAttribute != null)
                    {
                        EditorGUILayout.GetControlRect(false, spaceAttribute.height);
                    }
                    else if (attr is HeaderAttribute)
                    {
                        var rect = EditorGUILayout.GetControlRect(false, 24f);
                        rect.y += 8f;
                        rect = EditorGUI.IndentedRect(rect);
                        EditorGUI.LabelField(rect, (attr as HeaderAttribute).header, MarsEditorGUI.Styles.LabelHeader);
                    }
                }
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                if (toggleProperty != null && toggleProperty.Value.propertyType != SerializedPropertyType.Boolean)
                {
                    toggleProperty = null;
                    onlyHideToggle = false;
                }

                // Override checkbox
                var overrideRect = DrawCheckboxFillerRect();
                DrawOverrideCheckbox(overrideRect, toggleProperty);

                // Property
                if (onlyHideToggle && toggleProperty != null)
                    GUI.enabled = toggleProperty.Value.boolValue;
                using (new EditorGUI.DisabledScope(toggleProperty != null && !toggleProperty.Value.boolValue))
                {
                    if (decorator != null)
                    {
                        if (decorator.OnGUI(property.Value, title, attribute))
                        {
                            GUI.enabled = guiEnabled;
                            return;
                        }
                    }

                    // Default unity field
                    if (property.Value.hasVisibleChildren
                        && property.Value.propertyType != SerializedPropertyType.Vector2
                        && property.Value.propertyType != SerializedPropertyType.Vector3)
                    {
                        GUILayout.Space(12f);
                        EditorGUILayout.PropertyField(property.Value, title, true);
                    }
                    else
                    {
                        EditorGUILayout.PropertyField(property.Value, title);
                    }
                }

                GUI.enabled = guiEnabled;
            }
        }

        /// <summary>
        /// Draw a property field within a specified region, with checkbox if appropriate
        /// </summary>
        /// <param name="position">Where these properties should be drawn</param>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        public static void PropertyFieldInRect(Rect position, SerializedPropertyData toggleProperty, SerializedPropertyData property)
        {
            var title = GetContent(property.DisplayName);
            PropertyFieldInRect(position, toggleProperty, property, title, false, true);
        }

        /// <summary>
        /// Draw a property field within a specified region, with checkbox if appropriate
        /// </summary>
        /// <param name="position">Where these properties should be drawn</param>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        public static void PropertyFieldInRect(Rect position, SerializedPropertyData toggleProperty, SerializedPropertyData property,
            bool onlyHideToggle, bool showHideInInspector)
        {
            var title = GetContent(property.DisplayName);
            PropertyFieldInRect(position, toggleProperty, property, title, onlyHideToggle, showHideInInspector);
        }

        /// <summary>
        /// Draw a property field within a specified region, with checkbox if appropriate
        /// </summary>
        /// <param name="position">Where these properties should be drawn</param>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        // Derived from PostProcessEffectBaseEditor from PostProcessing
        public static void PropertyFieldInRect(Rect position, SerializedPropertyData toggleProperty, SerializedPropertyData property,
            GUIContent title)
        {
            PropertyFieldInRect(position, toggleProperty, property, title, false, true);
        }

        /// <summary>
        /// Draw a property field within a specified region, with checkbox if appropriate
        /// </summary>
        /// <param name="position">Where these properties should be drawn</param>
        /// <param name="toggleProperty">Property representing the checkbox value</param>
        /// <param name="property">The property being drawn</param>
        /// <param name="title">The label to display for this property</param>
        /// <param name="onlyHideToggle"></param>
        /// <param name="showHideInInspector">Force this property to draw despite a HideInInspector attribute</param>
        // Derived from PostProcessEffectBaseEditor from PostProcessing
        public static void PropertyFieldInRect(Rect position, SerializedPropertyData toggleProperty, SerializedPropertyData property,
            GUIContent title, bool onlyHideToggle, bool showHideInInspector)
        {
            // Skip hidden properties
            if (!showHideInInspector && property.GetAttribute<HideInInspector>() != null)
                return;

            var guiEnabled = GUI.enabled;

            // Check for DisplayNameAttribute first
            var displayNameAttr = property.GetAttribute<DisplayNameAttribute>();
            if (displayNameAttr != null)
                title.text = displayNameAttr.displayName;

            // Add tooltip if it's missing and an attribute is available
            if (string.IsNullOrEmpty(title.tooltip))
            {
                var tooltipAttr = property.GetAttribute<TooltipAttribute>();
                if (tooltipAttr != null)
                    title.tooltip = tooltipAttr.tooltip;
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                if (toggleProperty != null && toggleProperty.Value.propertyType != SerializedPropertyType.Boolean)
                {
                    toggleProperty = null;
                    onlyHideToggle = false;
                }

                // Override checkbox
                var overrideRect = DrawCheckboxFillerRect(ref position);
                DrawOverrideCheckbox(overrideRect, toggleProperty);

                // Property
                if (onlyHideToggle && toggleProperty != null)
                    GUI.enabled = toggleProperty.Value.boolValue;
                using (new EditorGUI.DisabledScope(toggleProperty != null && !toggleProperty.Value.boolValue))
                {
                    // Default unity field
                    if (property.Value.hasVisibleChildren
                        && property.Value.propertyType != SerializedPropertyType.Vector2
                        && property.Value.propertyType != SerializedPropertyType.Vector3)
                    {
                        EditorGUI.PropertyField(position, property.Value, title, true);

                    }
                    else
                    {
                        EditorGUI.PropertyField(position, property.Value, title);
                    }
                }

                GUI.enabled = guiEnabled;
            }
        }

        /// <summary>
        /// Draw the values in a dictionary in two columns
        /// </summary>
        /// <param name="dictionary">The dictionary of values to draw</param>
        /// <param name="keyLabel">The text to display at the top of the keys column</param>
        /// <param name="valueLabel">The text to display at the top of the values column</param>
        /// <param name="keyWidth">Layout options to be applied to the keys column</param>
        /// <param name="valueWidth">Layout options to be applied to the values column</param>
        /// <param name="customValueToString">
        /// (optional) A function that turns the Value entries into strings in a non-standard way
        /// </param>
        internal static void DrawDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary,
            string keyLabel, string valueLabel,
            GUILayoutOption keyWidth = null, GUILayoutOption valueWidth = null,
            Func<TValue, string> customValueToString = null)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(keyLabel, EditorStyles.miniBoldLabel, keyWidth);
                EditorGUILayout.LabelField(valueLabel, EditorStyles.miniBoldLabel, valueWidth);
            }

            var wrapStyle = MarsEditorGUI.Styles.LeftAlignedWrapLabel;
            if (customValueToString == null)
            {
                foreach (var kvp in dictionary)
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField(kvp.Key.ToString(), wrapStyle, keyWidth);
                        EditorGUILayout.LabelField(kvp.Value.ToString(), wrapStyle, valueWidth);
                    }

                    DrawSplitter();
                }
            }
            else
            {
                foreach (var kvp in dictionary)
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField(kvp.Key.ToString(), wrapStyle, keyWidth);
                        EditorGUILayout.LabelField(customValueToString(kvp.Value), wrapStyle, valueWidth);
                    }

                    DrawSplitter();
                }
            }
        }

        /// <summary>
        /// Draw the entries in a dictionary with floating-point values in two columns
        /// </summary>
        /// <param name="dictionary">The dictionary of values to draw</param>
        /// <param name="keyLabel">The text to display at the top of the keys column</param>
        /// <param name="valueLabel">The text to display at the top of the values column</param>
        /// <param name="floatFormat">A format string specifying how to print floating-point values</param>
        /// <param name="keyWidth">Layout options to be applied to the keys column</param>
        /// <param name="valueWidth">Layout options to be applied to the values column</param>
        internal static void DrawDictionary<TKey>(Dictionary<TKey, float> dictionary,
            string keyLabel, string valueLabel,
            GUILayoutOption keyWidth, GUILayoutOption valueWidth,
            string floatFormat = "F3")
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(keyLabel, EditorStyles.miniBoldLabel, keyWidth);
                EditorGUILayout.LabelField(valueLabel, EditorStyles.miniBoldLabel, valueWidth);
            }

            var wrapStyle = MarsEditorGUI.Styles.LeftAlignedWrapLabel;
            foreach (var kvp in dictionary)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField(kvp.Key.ToString(), wrapStyle, keyWidth);
                    EditorGUILayout.LabelField(kvp.Value.ToString(floatFormat), wrapStyle, valueWidth);
                }
            }
        }

        /// <summary>
        /// Draw the values in a dictionary in two columns
        /// </summary>
        /// <param name="dictionary">The dictionary of values to draw</param>
        /// <param name="title">The text to display in the header for the dictionary</param>
        /// <param name="keyLabel">The text to display at the top of the keys column</param>
        /// <param name="valueLabel">The text to display at the top of the values column</param>
        /// <param name="keyWidth">Layout options to be applied to the keys column</param>
        /// <param name="valueWidth">Layout options to be applied to the values column</param>
        internal static void DrawDictionaryWithHeader<TKey, TValue>(Dictionary<TKey, TValue> dictionary,
            string title, string keyLabel, string valueLabel,
            GUILayoutOption keyWidth = null, GUILayoutOption valueWidth = null,
            Func<TValue, string> customValueToString = null)
        {
            EditorGUILayout.LabelField(title, EditorStyles.boldLabel);
            using (new EditorGUI.IndentLevelScope())
            {
                DrawDictionary(dictionary, keyLabel, valueLabel, keyWidth, valueWidth, customValueToString);
            }
        }

        /// <summary>
        /// Draw a label in a box next to the mouse cursor
        /// </summary>
        /// <param name="text">The text to display in the label</param>
        internal static void MouseLabel(string text)
        {
            var content = new GUIContent(text);
            GUI.Label(new Rect(Event.current.mousePosition + k_MouseLabelOffset, GUI.skin.box.CalcSize(content)), text, "box");
        }

        /// <summary>
        /// Draw a warning message box
        /// </summary>
        /// <param name="warning">The text to display in the warning</param>
        internal static void Warning(string warning)
        {
            EditorGUILayout.HelpBox(warning, MessageType.Warning);
        }

        /// <summary>
        /// Formats an angle value as a string with rounding and a degree symbol
        /// </summary>
        /// <param name="angle"> The angle value </param>
        /// <returns></returns>
        internal static string FormatAngleDegreesString(float angle)
        {
            return string.Format("{0:0}\u00B0", angle);
        }

        /// <summary>
        /// Get a GUIContent from input string, with text and tooltip separated by a | pipe character
        /// </summary>
        /// <param name="textAndTooltip">Combined text and tooltip string, separated by a | pipe character</param>
        /// <returns>The resulting GUIContent</returns>
        public static GUIContent GetContent(string textAndTooltip)
        {
            if (string.IsNullOrEmpty(textAndTooltip))
                return GUIContent.none;

            GUIContent content;

            if (s_GUIContentCache.TryGetValue(textAndTooltip, out content))
                return content;

            var s = textAndTooltip.Split('|');
            content = new GUIContent(s[0]);

            if (s.Length > 1 && !string.IsNullOrEmpty(s[1]))
                content.tooltip = s[1];

            s_GUIContentCache.Add(textAndTooltip, content);

            return content;
        }

        internal static AttributeDecorator GetDecorator(Type attributeType)
        {
            AttributeDecorator decorator;
            return !s_AttributeDecorators.TryGetValue(attributeType, out decorator)
                ? null
                : decorator;
        }

        internal static Color GetSceneBackgroundColor()
        {
            var bgColor = EditorMaterialUtils.PrefToColor(
                EditorPrefs.GetString(k_SceneBackgroundPrefsKey));
            bgColor.a = 1f;
            return bgColor;
        }

        /// <summary>
        /// Collect all the data associated to a <c>SerializedProperty</c> on a <c>SerializedObject</c> to use the
        /// <c>SerializedPropertyData</c> in the GUI
        /// </summary>
        /// <param name="serializedObject">serialized object in an inspector</param>
        /// <param name="propertyName">Find serialized property by name.</param>
        /// <returns>Collected data for drawing gui with <c>SerializedPropertyData</c></returns>
        public static SerializedPropertyData FindSerializedPropertyData(this SerializedObject serializedObject, string propertyName)
        {
            return FindSerializedPropertyData(serializedObject.FindProperty(propertyName));
        }

        /// <summary>
        /// Collect all the data associated to a <c>SerializedProperty</c> on a <c>SerializedObject</c> to use the
        /// <c>SerializedPropertyData</c> in the GUI
        /// </summary>
        /// <param name="property"><c>SerializedProperty</c> object that data needs to be collected from</param>
        /// <returns>Collected data for drawing gui with <c>SerializedPropertyData</c></returns>
        public static SerializedPropertyData FindSerializedPropertyData(SerializedProperty property)
        {
            Assert.IsNotNull(property);
            var attributes = EditorUtils.GetMemberAttributes(property);
            var fieldType = EditorUtils.GetFieldInfoFromProperty(property).FieldType;
            return new SerializedPropertyData(property, fieldType, attributes);
        }

        // Adapted from SceneViewOverlay.EatMouseInput
        internal static void EatMouseInput(Rect position, string controlIdHint)
        {
            var id = GUIUtility.GetControlID(controlIdHint.GetHashCode(), FocusType.Passive, position);
            switch (Event.current.GetTypeForControl(id))
            {
                case EventType.MouseDown:
                    if (position.Contains(Event.current.mousePosition))
                    {
                        GUIUtility.hotControl = id;
                        Event.current.Use();
                    }
                    break;
                case EventType.MouseUp:
                    if (GUIUtility.hotControl == id)
                    {
                        GUIUtility.hotControl = 0;
                        Event.current.Use();
                    }
                    break;
                case EventType.MouseDrag:
                    if (GUIUtility.hotControl == id)
                        Event.current.Use();
                    break;
                case EventType.ScrollWheel:
                    if (position.Contains(Event.current.mousePosition))
                        Event.current.Use();
                    break;
            }
        }

        internal static Vector2 Drag2D(Vector2 scrollPosition, Rect position)
        {
            if (s_Drag2DMethodInfo == null)
            {
                var unityEditor = Assembly.GetAssembly(typeof(PreviewRenderUtility));
                s_PreviewGUI = unityEditor.CreateInstance(k_PreviewGUIClassName);
                if (s_PreviewGUI == null)
                    return scrollPosition;

                var t = s_PreviewGUI.GetType();
                s_Drag2DMethodInfo = t.GetMethod(k_Drag2DMethodName,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy |
                    BindingFlags.Instance | BindingFlags.Static);

                if (s_Drag2DMethodInfo == null)
                    return scrollPosition;
            }

            return (Vector2)s_Drag2DMethodInfo.Invoke(s_PreviewGUI, new object[] { scrollPosition, position });
        }

        /// <summary>
        /// Recreates the toggle button and functionality with gui button.
        /// </summary>
        /// <param name="value">Current value of toggle parameter.</param>
        /// <param name="guiContent">GUI content to display on the button.</param>
        /// <param name="onImage">Texture to display on the button when it is on.</param>
        /// <param name="offImage">Texture to display on the button when it is off.</param>
        /// <param name="style">The style to use. If left out, the button style from the current GUISkin is used.</param>
        /// <param name="options">An optional list of layout options that specify extra layout properties. Any values passed in here will override settings defined by the style.&lt;br&gt;
        /// See Also: GUILayout.Width, GUILayout.Height, GUILayout.MinWidth, GUILayout.MaxWidth, GUILayout.MinHeight,
        /// GUILayout.MaxHeight, GUILayout.ExpandWidth, GUILayout.ExpandHeight.</param>
        /// <returns>
        ///   <para>The selected state of the toggle.</para>
        /// </returns>
        /// TODO issues with the layout of images and text with EditorGUILayout.Toggle required this hack to keep consistent alignment with other GUI items.
        internal static bool ImageToggle(bool value, GUIContent guiContent, Texture onImage, Texture offImage,
            GUIStyle style, params GUILayoutOption[] options)
        {
            var contentIcon = value ? onImage : offImage;
            // TODO Toggle does not seem to be displaying tooltips
            // value = EditorGUILayout.Toggle(guiContent, value, style, options);
            if (GUILayout.Button(guiContent, style, options))
                value = !value;

            var lastRect = GUILayoutUtility.GetLastRect();
            var offset = MarsEditorGUI.Styles.imagePaddingRect;
            var imageRect = new Rect(lastRect.xMin + offset.left, lastRect.yMin + offset.bottom,
                lastRect.width - offset.left - offset.right, lastRect.height - offset.bottom - offset.top);

            GUI.DrawTexture(imageRect, contentIcon, ScaleMode.ScaleToFit, true, 1);

            return value;
        }

        /// <summary>
        /// Set the Unity layer's visibility
        /// </summary>
        /// <param name="layer">Layer to modify</param>
        /// <param name="newVisibleState">Target view state of layer</param>
        internal static void SetLayerVisibleState(int layer, bool newVisibleState)
        {
            var layerMask = 1 << layer;
            if (newVisibleState)
                Tools.visibleLayers |= layerMask;
            else
                Tools.visibleLayers &= ~layerMask;
        }

        /// <summary>
        /// Set the Unity layer's visibility
        /// </summary>
        /// <param name="layer">Layer to modify</param>
        /// <param name="newLockState">Target lock state of layer</param>
        internal static void SetLayerLockState(int layer, bool newLockState)
        {
            var layerMask = 1 << layer;
            if (newLockState)
                Tools.lockedLayers |= layerMask;
            else
                Tools.lockedLayers &= ~layerMask;
        }

        internal static T ObjectFieldWithControlIdCheck<T>(
            T obj, ref int controlId, params GUILayoutOption[] options) where T : UnityObject
        {
            var objectFieldContent = EditorGUIUtility.ObjectContent(obj, typeof(T));
            var objectFieldStyle = EditorStyles.objectField;

            using (new GUILayout.HorizontalScope())
            {
                if (GUILayout.Button(objectFieldContent, objectFieldStyle, options) && obj)
                    EditorGUIUtility.PingObject(obj);

                var selectorRect = GUILayoutUtility.GetLastRect();
                const int buttonSize = 16;
                selectorRect.x = selectorRect.x + selectorRect.width;
                selectorRect.width = buttonSize;
                selectorRect.height = buttonSize;

                var objFieldButtonStyle = (GUIStyle) s_ObjectFieldButtonStyleProperty.GetValue(null);

                if (GUI.Button(selectorRect, string.Empty, objFieldButtonStyle))
                {
                    controlId = GUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<T>(null, false, string.Empty, controlId);
                }
            }

            if (Event.current.commandName == "ObjectSelectorClosed" && Event.current.type == EventType.Layout && EditorGUIUtility.GetObjectPickerControlID() == controlId)
            {
                var pickedObject = EditorGUIUtility.GetObjectPickerObject();
                    obj = pickedObject as T;
            }

            T draggedObject = null;
            if (DragAndDrop.objectReferences.Length > 0)
                draggedObject = DragAndDrop.objectReferences[0] as T;

            if (draggedObject == null)
                return obj;

            var draggedObjectIsCorrectType = draggedObject.GetType() == typeof(T);

            if (Event.current.type == EventType.DragUpdated)
            {
                DragAndDrop.visualMode = draggedObjectIsCorrectType
                    ? DragAndDropVisualMode.Copy
                    : DragAndDropVisualMode.Rejected;

                Event.current.Use();
            }
            else if (Event.current.type == EventType.DragPerform)
            {
                if (draggedObjectIsCorrectType)
                    obj = draggedObject;

                Event.current.Use();
            }

            return obj;
        }
    }
}

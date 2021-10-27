using System;
using System.Collections.Generic;
using Unity.MARS.Simulation;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    [PanelOrder(PanelOrders.MARSObjectCreationOrder)]
    class MarsObjectCreationPanel : PanelView
    {
        const string k_ObjectCreationPanelLabel = "Create";
        const int k_NumColumns = 2;
        const float k_InverseNumColumns = 1 / (float) k_NumColumns;
        const float k_RowPadding = 3.5f;

        static readonly Vector2 k_PrefSize = new Vector2(240f, 240f);
        static readonly Vector2 k_MinSize = new Vector2(128f, 128f);
        static readonly Vector2 k_MaxSize = new Vector2(MarsEditorGUI.MaxWindowSize, MarsEditorGUI.MaxWindowSize);
        static readonly string k_TypeName = typeof(MarsObjectCreationPanel).FullName;

        class Styles
        {
            const int k_PaddingX = 10;
            const int k_PaddingY = 8;

            public readonly GUIStyle createObjectButtonStyle;
            public readonly GUIStyle createObjectButtonStyleFixedIcon;
            public readonly GUIStyle indentAlignment;

            float m_ImageSize;
            bool m_FixedIconSizeCalculated;

            public int paddingX => k_PaddingX;

            public Styles()
            {
                createObjectButtonStyle = new GUIStyle(MarsEditorGUI.Styles.Button)
                {
                    imagePosition = ImagePosition.ImageLeft,
                    padding = new RectOffset(k_PaddingX, k_PaddingX, k_PaddingY, k_PaddingY),
                    clipping = TextClipping.Clip,
                    alignment = TextAnchor.MiddleLeft,
                    wordWrap = false,
                };

                createObjectButtonStyleFixedIcon = new GUIStyle(createObjectButtonStyle);

                indentAlignment = new GUIStyle(MarsEditorGUI.Styles.NoMarginScopeAlignment);
                indentAlignment.margin.left += k_PaddingX;
            }

            void CalculateFixedIconStyleSize()
            {
                if (m_FixedIconSizeCalculated || Event.current == null || Event.current.type != EventType.Layout)
                    return;

                createObjectButtonStyleFixedIcon.imagePosition = ImagePosition.ImageLeft;
                createObjectButtonStyleFixedIcon.padding = new RectOffset(k_PaddingX, k_PaddingX, k_PaddingY, k_PaddingY);

                var buttonSize = createObjectButtonStyleFixedIcon.CalcSize(new GUIContent("Test", Texture2D.blackTexture));
                m_ImageSize = buttonSize.y - k_PaddingY * 2f;

                createObjectButtonStyleFixedIcon.imagePosition = ImagePosition.TextOnly;
                createObjectButtonStyleFixedIcon.padding.left += (int) m_ImageSize;

                m_FixedIconSizeCalculated = true;
            }

            public bool DrawFixedIconButton(GUIContent guiContent, params GUILayoutOption[] options)
            {
                CalculateFixedIconStyleSize();

                var buttonStyle = guiContent.image != null ? createObjectButtonStyleFixedIcon : createObjectButtonStyle;

                var value = GUILayout.Button(guiContent, buttonStyle, options);

                if (buttonStyle.imagePosition == ImagePosition.TextOnly)
                {
                    var rect = GUILayoutUtility.GetLastRect();
                    const float rectPaddingX = k_PaddingX * 0.75f;
                    rect.x += rectPaddingX;
                    rect.y += k_PaddingY;
                    rect.width = m_ImageSize;
                    rect.height = m_ImageSize;

                    GUI.DrawTexture(rect, guiContent.image, ScaleMode.ScaleToFit, true);
                }

                return value;
            }
        }

        static Styles s_Styles;

        static Styles styles
        {
            get
            {
                if (s_Styles == null)
                    s_Styles = new Styles();

                return s_Styles;
            }
        }

        public override string PanelLabel => k_ObjectCreationPanelLabel;

        public override bool DrawAsWindow { get; set; }

        public override bool AutoRepaintOnSceneChange => false;

        public override bool UsePrefSize => false;

        public override Vector2 PreferredSize => k_PrefSize;

        public override Vector2 MinSize => k_MinSize;

        public override Vector2 MaxSize => k_MaxSize;

        public override bool PanelPopoutCanScroll => true;

        /// <inheritdoc />
        public override bool PanelExpanded
        {
            get => EditorPrefsUtils.GetBool(k_TypeName, true);
            set => EditorPrefsUtils.SetBool(k_TypeName, value);
        }

        public override void OnGUI()
        {
            if (MarsObjectCreationSettings.instance == null)
                return;

            using (new EditorGUILayout.VerticalScope(styles.indentAlignment))
            {
                foreach (var section in MarsObjectCreationSettings.instance.ObjectCreationButtonSections)
                    DrawSection(section, ScrollingVertical);
            }

            base.OnGUI();
        }

        internal static void DrawSection(MarsObjectCreationSettings.ObjectCreationButtonSection section, bool hasVerticalScrollbar, Action<GameObject> buttonCallback = null)
        {
            var width =  EditorGUIUtility.currentViewWidth;
            if (hasVerticalScrollbar)
                width -= GUI.skin.verticalScrollbar.fixedWidth + styles.paddingX;

            var buttonWidth = width * k_InverseNumColumns - styles.createObjectButtonStyle.margin.horizontal * k_InverseNumColumns - k_RowPadding;

            section.Expanded = EditorGUILayout.Foldout(section.Expanded, new GUIContent(section.Name), true);
            if (!section.Expanded)
                return;

            var buttons = section.Buttons;
            var needHorizontalEnd = true;
            for (var i = 0; i < buttons.Length; i++)
            {
                if (i % k_NumColumns == 0)
                    GUILayout.BeginHorizontal(GUIStyle.none);

                var createButton = buttons[i];

                if (createButton != null)
                {
                    var creationButtonValid = true;
                    if (createButton.CreateInContextSelection == ObjectCreationData.CreateInContext.SyntheticSimulation)
                    {
                        creationButtonValid = SimulationSceneModule.UsingSimulation &&
                                              SimulationSettings.instance.EnvironmentMode == EnvironmentMode.Synthetic;
                    }

                    using (new EditorGUI.DisabledScope(!creationButtonValid))
                    {
                        GUI.SetNextControlName(createButton.name);
                        if (styles.DrawFixedIconButton(createButton.ObjectGUIContent, GUILayout.Width(buttonWidth)))
                        {
                            if (createButton.CreateGameObject(out var go, null))
                            {
                                EditorEvents.CreationMenuItemUsed.Send(new MarsMenuEventArgs
                                    {label = $"{section.Name}/{createButton.ObjectName}"});

                                buttonCallback?.Invoke(go);
                            }
                        }
                    }
                }

                if (i % k_NumColumns == 1)
                {
                    GUILayout.EndHorizontal();
                    needHorizontalEnd = false;
                }
                else
                {
                    needHorizontalEnd = true;
                }
            }

            // Leave Space for an empty button and end horizontal row
            if (needHorizontalEnd)
            {
                GUILayout.Space(buttonWidth);
                GUILayout.EndHorizontal();
            }
        }

        protected override MenuItemData[] MenuItems()
        {
            return new[]
            {
                new MenuItemData
                (
                    new GUIContent
                    {
                        text = "Set up object prefabs"
                    }, false,
                    () => { Selection.activeObject = MarsObjectCreationSettings.instance; }
                )
            };
        }

        public override void Repaint() { }

        public override void OnSelectionChanged() { }
    }
}

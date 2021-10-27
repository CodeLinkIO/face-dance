// In 2019.3 & 2019.4, scene placement options are placed in the editor toolbar.
// This API is new in 19.3, so in previous versions we put these tools in a MARS panel.
// The ability to place items in the tool bar is removed in 2020.1 but added back in for 2021.1
#if !(UNITY_2019_3 || UNITY_2019_4)
using System;
using Unity.MARS.Authoring;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Authoring;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Scene placement tools panel
    /// </summary>
    [PanelOrder(PanelOrders.ScenePlacementOrder)]
    public class ScenePlacementPanel : PanelView
    {
        static class Styles
        {
            internal static readonly float ButtonsWidth;
            internal static readonly float ButtonsWidthHalf;
            internal static readonly float ButtonHeight;
            static Styles()
            {
                var appCommandStyle = MarsEditorGUI.InternalEditorStyles.AppCommand;
                ButtonsWidth = appCommandStyle.fixedWidth * 3;
                ButtonsWidthHalf = ButtonsWidth / 2f;
                ButtonHeight = appCommandStyle.fixedHeight;
            }
        }

        const string k_PlacementOptionsLabel = "Placement Options";
        const string k_NoInteractionTargetsHelpMessage = "No Interaction Targets present.";
        const string k_OverrideHelpMessage = "Some options overridden";

        static readonly Vector2 k_PrefSize = new Vector2(240f, 26f);
        static readonly Vector2 k_MinSize = new Vector2(240f, 26f);
        static readonly Vector2 k_MaxSize = new Vector2(240f, 26f);

        static readonly string k_TypeName = typeof(ScenePlacementPanel).FullName;

        bool m_InteractionTargetsExist;
        bool m_HasOverride;

        /// <inheritdoc />
        public override string PanelLabel => k_PlacementOptionsLabel;

        /// <inheritdoc />
        public override bool PanelExpanded
        {
            get { return EditorPrefsUtils.GetBool(k_TypeName, true); }
            set { EditorPrefsUtils.SetBool(k_TypeName, value); }
        }

        /// <inheritdoc />
        public override bool DrawAsWindow { get; set; }

        /// <inheritdoc />
        public override bool AutoRepaintOnSceneChange => false;

        /// <inheritdoc />
        public override bool UsePrefSize => true;

        /// <inheritdoc />
        public override Vector2 PreferredSize => k_PrefSize;

        /// <inheritdoc />
        public override Vector2 MinSize => k_MinSize;

        /// <inheritdoc />
        public override Vector2 MaxSize => k_MaxSize;

        /// <inheritdoc />
        public override void OnEnable()
        {
            base.OnEnable();
            hideFlags = HideFlags.DontSave;
        }

        /// <inheritdoc />
        public override void OnGUI()
        {
            if (Event.current.type == EventType.Layout)
            {
                m_InteractionTargetsExist = InteractionTarget.AllTargets.Count > 0;

                m_HasOverride = false;
                var scenePlacementModule = ModuleLoaderCore.instance.GetModule<ScenePlacementModule>();
                if (scenePlacementModule != null)
                {
                    var overrides = scenePlacementModule.PlacementOverrides;
                    m_HasOverride = overrides.useSnapToPivotOverride || overrides.useOrientToSurfaceOverride
                        ||  overrides.useAxisOverride;
                }
            }

            using (new EditorGUILayout.VerticalScope(MarsEditorGUI.Styles.AreaAlignment))
            {
                var rect = GUILayoutUtility.GetRect(Styles.ButtonsWidth, Styles.ButtonsWidth, Styles.ButtonHeight,
                    Styles.ButtonHeight);
                rect.xMin = (rect.width / 2) - Styles.ButtonsWidthHalf;
                ScenePlacementGUI.DrawPlacementToolSettings(rect, false);

                DrawHelpBoxArea(m_HasOverride, m_InteractionTargetsExist);
            }

            base.OnGUI();
        }

        /// <inheritdoc />
        public override void Repaint()
        {
            if (EditorWindow != null)
                EditorWindow.Repaint();

            if (PanelWindow != null)
                PanelWindow.Repaint();
        }

        /// <inheritdoc />
        public override void OnSelectionChanged() { }

        static void DrawHelpBoxArea(bool hasOverride, bool hasInteractionTarget)
        {
            using (new EditorGUILayout.VerticalScope(MarsEditorGUI.Styles.NoVerticalMarginScopeAlignment))
            {
                if (hasOverride)
                    EditorGUILayout.HelpBox(k_OverrideHelpMessage, MessageType.Info);

                if (!hasInteractionTarget)
                    EditorGUILayout.HelpBox(k_NoInteractionTargetsHelpMessage, MessageType.Info);
            }
        }
    }
}
#endif

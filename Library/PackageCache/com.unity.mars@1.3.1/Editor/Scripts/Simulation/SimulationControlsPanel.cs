using System;
using Unity.XRTools.Utils;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    [Serializable]
    [PanelOrder(PanelOrders.SimulationControlsOrder)]
    class SimulationControlsPanel : PanelView
    {
        const string k_SimulationViewPaneLabel = "Simulation Controls";
        static readonly Vector2 k_PrefSize = new Vector2(275f, 85f);
        static readonly Vector2 k_MinSize = new Vector2(275f, 85f);
        static readonly Vector2 k_MaxSize = new Vector2(MarsEditorGUI.MaxWindowSize, MarsEditorGUI.MaxWindowSize);
        static readonly string k_TypeName = typeof(SimulationControlsPanel).FullName;

        /// <inheritdoc />
        public override string PanelLabel => k_SimulationViewPaneLabel;

        /// <inheritdoc />
        public override bool PanelExpanded
        {
            get => EditorPrefsUtils.GetBool(k_TypeName, true);
            set => EditorPrefsUtils.SetBool(k_TypeName, value);
        }

        /// <inheritdoc />
        public override bool DrawAsWindow { get; set; }

        /// <inheritdoc />
        public override bool AutoRepaintOnSceneChange => true;

        /// <inheritdoc />
        public override bool UsePrefSize => false;

        /// <inheritdoc />
        public override Vector2 PreferredSize => k_PrefSize;

        /// <inheritdoc />
        public override Vector2 MinSize => k_MinSize;

        /// <inheritdoc />
        public override Vector2 MaxSize => k_MaxSize;

        public override void OnEnable()
        {
            base.OnEnable();
            hideFlags = HideFlags.DontSave;
        }

        /// <inheritdoc />
        public override void OnGUI()
        {
            SimulationControlsGUI.DrawControlsWindow();

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

        protected override MenuItemData[] MenuItems()
        {
            return new[]
            {
                new MenuItemData ( new GUIContent("Open Simulation View"), false,
                    SimulationView.InitWindowInSimulationView)
            };
        }
    }
}

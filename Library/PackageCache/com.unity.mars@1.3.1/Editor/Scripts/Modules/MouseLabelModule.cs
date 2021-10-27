using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Manager for mouse labels in Scene GUI
    /// </summary>
    class MouseLabelModule : IModule
    {
        const float k_MouseLabelMargin = 5f;
        static readonly Vector2 k_MouseLabelOffset = new Vector2(-8, 30);
        static readonly GUIStyle k_MouseLabelStyle = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).GetStyle("tooltip");

        static Dictionary<Component, MouseLabel> s_MouseLabels = new Dictionary<Component, MouseLabel>();

        struct MouseLabel
        {
            public string message;
            public Vector2 boxSize;
            public float yOffset;
        }

        void IModule.LoadModule()
        {
            s_MouseLabels.Clear();
            SceneView.duringSceneGui += OnSceneGUI;
        }

        void IModule.UnloadModule()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        static void OnSceneGUI(SceneView sceneView)
        {
            if (s_MouseLabels.Count == 0)
                return;

            UnityObjectUtils.RemoveDestroyedKeys(s_MouseLabels);

            Handles.BeginGUI();
            var origin = Event.current.mousePosition + k_MouseLabelOffset;
            foreach (var mouseLabel in s_MouseLabels.Values)
            {
                GUI.Label(
                    new Rect(origin + mouseLabel.yOffset * Vector2.up, mouseLabel.boxSize),
                    mouseLabel.message,
                    k_MouseLabelStyle);
            }

            Handles.EndGUI();
        }

        public static void AddMouseLabel(Component comp, string message)
        {
            var mouseLabel = new MouseLabel
            {
                message = message,
                boxSize = k_MouseLabelStyle.CalcScreenSize(k_MouseLabelStyle.CalcSize(new GUIContent(message))),
            };

            s_MouseLabels[comp] = mouseLabel;
            UpdateMouseLabels();
        }

        public static void RemoveMouseLabel(Component comp)
        {
            s_MouseLabels.Remove(comp);
            UpdateMouseLabels();
        }

        static void UpdateMouseLabels()
        {
            var totalYOffset = 0f;
            var keys = new List<Component>(s_MouseLabels.Keys);
            foreach (var key in keys)
            {
                var label = s_MouseLabels[key];
                label.yOffset = totalYOffset;
                s_MouseLabels[key] = label;
                totalYOffset += s_MouseLabels[key].boxSize.y + k_MouseLabelMargin;
            }
        }
    }
}

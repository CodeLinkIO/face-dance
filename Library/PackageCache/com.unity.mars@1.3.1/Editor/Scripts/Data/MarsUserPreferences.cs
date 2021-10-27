using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    static class MarsUserPreferences
    {
        const string k_ResetColorsEvent = "Reset Colors";

        static readonly Color k_DefaultHighlightedSimulatedObjectColor = Color.yellow;
        static readonly Color k_DefaultConditionFailTextColor = Color.red;

        const string k_PrefPrefix = "MARS";
        const string k_HighlightedSimulatedObjectColorPref = k_PrefPrefix + ".HighightedSimulatedObjectsColor";
        const string k_DefaultConditionFailTextColorPref = k_PrefPrefix + ".DefaultConditionFailTextColor";
        const string k_TintImageMarkersPref = k_PrefPrefix + ".TintImageMarkers";
        const string k_RestrictCameraToEnvironmentBoundsPref = k_PrefPrefix + ".RestrictCameraToEnvironmentBounds";
        const string k_ElectiveExtensionsReportsErrorsPref = k_PrefPrefix + ".ElectiveExtensionsReportsErrors";

        internal const string HighlightedSimulatedObjectColorTooltip = "Text color used to highlight the simulated versions of selected content in the MARS Hierarchy";
        internal const string ConditionFailTextColorTooltip = "Text color used by the MARS Compare Tool for data that fails to pass a Condition";

        static Color s_HighlightedSimulatedObjectColor;
        static Color s_ConditionFailTextColor;
        static bool s_RestrictCameraToEnvironmentBounds;
        static bool s_TintImageMarkers;
        static bool s_ElectiveExtensionsReportsErrors;

        public static Color HighlightedSimulatedObjectColor
        {
            get { return s_HighlightedSimulatedObjectColor; }
            set
            {
                s_HighlightedSimulatedObjectColor = value;
                var colorString = EditorMaterialUtils.ColorToColorPref(k_HighlightedSimulatedObjectColorPref, value);
                EditorPrefs.SetString(k_HighlightedSimulatedObjectColorPref, colorString);
            }
        }

        public static Color ConditionFailTextColor
        {
            get { return s_ConditionFailTextColor; }
            set
            {
                s_ConditionFailTextColor = value;
                var colorString = EditorMaterialUtils.ColorToColorPref(k_DefaultConditionFailTextColorPref, value);
                EditorPrefs.SetString(k_DefaultConditionFailTextColorPref, colorString);
            }
        }

        public static bool TintImageMarkers
        {
            get { return s_TintImageMarkers; }
            set
            {
                s_TintImageMarkers = value;
                EditorPrefs.SetBool(k_TintImageMarkersPref, value);
            }
        }

        public static bool RestrictCameraToEnvironmentBounds
        {
            get { return s_RestrictCameraToEnvironmentBounds; }
            set
            {
                s_RestrictCameraToEnvironmentBounds = value;
                EditorPrefs.SetBool(k_RestrictCameraToEnvironmentBoundsPref, value);
            }
        }

        public static bool ElectiveExtensionsReportsErrors
        {
            get { return s_ElectiveExtensionsReportsErrors; }
            set
            {
                s_ElectiveExtensionsReportsErrors = value;
                EditorPrefs.SetBool(k_ElectiveExtensionsReportsErrorsPref, value);
            }
        }

        static MarsUserPreferences()
        {
            var defaultColor = EditorMaterialUtils.ColorToColorPref(k_HighlightedSimulatedObjectColorPref, k_DefaultHighlightedSimulatedObjectColor);
            var colorString = EditorPrefs.GetString(k_HighlightedSimulatedObjectColorPref, defaultColor);
            s_HighlightedSimulatedObjectColor = EditorMaterialUtils.PrefToColor(colorString);


            defaultColor = EditorMaterialUtils.ColorToColorPref(k_DefaultConditionFailTextColorPref, k_DefaultConditionFailTextColor);
            colorString = EditorPrefs.GetString(k_DefaultConditionFailTextColorPref, defaultColor);
            s_ConditionFailTextColor = EditorMaterialUtils.PrefToColor(colorString);

            s_TintImageMarkers = EditorPrefs.GetBool(k_TintImageMarkersPref);
            s_RestrictCameraToEnvironmentBounds = EditorPrefs.GetBool(k_RestrictCameraToEnvironmentBoundsPref, true);
            s_ElectiveExtensionsReportsErrors = EditorPrefs.GetBool(k_ElectiveExtensionsReportsErrorsPref);
        }

        public static void ResetColors()
        {
            s_HighlightedSimulatedObjectColor = k_DefaultHighlightedSimulatedObjectColor;
            s_ConditionFailTextColor = k_DefaultConditionFailTextColor;

            EditorEvents.UiComponentUsed.Send(new UiComponentArgs { label = k_ResetColorsEvent, active = true });

            SceneView.RepaintAll();
        }
    }
}

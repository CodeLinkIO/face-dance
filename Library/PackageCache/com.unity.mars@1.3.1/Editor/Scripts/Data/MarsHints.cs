using UnityEditor;

namespace Unity.MARS
{
    internal static class MarsHints
    {
        const string k_ResetHintsEvent = "Reset Hints";

        const string k_ShowMarsHintsPrefKey = "ShowMarsHintsPrefKey";
        const string k_WorldScaleHintPrefKey = "ShowWorldScaleHintPrefKey";
        const string k_ShowEntitySetupHintsPrefKey = "ShowEntitySetupHintsPrefKey";
        const string k_ShowDataVisualizersHintsPrefKey = "ShowDataVisualizersHintsPrefKey";
        const string k_ShowMemoryOptionsHintPrefKey = "ShowMemoryOptionsHintPrefKey";
        const string k_ShowQuerySearchHintPrefKey = "ShowQuerySearchHintPrefKey";
        const string k_ShowDisabledSimulationComponentsHintPrefKey = "ShowDisabledSimulationComponentsHintPrefKey";
        const string k_ShowSimulatedGeoLocationHintPrefKey = "ShowSimulatedGeoLocationHintPrefKey";
        const string k_ShowDeviceViewControlsHintPrefKey = "ShowDeviceViewControlsHintPrefKey";

        static bool s_ShowMarsHints;
        static bool s_ShowWorldScaleHint;
        static bool s_ShowEntitySetupHints;
        static bool s_ShowDataVisualizersHints;
        static bool s_ShowMemoryOptionsHint;
        static bool s_ShowQuerySearchHint;
        static bool s_ShowDisabledSimulationComponentsHint;
        static bool s_ShowSimulatedGeoLocationHint;
        static bool s_ShowDeviceViewControlsHint;

        public static bool ShowWorldScaleHint
        {
            get => s_ShowMarsHints && s_ShowWorldScaleHint;
            set
            {
                EditorPrefs.SetBool(k_WorldScaleHintPrefKey, value);
                s_ShowWorldScaleHint = value;
            }
        }

        public static bool ShowEntitySetupHints
        {
            get => s_ShowMarsHints && s_ShowEntitySetupHints;
            set
            {
                EditorPrefs.SetBool(k_ShowEntitySetupHintsPrefKey, value);
                s_ShowEntitySetupHints = value;
            }
        }

        public static bool ShowDataVisualizersHints
        {
            get => s_ShowMarsHints && s_ShowDataVisualizersHints;
            set
            {
                EditorPrefs.SetBool(k_ShowDataVisualizersHintsPrefKey, value);
                s_ShowDataVisualizersHints = value;
            }
        }

        public static bool ShowMemoryOptionsHint
        {
            get => s_ShowMarsHints && s_ShowMemoryOptionsHint;
            set
            {
                EditorPrefs.SetBool(k_ShowMemoryOptionsHintPrefKey, value);
                s_ShowMemoryOptionsHint = value;
            }
        }

        public static bool ShowQuerySearchHint
        {
            get => s_ShowMarsHints && s_ShowQuerySearchHint;
            set
            {
                EditorPrefs.SetBool(k_ShowQuerySearchHintPrefKey, value);
                s_ShowQuerySearchHint = value;
            }
        }

        public static bool ShowDisabledSimulationComponentsHint
        {
            get => s_ShowMarsHints && s_ShowDisabledSimulationComponentsHint;
            set
            {
                EditorPrefs.SetBool(k_ShowDisabledSimulationComponentsHintPrefKey, value);
                s_ShowDisabledSimulationComponentsHint = value;
            }
        }

        public static bool ShowSimulatedGeoLocationHint
        {
            get => s_ShowMarsHints && s_ShowSimulatedGeoLocationHint;
            set
            {
                EditorPrefs.SetBool(k_ShowSimulatedGeoLocationHintPrefKey, value);
                s_ShowSimulatedGeoLocationHint = value;
            }
        }

        public static bool ShowDeviceViewControlsHint
        {
            get => s_ShowMarsHints && s_ShowDeviceViewControlsHint;
            set
            {
                EditorPrefs.SetBool(k_ShowDeviceViewControlsHintPrefKey, value);
                s_ShowDeviceViewControlsHint = value;
            }
        }

        static MarsHints()
        {
            s_ShowMarsHints = EditorPrefs.GetBool(k_ShowMarsHintsPrefKey, true);
            s_ShowWorldScaleHint = EditorPrefs.GetBool(k_WorldScaleHintPrefKey, true);
            s_ShowEntitySetupHints = EditorPrefs.GetBool(k_ShowEntitySetupHintsPrefKey, true);
            s_ShowDataVisualizersHints = EditorPrefs.GetBool(k_ShowDataVisualizersHintsPrefKey, true);
            s_ShowMemoryOptionsHint = EditorPrefs.GetBool(k_ShowMemoryOptionsHintPrefKey, true);
            s_ShowQuerySearchHint = EditorPrefs.GetBool(k_ShowQuerySearchHintPrefKey, true);
            s_ShowDisabledSimulationComponentsHint =
                EditorPrefs.GetBool(k_ShowDisabledSimulationComponentsHintPrefKey, true);
            s_ShowSimulatedGeoLocationHint = EditorPrefs.GetBool(k_ShowSimulatedGeoLocationHintPrefKey, true);
            s_ShowDeviceViewControlsHint = EditorPrefs.GetBool(k_ShowDeviceViewControlsHintPrefKey, true);
        }

        public static void ResetHints()
        {
            s_ShowMarsHints = true;
            ShowWorldScaleHint = true;
            ShowEntitySetupHints = true;
            ShowDataVisualizersHints = true;
            ShowMemoryOptionsHint = true;
            ShowQuerySearchHint = true;
            ShowDisabledSimulationComponentsHint = true;
            ShowSimulatedGeoLocationHint = true;
            ShowDeviceViewControlsHint = true;

            EditorEvents.UiComponentUsed.Send(new UiComponentArgs {label = k_ResetHintsEvent, active = true});
        }
    }
}

using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    class MarsPreferencesProvider : SettingsProvider
    {
        class Styles
        {
            public readonly GUIContent HighlightedSimulatedObjectColorContent;
            public readonly GUIContent ConditionFailTextColorTooltipContent;

            public Styles()
            {
                HighlightedSimulatedObjectColorContent = new GUIContent("Highlighted Simulated Object Color", MarsUserPreferences.HighlightedSimulatedObjectColorTooltip);
                ConditionFailTextColorTooltipContent = new GUIContent("Condition Fail Text Color", MarsUserPreferences.ConditionFailTextColorTooltip);
            }
        }

        const string k_CameraPermissionLabel = "Camera permission";
        const string k_OSXWithPermissionsHelpBox = "MARS Camera permissions are handled by the operating system. To allow or deny acces to the camera, go to System Preferences > Security & Privacy > Camera and toggle Unity Hub";

        static Styles s_Styles;
        static Styles styles => s_Styles ?? (s_Styles = new Styles());

        [SettingsProvider]
        public static SettingsProvider CreateMARSPreferencesProvider() { return new MarsPreferencesProvider(); }

        MarsPreferencesProvider(string path = "Preferences/MARS", SettingsScope scope = SettingsScope.User)
            : base(path, scope) { }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);

            if (CameraPermissionUtils.IsOSXWithPermissions())
            {
                EditorGUILayout.HelpBox(k_OSXWithPermissionsHelpBox, MessageType.Info);
            }
            else
            {
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    var granted = EditorPrefs.GetBool(CameraPermissionUtils.CameraPermissionPref, false);
                    granted = EditorGUILayout.Toggle(k_CameraPermissionLabel, granted);

                    if (check.changed)
                        EditorPrefs.SetBool(CameraPermissionUtils.CameraPermissionPref, granted);
                }
            }

            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            EditorGUI.BeginChangeCheck();

            if (GUILayout.Button("Reset All Hints", GUILayout.Width(120)))
                MarsHints.ResetHints();

            MarsUserPreferences.HighlightedSimulatedObjectColor = EditorGUILayout.ColorField(styles.HighlightedSimulatedObjectColorContent, MarsUserPreferences.HighlightedSimulatedObjectColor);
            MarsUserPreferences.ConditionFailTextColor = EditorGUILayout.ColorField(styles.ConditionFailTextColorTooltipContent, MarsUserPreferences.ConditionFailTextColor);

            using (new GUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Use Default Colors"))
                    MarsUserPreferences.ResetColors();

                GUILayout.FlexibleSpace();
            }

            if (EditorGUI.EndChangeCheck())
            {
                foreach (var window in Resources.FindObjectsOfTypeAll<EditorWindow>())
                {
                    window.Repaint();
                }
            }

            GUILayout.Space(5);

            MarsUserPreferences.RestrictCameraToEnvironmentBounds = EditorGUILayout.Toggle("Restrict Camera To Environment Bounds", MarsUserPreferences.RestrictCameraToEnvironmentBounds);
            MarsUserPreferences.TintImageMarkers = EditorGUILayout.Toggle("Tint Image Markers", MarsUserPreferences.TintImageMarkers);
            MarsUserPreferences.ElectiveExtensionsReportsErrors = EditorGUILayout.Toggle("Elective Extensions Reports Errors", MarsUserPreferences.ElectiveExtensionsReportsErrors);
        }
    }
}

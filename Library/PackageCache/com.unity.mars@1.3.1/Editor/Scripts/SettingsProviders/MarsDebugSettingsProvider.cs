using System.Linq;
using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS
{
    class MarsDebugSettingsProvider : SettingsProvider
    {
        SerializedObject m_DebugSettingsObject;
        MarsDebugLoggingSettingsDrawer m_MarsDebugLoggingSettingsDrawer;

        [SettingsProvider]
        public static SettingsProvider CreateMARSPreferencesProvider()
        {
            var provider = new MarsDebugSettingsProvider()
            {
                keywords = GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MarsDebugSettings.instance)).ToList()
            };

            return provider;
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            var debugSettings = MarsDebugSettings.instance;
            m_DebugSettingsObject = new SerializedObject(debugSettings);
            m_MarsDebugLoggingSettingsDrawer = new MarsDebugLoggingSettingsDrawer(m_DebugSettingsObject);
        }

        MarsDebugSettingsProvider(string path = MARSCore.ProjectSettingsRootPath + "/Debug Settings",
            SettingsScope scope = SettingsScope.Project) : base(path, scope) { }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            EditorGUILayout.LabelField("Enable Logging", EditorStyles.boldLabel);
            m_MarsDebugLoggingSettingsDrawer.InspectorGUI(m_DebugSettingsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }
}

using System.Linq;
using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS
{
    class MarsSceneTrackingSettingsProvider : SettingsProvider
    {
        SerializedObject m_SceneWatchdogObject;
        SceneWatchdogModuleDrawer m_SceneWatchdogModuleDrawer;

        SerializedObject m_SceneModuleObject;
        MarsSceneModuleSceneTrackingDrawer m_SceneModuleSceneTrackingDrawer;

        [SettingsProvider]
        public static SettingsProvider CreateMARSPreferencesProvider()
        {
            var keywordsList = GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(SceneWatchdogModule.instance)).ToList();
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MARSSceneModule.instance)));

            var provider = new MarsSceneTrackingSettingsProvider{ keywords = keywordsList };

            return provider;
        }

        MarsSceneTrackingSettingsProvider(string path = MARSCore.ProjectSettingsRootPath + "/Scene Tracking", SettingsScope scope = SettingsScope.Project)
            : base(path, scope) { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);

            var sceneWatchdogModule = SceneWatchdogModule.instance;
            m_SceneWatchdogObject = new SerializedObject(sceneWatchdogModule);
            m_SceneWatchdogModuleDrawer = new SceneWatchdogModuleDrawer(m_SceneWatchdogObject);

            var sceneModule = MARSSceneModule.instance;
            m_SceneModuleObject = new SerializedObject(sceneModule);
            m_SceneModuleSceneTrackingDrawer = new MarsSceneModuleSceneTrackingDrawer(m_SceneModuleObject);
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            EditorGUILayout.LabelField("Scene Module", EditorStyles.boldLabel);
            m_SceneModuleSceneTrackingDrawer.InspectorGUI(m_SceneModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Scene Watchdog", EditorStyles.boldLabel);
            m_SceneWatchdogModuleDrawer.InspectorGUI(m_SceneWatchdogObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }
}

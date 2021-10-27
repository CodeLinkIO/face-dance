using System.Linq;
using Unity.MARS.Authoring;
using Unity.MARS.Forces;
using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;
using UnityEditor.MARS.Simulation.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.MARS
{
    class MarsEditorVisualsSettingsProvider : SettingsProvider
    {
        SerializedObject m_CompositeRenderModuleObject;
        CompositeRenderModuleOptionsDrawer m_CompositeRenderModuleOptionsDrawer;

        SerializedObject m_DataVisualsModuleOptionsObject;
        DataVisualsModuleOptionsDrawer m_DataVisualsModuleOptionsDrawer;

        SerializedObject m_DebugSettingsObject;
        MarsDebugVisualsSettingsDrawer m_DebugVisualsSettingsDrawer;

        SerializedObject m_ProxyForcesFieldSolverModuleObject;
        ProxyForcesFieldSolverModuleDrawer m_ProxyForcesFieldSolverModuleDrawer;

        SerializedObject m_XRayOptionsObject;
        XRayOptionsDrawer m_XRayOptionsDrawer;

        [SettingsProvider]
        public static SettingsProvider CreateMarsPreferencesProvider()
        {
            var keywordsList = GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(DataVisualsModuleOptions.instance)).ToList();
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(MarsDebugSettings.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(ProxyForcesFieldSolverModule.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(CompositeRenderModuleOptions.instance)));
            keywordsList.AddRange(GetSearchKeywordsFromPath(AssetDatabase.GetAssetPath(XRayOptions.instance)));

            var provider = new MarsEditorVisualsSettingsProvider{ keywords = keywordsList };

            return provider;
        }

        MarsEditorVisualsSettingsProvider(string path = MARSCore.ProjectSettingsRootPath + "/Editor Visuals",
            SettingsScope scope = SettingsScope.Project)
            : base(path, scope) { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);

            var dataVisualsModuleOptions = DataVisualsModuleOptions.instance;
            m_DataVisualsModuleOptionsObject = new SerializedObject(dataVisualsModuleOptions);
            m_DataVisualsModuleOptionsDrawer = new DataVisualsModuleOptionsDrawer(m_DataVisualsModuleOptionsObject);

            var debugSettings = MarsDebugSettings.instance;
            m_DebugSettingsObject = new SerializedObject(debugSettings);
            m_DebugVisualsSettingsDrawer = new MarsDebugVisualsSettingsDrawer(m_DebugSettingsObject);

            var proxyForcesFieldSolverModule = ProxyForcesFieldSolverModule.instance;
            m_ProxyForcesFieldSolverModuleObject = new SerializedObject(proxyForcesFieldSolverModule);
            m_ProxyForcesFieldSolverModuleDrawer = new ProxyForcesFieldSolverModuleDrawer(m_ProxyForcesFieldSolverModuleObject);

            var compositeRenderModuleOptions = CompositeRenderModuleOptions.instance;
            m_CompositeRenderModuleObject = new SerializedObject(compositeRenderModuleOptions);
            m_CompositeRenderModuleOptionsDrawer = new CompositeRenderModuleOptionsDrawer(m_CompositeRenderModuleObject);

            var xRayOptions = XRayOptions.instance;
            m_XRayOptionsObject = new SerializedObject(xRayOptions);
            m_XRayOptionsDrawer = new XRayOptionsDrawer(m_XRayOptionsObject);
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            EditorGUIUtility.labelWidth = MarsEditorGUI.SettingsLabelWidth;

            EditorGUILayout.LabelField("Simulation Data Visuals", EditorStyles.boldLabel);
            m_DataVisualsModuleOptionsDrawer.InspectorGUI(m_DataVisualsModuleOptionsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Simulated Data Discovery", EditorStyles.boldLabel);
            m_DebugVisualsSettingsDrawer.InspectorGUI(m_DebugSettingsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Proxy Forces Solver", EditorStyles.boldLabel);
            m_ProxyForcesFieldSolverModuleDrawer.InspectorGUI(m_ProxyForcesFieldSolverModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Composite Render", EditorStyles.boldLabel);
            m_CompositeRenderModuleOptionsDrawer.InspectorGUI(m_CompositeRenderModuleObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("X-Ray Module", EditorStyles.boldLabel);
            m_XRayOptionsDrawer.InspectorGUI(m_XRayOptionsObject);
            EditorGUIUtils.DrawBoxSplitter();
            EditorGUILayout.Space();
        }
    }
}

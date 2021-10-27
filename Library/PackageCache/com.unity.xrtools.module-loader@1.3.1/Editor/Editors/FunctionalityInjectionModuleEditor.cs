using System;
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;

namespace Unity.XRTools.ModuleLoader
{
    [CustomEditor(typeof(FunctionalityInjectionModule))]
    class FunctionalityInjectionModuleEditor : Editor
    {
        class Styles
        {
            public GUIStyle ProviderTypesFoldoutStyle;

            public Styles()
            {
                ProviderTypesFoldoutStyle = new GUIStyle(EditorStyles.foldout);
            }
        }

        static readonly List<Type> k_AllProviderTypes = new List<Type>();
        static readonly List<Type> k_AllSubscriberTypes = new List<Type>();
        static readonly Dictionary<Type, MonoScript> k_MonoScripts = new Dictionary<Type, MonoScript>();
        static readonly string[] k_SearchInFolders = { "Assets", "Packages" };

        const float k_PriorityColumnWidth = 100f;
        const float k_PriorityHeaderOffset = 36f;

        static Styles s_Styles;
        static Styles styles { get { return s_Styles ?? (s_Styles = new Styles()); } }

        FunctionalityInjectionModule m_FIModule;
        bool m_ShowIslands = true;

        SerializedProperty m_DefaultIslandProperty;

        bool m_ShowProviderTypeList;
        bool m_ShowSubscriberTypeList;

        static FunctionalityInjectionModuleEditor()
        {
#if UNITY_2019_2_OR_NEWER
            foreach (var type in TypeCache.GetTypesDerivedFrom<IFunctionalityProvider>())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;

                k_AllProviderTypes.Add(type);
            }

            foreach (var type in TypeCache.GetTypesDerivedFrom<IFunctionalitySubscriber>())
            {
                if (type.IsAbstract || type.IsInterface)
                    continue;

                k_AllSubscriberTypes.Add(type);
            }
#else
            typeof(IFunctionalityProvider).GetImplementationsOfInterface(k_AllProviderTypes);
            typeof(IFunctionalitySubscriber).GetImplementationsOfInterface(k_AllSubscriberTypes);
#endif

            k_AllProviderTypes.Sort((a, b) =>
            {
                var optionsA = FunctionalityIsland.GetProviderSelectionOptions(a);
                var optionsB = FunctionalityIsland.GetProviderSelectionOptions(b);
                return optionsB.Priority.CompareTo(optionsA.Priority);
            });
        }

        static void AddMonoScriptTypes(List<Type> types)
        {
            foreach (var type in types)
            {
                if (k_MonoScripts.ContainsKey(type))
                    continue;

                var guids = AssetDatabase.FindAssets(type.Name, k_SearchInFolders);
                foreach (var guid in guids)
                {
                    var importer = AssetImporter.GetAtPath(AssetDatabase.GUIDToAssetPath(guid)) as MonoImporter;
                    if (importer)
                    {
                        var script = importer.GetScript();
                        var scriptType = script.GetClass();
                        if (scriptType == null || scriptType != type)
                            continue;

                        k_MonoScripts[type] = script;
                    }
                }
            }
        }

        void OnEnable()
        {
            m_FIModule = (FunctionalityInjectionModule)target;
            m_DefaultIslandProperty = serializedObject.FindProperty("m_DefaultIsland");
            var scripts = MonoImporter.GetAllRuntimeMonoScripts();
            foreach (var script in scripts)
            {
                var type = script.GetClass();
                if (type == null)
                    continue;

                k_MonoScripts[type] = script;
            }

            AddMonoScriptTypes(k_AllProviderTypes);
            AddMonoScriptTypes(k_AllSubscriberTypes);
        }

        public override void OnInspectorGUI()
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(m_DefaultIslandProperty);
                m_ShowIslands = EditorGUILayout.Foldout(m_ShowIslands, "Current Islands", true);
                if (m_ShowIslands)
                    DrawCurrentIslands();

                if (check.changed)
                    serializedObject.ApplyModifiedProperties();
            }

            const float providerColumnWidthRatio = 0.5f;
            var providerWidth = EditorGUIUtility.currentViewWidth * providerColumnWidthRatio;
            var foldoutStyle = styles.ProviderTypesFoldoutStyle;
            styles.ProviderTypesFoldoutStyle.fixedWidth = providerWidth;
            var providerColumnWidth = GUILayout.Width(providerWidth);
            var priorityColumnWidth = GUILayout.Width(k_PriorityColumnWidth);
            using (new EditorGUILayout.HorizontalScope())
            {
                m_ShowProviderTypeList = EditorGUILayout.Foldout(m_ShowProviderTypeList, "Provider Types", true, foldoutStyle);
                if (m_ShowProviderTypeList)
                {
                    GUILayout.Space(providerWidth - k_PriorityHeaderOffset);
                    GUILayout.Label("Priorities", priorityColumnWidth);
                    GUILayout.Label("Excluded Platforms");
                }
            }

            if (m_ShowProviderTypeList)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    foreach (var type in k_AllProviderTypes)
                    {
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            var priority = 0;
                            var excludedPlatforms = string.Empty;
                            var priorityAttribute = FunctionalityIsland.GetProviderSelectionOptions(type);
                            if (priorityAttribute != null)
                            {
                                priority = priorityAttribute.Priority;
                                var platforms = priorityAttribute.ExcludedPlatforms;
                                if (platforms != null)
                                    excludedPlatforms = String.Join(", ", platforms);
                            }

                            MonoScript script;
                            if (k_MonoScripts.TryGetValue(type, out script))
                                EditorGUILayout.ObjectField(script, typeof(MonoScript), false, providerColumnWidth);
                            else
                                EditorGUILayout.LabelField(type.GetFullNameWithGenericArguments(), providerColumnWidth);

                            EditorGUILayout.LabelField(priority.ToString(), priorityColumnWidth);
                            EditorGUILayout.LabelField(string.Join(", ", excludedPlatforms));
                        }
                    }
                }
            }

            m_ShowSubscriberTypeList = EditorGUILayout.Foldout(m_ShowSubscriberTypeList, "Subscriber Types", true);
            if (m_ShowSubscriberTypeList)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    foreach (var type in k_AllSubscriberTypes)
                    {
                        MonoScript script;
                        if (k_MonoScripts.TryGetValue(type, out script))
                            EditorGUILayout.ObjectField(script, typeof(MonoScript), false);
                        else
                            EditorGUILayout.LabelField(type.GetFullNameWithGenericArguments());
                    }
                }
            }
        }

        void DrawCurrentIslands()
        {
            using (new EditorGUI.IndentLevelScope())
            {
                using (new EditorGUI.DisabledGroupScope(true))
                {
                    EditorGUILayout.ObjectField("Active Island", m_FIModule.activeIsland, typeof(FunctionalityIsland), false);
                }

                foreach (var island in m_FIModule.islands)
                {
                    if (!island)
                        continue;

                    island.foldoutState = EditorGUILayout.Foldout(island.foldoutState, island.name, true);
                    if (!island.foldoutState)
                        continue;

                    FunctionalityIslandEditor.DrawProviders(island);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.XRTools.ModuleLoader;
using UnityEditor.MARS.Simulation;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    [MovedFrom("Unity.MARS")]
    class TemplatesWindow : EditorWindow
    {
        const string k_CollectionSearchFilter = "t:TemplateCollection";

        const int k_ButtonSize = 85;
        const int k_ButtonMargin = 8;
        const int k_RowMargin = 26;
        static readonly GUIContent k_WindowTitle;

        int m_ButtonsPerRow;
        List<TemplateData> m_Templates = new List<TemplateData>();
        float[] m_NameWidths;
        float m_WindowWidth;

        static TemplatesWindow()
        {
            k_WindowTitle = new GUIContent("Templates");
        }

        [MenuItem(MenuConstants.MenuPrefix + "Choose Template", priority = MenuConstants.TemplatePriority)]
        static void ShowTemplatesWindow()
        {
            var window = (TemplatesWindow)CreateInstance(typeof(TemplatesWindow));
            window.titleContent = k_WindowTitle;
            window.ShowUtility();
        }

        void OnEnable()
        {
            m_Templates.Clear();

            var templateCollectionGuids = AssetDatabase.FindAssets(k_CollectionSearchFilter);

            foreach (var guid in templateCollectionGuids)
            {
                var templateCollection = AssetDatabase.LoadAssetAtPath<TemplateCollection>(AssetDatabase.GUIDToAssetPath(guid));
                m_Templates.AddRange(templateCollection.templates);
            }

            var templatesCount = m_Templates.Count;
            m_ButtonsPerRow = Mathf.CeilToInt(Mathf.Sqrt(templatesCount));
            m_WindowWidth = (k_ButtonSize + k_ButtonMargin * 2) * m_ButtonsPerRow + k_ButtonMargin * 4;
            minSize = default(Vector2);

            m_NameWidths = new float[m_Templates.Count];
            for (var i = 0; i < templatesCount; i++)
            {
                var nameWidth = EditorStyles.label.CalcSize(new GUIContent(m_Templates[i].name)).x;
                m_NameWidths[i] = Mathf.Min(nameWidth, k_ButtonSize);
            }
        }

        void OnDisable()
        {
            m_Templates.Clear();
        }

        void OnGUI()
        {
            if (m_Templates == null)
            {
                EditorGUILayout.LabelField("No Templates");
                GUIUtility.ExitGUI();
            }

            using (new GUILayout.VerticalScope())
            {
                GUILayout.Label(" Choose a Template", EditorStyles.boldLabel);
                GUILayout.Space(5);

                var templateCount = m_Templates.Count;
                for (var i = 0; i < templateCount; i += m_ButtonsPerRow)
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        GUILayout.Space(k_ButtonMargin);
                        for (var j = i; j < i + m_ButtonsPerRow; j++)
                        {
                            if (j >= templateCount)
                            {
                                GUILayout.Space(k_ButtonMargin * 2 + k_ButtonSize);
                                continue;
                            }

                            DrawTemplateButton(m_Templates[j], m_NameWidths[j]);
                        }
                        GUILayout.Space(k_ButtonMargin);
                    }
                    GUILayout.Space(k_RowMargin);
                }
            }

            if (minSize == default(Vector2))
            {
                var rect = GUILayoutUtility.GetLastRect();

                if (Event.current.type == EventType.Repaint)
                    minSize = maxSize = new Vector2(m_WindowWidth, rect.height);
            }
        }

        void DrawTemplateButton(TemplateData template, float nameWidth)
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Space(k_ButtonMargin);

                using (new GUILayout.VerticalScope())
                {
                    if (GUILayout.Button(template.icon, GUI.skin.GetStyle("Box"), GUILayout.Width(k_ButtonSize), GUILayout.Height(k_ButtonSize)))
                    {
                        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

                        var moduleLoader = ModuleLoaderCore.instance;
                        if (moduleLoader != null)
                        {
                            var environmentManager = moduleLoader.GetModule<MARSEnvironmentManager>();
                            if (environmentManager != null && environmentManager.TrySetModeAndRestartSimulation(template.environmentMode))
                                EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(template.scene));
                        }

                        Close();
                        GUIUtility.ExitGUI();
                    }

                    using (new GUILayout.HorizontalScope())
                    {
                        GUILayout.FlexibleSpace();
                        GUILayout.Label(template.name, EditorStyles.label, GUILayout.Width(nameWidth));
                        GUILayout.FlexibleSpace();
                    }
                }

                GUILayout.Space(k_ButtonMargin);
            }
        }
    }
}

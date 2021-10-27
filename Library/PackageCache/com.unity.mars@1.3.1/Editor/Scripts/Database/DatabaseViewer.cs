using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS.Data
{
    class MARSDatabaseViewer : EditorWindow, IHasCustomMenu
    {
        class Styles
        {
            public const string k_CompilingMessage = "Database Viewer unavailable while recompiling...";

            public static readonly GUIStyle CompilingStyle;
            public static readonly GUIStyle BiggestFoldoutLabelStyle;

            static Styles()
            {
                CompilingStyle = new GUIStyle(EditorStyles.label)
                {
                    fontSize = 11,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true
                };

                BiggestFoldoutLabelStyle = new GUIStyle(EditorStyles.foldout);
                {
                    BiggestFoldoutLabelStyle.fontSize = 14;
                    BiggestFoldoutLabelStyle.fontStyle = FontStyle.Bold;
                };
            }
        }

        public const string WindowTitle = "Database Viewer";
        static readonly StringBuilder k_StringBuilder = new StringBuilder();

        static readonly Vector2 k_MaxSize = new Vector2(280f, 3400f);

        static bool s_ShowDataOwnership = true;
        static bool s_ShowTraitData = true;
        static bool s_ShowProviderData;

        readonly GUILayoutOption m_OwnershipKeyColumnWidth = GUILayout.Width(108);
        readonly GUILayoutOption m_OwnershipValueColumnWidth = GUILayout.Width(142);

        Vector2 m_DataOwnershipScrollPosition;
        Vector2 m_ProviderDataScrollPosition;
        Vector2 m_TraitScrollPosition;

        [MenuItem(MenuConstants.DevMenuPrefix + WindowTitle, priority = MenuConstants.DatabaseViewerPriority)]
        public static void Init()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = WindowTitle, active = true });
            GetWindow(typeof(MARSDatabaseViewer), false, WindowTitle);
        }

        public void AddItemsToMenu(GenericMenu menu) { this.MarsCustomMenuOptions(menu); }

        void OnEnable()
        {
            titleContent.text = WindowTitle;
            maxSize = k_MaxSize;
            MARSDatabase.dataUpdating += Repaint;
        }

        void OnDisable()
        {
            MARSDatabase.dataUpdating -= Repaint;
        }

        void OnDestroy()
        {
            EditorEvents.WindowUsed.Send(new UiComponentArgs { label = WindowTitle, active = false });
        }

        void OnGUI()
        {
            if (EditorApplication.isCompiling)
            {
                GUILayout.FlexibleSpace();
                EditorGUILayout.LabelField(Styles.k_CompilingMessage, Styles.CompilingStyle);
                GUILayout.FlexibleSpace();
                return;
            }

            var db = ModuleLoaderCore.instance.GetModule<MARSDatabase>();
            if (db == null)
                return;

            s_ShowDataOwnership = EditorGUILayout.Foldout(s_ShowDataOwnership, "Data Ownership", true, Styles.BiggestFoldoutLabelStyle);
            if (s_ShowDataOwnership)
            {
                using (new EditorGUILayout.VerticalScope())
                {
                    DrawDataOwnership(db);
                }
            }

            s_ShowProviderData = EditorGUILayout.Foldout(s_ShowProviderData, "Trackable Data", true, Styles.BiggestFoldoutLabelStyle);
            if (s_ShowProviderData)
            {
                m_ProviderDataScrollPosition = EditorGUILayout.BeginScrollView(m_ProviderDataScrollPosition);
                DrawPlaneData(db.planeData.dictionary);
                DrawFaceData(db.faceData.dictionary);
                DrawDataCollection("Synthesized Objects", db.synthesizedObjectData);
                EditorGUILayout.EndScrollView();
                EditorGUILayout.Separator();
            }

            s_ShowTraitData = EditorGUILayout.Foldout(s_ShowTraitData, "Trait Data", true, Styles.BiggestFoldoutLabelStyle);
            if (s_ShowTraitData)
            {
                m_TraitScrollPosition = EditorGUILayout.BeginScrollView(m_TraitScrollPosition);
                db.GetTraitProvider(out MARSTraitDataProvider<bool> tagTraits);
                // if we get a null provider, code generation hasn't run yet
                if (tagTraits == null)
                    return;

                DrawTraitCollection("Semantic Tag Traits", tagTraits);
                db.GetTraitProvider(out MARSTraitDataProvider<Pose> poseTraits);
                DrawTraitCollection("Pose Traits", poseTraits);
                db.GetTraitProvider(out MARSTraitDataProvider<string> stringTraits);
                DrawTraitCollection("String Traits", stringTraits);
                db.GetTraitProvider(out MARSTraitDataProvider<Vector3> vector3Traits);
                DrawTraitCollection("Vector3 Traits", vector3Traits);
                db.GetTraitProvider(out MARSTraitDataProvider<Vector2> vector2Traits);
                DrawTraitCollection("Vector2 Traits", vector2Traits);
                db.GetTraitProvider(out MARSTraitDataProvider<float> floatTraits);
                DrawTraitCollection("Float Traits", floatTraits);
                db.GetTraitProvider(out MARSTraitDataProvider<int> intTraits);
                DrawTraitCollection("Int Traits", intTraits);
                EditorGUILayout.EndScrollView();
                EditorGUILayout.Separator();
            }
        }

        void DrawDataOwnership(MARSDatabase db)
        {
            using (var scope = new EditorGUILayout.ScrollViewScope(m_DataOwnershipScrollPosition))
            {
                EditorGUILayout.Space();
                EditorGUIUtils.DrawDictionaryWithHeader(db.DataUsedByQueries, "Used By Proxies",
                    "Query ID", "Data IDs", m_OwnershipKeyColumnWidth, m_OwnershipValueColumnWidth,
                    CollectionExtensions.Stringify);

                EditorGUILayout.Space();
                EditorGUIUtils.DrawBoxSplitter();
                EditorGUIUtils.DrawDictionaryWithHeader(db.DataUsedByQueryMatches, "Used By Each Proxy Match",
                    "Query Match ID", "Data ID", m_OwnershipKeyColumnWidth, m_OwnershipValueColumnWidth);

                EditorGUILayout.Space();
                EditorGUIUtils.DrawDictionaryWithHeader(db.SetDataUsedByQueryMatches, "Used By Each ProxyGroup Match",
                    "Query Match ID", "Data IDs", m_OwnershipKeyColumnWidth, m_OwnershipValueColumnWidth,
                    CollectionExtensions.Stringify);

                EditorGUILayout.Space();
                EditorGUIUtils.DrawBoxSplitter();
                EditorGUIUtils.DrawDictionaryWithHeader(db.ReservedData, "Reserved Data",
                    "Data ID", "Reserved By Query", m_OwnershipKeyColumnWidth, m_OwnershipValueColumnWidth);

                EditorGUILayout.Space();
                EditorGUIUtils.DrawBoxSplitter();
                EditorGUIUtils.DrawDictionaryWithHeader(db.SharedDataUsersCounter, "Shared Data",
                    "Data ID", "# of Users", m_OwnershipKeyColumnWidth, m_OwnershipValueColumnWidth);

                EditorGUILayout.Space();
                EditorGUIUtils.DrawBoxSplitter();
                m_DataOwnershipScrollPosition = scope.scrollPosition;
            }
        }

        static void DrawTraitCollection<T>(string label, MARSTraitDataProvider<T> provider)
        {
            if (provider == null || provider.dictionary.Count < 1)
                return;

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField(label, EditorStyles.largeLabel);

            foreach (var traitsKvp in provider.dictionary)
            {
                k_StringBuilder.Length = 0;
                EditorGUILayout.LabelField("Trait name: " + traitsKvp.Key, EditorStyles.boldLabel);

                foreach (var kvp in traitsKvp.Value)
                    k_StringBuilder.AppendFormat("ID: {0}, Value: {1}\n", kvp.Key, kvp.Value);

                EditorGUILayout.HelpBox(k_StringBuilder.ToString(), MessageType.None);
            }
        }

        static void DrawFaceData(Dictionary<MarsTrackableId, KeyValuePair<int, IMRFace>> dictionary)
        {
            if (dictionary.Count < 1)
                return;

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Faces", EditorStyles.largeLabel);
            foreach (var kvp in dictionary)
            {
                var entry = kvp.Value;
                var face = entry.Value;
                var landmarkPoses = face.LandmarkPoses;
                EditorGUILayout.LabelField("ID: " + kvp.Key, EditorStyles.boldLabel);
                k_StringBuilder.Length = 0;
                foreach (var landmark in landmarkPoses)
                {
                    k_StringBuilder.AppendFormat("Landmark: {0}, Pose: {1}\n", landmark.Key, landmark.Value);
                }
                EditorGUILayout.LabelField("Landmark Poses");
                EditorGUILayout.HelpBox(k_StringBuilder.ToString(), MessageType.None);
                k_StringBuilder.Length = 0;
                if (face.Expressions.Count > 0)
                {
                    foreach (var expression in face.Expressions)
                    {
                        k_StringBuilder.AppendFormat("Expression: {0}, Coefficient: {1}\n", expression.Key,
                            expression.Value.ToString("F2", CultureInfo.InvariantCulture));
                    }

                    EditorGUILayout.LabelField("Expression Coefficients");
                    EditorGUILayout.HelpBox(k_StringBuilder.ToString(), MessageType.None);
                }
            }
        }

        static void DrawPlaneData(Dictionary<MarsTrackableId, KeyValuePair<int, MRPlane>> dictionary)
        {
            if (dictionary.Count < 1)
                return;

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Planes", EditorStyles.largeLabel);
            foreach (var kvp in dictionary)
            {
                var entry = kvp.Value;
                var plane = entry.Value;
                EditorGUILayout.LabelField("ID: " + kvp.Key + ", Plane ID:" + plane.id);

                k_StringBuilder.Length = 0;
                var vertices = plane.vertices;
                if (vertices != null)
                {
                    var vertexCount = plane.vertices.Count;
                    for (var i = 0; i < vertexCount; i++)
                    {
                        k_StringBuilder.AppendFormat("Vertex {0}:, {1}\n", i, vertices[i]);
                    }
                }

                EditorGUILayout.LabelField("Vertices");
                EditorGUILayout.HelpBox(k_StringBuilder.ToString(), MessageType.None);
            }
        }

        static void DrawDataCollection<T>(string label, MARSDataProvider<T> provider)
        {
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);

            foreach (var traitsKVP in provider.dictionary)
            {
                EditorGUILayout.LabelField(String.Format("ID:{0}", traitsKVP.Key));
                EditorGUILayout.HelpBox(String.Format("{0}", traitsKVP.Value), MessageType.None);
            }
        }
    }
}

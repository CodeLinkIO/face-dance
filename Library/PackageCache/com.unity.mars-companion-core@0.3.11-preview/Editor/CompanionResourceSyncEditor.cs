using UnityEditor;
using UnityObject = UnityEngine.Object;

namespace Unity.MARS.Companion.Core
{
    [CustomEditor(typeof(CompanionResourceSync))]
    class CompanionResourceSyncEditor : Editor
    {
        bool m_Expanded = true;
        SerializedProperty m_DefaultMarkerLibraryProperty;

        void OnEnable()
        {
            m_DefaultMarkerLibraryProperty = serializedObject.FindProperty("m_DefaultMarkerLibrary");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(m_DefaultMarkerLibraryProperty);
            m_Expanded = EditorGUILayout.Foldout(m_Expanded, "Resource Mapping", true);
            if (!m_Expanded)
                return;

            using (new EditorGUI.IndentLevelScope())
            {
                var sync = (CompanionResourceSync)target;
                foreach (var kvp in sync.ResourceDictionary)
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField($"Cloud guid: {kvp.Key}");

                        UnityObject asset = null;
                        var assetGuid = kvp.Value;
                        if (!string.IsNullOrEmpty(assetGuid))
                        {
                            var assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                            if (!string.IsNullOrEmpty(assetPath))
                                asset = AssetDatabase.LoadAssetAtPath<UnityObject>(assetPath);
                        }

                        if (asset == null)
                            EditorGUILayout.LabelField($"Asset guid: {kvp.Value}");
                        else
                            EditorGUILayout.ObjectField(asset, typeof(UnityObject), false);
                    }
                }
            }
        }
    }
}

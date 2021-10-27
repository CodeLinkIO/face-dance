using Unity.MARS.Data;
using Unity.MARS.Data.ARFoundation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data.ARFoundation
{
    [CustomEditor(typeof(MarkerProviderSettings))]
    [MovedFrom("Unity.MARS.Providers")]
    public class MarkerProviderSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var settings = (MarkerProviderSettings)target;
            var libraryMap = settings.MarsToXRLibraryMap;
            if (libraryMap.Count == 0)
            {
                EditorGUILayout.LabelField("No Image Libraries");
            }
            else
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("MARS Libraries");
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("AR Foundation Libraries");
                }

                using (new EditorGUI.DisabledScope(true))
                {
                    foreach (var kvp in libraryMap)
                    {
                        using (new EditorGUILayout.HorizontalScope())
                        {
                            EditorGUILayout.ObjectField(kvp.Key, typeof(MarsMarkerLibrary), false);
                            GUILayout.FlexibleSpace();
                            EditorGUILayout.ObjectField(kvp.Value, typeof(MarsMarkerLibrary), false);
                        }
                    }
                }
            }
        }
    }
}

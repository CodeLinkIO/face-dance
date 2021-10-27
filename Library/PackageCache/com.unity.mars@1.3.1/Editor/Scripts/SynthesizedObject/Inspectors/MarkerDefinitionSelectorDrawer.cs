using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    class MarkerDefinitionSelectorDrawer
    {
        const string k_CurrentMarkerGuidDoesntMatchCurrentLibrary = "Current internal marker ID doesn't match any of the " +
            "IDs in the current library. It might belong to another library.";

        static readonly GUIContent s_MarkerIDContent;

        int m_SizeOptionIndex;
        int m_CurrentMarkerIndex = ImageMarkerEditorUtils.UnselectedMarkerIndex;
        Vector2 m_ImageBrowserScrollPos;
        SerializedObject m_MarkerLibrarySerializedObject;
        SerializedProperty m_MarkerProperty;
        SerializedProperty m_MarkerDefinitionProperty;
        MarsMarkerLibrary m_MarkerLibrary;

        static MarkerDefinitionSelectorDrawer()
        {
            s_MarkerIDContent = new GUIContent("Marker ID", "Image marker GUID in the marker library (read only).");
        }

        internal void UpdateMarkerLibrarySerializedObject()
        {
            m_MarkerLibrarySerializedObject.Update();
        }

        public MarkerDefinitionSelectorDrawer(string markerGuidValue)
        {
            var markerLibraryModule = ModuleLoaderCore.instance.GetModule<MARSMarkerLibraryModule>();
            if (markerLibraryModule != null)
                markerLibraryModule.UpdateMarkerDataFromLibraries();

            var marsSession = MARSSession.Instance;
            if (marsSession == null)
                return;

            var markerLibrary = marsSession.MarkerLibrary;
            if (markerLibrary == null)
                return;

            UpdateMarkerLibraryData(markerLibrary, markerGuidValue);
        }

        /// <summary>
        /// Draw the Marker Definition Selector GUI
        /// </summary>
        /// <param name="markerLibrary"></param>
        /// <param name="markerGuidValue">The guid string value of the marker id</param>
        /// <returns>Guid of the selected marker</returns>
        public string DrawSelectorGUI(MarsMarkerLibrary markerLibrary, string markerGuidValue)
        {
            UpdateMarkerLibraryData(markerLibrary, markerGuidValue);

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var selectionIndex = ImageMarkerEditorUtils.DrawImageMarkerLibraryInspector(ref m_ImageBrowserScrollPos,
                    markerLibrary, m_CurrentMarkerIndex);

                if (m_CurrentMarkerIndex == ImageMarkerEditorUtils.UnselectedMarkerIndex)
                {
                    EditorGUILayout.HelpBox(k_CurrentMarkerGuidDoesntMatchCurrentLibrary, MessageType.Info);
                }
                else
                {
                    m_SizeOptionIndex = ImageMarkerEditorUtils.DrawImageMarkerInfoContentsAtIndex(m_MarkerDefinitionProperty,
                        m_SizeOptionIndex);
                }

                DrawGuid(markerGuidValue);

                if (check.changed)
                {
                    m_MarkerLibrarySerializedObject.ApplyModifiedProperties();
                    UpdateMarkerLibrarySerializedObject();
                }

                return selectionIndex != ImageMarkerEditorUtils.UnselectedMarkerIndex ?
                    markerLibrary[selectionIndex].MarkerId.ToString() : markerGuidValue;
            }
        }

        /// <summary>
        /// Updates the Marker library data for this drawer.
        /// </summary>
        /// <param name="markerGuidValue">The guid string value of the marker id</param>
        public void UpdateMarkerLibraryData(string markerGuidValue)
        {
            UpdateMarkerLibraryData(m_MarkerLibrary, markerGuidValue);
        }

        void UpdateMarkerLibraryData(MarsMarkerLibrary markerLibrary, string markerGuidValue)
        {
            const string markersProp = "m_Markers";

            if (m_CurrentMarkerIndex != ImageMarkerEditorUtils.UnselectedMarkerIndex &&
                m_CurrentMarkerIndex < markerLibrary.Count &&
                markerLibrary[m_CurrentMarkerIndex].MarkerId.ToString() == markerGuidValue &&
                m_MarkerLibrary == markerLibrary)
            {
                return;
            }

            m_CurrentMarkerIndex = ImageMarkerEditorUtils.CurrentSelectedImageMarkerIndex(markerLibrary, markerGuidValue);

            if (m_MarkerLibrary != markerLibrary)
            {
                m_MarkerLibrarySerializedObject = new SerializedObject(markerLibrary);
                m_MarkerProperty = m_MarkerLibrarySerializedObject.FindProperty(markersProp);

                m_MarkerLibrary = markerLibrary;
            }

            if (m_CurrentMarkerIndex != ImageMarkerEditorUtils.UnselectedMarkerIndex)
            {
                m_SizeOptionIndex = MarkerConstants.GetSelectedMarsMarkerSizeOption(markerLibrary[m_CurrentMarkerIndex].Size);

                m_MarkerDefinitionProperty = m_MarkerProperty.GetArrayElementAtIndex(m_CurrentMarkerIndex);
            }
        }

        public static void DrawGuid(string markerGuidValue)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(s_MarkerIDContent, GUILayout.Width(EditorGUIUtility.labelWidth));
                EditorGUILayout.SelectableLabel(markerGuidValue, GUILayout.Height(EditorGUIUtility.singleLineHeight));
            }
        }
    }
}

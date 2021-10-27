using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using UnityEditor;
using UnityEditor.MARS;

namespace Unity.MARS
{
    [ComponentEditor(typeof(MarkerCondition))]
    class MarkerConditionInspector : ComponentInspector
    {
        MarkerDefinitionSelectorDrawer m_MarkerDefinitionSelectorDrawer;
        SerializedProperty m_MarkerGuidProperty;

        public override void OnEnable()
        {
            base.OnEnable();
            const string markerGuidProp = "m_MarkerGuid";
            m_MarkerGuidProperty = serializedObject.FindProperty(markerGuidProp);

            m_MarkerDefinitionSelectorDrawer = new MarkerDefinitionSelectorDrawer(m_MarkerGuidProperty.stringValue);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            m_MarkerDefinitionSelectorDrawer = null;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var markerLibrary = ImageMarkerEditorUtils.GetSessionMarkerLibrary();
            if (markerLibrary == null)
                return;

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var currentMarkerID = m_MarkerGuidProperty.stringValue;
                var newMarkerID = m_MarkerDefinitionSelectorDrawer.DrawSelectorGUI(markerLibrary, currentMarkerID);
                if (newMarkerID != currentMarkerID)
                {
                    m_MarkerGuidProperty.stringValue = newMarkerID;
                    serializedObject.ApplyModifiedProperties();
                    m_MarkerDefinitionSelectorDrawer.UpdateMarkerLibraryData(m_MarkerGuidProperty.stringValue);
                }

                if (check.changed)
                {
                    serializedObject.ApplyModifiedProperties();
                    isDirty = true;

                    var marsSession = MARSSession.Instance;
                    if (marsSession == null)
                        return;

                    marsSession.CheckCapabilities();
                }
            }
        }
    }
}

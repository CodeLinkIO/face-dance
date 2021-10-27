using Unity.MARS.Settings;
using UnityEditor;
using UnityEditor.MARS;

namespace Unity.MARS
{
    [CustomEditor(typeof(MARSMemoryOptions))]
    class MARSMemoryOptionsEditor : Editor
    {
        SerializedProperty m_MultiplierProperty;
        SerializedProperty m_QueryDataCapacityProperty;
        SerializedProperty m_RatingDictCapacityProperty;
        SerializedProperty m_MatchSetCapacityProperty;
        SerializedProperty m_MatchSetCountProperty;
        SerializedProperty m_ResultDictCapacityProperty;
        SerializedProperty m_UseTrackingCapacityProperty;
        SerializedProperty m_DirtyStatesCapacityProperty;
        SerializedProperty m_DirtyStatesCountProperty;
        SerializedProperty m_TraitDictionaryCapacityProperty;

        int m_PreviousSliderValue;
        bool m_AdvancedEditing;

        const string k_AdvancedEditHelpContent = "Any changes made in here will be blown away if you " +
                                                 "change the slider above!\n\nThis should be used after " +
                                                 "you have tweaked the general multiplier & are still " +
                                                 "seeing dynamic allocation come from the query system.";

        const string k_GeneralHelpContent = "These numbers control how much memory gets allocated by MARS when " +
                                            "it loads.\nIt is fine to leave them at their defaults.\n\n" +
                                            "Pre-allocating more memory means we are less likely to " +
                                            "have to incur garbage collection later, but also means the system " +
                                            "will use more memory as soon as it starts.\n\n By adjusting the " +
                                            "slider below, you can scale that memory usage across all settings.";

        void OnEnable()
        {
            m_MultiplierProperty = serializedObject.FindProperty("m_Multiplier");

            m_QueryDataCapacityProperty = serializedObject.FindProperty("QueryDataCapacity");
            m_RatingDictCapacityProperty = serializedObject.FindProperty("RatingDictionaryCapacity");
            m_MatchSetCapacityProperty = serializedObject.FindProperty("MatchIdHashSetCapacity");
            m_MatchSetCountProperty = serializedObject.FindProperty("MatchIdHashSetPreAllocationCount");
            m_ResultDictCapacityProperty = serializedObject.FindProperty("ResultDictionaryCapacity");
            m_UseTrackingCapacityProperty = serializedObject.FindProperty("DataUseTrackingCapacity");
            m_DirtyStatesCapacityProperty = serializedObject.FindProperty("DataDirtyStatesCapacity");
            m_DirtyStatesCountProperty = serializedObject.FindProperty("DataDirtyStatesPreAllocationCount");
            m_TraitDictionaryCapacityProperty = serializedObject.FindProperty("TraitDictionaryListCapacity");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var showHint = MarsHints.ShowMemoryOptionsHint;
            showHint = MarsEditorUtils.HintBox(showHint, k_GeneralHelpContent, "Memory options help");
            MarsHints.ShowMemoryOptionsHint = showHint;

            m_MultiplierProperty.intValue = EditorGUILayout.IntSlider("Allocation Multiplier",
                m_MultiplierProperty.intValue, 1, 10);

            // being / end change check gives too many events, so manually detect changes
            if (m_PreviousSliderValue != m_MultiplierProperty.intValue)
            {
                UpdateObject(m_MultiplierProperty.intValue);
                serializedObject.ApplyModifiedProperties();
            }

            m_PreviousSliderValue = m_MultiplierProperty.intValue;

            m_AdvancedEditing = EditorGUILayout.Toggle("Enable Advanced Editing", m_AdvancedEditing);

            if (m_AdvancedEditing)
            {
                EditorGUILayout.HelpBox(k_AdvancedEditHelpContent, MessageType.Warning);
            }

            using (new EditorGUI.DisabledScope(!m_AdvancedEditing))
            {
                DrawDefaultInspector();
            }

            serializedObject.ApplyModifiedProperties();
        }

        void UpdateObject(int multiplier)
        {
            m_QueryDataCapacityProperty.intValue = MARSMemoryOptions.Defaults.QueryDataCapacity * multiplier;
            m_RatingDictCapacityProperty.intValue = MARSMemoryOptions.Defaults.RatingDictionaryCapacity * multiplier;
            m_MatchSetCapacityProperty.intValue = MARSMemoryOptions.Defaults.MatchIdHashSetCapacity * multiplier;
            m_MatchSetCountProperty.intValue = MARSMemoryOptions.Defaults.MatchIdHashSetPreAllocationCount * multiplier;
            m_ResultDictCapacityProperty.intValue = MARSMemoryOptions.Defaults.ResultDictionaryCapacity * multiplier;
            m_UseTrackingCapacityProperty.intValue = MARSMemoryOptions.Defaults.DataUseTrackingCapacity * multiplier;
            m_DirtyStatesCapacityProperty.intValue = MARSMemoryOptions.Defaults.DataDirtyStatesCapacity * multiplier;
            m_DirtyStatesCountProperty.intValue = MARSMemoryOptions.Defaults.DataDirtyStatesPreAllocationCount * multiplier;
            m_TraitDictionaryCapacityProperty.intValue = MARSMemoryOptions.Defaults.TraitDictionaryListCapacity * multiplier;
        }
    }
}

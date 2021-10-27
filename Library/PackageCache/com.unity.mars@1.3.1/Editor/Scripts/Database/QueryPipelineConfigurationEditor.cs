using System;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEditor;
using UnityEditor.MARS;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(QueryPipelineConfiguration))]
    class QueryPipelineConfigurationEditor : Editor
    {
        const string k_HelpText = "This configuration asset determines how MARS will spread out the work " +
                                  "of acquiring matches for objects with conditions.\n\n" +
                                  "Each entry in this array defines the maximum amount of frames a stage is allowed to take\n" +
                                  "If 0, a stage will be run on the same frame as all adjacent stages with a budget of 0.\n\n" +
                                  "The cycle will always start on CycleSetup & end on AcquireHandling.";

        const string k_SetOrderText = "The weight number for each object type in a set determines how much that type " +
                                      "of object influences the order in which sets' answers are found.\nA higher " +
                                      "number means more influence on the order";

        const string k_SearchCurveText = "This curve determines how extensive of a search we perform for set matches.\n" +
                                         "Not recommended to modify in most cases, as " +
                                         "modification can lead to drastic performance effects";

        SerializedProperty m_FrameBudgetsProperty;
        SerializedProperty m_SearchCurveProperty;
        SerializedProperty m_SetOrderWeightsProperty;
        SerializedProperty m_ReservedMemberWeightProperty;
        SerializedProperty m_SharedMemberWeightProperty;
        SerializedProperty m_RelationWeightProperty;

        bool m_ShowFrameFenceFoldout;
        bool m_ShowOrderWeightFoldout;
        bool m_ShowFrameBudgetsFoldout;
        bool m_ShowWeightsHelp = true;
        bool m_ShowCurveHelp = true;
        bool m_ShowHelp = true;

        public void OnEnable()
        {
            m_SearchCurveProperty = serializedObject.FindProperty("m_SearchSpacePortionCurve");
            m_FrameBudgetsProperty = serializedObject.FindProperty("m_FrameBudgets");
            m_SetOrderWeightsProperty = serializedObject.FindProperty("m_SolveOrderWeighting");
            m_ReservedMemberWeightProperty = m_SetOrderWeightsProperty.FindPropertyRelative("ReservedMemberWeight");
            m_SharedMemberWeightProperty = m_SetOrderWeightsProperty.FindPropertyRelative("SharedMemberWeight");
            m_RelationWeightProperty = m_SetOrderWeightsProperty.FindPropertyRelative("RelationWeight");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            m_ShowHelp = MarsEditorUtils.HintBox(m_ShowHelp, k_HelpText, "PipelineFenceConfiguration");

            var module = ModuleLoaderCore.instance.GetModule<QueryPipelinesModule>();
            var stageInstances = module?.StandalonePipeline?.Stages;

            m_ShowFrameBudgetsFoldout = EditorGUILayout.Foldout(m_ShowFrameBudgetsFoldout, "Stage Frame Budgets", true);
            if (m_ShowFrameBudgetsFoldout)
            {
                for (var i = 1; i < m_FrameBudgetsProperty.arraySize; i++)
                {
                    var prop = m_FrameBudgetsProperty.GetArrayElementAtIndex(i);
                    var label = stageInstances == null ? i.ToString() : stageInstances[i].Label;
                    EditorGUILayout.PropertyField(prop, new GUIContent(label));
                }
            }

            m_ShowWeightsHelp = MarsEditorUtils.HintBox(m_ShowWeightsHelp, k_SetOrderText, "SetOrderConfiguration");

            m_ShowOrderWeightFoldout = EditorGUILayout.Foldout(m_ShowOrderWeightFoldout, "Set Order Weighting", true);
            if (m_ShowOrderWeightFoldout)
            {
                EditorGUILayout.Slider(m_ReservedMemberWeightProperty,
                    GroupOrderWeights.MinReservedWeight, GroupOrderWeights.MaxReservedWeight);
                EditorGUILayout.Slider(m_SharedMemberWeightProperty,
                    GroupOrderWeights.MinSharedWeight, GroupOrderWeights.MaxSharedWeight);
                EditorGUILayout.Slider(m_RelationWeightProperty,
                    GroupOrderWeights.MinRelationWeight, GroupOrderWeights.MaxRelationWeight);
            }

            m_ShowCurveHelp = MarsEditorUtils.HintBox(m_ShowCurveHelp, k_SearchCurveText, "SearchCurveConfig");
            EditorGUILayout.PropertyField(m_SearchCurveProperty);

            EditorGUILayout.Separator();
            serializedObject.ApplyModifiedProperties();
        }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.MARSUtils;
using UnityEditor;
using UnityEngine;

namespace Unity.MARS
{
    [CustomEditor(typeof(SlowTaskModule))]
    class SlowTaskModuleEditor : Editor
    {
        const string k_TasksFormat = "Tasks ({0})";
        const string k_MarsTimeTasksFormat = "MARS Time Tasks ({0})";

        [SerializeField]
        bool m_ShowTasks;

        [SerializeField]
        bool m_ShowMarsTimeTasks;

        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var module = (SlowTaskModule)target;
            DrawTaskList(module.tasks, k_TasksFormat, ref m_ShowTasks);
            DrawTaskList(module.MarsTimeTasks, k_MarsTimeTasksFormat, ref m_ShowMarsTimeTasks);
        }

        static void DrawTaskList(Dictionary<Action, SlowTaskModule.SlowTask> tasks, string foldoutFormat, ref bool expanded)
        {
            var foldoutLabel = string.Format(foldoutFormat, tasks.Count);
            expanded = EditorGUILayout.Foldout(expanded, foldoutLabel, true);
            if (expanded)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    foreach (var kvp in tasks)
                    {
                        var task = kvp.Value;
                        var label = kvp.Key.Method.Name;
                        var value = $"{task.sleepTime} | {task.lastExecutionTime}";
                        EditorGUILayout.LabelField(label, value);
                    }
                }
            }
        }
    }
}

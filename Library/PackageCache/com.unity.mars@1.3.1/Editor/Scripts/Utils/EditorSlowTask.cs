using System;
using UnityEngine;

namespace UnityEditor.MARS
{
    class EditorSlowTask
    {
        public Action Task;
        public double SleepTime;
        public double LastExecutionTime;

        public EditorSlowTask(Action task, double sleepTime)
        {
            Task = task;
            SleepTime = sleepTime;
            LastExecutionTime = EditorApplication.timeSinceStartup;
        }

        public void Update()
        {
            if (EditorApplication.timeSinceStartup - LastExecutionTime >= SleepTime)
                ExecuteTask();
        }

        public void ExecuteTask()
        {
            Task();
            LastExecutionTime = EditorApplication.timeSinceStartup;
        }
    }
}

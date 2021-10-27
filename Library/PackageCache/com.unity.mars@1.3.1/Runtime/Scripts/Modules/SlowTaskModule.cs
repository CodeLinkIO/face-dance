using System;
using System.Collections.Generic;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.MARSUtils
{
    /// <summary>
    /// Manages tasks that run at regular intervals
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class SlowTaskModule : ScriptableSettings<SlowTaskModule>, IModuleBehaviorCallbacks, IModuleMarsUpdate,
        IProvidesSlowTasks
    {
        // Use an increment slightly longer than frame time to ensure it happens in the next frame
        const float k_OffsetFrameRateMultiplier = 1.1f;

        [SerializeField]
        [Tooltip("The number of tasks to register before incrementing the task start time")]
        int m_IncrementInterval = 8;

        internal class SlowTask
        {
            public Action task;
            public float sleepTime;
            public float lastExecutionTime;

            public void Update(float time)
            {
                if (time - lastExecutionTime >= sleepTime)
                {
                    task();
                    lastExecutionTime = time;
                }
            }
        }

        readonly Dictionary<Action, SlowTask> m_Tasks = new Dictionary<Action, SlowTask>();
        readonly Dictionary<Action, SlowTask> m_MarsTimeTasks = new Dictionary<Action, SlowTask>();

        [NonSerialized]
        int m_TasksRegisteredThisFrame;

        [NonSerialized]
        float m_StartTime;

        [NonSerialized]
        float m_OffsetIncrement;

        [NonSerialized]
        int m_TaskFrameRate;

        [NonSerialized]
        int m_MarsTimeTasksRegisteredThisFrame;

        [NonSerialized]
        float m_MarsTaskTime;

        // These internal properties are just for testing
        internal Dictionary<Action, SlowTask> tasks
        {
            get { return m_Tasks; }
        }

        internal Dictionary<Action, SlowTask> MarsTimeTasks => m_MarsTimeTasks;

        internal int incrementInterval
        {
            get { return m_IncrementInterval; }
        }

        internal int taskFrameRate
        {
            get { return m_TaskFrameRate;}
            set
            {
                m_TaskFrameRate = value;
                m_OffsetIncrement = Mathf.Abs(k_OffsetFrameRateMultiplier / taskFrameRate);
            }
        }

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<SlowTask> k_TempTasks = new List<SlowTask>();

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            m_StartTime = Time.time;
            m_MarsTaskTime = 0f;
            taskFrameRate = Application.targetFrameRate;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            ClearTasks();
        }

        public void ClearTasks()
        {
            m_Tasks.Clear();
            m_MarsTimeTasks.Clear();
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() {}

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable() {}

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() {}

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate()
        {
            m_StartTime = Time.time; // This can be modified during the frame
            m_TasksRegisteredThisFrame = 0;

            k_TempTasks.Clear();
            foreach (var kvp in m_Tasks)
            {
                k_TempTasks.Add(kvp.Value);
            }

            foreach (var task in k_TempTasks)
            {
                task.Update(m_StartTime);
            }
        }

        /// <inheritdoc />
        void IModuleMarsUpdate.OnMarsUpdate()
        {
            m_MarsTaskTime = MarsTime.Time;
            m_MarsTimeTasksRegisteredThisFrame = 0;
            k_TempTasks.Clear();
            foreach (var kvp in m_MarsTimeTasks)
            {
                k_TempTasks.Add(kvp.Value);
            }

            foreach (var task in k_TempTasks)
            {
                task.Update(m_MarsTaskTime);
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable()
        {
            m_MarsTaskTime = 0f;
            m_MarsTimeTasks.Clear();
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() {}

        /// <inheritdoc />
        void IFunctionalityProvider.LoadProvider() {}

        /// <inheritdoc />
        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesSlowTasks>(obj);
        }

        /// <inheritdoc />
        void IFunctionalityProvider.UnloadProvider() {}

        public bool AddSlowTask(Action action, float sleepTime, bool replace = false)
        {
            if (!replace && m_Tasks.ContainsKey(action))
                return false;

            m_TasksRegisteredThisFrame++;
            // Distribute work by making sure we don't pile up every task on the same frames
            if (m_TasksRegisteredThisFrame % m_IncrementInterval == 0)
                m_StartTime += m_OffsetIncrement;

            var newTask = new SlowTask
            {
                task = action,
                sleepTime = sleepTime,
                lastExecutionTime = m_StartTime
            };

            m_Tasks[action] = newTask;
            return true;
        }

        public bool RemoveSlowTask(Action task)
        {
            m_Tasks.Remove(task);
            return true;
        }

        public bool AddMarsTimeSlowTask(Action action, float sleepTime, bool replace = false)
        {
            if (!replace && m_MarsTimeTasks.ContainsKey(action))
                return false;

            m_MarsTimeTasksRegisteredThisFrame++;
            if (m_MarsTimeTasksRegisteredThisFrame % m_IncrementInterval == 0)
                m_MarsTaskTime += m_OffsetIncrement;

            var newTask = new SlowTask
            {
                task = action,
                sleepTime = sleepTime,
                lastExecutionTime = m_MarsTaskTime
            };

            m_MarsTimeTasks[action] = newTask;
            return true;
        }

        public bool RemoveMarsTimeSlowTask(Action task)
        {
            m_MarsTimeTasks.Remove(task);
            return true;
        }

        // this is used by the environment manager to force synchronous query execution
        internal void ForceRunAllTasks()
        {
            var time = Time.time;
            foreach (var kvp in m_Tasks)
            {
                var slowTask = kvp.Value;
                slowTask.task();
                slowTask.lastExecutionTime = time;
            }
        }
    }
}

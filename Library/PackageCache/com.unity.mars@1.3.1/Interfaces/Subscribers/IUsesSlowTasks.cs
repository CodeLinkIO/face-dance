using System;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.MARSUtils
{
    /// <summary>
    /// Provides access to slow task management
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesSlowTasks : IFunctionalitySubscriber<IProvidesSlowTasks>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesSlowTasksMethods
    {
        /// <summary>
        /// Registers the given task and starts it running at regular intervals based on game time
        /// </summary>
        /// <param name="task">The delegate to execute at each interval</param>
        /// <param name="sleepTime">The amount of time to wait between executions</param>
        /// <param name="replace">(Optional) Whether this should replace existing parameters
        /// for <paramref name="task"/> if it has already been registered</param>
        /// <returns>True if the task has not already been added or if <paramref name="replace"/> is true, false otherwise</returns>
        public static bool AddSlowTask(this IUsesSlowTasks obj, Action task, float sleepTime, bool replace = false)
        {
            return obj.provider.AddSlowTask(task, sleepTime, replace);
        }

        /// <summary>
        /// Unregisters the given task and stops running it
        /// </summary>
        /// <param name="task">The task to remove</param>
        /// <returns>True if the task was successfully found and removed, false otherwise</returns>
        public static bool RemoveSlowTask(this IUsesSlowTasks obj, Action task)
        {
            return obj.provider.RemoveSlowTask(task);
        }

        /// <summary>
        /// Registers the given task and starts it running at regular intervals based on MARS time
        /// </summary>
        /// <param name="task">The delegate to execute at each interval</param>
        /// <param name="sleepTime">The amount of time to wait between executions</param>
        /// <param name="replace">(Optional) Whether this should replace existing parameters
        /// for <paramref name="task"/> if it has already been registered</param>
        /// <returns>True if the task has not already been added or if <paramref name="replace"/> is true, false otherwise</returns>
        public static bool AddMarsTimeSlowTask(this IUsesSlowTasks obj, Action task, float sleepTime, bool replace = false)
        {
            return obj.provider.AddMarsTimeSlowTask(task, sleepTime, replace);
        }

        /// <summary>
        /// Unregisters the given MARS-time task and stops running it
        /// </summary>
        /// <param name="task">The task to remove</param>
        /// <returns>True if the task was successfully found and removed, false otherwise</returns>
        public static bool RemoveMarsTimeSlowTask(this IUsesSlowTasks obj, Action task)
        {
            return obj.provider.RemoveMarsTimeSlowTask(task);
        }
    }
}

using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Provides access to point cloud features
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IUsesSessionControl : IFunctionalitySubscriber<IProvidesSessionControl>
    {
    }

    [MovedFrom("Unity.MARS")]
    public static class IUsesSessionControlMethods
    {
        /// <summary>
        /// Check if the session exists, regardless of whether it is running
        /// </summary>
        /// <returns>True if the session exists, false otherwise</returns>
        public static bool SessionExists(this IUsesSessionControl obj)
        {
            return obj.provider.SessionExists();
        }

        /// <summary>
        /// Check if the session is running. If the session does not exist, returns false
        /// </summary>
        /// <returns>True if the session exists and is running, false otherwise</returns>
        public static bool SessionRunning(this IUsesSessionControl obj)
        {
            return obj.provider.SessionRunning();
        }

        /// <summary>
        /// Check if the session is ready
        /// </summary>
        /// <returns>True if the session is ready, false otherwise</returns>
        public static bool SessionReady(this IUsesSessionControl obj)
        {
            return obj.provider.SessionReady();
        }

        /// <summary>
        /// Create a new MR Session. If the session has been created, this does nothing.
        /// </summary>
        public static void CreateSession(this IUsesSessionControl obj)
        {
            obj.provider.CreateSession();
        }

        /// <summary>
        /// Pauses the MR Session. If a session has been paused, this does nothing.
        /// </summary>
        public static void DestroySession(this IUsesSessionControl obj)
        {
            obj.provider.DestroySession();
        }

        /// <summary>
        /// Resets the MR Session. This will trigger removal events
        /// </summary>
        public static void ResetSession(this IUsesSessionControl obj)
        {
            obj.provider.ResetSession();
        }

        /// <summary>
        /// Resumes the MR Session. If a session has not has been paused, this does nothing.
        /// </summary>
        public static void PauseSession(this IUsesSessionControl obj)
        {
            obj.provider.PauseSession();
        }

        /// <summary>
        /// Create a new MR Session. If the session has been created, this does nothing.
        /// </summary>
        public static void ResumeSession(this IUsesSessionControl obj)
        {
            obj.provider.ResumeSession();
        }
    }
}

using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for controlling the MR session (not the MARS Session)
    /// This functionality provider is responsible for starting, stopping, creating, and destroying the MR session,
    /// which on most platforms controls other MR subsystems like camera tracking, plane finding, etc.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesSessionControl : IFunctionalityProvider
    {
        /// <summary>
        /// Check if the session exists, regardless of whether it is running
        /// </summary>
        /// <returns>True if the session exists, false otherwise</returns>
        bool SessionExists();

        /// <summary>
        /// Check if the session is running. If the session does not exist, returns false
        /// </summary>
        /// <returns>True if the session exists and is running, false otherwise</returns>
        bool SessionRunning();

        /// <summary>
        /// Check if the session is ready
        /// </summary>
        /// <returns>True if the session is ready, false otherwise</returns>
        bool SessionReady();

        /// <summary>
        /// Create a new MR Session. If the session has been created, this does nothing.
        /// </summary>
        void CreateSession();

        /// <summary>
        /// Destroy the MR Session. If a session has not has been created, this does nothing.
        /// </summary>
        void DestroySession();

        /// <summary>
        /// Resets the MR Session. This will trigger removal events
        /// for all current data
        /// </summary>
        void ResetSession();

        /// <summary>
        /// Pauses the MR Session. If a session has been paused, this does nothing.
        /// </summary>
        void PauseSession();

        /// <summary>
        /// Resumes the MR Session. If a session has not has been paused, this does nothing.
        /// </summary>
        void ResumeSession();
    }
}

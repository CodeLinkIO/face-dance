using System;

namespace Unity.ContentManager
{
    /// <summary>
    /// Represents the different aspects of the installation lifecycle for a piece of content.
    /// </summary>
    [Flags]
    enum InstallationStatus
    {
        /// The first group contains the raw flags set by the Content Manager module.
        /// The second group contains combination flags for commonly referenced states.
        Unknown = 0,
        Installed = 1,
        InstallQueued = 2,
        UninstallRequested = 4,
        Locked = 8,
        DifferentVersion = 16,

        Installing = InstallQueued | Locked,
        UpdateAvailable = Installed | DifferentVersion,
        UpdateQueued = UpdateAvailable | InstallQueued,
        Updating = UpdateAvailable | Locked,
        UninstallQueued = Installed | UninstallRequested,
        Uninstalling = Installed | UninstallQueued | Locked
    }
}

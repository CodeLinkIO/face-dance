namespace Unity.ContentManager
{
    /// <summary>
    /// Represents a type of Package Manager operation that can be queued in the Content Manager.
    /// </summary>
    enum PackageAction
    {
        /// <summary> Gets the list of installed packages in the project and available packages in the registry. /// </summary>
        Status = 0,
        /// <summary> Installs a package into the project. /// </summary>
        Add,
        /// <summary> Uninstalls a package from the project. /// </summary>
        Remove,
        /// <summary> Makes an installed package writeable. /// </summary>
        Embed,
        /// <summary> Installs the first sample located in the package. /// </summary>
        SampleInstall
    }
}

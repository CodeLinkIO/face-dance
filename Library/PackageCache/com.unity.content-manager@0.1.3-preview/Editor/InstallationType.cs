namespace Unity.ContentManager
{
    /// <summary>
    /// Describes where and how a piece of content can be installed.
    /// </summary>
    enum InstallationType
    {
        /// <summary> Installs like a typical Unity package. </summary>
        Package = 0,
        /// <summary> Installs like a typical Unity package and becomes embedded in your project. </summary>
        WriteablePackage = 1,
        /// <summary> IInstalls like a typical Unity package and also installs the first sample found in the package.json file. </summary>
        UnityPackage = 2
    }
}

using System;
using UnityEngine;

namespace Unity.ContentManager
{
    /// <summary>
    /// Represents one piece of content that can be installed via the Content Manager.
    /// </summary>
    [CreateAssetMenu(menuName = "Content Manager/Content Pack")]
    class ContentPack : ScriptableObject
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("The plain language name of the Content Pack.")]
        string m_DisplayName;

        [SerializeField]
        [Tooltip("The package identifier the Content Pack uses in Package Manager.")]
        string m_PackageName;

        [SerializeField]
        [Tooltip("The path used by Package Manager to download the Content Pack.")]
        string m_Url;

        [SerializeField]
        [Tooltip("Where and how this piece of content is installed.")]
        InstallationType m_InstallType;

        [SerializeField]
        [TextArea]
        [Tooltip("A description of what the Content Pack contains for users.")]
        string m_Description;

        [SerializeField]
        [Tooltip("A comma-delimited field of different category tags for sorting and filtering.")]
        string m_Category;

        [SerializeField]
        [Tooltip("A custom label to use if this content pack contains preview packages.")]
        string m_PreviewLabel;

        [SerializeField]
        [Tooltip("Image used as a thumbnail and header when viewing details about the Content Pack.")]
        Texture2D m_PreviewImage;

        [SerializeField]
        [Tooltip("The version of the package installed by this Content Pack.")]
        string m_Version;

        [SerializeField]
        [Tooltip("The date this Content Pack was initially created.")]
        SerializedDate m_Created;

        [SerializeField]
        [Tooltip("The date this Content Pack was last updated.")]
        SerializedDate m_Updated;

#pragma warning restore 649

        public string DisplayName => m_DisplayName;
        public string PackageName => m_PackageName;
        public string Url => m_Url;
        public InstallationType InstallType => m_InstallType;
        public string Description => m_Description;
        public string Category => m_Category;
        public string PreviewLabel
        {
            get
            {
                return string.IsNullOrWhiteSpace(m_PreviewLabel) ? "Preview" : m_PreviewLabel;
            }
        }

        public Texture2D PreviewImage => m_PreviewImage;
        public string Version => m_Version;
        public DateTime Created => m_Created.ToDateTime;
        public DateTime Updated => m_Updated.ToDateTime;

        /// <summary>
        /// Non-serialized status value. The Content Manager updates this during editor usage.
        /// </summary>
        public InstallationStatus InstallStatus { get; set; }

        /// <summary>
        /// Non-serialized version value. The Content Manager uses this to install specific package versions.
        /// </summary>
        public string AutoVersion { get; set; }

        /// <summary>
        /// Non-serialized value. The Content Manager uses this to filter packages based on Content Product.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Non-serialized flag. True if the content pack refers to a package version in the Unity registry that is preview.
        /// </summary>
        public bool Preview { get { return Version.ToLower().Contains("preview"); } }
    }
}

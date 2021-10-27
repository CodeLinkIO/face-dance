using UnityEngine;

namespace Unity.ContentManager
{
    /// <summary>
    /// A named string filter used for limiting what entries are viewed in the Content Manager.
    /// </summary>
    [System.Serializable]
    class CategoryFilter
    {
        public static readonly CategoryFilter AllEntries = new CategoryFilter { m_Name = "All", m_Filter = "" };

        [SerializeField]
        [Tooltip("The name that will appear for this category entry in the Content Manager")]
        string m_Name;

        [SerializeField]
        [Tooltip("The filter used when selecting this category entry for available content packs")]
        string m_Filter;

        public string Name => m_Name;
        public string Filter => m_Filter;
    }
}

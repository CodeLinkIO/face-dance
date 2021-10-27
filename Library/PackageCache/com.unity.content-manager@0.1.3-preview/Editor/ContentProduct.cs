using System.Collections.Generic;
using UnityEngine;

namespace Unity.ContentManager
{
    /// <summary>
    /// Represents one piece of content that can be installed via the Content Manager.
    /// </summary>
    [CreateAssetMenu(menuName = "Content Manager/Content Product")]
    public class ContentProduct : ScriptableObject
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Icon to show next to the product name.")]
        Texture2D m_Icon;

        [SerializeField]
        [Tooltip("The plain language name of the product.")]
        string m_DisplayName;

        [SerializeField]
        [Tooltip("A subtitle of the product.")]
        string m_Description;

        [SerializeField]
        [Tooltip("The path where this product searches for content packs.")]
        string m_SearchPath;

        [SerializeField]
        [Tooltip("True if this product displays in the Content Manager.")]
        bool m_Visible = true;

        [SerializeField]
        [Tooltip("All categories associated with this set of content.")]
        List<CategoryFilter> m_Categories = new List<CategoryFilter>();
#pragma warning restore 649

        internal Texture2D Icon => m_Icon;
        internal string DisplayName => m_DisplayName;
        internal string Description => m_Description;
        internal string SearchPath => m_SearchPath;
        internal bool Visible => m_Visible;
        internal List<CategoryFilter> Categories => m_Categories;
    }
}

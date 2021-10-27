using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Unity.ContentManager
{
    /// <summary>
    /// Shows details about Unity MARS Content Packs that can be installed or updated.
    /// </summary>
    public class ContentManagerWindow : EditorWindow
    {
        const string k_ContentManagerWindowName = "Content Manager";
        const string k_ContentManagerMenuName = "Window/Content Manager";
        const int k_ContentManagerMenuPriority = 1500;

        ContentManagerDriver m_ContentManagerDriver;
        ContentDrawer m_Drawer = new ContentDrawer();
        readonly List<ContentProduct> m_Products = new List<ContentProduct>();
        readonly List<CategoryFilter> m_Categories = new List<CategoryFilter>();
        readonly List<ContentPack> m_FilteredPacks = new List<ContentPack>();

        [SerializeField]
        ContentProduct m_ActiveProduct;

        [SerializeField]
        CategoryFilter m_ActiveFilter;

        [SerializeField]
        ContentPack m_ActivePack;

        [MenuItem(k_ContentManagerMenuName, priority = k_ContentManagerMenuPriority)]
        static void Init()
        {
            var win = GetWindow<ContentManagerWindow>();
            win.titleContent = new GUIContent(k_ContentManagerWindowName);
        }

        /// <summary>
        /// Opens the Content Manager window or focuses it on a specific Content Product.
        /// </summary>
        /// <param name="startingProduct">The product to start the Content Manager focused on</param>
        public static void OpenWithWithProduct(ContentProduct startingProduct)
        {
            var win = GetWindow<ContentManagerWindow>();
            win.titleContent = new GUIContent(k_ContentManagerWindowName);

            if (startingProduct != null)
            {
                if (win.m_ContentManagerDriver != null)
                    win.OnContentProductChanged(startingProduct);
                else
                    win.m_ActiveProduct = startingProduct;
            }
        }

        void OnEnable()
        {
            if (m_ContentManagerDriver != null)
                return;

            m_ContentManagerDriver = ContentManagerDriver.Instance;

            if (m_ContentManagerDriver != null)
                OnDriverReady();
        }

        void OnDisable()
        {
            if (m_ContentManagerDriver != null)
            {
                ContentManagerDriver.UnsubscribeStatusCallback(OnContentPacksLoaded);
                ContentManagerDriver.UnsubscribeChangeCallback(m_Drawer.RefreshContentView);
            }

            m_Drawer?.Deinit();

            m_ContentManagerDriver = null;
        }

        void OnDriverReady()
        {
            // Act as a middle-man, hooking up update events from the driver to the UI drawer
            ContentManagerDriver.SubscribeStatusCallback(OnContentPacksLoaded);
            ContentManagerDriver.SubscribeChangeCallback(m_Drawer.RefreshContentView);

            // Likewise, ensure any buttons drawn by the Content Manager window send messages to the driver
            m_Drawer.Init(rootVisualElement, OnContentWindowSizeChanged, OnContentProductChanged, OnContentFilterChanged, ContentManagerDriver.InstallContent, ContentManagerDriver.InstallContent, ContentManagerDriver.UninstallContent, ContentManagerDriver.CancelContentAction, OnContentSelect, m_ActivePack, m_ActiveFilter, m_ActiveProduct);

            ContentManagerDriver.UpdateContentStatus();
        }

        void OnContentPacksLoaded(bool success, string message)
        {
            if (success)
            {
                UpdateFilteredProducts();
                UpdateFilteredPacks();
            }
        }

        void OnContentWindowSizeChanged(Vector2 newWindowSize)
        {
            minSize = newWindowSize;
        }

        void OnContentProductChanged(ContentProduct target)
        {
            m_ActiveProduct = target;
            m_Categories.Clear();

            if (m_ActiveProduct != null)
            {
                m_Categories.Add(CategoryFilter.AllEntries);
                m_Categories.AddRange(target.Categories);
            }

            m_Drawer.SetCategoryList(m_Categories);
        }

        void OnContentFilterChanged(CategoryFilter filter)
        {
            if (m_ContentManagerDriver == null)
                return;

            m_ActiveFilter = filter;

            UpdateFilteredPacks();
        }

        void OnContentSelect(ContentPack selectedPack)
        {
            m_ActivePack = selectedPack;
        }

        void UpdateFilteredProducts()
        {
            var visibleProducts = ContentManagerDriver.AvailableContentProducts.Where(product => product.Visible);
            if (m_ActiveProduct == null)
            {
                m_ActiveProduct = visibleProducts.FirstOrDefault();

                if (m_ActiveProduct == null)
                    m_ActiveProduct = ContentManagerDriver.AvailableContentProducts.FirstOrDefault();

                if (m_ActiveProduct != null)
                    m_Drawer.SetProduct(m_ActiveProduct);
            }

            m_Products.Clear();
            m_Products.AddRange(visibleProducts);
            m_Drawer.SetProductList(m_Products);
        }

        void UpdateFilteredPacks()
        {
            // First filter down by search path
            // Then filter down by category -or- show all packs if no filter is selected
            if (m_ActiveProduct == null || string.IsNullOrEmpty(m_ActiveProduct.SearchPath))
                return;
            var searchPath = m_ActiveProduct.SearchPath.ToLower();
            m_FilteredPacks.Clear();
            m_FilteredPacks.AddRange(ContentManagerDriver.AvailableContentPacks.Where(pack => pack.Path.StartsWith(searchPath) &&
                (m_ActiveFilter == null || string.IsNullOrEmpty(m_ActiveFilter.Filter) || m_ActiveFilter.Filter.Contains(pack.Category)))
            );
            m_Drawer.SetContentPackList(m_FilteredPacks);
        }
    }
}

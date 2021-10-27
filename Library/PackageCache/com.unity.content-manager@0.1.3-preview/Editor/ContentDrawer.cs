using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.IMGUI.Controls;
using System;

namespace Unity.ContentManager
{
    /// <summary>
    /// Handles the drawing and UI interactions of the Content Manager window.
    /// </summary>
    class ContentDrawer
    {
        // File lookup constants
        const string k_Directory = "Packages/com.unity.content-manager/Editor/Design/";
        const string k_WindowXMLPath = k_Directory + "ContentManager.uxml";
        const string k_WindowStylePath = k_Directory + "ContentManager.uss";
        const string k_DarkThemeStylePath = k_Directory + "ContentManagerDarkTheme.uss";
        const string k_LightThemeStylePath = k_Directory + "ContentManagerLightTheme.uss";

        const string k_CategoryXMLPath = k_Directory + "ContentManagerCategory.uxml";
        const string k_EntryXMLPath = k_Directory + "ContentManagerEntry.uxml";

        // IDs and classes for selection and state change
        const string k_WindowCanvasID = "WindowCanvas";
        const string k_SelectedClass = "selected";
        const string k_DisabledClass = "disabled";
        const string k_DownloadedClass = "downloaded";
        const string k_UpdateClass = "update-available";
        const string k_PendingClass = "in-progress";

        const string k_ProductEntryID = "ProductEntry";
        const string k_ProductIconID = "ProductIcon";
        const string k_ProductNameID = "ProductName";
        const string k_ProductDescriptionID = "ProductDescription";

        const string k_CategoryListID = "CategoryList";
        const string k_CategoryClass = "category";
        const string k_CategoryLabelClass = "category-label";

        const string k_EntryListID = "ContentList";
        const string k_EntryWrapperID = "ContentListWrapper";
        const string k_EntryClass = "content-entry";
        const string k_EntryThumbnailClass = "content-entry-thumbnail";
        const string k_EntryLabelClass = "content-entry-label";
        const string k_EntryCatClass = "content-entry-cat";
        const string k_EntryDownloadIndicator = "loading-spinner";

        const string k_ContentImageID = "ContentImage";

        const string k_DescriptionNameID = "DescriptionName";
        const string k_DescriptionPackageID = "DescriptionPackage";
        const string k_DescriptionDateID = "DescriptionDate";
        const string k_DescriptionTextID = "DescriptionText";
        const string k_DescriptionLocationID = "DescriptionLocation";
        const string k_DescriptionStatusID = "DescriptionStatus";
        const string k_DescriptionHeadingID = "DescriptionHeading";

        const string k_InstallButtonID = "InstallButton";
        const string k_UpdateButtonID = "UpdateButton";
        const string k_UninstallButtonID = "UninstallButton";
        const string k_CancelButtonID = "CancelButton";

        const string k_UpdatedString = "Last Updated: ";

        const float k_LoadingRotationSpeed = 360.0f;

        static ProductDropDown s_ProductDropDown;

        // Actions called by the hub window or driver
        Action<Vector2> m_WindowResize;
        Action<ContentProduct> m_ApplyProductFilter;
        Action<CategoryFilter> m_ApplyContentFilter;
        Action<ContentPack> m_InstallContentPack;
        Action<ContentPack> m_UpdateContentPack;
        Action<ContentPack> m_UninstallContentPack;
        Action<ContentPack> m_CancelContentPack;
        Action<ContentPack> m_SelectContentPack;

        // Assets used for cloning or modification
        VisualElement m_RootVisualElement;
        VisualTreeAsset m_CategoryTemplate;
        VisualTreeAsset m_EntryTemplate;

        VisualElement m_ProductIcon;
        Label m_ProductName;
        Label m_ProductDescription;

        ScrollView m_CategoryListView;
        VisualElement m_LastCategoryElement;

        VisualElement m_EntryListView;
        VisualElement m_LastEntryElement;

        VisualElement m_ContentImage;

        Label m_DescriptionName;
        Label m_DescriptionPackage;
        Label m_DescriptionDate;
        Label m_DescriptionText;
        Label m_DescriptionLocation;
        Label m_DescriptionStatus;
        Label m_DescriptionHeading;

        VisualElement m_InstallButton;
        VisualElement m_UpdateButton;
        VisualElement m_UninstallButton;
        VisualElement m_CancelButton;

        List<CategoryFilter> m_CategoryEntries = new List<CategoryFilter>();
        List<ContentPack> m_ContentPacks = new List<ContentPack>();
        ContentProduct m_SelectedProduct;
        ContentPack m_SelectedPack;
        CategoryFilter m_SelectedFilter;

        List<ITransform> m_LoadingSpinners = new List<ITransform>();

        /// <summary>
        /// Used to start drawing the Content Manager window.
        /// </summary>
        /// <param name="ve">The root element that all UI will be placed inside</param>
        /// <param name="onWindowSize">Action to call when the window is resized</param>
        /// <param name="onProductFilter">Action to call when a product is selected</param>
        /// <param name="onContentFilter">Action to call when a category button is activated</param>
        /// <param name="onContentInstall">Action to call when the install button is activated for a piece of content</param>
        /// <param name="onContentUpdate">Action to call when the update button is activated for a piece of content</param>
        /// <param name="onContentUninstall">Action to call when the uninstall button is activated</param>
        /// <param name="onContentCancel">Action to call when the cancel button is activated</param>
        /// <param name="onContentSelect">Action to call when content is selected</param>
        /// <param name="defaultPack">An optional content pack to start focused on</param>
        /// <param name="defaultFilter">An optional category to start focused on</param>
        /// <param name="defaultProduct">An optional product to start focused on</param>
        public void Init(VisualElement ve, Action<Vector2> onWindowSize, Action<ContentProduct> onProductFilter,
            Action<CategoryFilter> onContentFilter, Action<ContentPack> onContentInstall,
            Action<ContentPack> onContentUpdate, Action<ContentPack> onContentUninstall,
            Action<ContentPack> onContentCancel, Action<ContentPack> onContentSelect, ContentPack defaultPack = null,
            CategoryFilter defaultFilter = null, ContentProduct defaultProduct = null)
        {
            if (s_ProductDropDown == null)
                s_ProductDropDown = new ProductDropDown(new AdvancedDropdownState());

            s_ProductDropDown.OnSelect = SetProductFull;

            m_RootVisualElement = ve;

            m_WindowResize = onWindowSize;
            m_ApplyProductFilter = onProductFilter;
            m_ApplyContentFilter = onContentFilter;
            m_InstallContentPack = onContentInstall;
            m_UpdateContentPack = onContentUpdate;
            m_UninstallContentPack = onContentUninstall;
            m_CancelContentPack = onContentCancel;
            m_SelectContentPack = onContentSelect;

            m_SelectedPack = defaultPack;
            m_SelectedFilter = defaultFilter;
            m_SelectedProduct = defaultProduct;

            SetupUI();

            EditorApplication.update += UpdateSpinners;
        }

        /// <summary>
        /// Used to shut down any drawing processes for the Content Manager window.
        /// </summary>
        public void Deinit()
        {
            EditorApplication.update -= UpdateSpinners;
        }

        /// <summary>
        /// Makes the drawn content window show a specific list of products.
        /// </summary>
        /// <param name="products">The products to list in the selector</param>
        public void SetProductList(List<ContentProduct> products)
        {
            s_ProductDropDown.ProductsToDisplay = products;
        }

        /// <summary>
        /// Sets the active product to be focused in the Content Manager window.
        /// </summary>
        /// <param name="target">The product to show content and filter against</param>
        public void SetProduct(ContentProduct target)
        {
            m_SelectedProduct = target;
            if (target != null)
            {
                m_ProductIcon.style.backgroundImage = target.Icon;
                m_ProductName.text = target.DisplayName;
                m_ProductDescription.text = target.Description;
            }

            UpdateProductList();
        }

        /// <summary>
        /// Sets the active product and resets the selected Content Pack and filter.
        /// </summary>
        /// <param name="target"></param>
        void SetProductFull(ContentProduct target)
        {
            if (target != m_SelectedProduct)
            {
                m_SelectedPack = null;
                m_SelectedFilter = null;
                m_LastCategoryElement = null;
            }

            SetProduct(target);
        }

        /// <summary>
        /// Makes the drawn content window show a specific list of categories.
        /// </summary>
        /// <param name="categories">The categories to list in the sidebar</param>
        public void SetCategoryList(List<CategoryFilter> categories)
        {
            m_CategoryEntries = categories;
            UpdateCategoryList();
        }

        /// <summary>
        /// Makes the drawn content window show a specific set of Content Packs.
        /// </summary>
        /// <param name="contentPacks">The content packs</param>
        public void SetContentPackList(List<ContentPack> contentPacks)
        {
            m_ContentPacks = contentPacks;
            UpdateContentList();
            UpdateContentDetail();
        }

        /// <summary>
        /// Triggers a full visual refresh of the window.
        /// </summary>
        public void RefreshContentView()
        {
            UpdateCategoryList();
            UpdateContentList();
            UpdateContentDetail();
        }

        void UpdateSpinners()
        {
            // We need to handle all the loading spinners in this menu - there is not a great pure USS way to handle this yet
            if (m_LoadingSpinners.Count == 0)
                return;

            // Calculate the rotation for the loading spinner
            var localRotationTime = (float)(EditorApplication.timeSinceStartup % 1.0);
            var spinnerAngle = localRotationTime * k_LoadingRotationSpeed;
            var rotation = Quaternion.Euler(0.0f, 0.0f, spinnerAngle);

            // All USS elements are centered at the upper-left corner,
            // We need to calculate counter-position to center the object properly
            spinnerAngle *= Mathf.Deg2Rad;
            var offset = new Vector2(-8.0f, -8.0f);
            var angleValues = new Vector2(Mathf.Cos(-spinnerAngle), Mathf.Sin(-spinnerAngle));
            var rotatedPoint = new Vector3(offset.x * angleValues.x + offset.y * angleValues.y - offset.x,
                -offset.x * angleValues.y + offset.y * angleValues.x - offset.y, 0.0f);

            foreach (var currentTransform in m_LoadingSpinners)
            {
                currentTransform.position = rotatedPoint;
                currentTransform.rotation = rotation;
            }
        }

        void SetupUI()
        {
            // Hook up the main UI
            var windowXml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_WindowXMLPath);
            windowXml.CloneTree(m_RootVisualElement);

            // Load the main style sheet and theme-based style sheet
            var windowStyle = AssetDatabase.LoadAssetAtPath<StyleSheet>(k_WindowStylePath);
            var themePath = EditorGUIUtility.isProSkin ? k_DarkThemeStylePath : k_LightThemeStylePath;
            var themeStyle = AssetDatabase.LoadAssetAtPath<StyleSheet>(themePath);
            m_RootVisualElement.styleSheets.Add(windowStyle);
            m_RootVisualElement.styleSheets.Add(themeStyle);

            // Hook up to the window canvas to control the editor window size
            var windowCanvas = m_RootVisualElement.Q(k_WindowCanvasID);
            windowCanvas.RegisterCallback<GeometryChangedEvent>(UpdateMinimumSize);

            // Hook up to the product list view to add product entries
            var productEntry = m_RootVisualElement.Q(k_ProductEntryID);
            productEntry.RegisterCallback<PointerDownEvent>(ProductEntryClicked);

            m_ProductIcon = m_RootVisualElement.Q<VisualElement>(k_ProductIconID);
            m_ProductName = m_RootVisualElement.Q<Label>(k_ProductNameID);
            m_ProductDescription = m_RootVisualElement.Q<Label>(k_ProductDescriptionID);

            // Hook up to the content detail pane
            m_ContentImage = m_RootVisualElement.Q(k_ContentImageID);

            m_DescriptionName = m_RootVisualElement.Q<Label>(k_DescriptionNameID);
            m_DescriptionPackage = m_RootVisualElement.Q<Label>(k_DescriptionPackageID);
            m_DescriptionDate = m_RootVisualElement.Q<Label>(k_DescriptionDateID);
            m_DescriptionText = m_RootVisualElement.Q<Label>(k_DescriptionTextID);
            m_DescriptionLocation = m_RootVisualElement.Q<Label>(k_DescriptionLocationID);
            m_DescriptionStatus = m_RootVisualElement.Q<Label>(k_DescriptionStatusID);
            m_DescriptionHeading = m_RootVisualElement.Q<Label>(k_DescriptionHeadingID);

            // Set up consistent actions for any of the content installation/configuration buttons
            m_InstallButton = m_RootVisualElement.Q(k_InstallButtonID);
            if (m_InstallButton != null)
            {
                if (m_InstallButton is Button asButton)
                    asButton.clicked += ContentInstallButtonClicked;
                else
                    m_InstallButton.RegisterCallback<PointerDownEvent>(ContentInstallClicked);
            }

            m_UpdateButton = m_RootVisualElement.Q(k_UpdateButtonID);
            if (m_UpdateButton != null)
            {
                if (m_UpdateButton is Button asButton)
                    asButton.clicked += ContentUpdateButtonClicked;
                else
                    m_UpdateButton.RegisterCallback<PointerDownEvent>(ContentUpdateClicked);
            }

            m_UninstallButton = m_RootVisualElement.Q(k_UninstallButtonID);
            if (m_UninstallButton != null)
            {
                if (m_UninstallButton is Button asButton)
                    asButton.clicked += ContentUninstallButtonClicked;
                else
                    m_UninstallButton.RegisterCallback<PointerDownEvent>(ContentUninstallClicked);
            }

            m_CancelButton = m_RootVisualElement.Q(k_CancelButtonID);
            if (m_CancelButton != null)
            {
                if (m_CancelButton is Button asButton)
                    asButton.clicked += ContentCancelButtonClicked;
                else
                    m_CancelButton?.RegisterCallback<PointerDownEvent>(ContentCancelClicked);
            }

            // Hook up to the category list view to add category entries
            m_CategoryEntries.Clear();
            m_CategoryTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_CategoryXMLPath);
            m_CategoryListView = m_RootVisualElement.Q<ScrollView>(k_CategoryListID);

            UpdateProductList();

            if (m_SelectedProduct != null)
                SetProduct(m_SelectedProduct);

            // Hook up to the entry list view to add content pack entries
            m_EntryTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(k_EntryXMLPath);
            var entryScrollView = m_RootVisualElement.Q<ScrollView>(k_EntryListID);
            if (entryScrollView != null)
            {
                m_EntryListView = entryScrollView.Q(k_EntryWrapperID);
                if (m_EntryListView != null)
                    UpdateContentList();
            }

            UpdateContentDetail();
        }

        void UpdateMinimumSize(GeometryChangedEvent evt)
        {
            if (evt.target is VisualElement windowCanvas && m_WindowResize != null)
            {
                var windowStyle = windowCanvas.resolvedStyle;
                m_WindowResize(new Vector2(windowStyle.minWidth.value, windowStyle.minHeight.value));
            }
        }

        void UpdateProductList()
        {
            // Reselect the last element so that it continues to be highlighted in the window
            m_ApplyProductFilter?.Invoke(m_SelectedProduct);

        }

        void UpdateCategoryList()
        {
            if (m_CategoryListView == null)
                return;

            // Rebuild the category list
            m_CategoryListView.Clear();
            foreach (var category in m_CategoryEntries)
            {
                var element = m_CategoryTemplate.CloneTree().Q(className: k_CategoryClass);
                var categoryLabel = element.Q<Label>(className: k_CategoryLabelClass);
                element.userData = category;
                categoryLabel.text = category.Name;

                element.RegisterCallback<PointerDownEvent>(CategoryButtonClicked);
                m_CategoryListView.Add(element);
                element.AddToClassList(category.Name);

                if (m_LastCategoryElement == null || m_SelectedFilter != null && m_SelectedFilter == category)
                    m_LastCategoryElement = element;
            }

            // Reselect the last element so that it continues to be highlighted in the window
            if (m_LastCategoryElement != null)
            {
                m_LastCategoryElement.AddToClassList(k_SelectedClass);
                m_SelectedFilter = m_LastCategoryElement.userData as CategoryFilter;
                m_ApplyContentFilter?.Invoke(m_SelectedFilter);
            }
        }

        void CategoryButtonClicked(PointerDownEvent evt)
        {
            var clicked = evt.currentTarget as VisualElement;
            if (clicked == m_LastCategoryElement)
                return;

            m_LastCategoryElement?.RemoveFromClassList(k_SelectedClass);

            if (clicked == null)
                return;

            clicked.AddToClassList(k_SelectedClass);
            m_LastCategoryElement = clicked;
            m_SelectedFilter = clicked.userData as CategoryFilter;
            m_ApplyContentFilter?.Invoke(m_SelectedFilter);
        }

        void UpdateContentList()
        {
            if (m_EntryListView == null)
                return;

            m_LoadingSpinners.Clear();
            m_EntryListView.Clear();

            if (m_SelectedPack == null && m_ContentPacks.Count > 0)
            {
                m_SelectedPack = m_ContentPacks[0];
                UpdateContentDetail();
            }

            // Create a selection button for each piece of visible content
            // Update the data inside
            // Configure actions to highlight a clicked piece of content in the detail pane
            foreach (var currentContent in m_ContentPacks)
            {
                var element = m_EntryTemplate.CloneTree().Q(className: k_EntryClass);
                var elementThumbnail = element.Q<VisualElement>(className: k_EntryThumbnailClass);
                var elementLabel = element.Q<Label>(className: k_EntryLabelClass);
                var elementCat = element.Q<Label>(className: k_EntryCatClass);

                element.userData = currentContent;
                elementLabel.text = DisplayNameString(currentContent);

                elementCat.text = char.ToUpper(currentContent.Category[0]) + currentContent.Category.Substring(1);
                element.RegisterCallback<PointerDownEvent>(ContentPackButtonClicked);

                if (currentContent.InstallStatus.HasFlag(InstallationStatus.Installed))
                    element.AddToClassList(k_DownloadedClass);
                else
                    element.RemoveFromClassList(k_DownloadedClass);

                if (currentContent.InstallStatus.HasFlag(InstallationStatus.UpdateAvailable))
                    element.AddToClassList(k_UpdateClass);
                else
                    element.RemoveFromClassList(k_UpdateClass);

                if (currentContent.InstallStatus.HasFlag(InstallationStatus.Locked) | currentContent.InstallStatus.HasFlag(InstallationStatus.InstallQueued) | currentContent.InstallStatus.HasFlag(InstallationStatus.UninstallQueued))
                {
                    element.AddToClassList(k_PendingClass);
                    var elementIndicator = element.Q<VisualElement>(className: k_EntryDownloadIndicator);
                    m_LoadingSpinners.Add(elementIndicator.transform);
                }
                else
                    element.RemoveFromClassList(k_PendingClass);

                if (m_SelectedPack != null && currentContent == m_SelectedPack)
                {
                    m_LastEntryElement = element;
                    element.AddToClassList(k_SelectedClass);
                }

                var elementThumbnailStyle = elementThumbnail.style;
                elementThumbnailStyle.backgroundImage = currentContent.PreviewImage;

                m_EntryListView.Add(element);
            }
        }

        void ContentPackButtonClicked(PointerDownEvent evt)
        {
            var clicked = evt.currentTarget as VisualElement;
            if (clicked == m_LastEntryElement)
                return;

            m_LastEntryElement?.RemoveFromClassList(k_SelectedClass);

            if (clicked == null)
                return;

            clicked.AddToClassList(k_SelectedClass);
            m_LastEntryElement = clicked;
            m_SelectedPack = clicked.userData as ContentPack;
            UpdateContentDetail();
        }

        void UpdateContentDetail()
        {
            m_SelectContentPack(m_SelectedPack);
            if (m_SelectedPack != null)
            {
                m_ContentImage.style.backgroundImage = m_SelectedPack.PreviewImage;

                m_DescriptionName.text = DisplayNameString(m_SelectedPack);
                m_DescriptionPackage.text = m_SelectedPack.PackageName;
                m_DescriptionDate.text = $"{k_UpdatedString}{m_SelectedPack.Updated.ToShortDateString()}";
                m_DescriptionText.text = m_SelectedPack.Description;

                EnableElement(m_DescriptionHeading, true);

                m_DescriptionLocation.text = DisplayInstallTypeString(m_SelectedPack.InstallType);

                m_DescriptionStatus.text = DisplayInstallStatusString(m_SelectedPack.InstallStatus);

                // Use different combinations of status to enable different content action buttons
                EnableElement(m_InstallButton, m_SelectedPack.InstallStatus == InstallationStatus.Unknown);
                EnableElement(m_UpdateButton, (m_SelectedPack.InstallStatus & InstallationStatus.Installed) != 0 && (m_SelectedPack.InstallStatus & InstallationStatus.DifferentVersion) != 0 &&
                    (m_SelectedPack.InstallStatus & (InstallationStatus.InstallQueued | InstallationStatus.UninstallRequested | InstallationStatus.Locked)) == 0);

                EnableElement(m_UninstallButton, (m_SelectedPack.InstallStatus & InstallationStatus.Installed) != 0 &&
                    (m_SelectedPack.InstallStatus & (InstallationStatus.InstallQueued | InstallationStatus.UninstallRequested | InstallationStatus.Locked)) == 0);

                EnableElement(m_CancelButton, (m_SelectedPack.InstallStatus & (InstallationStatus.InstallQueued | InstallationStatus.UninstallRequested)) != 0 &&
                    (m_SelectedPack.InstallStatus & InstallationStatus.Locked) == 0);
            }
            else
            {
                m_ContentImage.style.backgroundImage = null;
                m_DescriptionName.text = "";
                m_DescriptionPackage.text = "";
                m_DescriptionDate.text = "";
                m_DescriptionText.text = "";
                m_DescriptionLocation.text = "";
                m_DescriptionStatus.text = "";

                EnableElement(m_DescriptionHeading, false);
                EnableElement(m_InstallButton, false);
                EnableElement(m_UpdateButton, false);
                EnableElement(m_UninstallButton, false);
                EnableElement(m_CancelButton, false);
            }
        }

        static void ProductEntryClicked(PointerDownEvent evt)
        {
            if (GUI.skin == null)
                return;

            s_ProductDropDown.Show(new Rect(evt.position, Vector2.zero));
        }

        void ContentInstallButtonClicked()
        {
            if (m_SelectedPack == null || m_InstallContentPack == null)
                return;

            m_InstallContentPack(m_SelectedPack);
            UpdateContentDetail();
        }
        void ContentInstallClicked(PointerDownEvent evt)
        {
            ContentInstallButtonClicked();
        }

        void ContentUpdateButtonClicked()
        {
            if (m_SelectedPack == null || m_UpdateContentPack == null)
                return;

            m_UpdateContentPack(m_SelectedPack);
            UpdateContentDetail();
        }
        void ContentUpdateClicked(PointerDownEvent evt)
        {
            ContentUpdateButtonClicked();
        }

        void ContentUninstallButtonClicked()
        {
            if (m_SelectedPack == null || m_UninstallContentPack == null)
                return;

            m_UninstallContentPack(m_SelectedPack);
            UpdateContentDetail();
        }

        void ContentUninstallClicked(PointerDownEvent evt)
        {
            ContentUninstallButtonClicked();
        }

        void ContentCancelButtonClicked()
        {
            if (m_SelectedPack == null || m_CancelContentPack == null)
                return;

            m_CancelContentPack(m_SelectedPack);
            UpdateContentDetail();
        }
        void ContentCancelClicked(PointerDownEvent evt)
        {
            ContentCancelButtonClicked();
        }

        static void EnableElement(VisualElement target, bool enabled)
        {
            if (enabled)
                target.RemoveFromClassList(k_DisabledClass);
            else
                target.AddToClassList(k_DisabledClass);
        }

        static string DisplayNameString(ContentPack targetContent)
        {
            return targetContent.Preview ? $"{targetContent.DisplayName} ({targetContent.PreviewLabel})" : targetContent.DisplayName;
        }

        static string DisplayInstallTypeString(InstallationType installType)
        {
            switch (installType)
            {
                case InstallationType.Package:
                    return "Installs to packages";
                case InstallationType.WriteablePackage:
                    return "Installs to packages (writeable)";
                case InstallationType.UnityPackage:
                    return "Installs to project";
            }

            return "";
        }

        static string DisplayInstallStatusString(InstallationStatus installStatus)
        {
            switch (installStatus)
            {
                case InstallationStatus.Unknown:
                    return "";
                case InstallationStatus.Installed:
                    return "";
                case InstallationStatus.InstallQueued:
                    return "Install queued";
                case InstallationStatus.Installing:
                    return "Installing...";
                case InstallationStatus.UpdateAvailable:
                    return "";
                case InstallationStatus.UpdateQueued:
                    return "Update Queued";
                case InstallationStatus.Updating:
                    return "Updating...";
                case InstallationStatus.UninstallQueued:
                    return "Uninstall Queued";
                case InstallationStatus.Uninstalling:
                    return "Uninstalling...";
            }

            return "";
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;

namespace Unity.ContentManager
{
    class ProductDropDown : AdvancedDropdown
    {
        class ProductDropdownItem : AdvancedDropdownItem
        {
            public readonly ContentProduct Product;

            public ProductDropdownItem(string name, ContentProduct product) : base(name)
            {
                Product = product;
            }
        }

        public Action<ContentProduct> OnSelect { get; set; }
        public List<ContentProduct> ProductsToDisplay { get; set; }

        public ProductDropDown(AdvancedDropdownState state) : base(state)
        {
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new AdvancedDropdownItem("Select Product");

            if (ProductsToDisplay != null)
            {
                foreach (var currentProduct in ProductsToDisplay)
                {
                    root.AddChild(new ProductDropdownItem(currentProduct.DisplayName, currentProduct) { icon = currentProduct.Icon });
                }
            }

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            if (item is ProductDropdownItem productItem)
                OnSelect?.Invoke(productItem.Product);
        }
    }
}

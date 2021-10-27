using System;
using Unity.MARS;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS
{
    /// <summary>
    /// Attribute that shows and orders the panel views in the MARS Panel.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class PanelOrderAttribute : Attribute
    {
        /// <summary>
        /// Order least to greatest from top to bottom the panel will display in the MARS Panel
        /// </summary>
        public readonly int Order;

        /// <inheritdoc />
        /// <param name="order">Order least to greatest from top to bottom the panel will display in the MARS Panel</param>
        public PanelOrderAttribute(int order = PanelOrders.DefaultOrder) { Order = order; }
    }
}

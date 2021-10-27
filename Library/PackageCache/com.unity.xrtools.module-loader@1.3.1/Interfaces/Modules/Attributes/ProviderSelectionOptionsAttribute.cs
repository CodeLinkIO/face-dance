using System;
using UnityEngine;

namespace Unity.XRTools.ModuleLoader
{
    /// <summary>
    /// Specifies the priority level for this provider
    /// When the system automatically creates providers, it will use the priority value to sort the list of types which
    /// implement a particular provider interface, and activate the type with the highest priority value
    /// </summary>
    public class ProviderSelectionOptionsAttribute : Attribute
    {
        /// <summary>
        /// The priority level of this provider
        /// </summary>
        public int Priority { get; private set; }

        /// <summary>
        /// Platforms on which this provider should be excluded
        /// </summary>
        public RuntimePlatform[] ExcludedPlatforms { get; private set; }

        /// <summary>
        /// If true, the system will not automatically create an instance of this provider. The provider can still be
        /// automatically setup as part of a prefab instance.
        /// </summary>
        public bool DisallowAutoCreation { get; }

        /// <summary>
        /// Initializes a new instance of ProviderSelectionOptionsAttribute
        /// </summary>
        /// <param name="priority">The priority level of this provider, used for sorting alongside other implementors of the same functionality type</param>
        /// <param name="excludedPlatforms">Platforms on which this provider should be excluded</param>
        /// <param name="disallowAutoCreation">If true, the system will not automatically create an instance of this provider.
        /// The provider can still be automatically setup as part of a prefab instance.</param>
        public ProviderSelectionOptionsAttribute(int priority = 0, RuntimePlatform[] excludedPlatforms = null, bool disallowAutoCreation = false)
        {
            Priority = priority;
            ExcludedPlatforms = excludedPlatforms;
            DisallowAutoCreation = disallowAutoCreation;
        }
    }
}

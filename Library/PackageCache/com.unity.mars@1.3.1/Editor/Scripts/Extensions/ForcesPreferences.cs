using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;

namespace UnityEditor.MARS.Forces.EditorExtensions
{
    class ForcesPreferences : EditorScriptableSettings<ForcesPreferences>
    {
#pragma warning disable 649
        [SerializeField]
        Material m_ProxyForceRegionEmpty;

        [SerializeField]
        Material m_ProxyForceRegionOccupied;

        [SerializeField]
        Material m_ProxyForceRegionTouching;
#pragma warning restore 649

        public Material ProxyForceRegionEmpty => m_ProxyForceRegionEmpty;

        public Material ProxyForceRegionOccupied => m_ProxyForceRegionOccupied;

        public Material ProxyForceRegionTouching => m_ProxyForceRegionTouching;
    }
}

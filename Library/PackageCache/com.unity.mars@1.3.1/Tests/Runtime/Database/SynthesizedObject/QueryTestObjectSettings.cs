using UnityEngine;
using Unity.XRTools.Utils;
using UnityEngine.Serialization;

namespace Unity.MARS.Tests
{
    /// <summary>
    /// Holds references to pre-configured game objects for use in the runtime query system tests
    /// </summary>
    [ScriptableSettingsPath("Packages/com.unity.mars/Tests/Runtime/Database/Query Objects")]
    class QueryTestObjectSettings : ScriptableSettings<QueryTestObjectSettings>
    {
#pragma warning disable 649
        [SerializeField]
        GameObject m_NonRequiredChildrenSet;

        [FormerlySerializedAs("m_AllNonRequiredChildrenSet")] [SerializeField]
        GameObject m_AllNonRequiredChildrenGroup;
        [SerializeField]
        GameObject m_AllNonRequiredChildrenReacquireGroup;

        [SerializeField]
        GameObject m_SimpleProxyGroup;

        [SerializeField]
        GameObject m_ProxyGroupWithNonRequiredMember;

        [SerializeField]
        GameObject m_SimplePlaneConditionProxy;

        [SerializeField]
        GameObject m_SimpleReplicatedProxy;
#pragma warning restore 649

        public GameObject NonRequiredChildrenSet => m_NonRequiredChildrenSet;
        public GameObject AllNonRequiredChildrenGroup => m_AllNonRequiredChildrenGroup;
        public GameObject AllNonRequiredChildrenReacquireGroup => m_AllNonRequiredChildrenReacquireGroup;
        public GameObject SimpleProxyGroup => m_SimpleProxyGroup;
        public GameObject ProxyGroupWithNonRequiredMember => m_ProxyGroupWithNonRequiredMember;
        public GameObject SimplePlaneConditionProxy => m_SimplePlaneConditionProxy;
        public GameObject SimpleReplicatedProxy => m_SimpleReplicatedProxy;
    }
}

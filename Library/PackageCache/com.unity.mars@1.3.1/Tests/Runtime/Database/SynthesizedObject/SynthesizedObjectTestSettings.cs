using UnityEngine;
using Unity.XRTools.Utils;

namespace Unity.MARS.Tests
{
    /// <summary>
    /// This holds references to pre-configured game objects for use in the SynthesizedObject tests
    /// </summary>
    [ScriptableSettingsPath("Packages/com.unity.mars/Tests/Runtime/Database/SynthesizedObject")]
    class SynthesizedObjectTestSettings : ScriptableSettings<SynthesizedObjectTestSettings>
    {
#pragma warning disable 649
        [SerializeField]
        GameObject m_SynthesizedObject;

        [SerializeField]
        GameObject m_Test1QueryObject;

        [SerializeField]
        GameObject m_Test2QueryObject;

        [SerializeField]
        GameObject m_Test3QueryObject1;

        [SerializeField]
        GameObject m_Test3QueryObject2;
#pragma warning restore 649

        public GameObject SynthesizedObject { get { return m_SynthesizedObject; } }
        public GameObject Test1QueryObject { get { return m_Test1QueryObject; } }
        public GameObject Test2QueryObject { get { return m_Test2QueryObject; } }
        public GameObject Test3QueryObject1 { get { return m_Test3QueryObject1; } }
        public GameObject Test3QueryObject2 { get { return m_Test3QueryObject2; } }
    }
}

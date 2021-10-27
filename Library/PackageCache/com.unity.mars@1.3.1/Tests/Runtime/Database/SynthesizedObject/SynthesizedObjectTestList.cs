#if UNITY_EDITOR
using NUnit.Framework;
using System.Collections;
using Unity.MARS.Settings;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    class SynthesizedObjectTestList
    {
        bool m_SimulateInPlayModeCachedValue;
        bool m_SimulateDiscoveryCachedValue;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            MARSSession.TestMode = true;
            var sceneModule = MARSSceneModule.instance;
            m_SimulateInPlayModeCachedValue = sceneModule.simulateInPlaymode;
            m_SimulateDiscoveryCachedValue = sceneModule.simulateDiscovery;

            sceneModule.simulateInPlaymode = true;
            sceneModule.simulateDiscovery = false;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            MARSSession.TestMode = false;
            var sceneModule = MARSSceneModule.instance;
            sceneModule.simulateInPlaymode = m_SimulateInPlayModeCachedValue;
            sceneModule.simulateDiscovery = m_SimulateDiscoveryCachedValue;
        }

        [UnityTest]
        public IEnumerator SynthesizedObjectAddRemoveToDB()
        {
            yield return new MonoBehaviourTest<AddRemoveSynthesizedTest>();
        }

        [UnityTest]
        public IEnumerator SynthesizedObjectUpdatesDB()
        {
            yield return new MonoBehaviourTest<UpdateSynthesizedTest>();
        }

        [UnityTest]
        public IEnumerator SynthesizedObjectFiresWithRealWorldObject()
        {
            yield return new MonoBehaviourTest<SynthesizedChildTest>();
        }
    }
}
#endif

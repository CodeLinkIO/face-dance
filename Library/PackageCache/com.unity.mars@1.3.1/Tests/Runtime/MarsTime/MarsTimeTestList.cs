#if UNITY_EDITOR
using System.Collections;
using NUnit.Framework;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Tests
{
    class MarsTimeTestList
    {
        MarsTimeModule m_MarsTimeModule;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_MarsTimeModule = MarsTimeModule.instance;
            var marsTimeModule = (IModule)m_MarsTimeModule;
            marsTimeModule.LoadModule();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var marsTimeModule = (IModule)m_MarsTimeModule;
            marsTimeModule.UnloadModule();
        }

        [SetUp]
        public void SetUp()
        {
            // Must set start time here so tests can know the difference in Time.time from when MarsTimeModule was set up
            MarsTimeTest.StartTime = Time.time;
            var marsTimeModule = (IModuleBehaviorCallbacks)m_MarsTimeModule;
            marsTimeModule.OnBehaviorEnable();
        }

        [TearDown]
        public void TearDown()
        {
            var marsTimeModule = (IModuleBehaviorCallbacks)m_MarsTimeModule;
            marsTimeModule.OnBehaviorDisable();
        }

        [UnityTest]
        public IEnumerator MarsTimeTick() { yield return new MonoBehaviourTest<MarsTimeTickTest>(); }

        [UnityTest]
        public IEnumerator MarsTimeScale() { yield return new MonoBehaviourTest<MarsTimeScaleTest>(); }
    }
}
#endif

using NUnit.Framework;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Tests
{
    class UnityInternalCallbacksTests
    {
        UnityCallbackLogger m_CallbackLogger;

        [SetUp]
        public void SetUp()
        {
            m_CallbackLogger = UnityCallbackLogger.Create();
        }

        [TearDown]
        public void TearDown()
        {
            m_CallbackLogger.Dispose();
        }

        [Test]
        public void OnEnableINTERNAL_CalledOnObjectCreation()
        {
            Assert.That(m_CallbackLogger.GetCallbackReceivedCount(UnityCallback.OnEnableINTERNAL), Is.EqualTo(1));
        }

        [Test]
        public void OnEnableINTERNAL_CalledOnObjectActivation()
        {
            m_CallbackLogger.target.enabled = false;
            m_CallbackLogger.Clear();
            m_CallbackLogger.target.enabled = true;

            Assert.That(m_CallbackLogger.GetCallbackReceivedCount(UnityCallback.OnEnableINTERNAL), Is.EqualTo(1));
        }

        [Test]
        public void OnDisableINTERNAL_CalledOnObjectDestruction()
        {
            Object.DestroyImmediate(m_CallbackLogger.target.gameObject);
            Assert.That(m_CallbackLogger.GetCallbackReceivedCount(UnityCallback.OnDisableINTERNAL), Is.EqualTo(1));
        }

        [Test]
        public void OnDisableINTERNAL_CalledOnObjectDeactivation()
        {
            m_CallbackLogger.target.enabled = false;
            Assert.That(m_CallbackLogger.GetCallbackReceivedCount(UnityCallback.OnDisableINTERNAL), Is.EqualTo(1));
        }
    }
}
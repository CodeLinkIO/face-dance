using NUnit.Framework;
using System;
using Unity.MARS.Query;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Tests
{
    class EvaluationSchedulerModuleTests
    {
        EvaluationSchedulerModule m_Module;

        [OneTimeSetUp]
        public void Setup()
        {
            m_Module = EvaluationSchedulerModule.instance;
        }

        [SetUp]
        public void BeforeEach()
        {
            MarsTime.Time = 0f;
            var module = (IModule)m_Module;
            module.LoadModule();
            m_Module.SetMode(MarsSceneEvaluationMode.WaitForRequest);
        }

        [TearDown]
        public void AfterEach()
        {
            var module = (IModule)m_Module;
            module.UnloadModule();
        }

        [Test]
        public void SetEvaluationMode_WaitToInterval_QueuesEvaluationIfAlreadyRunning()
        {
            // to fake the "already evaluating" state, queue an evaluation, set the time into the future, tick update
            var response = m_Module.RequestSceneEvaluation();
            Assert.AreEqual(MarsSceneEvaluationRequestResponse.QueuedAfterCooldown, response);
            MarsTime.Time += m_Module.MinimumEvaluationInterval + 1f;
            var moduleMarsUpdate = (IModuleMarsUpdate)m_Module;
            moduleMarsUpdate.OnMarsUpdate();
            Assert.True(m_Module.CurrentlyEvaluating);
            Assert.False(m_Module.EvaluationQueued);

            m_Module.SetMode(MarsSceneEvaluationMode.EvaluateOnInterval);

            Assert.True(m_Module.EvaluationQueued);
            Assert.AreEqual(m_Module.ActiveMode, MarsSceneEvaluationMode.EvaluateOnInterval);
        }

        [Test]
        public void SetEvaluationMode_WaitToInterval_StartsEvaluationIfNotRunning()
        {
            Assert.AreEqual(m_Module.ActiveMode, MarsSceneEvaluationMode.WaitForRequest);
            Assert.False(m_Module.CurrentlyEvaluating);

            m_Module.SetMode(MarsSceneEvaluationMode.EvaluateOnInterval);

            Assert.False(m_Module.EvaluationQueued);
            Assert.True(m_Module.CurrentlyEvaluating);
            Assert.AreEqual(m_Module.ActiveMode, MarsSceneEvaluationMode.EvaluateOnInterval);
        }

        [Test]
        public void SetEvaluationMode_IntervalToWait()
        {
            m_Module.SetMode(MarsSceneEvaluationMode.EvaluateOnInterval);
            Assert.AreEqual(m_Module.ActiveMode, MarsSceneEvaluationMode.EvaluateOnInterval);

            m_Module.SetMode(MarsSceneEvaluationMode.WaitForRequest);
            Assert.AreEqual(m_Module.ActiveMode, MarsSceneEvaluationMode.WaitForRequest);
        }

        [Test]
        public void RequestSceneEvaluation_ReturnNotQueued_IfUsingIntervalMode()
        {
            m_Module.SetMode(MarsSceneEvaluationMode.EvaluateOnInterval);

            var response = m_Module.RequestSceneEvaluation();
            Assert.AreEqual(MarsSceneEvaluationRequestResponse.NotQueued, response);
        }

        [Test]
        public void RequestSceneEvaluation_ReturnQueuedImmediately_IfNotOnCooldown()
        {
            // fake that more than the minimum time between evaluations has elapsed
            MarsTime.Time += m_Module.MinimumEvaluationInterval + 1f;

            var response = m_Module.RequestSceneEvaluation();
            Assert.AreEqual(MarsSceneEvaluationRequestResponse.QueuedImmediately, response);
        }

        [Test]
        public void RequestSceneEvaluation_ReturnQueuedAfterCooldown_IfOnCooldown()
        {
            // because no Mars Time has passed since we loaded, the minimum time between evaluations hasn't elapsed
            var response = m_Module.RequestSceneEvaluation();
            Assert.AreEqual(MarsSceneEvaluationRequestResponse.QueuedAfterCooldown, response);
        }

        [Test]
        public void RequestSceneEvaluation_WhileQueuedButNotEvaluating_ReturnAlreadyQueued()
        {
            m_Module.RequestSceneEvaluation();
            // the second time we queue, the system should acknowledge that is was already queued
            var response = m_Module.RequestSceneEvaluation();

            Assert.AreEqual(MarsSceneEvaluationRequestResponse.AlreadyQueued, response);
        }

        [Test]
        public void RequestSceneEvaluation_WhileEvaluatingButNotQueued_ReturnQueuedAfterCooldown()
        {
            StartEvaluation();
            // the second time we queue, the system should acknowledge that it was queued for eval after cooldown
            var response = m_Module.RequestSceneEvaluation();

            Assert.AreEqual(MarsSceneEvaluationRequestResponse.QueuedAfterCooldown, response);
        }

        [Test]
        public void RequestSceneEvaluation_WhileEvaluatingAndAlreadyQueued_ReturnAlreadyQueued()
        {
            StartEvaluation();
            m_Module.RequestSceneEvaluation();
            // the second time we queue after starting evaluation, the system should acknowledge that is was already queued
            var response = m_Module.RequestSceneEvaluation();

            Assert.AreEqual(MarsSceneEvaluationRequestResponse.AlreadyQueued, response);
        }

        [Test]
        public void UpdateWhenQueued_TriggersEvaluationStart_IfMinimumIntervalElapsed()
        {
            Assert.AreEqual(MarsSceneEvaluationMode.WaitForRequest, m_Module.ActiveMode);
            MarsTime.Time += m_Module.MinimumEvaluationInterval + 1f;
            m_Module.RequestSceneEvaluation();

            var moduleMarsUpdate = (IModuleMarsUpdate)m_Module;
            moduleMarsUpdate.OnMarsUpdate();

            Assert.True(m_Module.CurrentlyEvaluating);
            Assert.False(m_Module.EvaluationQueued);
        }

        [Test]
        public void UpdateWhenQueued_DoesNotTriggerEvaluationStart_IfMinimumIntervalNotElapsed()
        {
            Assert.AreEqual(MarsSceneEvaluationMode.WaitForRequest, m_Module.ActiveMode);
            m_Module.RequestSceneEvaluation();

            var moduleMarsUpdate = (IModuleMarsUpdate)m_Module;
            moduleMarsUpdate.OnMarsUpdate();

            Assert.False(m_Module.CurrentlyEvaluating);
            Assert.True(m_Module.EvaluationQueued);
        }

        [Test]
        public void GetAndSetEvaluationInterval()
        {
            m_Module.SetEvaluationInterval(0f);
            // settings to 0 or less should instead set to the absolute minimum
            Assert.AreEqual(EvaluationSchedulerModule.AbsoluteMinimumIntervalTime, m_Module.GetEvaluationInterval());

            const float value1 = 1f;
            m_Module.SetEvaluationInterval(value1);
            Assert.AreEqual(value1, m_Module.GetEvaluationInterval());

            const float value2 = 5f;
            m_Module.SetEvaluationInterval(value2);
            Assert.AreEqual(value2, m_Module.GetEvaluationInterval());
        }

        void StartEvaluation()
        {
            MarsTime.Time += m_Module.MinimumEvaluationInterval + 1f;
            m_Module.RequestSceneEvaluation();
            var moduleMarsUpdate = (IModuleMarsUpdate)m_Module;
            moduleMarsUpdate.OnMarsUpdate();
        }
    }
}

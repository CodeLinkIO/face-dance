#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS.Tests
{
    /// <summary>
    /// Tests that Mars Time ticks on a fixed time interval and that MarsUpdate is fired with each tick
    /// </summary>
    [AddComponentMenu("")]
    class MarsTimeTickTest : MarsTimeTest
    {
        const int k_FrameCount = 10;

        int m_CurrentMarsFrame;
        float m_CurrentMarsTime;
        int m_MarsUpdatesThisFrame;

        protected override int FrameCount { get { return k_FrameCount; } }

        protected override void OnEnable()
        {
            base.OnEnable();

            m_CurrentMarsTime = MarsTime.Time;
            m_CurrentMarsFrame = MarsTime.FrameCount;
            MarsTime.MarsUpdate += OnMarsUpdate;
        }

        void OnDisable()
        {
            MarsTime.MarsUpdate -= OnMarsUpdate;
        }

        protected override void Update()
        {
            if (IsTestFinished)
                return;

            var marsTimeLastFrame = MarsTime.Time;
            m_MarsUpdatesThisFrame = 0;

            base.Update();

            // Mars Time should update at the same pace as Time.time
            AssertMarsTimeIsCloseToTime(Time.time - StartTime);

            // Check that we received the Mars Update callback the right number of times
            var expectedUpdatesThisFrame = Mathf.RoundToInt((MarsTime.Time - marsTimeLastFrame) / m_MarsTimeStep);
            Assert.AreEqual(expectedUpdatesThisFrame, m_MarsUpdatesThisFrame);
        }

        void OnMarsUpdate()
        {
            m_MarsUpdatesThisFrame++;

            var marsTime = MarsTime.Time;
            Assert.AreEqual(m_CurrentMarsTime + m_MarsTimeStep, marsTime, k_TimeCheckTolerance);
            m_CurrentMarsTime = marsTime;

            var marsFrame = MarsTime.FrameCount;
            Assert.AreEqual(m_CurrentMarsFrame + 1, marsFrame);
            m_CurrentMarsFrame = marsFrame;
        }
    }
}
#endif

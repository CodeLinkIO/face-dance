#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Tests
{
    /// <summary>
    /// Tests that changes to MarsTime.TimeScale affect the frequency of MarsUpdates per frame
    /// </summary>
    [AddComponentMenu("")]
    class MarsTimeScaleTest : MarsTimeTest
    {
        const int k_BaseFrameCount = 21;
        const int k_MaxSkippedFrames = 1000; // Failsafe to keep the test from running indefinitely
        const float k_FastTimeScale = 50f;
        const float k_SlowTimeScale = 0.5f;
        const float k_NegativeTimeScale = -1f;

        float m_TimeAtLastTimeScaleChange;
        float m_MarsTimeAtLastTimeScaleChange;
        int m_CurrentFrame;
        bool m_PausedThisFrame;
        int m_SkippedFrames;

        protected override int FrameCount { get { return k_BaseFrameCount + m_SkippedFrames; } }

        protected override void OnEnable()
        {
            base.OnEnable();

            m_TimeAtLastTimeScaleChange = StartTime;
            m_MarsTimeAtLastTimeScaleChange = MarsTime.Time;
        }

        protected override void Update()
        {
            if (IsTestFinished)
                return;

            Assert.AreEqual(Time.deltaTime * MarsTime.TimeScale, MarsTime.ScaledDeltaTime, k_TimeCheckTolerance);

            var time = Time.time;
            var endMarsTime = m_MarsTimeAtLastTimeScaleChange + (time - m_TimeAtLastTimeScaleChange) * MarsTime.TimeScale;
            if ((MarsTime.Time + m_MarsTimeStep > endMarsTime) && !MarsTime.Paused && (m_SkippedFrames < k_MaxSkippedFrames))
            {
                // Sometimes there will be no MarsUpdates in a frame due to small deltaTime. Since we test setting MarsTime
                // properties from MarsUpdate, we skip frames where there will be no MarsUpdates (unless paused).
                // Eventually there should be a frame with a MarsUpdate, when the difference in time from the start
                // is larger than MarsTime.TimeStep.
                m_SkippedFrames++;
                return;
            }

            switch (m_CurrentFrame)
            {
                case 0:
                    // Test setting time scale from Mars Update
                    MarsTime.MarsUpdate += SetFastTimeScale;
                    break;
                case 4:
                    // Test pausing from Mars Update
                    MarsTime.MarsUpdate += PauseMarsTime;
                    break;
                case 8:
                    MarsTime.Play();
                    Assert.AreEqual(1f, MarsTime.TimeScale, k_TimeScaleCheckTolerance);
                    Assert.False(MarsTime.Paused);
                    break;
                case 10:
                    // Test setting time scale before MarsTimeModule updates.
                    // Directly setting time scale to 0 should pause Mars Time, but not immediately
                    MarsTime.TimeScale = 0f;
                    Assert.AreEqual(0f, MarsTime.TimeScale, k_TimeScaleCheckTolerance);
                    Assert.False(MarsTime.Paused);
                    break;
                case 12:
                    // Test setting time scale to positive value to unpause next frame
                    MarsTime.TimeScale = k_SlowTimeScale;
                    Assert.AreEqual(k_SlowTimeScale, MarsTime.TimeScale, k_TimeScaleCheckTolerance);

                    // Paused should still be false because we did not call Play
                    Assert.True(MarsTime.Paused);
                    break;
                case 16:
                    // Setting a negative time scale should log an error and have no effect on MarsTime.TimeScale, as
                    // is the case with Time.timeScale
                    LogAssert.Expect(LogType.Error, MarsTimeModule.NegativeTimeScaleMessage);
                    MarsTime.TimeScale = k_NegativeTimeScale;
                    Assert.AreEqual(k_SlowTimeScale, MarsTime.TimeScale, k_TimeScaleCheckTolerance);
                    break;
                case 20:
                    // Calling Play() while Paused is false should do nothing
                    MarsTime.Play();
                    Assert.AreEqual(k_SlowTimeScale, MarsTime.TimeScale, k_TimeScaleCheckTolerance);
                    break;
            }

            base.Update();

            var timeSinceLastTimeScaleChange = time - m_TimeAtLastTimeScaleChange;
            var timeScaleChanged = false;
            switch (m_CurrentFrame)
            {
                case 0:
                    // We changed to fast time scale this frame but it should only have an effect starting next frame, not this one.
                    // Mars Time should be close to the unscaled difference in time from the start.
                    AssertMarsTimeIsCloseToTime(timeSinceLastTimeScaleChange);
                    timeScaleChanged = true;
                    break;
                case 1:
                case 2:
                case 3:
                    // Test that fast time scale is applied to Mars Time updates
                    AssertMarsTimeIsCloseToTime(m_MarsTimeAtLastTimeScaleChange + timeSinceLastTimeScaleChange * k_FastTimeScale);
                    break;
                case 4:
                    MarsTime.MarsUpdate -= PauseMarsTime;
                    break;
                case 5:
                case 6:
                case 7:
                    // Test that Mars Time does not advance while paused
                    AssertMarsTimeHasNotChanged();
                    break;
                case 8:
                    // Even though Paused is false, Mars Time should not have changed after update since the call to Play happened this frame
                    AssertMarsTimeHasNotChanged();
                    timeScaleChanged = true;
                    break;
                case 9:
                    // Mars Time should update at the same pace as Time.time after calling Play
                    AssertMarsTimeIsCloseToTime(m_MarsTimeAtLastTimeScaleChange + timeSinceLastTimeScaleChange);
                    break;
                case 10:
                    // Time scale was set to 0 but not through Pause.
                    // Mars Time should have advanced this frame, but Paused should be true so that time does not advance next frame.
                    AssertMarsTimeIsCloseToTime(m_MarsTimeAtLastTimeScaleChange + timeSinceLastTimeScaleChange);
                    Assert.True(MarsTime.Paused);
                    timeScaleChanged = true;
                    break;
                case 11:
                    AssertMarsTimeHasNotChanged();
                    Assert.True(MarsTime.Paused);
                    break;
                case 12:
                    // Time scale was set to a positive value.  Time should not have advanced this frame but should advance next frame.
                    AssertMarsTimeHasNotChanged();
                    Assert.False(MarsTime.Paused);
                    timeScaleChanged = true;
                    break;
                default:
                    // Test that slow time scale is applied to Mars Time updates
                    AssertMarsTimeIsCloseToTime(m_MarsTimeAtLastTimeScaleChange + timeSinceLastTimeScaleChange * k_SlowTimeScale);
                    Assert.False(MarsTime.Paused);
                    break;
            }

            if (timeScaleChanged)
            {
                m_TimeAtLastTimeScaleChange = time;
                m_MarsTimeAtLastTimeScaleChange = MarsTime.Time;
            }

            m_CurrentFrame++;
        }

        static void SetFastTimeScale()
        {
            MarsTime.MarsUpdate -= SetFastTimeScale;
            MarsTime.TimeScale = k_FastTimeScale;
            AssertTimeScaleIsValue(k_FastTimeScale);
        }

        void PauseMarsTime()
        {
            Assert.False(m_PausedThisFrame, "Mars Update occurred while Mars Time is paused");

            m_PausedThisFrame = true;
            MarsTime.Pause();
            Assert.Zero(MarsTime.TimeScale);
            Assert.True(MarsTime.Paused);
            m_TimeAtLastTimeScaleChange = Time.time;
            m_MarsTimeAtLastTimeScaleChange = MarsTime.Time;
        }

        static void AssertTimeScaleIsValue(float value)
        {
            Assert.AreEqual(value, MarsTime.TimeScale, k_TimeScaleCheckTolerance);
        }

        void AssertMarsTimeHasNotChanged()
        {
            Assert.AreEqual(m_MarsTimeAtLastTimeScaleChange, MarsTime.Time, k_TimeCheckTolerance);
        }
    }
}
#endif

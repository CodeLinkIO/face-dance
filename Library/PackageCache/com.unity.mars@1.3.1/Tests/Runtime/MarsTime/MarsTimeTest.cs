#if UNITY_EDITOR
using NUnit.Framework;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Tests
{
    /// <summary>
    /// Base class used for Mars Time tests. Sets up and updates MarsTimeModule.
    /// </summary>
    [AddComponentMenu("")]
    abstract class MarsTimeTest : MonoBehaviour, IMonoBehaviourTest
    {
        protected const float k_TimeCheckTolerance = 0.0001f;
        protected static readonly float k_TimeScaleCheckTolerance = Mathf.Epsilon * 8f; // This is the tolerance used for Mathf.Approximately

        protected float m_MarsTimeStep;

        MarsTimeModule m_MarsTimeModule;
        int m_StartFrame;

        public static float StartTime { get; set; }

        public bool IsTestFinished
        {
            get
            {
                if (Time.frameCount - m_StartFrame >= FrameCount)
                {
                    enabled = false;
                    return true;
                }

                return false;
            }
        }

        protected abstract int FrameCount { get; }

        protected virtual void OnEnable()
        {
            m_StartFrame = Time.frameCount;

            m_MarsTimeModule = MarsTimeModule.instance;
            m_MarsTimeStep = MarsTime.TimeStep;

            Assert.Zero(MarsTime.Time);
            Assert.Zero(MarsTime.FrameCount);
            Assert.AreEqual(1f, MarsTime.TimeScale, k_TimeScaleCheckTolerance);
            Assert.False(MarsTime.Paused);
        }

        protected virtual void Update()
        {
            var marsTimeModule = (IModuleBehaviorCallbacks)m_MarsTimeModule;
            marsTimeModule.OnBehaviorUpdate();
        }

        protected void AssertMarsTimeIsCloseToTime(float time)
        {
            // Mars Time should not go past the given time
            var marsTime = MarsTime.Time;
            Assert.LessOrEqual(marsTime, time);

            // The next increment should be greater than the given time
            Assert.GreaterOrEqual(marsTime + m_MarsTimeStep, time);
        }
    }
}
#endif

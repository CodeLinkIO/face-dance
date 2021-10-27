#if UNITY_EDITOR
using System;
using Unity.MARS.Simulation;
using Unity.MARS.Tests;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Base class used for each Synthesized Object test case.
    /// Responsible for clearing out the backend and database to a base state and creating any extra providers
    /// </summary>
    [AddComponentMenu("")]
    abstract class SynthesizedObjectTest : MarsRuntimeTest
    {
        const int k_FrameCount = 60;

        protected SynthesizedObjectTestSettings m_References;

        public override bool IsTestFinished
        {
            get
            {
                // Wait until all simulation scenes are unloaded before completing the test
                if (!enabled && SceneManager.sceneCount == m_StartSceneCount)
                    return true;

                // Shut down after desired frame count
                if (MarsTime.FrameCount - m_StartFrame >= k_FrameCount)
                    enabled = false;

                return false;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_References = SynthesizedObjectTestSettings.instance;
        }
    }
}
#endif

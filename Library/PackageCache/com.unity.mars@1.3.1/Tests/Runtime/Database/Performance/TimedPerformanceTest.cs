#if UNITY_EDITOR
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.TestTools;
using Debug = UnityEngine.Debug;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    abstract class TimedPerformanceTest : MonoBehaviour, IMonoBehaviourTest
    {
        protected float m_StartTime;
        protected float m_Duration = 1f;

        protected static int s_DataCount = 1000;

        protected readonly List<long> m_ElapsedTickSamples = new List<long>();
        protected static Stopwatch s_Stopwatch = new Stopwatch();

        public bool IsTestFinished
        {
            get
            {
                if (Time.time - m_StartTime >= m_Duration)
                {
                    LogResults();
                    enabled = false;
                    return true;
                }

                return false;
            }
        }

        protected virtual void Awake()
        {
            m_StartTime = Time.time;
        }

        protected virtual void LogResults()
        {
            var sum = 0f;
            var sampleCount = m_ElapsedTickSamples.Count;
            for (var i = 0; i < sampleCount; i++)
            {
                sum += m_ElapsedTickSamples[i];
            }

            Debug.LogFormat("Total ticks elapsed: {0} , Total calls {1}", sum, sampleCount * s_DataCount);
            Debug.LogFormat("Average time: {0} , for {1} calls per frame", sum / sampleCount, s_DataCount);
        }

        // you have to re-implement Update following this pattern
        protected virtual void Update()
        {
            s_Stopwatch.Restart();

            //for (var i = 0; i < s_DataCount; i++)
            //{
            //    // do stuff
            //}

            s_Stopwatch.Stop();

            m_ElapsedTickSamples.Add(s_Stopwatch.ElapsedTicks);
        }

        protected virtual void OnDestroy() { }
    }
}
#endif

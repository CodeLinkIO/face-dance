using System.Diagnostics;

namespace Unity.XRTools.Utils.Tests
{
    abstract class PerformanceComparisonTest : PerformanceTestBase
    {
        protected readonly Stopwatch m_TimerB = new Stopwatch();
        protected long m_ElapsedTicksB;

        protected string m_MethodBLabel;
        
        public void Awake()
        {
            SetupData();

            RunTestFrame(); // make sure we JIT the code ahead of time
            m_Timer.Reset();
            m_TimerB.Reset();
            m_ElapsedTicks = 0;
            m_ElapsedTicksB = 0;

            m_TestClassLabel = GetType().Name;
        }

        protected override string GetReport()
        {
            var count = (float) (m_CallCount * m_FrameCounter);
            m_Report = string.Format("{0} - {1} calls\n\n", m_TestClassLabel, m_CallCount * m_FrameCount);

            var ratio = m_ElapsedTicks / (float) m_ElapsedTicksB;
            var ratioMsg = ratio.ToString("F5");
            m_Report += string.Format("{0} : 1 ratio for execution time\n\n", ratioMsg);
            m_Report += string.Format("using {0}\naverage {1} ticks / call\n\n", m_MethodLabel, m_ElapsedTicks / count);
            m_Report += string.Format("using {0}\naverage {1} ticks / call", m_MethodBLabel, m_ElapsedTicksB / count);
            return m_Report;
        }
    }
}

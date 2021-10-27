namespace Unity.XRTools.Utils.Tests
{
    abstract class PerformanceTest : PerformanceTestBase
    {
        public void Awake()
        {
            SetupData();

            RunTestFrame(); // make sure we JIT the code ahead of time
            m_Timer.Reset();
            m_ElapsedTicks = 0;

            m_TestClassLabel = GetType().Name;
        }

        protected override string GetReport()
        {
            var count = (float) (m_CallCount * m_FrameCounter);
            m_Report = string.Format("{0} - {1} calls\n\n", m_TestClassLabel, m_CallCount * m_FrameCount);
            m_Report += string.Format("using {0}\naverage {1} ticks / call\n", m_MethodLabel, m_ElapsedTicks / count);
            return m_Report;
        }
    }
}

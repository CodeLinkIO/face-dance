#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class RemoveDataTest : DatabasePerformanceTest, IMonoBehaviourTest
    {
        const int k_TotalDataCount = 10000;
        static int s_RemoveIndex;

        MRPlane[] m_Planes = new MRPlane[k_TotalDataCount];

        public new bool IsTestFinished
        {
            get
            {
                if (s_RemoveIndex >= k_TotalDataCount)
                {
                    enabled = false;
                    return true;
                }

                return false;
            }
        }

        public void OnEnable()
        {
            ConnectDb();
            m_StartFrame = Time.frameCount;

            for (var i = 0; i < k_TotalDataCount; i++)
            {
                var plane = MakeNewPlane();
                m_Planes[i] = plane;
                m_Db.planeData.AddOrUpdateData(plane);
            }
        }

        public void Update()
        {
            for (var i = s_RemoveIndex; i < s_RemoveIndex + s_DataCount; i++)
                m_Db.planeData.RemoveData(m_Planes[i]);

            s_RemoveIndex += s_DataCount;
        }

    }
}
#endif

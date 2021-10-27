#if UNITY_EDITOR
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class AddDataTest : DatabasePerformanceTest
    {
        public void OnEnable()
        {
            ConnectDb();
            m_StartFrame = Time.frameCount;
        }

        public void Update()
        {
            for (var i = 0; i < s_DataCount; i++)
                m_Db.planeData.AddOrUpdateData(MakeNewPlane());
        }
    }
}
#endif

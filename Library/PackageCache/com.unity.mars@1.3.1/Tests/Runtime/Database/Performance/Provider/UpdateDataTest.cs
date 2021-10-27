#if UNITY_EDITOR
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    class UpdateDataTest : DatabasePerformanceTest
    {
        MRPlane[] m_Planes = new MRPlane[s_DataCount];

        public void OnEnable()
        {
            ConnectDb();
            m_StartFrame = Time.frameCount;
            for (var i = 0; i < s_DataCount; i++)
            {
                var plane = new MRPlane();
                plane.id = MarsTrackableId.Create();
                plane.extents = Vector2.one;
                m_Planes[i] = plane;
                m_Db.planeData.AddOrUpdateData(plane);
            }
        }

        public void Update()
        {
            // Even though we give it back the same data, the test works the same
            for (var i = 0; i < s_DataCount; i++)
                m_Db.planeData.AddOrUpdateData(m_Planes[i]);
        }
    }
}
#endif

#if UNITY_EDITOR
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    abstract class TimedRelationPerformanceTest<TRelation, TData> : TimedConditionPerformanceTest
        where TRelation : Component, IRelation<TData>
    {
        protected TRelation m_Relation;

        protected readonly TData[] m_DataToCompare = new TData[s_DataCount];

        protected override void Awake()
        {
            Random.InitState(0);
            base.Awake();
            m_Relation = m_TestObject.AddComponent<TRelation>();
            var cameraOffsetProvider = (IFunctionalityProvider)m_CameraOffsetProvider;
            cameraOffsetProvider.ConnectSubscriber(m_Relation);

            // make sure we don't let clients do their normal registration
            var client = m_TestObject.GetComponent<ProxyGroup>();
            if (client != null)
                client.enabled = false;

            m_TestObject.SetActive(true);
        }

        protected void RunTestIteration(TData child1Data)
        {
            s_Stopwatch.Restart();
            for (var i = 0; i < s_DataCount; i++)
            {
                m_Relation.RateDataMatch(ref child1Data, ref m_DataToCompare[i]);
            }

            s_Stopwatch.Stop();

            m_ElapsedTickSamples.Add(s_Stopwatch.ElapsedTicks);
        }
    }
}
#endif

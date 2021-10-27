#if UNITY_EDITOR
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    [AddComponentMenu("")]
    abstract class TimedConditionPerformanceTest : TimedPerformanceTest
    {
        protected MARSDatabase m_Db;
        protected QueryPipelinesModule m_PipelinesModule;
        protected MARSQueryBackend m_QueryBackend;

        protected GameObject m_TestObject;
        protected CameraOffsetProvider m_CameraOffsetProvider;

        protected override void Awake()
        {
            Random.InitState(0);
            base.Awake();

            var moduleLoader = ModuleLoaderCore.instance;
            moduleLoader.ReloadModules();
            m_Db = moduleLoader.GetModule<MARSDatabase>();

            m_PipelinesModule = moduleLoader.GetModule<QueryPipelinesModule>();
            var pipelineModuleDependency = (IModuleDependency<MARSDatabase>)m_PipelinesModule;
            pipelineModuleDependency.ConnectDependency(m_Db);

            var pipelinesModule = (IModule)m_PipelinesModule;
            pipelinesModule.LoadModule();

            m_QueryBackend = moduleLoader.GetModule<MARSQueryBackend>();
            var queryBackendDependency = (IModuleDependency<QueryPipelinesModule>)m_QueryBackend;
            queryBackendDependency.ConnectDependency(m_PipelinesModule);

            var queryBackendModule = (IModule)m_QueryBackend;
            queryBackendModule.LoadModule();

            m_TestObject = new GameObject();
            m_TestObject.SetActive(false);
            m_TestObject.AddComponent<Camera>();
            m_CameraOffsetProvider = m_TestObject.AddComponent<CameraOffsetProvider>();
        }

        protected override void OnDestroy()
        {
            UnityObjectUtils.Destroy(m_TestObject);
        }
    }

    abstract class TimedConditionPerformanceTest<TCondition, TData> : TimedConditionPerformanceTest
        where TCondition : Component, ICondition<TData>
    {
        protected TCondition m_Condition;

        protected TData[] m_DataToCompare = new TData[s_DataCount];

        protected override void Awake()
        {
            base.Awake();
            m_Condition = m_TestObject.AddComponent<TCondition>();
            var realWorldObject = m_TestObject.GetComponent<Proxy>();
            if (realWorldObject != null)
            {
                realWorldObject.enabled = false;
            }

            var cameraOffsetProvider = (IFunctionalityProvider)m_CameraOffsetProvider;
            cameraOffsetProvider.ConnectSubscriber(m_Condition);
            m_TestObject.SetActive(true);
        }

        protected override void Update()
        {
            RunTestIteration();
        }

        protected void RunTestIteration()
        {
            s_Stopwatch.Restart();
            for (var i = 0; i < s_DataCount; i++)
            {
                m_Condition.RateDataMatch(ref m_DataToCompare[i]);
            }

            s_Stopwatch.Stop();

            m_ElapsedTickSamples.Add(s_Stopwatch.ElapsedTicks);
        }
    }
}
#endif

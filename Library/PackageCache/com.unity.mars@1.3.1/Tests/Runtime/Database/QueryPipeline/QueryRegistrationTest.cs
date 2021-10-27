#if UNITY_EDITOR
using System;
using Unity.MARS.Actions;
using Unity.MARS.Conditions;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Query;
using Unity.MARS.Settings;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.MARS.Data.Tests
{
    /// <summary>
    /// Tests the sequence of creating a Proxy, waiting until it is tracking, deactivating it, and re-activating it on the next frame
    /// </summary>
    [AddComponentMenu("")]
    class QueryRegistrationTest : MonoBehaviour, IMonoBehaviourTest
    {
        const float k_SecondsTimeOut = 15.0f;

        MARSSession m_MARSSession;
        GameObject m_Proxy;

        // Local method use only -- created here to reduce garbage collection
        bool m_Completed;
        float m_TimeSinceCompleted;
        bool m_WasBlockingEnsureSession;
        bool m_WasSimulatingInPlayMode;
        bool m_WasSimulatingDiscovery;

        public bool IsTestFinished { get; private set; }

        protected virtual void OnEnable()
        {
            var sceneModule = MARSSceneModule.instance;
            m_WasBlockingEnsureSession = sceneModule.BlockEnsureSession;
            m_WasSimulatingInPlayMode = sceneModule.simulateInPlaymode;
            m_WasSimulatingDiscovery = sceneModule.simulateDiscovery;
            sceneModule.BlockEnsureSession = false;
            sceneModule.simulateInPlaymode = true;
            sceneModule.simulateDiscovery = false;

            MARSSession.TestMode = true;
            MARSSession.EnsureRuntimeState();
            m_MARSSession = MARSSession.Instance;

            m_Proxy = new GameObject("QueryRegistrationTest_Proxy");
            m_Proxy.SetActive(false);
            m_Proxy.AddComponent<Proxy>();
            m_Proxy.AddComponent<ShowChildrenOnTrackingAction>();
            m_Proxy.AddComponent<SetPoseAction>();
            m_Proxy.AddComponent<IsPlaneCondition>();
            m_Proxy.SetActive(true);

            var synthPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            synthPlane.SetActive(false);
            synthPlane.AddComponent<SynthesizedObject>();
            synthPlane.AddComponent<SynthesizedPlane>();
            synthPlane.SetActive(true);
        }

        void Update()
        {
            if (!m_Proxy.activeSelf)
            {
                m_Proxy.SetActive(true);
                m_Completed = true;
                m_TimeSinceCompleted = 0.0f;
            }

            m_TimeSinceCompleted += Time.deltaTime;
            if (m_TimeSinceCompleted >= k_SecondsTimeOut)
            {
                IsTestFinished = true;
                enabled = false;
                if (!m_Completed)
                    throw new Exception("Query failed to track in the first place.");
                else
                    throw new TimeoutException("Query failed to re-acquire before timeout");
            }

            switch (m_Proxy.GetComponent<Proxy>().queryState)
            {
                case QueryState.Unknown:
                    break;
                case QueryState.Unavailable:
                    break;
                case QueryState.Querying:
                    break;
                case QueryState.Tracking:
                    m_TimeSinceCompleted = 0.0f;
                    if (m_Completed)
                    {
                        IsTestFinished = true;
                        enabled = false;
                    }
                    else
                    {
                        m_Proxy.SetActive(false);
                    }

                    break;
                case QueryState.Acquiring:
                    break;
                case QueryState.Resuming:
                    break;
            }
        }

        protected virtual void OnDisable()
        {
            if (m_MARSSession)
                Destroy(m_MARSSession.gameObject);

            var sceneModule = MARSSceneModule.instance;
            sceneModule.BlockEnsureSession = m_WasBlockingEnsureSession;
            sceneModule.simulateInPlaymode = m_WasSimulatingInPlayMode;
            sceneModule.simulateDiscovery = m_WasSimulatingDiscovery;

            MARSSession.TestMode = false;
        }
    }
}
#endif

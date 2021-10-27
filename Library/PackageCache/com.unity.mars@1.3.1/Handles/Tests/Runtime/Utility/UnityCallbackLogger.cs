using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace Unity.MARS.MARSHandles.Tests
{
    enum UnityCallback
    {
        OnEnableINTERNAL,
        OnDisableINTERNAL,
    }

    class UnityCallbackLogger : IDisposable
    {
        class MonoBehaviourDummy : MonoBehaviour
        {
            List<UnityCallback> m_Log = new List<UnityCallback>();

            //Callbacks will arrive before we are linked to the logger
            public void LinkToLogger(List<UnityCallback> log)
            {
                log.AddRange(m_Log);
                m_Log = log;
            }

            void OnEnableINTERNAL()
            {
                m_Log.Add(UnityCallback.OnEnableINTERNAL);
            }

            void OnDisableINTERNAL()
            {
                m_Log.Add(UnityCallback.OnDisableINTERNAL);
            }
        }

        readonly List<UnityCallback> m_CallbackLog = new List<UnityCallback>();
        MonoBehaviour m_Target;

        public MonoBehaviour target
        {
            get { return m_Target; }
        }

        public static UnityCallbackLogger Create()
        {
            UnityCallbackLogger logger = new UnityCallbackLogger();

            var go = new GameObject("Unity Callback Logger", typeof(MonoBehaviourDummy));
            var target = go.GetComponent<MonoBehaviourDummy>();
            logger.m_Target = target;
            target.LinkToLogger(logger.m_CallbackLog);

            return logger;
        }

        public void Dispose()
        {
            if (m_Target != null)
                UnityEngine.Object.DestroyImmediate(m_Target);
        }

        public void Clear()
        {
            m_CallbackLog.Clear();
        }

        public int GetCallbackReceivedCount(UnityCallback callback)
        {
            int result = 0;
            foreach (var c in m_CallbackLog)
            {
                if (c == callback)
                    ++result;
            }

            return result;
        }

        public bool WasCallbackReceived(UnityCallback callback)
        {
            return m_CallbackLog.Contains(callback);
        }
    }
}

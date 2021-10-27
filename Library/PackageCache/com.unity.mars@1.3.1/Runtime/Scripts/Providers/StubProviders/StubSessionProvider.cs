using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Providers
{
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.StubProviderPriority)]
    class StubSessionProvider : StubProvider, IProvidesSessionControl
    {
        bool m_Destroyed;
        bool m_Paused;

        public override void ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesSessionControl>(obj);
        }

        public bool SessionExists() { return !m_Destroyed; }

        public bool SessionRunning() { return !m_Destroyed && !m_Paused; }

        public bool SessionReady() { return true; }

        public void CreateSession() { m_Destroyed = false; }

        public void DestroySession() { m_Destroyed = true; }

        public void ResetSession() { }

        public void PauseSession() { m_Paused = true; }

        public void ResumeSession() { m_Paused = false; }
    }
}

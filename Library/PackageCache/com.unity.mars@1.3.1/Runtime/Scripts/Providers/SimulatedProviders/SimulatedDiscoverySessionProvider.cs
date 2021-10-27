using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority, disallowAutoCreation:true)]
    [MovedFrom("Unity.MARS")]
    public class SimulatedDiscoverySessionProvider : MonoBehaviour, IProvidesSessionControl
    {
#pragma warning disable 649
        [SerializeField]
        SimulatedDiscoveryPlanesProvider m_PlanesProvider;

        [SerializeField]
        SimulatedDiscoveryPointCloudProvider m_PointCloudProvider;
#pragma warning restore 649

        public bool Destroyed { get; private set; }
        public bool Paused { get; private set; }

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesSessionControl>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        bool IProvidesSessionControl.SessionExists() { return !Destroyed; }

        bool IProvidesSessionControl.SessionRunning() { return !Destroyed && !Paused; }

        bool IProvidesSessionControl.SessionReady() { return true; }

        void IProvidesSessionControl.CreateSession() { Destroyed = false; }

        void IProvidesSessionControl.DestroySession() { Destroyed = true; }

        void IProvidesSessionControl.ResetSession()
        {
            if (m_PlanesProvider != null)
                m_PlanesProvider.ResetPlanes();

            if (m_PointCloudProvider != null)
                m_PointCloudProvider.ClearPoints();
        }

        void IProvidesSessionControl.PauseSession()
        {
            Paused = true;
        }

        void IProvidesSessionControl.ResumeSession()
        {
            Paused = false;
        }
    }
#else
    public class SimulatedDiscoverySessionProvider : MonoBehaviour
    {
        [SerializeField]
        SimulatedDiscoveryPlanesProvider m_PlanesProvider;

        [SerializeField]
        SimulatedDiscoveryPointCloudProvider m_PointCloudProvider;
    }
#endif
}

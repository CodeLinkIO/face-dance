using System;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    [MovedFrom("Unity.MARS.Providers")]
    public class SimulatedLightEstimationProvider : MonoBehaviour, IProvidesLightEstimation
    {
        public event Action<MRLightEstimation> lightEstimationUpdated;

        SynthesizedLightEstimation m_SynthLightEstimation;
        MRLightEstimation m_LightEstimation;

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesLightEstimation>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        public void RegisterSynthesizedLightEstimation(SynthesizedLightEstimation synthLightEstimation)
        {
            this.m_SynthLightEstimation = synthLightEstimation;
            lightEstimationUpdated?.Invoke(synthLightEstimation.GetData());
        }

        public void UnregisterSythensizedLightEstimation(SynthesizedLightEstimation synthLightEstimation)
        {
            if (this.m_SynthLightEstimation == synthLightEstimation)
                this.m_SynthLightEstimation = null;
        }

        public bool TryGetLightEstimation(out MRLightEstimation lightEstimation)
        {
            if (m_SynthLightEstimation)
            {
                lightEstimation = m_SynthLightEstimation.GetData();
                return true;
            }
            lightEstimation = default(MRLightEstimation);
            return false;
        }

        void Update()
        {
            if (m_SynthLightEstimation)
            {
                var lightEstimation = m_SynthLightEstimation.GetData();
                if (!m_LightEstimation.AreLightsEqual(lightEstimation))
                {
                    m_LightEstimation = lightEstimation;
                    lightEstimationUpdated?.Invoke(m_LightEstimation);
                }
            }
        }

    }
#else
public class SimulatedLightEstimationProvider : MonoBehaviour { }
#endif
}

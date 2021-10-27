using Unity.MARS.Providers.Synthetic;
using Unity.MARS.Simulation;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    [MovedFrom("Unity.MARS.Data")]
    [HelpURL(DocumentationConstants.SynthesizedLightEstimationDocs)]
    [RequireComponent(typeof(Light))]
    public class SynthesizedLightEstimation : MonoBehaviour, ISimulatable
    {
        [SerializeField]
        bool m_Directional = false;

        Light m_Light;

        MRLightEstimation m_LightEstimation = default(MRLightEstimation);

        void OnEnable()
        {
            m_Light = GetComponent<Light>();
#if UNITY_EDITOR
            foreach (var provider in Resources.FindObjectsOfTypeAll<SimulatedLightEstimationProvider>())
                provider.RegisterSynthesizedLightEstimation(this);
#endif
        }

        void OnDisable()
        {
#if UNITY_EDITOR
            foreach (var provider in Resources.FindObjectsOfTypeAll<SimulatedLightEstimationProvider>())
                provider.UnregisterSythensizedLightEstimation(this);
#endif
        }

        public MRLightEstimation GetData()
        {
            if (m_Light == null)
                return m_LightEstimation;

            if (m_Directional)
            {
                m_LightEstimation.m_AmbientBrightness = null;
                m_LightEstimation.m_ColorCorrection = null;

                m_LightEstimation.m_MainLightBrightness = m_Light.intensity;
                m_LightEstimation.m_MainLightColor = m_Light.color;
                m_LightEstimation.m_MainLightDirection = transform.forward;
            }
            else
            {
                m_LightEstimation.m_AmbientBrightness = m_Light.intensity;
                m_LightEstimation.m_ColorCorrection = m_Light.color;

                m_LightEstimation.m_MainLightBrightness = null;
                m_LightEstimation.m_MainLightColor = null;
                m_LightEstimation.m_MainLightDirection = null;
            }

            m_LightEstimation.m_SphericalHarmonics = RenderSettings.ambientProbe;

            return m_LightEstimation;
        }
    }
}

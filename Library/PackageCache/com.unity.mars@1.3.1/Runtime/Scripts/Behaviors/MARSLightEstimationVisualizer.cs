using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Visualizers
{
    [HelpURL(DocumentationConstants.MarsLightEstimationVisualizer)]
    [RequireComponent(typeof(Light))]
    [MovedFrom("Unity.MARS.Behaviors")]
    public class MARSLightEstimationVisualizer : MonoBehaviour, IUsesLightEstimation, IUsesCameraOffset, ISimulatable
    {
        IProvidesLightEstimation IFunctionalitySubscriber<IProvidesLightEstimation>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        Light m_Light;

        public Light Light { get => m_Light; internal set { m_Light = value; } }

        void OnEnable()
        {
            m_Light = GetComponent<Light>();
            if (!m_Light)
            {
                Debug.LogError("LightEstimationVisualizer doesn't have a Light component");
            }

            this.SubscribeLightEstimationUpdated(LightEstimationHandler);

            MRLightEstimation lightEstimation;
            if (this.TryGetLightEstimation(out lightEstimation))
                LightEstimationHandler(lightEstimation);
        }

        void OnDisable()
        {
            this.UnsubscribeLightEstimationUpdated(LightEstimationHandler);
        }

        void LightEstimationHandler(MRLightEstimation lightEstimation)
        {
            if (m_Light)
            {
                if (lightEstimation.m_AmbientBrightness.HasValue)
                    m_Light.intensity = lightEstimation.m_AmbientBrightness.Value;

                if (lightEstimation.m_AmbientColorTemperature.HasValue)
                    m_Light.colorTemperature = lightEstimation.m_AmbientColorTemperature.Value;

                if (lightEstimation.m_ColorCorrection.HasValue)
                    m_Light.color = lightEstimation.m_ColorCorrection.Value;

                if (lightEstimation.m_MainLightBrightness.HasValue)
                    m_Light.intensity = lightEstimation.m_MainLightBrightness.Value;

                if (lightEstimation.m_MainLightColor.HasValue)
                    m_Light.color = lightEstimation.m_MainLightColor.Value;

                if (lightEstimation.m_MainLightDirection.HasValue)
                {
                    Vector3 dir = lightEstimation.m_MainLightDirection.Value;
                    m_Light.transform.rotation = Quaternion.LookRotation(dir);
                }

                if (lightEstimation.m_SphericalHarmonics.HasValue)
                    RenderSettings.ambientProbe = lightEstimation.m_SphericalHarmonics.Value;
            }
        }
    }
}

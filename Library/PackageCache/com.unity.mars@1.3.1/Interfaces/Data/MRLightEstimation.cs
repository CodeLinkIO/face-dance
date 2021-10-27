using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for light estimation data
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public struct MRLightEstimation
    {
        [SerializeField]
        public float? m_AmbientBrightness;

        [SerializeField]
        public float? m_AmbientColorTemperature;

        [SerializeField]
        public float? m_AmbientIntensityInLumens;

        [SerializeField]
        public Color? m_ColorCorrection;

        [SerializeField]
        public float? m_MainLightBrightness;

        [SerializeField]
        public Color? m_MainLightColor;

        [SerializeField]
        public Vector3? m_MainLightDirection;

        [SerializeField]
        public float? m_MainLightIntensityLumens;

        [SerializeField]
        public SphericalHarmonicsL2? m_SphericalHarmonics;

        public bool AreLightsEqual(MRLightEstimation other)
        {
            return m_AmbientBrightness == other.m_AmbientBrightness
                && m_AmbientColorTemperature == other.m_AmbientColorTemperature
                && m_AmbientIntensityInLumens == other.m_AmbientIntensityInLumens
                && m_ColorCorrection == other.m_ColorCorrection
                && m_MainLightBrightness == other.m_MainLightBrightness
                && m_MainLightColor == other.m_MainLightColor
                && m_MainLightIntensityLumens == other.m_MainLightIntensityLumens
                && m_MainLightDirection == other.m_MainLightDirection
                && m_SphericalHarmonics == other.m_SphericalHarmonics;
        }
    }
}

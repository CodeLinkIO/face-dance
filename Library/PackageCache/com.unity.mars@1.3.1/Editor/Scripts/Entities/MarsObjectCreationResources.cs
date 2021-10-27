using System;
using Unity.MARS.Data.Synthetic;
using Unity.XRTools.Utils;
using UnityEditor.MARS;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.MARS
{
    class MarsObjectCreationResources : EditorScriptableSettings<MarsObjectCreationResources>
    {
#pragma warning disable 649
        [Header("Primitives")]
        [SerializeField]
        ObjectCreationData m_ProxyObjectPreset;

        [SerializeField]
        ObjectCreationData m_ProxyGroupPreset;

        [SerializeField]
        ObjectCreationData m_ReplicatorPreset;

        [FormerlySerializedAs("m_SyntheticPreset")]
        [SerializeField]
        ObjectCreationData m_SyntheticObjectPreset;

        [Header("Presets")]
        [SerializeField]
        ObjectCreationData m_HorizontalPlanePreset;

        [SerializeField]
        ObjectCreationData m_VerticalPlanePreset;

        [SerializeField]
        ObjectCreationData m_ImageMarkerPreset;

        [SerializeField]
        ObjectCreationData m_FaceMaskPreset;
        
        [SerializeField]
        ObjectCreationData m_BodyPreset;

        [SerializeField]
        ObjectCreationData m_ElevatedSurfaceObjectPreset;

        [SerializeField]
        ObjectCreationData m_FloorObjectPreset;

        [Header("Visualizers")]
        [SerializeField]
        ObjectCreationData m_PlaneVisualsPreset;

        [SerializeField]
        ObjectCreationData m_PointCloudVisualsPreset;

        [SerializeField]
        ObjectCreationData m_FaceLandmarkVisualsPreset;

        [SerializeField]
        ObjectCreationData m_LightEstimationVisualPreset;

        [Header("Simulated")]
        [SerializeField]
        ObjectCreationData m_SyntheticImageMarkerPreset;

        [SerializeField] 
        ObjectCreationData m_SyntheticBodyPreset;
        
        [Header("Other")]
        [SerializeField]
        SynthesizedPlane m_GeneratedSimulatedPlane;
#pragma warning restore 649
        // Primitives
        public ObjectCreationData ProxyObjectPreset => m_ProxyObjectPreset;
        public ObjectCreationData ProxyGroupPreset => m_ProxyGroupPreset;
        public ObjectCreationData ReplicatorPreset => m_ReplicatorPreset;
        public ObjectCreationData SyntheticObjectPreset => m_SyntheticObjectPreset;

        // Presets
        public ObjectCreationData HorizontalPlanePreset => m_HorizontalPlanePreset;
        public ObjectCreationData VerticalPlanePreset => m_VerticalPlanePreset;
        public ObjectCreationData ImageMarkerPreset => m_ImageMarkerPreset;
        public ObjectCreationData FaceMaskPreset => m_FaceMaskPreset;
        public ObjectCreationData BodyPreset => m_BodyPreset;
        public ObjectCreationData FloorObjectPreset => m_FloorObjectPreset;
        public ObjectCreationData ElevatedSurfacePreset => m_ElevatedSurfaceObjectPreset;

        // Visualizers
        public ObjectCreationData PlaneVisualsPreset => m_PlaneVisualsPreset;
        public ObjectCreationData PointCloudVisualsPreset => m_PointCloudVisualsPreset;
        public ObjectCreationData FaceLandmarkVisualsPreset => m_FaceLandmarkVisualsPreset;
        public ObjectCreationData LightEstimationVisualsPreset => m_LightEstimationVisualPreset;

        // Simulated
        public ObjectCreationData SyntheticImageMarkerPreset => m_SyntheticImageMarkerPreset;
        public ObjectCreationData SyntheticBodyPreset => m_SyntheticBodyPreset;

        //Other
        public SynthesizedPlane GeneratedSimulatedPlanePrefab => m_GeneratedSimulatedPlane;
    }
}

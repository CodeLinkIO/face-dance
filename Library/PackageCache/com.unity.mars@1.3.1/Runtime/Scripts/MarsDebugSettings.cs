using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Settings
{
    /// <summary>
    /// MARS debug settings
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public class MarsDebugSettings : ScriptableSettings<MarsDebugSettings>
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Enables logging from the MARSSceneModule. Used to log modules and providers found when starting the MARSSceneModule.")]
        bool m_SceneModuleLogging;

        [SerializeField]
        [Tooltip("Enables logging from the GeoLocationsModule")]
        bool m_GeolocationModuleLogging;

        [SerializeField]
        [Tooltip("Enables logging from the QuerySimulationModule")]
        bool m_QuerySimulationModuleLogging;

        [SerializeField]
        [Tooltip("Enables logging from the <SimulatedObjectManager")]
        bool m_SimObjectsManagerLogging;

        [SerializeField]
        [Tooltip("Enables logging for simulation plane finding")]
        bool m_SimPlaneFindingLogging;

        [SerializeField]
        [Tooltip("Enables selection of interaction targets for debugging")]
        bool m_AllowInteractionTargetSelection;

        [SerializeField]
        [Tooltip("Enables drawing debug plane vertices")]
        bool m_SimDiscoveryPointCloudDebug;

        [SerializeField]
        [Tooltip("Enables drawing debug plane vertices")]
        bool m_SimDiscoveryPlaneVerticesDebug;

        [SerializeField]
        [Tooltip("Enables drawing debug plane extents")]
        bool m_SimDiscoveryPlaneExtentsDebug;

        [SerializeField]
        [Tooltip("Enables drawing debug plane center")]
        bool m_SimDiscoveryPlaneCenterDebug;

        [SerializeField]
        [Tooltip("Enables drawing debug voxels")]
        bool m_SimDiscoveryVoxelsDebug;

        [SerializeField]
        [Tooltip("Enables drawing debug image marker")]
        bool m_SimDiscoveryImageMarkerDebug;
#pragma warning restore 649

        [SerializeField]
        [Tooltip("How long to draw the point cloud ray gizmo")]
        float m_SimDiscoveryPointCloudRayGizmoTime = 0.5f;

        /// <summary>
        /// Enables logging from the <c>MARSSceneModule</c>. Used to log modules and providers found when starting the <c>MARSSceneModule</c>
        /// </summary>
        public static bool SceneModuleLogging => instance.m_SceneModuleLogging;

        /// <summary>
        /// Enables logging from the <c>GeoLocationsModule</c>
        /// </summary>
        public static bool GeoLocationModuleLogging => instance.m_GeolocationModuleLogging;

        /// <summary>
        /// Enables logging from the <c>QuerySimulationModule</c>
        /// </summary>
        public static bool QuerySimulationModuleLogging => instance.m_QuerySimulationModuleLogging;

        /// <summary>
        /// Enables logging from the <c>SimulatedObjectManager</c>
        /// </summary>
        public static bool SimObjectsManagerLogging => instance.m_SimObjectsManagerLogging;

        /// <summary>
        /// Enables logging for simulation plane finding
        /// </summary>
        public static bool SimPlaneFindingLogging => instance.m_SimPlaneFindingLogging;

        /// <summary>
        /// Enables drawing debug plane vertices
        /// </summary>
        public static bool SimDiscoveryPointCloudDebug => instance.m_SimDiscoveryPointCloudDebug;
        /// <summary>
        /// How long to draw the point cloud ray gizmo
        /// </summary>
        public static float SimDiscoveryPointCloudRayGizmoTime => instance.m_SimDiscoveryPointCloudRayGizmoTime;
        /// <summary>
        /// Enables drawing debug plane vertices
        /// </summary>
        public static bool SimDiscoveryModulePlaneVerticesDebug => instance.m_SimDiscoveryPlaneVerticesDebug;
        /// <summary>
        /// Enables drawing debug plane extents
        /// </summary>
        public static bool SimDiscoveryModulePlaneExtentsDebug => instance.m_SimDiscoveryPlaneExtentsDebug;
        /// <summary>
        /// Enables drawing debug plane center
        /// </summary>
        public static bool SimDiscoveryModulePlaneCenterDebug => instance.m_SimDiscoveryPlaneCenterDebug;
        /// <summary>
        /// Enables drawing debug voxels
        /// </summary>
        public static bool SimDiscoveryVoxelsDebug => instance.m_SimDiscoveryVoxelsDebug;
        /// <summary>
        /// Enables drawing debug image marker
        /// </summary>
        public static bool SimDiscoveryImageMarkerDebug => instance.m_SimDiscoveryImageMarkerDebug;

        /// <summary>
        /// Enables selection of interaction targets for debugging
        /// </summary>
        public static bool allowInteractionTargetSelection => instance.m_AllowInteractionTargetSelection;
    }
}

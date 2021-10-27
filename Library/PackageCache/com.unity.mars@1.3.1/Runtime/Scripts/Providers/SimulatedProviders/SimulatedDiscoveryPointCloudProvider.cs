using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Random = UnityEngine.Random;

namespace Unity.MARS.Providers.Synthetic
{
#if UNITY_EDITOR
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority, disallowAutoCreation:true)]
    [MovedFrom("Unity.MARS")]
    public class SimulatedDiscoveryPointCloudProvider : MonoBehaviour, IProvidesPointCloud, IUsesCameraOffset
    {
#pragma warning disable 649
        [SerializeField]
        SimulatedDiscoverySessionProvider m_SessionProvider;
#pragma warning restore 649

        [SerializeField]
        float m_MinimumRecastTime = 0.15f;

        [SerializeField]
        float m_DistanceToRecast = 0.025f;

        [SerializeField]
        float m_AngleDegreesToRecast = 4f;

        [SerializeField]
        int m_RaysPerCast = 256;

        [SerializeField]
        float m_MaxHitDistance = 2f;

        [SerializeField]
        float m_MinHitDistance = 0.05f;        // don't detect points closer than 5 cm to camera

        static readonly Vector3 k_Forward = Vector3.forward;
        static readonly Color k_RayHitColor = new Color(0f, 1f, 0f, 0.5f);
        static readonly Color k_RayMissColor = new Color(1f, 0f, 0f, 0.1f);

        Camera m_Camera;
        Pose m_CameraPose;
        Pose m_PreviousCameraPose;
        bool m_Paused;

        float m_LastCastTime;
        MarsTrackableId m_TrackableId = MarsTrackableId.Create();
        IProvidesSessionControl m_ProvidesSessionControl;

        NativeArray<ulong> m_Identifiers;
        NativeArray<Vector3> m_Positions;
        NativeArray<float> m_ConfidenceValues;

        readonly List<Vector3> m_Normals = new List<Vector3>();
        readonly Dictionary<MarsTrackableId, PointCloudData> m_Data = new Dictionary<MarsTrackableId, PointCloudData>();
        readonly Dictionary<MarsTrackableId, List<Vector3>> m_NormalData = new Dictionary<MarsTrackableId, List<Vector3>>();

        RaycastHit[] m_RaycastHits = new RaycastHit[0];
        Ray[] m_Raycasts = new Ray[0];

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        public event Action<Dictionary<MarsTrackableId, PointCloudData>> PointCloudUpdated;

        public void StopDetectingPoints() { m_Paused = true; }
        public void StartDetectingPoints() { m_Paused = false; }

        void OnEnable()
        {
            EditorOnlyEvents.onTemporalSimulationStart += OnTemporalSimulationStart;
            m_ProvidesSessionControl = m_SessionProvider;
        }

        void OnDisable()
        {
            EditorOnlyEvents.onTemporalSimulationStart -= OnTemporalSimulationStart;
            MarsTime.MarsUpdate -= OnMarsUpdate;
            ClearPoints();
            m_Paused = false;
            m_LastCastTime = 0f;
        }

        void Start()
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            Initialize();
        }

        void OnTemporalSimulationStart()
        {
            // We can't just initialize in Start, since it's possible for this provider's runInEditMode
            // state to persist between simulations.
            Initialize();
        }

        void Initialize()
        {
            m_Camera = MarsRuntimeUtils.GetActiveCamera(true);

            m_PreviousCameraPose = m_Camera != null ? m_Camera.transform.GetWorldPose() : default;
            m_NormalData[m_TrackableId] = m_Normals;
            MarsTime.MarsUpdate += OnMarsUpdate;
        }

        void OnMarsUpdate()
        {
            // TODO subscribe to IProvidesSessionControl
            if (m_Camera == null || m_Paused || m_SessionProvider && !m_ProvidesSessionControl.SessionRunning())
                return;

            m_CameraPose = m_Camera.transform.GetWorldPose();

            if (!ShouldRecast())
                return;

            m_PreviousCameraPose = m_CameraPose;

            SimulationRaycastHits();
            CompleteRayCastHits();
        }

        internal void CompleteRayCastHits()
        {
            m_Normals.Clear();

            var scaledMinimumDistance = m_MinHitDistance * this.GetCameraScale();

            var length = m_Raycasts.Length;
            m_Normals.EnsureCapacity(length);
            NativeArrayUtils.EnsureCapacity(ref m_Identifiers, length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            NativeArrayUtils.EnsureCapacity(ref m_Positions, length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            NativeArrayUtils.EnsureCapacity(ref m_ConfidenceValues, length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

            var hitCount = 0;
            for (var i = 0; i < length; i++)
            {
                var result = m_RaycastHits[i];
                if (result.collider == null)
                    continue;

                if (result.distance < scaledMinimumDistance)
                    continue;

                m_Normals.Add(this.ApplyInverseOffsetToDirection(result.normal));
                m_Identifiers[hitCount] = (ulong)i;
                m_Positions[hitCount] = this.ApplyInverseOffsetToPosition(result.point);
                m_ConfidenceValues[hitCount] = Random.Range(0f, 1f);
                hitCount++;
            }

            var data = new PointCloudData
            {
                Identifiers = new NativeSlice<ulong>(m_Identifiers, 0, hitCount),
                Positions = new NativeSlice<Vector3>(m_Positions, 0, hitCount),
                ConfidenceValues = new NativeSlice<float>(m_ConfidenceValues, 0, hitCount)
            };

            m_Data[m_TrackableId] = data;

            if (PointCloudUpdated != null)
                PointCloudUpdated(GetPoints());
        }

        internal void SimulationRaycastHits()
        {
            var cameraTransform = m_Camera.transform;
            var origin = cameraTransform.position;

            var fov = m_Camera.fieldOfView * 0.5f;
            var rotation = cameraTransform.rotation;
            var mask = SimulationConstants.SimulatedEnvironmentLayerMask;

            var horizontalFOV = m_Camera.GetHorizontalFOV();
            var scaledMaxHitDistance = m_MaxHitDistance * this.GetCameraScale();

            if (m_RaycastHits.Length != m_RaysPerCast)
                m_RaycastHits = new RaycastHit[m_RaysPerCast];

            if (m_Raycasts.Length != m_RaysPerCast)
                m_Raycasts = new Ray[m_RaysPerCast];

            var simScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene();
            if (!simScene.IsValid())
                return;

            var physicScene = simScene.GetPhysicsScene();

            if (!physicScene.IsValid())
                return;

            for (var i = 0; i < m_RaysPerCast; i++)
            {
                var direction = FrustumRay(fov, horizontalFOV, rotation);

                RaycastHit hit;
                m_Raycasts[i] = new Ray(origin, direction);
                physicScene.Raycast(m_Raycasts[i].origin, m_Raycasts[i].direction, out hit, scaledMaxHitDistance, mask);

                m_RaycastHits[i] = hit;
            }

            m_LastCastTime = MarsTime.Time;
        }

        static Vector3 FrustumRay(float fov, float horizontalCameraFov, Quaternion rotation)
        {
            var x = Random.Range(-fov, fov);
            var y = Random.Range(-horizontalCameraFov, horizontalCameraFov);
            var noiseRotation = Quaternion.Euler(x, y, 0);
            return rotation * noiseRotation * k_Forward;
        }

        bool ShouldRecast()
        {
            if (MarsTime.Time - m_LastCastTime < m_MinimumRecastTime)
                return false;

            if (Vector3.Distance(m_PreviousCameraPose.position, m_CameraPose.position) > m_DistanceToRecast * this.GetCameraScale())
                return true;

            if (Quaternion.Angle(m_PreviousCameraPose.rotation, m_CameraPose.rotation) > m_AngleDegreesToRecast)
                return true;

            return false;
        }

        void IFunctionalityProvider.LoadProvider()
        {
            m_Identifiers = new NativeArray<ulong>(m_RaysPerCast, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            m_Positions = new NativeArray<Vector3>(m_RaysPerCast, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            m_ConfidenceValues = new NativeArray<float>(m_RaysPerCast, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesPointCloud>(obj);
        }

        void IFunctionalityProvider.UnloadProvider()
        {
            if (m_Identifiers.IsCreated)
                m_Identifiers.Dispose();

            if (m_Positions.IsCreated)
                m_Positions.Dispose();

            if(m_ConfidenceValues.IsCreated)
                m_ConfidenceValues.Dispose();
        }

        public Dictionary<MarsTrackableId, PointCloudData> GetPoints() { return m_Data; }

        public Dictionary<MarsTrackableId, List<Vector3>> GetNormals() { return m_NormalData; }

        void OnDrawGizmos()
        {
            if (!MarsDebugSettings.SimDiscoveryPointCloudDebug || m_LastCastTime == 0f ||
                MarsTime.Time - m_LastCastTime > MarsDebugSettings.SimDiscoveryPointCloudRayGizmoTime)
            {
                return;
            }

            var scaledMaxHitDistance = m_MaxHitDistance * this.GetCameraScale();

            var gizmosColor = Gizmos.color;

            for (var i = 0; i < m_RaycastHits.Length; i++)
            {
                var result = m_RaycastHits[i];
                var didHit = result.collider != null;
                var endpoint = didHit ? result.point : m_Raycasts[i].origin + m_Raycasts[i].direction * scaledMaxHitDistance;

                Gizmos.color = didHit ? k_RayHitColor : k_RayMissColor;
                Gizmos.DrawLine(m_Raycasts[i].origin, endpoint);
            }

            Gizmos.color = gizmosColor;
        }

        public void ClearPoints()
        {
            m_Normals.Clear();
            m_Data[m_TrackableId] = new PointCloudData
            {
                Identifiers = new NativeSlice<ulong>(m_Identifiers, 0, 0),
                Positions = new NativeSlice<Vector3>(m_Positions, 0, 0),
                ConfidenceValues = new NativeSlice<float>(m_ConfidenceValues, 0, 0)
            };
        }
    }
#else
    public class SimulatedDiscoveryPointCloudProvider : MonoBehaviour
    {
        [SerializeField]
        SimulatedDiscoverySessionProvider m_SessionProvider;

        [SerializeField]
        float m_MinimumRecastTime;

        [SerializeField]
        float m_DistanceToRecast;

        [SerializeField]
        float m_AngleDegreesToRecast;

        [SerializeField]
        int m_RaysPerCast;

        [SerializeField]
        float m_MaxHitDistance;

        [SerializeField]
        float m_MinHitDistance;
    }
#endif
}

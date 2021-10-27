using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

#if INCLUDE_AR_FOUNDATION_3_OR_NEWER
using UnityEngine.XR.ARFoundation;
#endif
#if INCLUDE_LEGACY_INPUT_HELPERS
using UnityEngine.SpatialTracking;
#endif

namespace Unity.MARS
{
    /// <summary>
    /// The camera controller for MARS
    /// This behavior subscribes to IUsesCameraPose and IUsesCameraProjectionMatrix to update the main Camera and its
    /// Transform. It is automatically added to the camera when MARSSession sets itself up and must remain present in
    /// the scene for MARS to work.
    /// </summary>
    [AddComponentMenu("")]
    [RequireComponent(typeof(Camera))]
    [MovedFrom("Unity.MARS.Behaviors")]
    public class MARSCamera : MonoBehaviour, IUsesCameraPose, IUsesCameraProjectionMatrix, IUsesFunctionalityInjection,
        ISimulatable
    {
        class CameraIntrinsicsSubscriber : IUsesCameraIntrinsics
        {
            IProvidesCameraIntrinsics IFunctionalitySubscriber<IProvidesCameraIntrinsics>.provider { get; set; }
        }

#pragma warning disable 649
        [SerializeField]
        GameObject m_TrackingWarning;
#pragma warning restore 649

        Camera m_Camera;
        bool m_Initialized;
#if UNITY_EDITOR
        int m_ScreenWidth;
        int m_ScreenHeight;
        bool m_CameraSetup;
#endif

        readonly CameraIntrinsicsSubscriber m_IntrinsicsSubscriber = new CameraIntrinsicsSubscriber();

        IProvidesCameraPose IFunctionalitySubscriber<IProvidesCameraPose>.provider { get; set; }
        IProvidesCameraProjectionMatrix IFunctionalitySubscriber<IProvidesCameraProjectionMatrix>.provider { get; set; }
        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        internal Camera MarsCamera
        {
            get
            {
#if UNITY_EDITOR
                if (!m_CameraSetup)
                {
                    m_Camera = GetComponent<Camera>();
                    m_CameraSetup = true;
                }
#endif
                return m_Camera;
            }
        }

        /// <summary>
        /// If true, MARSCamera will not update the pose of its transform
        /// </summary>
        public bool DisablePoseDriving { get; set; }

        void OnEnable()
        {
            if (this.HasProvider<IProvidesCameraPose>())
                EnsureInitialized();
        }

        void EnsureInitialized()
        {
            if (m_Initialized)
                return;

            m_Initialized = true;
            if (Application.isPlaying)
            {
#if INCLUDE_AR_FOUNDATION_3_OR_NEWER
                if (GetComponent<ARPoseDriver>() != null)
                    DisablePoseDriving = true;
#endif

#if INCLUDE_LEGACY_INPUT_HELPERS
                if (GetComponent<TrackedPoseDriver>() != null)
                    DisablePoseDriving = true;
#endif
            }

            if (!DisablePoseDriving)
                this.SubscribePoseUpdated(OnPoseUpdated);

            m_Camera = GetComponent<Camera>();

            // Composite Camera Rendering handles setting clear flags in editor
            if (!Application.isEditor)
            {
                m_Camera.clearFlags = CameraClearFlags.SolidColor;
                m_Camera.backgroundColor = Color.black;
            }

            if (m_TrackingWarning)
                this.SubscribeTrackingTypeChanged(OnTrackingStateChanged);

            var projectionMatrix = this.GetProjectionMatrix();
            if (projectionMatrix.HasValue)
                m_Camera.projectionMatrix = projectionMatrix.Value;

            if (!DisablePoseDriving)
                transform.SetLocalPose(this.GetPose());

            this.InjectFunctionalitySingle(m_IntrinsicsSubscriber);
            if (m_IntrinsicsSubscriber.HasProvider())
            {
                var fov = m_IntrinsicsSubscriber.GetFieldOfView();
                if (fov.HasValue)
                    SetFOV(fov.Value);

                m_IntrinsicsSubscriber.SubscribeFieldOfViewUpdated(SetFOV);
            }
        }

        void OnDisable()
        {
            m_Initialized = false;
            this.UnsubscribePoseUpdated(OnPoseUpdated);
            this.UnsubscribeTrackingTypeChanged(OnTrackingStateChanged);
            if (m_IntrinsicsSubscriber.HasProvider())
                m_IntrinsicsSubscriber.UnsubscribeFieldOfViewUpdated(SetFOV);
        }

        void Start()
        {
            EnsureInitialized();
        }

#if UNITY_EDITOR
        void Update()
        {
            // Need to unlock the projection matrix if the screen size changes
            if (m_ScreenWidth != Screen.width || m_ScreenHeight != Screen.height)
            {
                m_Camera.ResetProjectionMatrix();
                m_ScreenWidth = Screen.width;
                m_ScreenHeight = Screen.height;
            }
        }
#endif

        void OnTrackingStateChanged(MRCameraTrackingState state)
        {
            switch (state)
            {
                case MRCameraTrackingState.Normal:
                    m_TrackingWarning.SetActive(false);
                    break;
                default:
                    m_TrackingWarning.SetActive(true);
                    break;
            }
        }

        void OnPoseUpdated(Pose pose)
        {
            var projectionMatrix = this.GetProjectionMatrix();
            if (projectionMatrix.HasValue)
                m_Camera.projectionMatrix = projectionMatrix.Value;

            transform.SetLocalPose(pose);
        }

        void SetFOV(float fov)
        {
            // Need to make sure projection matrix is reset if it was overridden
            // or else the field of view value is ignored
            m_Camera.ResetProjectionMatrix();
            m_Camera.fieldOfView = fov;
        }
    }
}

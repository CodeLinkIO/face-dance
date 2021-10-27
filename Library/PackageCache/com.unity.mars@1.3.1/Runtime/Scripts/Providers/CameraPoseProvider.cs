using System;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

#if INCLUDE_LEGACY_INPUT_HELPERS
using UnityEngine.SpatialTracking;
#endif

namespace Unity.MARS.Providers
{
    [ProviderSelectionOptions(ProviderPriorities.PreferredPriority)]
    public class CameraPoseProvider :
#if INCLUDE_LEGACY_INPUT_HELPERS
        TrackedPoseDriver,
#else
        MonoBehaviour,
#endif
        IProvidesCameraPose, IUsesCameraOffset
    {
        const float k_MoveSpeed = 0.1f;
        const float k_SpeedBoost = 10f;
        const float k_TurnSpeed = 10f;

        /// <inheritdoc />
        public event Action<Pose> poseUpdated;
#pragma warning disable 67 // TODO: See about getting tracking state from TrackedPoseDriver
        /// <inheritdoc />
        public event Action<MRCameraTrackingState> trackingStateChanged;
#pragma warning restore 67

        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        bool m_WasMouseDownLastFrame;
        Vector3 m_LastMousePosition;
        Vector3 m_EulerAngles;

        void Start()
        {
#if INCLUDE_LEGACY_INPUT_HELPERS
            SetPoseSource(DeviceType.GenericXRDevice, TrackedPose.ColorCamera);
            UseRelativeTransform = false;
#endif

            var marsCamera = MarsRuntimeUtils.GetActiveCamera(true);

            if (marsCamera)
            {
                var cameraTransform = marsCamera.transform;
                var cameraParent = cameraTransform.parent;
                if (!cameraParent)
                {
                    cameraParent = new GameObject("XRCameraRig").transform;
                    cameraTransform.parent = cameraParent;
                }

                transform.SetParent(cameraParent, false);
            }
        }

        /// <inheritdoc />
        void IFunctionalityProvider.LoadProvider() { }

        /// <inheritdoc />
        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesCameraPose>(obj);
        }

        /// <inheritdoc />
        void IFunctionalityProvider.UnloadProvider() { }

        /// <inheritdoc />
        public Pose GetCameraPose()
        {
            return transform.GetLocalPose();
        }

#if INCLUDE_LEGACY_INPUT_HELPERS
        /// <inheritdoc />
        protected override void PerformUpdate()
#else
        [Obsolete("PerformUpdate should only be used when INCLUDE_LEGACY_INPUT_HELPERS is defined.", true)]
        /// <inheritdoc />
        protected virtual void PerformUpdate(){}

        void Update()
#endif
        {
#if UNITY_EDITOR
            var moveSpeed = this.GetCameraScale() * k_MoveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
                moveSpeed *= k_SpeedBoost;

            var cameraPose = GetCameraPose();
            var forward = cameraPose.rotation * Vector3.forward;
            var right = cameraPose.rotation * Vector3.right;
            var up = cameraPose.rotation * Vector3.up;

            if (Input.GetKey(KeyCode.W))
                cameraPose.position += forward * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.S))
                cameraPose.position -= forward * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.A))
                cameraPose.position -= right * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.D))
                cameraPose.position += right * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.Q))
                cameraPose.position += up * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.Z))
                cameraPose.position -= up * Time.deltaTime * moveSpeed;

            if (Input.GetMouseButton(1))
            {
                if (!m_WasMouseDownLastFrame)
                    m_LastMousePosition = Input.mousePosition;

                var deltaPosition = Input.mousePosition - m_LastMousePosition;
                var turnSpeed = Time.deltaTime * k_TurnSpeed;
                m_EulerAngles.y += turnSpeed * deltaPosition.x;
                m_EulerAngles.x -= turnSpeed * deltaPosition.y;
                cameraPose.rotation = Quaternion.Euler(m_EulerAngles);
                m_LastMousePosition = Input.mousePosition;
                m_WasMouseDownLastFrame = true;
            }
            else
            {
                m_WasMouseDownLastFrame = false;
            }

            transform.SetLocalPose(cameraPose);
#elif INCLUDE_LEGACY_INPUT_HELPERS
            base.PerformUpdate();
#endif

            if (poseUpdated != null)
                poseUpdated(GetCameraPose());

            //TODO: Tracking state
        }
    }
}

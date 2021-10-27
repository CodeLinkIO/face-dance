using System;
using Unity.MARS.Data;
using Unity.MARS.Data.Synthetic;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers.Synthetic
{
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    [MovedFrom("Unity.MARS.Providers")]
    public class SimulatedCameraPoseProvider : MonoBehaviour, IProvidesCameraPose, IUsesDeviceSimulationSettings
    {
        [SerializeField]
        bool m_UseMovementBoundsInGame = true;

        CameraFPSModeHandler m_FPSModeHandler;

        /// <inheritdoc />
        public event Action<Pose> poseUpdated;
#pragma warning disable 67
        /// <inheritdoc />
        public event Action<MRCameraTrackingState> trackingStateChanged;
#pragma warning restore 67

        IProvidesDeviceSimulationSettings IFunctionalitySubscriber<IProvidesDeviceSimulationSettings>.provider { get; set; }

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
        public Pose GetCameraPose() { return transform.GetLocalPose(); }

        void OnEnable()
        {
            if (Application.isPlaying)
            {
                m_FPSModeHandler = new CameraFPSModeHandler();
                this.SubscribeEnvironmentChanged(OnEnvironmentChanged);
                return;
            }

            transform.SetWorldPose(this.GetDeviceStartingPose());
        }

        void OnDisable()
        {
            if (Application.isPlaying)
                this.UnsubscribeEnvironmentChanged(OnEnvironmentChanged);
        }

        void OnEnvironmentChanged()
        {
            if (Application.isPlaying)
            {
                transform.SetWorldPose(this.GetDeviceStartingPose());
                poseUpdated?.Invoke(GetCameraPose());
            }
        }

        void Update()
        {
            if (!this.GetIsMovementEnabled())
                return;

            var playing = Application.isPlaying;
            var fpsModeContext = playing ? m_FPSModeHandler : CameraFPSModeHandler.activeHandler;

            if (fpsModeContext == null)
                return;

            if (playing)
            {
                fpsModeContext.UseMovementBounds = m_UseMovementBoundsInGame;
                fpsModeContext.MovementBounds = this.GetEnvironmentBounds();
                fpsModeContext.HandleGameInput();
            }

            if (!fpsModeContext.MoveActive)
                return;

            var pose = fpsModeContext.CalculateMovement(transform.GetWorldPose(), playing);
            transform.SetWorldPose(pose);
            if (poseUpdated != null)
                poseUpdated(GetCameraPose());
        }
    }
}

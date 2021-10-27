using System;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers.Synthetic
{
    [ProviderSelectionOptions(ProviderPriorities.SimulatedProviderPriority)]
    [MovedFrom("Unity.MARS.Providers")]
    class SimulatedCameraViewProvider : MonoBehaviour, IProvidesCameraTexture, IProvidesCameraIntrinsics,
        IProvidesCameraProjectionMatrix, IUsesSimulationVideoFeed
    {
        Texture m_VideoTexture;

        float? m_FOV;

        Camera m_ActiveCamera;

        IProvidesSimulationVideoFeed IFunctionalitySubscriber<IProvidesSimulationVideoFeed>.provider { get; set; }

        public CameraFacingDirection CameraFacingDirection => m_VideoTexture != null ? this.GetVideoFacingDirection() : CameraFacingDirection.World;

        public float FocalLength { get; private set; }

        public event Action<float> FieldOfViewUpdated;

        void IFunctionalityProvider.LoadProvider() { }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesCameraProjectionMatrix>(obj);
            this.TryConnectSubscriber<IProvidesCameraTexture>(obj);
            this.TryConnectSubscriber<IProvidesCameraIntrinsics>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() { }

        Texture IProvidesCameraTexture.GetCameraTexture() { return m_VideoTexture; }

        void IProvidesCameraTexture.RequestCameraFacingDirection(CameraFacingDirection facingDirection)
        {
            // Not implemented - video feed in simulation is either always user-facing or always world-facing
        }

        float? IProvidesCameraIntrinsics.GetFieldOfView() { return m_FOV; }

        Matrix4x4? IProvidesCameraProjectionMatrix.GetProjectionMatrix()
        {
            if (m_ActiveCamera == null)
                return null;

            return m_ActiveCamera.projectionMatrix;
        }

        void OnEnable()
        {
            var videoFeedTexture = this.GetVideoFeedTexture();
            if (videoFeedTexture != null)
                SetupFromVideoFeed(videoFeedTexture);

            this.SubscribeVideoFeedTextureCreated(SetupFromVideoFeed);
            m_ActiveCamera = MarsRuntimeUtils.GetActiveCamera();
        }

        void OnDisable()
        {
            m_VideoTexture = null;
            m_FOV = null;
            this.UnsubscribeVideoFeedTextureCreated(SetupFromVideoFeed);
        }

        void SetupFromVideoFeed(Texture videoFeedTexture)
        {
            m_VideoTexture = videoFeedTexture;
            FocalLength = this.GetVideoFocalLength();
            var halfHeight = videoFeedTexture.height * 0.5f;
            var halfFOV = Mathf.Atan(halfHeight / FocalLength) * Mathf.Rad2Deg;
            m_FOV = halfFOV * 2f;
            FieldOfViewUpdated?.Invoke(m_FOV.Value);
        }
    }
}

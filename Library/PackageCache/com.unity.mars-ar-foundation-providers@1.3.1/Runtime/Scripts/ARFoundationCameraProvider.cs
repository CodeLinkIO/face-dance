#if ARFOUNDATION_2_1_OR_NEWER
using Unity.MARS.MARSUtils;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARFoundation;
using UnityObject = UnityEngine.Object;

#if ARFOUNDATION_4_OR_NEWER
using ARFoundationCameraFacingDirection = UnityEngine.XR.ARFoundation.CameraFacingDirection;
#else
using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;
#endif

using CameraFacingDirection = Unity.MARS.Data.CameraFacingDirection;

namespace Unity.MARS.Providers.ARFoundation
{
    [ProviderSelectionOptions(excludedPlatforms: new []{
        RuntimePlatform.WindowsEditor,
        RuntimePlatform.OSXEditor,
        RuntimePlatform.LinuxEditor,
        RuntimePlatform.WindowsPlayer,
        RuntimePlatform.OSXPlayer,
        RuntimePlatform.LinuxPlayer
    })]
    [MovedFrom("Unity.MARS.Providers")]
    public class ARFoundationCameraProvider : IProvidesCameraTexture, IProvidesCameraProjectionMatrix
    {
        ARCameraManager m_NewARCameraManager;
        ARCameraManager m_ARCameraManager;
        ARCameraBackground m_ARCameraBackground;
        ARCameraBackground m_NewARCameraBackground;

        int m_CameraWidth;
        int m_CameraHeight;
        Matrix4x4? m_CurrentProjectionMatrix;

        // Texture returned to the user by GetCameraTexture(), reused on subsequent calls.
        RenderTexture m_RenderTexture;
        bool m_RenderTextureDirty;

#if !ARFOUNDATION_4_OR_NEWER
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        // Reference type collections must also be cleared after use
        static readonly List<XRFaceSubsystem> k_FaceSubsystems = new List<XRFaceSubsystem>();
#endif

        public CameraFacingDirection CameraFacingDirection
        {
            get
            {
#if ARFOUNDATION_4_OR_NEWER
                switch (m_ARCameraManager.currentFacingDirection)
                {
                    case UnityEngine.XR.ARFoundation.CameraFacingDirection.User:
                        return CameraFacingDirection.User;
                    case UnityEngine.XR.ARFoundation.CameraFacingDirection.World:
                        return CameraFacingDirection.World;
                    default:
                        return CameraFacingDirection.None;
                }
#else
                k_FaceSubsystems.Clear();
                SubsystemManager.GetInstances(k_FaceSubsystems);
                var direction = CameraFacingDirection.World;
                foreach (var faceSubsystem in k_FaceSubsystems)
                {
                    if (faceSubsystem.running)
                    {
                        direction = CameraFacingDirection.User;
                        break;
                    }
                }

                k_FaceSubsystems.Clear();
                return direction;
#endif
            }
        }

        void IFunctionalityProvider.LoadProvider()
        {
            ARFoundationSessionProvider.RequireARSession();
            InitializeCameraProvider();
        }

        void InitializeCameraProvider()
        {
            var camera = MarsRuntimeUtils.GetActiveCamera(true);

            if (camera)
            {
                m_ARCameraBackground = camera.GetComponent<ARCameraBackground>();
                if (!m_ARCameraBackground)
                {
                    m_ARCameraBackground = camera.gameObject.AddComponent<ARCameraBackground>();
                    m_NewARCameraBackground = m_ARCameraBackground;
                    m_ARCameraBackground.hideFlags = HideFlags.DontSave;
                }

                m_ARCameraManager = camera.GetComponent<ARCameraManager>();

                if (!m_ARCameraManager)
                {
                    m_ARCameraManager = camera.gameObject.AddComponent<ARCameraManager>();
                    m_NewARCameraManager = m_ARCameraManager;
                    m_ARCameraManager.hideFlags = HideFlags.DontSave;
                }

                m_ARCameraManager.frameReceived += ARCameraManagerOnFrameReceived;
            }

            m_CurrentProjectionMatrix = null;
        }

        void ARCameraManagerOnFrameReceived(ARCameraFrameEventArgs cameraFrameEvent)
        {
            m_CurrentProjectionMatrix = cameraFrameEvent.projectionMatrix;

            if (cameraFrameEvent.textures.Count > 0)
            {
                var texture = cameraFrameEvent.textures[0];
                m_CameraWidth = texture.width;
                m_CameraHeight = texture.height;
                m_RenderTextureDirty = true;
            }
        }

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesCameraTexture>(obj);
            this.TryConnectSubscriber<IProvidesCameraProjectionMatrix>(obj);
        }

        void IFunctionalityProvider.UnloadProvider()
        {
            ShutdownCameraProvider();
            ARFoundationSessionProvider.TearDownARSession();
        }

        void ShutdownCameraProvider()
        {
            m_ARCameraManager.frameReceived -= ARCameraManagerOnFrameReceived;

            if (m_NewARCameraBackground)
                UnityObjectUtils.Destroy(m_NewARCameraBackground);

            if (m_NewARCameraManager)
                UnityObjectUtils.Destroy(m_NewARCameraManager);
        }

        Matrix4x4? IProvidesCameraProjectionMatrix.GetProjectionMatrix()
        {
            return m_CurrentProjectionMatrix;
        }

        Texture IProvidesCameraTexture.GetCameraTexture()
        {
            if (!m_RenderTexture || m_RenderTexture.width != m_CameraWidth || m_RenderTexture.height != m_CameraHeight)
            {
                if (m_CameraWidth == 0 || m_CameraHeight == 0)
                    return null;
                m_RenderTexture = new RenderTexture(m_CameraWidth, m_CameraHeight, 0);
            }

            if (m_RenderTextureDirty)
            {
                Graphics.Blit(null, m_RenderTexture, m_ARCameraBackground.material);
                m_RenderTextureDirty = false;
            }
            return m_RenderTexture;
        }

        void IProvidesCameraTexture.RequestCameraFacingDirection(CameraFacingDirection facingDirection)
        {
            // AR Foundation version 3 has no way to explicitly request which camera to use.
#if ARFOUNDATION_4_OR_NEWER
            UnityEngine.XR.ARFoundation.CameraFacingDirection arFoundationDirection;
            switch (facingDirection)
            {
                case CameraFacingDirection.User:
                    arFoundationDirection = ARFoundationCameraFacingDirection.User;
                    break;
                case CameraFacingDirection.World:
                    arFoundationDirection = ARFoundationCameraFacingDirection.World;
                    break;
                default:
                    arFoundationDirection = ARFoundationCameraFacingDirection.None;
                    break;
            }
            m_ARCameraManager.requestedFacingDirection = arFoundationDirection;
#endif
        }
    }
}
#endif

#if ARSUBSYSTEMS_2_1_OR_NEWER
using System;
using System.Runtime.InteropServices;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

#if ARSUBSYSTEMS_4_OR_NEWER
using UnityEngine.Rendering;
#endif

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Camera subsystem implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class CameraSubsystem : XRCameraSubsystem, IMarsXRSubsystem
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct XRCameraFrame
        {
            public long TimestampNs;
            public float AverageBrightness;
            public float AverageColorTemperature;
            public Color ColorCorrection;
            public Matrix4x4 ProjectionMatrix;
            public Matrix4x4 DisplayMatrix;
            public TrackingState TrackingState;
            public IntPtr NativePtr;
            public XRCameraFrameProperties Properties;

#if ARSUBSYSTEMS_3_OR_NEWER
            public float AverageIntensityInLumens;
            public double ExposureDuration;
            public float ExposureOffset;
#endif

#if ARSUBSYSTEMS_4_OR_NEWER
            public float MainLightIntensityLumens;
            public Color MainLightColor;
            public Vector3 MainLightDirection;
            public SphericalHarmonicsL2 AmbientSphericalHarmonics;
            public XRTextureDescriptor CameraGrain;
            public float NoiseIntensity;
#endif
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct XRCameraFrameUnion
        {
            [FieldOffset(0)]
            public XRCameraFrame m_OurXRCameraFrame;

            [FieldOffset(0)]
            public UnityEngine.XR.ARSubsystems.XRCameraFrame m_TheirXRCameraFrame;
        }

        IMarsXRSubscriber m_FunctionalitySubscriber;

        public IMarsXRSubscriber FunctionalitySubscriber
        {
            get
            {
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                if (m_FunctionalitySubscriber == null)
                    m_FunctionalitySubscriber = provider as IMarsXRSubscriber;
#endif

                return m_FunctionalitySubscriber;
            }
        }

#if !(ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER)
#if ARSUBSYSTEMS_3_OR_NEWER
        protected override Provider CreateProvider() => CreateMarsProvider();
#else
        protected override IProvider CreateProvider() => CreateMarsProvider();
#endif

        MARSXRProvider CreateMarsProvider()
        {
            var marsProvider = new MARSXRProvider();
            m_FunctionalitySubscriber = marsProvider;
            return marsProvider;
        }
#endif

#if ARSUBSYSTEMS_3_OR_NEWER
        class MARSXRProvider : Provider, IMarsXRSubscriber, IUsesCameraPose, IUsesLightEstimation
#else
        class MARSXRProvider : IProvider, IMarsXRSubscriber, IUsesCameraPose, IUsesLightEstimation
#endif
        {
            MRLightEstimation m_LastLightEstimation;

            IProvidesCameraPose IFunctionalitySubscriber<IProvidesCameraPose>.provider { get; set; }
            IProvidesLightEstimation IFunctionalitySubscriber<IProvidesLightEstimation>.provider { get; set; }
            public override bool permissionGranted => true;

            public void SubscribeToEvents()
            {
                PoseUpdated(this.GetPose());
                this.SubscribePoseUpdated(PoseUpdated);
                this.SubscribeTrackingTypeChanged(TrackingTypeChanged);
                this.SubscribeLightEstimationUpdated(LightEstimationUpdated);

                this.TryGetLightEstimation(out m_LastLightEstimation);
            }

            public void UnsubscribeFromEvents()
            {
                this.UnsubscribePoseUpdated(PoseUpdated);
                this.UnsubscribeTrackingTypeChanged(TrackingTypeChanged);
                this.UnsubscribeLightEstimationUpdated(LightEstimationUpdated);
            }

            static void PoseUpdated(Pose pose)
            {
                SetCameraPose(pose.position.x, pose.position.y, pose.position.z,
                    pose.rotation.x, pose.rotation.y, pose.rotation.z, pose.rotation.w);
            }

            static void TrackingTypeChanged(MRCameraTrackingState state) { }

            void LightEstimationUpdated(MRLightEstimation lightEstimation) { m_LastLightEstimation = lightEstimation; }

            public override bool TryGetFrame(XRCameraParams cameraParams, out UnityEngine.XR.ARSubsystems.XRCameraFrame cameraFrame)
            {
                var frame = new XRCameraFrame();
                XRCameraFrameProperties properties = 0;
                if (m_LastLightEstimation.m_AmbientBrightness.HasValue)
                {
                    frame.AverageBrightness = m_LastLightEstimation.m_AmbientBrightness.Value;
                    properties |= XRCameraFrameProperties.AverageBrightness;
                }

                if (m_LastLightEstimation.m_AmbientColorTemperature.HasValue)
                {
                    frame.AverageColorTemperature = m_LastLightEstimation.m_AmbientColorTemperature.Value;
                    properties |= XRCameraFrameProperties.AverageColorTemperature;
                }

                if (m_LastLightEstimation.m_ColorCorrection.HasValue)
                {
                    frame.ColorCorrection = m_LastLightEstimation.m_ColorCorrection.Value;
                    properties |= XRCameraFrameProperties.ColorCorrection;
                }

#if ARSUBSYSTEMS_3_OR_NEWER
                if (m_LastLightEstimation.m_AmbientIntensityInLumens.HasValue)
                {
                    frame.AverageIntensityInLumens = m_LastLightEstimation.m_AmbientIntensityInLumens.Value;
                    properties |= XRCameraFrameProperties.AverageIntensityInLumens;
                }
#endif

#if ARSUBSYSTEMS_4_OR_NEWER
                if (m_LastLightEstimation.m_MainLightColor.HasValue)
                {
                    frame.MainLightColor = m_LastLightEstimation.m_MainLightColor.Value;
                    properties |= XRCameraFrameProperties.MainLightColor;
                }

                if (m_LastLightEstimation.m_MainLightDirection.HasValue)
                {
                    frame.MainLightDirection = m_LastLightEstimation.m_MainLightDirection.Value;
                    properties |= XRCameraFrameProperties.MainLightDirection;
                }

                if (m_LastLightEstimation.m_MainLightIntensityLumens.HasValue)
                {
                    frame.MainLightIntensityLumens = m_LastLightEstimation.m_MainLightIntensityLumens.Value;
                    properties |= XRCameraFrameProperties.MainLightIntensityLumens;
                }

                if (m_LastLightEstimation.m_SphericalHarmonics.HasValue)
                {
                    frame.AmbientSphericalHarmonics = m_LastLightEstimation.m_SphericalHarmonics.Value;
                    properties |= XRCameraFrameProperties.AmbientSphericalHarmonics;
                }
#endif

                frame.Properties = properties;

                var union = new XRCameraFrameUnion { m_OurXRCameraFrame = frame };
                cameraFrame = union.m_TheirXRCameraFrame;
                return true;
            }

            // ReSharper disable InconsistentNaming
            [DllImport("MARSXRSubsystem", EntryPoint = "MARSXRSubsystem_SetCameraPose")]
            public static extern void SetCameraPose(float pos_x, float pos_y, float pos_z,
                float rot_x, float rot_y, float rot_z, float rot_w);
            // ReSharper restore InconsistentNaming
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Register()
        {
            XRCameraSubsystem.Register(new XRCameraSubsystemCinfo
            {
                id = "MARS-Camera",
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                providerType = typeof(CameraSubsystem.MARSXRProvider),
                subsystemTypeOverride = typeof(CameraSubsystem),
#else
                implementationType = typeof(CameraSubsystem),
#endif
            });
        }
    }
}
#endif

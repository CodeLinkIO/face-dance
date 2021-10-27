#if ARSUBSYSTEMS_2_1_OR_NEWER
using System;
using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.XRSubsystem
{
    class CameraSubsystemTest
    {
        // Check that our version of XRFace mirrors the layout of ARSubsystem.XRCameraFrame
        [Test]
        public void XRCameraFrameLayout()
        {
            var sphericalHarmonics = new UnityEngine.Rendering.SphericalHarmonicsL2();
            var f = 1000f;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    sphericalHarmonics[i, j] = f++;
                }
            }

            CameraSubsystem.XRCameraFrame[] frames =
            {
                new CameraSubsystem.XRCameraFrame
                {
                    TimestampNs = 1,
                    AverageBrightness = 2,
                    AverageColorTemperature = 3,
                    ColorCorrection = new Color(4, 5, 6),
                    ProjectionMatrix = new Matrix4x4(
                        new Vector4(7, 8, 9, 10),
                        new Vector4(11, 12, 13, 14),
                        new Vector4(15, 16, 17, 18),
                        new Vector4(19, 20, 21, 22)
                    ),
                    DisplayMatrix = new Matrix4x4(
                        new Vector4(23, 24, 25, 26),
                        new Vector4(27, 28, 29, 30),
                        new Vector4(31, 32, 33, 34),
                        new Vector4(35, 36, 37, 38)
                    ),
                    TrackingState = TrackingState.Tracking,
                    NativePtr = new IntPtr(39),
                    Properties = XRCameraFrameProperties.ProjectionMatrix,

#if ARSUBSYSTEMS_3_OR_NEWER
                    AverageIntensityInLumens = 40,
                    ExposureDuration = 41,
                    ExposureOffset = 42,
#endif

#if ARSUBSYSTEMS_4_OR_NEWER
                    MainLightIntensityLumens = 43,
                    MainLightColor = new Color(44, 45, 46),
                    MainLightDirection = new Vector3(47, 48, 49),
                    AmbientSphericalHarmonics = sphericalHarmonics,
                    CameraGrain = new XRTextureDescriptor(),
                    NoiseIntensity = 50,
#endif
                },
                new CameraSubsystem.XRCameraFrame
                {
                    AverageBrightness = 2,
                }
            };

            var nativeFrames = new NativeArray<XRCameraFrame>(2, Allocator.Temp);
            nativeFrames.Reinterpret<CameraSubsystem.XRCameraFrame>().CopyFrom(frames);

            Assert.AreEqual(frames[0].TimestampNs, nativeFrames[0].timestampNs);
            Assert.AreEqual(frames[0].AverageBrightness, nativeFrames[0].averageBrightness);
            Assert.AreEqual(frames[0].AverageColorTemperature, nativeFrames[0].averageColorTemperature);
            Assert.AreEqual(frames[0].ColorCorrection, nativeFrames[0].colorCorrection);
            Assert.AreEqual(frames[0].ProjectionMatrix, nativeFrames[0].projectionMatrix);
            Assert.AreEqual(frames[0].DisplayMatrix, nativeFrames[0].displayMatrix);
            Assert.AreEqual(frames[0].TrackingState, nativeFrames[0].trackingState);
            Assert.AreEqual(frames[0].NativePtr, nativeFrames[0].nativePtr);
            Assert.AreEqual(frames[0].Properties, nativeFrames[0].properties);

#if ARSUBSYSTEMS_3_OR_NEWER
            Assert.AreEqual(frames[0].AverageIntensityInLumens, nativeFrames[0].averageIntensityInLumens);
            Assert.AreEqual(frames[0].ExposureDuration, nativeFrames[0].exposureDuration);
            Assert.AreEqual(frames[0].ExposureOffset, nativeFrames[0].exposureOffset);
#endif

#if ARSUBSYSTEMS_4_OR_NEWER
            Assert.AreEqual(frames[0].MainLightIntensityLumens, nativeFrames[0].mainLightIntensityLumens);
            Assert.AreEqual(frames[0].MainLightColor, nativeFrames[0].mainLightColor);
            Assert.AreEqual(frames[0].MainLightDirection, nativeFrames[0].mainLightDirection);
            Assert.AreEqual(frames[0].AmbientSphericalHarmonics, nativeFrames[0].ambientSphericalHarmonics);
            Assert.AreEqual(frames[0].CameraGrain, nativeFrames[0].cameraGrain);
            Assert.AreEqual(frames[0].NoiseIntensity, nativeFrames[0].noiseIntensity);
#endif

            Assert.AreEqual(frames[1].AverageBrightness, nativeFrames[1].averageBrightness);
        }
    }
}
#endif

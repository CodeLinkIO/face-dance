#if ARSUBSYSTEMS_2_1_OR_NEWER
using System;
using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.XRSubsystem
{
    public class FaceSubsystemTest
    {
        // Check that our version of XRFace mirrors the layout of ARSubsystems.XRFace
        [Test]
        public void XRFaceStructLayout()
        {
            FaceSubsystem.XRFace[] faces = { new FaceSubsystem.XRFace()
            {
                m_TrackableId = new TrackableId(1, 2),
                m_Pose = new Pose(new Vector3(3, 4, 5), new Quaternion(6, 7, 8, 9)),
                m_TrackingState = TrackingState.Tracking,
                m_NativePtr = new IntPtr(10),
#if ARSUBSYSTEMS_3_OR_NEWER
                m_LeftEyePose = new Pose(new Vector3(11, 12, 13), new Quaternion(14, 15, 16, 17)),
                m_RightEyePose = new Pose(new Vector3(18, 19, 20), new Quaternion(21, 22, 23, 24)),
                m_FixationPoint = new Vector3(25, 26, 27),
#endif
            },
            new FaceSubsystem.XRFace()
            {
                m_TrackableId = new TrackableId(28, 29),
            }
            };

            var nativeFaces = new NativeArray<XRFace>(2, Allocator.Temp);
            nativeFaces.Reinterpret<FaceSubsystem.XRFace>().CopyFrom(faces);

            Assert.AreEqual(faces[0].m_TrackableId, nativeFaces[0].trackableId);
            Assert.AreEqual(faces[0].m_Pose, nativeFaces[0].pose);
            Assert.AreEqual(faces[0].m_TrackingState, nativeFaces[0].trackingState);
            Assert.AreEqual(faces[0].m_NativePtr, nativeFaces[0].nativePtr);
#if ARSUBSYSTEMS_3_OR_NEWER
            Assert.AreEqual(faces[0].m_LeftEyePose, nativeFaces[0].leftEyePose);
            Assert.AreEqual(faces[0].m_RightEyePose, nativeFaces[0].rightEyePose);
            Assert.AreEqual(faces[0].m_FixationPoint, nativeFaces[0].fixationPoint);
#endif

            Assert.AreEqual(faces[1].m_TrackableId, nativeFaces[1].trackableId);
        }
    }
}
#endif

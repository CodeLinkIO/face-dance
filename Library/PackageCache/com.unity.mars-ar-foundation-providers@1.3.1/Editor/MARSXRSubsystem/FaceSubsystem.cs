#if ARSUBSYSTEMS_2_1_OR_NEWER
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;

namespace Unity.MARS.XRSubsystem
{
    /// <summary>
    /// Face subsystem implementation for MARS XR Subsystems.
    /// </summary>
    public sealed class FaceSubsystem : XRFaceSubsystem, IMarsXRSubsystem
    {

        // Mirror memory layout of UnityEngine.XR.ARSubsystems.XRFace
#pragma warning disable 649
        [StructLayout(LayoutKind.Sequential)]
        internal struct XRFace
        {
            public TrackableId m_TrackableId;
            public Pose m_Pose;
            public TrackingState m_TrackingState;
            public IntPtr m_NativePtr;
#if ARSUBSYSTEMS_3_OR_NEWER
            public Pose m_LeftEyePose;
            public Pose m_RightEyePose;
            public Vector3 m_FixationPoint;
#endif
        }
#pragma warning restore 649

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
        class MARSXRProvider : Provider, IMarsXRSubscriber, IUsesFaceTracking
#else
        class MARSXRProvider : IProvider, IMarsXRSubscriber, IUsesFaceTracking
#endif
        {
            readonly Dictionary<MarsTrackableId, IMRFace> m_AddedFaces = new Dictionary<MarsTrackableId, IMRFace>();
            readonly Dictionary<MarsTrackableId, IMRFace> m_UpdatedFaces = new Dictionary<MarsTrackableId, IMRFace>();
            readonly HashSet<MarsTrackableId> m_RemovedFaces = new HashSet<MarsTrackableId>();

            readonly Dictionary<TrackableId, IMRFace> m_Faces = new Dictionary<TrackableId, IMRFace>();

            const int k_DefaultConversionBufferCapacity = 1;
            XRFace[] m_ConversionBuffer = new XRFace[k_DefaultConversionBufferCapacity];
            TrackableId[] m_IdConversionBuffer = new TrackableId[k_DefaultConversionBufferCapacity];

            IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }

#if ARSUBSYSTEMS_3_OR_NEWER
            public override int supportedFaceCount => 1;
#endif

            void FaceAdded(IMRFace face)
            {
                m_AddedFaces.Add(face.id, face);
                m_Faces.Add(new TrackableId(face.id.subId1, face.id.subId2), face);
            }

            void FaceUpdated(IMRFace face)
            {
                if (m_AddedFaces.ContainsKey(face.id))
                    m_AddedFaces[face.id] = face;
                else
                    m_UpdatedFaces[face.id] = face;
                m_Faces[new TrackableId(face.id.subId1, face.id.subId2)] = face;
            }

            void FaceRemoved(IMRFace face)
            {
                if (!m_AddedFaces.Remove(face.id))
                {
                    m_UpdatedFaces.Remove(face.id);
                    m_RemovedFaces.Add(face.id);
                }

                m_Faces.Remove(new TrackableId(face.id.subId1, face.id.subId2));
            }

            public void SubscribeToEvents()
            {
                this.SubscribeFaceAdded(FaceAdded);
                this.SubscribeFaceUpdated(FaceUpdated);
                this.SubscribeFaceRemoved(FaceRemoved);
            }

            public void UnsubscribeFromEvents()
            {
                this.UnsubscribeFaceAdded(FaceAdded);
                this.UnsubscribeFaceUpdated(FaceUpdated);
                this.UnsubscribeFaceRemoved(FaceRemoved);
            }

            public override void Destroy() { }

            public override void Start() { }

            public override void Stop() { }

            public override TrackableChanges<UnityEngine.XR.ARSubsystems.XRFace> GetChanges(UnityEngine.XR.ARSubsystems.XRFace defaultFace, Allocator allocator)
            {
                var changes = new TrackableChanges<UnityEngine.XR.ARSubsystems.XRFace>(m_AddedFaces.Count,
                    m_UpdatedFaces.Count, m_RemovedFaces.Count, allocator);
                var numAddedFaces = m_AddedFaces.Count;
                if (numAddedFaces > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numAddedFaces);
                    var i = 0;
                    foreach (var face in m_AddedFaces.Values)
                        m_ConversionBuffer[i++] = XRFaceFromIMRFace(face);
                    NativeArray<XRFace>.Copy(m_ConversionBuffer, changes.added.Reinterpret<XRFace>(), numAddedFaces);
                    m_AddedFaces.Clear();
                }

                var numUpdatedFaces = m_UpdatedFaces.Count;
                if (numUpdatedFaces > 0)
                {
                    Utils.EnsureCapacity(ref m_ConversionBuffer, numUpdatedFaces);
                    var i = 0;
                    foreach (var face in m_UpdatedFaces.Values)
                        m_ConversionBuffer[i++] = XRFaceFromIMRFace(face);
                    NativeArray<XRFace>.Copy(m_ConversionBuffer, changes.updated.Reinterpret<XRFace>(), numUpdatedFaces);
                    m_UpdatedFaces.Clear();
                }

                var numRemovedFaces = m_RemovedFaces.Count;
                if (numRemovedFaces > 0)
                {
                    Utils.EnsureCapacity(ref m_IdConversionBuffer, numRemovedFaces);
                    var i = 0;
                    foreach (var id in m_RemovedFaces)
                    {
                        m_IdConversionBuffer[i++] = new TrackableId(id.subId1, id.subId2);
                    }

                    NativeArray<TrackableId>.Copy(m_IdConversionBuffer, changes.removed, numRemovedFaces);
                    m_RemovedFaces.Clear();
                }

                return changes;
            }

            public override void GetFaceMesh(TrackableId faceId, Allocator allocator, ref XRFaceMesh faceMesh)
            {
                // This code is not currently used as simulation does not currently provide a mesh.
                var mesh = m_Faces[faceId].Mesh;
                if (mesh == null)
                    return;

                var numVerts = mesh.vertexCount;
                var numTris = mesh.triangles.Length / 3;
                var attributes = (mesh.normals.Length > 0 ? XRFaceMesh.Attributes.Normals : 0) |
                    (mesh.uv.Length > 0 ? XRFaceMesh.Attributes.UVs : 0);
                faceMesh.Resize(numVerts, numTris, attributes, allocator);

                faceMesh.vertices.CopyFrom(mesh.vertices);
                faceMesh.indices.CopyFrom(mesh.triangles);
                if (mesh.normals.Length > 0)
                    faceMesh.normals.CopyFrom(mesh.normals);
                if (mesh.uv.Length > 0)
                    faceMesh.uvs.CopyFrom(mesh.uv);
            }
        }

        static XRFace XRFaceFromIMRFace(IMRFace mrFace)
        {
            var face = new XRFace
            {
                m_TrackableId = new TrackableId(mrFace.id.subId1, mrFace.id.subId2),
                m_Pose = mrFace.pose,
                m_TrackingState = TrackingState.Tracking,
#if ARSUBSYSTEMS_3_OR_NEWER
                m_LeftEyePose = Pose.identity,
                m_RightEyePose = Pose.identity,
#endif
            };

#if ARSUBSYSTEMS_3_OR_NEWER
            if (mrFace.LandmarkPoses.TryGetValue(MRFaceLandmark.LeftEye, out var pose))
                face.m_LeftEyePose = new Pose(pose.position - mrFace.pose.position,
                    Quaternion.Inverse(mrFace.pose.rotation) * pose.rotation);
            if (mrFace.LandmarkPoses.TryGetValue(MRFaceLandmark.RightEye, out pose))
                face.m_RightEyePose = new Pose(pose.position - mrFace.pose.position,
                    Quaternion.Inverse(mrFace.pose.rotation) * pose.rotation);
#endif

            return face;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void RegisterDescriptor()
        {
            XRFaceSubsystemDescriptor.Create(new FaceSubsystemParams
            {
                id = "MARS-Face",
#if ARSUBSYSTEMS_4_OR_NEWER && UNITY_2020_2_OR_NEWER
                providerType = typeof(FaceSubsystem.MARSXRProvider),
                subsystemTypeOverride = typeof(FaceSubsystem),
#else
                subsystemImplementationType = typeof(FaceSubsystem),
#endif
                supportsFaceMeshNormals = false,
                supportsFaceMeshUVs = false,
                supportsFaceMeshVerticesAndIndices = false,
                supportsFacePose = false,
#if ARSUBSYSTEMS_3_OR_NEWER
                supportsEyeTracking = true,
#endif
            });
        }
    }
}
#endif

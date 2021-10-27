using System;
using System.Collections.Generic;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
#pragma warning disable 67
    /// <summary>
    /// This provider is used in performance tests to provide all baseline functionalities while doing no extra work.
    /// It will be used by default if no providers are added to your project, or if there are issues setting up providers.
    /// </summary>
    [AddComponentMenu("")]
    [ProviderSelectionOptions(ProviderPriorities.TestProviderPriority, disallowAutoCreation:true)]
    class PerfTestMultiProvider : MonoBehaviour, IProvidesCameraPose, IProvidesPointCloud,
        IProvidesPlaneFinding, IProvidesCameraOffset, IProvidesLightEstimation,
        IProvidesReferencePoints, IProvidesFaceTracking
    {
        readonly Dictionary<MarsTrackableId, MRPlane> m_Planes = new Dictionary<MarsTrackableId, MRPlane>();
        readonly Dictionary<MarsTrackableId, IMRFace> m_Faces = new Dictionary<MarsTrackableId, IMRFace>();

        void IFunctionalityProvider.LoadProvider() {}

        void IFunctionalityProvider.ConnectSubscriber(object obj)
        {
            this.TryConnectSubscriber<IProvidesCameraPose>(obj);
            this.TryConnectSubscriber<IProvidesCameraOffset>(obj);
            this.TryConnectSubscriber<IProvidesLightEstimation>(obj);
            this.TryConnectSubscriber<IProvidesPlaneFinding>(obj);
            this.TryConnectSubscriber<IProvidesPointCloud>(obj);
            this.TryConnectSubscriber<IProvidesReferencePoints>(obj);
            this.TryConnectSubscriber<IProvidesFaceTracking>(obj);
        }

        void IFunctionalityProvider.UnloadProvider() {}

        public Dictionary<MarsTrackableId, PointCloudData> GetPoints()
        {
            throw new NotImplementedException();
        }

        public event Action<Dictionary<MarsTrackableId, PointCloudData>> PointCloudUpdated;
        public void StopDetectingPoints() { }
        public void StartDetectingPlanes() { }
        public void StopDetectingPlanes() { }
        public void StartDetectingPoints() { }

        public Pose GetCameraPose() { return default(Pose); }

        public event Action<Pose> poseUpdated;
        public event Action<MRCameraTrackingState> trackingStateChanged;

        public Vector3 cameraPositionOffset
        {
            get { return Vector3.zero; }
            set { }
        }

        public float cameraYawOffset
        {
            get { return 0; }
            set { }
        }

        public float cameraScale
        {
            get { return 1; }
            set { }
        }

        public Matrix4x4 CameraOffsetMatrix { get { return Matrix4x4.identity; } }

        public Pose ApplyOffsetToPose(Pose pose)
        {
            return pose;
        }

        public Pose ApplyInverseOffsetToPose(Pose pose)
        {
            return pose;
        }

        public Vector3 ApplyOffsetToPosition(Vector3 position)
        {
            return position;
        }

        public Vector3 ApplyInverseOffsetToPosition(Vector3 position)
        {
            return position;
        }

        public Vector3 ApplyOffsetToDirection(Vector3 direction)
        {
            return direction;
        }

        public Vector3 ApplyInverseOffsetToDirection(Vector3 direction)
        {
            return direction;
        }

        public Quaternion ApplyOffsetToRotation(Quaternion rotation)
        {
            return rotation;
        }

        public Quaternion ApplyInverseOffsetToRotation(Quaternion rotation)
        {
            return rotation;
        }

        public event Action<MRLightEstimation> lightEstimationUpdated;
        public bool TryGetLightEstimation(out MRLightEstimation lightEstimation)
        {
            lightEstimation = default(MRLightEstimation);
            return true;
        }

        public event Action<MRPlane> planeAdded;
        public event Action<MRPlane> planeUpdated;
        public event Action<MRPlane> planeRemoved;
        public void GetPlanes(List<MRPlane> planes)
        {
            foreach (var kvp in m_Planes)
            {
                planes.Add(kvp.Value);
            }
        }

        public event Action<MRReferencePoint> pointAdded;
        public event Action<MRReferencePoint> pointUpdated;
        public event Action<MRReferencePoint> pointRemoved;
        public void GetAllReferencePoints(List<MRReferencePoint> referencePoints)
        {
            throw new NotImplementedException();
        }

        public bool TryAddReferencePoint(Pose pose, out MarsTrackableId referencePointId)
        {
            throw new NotImplementedException();
        }

        public bool TryGetReferencePoint(MarsTrackableId id, out MRReferencePoint referencePoint)
        {
            throw new NotImplementedException();
        }

        public bool TryRemoveReferencePoint(MarsTrackableId id)
        {
            throw new NotImplementedException();
        }

        public void StopTrackingReferencePoints() { }
        public void StartTrackingReferencePoints() { }

        public int GetMaxFaceCount()
        {
            return 0;
        }

        public int RequestedMaximumFaceCount
        {
            get => 0;
            set {}
        }

        public int CurrentMaximumFaceCount => 0;

        public int SupportedFaceCount => 0;

        public event Action<IMRFace> FaceAdded;
        public event Action<IMRFace> FaceUpdated;
        public event Action<IMRFace> FaceRemoved;
        public void GetFaces(List<IMRFace> faces)
        {
            throw new NotImplementedException();
        }

        void Start()
        {
            for (var i = 0; i < 10; i++)
            {
                var p = new MRPlane();
                var trackableId = MarsTrackableId.Create();
                p.id = trackableId;
                m_Planes.Add(p.id, p);
                if (planeAdded != null)
                    planeAdded(p);

                var f = new TestFace();
                f.id = trackableId;
                m_Faces.Add(p.id, f);
                if (FaceAdded != null)
                    FaceAdded(f);
            }
        }

        void Update()
        {
            if (planeUpdated != null)
            {
                foreach (var plane in m_Planes)
                {
                    planeUpdated(plane.Value);
                }
            }

            if (FaceUpdated != null)
            {
                foreach (var face in m_Faces)
                {
                    FaceUpdated(face.Value);
                }
            }

            var pose = new Pose();
            if (poseUpdated != null)
                poseUpdated(pose);
        }
    }
#pragma warning restore 67
}

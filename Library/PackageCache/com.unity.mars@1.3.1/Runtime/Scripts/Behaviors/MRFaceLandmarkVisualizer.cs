using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS
{
    [HelpURL(DocumentationConstants.FaceLandmarkVisualizerDocs)]
    class MRFaceLandmarkVisualizer : MonoBehaviour, IUsesFaceTracking, IUsesCameraOffset, ISimulatable
    {
        const string k_ContainerName = "MRFaceLandmarkVisualizer";
        const string k_FaceNameFormat = "Face {0}";

        class LandmarkSet
        {
            public readonly Transform[] points;
            public readonly MeshRenderer[] renderers;

            public LandmarkSet(float scale, string faceName, Transform parent)
            {
                var landmarks = EnumValues<MRFaceLandmark>.Values;
                var landmarkCount = landmarks.Length;
                points = new Transform[landmarkCount];
                renderers = new MeshRenderer[landmarkCount];
                var transform = GameObjectUtils.Create(faceName).transform;
                transform.parent = parent;
                for (var i = 0; i < landmarkCount; i++)
                {
                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.name = landmarks[i].ToString();
                    var sphereTransform = sphere.transform;
                    sphereTransform.localScale *= scale;
                    sphereTransform.parent = transform;
                    renderers[i] = sphere.GetComponent<MeshRenderer>();
                    points[i] = sphere.transform;
                }
            }

            public void SetEnabled(bool enabled)
            {
                foreach (var renderer in renderers)
                {
                    if (renderer != null)
                        renderer.enabled = enabled;
                }
            }
        }

        [SerializeField]
        float m_Scale = 0.01f; // 1cm

        Transform m_Container;

        // HACK: Container can get destroyed in simulation so re-create it if necessary
        Transform container
        {
            get
            {
                if (!m_Container)
                    m_Container = GameObjectUtils.Create(k_ContainerName).transform;

                return m_Container;
            }
        }

        readonly Queue<LandmarkSet> m_LandmarkSetPool = new Queue<LandmarkSet>();
        readonly Dictionary<MarsTrackableId, LandmarkSet> m_LandmarkSets = new Dictionary<MarsTrackableId, LandmarkSet>();

        IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        void OnEnable()
        {
            var maxFaceCount = this.GetCurrentMaximumFaceCount();
            for (var i = 0; i < maxFaceCount; i++)
            {
                m_LandmarkSetPool.Enqueue(new LandmarkSet(m_Scale, string.Format(k_FaceNameFormat, i), container));
            }

            this.SubscribeFaceAdded(OnFaceAdded);
            this.SubscribeFaceUpdated(OnFaceUpdated);
            this.SubscribeFaceRemoved(OnFaceRemoved);
        }

        void OnDisable()
        {
            this.UnsubscribeFaceAdded(OnFaceAdded);
            this.UnsubscribeFaceUpdated(OnFaceUpdated);
            this.UnsubscribeFaceRemoved(OnFaceRemoved);
            m_LandmarkSetPool.Clear();
            m_LandmarkSets.Clear();
        }

        void OnFaceAdded(IMRFace face)
        {
            var id = face.id;
            var landmarks = GetLandmarkSet(id.ToString());
            landmarks.SetEnabled(true);
            m_LandmarkSets[id] = landmarks;
            UpdateLandmarks(face, landmarks);
        }

        void OnFaceUpdated(IMRFace face)
        {
            LandmarkSet landmarks;
            var id = face.id;
            if (!m_LandmarkSets.TryGetValue(id, out landmarks))
            {
                landmarks = GetLandmarkSet(id.ToString());
                landmarks.SetEnabled(true);
                m_LandmarkSets[id] = landmarks;
            }

            UpdateLandmarks(face, landmarks);
        }

        void OnFaceRemoved(IMRFace face)
        {
            LandmarkSet landmarks;
            var id = face.id;
            if (m_LandmarkSets.TryGetValue(id, out landmarks))
            {
                landmarks.SetEnabled(false);
                m_LandmarkSets.Remove(id);
                m_LandmarkSetPool.Enqueue(landmarks);
            }
        }

        void UpdateLandmarks(IMRFace face, LandmarkSet landmarkSet)
        {
            var points = landmarkSet.points;
            var renderers = landmarkSet.renderers;
            var landmarkPoses = face.LandmarkPoses;
            var landmarkCount = points.Length;
            var sphereScale = this.GetCameraScale() * m_Scale * Vector3.one;
            for (var i = 0; i < landmarkCount; i++)
            {
                Pose pose;
                if (landmarkPoses.TryGetValue((MRFaceLandmark) i, out pose))
                {
                    var point = points[i];
                    point.SetWorldPose(this.ApplyOffsetToPose(pose));
                    point.localScale = sphereScale;
                    renderers[i].enabled = true;
                }
                else
                {
                    renderers[i].enabled = false;
                }
            }
        }

        LandmarkSet GetLandmarkSet(string faceName)
        {
            return m_LandmarkSetPool.Count > 0 ?
                m_LandmarkSetPool.Dequeue() : new LandmarkSet(m_Scale, faceName, container);
        }
    }
}

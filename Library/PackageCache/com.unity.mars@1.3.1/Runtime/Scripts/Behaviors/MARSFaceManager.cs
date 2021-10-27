using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Visualizers
{
    [MovedFrom("Unity.MARS.Behaviors")]
    public class MARSFaceManager : MonoBehaviour, IUsesFaceTracking, IUsesCameraOffset, IUsesFunctionalityInjection, ISimulatable
    {
        class Face
        {
            public readonly GameObject gameObject;
            public readonly Transform transform;
            public readonly MeshFilter meshFilter;

            // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
            static readonly List<IFunctionalitySubscriber> k_Subscribers = new List<IFunctionalitySubscriber>();

            public Face(GameObject prefab, Transform parent, IUsesFunctionalityInjection injector)
            {
                gameObject = Instantiate(prefab, parent);
                transform = gameObject.transform;
                meshFilter = gameObject.GetComponentInChildren<MeshFilter>(true);

                // k_Subscribers is cleared by GetComponentsInChildren
                gameObject.GetComponentsInChildren(true, k_Subscribers);
                foreach (var subscriber in k_Subscribers)
                {
                    injector.InjectFunctionalitySingle(subscriber);
                }
            }
        }
#pragma warning disable 649
        [SerializeField]
        GameObject m_FacePrefab;
#pragma warning restore 649

        bool m_RunInEditModeDirty;
        Pose m_StartPose;
        bool m_StartActive;
        Transform m_FaceParent;

        readonly Queue<Face> m_FacePool = new Queue<Face>();
        readonly Dictionary<MarsTrackableId, Face> m_Faces = new Dictionary<MarsTrackableId, Face>();

        IProvidesFaceTracking IFunctionalitySubscriber<IProvidesFaceTracking>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }
        IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }

        void OnEnable()
        {
            m_FaceParent = GameObjectUtils.Create("Faces").transform;
            m_RunInEditModeDirty = true;
            m_StartPose = m_FacePrefab.transform.GetWorldPose();
            m_StartActive = m_FacePrefab.activeInHierarchy;

            var maxFaces = this.GetCurrentMaximumFaceCount();
            while (m_FacePool.Count < maxFaces)
            {
                var face = new Face(m_FacePrefab, m_FaceParent, this);
                face.gameObject.SetActive(false);
                m_FacePool.Enqueue(face);
            }

            this.SubscribeFaceAdded(FaceAdded);
            this.SubscribeFaceUpdated(FaceUpdated);
            this.SubscribeFaceRemoved(FaceRemoved);
        }

        void OnDisable()
        {
            this.UnsubscribeFaceAdded(FaceAdded);
            this.UnsubscribeFaceUpdated(FaceUpdated);
            this.UnsubscribeFaceRemoved(FaceRemoved);

            m_Faces.Clear();
            m_FacePool.Clear();
            if (m_FaceParent)
                UnityObjectUtils.Destroy(m_FaceParent.gameObject);

            if (!m_FacePrefab)
                return;

            if (m_RunInEditModeDirty)
            {
                m_FacePrefab.transform.SetWorldPose(m_StartPose);
                m_FacePrefab.SetActive(m_StartActive);
            }
        }

        void FaceAdded(IMRFace face)
        {
            var faceContainer = GetFace();
            m_Faces.Add(face.id, faceContainer);
            faceContainer.gameObject.SetActive(true);
            var faceTransform = faceContainer.transform;
            faceTransform.SetLocalPose(this.ApplyOffsetToPose(face.pose));
            var meshFilter = faceContainer.meshFilter;
            if (meshFilter != null)
            {
                var faceMesh = face.Mesh;
                if (faceMesh != null)
                    meshFilter.sharedMesh = faceMesh;
                else
                    meshFilter.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        void FaceUpdated(IMRFace face)
        {
            if (m_Faces.TryGetValue(face.id, out var faceObj))
                faceObj.transform.SetLocalPose(this.ApplyOffsetToPose(face.pose));
            else
                FaceAdded(face);
        }

        void FaceRemoved(IMRFace face)
        {
            var id = face.id;
            var faceContainer = m_Faces[id];
            m_FacePool.Enqueue(faceContainer);
            m_Faces.Remove(id);
            var faceObject = faceContainer.gameObject;
            if (faceObject)
                faceObject.SetActive(false);
        }

        Face GetFace()
        {
            if (m_FacePool.Count > 0)
                return m_FacePool.Dequeue();

            return new Face(m_FacePrefab, m_FaceParent, this);
        }
    }
}

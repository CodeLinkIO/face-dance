using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Visualizers
{
    [MovedFrom("Unity.MARS.Behaviors")]
    public class MARSStickerPlacer : MonoBehaviour, IUsesPlaneFinding, IUsesMRHitTesting, IUsesCameraOffset
    {
        class SpawnedObject
        {
            public float time;
            public GameObject obj;
        }

        const float k_PlaneHeight = 0.01f;
        const string k_PhysicsPlaneNameFormat = "Physics Plane {0}";

        IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }
        IProvidesMRHitTesting IFunctionalitySubscriber<IProvidesMRHitTesting>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        [SerializeField]
        float m_DestroyDelay = 5f;

#pragma warning disable 649
        [SerializeField]
        LayerMask m_ObjectLayer;

        [SerializeField]
        LayerMask m_PlaneLayer;

        [SerializeField]
        GameObject[] m_Assets;
#pragma warning restore 649

        int m_Layer;
        int m_RaycastLayers;
        GameObject m_Selected;
        Pose m_LastValid;
        Vector3 m_GrabHitOffset;
        Camera m_Camera;

        readonly Dictionary<MarsTrackableId, GameObject> m_Planes = new Dictionary<MarsTrackableId, GameObject>();
        readonly Queue<SpawnedObject> m_SpawnedObjects = new Queue<SpawnedObject>();

        void OnEnable()
        {
            m_Layer = m_PlaneLayer.GetFirstLayerIndex();

            this.SubscribePlaneAdded(PlaneAddedHandler);
            this.SubscribePlaneUpdated(PlaneUpdatedHandler);
            this.SubscribePlaneRemoved(PlaneRemovedHandler);

            m_RaycastLayers = m_PlaneLayer | m_ObjectLayer;

            m_Camera = MarsRuntimeUtils.GetActiveCamera(true);
        }

        void OnDisable()
        {
            this.UnsubscribePlaneAdded(PlaneAddedHandler);
            this.UnsubscribePlaneUpdated(PlaneUpdatedHandler);
            this.UnsubscribePlaneRemoved(PlaneRemovedHandler);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;

                var ray = m_Camera.ScreenPointToRay(mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_RaycastLayers))
                {
                    var hitLayer = 1 << hit.transform.gameObject.layer;
                    if ((m_ObjectLayer & hitLayer) != 0)
                    {
                        // Only select when not already selected
                        if (m_Selected == null)
                        {
                            m_Selected = hit.collider.gameObject;
                            m_LastValid = PoseFromHit(m_Camera.transform, hit);

                            if (IntersectPlanePoint(m_Selected.transform.position, m_Selected.transform.up, ray, out m_GrabHitOffset))
                                m_GrabHitOffset = m_Selected.transform.position - m_GrabHitOffset;
                            else
                                m_GrabHitOffset = Vector3.zero;
                        }
                    }
                    else if ((m_PlaneLayer & hitLayer) != 0)
                    {
                        m_Selected = SpawnAsset(PoseFromHit(m_Camera.transform, hit));
                        m_LastValid = hit.transform.GetWorldPose();

                        if (IntersectPlanePoint(m_Selected.transform.position, m_Selected.transform.up, ray, out m_GrabHitOffset))
                            m_GrabHitOffset = m_Selected.transform.position - m_GrabHitOffset;
                        else
                            m_GrabHitOffset = Vector3.zero;
                    }
                }
            }
            else if (Input.GetMouseButton(0))
            {
                if (m_Selected != null)
                {
                    var mousePosition = Input.mousePosition;
                    var ray = m_Camera.ScreenPointToRay(mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_PlaneLayer.value))
                        m_LastValid = PoseFromHit(m_Camera.transform, hit);

                    m_Selected.transform.position = m_LastValid.position + m_GrabHitOffset;
                    m_Selected.transform.rotation = m_LastValid.rotation;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_Selected = null;
                m_LastValid = Pose.identity;
                m_GrabHitOffset = Vector3.zero;
            }

            if (m_SpawnedObjects.Count > 0)
            {
                var peek = m_SpawnedObjects.Peek();
                if (Time.time - peek.time > m_DestroyDelay)
                {
                    if (m_Selected == peek.obj)
                    {
                        m_Selected = null;
                        m_LastValid = Pose.identity;
                        m_GrabHitOffset = Vector3.zero;
                    }

                    m_SpawnedObjects.Dequeue();
                    Destroy(peek.obj);
                }
            }
        }

        GameObject SpawnAsset(Pose pose)
        {
            var spawnedObject = new SpawnedObject { time = Time.time };
            var obj = Instantiate(m_Assets[Random.Range(0, m_Assets.Length)]);
            spawnedObject.obj = obj;
            var newTransform = obj.transform;
            newTransform.parent = transform.parent;
            newTransform.position = pose.position;
            newTransform.rotation = pose.rotation;
            m_SpawnedObjects.Enqueue(spawnedObject);

            return obj;
        }

        protected virtual void CreateOrUpdatePhysicsPlane(MRPlane plane)
        {
            GameObject go;
            if (!m_Planes.TryGetValue(plane.id, out go))
            {
                go = new GameObject { name = string.Format(k_PhysicsPlaneNameFormat, plane.id) };
                go.AddComponent<BoxCollider>();
                go.layer = m_Layer;
                m_Planes.Add(plane.id, go);
            }

            var pose = plane.pose;
            pose.position += pose.rotation * plane.center;
            pose = this.ApplyOffsetToPose(pose);
            go.transform.localPosition = pose.position;
            go.transform.localRotation = pose.rotation;
            var extents = plane.extents;
            go.transform.localScale = new Vector3(extents.x, k_PlaneHeight, extents.y) * this.GetCameraScale();
        }

        protected virtual void PlaneAddedHandler(MRPlane plane)
        {
            CreateOrUpdatePhysicsPlane(plane);
        }

        protected virtual void PlaneUpdatedHandler(MRPlane plane)
        {
            CreateOrUpdatePhysicsPlane(plane);
        }

        protected virtual void PlaneRemovedHandler(MRPlane plane)
        {
            GameObject go;
            if (m_Planes.TryGetValue(plane.id, out go))
            {
                Destroy(go);
                m_Planes.Remove(plane.id);
            }
        }

        static Pose PoseFromHit(Transform cameraTransform, RaycastHit hit)
        {
            var hitPoint = hit.point;
            var forwardRot = Quaternion.LookRotation(cameraTransform.forward, hit.normal);
            var upRot = Quaternion.FromToRotation(forwardRot * Vector3.up, hit.normal);
            upRot *= forwardRot;

            return new Pose(hitPoint, upRot);
        }

        static bool IntersectPlanePoint(Vector3 planeOrigin, Vector3 planeNormal, Ray ray, out Vector3 hitPoint)
        {
            var denominator = Mathf.Abs(Vector3.Dot(planeNormal, ray.direction));
            if (denominator > float.Epsilon)
            {
                var planeToRay = planeOrigin - ray.origin;
                var distAlongRay = Mathf.Abs(Vector3.Dot(planeToRay, planeNormal) / denominator);
                if (distAlongRay >= 0f)
                {
                    hitPoint = ray.direction * distAlongRay + ray.origin;
                    return true;
                }
            }

            hitPoint = Vector3.zero;
            return false;
        }
    }
}

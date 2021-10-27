using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Visualizers
{
    [HelpURL(DocumentationConstants.MarsPlaneVisualizerDocs)]
    class MARSPlaneVisualizer : MonoBehaviour, IUsesPlaneFinding, IUsesCameraOffset, ISimulatable
    {
        class PlaneVisual
        {
            const int k_InitialPoolSize = 64;
            static readonly Queue<PlaneVisual> k_Pool = new Queue<PlaneVisual>();

            const int k_InitialVertexCount = 64;
            const int k_InitialIndexCount = (k_InitialVertexCount - 2) * 3;

            public GameObject GameObject { get; private set; }
            public MeshCollider Collider { get; private set; }
            public Mesh Mesh;

            public List<int> Indices;
            public List<Vector3> Vertices;
            public List<Vector2> TextureCoordinates;
            public readonly List<Vector2> TextureCoordinates2 = new List<Vector2>(k_InitialVertexCount);

            internal static void InitializePool(bool makeEdge)
            {
                for (var i = 0; i < k_InitialPoolSize; i++)
                {
                    k_Pool.Enqueue(new PlaneVisual(null, null, null, makeEdge));
                }
            }

            PlaneVisual(GameObject gameObject, Mesh mesh, MeshCollider collider, bool makeEdge)
            {
                GameObject = gameObject;
                Mesh = mesh;
                Collider = collider;

                if (!makeEdge)
                    return;

                InitializeEdgeLists();
            }

            internal void InitializeEdgeLists()
            {
                if (Vertices != null)
                    return;

                Vertices = new List<Vector3>(k_InitialVertexCount);
                TextureCoordinates = new List<Vector2>(k_InitialVertexCount);
                Indices = new List<int>(k_InitialIndexCount);
            }

            internal static PlaneVisual GetOrCreate(GameObject gameObject, Mesh mesh, MeshCollider collider, bool makeEdge)
            {
                if (k_Pool.Count > 0)
                {
                    var planeVisual = k_Pool.Dequeue();
                    planeVisual.GameObject = gameObject;
                    planeVisual.Mesh = mesh;
                    planeVisual.Collider = collider;
                    return planeVisual;
                }

                return new PlaneVisual(gameObject, mesh, collider, makeEdge);
            }

            internal static void Recycle(PlaneVisual planeVisual)
            {
                // Release any UnityObject references so they can be cleaned up
                planeVisual.GameObject = null;
                planeVisual.Mesh = null;
                planeVisual.Collider = null;
                k_Pool.Enqueue(planeVisual);
            }
        }

        IProvidesPlaneFinding IFunctionalitySubscriber<IProvidesPlaneFinding>.provider { get; set; }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

#pragma warning disable 649
        [SerializeField]
        GameObject m_PlanePrefab;
#pragma warning restore 649

        [SerializeField]
        bool m_UsePlaneGeometry = true;

        [SerializeField]
        PlaneEdgeSettings m_EdgeSettings = PlaneEdgeSettings.Default;

#if UNITY_EDITOR
        bool m_UseParentLayer;
#endif

        readonly Dictionary<MarsTrackableId, PlaneVisual> m_Planes = new Dictionary<MarsTrackableId, PlaneVisual>();

        void Awake()
        {
            PlaneVisual.InitializePool(m_EdgeSettings.MakeEdge);
        }

        void OnEnable()
        {
#if UNITY_EDITOR
            var getSimScene = EditorOnlyDelegates.GetSimulatedEnvironmentScene;
            m_UseParentLayer = getSimScene != null &&
                gameObject.scene == getSimScene();
#endif

            this.SubscribePlaneAdded(PlaneAddedHandler);
            this.SubscribePlaneUpdated(PlaneUpdatedHandler);
            this.SubscribePlaneRemoved(PlaneRemovedHandler);

            var planes = new List<MRPlane>();
            this.GetPlanes(planes);
            foreach (var plane in planes)
            {
                CreateOrUpdateGameObject(plane);
            }
        }

        void OnDisable()
        {
            this.UnsubscribePlaneAdded(PlaneAddedHandler);
            this.UnsubscribePlaneUpdated(PlaneUpdatedHandler);
            this.UnsubscribePlaneRemoved(PlaneRemovedHandler);

            foreach (var pair in m_Planes)
            {
                var planeVisual = pair.Value;

                UnityObjectUtils.Destroy(planeVisual.GameObject);
                UnityObjectUtils.Destroy(planeVisual.Mesh);
            }

            m_Planes.Clear();
        }

        void CreateOrUpdateGameObject(MRPlane plane)
        {
            if (MARSCore.instance.paused)
                return;

            GameObject go;
            Mesh mesh = null;
            MeshCollider meshCollider = null;
            var id = plane.id;
            var useGeometry = m_UsePlaneGeometry && plane.vertices != null;
            var makeEdge = m_EdgeSettings.MakeEdge;
            if (m_Planes.TryGetValue(id, out var planeVisual))
            {
                go = planeVisual.GameObject;
                mesh = planeVisual.Mesh;
                meshCollider = planeVisual.Collider;
                if (useGeometry && mesh == null)
                {
                    mesh = new Mesh();
                    planeVisual.Mesh = mesh;
                }
            }
            else
            {
                go = Instantiate(m_PlanePrefab, transform);

#if UNITY_EDITOR
                // This allows the instantiated objects to use layer locking for scene picking in the editor.
                if (m_UseParentLayer)
                    go.SetLayerAndHideFlagsRecursively(gameObject.layer, HideFlags.DontSave);
                else
                    go.SetHideFlagsRecursively(HideFlags.DontSave);
#else
                go.SetHideFlagsRecursively(HideFlags.DontSave);
#endif

                if (useGeometry)
                {
                    mesh = new Mesh();

                    var meshFilter = go.GetComponentInChildren<MeshFilter>();
                    if (meshFilter)
                        meshFilter.sharedMesh = mesh;

                    meshCollider = go.GetComponentInChildren<MeshCollider>();
                    if (meshCollider)
                        meshCollider.sharedMesh = mesh;

                    planeVisual = PlaneVisual.GetOrCreate(go, mesh, meshCollider, makeEdge);
                }
                else
                {
                    planeVisual = PlaneVisual.GetOrCreate(go, null, null, makeEdge);
                }

                m_Planes.Add(id, planeVisual);
            }

            var goTransform = go.transform;
            var pose = this.ApplyOffsetToPose(plane.pose);
            goTransform.SetWorldPose(pose);

            var cameraScale = this.GetCameraScale();
            if (useGeometry)
            {
                var vertices = plane.vertices;
                var textureCoordinates = plane.textureCoordinates;
                var textureCoordinates2 = planeVisual.TextureCoordinates2;
                var indices = plane.indices;
                if (makeEdge)
                {
                    planeVisual.InitializeEdgeLists();
                    PlaneUtils.GeneratePlaneWithBorders(plane.pose, vertices, planeVisual.Vertices, planeVisual.TextureCoordinates,
                        planeVisual.TextureCoordinates2, planeVisual.Indices, m_EdgeSettings);

                    vertices = planeVisual.Vertices;
                    textureCoordinates = planeVisual.TextureCoordinates;
                    indices = planeVisual.Indices;
                }
                else
                {
                    // Need to set uv2's with all 0's to clear out edge UVs if they exist (can happen if MakeEdge is toggled during play mode)
                    var vertexCount = vertices.Count;
                    textureCoordinates2.SetSize(vertexCount);
                    for (var i = 0; i < vertexCount; i++)
                    {
                        textureCoordinates2[i] = default;
                    }
                }

                goTransform.localScale = Vector3.one * cameraScale;
                mesh.triangles = null;
                mesh.SetVertices(vertices);
                mesh.SetUVs(0, textureCoordinates);
                mesh.SetUVs(1, textureCoordinates2);
                mesh.SetTriangles(indices, 0, true);
                mesh.RecalculateNormals();

                if (meshCollider != null)
                    meshCollider.sharedMesh = mesh; // this needs to re-applied to take effect
            }
            else
            {
                var extents = plane.extents;
                goTransform.position += pose.rotation * (plane.center * cameraScale);
                goTransform.localScale = new Vector3(extents.x, 1f, extents.y) * cameraScale;
            }
        }

        void PlaneAddedHandler(MRPlane plane)
        {
            if (m_PlanePrefab)
                CreateOrUpdateGameObject(plane);
        }

        void PlaneUpdatedHandler(MRPlane plane)
        {
            if (m_PlanePrefab)
                CreateOrUpdateGameObject(plane);
        }

        void PlaneRemovedHandler(MRPlane plane)
        {
            if (m_Planes.TryGetValue(plane.id, out var planeVisual))
            {
                UnityObjectUtils.Destroy(planeVisual.GameObject);
                UnityObjectUtils.Destroy(planeVisual.Mesh);
                m_Planes.Remove(plane.id);
                PlaneVisual.Recycle(planeVisual);
            }
        }
    }
}

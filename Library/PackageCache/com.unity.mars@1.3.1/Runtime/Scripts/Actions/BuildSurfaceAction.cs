using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Actions
{
    /// <summary>
    /// Creates a surface plane from the entity's plane data
    /// </summary>
	[HelpURL(DocumentationConstants.BuildSurfaceActionDocs)]
    [MonoBehaviourComponentMenu(typeof(BuildSurfaceAction), "Action/Build Surface")]
    [MovedFrom("Unity.MARS")]
    public class BuildSurfaceAction : TransformAction, IMatchAcquireHandler, IMatchUpdateHandler,
        IUsesMARSTrackableData<MRPlane>, IUsesCameraOffset, IRequiresTraits
    {
        [SerializeField]
        [Tooltip("Offsets the created plane in local space. Offset in Y axis to clarify depth ordering.")]
        Vector3 m_LocalPlaneOffset = Vector3.zero;

        const float k_MinVerticalBounds = 0.001f;
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Plane };

        static Vector3[] s_BaseVertices =
        {
            new Vector3(0.5f, 0, 0.5f), new Vector3(0.5f, 0, -0.5f),
            new Vector3(-0.5f, 0, -0.5f), new Vector3(-0.5f, 0, 0.5f)
        };

        static Vector2[] s_DefaultUVs =
        {
            new Vector2(1.0f, 1.0f), new Vector2(1.0f, -1.0f), new Vector2(-1.0f, -1.0f), new Vector2(-1.0f, 1.0f)
        };

        static Vector3[] s_DefaultNormals = { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
        static int[] s_DefaultTris = { 0, 1, 2, 0, 2, 3 };
        static Bounds s_DefaultBounds = new Bounds(Vector3.zero, new Vector3(1.0f, k_MinVerticalBounds, 1.0f));
        static Vector3[] s_DefaultVertices = new Vector3[4];

        Transform m_Transform;
        Mesh m_Mesh;
        MeshFilter m_MeshFilter;
        MeshCollider m_MeshCollider;

        /// <inheritdoc />
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        /// <inheritdoc />
        public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <summary>
        /// Offsets the created plane in local space. Offset in Y axis to clarify depth ordering.
        /// </summary>
        public Vector3 LocalPlaneOffset { get { return m_LocalPlaneOffset; } set { m_LocalPlaneOffset = value; } }

        void OnEnable()
        {
            m_MeshFilter = GetComponent<MeshFilter>();
            m_MeshCollider = GetComponent<MeshCollider>();

            if (m_MeshFilter == null && m_MeshCollider == null)
            {
                Debug.LogError("BuildSurfaceAction requires a MeshFilter or MeshCollider to do anything.");
                enabled = false;
                return;
            }

            m_Transform = transform;

            if (m_Mesh != null)
                return;

            m_Mesh = new Mesh();
            if (m_MeshFilter != null)
                m_MeshFilter.sharedMesh = m_Mesh;

            if (m_MeshCollider != null)
            {
                m_MeshCollider.convex = false;
                m_MeshCollider.sharedMesh = m_Mesh;
            }
        }

        void OnDestroy()
        {
            if (m_Mesh != null)
                UnityObjectUtils.Destroy(m_Mesh);
        }

        /// <inheritdoc />
        public void OnMatchAcquire(QueryResult queryResult)
        {
            UpdateSurface(queryResult);
        }

        /// <inheritdoc />
        public void OnMatchUpdate(QueryResult queryResult)
        {
            UpdateSurface(queryResult);
        }

        void UpdateSurface(QueryResult queryResult)
        {
            if ((!this) || (!isActiveAndEnabled))
                return;

            var mrPlane = queryResult.ResolveValue(this);
            var cameraScale = this.GetCameraScale();

            var worldPose = this.ApplyOffsetToPose(mrPlane.pose);
            worldPose.position += worldPose.rotation * m_LocalPlaneOffset;
            m_Transform.SetWorldPose(worldPose);
            m_Transform.localScale = Vector3.one * cameraScale;

            var vertices = mrPlane.vertices;
            if (vertices != null)
            {
                m_Mesh.triangles = null;
                m_Mesh.SetVertices(vertices);
                m_Mesh.SetUVs(0, mrPlane.textureCoordinates);
                m_Mesh.SetTriangles(mrPlane.indices, 0);

                var extents = mrPlane.extents;
                m_Mesh.bounds = new Bounds(mrPlane.center, new Vector3(extents.x, Mathf.Max(k_MinVerticalBounds, extents.y), extents.y));

                if (mrPlane.normals == null || mrPlane.normals.Count == 0)
                    m_Mesh.RecalculateNormals();
                else
                    m_Mesh.SetNormals(mrPlane.normals);

                m_Mesh.UploadMeshData(false);
            }
            else
            {
                // Build a Y aligned quad
                m_Mesh.triangles = null;
                var extents = mrPlane.extents;
                var extentsScale = new Vector3(extents.x, 1.0f, extents.y);
                for (var vertCounter = 0; vertCounter < 4; vertCounter++)
                {
                    s_DefaultVertices[vertCounter] = Vector3.Scale(s_BaseVertices[vertCounter], extentsScale);
                }

                m_Mesh.vertices = s_DefaultVertices;
                m_Mesh.normals = s_DefaultNormals;
                m_Mesh.uv = s_DefaultUVs;
                m_Mesh.triangles = s_DefaultTris;
                m_Mesh.bounds = s_DefaultBounds;
                m_Mesh.UploadMeshData(false);
            }

            if (m_MeshCollider)
                m_MeshCollider.sharedMesh = m_Mesh;
        }
    }
}

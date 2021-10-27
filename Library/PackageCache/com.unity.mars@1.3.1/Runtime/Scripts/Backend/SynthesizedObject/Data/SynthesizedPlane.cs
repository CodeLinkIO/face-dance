using System.Collections.Generic;
using System.Linq;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.ModuleLoader;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data.Synthetic
{
    /// <summary>
    /// Creates data for an MRPlane
    /// When added to a synthesized object, adds a trackable MRPlane to the database.
    /// When added to a simulated object, its plane will be provided to the database by the simulated plane provider.
    /// </summary>
    [ExecuteInEditMode]
    [RequireComponent(typeof(SynthesizedPose))]
    [RequireComponent(typeof(SynthesizedAlignment))]
    [RequireComponent(typeof(SynthesizedBounds2D))]
    [HelpURL(DocumentationConstants.SynthesizedPlaneDocs)]
    [MovedFrom("Unity.MARS.Data")]
    public class SynthesizedPlane : SynthesizedTrackable<MRPlane>, IUsesCameraOffset
    {
        static readonly TraitDefinition[] k_ProvidedTraits = { TraitDefinitions.Plane };

        const string k_GeneratedMeshPrefix = "Generated Mesh";
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Use the MR Plane data to generate the visual mesh.")]
        bool m_UseMRPlaneMesh;
#pragma warning restore 649

        [SerializeField]
        [HideInInspector]
        MRPlane m_Plane;

        // Plane used for the SynthesizedTrackable that has a runtime generated ID rather than any serialized value.
        MRPlane m_RuntimePlane;

        SynthesizedPose m_PoseSource;
        SynthesizedAlignment m_AlignmentSource;
        SynthesizedBounds2D m_ExtentsSource;

        MRPlane m_GeneratedPlane;
        bool m_MRPlaneGenerated;
        Mesh m_GeneratedMesh;
        Mesh m_OriginalMesh;
        MeshFilter m_MeshFilter;

        public override string TraitName { get { return TraitNames.Plane; } }
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        internal int dataID { get; set; }

        /// <summary>
        /// Called by Unity when the object is first activated
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            if (m_Plane.vertices != null)
                return;

            m_Plane.vertices = new List<Vector3>();
            m_Plane.textureCoordinates = new List<Vector2>();
            m_Plane.indices = new List<int>();
            m_Plane.normals = new List<Vector3>();
        }

        /// <summary>
        /// Called by Unity when the object is enabled
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            CheckOriginalMeshCached();
            EnsureMeshSet();
        }

        void OnDestroy()
        {
            if (m_MeshFilter != null)
                m_MeshFilter.sharedMesh = m_OriginalMesh;

            UnityObjectUtils.Destroy(m_GeneratedMesh);
        }

        /// <summary>
        /// Get the TraitDefinitions provided by this SynthesizedPlane
        /// </summary>
        /// <returns>The provided traits</returns>
        public override TraitDefinition[] GetProvidedTraits() { return k_ProvidedTraits; }

        /// <summary>
        /// Called by MARS when the SynthesizedObject is initialized
        /// </summary>
        public override void Initialize()
        {
            CopyToRuntimePlane();

            m_PoseSource = GetComponent<SynthesizedPose>();
            m_AlignmentSource = GetComponent<SynthesizedAlignment>();
            m_ExtentsSource = GetComponent<SynthesizedBounds2D>();
        }

        /// <summary>
        /// Called when this plane is removed from the MARS database
        /// </summary>
        public override void Terminate()
        {
            m_RuntimePlane.id = MarsTrackableId.InvalidId;
        }

        /// <summary>
        /// Get the MRPlane data for this synthesized plane
        /// </summary>
        /// <returns>The MRPlane data</returns>
        public override MRPlane GetData()
        {
            if (!m_MRPlaneGenerated)
                UpdatePlaneFromData();

            return m_GeneratedPlane;
        }

        /// <summary>
        /// Set the data for the MRPlane backing this SynthesizedPlane
        /// </summary>
        /// <param name="vertices">The vertices for the boundary polygon</param>
        /// <param name="center">The position of the center of the plane</param>
        /// <param name="extents">The extents of the boundary polygon</param>
        public void SetMRPlaneData(List<Vector3> vertices, Vector3 center, Vector2 extents)
        {
            if (m_ExtentsSource == null)
                m_ExtentsSource = GetComponent<SynthesizedBounds2D>();

            m_ExtentsSource.baseBounds = extents;
            m_Plane.center = center;

            m_Plane.vertices.Clear();
            m_Plane.indices.Clear();
            m_Plane.normals.Clear();
            m_Plane.textureCoordinates.Clear();

            m_Plane.vertices.AddRange(vertices);
            PlaneUtils.TriangulatePlaneFromVertices(m_Plane.pose, m_Plane.vertices, m_Plane.indices, m_Plane.normals, m_Plane.textureCoordinates);

            SetMeshData();
            CopyToRuntimePlane();

            m_MRPlaneGenerated = false;
        }

        void UpdatePlaneFromData()
        {
            if (m_UseMRPlaneMesh)
            {
                m_GeneratedPlane = m_RuntimePlane;
                var localScale = transform.localScale;

                // We duplicate the vertices here since the original list is serialized with the base plane
                if (localScale != Vector3.one && m_GeneratedPlane.vertices != null)
                    m_GeneratedPlane.vertices = m_GeneratedPlane.vertices.ToList();

                ScaleVertices(m_GeneratedPlane.vertices, localScale);
            }
            else
            {
                m_GeneratedPlane = new MRPlane { id = m_RuntimePlane.id };

                if (m_OriginalMesh != null)
                {
                    var vertices = m_OriginalMesh.vertices.ToList();
                    var verticesLength = vertices.Count;

                    ScaleVertices(vertices, transform.localScale);

                    var indices = new List<int>(verticesLength * 3);
                    var normals = new List<Vector3>(verticesLength);
                    var texCoords = new List<Vector2>(verticesLength);

                    PlaneUtils.TriangulatePlaneFromVertices(m_GeneratedPlane.pose, vertices, indices, normals, texCoords);

                    indices.TrimExcess();

                    // Mesh data is not initialized when MR Plane is created
                    m_GeneratedPlane.vertices = vertices;
                    m_GeneratedPlane.indices = indices;
                    m_GeneratedPlane.normals = normals;
                    m_GeneratedPlane.textureCoordinates = texCoords;
                }
            }

            // Traits from other synthesized data
            m_GeneratedPlane.pose = m_PoseSource.GetTraitData();
            m_GeneratedPlane.alignment = (MarsPlaneAlignment)m_AlignmentSource.GetTraitData();
            m_GeneratedPlane.extents = m_ExtentsSource.GetTraitData();

            m_MRPlaneGenerated = true;
        }

        void ScaleVertices(List<Vector3> vertices, Vector3 scale)
        {
            if (transform.localScale == Vector3.one || vertices == null)
                return;

            for (var i = 0; i < vertices.Count; i++)
            {
                vertices[i] = Vector3.Scale(vertices[i], scale);
            }
        }

        void EnsureMeshSet()
        {
            if (m_UseMRPlaneMesh && !QuickValidateMesh())
                SetMeshData();

            var mesh = m_UseMRPlaneMesh ? m_GeneratedMesh : m_OriginalMesh;
            m_MeshFilter = GetComponent<MeshFilter>();
            if (m_MeshFilter == null)
            {
                m_MeshFilter = gameObject.AddComponent<MeshFilter>();
                m_MeshFilter.hideFlags = HideFlags.DontSave;
            }

            m_MeshFilter.sharedMesh = mesh;
        }

        bool QuickValidateMesh()
        {
            if (m_GeneratedMesh == null)
                return false;

            if (m_GeneratedMesh.vertices.Length != m_Plane.vertices.Count)
                return false;

            if (m_GeneratedMesh.triangles.Length != m_Plane.vertices.Count * 3)
                return false;

            return true;
        }

        void SetMeshData()
        {
            if (m_GeneratedMesh == null)
                m_GeneratedMesh = new Mesh{name = $"{k_GeneratedMeshPrefix} {gameObject.name}"};

            m_GeneratedMesh.SetVertices(m_Plane.vertices);
            m_GeneratedMesh.SetNormals(m_Plane.normals);
            m_GeneratedMesh.SetUVs(0, m_Plane.textureCoordinates);
            m_GeneratedMesh.SetTriangles(m_Plane.indices, 0);
        }

        void CheckOriginalMeshCached()
        {
            if (m_MeshFilter == null)
                m_MeshFilter = GetComponent<MeshFilter>();

            if (m_OriginalMesh != null && m_OriginalMesh.name.StartsWith(k_GeneratedMeshPrefix))
                m_OriginalMesh = null;

            if (m_MeshFilter == null)
                return;

            var usingGeneratedMesh = m_MeshFilter != null && m_MeshFilter.sharedMesh != null
                && m_MeshFilter.sharedMesh.name.StartsWith(k_GeneratedMeshPrefix);

            if ((m_OriginalMesh == null || m_OriginalMesh != m_MeshFilter.sharedMesh) && !usingGeneratedMesh)
                m_OriginalMesh = m_MeshFilter.sharedMesh;
        }

        /// <summary>
        /// Ensure that this object has the correct references to its Mesh and MeshFilter
        /// </summary>
        public void ValidateUsingMeshCache()
        {
            CheckOriginalMeshCached();
            EnsureMeshSet();
        }

        // Copy m_Plane to m_RuntimePlane but preserve its ID, or generate one if it doesn't have one.
        void CopyToRuntimePlane() {
            var id = m_RuntimePlane.id;
            if (id == MarsTrackableId.InvalidId)
                id = MarsTrackableId.Create();

            m_RuntimePlane = m_Plane;
            m_RuntimePlane.id = id;
        }

        /// <summary>
        /// Refresh the data for this SynthesizedPlane using the associated MRPlane
        /// </summary>
        public void RefreshFromMRPlane()
        {
            if (!m_UseMRPlaneMesh || QuickValidateMesh())
                return;

            SetMeshData();
            CopyToRuntimePlane();
            UpdatePlaneFromData();
        }
    }
}

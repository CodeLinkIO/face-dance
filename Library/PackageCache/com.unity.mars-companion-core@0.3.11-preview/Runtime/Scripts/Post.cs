using UnityEngine;

namespace Unity.MARS.Companion.Mobile
{
    class Post : MonoBehaviour
    {
        static readonly int[] k_Indices = { 0, 1, 2, 0, 3, 1 };
        static readonly Quaternion k_FlipRotation = Quaternion.AngleAxis(180f, Vector3.up);

#pragma warning disable 649
        [SerializeField]
        GameObject m_WallPrefab;

        [SerializeField]
        Transform m_BottomSphere;

        [SerializeField]
        Transform m_TopSphere;
#pragma warning restore 649

        public Transform Wall { get; private set; }

        Mesh m_WallMesh;
        Vector3[] m_WallMeshVertices;
        Vector3[] m_WallLinePositions;
        Vector2[] m_WallMeshUVs;
        LineRenderer m_LineRenderer;

        public void Setup(Material outlineMaterial = null, Material wallMaterial = null)
        {
            Wall = Instantiate(m_WallPrefab).transform;
            m_WallMesh = new Mesh();
            Wall.GetComponent<MeshFilter>().sharedMesh = m_WallMesh;
            m_WallMeshVertices = new Vector3[4];
            m_WallLinePositions = new Vector3[5];
            m_WallMeshUVs = new Vector2[4];
            m_LineRenderer = Wall.GetComponent<LineRenderer>();

            if (outlineMaterial != null)
            {
                m_LineRenderer.sharedMaterial = outlineMaterial;
                m_BottomSphere.GetComponent<MeshRenderer>().sharedMaterial = outlineMaterial;
                m_TopSphere.GetComponent<MeshRenderer>().sharedMaterial = outlineMaterial;
            }

            if (wallMaterial != null)
                Wall.GetComponent<MeshRenderer>().sharedMaterial = wallMaterial;
        }

        void OnDestroy()
        {
            if (Wall != null)
                Destroy(Wall.gameObject);

            if (m_WallMesh != null)
                Destroy(m_WallMesh);
        }

        public void UpdateWall(Vector3 position, Vector3 direction, float height, Vector3? cameraForward = null)
        {
            var halfPostToPost = direction * 0.5f;
            direction.y = 0;
            var midPoint = position + halfPostToPost;
            Wall.position = midPoint;
            var yawSign = Mathf.Sign(Vector3.Dot(Vector3.forward, direction));
            var currentYaw = Vector3.Angle(Vector3.left, direction) * yawSign;
            Wall.rotation = Quaternion.AngleAxis(currentYaw, Vector3.up);

            if (cameraForward.HasValue && Vector3.Dot(cameraForward.Value, Wall.forward) < 0)
                Wall.rotation *= k_FlipRotation;

            UpdateWallMesh(direction.magnitude, height);
        }

        public void SetTopSphereHeight(float height)
        {
            m_TopSphere.localPosition = Vector3.up * height;
        }

        public void SetPostHeight(Vector3 nextPostPosition, float height)
        {
            SetTopSphereHeight(height);
            if (m_WallMesh != null)
                UpdateWallMesh(Vector3.Distance(transform.position, nextPostPosition), height);
        }

        void UpdateWallMesh(float length, float height)
        {
            var halfLength = length * 0.5f;
            var leftSide = Vector2.left * halfLength;
            var rightSide = Vector2.right * halfLength;
            var upVector = Vector2.up * height;
            m_WallMeshVertices[0] = m_WallMeshUVs[0] = leftSide;
            m_WallMeshVertices[1] = m_WallMeshUVs[1] = rightSide + upVector;
            m_WallMeshVertices[2] = m_WallMeshUVs[2] = rightSide;
            m_WallMeshVertices[3] = m_WallMeshUVs[3] = leftSide + upVector;

            m_WallLinePositions[0] = leftSide;
            m_WallLinePositions[1] = leftSide + upVector;
            m_WallLinePositions[2] = rightSide + upVector;
            m_WallLinePositions[3] = rightSide;
            m_WallLinePositions[4] = leftSide;
            m_LineRenderer.SetPositions(m_WallLinePositions);

            m_WallMesh.vertices = m_WallMeshVertices;
            m_WallMesh.uv = m_WallMeshUVs;
            m_WallMesh.triangles = k_Indices;
            m_WallMesh.RecalculateBounds();
        }
    }
}

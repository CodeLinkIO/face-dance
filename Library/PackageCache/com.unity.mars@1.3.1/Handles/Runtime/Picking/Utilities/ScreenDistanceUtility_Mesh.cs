using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    static partial class ScreenDistanceUtility
    {
        public static float DistanceToMesh(Vector2 screenPoint, Camera camera, Matrix4x4 matrix, Mesh mesh)
        {
            if (mesh == null)
                return float.MaxValue;

            mesh.GetVertices(s_VertexBuffer);
            ProjectVerticesOnScreen(camera, matrix, s_VertexBuffer, s_ScreenProjectedVertices);

            float distance = float.MaxValue;
            for (int i = 0; i < mesh.subMeshCount; ++i)
            {
                mesh.GetIndices(s_IndicesBuffer, i);
                distance = Mathf.Min(distance, DistanceToMesh(screenPoint, s_ScreenProjectedVertices, s_IndicesBuffer, mesh.GetTopology(i)));
            }

            return distance;
        }

        internal static float DistanceToMesh(Vector2 screenPoint, Camera camera, Matrix4x4 matrix, IReadOnlyList<Vector3> vertices, IReadOnlyList<int> indices, MeshTopology topology)
        {
            ProjectVerticesOnScreen(camera, matrix, vertices, s_ScreenProjectedVertices);
            return DistanceToMesh(screenPoint, s_ScreenProjectedVertices, indices, topology);
        }

        static float DistanceToMesh(
            Vector2 screenPoint,
            IReadOnlyList<Vector2> verticesOnScreen,
            IReadOnlyList<int> indices,
            MeshTopology topology)
        {
            switch (topology)
            {
                case MeshTopology.Triangles:
                    return DistanceToTrianglesMesh(screenPoint, indices, verticesOnScreen);

                case MeshTopology.Quads:
                    return DistanceToQuadsMesh(screenPoint, indices, verticesOnScreen);

                case MeshTopology.Points:
                    return DistanceToPointsMesh(screenPoint, indices, verticesOnScreen);

                case MeshTopology.Lines:
                    return DistanceToLinesMesh(screenPoint, indices, verticesOnScreen);

                case MeshTopology.LineStrip:
                    return DistanceToLineStripMesh(screenPoint, indices, verticesOnScreen);
            }

            return float.MaxValue;
        }


        static float DistanceToTrianglesMesh(Vector2 screenPoint, IReadOnlyList<int> triangles, IReadOnlyList<Vector2> vertices)
        {
            float nearest = float.MaxValue;
            for (int i = 0, count = triangles.Count; i < count; i += 3)
            {
                var a = vertices[triangles[i]];
                var b = vertices[triangles[i + 1]];
                var c = vertices[triangles[i + 2]];

                nearest = Mathf.Min(MathUtility.DistanceToTriangle(screenPoint, a, b, c), nearest);
            }

            return nearest;
        }

        static float DistanceToPointsMesh(Vector2 screenPoint, IReadOnlyList<int> indices, IReadOnlyList<Vector2> vertices)
        {
            float nearest = float.MaxValue;
            for (int i = 0, count = indices.Count; i < count; ++i)
            {
                nearest = Mathf.Min(Vector2.Distance(screenPoint, vertices[indices[i]]), nearest);
            }

            return nearest;
        }

        static float DistanceToQuadsMesh(Vector2 screenPoint, IReadOnlyList<int> indices, IReadOnlyList<Vector2> vertices)
        {
            float nearest = float.MaxValue;
            for (int i = 0, count = indices.Count; i < count; i += 4)
            {
                Vector2 a = vertices[indices[i]];
                Vector2 b = vertices[indices[i + 1]];
                Vector2 c = vertices[indices[i + 2]];
                Vector2 d = vertices[indices[i + 3]];

                nearest = Mathf.Min(MathUtility.DistanceToQuad(screenPoint, a, b, c, d), nearest);
            }

            return nearest;
        }

        static float DistanceToLineStripMesh(Vector2 screenPoint, IReadOnlyList<int> indices, IReadOnlyList<Vector2> vertices)
        {
            float nearest = float.MaxValue;
            for (int i = 0, count = indices.Count - 1; i < count; ++i)
            {
                Vector2 a = vertices[indices[i]];
                Vector2 b = vertices[indices[i + 1]];

                nearest = Mathf.Min(MathUtility.DistanceToLine(screenPoint, a, b), nearest);
            }

            return nearest;
        }

        static float DistanceToLinesMesh(Vector2 screenPoint, IReadOnlyList<int> indices, IReadOnlyList<Vector2> vertices)
        {
            float nearest = float.MaxValue;
            for (int i = 0, count = indices.Count; i < count; i += 2)
            {
                Vector2 a = vertices[indices[i]];
                Vector2 b = vertices[indices[i + 1]];

                nearest = Mathf.Min(MathUtility.DistanceToLine(screenPoint, a, b), nearest);
            }

            return nearest;
        }
    }
}

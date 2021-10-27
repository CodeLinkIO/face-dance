using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.MARSHandles.Picking
{
    static partial class ScreenDistanceUtility
    {

        static readonly List<Vector3> s_VertexBuffer = new List<Vector3>(256);
        static readonly List<Vector2> s_ScreenProjectedVertices = new List<Vector2>(256);
        static readonly List<int> s_IndicesBuffer = new List<int>(256);
        static readonly Vector3[] s_PointsBuffer = new Vector3[60];

        public struct Quad
        {
            public int indexA { get; private set; }
            public int indexB { get; private set; }
            public int indexC { get; private set; }
            public int indexD { get; private set; }

            public Quad(int a, int b, int c, int d) : this()
            {
                this.indexA = a;
                this.indexB = b;
                this.indexC = c;
                this.indexD = d;
            }
        }

        // Get the nearest 3D point.
        public static Vector3 ClosestPointToDisc(Vector2 screenPoint, Vector3 center, Vector3 normal, float radius, Camera camera)
        {
            Vector3 tangent = Vector3.Cross(normal, Vector3.up);
            if (tangent.sqrMagnitude < .001f)
                tangent = Vector3.Cross(normal, Vector3.right);
            return ClosestPointToArc(screenPoint, center, normal, tangent, 360, radius, camera);
        }

        // Get the nearest 3D point.
        public static Vector3 ClosestPointToArc(Vector2 screenPoint, Vector3 center, Vector3 normal, Vector3 from, float angle, float radius, Camera camera)
        {
            GetDiscSectionPoints(s_PointsBuffer, center, normal, from, angle, radius);
            return ClosestPointToPolyLine(screenPoint, s_PointsBuffer, camera);
        }



        // Get the nearest 3D point.
        public static Vector3 ClosestPointToPolyLine(Vector2 screenPoint, IList<Vector3> vertices, Camera camera)
        {
            float dist = DistanceToLine(screenPoint, vertices[0], vertices[1], camera);
            int nearest = 0;// Which segment we're closest to
            for (int i = 2; i < vertices.Count; i++)
            {
                float d = DistanceToLine(screenPoint, vertices[i - 1], vertices[i], camera);
                if (d < dist)
                {
                    dist = d;
                    nearest = i - 1;
                }
            }

            Vector3 lineStart = vertices[nearest];
            Vector3 lineEnd = vertices[nearest + 1];

            Vector2 screenLineStart = camera.WorldToScreenPoint(lineStart);
            Vector2 relativePoint = screenPoint - screenLineStart;
            Vector2 lineDirection = (Vector2)camera.WorldToScreenPoint(lineEnd) - screenLineStart;
            float length = lineDirection.magnitude;
            float dot = Vector3.Dot(lineDirection, relativePoint);
            if (length > .000001f)
                dot /= length * length;
            dot = Mathf.Clamp01(dot);

            return Vector3.Lerp(lineStart, lineEnd, dot);
        }


        // Pixel distance from mouse pointer to a 3D disc.
        public static float DistanceToDisc(Vector2 screenPoint, Vector3 center, Vector3 normal, float radius, Camera camera)
        {
            Vector3 tangent = Vector3.Cross(normal, Vector3.up);
            if (tangent.sqrMagnitude < .001f)
                tangent = Vector3.Cross(normal, Vector3.right);
            return DistanceToArc(screenPoint, center, normal, tangent, 360, radius, camera);
        }

        // Pixel distance from mouse pointer to a 3D section of a disc.
        public static float DistanceToArc(Vector2 screenPoint, Vector3 center, Vector3 normal, Vector3 from, float angle, float radius, Camera camera)
        {
            GetDiscSectionPoints(s_PointsBuffer, center, normal, from, angle, radius);
            return DistanceToPolyLine(screenPoint, s_PointsBuffer, camera);
        }

        // Pixel distance from mouse pointer to a polyline.
        public static float DistanceToPolyLine(Vector2 screenPoint, IList<Vector3> points, Camera camera)
        {
            float dist = float.MaxValue;
            for (int i = 0, max = points.Count - 1; i < max; ++i)
            {
                dist = Mathf.Min(dist, DistanceToLine(screenPoint, points[i], points[i+1], camera));
            }
            return dist;
        }

        public static float DistanceToLine(Vector2 screenPoint, Vector3 p1, Vector3 p2, Camera camera)
        {
            p1 = (Vector2)camera.WorldToScreenPoint(p1);
            p2 = (Vector2)camera.WorldToScreenPoint(p2);

            float result = MathUtility.DistanceToLine((Vector3)screenPoint, p1, p2);
            if (result < 0)
                result = 0.0f;
            return result;
        }

        public static float DistanceToQuads(Vector2 screenPoint, IReadOnlyList<Vector3> vertices, IReadOnlyList<Quad> quads, Camera camera)
        {
            ProjectVerticesOnScreen(camera, Matrix4x4.identity, vertices, s_ScreenProjectedVertices);

            float closest = float.MaxValue;
            for (int i = 0, count = quads.Count; i < count; ++i)
            {
                var quad = quads[i];
                var a = s_ScreenProjectedVertices[quad.indexA];
                var b = s_ScreenProjectedVertices[quad.indexB];
                var c = s_ScreenProjectedVertices[quad.indexC];
                var d = s_ScreenProjectedVertices[quad.indexD];
                closest = Mathf.Min(closest, MathUtility.DistanceToQuad(screenPoint, a, b, c, d));
            }

            return closest;
        }

        static void GetDiscSectionPoints(IList<Vector3> dest, Vector3 center, Vector3 normal, Vector3 from, float angle, float radius)
        {
            int count = dest.Count;
            Quaternion r = Quaternion.AngleAxis((angle / (count - 1)) * Mathf.Deg2Rad, normal);
            Vector3 tangent = from.normalized * radius;
            for (int i = 0; i < count; ++i)
            {
                dest[i] = center + tangent;
                tangent = r * tangent;
            }
        }

        static void ProjectVerticesOnScreen(Camera camera, Matrix4x4 matrix, IReadOnlyList<Vector3> vertices, ICollection<Vector2> results)
        {
            results.Clear();

            for (int i = 0, count = vertices.Count; i < count; ++i)
            {
                var vertex = vertices[i];
                results.Add(camera.WorldToScreenPoint(matrix.MultiplyPoint(vertex)));
            }
        }
    }
}

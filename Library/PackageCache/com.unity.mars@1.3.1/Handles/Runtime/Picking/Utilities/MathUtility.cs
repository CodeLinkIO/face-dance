using UnityEngine;

namespace Unity.MARS.MARSHandles
{
    static class MathUtility 
    {
        struct Bounds2D
        {
            public Vector2 center { get; private set; }
            public Vector2 size { get; private set; }
            public Vector2 extents { get; private set; }
            public float xMin { get; private set; }
            public float xMax { get; private set; }
            public float yMin { get; private set; }
            public float yMax { get; private set; }

            public Bounds2D(Vector2[] points) : this()
            {
                int count = points.Length;

                if (count == 0)
                {
                    xMin = xMax = yMin = yMax = 0f;
                }
                else
                {
                    xMin = xMax = points[0].x;
                    yMin = yMax = points[0].y;

                    for (int i = 1; i < count; ++i)
                    {
                        float x = points[i].x;
                        float y = points[i].y;

                        if (x < xMin) xMin = x;
                        if (x > xMax) xMax = x;
                        if (y < yMin) yMin = y;
                        if (y > yMax) yMax = y;
                    }
                }
                
                center = new Vector2((xMin + xMax) * 0.5f, (yMin + yMax) * 0.5f);
                size = new Vector2(xMax - xMin, yMax - yMin);
                extents = new Vector2(size.x * 0.5f, size.y * 0.5f);
            }

            public bool Contains(Vector2 point)
            {
                return point.x > xMin
                    && point.x < xMax
                    && point.y > yMin
                    && point.y < yMax;
            }
        }

        // Calculate distance between a point and a line.
        public static float DistanceToLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
        {
            return Vector3.Magnitude(ProjectPointLine(point, lineStart, lineEnd) - point);
        }

        // Project /point/ onto a line.
        public static Vector3 ProjectPointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
        {
            Vector3 relativePoint = point - lineStart;
            Vector3 lineDirection = lineEnd - lineStart;
            float length = lineDirection.magnitude;
            Vector3 normalizedLineDirection = lineDirection;
            if (length > .000001f)
                normalizedLineDirection /= length;

            float dot = Vector3.Dot(normalizedLineDirection, relativePoint);
            dot = Mathf.Clamp(dot, 0.0F, length);

            return lineStart + normalizedLineDirection * dot;
        }

        public static Vector3 ProjectPointOnRay(Vector3 point, Ray ray)
        {
            return ray.origin + Vector3.Project(point - ray.origin, ray.direction);
        }

        /// <summary>
        /// Calculate the minimum distance from a point to a triangle in 2d space.
        /// </summary>
        /// <param name="a">The first triangle position.</param>
        /// <param name="b">The second triangle position.</param>
        /// <param name="c">The third triangle position.</param>
        /// <param name="point">The point to calculate distance to.</param>
        /// <returns>The distance from point to the nearest point on a triangle.</returns>
        public static float DistanceToTriangle(Vector2 point, Vector2 a, Vector2 b, Vector2 c)
        {
            var inside = System.Math.Sign(Vector2.Dot(Vector2.Perpendicular(b - a), point - a));

            if (inside == System.Math.Sign(Vector2.Dot(Vector2.Perpendicular(c - b), point - b))
                && inside == System.Math.Sign(Vector2.Dot(Vector2.Perpendicular(a - c), point - c)))
                return 0;

            var da = DistanceToLine(point, a, b);
            var db = DistanceToLine(point, b, c);
            var dc = DistanceToLine(point, c, a);

            return Mathf.Min(da, Mathf.Min(db, dc));
        }

        static readonly float[] s_QuadDistanceBuffer = new float[4];
        static readonly Vector2[] s_QuadBuffer = new Vector2[4];
        /// <summary>
        /// Get the distance between a point and a quad
        /// </summary>
        /// <param name="point">The point from which the distance is calculated`</param>
        /// <param name="a">One of the quad's point. Is connected to b and d.</param>
        /// <param name="b">One of the quad's point. Is connected to a and c.</param>
        /// <param name="c">One of the quad's point. Is connected to b and d.</param>
        /// <param name="d">One of the quad's point. Is connected to c and a.</param>
        /// <returns></returns>
        public static float DistanceToQuad(Vector2 point, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        {
            s_QuadBuffer[0] = a;
            s_QuadBuffer[1] = b;
            s_QuadBuffer[2] = c;
            s_QuadBuffer[3] = d;

            var bounds = new Bounds2D(s_QuadBuffer);

            //Check if the point is inside the quad
            if (bounds.Contains(point))
            {
                var firstEdgeDir = bounds.center - (Vector2)GetEdgeCenter(a, b);
                var rayStart = bounds.center + firstEdgeDir * (bounds.size.y + bounds.size.x + 2f);
                var collisions = 0;

                for (int i = 0, count = s_QuadBuffer.Length-1; i < count; ++i)
                {
                    var p1 = s_QuadBuffer[i];
                    var p2 = s_QuadBuffer[i + 1];
                    if (AreSegmentIntersecting(rayStart, point, p1, p2))
                        ++collisions;
                }

                if (collisions % 2 != 0)
                    return 0f;
            }

            s_QuadDistanceBuffer[0] = DistanceToLine(point, a, b);
            s_QuadDistanceBuffer[1] = DistanceToLine(point, b, c);
            s_QuadDistanceBuffer[2] = DistanceToLine(point, c, d);
            s_QuadDistanceBuffer[3] = DistanceToLine(point, d, a);

            return Mathf.Min(s_QuadDistanceBuffer);
        }

        public static float DistanceToLine(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
        {
            float l2 = ((lineStart.x - lineEnd.x) * (lineStart.x - lineEnd.x)) +
                       ((lineStart.y - lineEnd.y) * (lineStart.y - lineEnd.y));
            
            if (l2 == 0.0f)
                return Vector2.Distance(point, lineStart);

            float t = Vector2.Dot(point - lineStart, lineEnd - lineStart) / l2;

            if (t < 0.0)
                return Vector2.Distance(point, lineStart);
            else if (t > 1.0)
                return Vector2.Distance(point, lineEnd);

            Vector2 projection = lineStart + t * (lineEnd - lineStart);

            return Vector2.Distance(point, projection);
        }

        public static bool AreSegmentIntersecting(Vector2 a1, Vector2 b1, Vector2 a2, Vector2 b2)
        {
            Vector2 s1, s2;
            s1.x = b1.x - a1.x; s1.y = b1.y - a1.y;
            s2.x = b2.x - a2.x; s2.y = b2.y - a2.y;

            float s, t;
            s = (-s1.y * (a1.x - a2.x) + s1.x * (a1.y - a2.y)) / (-s2.x * s1.y + s1.x * s2.y);
            t = (s2.x * (a1.y - a2.y) - s2.y * (a1.x - a2.x)) / (-s2.x * s1.y + s1.x * s2.y);

            return (s >= 0 && s <= 1 && t >= 0 && t <= 1);
        }

        public static Vector3 GetEdgeCenter(Vector3 a, Vector3 b)
        {
            var dir = b - a;
            return a + dir * 0.5f;
        }
    }
}
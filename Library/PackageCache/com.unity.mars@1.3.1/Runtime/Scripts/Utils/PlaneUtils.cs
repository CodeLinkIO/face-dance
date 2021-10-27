using System;
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public struct PlaneEdgeSettings
    {
        public bool MakeEdge;
        public float EdgeWidth;
        public float EdgeRepeatDistance;

        public static PlaneEdgeSettings Default => new PlaneEdgeSettings()
            { MakeEdge = false, EdgeWidth = 0.07f, EdgeRepeatDistance = 0.07f };
    }

    [MovedFrom("Unity.MARS")]
    public static class PlaneUtils
    {
        static readonly Vector3 k_Up = Vector3.up;

        /// <summary>
        /// Triangulates the polygon and tiles the UV data correctly from the polygon center.
        /// Sets normals to local up.
        /// </summary>
        /// <param name="pose">Input Pose of the source plane</param>
        /// <param name="vertices">Input Vertices of the polygon.</param>
        /// <param name="indices">Output Index buffer to fill for triangulation</param>
        /// <param name="normals">Output for vertex normals</param>
        /// <param name="texCoords">Output uv coordinates.</param>
        public static void TriangulatePlaneFromVertices(in Pose pose, List<Vector3> vertices, List<int> indices, List<Vector3> normals, List<Vector2> texCoords)
        {
            var uvPose = GeometryUtils.PolygonUVPoseFromPlanePose(pose);
            var vertsCount = vertices.Count;
            GeometryUtils.TriangulatePolygon(indices, vertsCount);

            for (var i = 0; i < vertsCount; i++)
            {
                var textureCoordinate = GeometryUtils.PolygonVertexToUV(vertices[i], pose, uvPose);
                texCoords.Add(textureCoordinate);
                normals.Add(k_Up);
            }
        }

        public static void GeneratePlaneWithBorders(Pose pose, List<Vector3> sourceVertices, List<Vector3> vertices, List<Vector2> textureCoordinates,
            List<Vector2> textureCoordinates2, List<int> indices, PlaneEdgeSettings settings)
        {
            var uvPose = GeometryUtils.PolygonUVPoseFromPlanePose(pose);

            var borderWidth = settings.EdgeWidth;
            var borderLengthTiling = settings.EdgeRepeatDistance;

            var ringLength = sourceVertices.Count;
            var vertexCount = ringLength * 2 + 2;

            vertices.SetSize(vertexCount);
            textureCoordinates.SetSize(vertexCount);
            textureCoordinates2.SetSize(vertexCount);
            indices.SetSize((vertexCount - 2) * 3);

            var tex2Along = 0.0f;
            var indexCount = 0;
            for (var edgeIndex = 0; edgeIndex < ringLength; edgeIndex++)
            {
                var sourceLoc = sourceVertices[edgeIndex];
                var sourceNext = sourceVertices[(edgeIndex+1)%ringLength];
                var sourcePrev = sourceVertices[(edgeIndex + ringLength - 1) % ringLength];
                var inDir = Vector3.Lerp(
                    Vector3.Cross(Vector3.up, (sourceNext - sourceLoc)),
                    Vector3.Cross(Vector3.up, (sourceLoc - sourcePrev)),
                    0.5f).normalized;

                var inLoc = sourceLoc + (inDir * borderWidth);
                var inTextureCoordinate = GeometryUtils.PolygonVertexToUV(inLoc, pose, uvPose);
                var outTextureCoordinate = GeometryUtils.PolygonVertexToUV(sourceLoc, pose, uvPose);

                var outerIndex = edgeIndex + ringLength;
                vertices[edgeIndex] = inLoc;
                vertices[outerIndex] = sourceLoc;
                textureCoordinates[edgeIndex] = inTextureCoordinate;
                textureCoordinates[outerIndex] = outTextureCoordinate;
                textureCoordinates2[edgeIndex] = new Vector2(tex2Along, 0.0f);
                textureCoordinates2[outerIndex] = new Vector2(tex2Along, 1.0f);

                tex2Along += (sourceNext - sourceLoc).magnitude / borderLengthTiling;

                var nextEdgeIndex = (edgeIndex + 1) % ringLength;
                if (nextEdgeIndex < ringLength)
                {
                    var innerNext = nextEdgeIndex + ringLength;

                    indices[indexCount++] = edgeIndex;
                    indices[indexCount++] = outerIndex;
                    indices[indexCount++] = nextEdgeIndex;

                    indices[indexCount++] = nextEdgeIndex;
                    indices[indexCount++] = outerIndex;
                    indices[indexCount++] = innerNext;
                }
            }

            // Close loop by duplicating first two verts with new uv2.
            var endIndex = ringLength * 2;
            vertices[endIndex] = vertices[0];
            vertices[endIndex + 1] = vertices[ringLength];
            textureCoordinates[endIndex] = textureCoordinates[0];
            textureCoordinates[endIndex + 1] = textureCoordinates[ringLength];

            tex2Along = Mathf.Round(tex2Along);
            textureCoordinates2[endIndex] = new Vector2(tex2Along, 0f);
            textureCoordinates2[endIndex + 1] = new Vector2(tex2Along, 1f);
        }

        internal static void SetSize<T>(this List<T> list, int size)
        {
            var count = list.Count;
            if (count > size)
            {
                list.RemoveRange(size, count - size);
                return;
            }

            if (list.Capacity < size)
                list.Capacity = size;

            while (list.Count < size)
            {
                list.Add(default);
            }
        }
    }
}

#if ARFOUNDATION_2_1_OR_NEWER
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARFoundation;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class ARPlaneExtensions
    {
        public static MRPlane ToMRPlane(this ARPlane plane)
        {
            var alignment = plane.alignment;
            var pose = plane.transform.GetWorldPose();

            var mrPlane = new MRPlane
            {
                id = plane.trackableId.ToMarsId(),
                alignment = alignment.ToMarsPlaneAlignment(),
                pose = pose,
                extents = plane.extents * 2.0f, // MR extents are diameter, AR extends are "(half dimensions) of the plane in meters."
                center = new Vector3(plane.centerInPlaneSpace.x,0.0f, plane.centerInPlaneSpace.y)
            };

            var nativeVertices = plane.boundary;
            if (nativeVertices.Length <= 0)
                return mrPlane;

            var count = nativeVertices.Length;
            var vertices = new List<Vector3>(count);
            var normals = new List<Vector3>(count);
            var textureCoordinates = new List<Vector2>(count);
            var indices = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var nativeVertex = nativeVertices[i];
                vertices.Add(new Vector3(nativeVertex.x, 0.0f, nativeVertex.y));
            }

            mrPlane.vertices = vertices;
            mrPlane.normals = normals;
            mrPlane.textureCoordinates = textureCoordinates;
            mrPlane.indices = indices;
            PlaneUtils.TriangulatePlaneFromVertices(mrPlane.pose, vertices, indices, normals, textureCoordinates);

            return mrPlane;
        }
    }
}
#endif

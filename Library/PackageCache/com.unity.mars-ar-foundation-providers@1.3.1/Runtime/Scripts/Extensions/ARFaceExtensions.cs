#if ARFOUNDATION_2_1_OR_NEWER
using System.Collections.Generic;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Unity.MARS.Data.ARFoundation
{
    [MovedFrom("Unity.MARS.Providers")]
    public static class ARFaceExtensions
    {
        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<Vector3> k_Vector3Buffer = new List<Vector3>();
        static readonly List<Vector2> k_Vector2Buffer = new List<Vector2>();
        static readonly List<int> k_IntBuffer = new List<int>();

        internal static void ToARFoundationFace(this ARFace face, XRFaceSubsystem xrFaceSubsystem, ref ARFoundationFace arFoundationFace)
        {
            if (arFoundationFace == null)
                arFoundationFace = new ARFoundationFace(face.trackableId.ToMarsId());

            arFoundationFace.pose = face.transform.GetWorldPose();
            arFoundationFace.TrackingState = face.trackingState.ToMARSTrackingState();

            var indices = face.indices;
            if (indices.Length > 0)
            {
                k_Vector3Buffer.Clear();
                foreach (var vertex in face.vertices)
                {
                    k_Vector3Buffer.Add(vertex);
                }

                arFoundationFace.Mesh.SetVertices(k_Vector3Buffer);

                k_Vector3Buffer.Clear();
                foreach (var normal in face.normals)
                {
                    k_Vector3Buffer.Add(normal);
                }

                arFoundationFace.Mesh.SetNormals(k_Vector3Buffer);

                k_Vector2Buffer.Clear();
                foreach (var uv in face.uvs)
                {
                    k_Vector2Buffer.Add(uv);
                }

                arFoundationFace.Mesh.SetUVs(0, k_Vector2Buffer);
                k_IntBuffer.Clear();
                foreach (var index in indices)
                {
                    k_IntBuffer.Add(index);
                }

                arFoundationFace.Mesh.SetTriangles(k_IntBuffer, 0);

#if !UNITY_EDITOR
#if UNITY_IOS && INCLUDE_ARKIT_FACE_PLUGIN
                // For iOS, we use ARKit Face Blendshapes to determine expressions
                arFoundationFace.GenerateLandmarks();
                arFoundationFace.CalculateExpressions(xrFaceSubsystem, face.trackableId);
#elif UNITY_ANDROID
                // For Android, we use the position of the face landmarks to determine expressions
                arFoundationFace.GenerateLandmarks();
                arFoundationFace.CalculateExpressions(ARCoreFaceLandmarksExtensions.LandmarkPositions);
#endif
#endif
            }
        }
    }
}
#endif

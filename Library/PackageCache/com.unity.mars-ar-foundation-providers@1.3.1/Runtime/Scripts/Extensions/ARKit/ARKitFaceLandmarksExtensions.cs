#if !UNITY_EDITOR && UNITY_IOS
using Unity.XRTools.Utils;
using UnityEngine;

namespace Unity.MARS.Data.ARFoundation
{
    static class ARKitFaceLandmarksExtensions
    {
        const int k_MeshLandmarksCount = 21;
        static readonly Vector3[] k_LandmarkPositions = new Vector3[k_MeshLandmarksCount];

        internal static void GenerateLandmarks(this ARFoundationFace arFoundationFace)
        {
            var landmarkTriangleIndices = ARKitLandmarkMeshIndices.instance.landmarkTriangleIndices;
            for (var i = 0; i < k_MeshLandmarksCount; i++)
            {
                var point = PointFromTriangle(arFoundationFace.Mesh.vertices, arFoundationFace.Mesh.triangles, landmarkTriangleIndices[i]);
                k_LandmarkPositions[i] = point;
            }

            MapToAuthorLandmarks(k_LandmarkPositions, arFoundationFace);
        }

        static Vector3 PointFromTriangle(Vector3[] vertices, int[] indices, int triangleIndex)
        {
            var index = triangleIndex * 3;
            var vert0 = vertices[indices[index]];
            var vert1 = vertices[indices[index + 1]];
            var vert2 = vertices[indices[index + 2]];

            var point = (vert0 + vert1 + vert2) * 0.33333333f;
            return point;
        }

        static void MapToAuthorLandmarks(Vector3[] vertexPositions, ARFoundationFace face)
        {
            var rotation = Quaternion.identity;

            var chin = new Pose(vertexPositions[(int)ARKitFaceMeshLandmark.ChinMiddle], rotation);
            var noseBridge = new Pose(vertexPositions[(int)ARKitFaceMeshLandmark.NoseBridge], rotation);
            var noseTip = new Pose(vertexPositions[(int)ARKitFaceMeshLandmark.NoseTip], rotation);

            var rightEyeOuter = vertexPositions[(int)ARKitFaceMeshLandmark.RightEyeOuter];
            var rightEyeUpper = vertexPositions[(int)ARKitFaceMeshLandmark.RightEyeTop];
            var rightEyeInner = vertexPositions[(int)ARKitFaceMeshLandmark.RightEyeInner];
            var rightEyeLower = vertexPositions[(int)ARKitFaceMeshLandmark.RightEyeBottom];
            var rightEyeAverage = (rightEyeOuter + rightEyeUpper + rightEyeInner + rightEyeLower) * 0.25f;
            var rightEye = new Pose(rightEyeAverage, rotation);

            var leftEyeOuter = vertexPositions[(int)ARKitFaceMeshLandmark.LeftEyeOuter];
            var leftEyeUpper = vertexPositions[(int)ARKitFaceMeshLandmark.LeftEyeTop];
            var leftEyeInner = vertexPositions[(int)ARKitFaceMeshLandmark.LeftEyeInner];
            var leftEyeLower = vertexPositions[(int)ARKitFaceMeshLandmark.LeftEyeBottom];
            var leftEyeAverage = (leftEyeOuter + leftEyeUpper + leftEyeInner + leftEyeLower) * 0.25f;
            var leftEye = new Pose(leftEyeAverage, rotation);

            var rightEyebrowInner = vertexPositions[(int)ARKitFaceMeshLandmark.RightEyebrowInner];
            var rightEyebrowOuter = vertexPositions[(int)ARKitFaceMeshLandmark.RightEyebrowOuter];
            var rightEyebrowAverage = (rightEyebrowInner + rightEyebrowOuter) * 0.5f;
            var rightEyebrow = new Pose(rightEyebrowAverage, rotation);

            var leftEyebrowInner = vertexPositions[(int)ARKitFaceMeshLandmark.LeftEyebrowInner];
            var leftEyebrowOuter = vertexPositions[(int)ARKitFaceMeshLandmark.LeftEyebrowOuter];
            var leftEyebrowAverage = (leftEyebrowInner + leftEyebrowOuter) * 0.5f;
            var leftEyebrow = new Pose(leftEyebrowAverage, rotation);

            var upperLipLeft = vertexPositions[(int)ARKitFaceMeshLandmark.UpperLipLeft];
            var upperLipRight = vertexPositions[(int)ARKitFaceMeshLandmark.UpperLipRight];
            var upperLipAverage = (upperLipLeft + upperLipRight) * 0.5f;
            var upperLip = new Pose(upperLipAverage, rotation);

            var lowerLipLeft = vertexPositions[(int)ARKitFaceMeshLandmark.LowerLipLeft];
            var lowerLipRight = vertexPositions[(int)ARKitFaceMeshLandmark.LowerLipRight];
            var lowerLipAverage = (lowerLipLeft + lowerLipRight) * 0.5f;
            var lowerLip = new Pose(lowerLipAverage, rotation);

            var leftLipCorner = vertexPositions[(int)ARKitFaceMeshLandmark.LeftLipCorner];
            var rightLipCorner = vertexPositions[(int)ARKitFaceMeshLandmark.RightLipCorner];
            var mouthAverage = (upperLipAverage + lowerLipAverage + leftLipCorner + rightLipCorner) * 0.25f;
            var mouth = new Pose(mouthAverage, rotation);

            var facePose = face.pose;
            face.LandmarkPoses[MRFaceLandmark.Chin] = facePose.ApplyOffsetTo(chin);
            face.LandmarkPoses[MRFaceLandmark.NoseBridge] = facePose.ApplyOffsetTo(noseBridge);
            face.LandmarkPoses[MRFaceLandmark.NoseTip] = facePose.ApplyOffsetTo(noseTip);
            face.LandmarkPoses[MRFaceLandmark.Mouth] = facePose.ApplyOffsetTo(mouth);
            face.LandmarkPoses[MRFaceLandmark.UpperLip] = facePose.ApplyOffsetTo(upperLip);
            face.LandmarkPoses[MRFaceLandmark.LowerLip] = facePose.ApplyOffsetTo(lowerLip);
            face.LandmarkPoses[MRFaceLandmark.RightEyebrow] = facePose.ApplyOffsetTo(rightEyebrow);
            face.LandmarkPoses[MRFaceLandmark.LeftEyebrow] = facePose.ApplyOffsetTo(leftEyebrow);
            face.LandmarkPoses[MRFaceLandmark.RightEye] = facePose.ApplyOffsetTo(rightEye);
            face.LandmarkPoses[MRFaceLandmark.LeftEye] = facePose.ApplyOffsetTo(leftEye);
        }
    }
}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;
using Unity.XRTools.Utils;

namespace Unity.MARS.Data.ARFoundation
{
    static class ARCoreFaceExpressionUtils
    {
        public static float LipCornerCoefficient(Vector3[] landmarks, ARCoreFaceMeshLandmark lipCornerLandmark, float min, float max)
        {
            var upperLip = (landmarks[(int)ARCoreFaceMeshLandmark.UpperLipLeft] + landmarks[(int)ARCoreFaceMeshLandmark.UpperLipRight]) * 0.5f;
            var corner = landmarks[(int)lipCornerLandmark];
            var chin = landmarks[(int)ARCoreFaceMeshLandmark.ChinMiddle];

            // when you open your mouth wide, the distance from a lip corner to chin increases,
            // and the distance from your upper lip to your chin also increases.  This allows
            // us to account for the first difference in a pretty stable way.
            var halfUpperLipToChinDistance = Vector3.Distance(upperLip, chin) * 0.5f;
            var distance = Vector3.Distance(corner, chin) - halfUpperLipToChinDistance;
            return CoefficientUtils.FromDistance(distance, min, max);
        }

        public static float EyebrowRaiseCoefficient(Vector3[] landmarks, ARCoreFaceMeshLandmark outer, ARCoreFaceMeshLandmark inner,
            ARCoreFaceMeshLandmark outerEye, float min, float max)
        {
            var innerBrow = landmarks[(int)inner];
            var outerBrow = landmarks[(int)outer];
            var eyeOuter = landmarks[(int)outerEye];
            var noseBridge = landmarks[(int)ARCoreFaceMeshLandmark.NoseBridge];

            var bridgeToInnerBrow = Vector3.Distance(innerBrow, noseBridge);
            var outerBrowToOuterEye = Vector3.Distance(outerBrow, eyeOuter);

            // we mostly base this on the distance from outer brow to outer eye, which works ok on its own
            // introducing a bit of weight from the distance between nose bridge and inner eyebrow
            // makes this more accurate across all possible brow raises and across different faces
            const float innerBrowWeight = 0.25f;
            const float outerBrowWeight = 0.75f;
            var distance = outerBrowToOuterEye * outerBrowWeight + bridgeToInnerBrow * innerBrowWeight;

            return CoefficientUtils.FromDistance(distance, min, max);
        }
    }
}
#endif

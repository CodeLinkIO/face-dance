using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    [MovedFrom("Unity.MARS")]
    public static class MRFaceExtensions
    {
        /// <summary>
        /// Calculates the Bounds of a MRFace using landmark positions.
        /// </summary>
        /// <returns>The min Bounds tha contains all the present face landmarks</returns>
        /// <param name="face">Face.</param>
        public static Bounds GetBounds(this IMRFace face)
        {
            // face pose position as the bound's center
            var center = face.pose.position;

            // default size
            var size = Vector3.one;

            // calculate size from landmarks
            if (face.LandmarkPoses != null)
            {
                // get extreme landmark positions
                var lowestX = float.PositiveInfinity;
                var highestX = float.NegativeInfinity;
                var lowestY = float.PositiveInfinity;
                var highestY = float.NegativeInfinity;
                var lowestZ = float.PositiveInfinity;
                var highestZ = float.NegativeInfinity;
                foreach (var landmarkPose in face.LandmarkPoses)
                {
                    var landmarkPosition = landmarkPose.Value.position;

                    lowestX = Mathf.Min(lowestX, landmarkPosition.x);
                    highestX = Mathf.Max(highestX, landmarkPosition.x);

                    lowestY = Mathf.Min(lowestY, landmarkPosition.y);
                    highestY = Mathf.Max(highestY, landmarkPosition.y);

                    lowestZ = Mathf.Min(lowestZ, landmarkPosition.z);
                    highestZ = Mathf.Max(highestZ, landmarkPosition.z);
                }

                // calculate bounding box using the extreme values
                size.x = highestX - lowestX;
                size.y = highestY - lowestY;
                size.z = highestZ - lowestZ;
            }

            return new Bounds(center, size);
        }
    }
}

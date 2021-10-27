using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Image marker size constants.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class MarkerConstants
    {
        public static readonly string[] MarkerSizeOptions = {"Custom", "Postcard", "A4 Paper", "Poster"};
        public static readonly Vector2[] MarkerSizeOptionsValuesInMeters = { new Vector2(1, 1),
            new Vector2(k_PostcardWidthInMeters, k_PostcardHeightInMeters),
            new Vector2(k_A4PaperWidthInMeters,k_A4PaperHeightInMeters),
            new Vector2(k_PosterWidthInMeters, k_PosterHeightInMeters) };

        const float k_PostcardWidthInMeters = 0.148f;
        const float k_PostcardHeightInMeters = 0.105f;

        const float k_A4PaperWidthInMeters = 0.210f;
        const float k_A4PaperHeightInMeters = 0.297f;

        const float k_PosterWidthInMeters = 0.841f;
        const float k_PosterHeightInMeters = 1.189f;

        const float k_MinimumPhysicalMarkerWidthInMeters = 0.01f;
        const float k_MinimumPhysicalMarkerHeightInMeters = 0.01f;

        public static float PostcardWidthInMeters { get => k_PostcardWidthInMeters; }
        public static float PostcardHeightInMeters { get => k_PostcardHeightInMeters; }
        public static float MinimumPhysicalMarkerSizeWidthInMeters { get => k_MinimumPhysicalMarkerWidthInMeters; }
        public static float MinimumPhysicalMarkerSizeHeightInMeters { get => k_MinimumPhysicalMarkerHeightInMeters; }
        public static Vector2 MinimumPhysicalMarkerSizeInCentimeters => new Vector2(k_MinimumPhysicalMarkerWidthInMeters*100, k_MinimumPhysicalMarkerHeightInMeters*100);

        /// <summary>
        /// Get the size option index from the <c>MarkerConstants</c>
        /// </summary>
        /// <param name="sizeToCompare">Size to compare to size constants</param>
        /// <returns>The selected size option index, or 0 for a custom size</returns>
        public static int GetSelectedMarsMarkerSizeOption(Vector2 sizeToCompare)
        {
            // Start from 1 since 0 is the custom option
            for (var i = 1; i < MarkerSizeOptionsValuesInMeters.Length; i++)
            {
                if (sizeToCompare == MarkerSizeOptionsValuesInMeters[i])
                    return i;
            }

            return 0;
        }
    }
}

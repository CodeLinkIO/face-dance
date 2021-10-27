using System;
using UnityEngine;

namespace Unity.MARS.Data
{
    [Serializable]
    public struct GeographicBoundingBox
    {
        /// <summary>
        /// The latitude / longitude coordinate of the center of the bounding box
        /// </summary>
        [Tooltip("The latitude / longitude coordinate of the center of the bounding box")]
        public GeographicCoordinate center;

        /// <summary>
        /// The distance the bounding box extends from the center in the north and south directions (in degrees)
        /// </summary>
        [Tooltip("The distance from the center in latitude degrees that the boundary extends")]
        public double latitudeExtents;

        /// <summary>
        /// The distance the bounding box extends from the center in the east and west directions (in degrees)
        /// </summary>
        [Tooltip("The distance from the center in longitude degrees that the boundary extends")]
        public double longitudeExtents;
    }
}

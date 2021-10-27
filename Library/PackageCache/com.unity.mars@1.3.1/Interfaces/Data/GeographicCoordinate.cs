using System;
using UnityEngine;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Represents a location in latitude and longitude
    /// </summary>
    [Serializable]
    public struct GeographicCoordinate
    {
        /// <summary>
        /// Coordinates representing an invalid location.  
        /// </summary>
        public static readonly GeographicCoordinate Invalid = new GeographicCoordinate();

        /// <summary>
        /// Geographical location latitude.
        /// </summary>
        public double latitude;
        /// <summary>
        /// Geographical location latitude.
        /// </summary>
        public double longitude;

        /// <summary>
        /// Create a new <c>GeographicCoordinate</c>
        /// </summary>
        /// <param name="latitude">Geographical location latitude.</param>
        /// <param name="longitude">Geographical location latitude.</param>
        public GeographicCoordinate(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return String.Format("latitude: {0} , longitude: {1}", latitude, longitude);
        }

        /// <summary>
        /// Implicit conversion of <c>GeographicCoordinate</c> to a new <c>Vector2</c> with no projection.
        /// </summary>
        /// <param name="coordinate">location in latitude and longitude</param>
        /// <returns>Location as a vector 2</returns>
        public static implicit operator Vector2(GeographicCoordinate coordinate)
        {
            return new Vector2((float)coordinate.latitude, (float)coordinate.longitude);
        }

        /// <summary>
        /// Implicit conversion of <c>Vector2</c> to a new <c>GeographicCoordinate</c> with no projection.
        /// </summary>
        /// <param name="vec">location as a vector 2</param>
        /// <returns>Location in latitude and longitude</returns>
        public static implicit operator GeographicCoordinate(Vector2 vec)
        {
            return new GeographicCoordinate(vec.x, vec.y);
        }

        /// <summary>
        /// Implicit conversion of a device's <c>LocationInfo</c> to a new <c>GeographicCoordinate</c>
        /// </summary>
        /// <param name="location">Device's location info</param>
        /// <returns>Location in latitude and longitude</returns>
        public static implicit operator GeographicCoordinate(LocationInfo location)
        {
            return new GeographicCoordinate(location.latitude, location.longitude);
        }
    }
}

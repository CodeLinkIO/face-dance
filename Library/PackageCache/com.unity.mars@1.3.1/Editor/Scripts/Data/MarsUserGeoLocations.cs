using System;
using Unity.MARS.Data;
using Unity.MARS.Settings;
using Unity.XRTools.Utils;
using UnityEditor.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEditor.MARS.Data
{
    /// <summary>
    /// Asset that contains user created geo locations and default geo locations for us in the <c>GeoLocationModule</c>
    /// </summary>
    [ScriptableSettingsPath(MARSCore.UserSettingsFolder)]
    [MovedFrom("Unity.MARS")]
    public sealed class MarsUserGeoLocations : EditorScriptableSettings<MarsUserGeoLocations>
    {
        static readonly UserGeoLocation[] k_DefaultLocations =
        {
            new UserGeoLocation(new GeographicCoordinate(37.7749,-122.4194),"San Francisco, United States"),
            new UserGeoLocation(new GeographicCoordinate(47.6062,-122.3321),"Seattle, United States"),
            new UserGeoLocation(new GeographicCoordinate(30.2672,-97.7431),"Austin, United States"),
            new UserGeoLocation(new GeographicCoordinate(40.4406,-79.9959),"Pittsburgh, United States"),
            new UserGeoLocation(new GeographicCoordinate(4.8087,-75.6906),"Pereira, Colombia"),
            new UserGeoLocation(new GeographicCoordinate(45.5017,-73.5673),"Montreal, Canada"),
            new UserGeoLocation(new GeographicCoordinate(51.4545,-2.5879),"Bristol, United Kingdom"),
            new UserGeoLocation(new GeographicCoordinate(52.1917,-1.7083),"Stratford-upon-Avon, United Kingdom"),
            new UserGeoLocation(new GeographicCoordinate(50.8225,-0.1372),"Brighton, United Kingdom"),
            new UserGeoLocation(new GeographicCoordinate(51.5074,-0.1278),"London, United Kingdom"),
            new UserGeoLocation(new GeographicCoordinate(48.8566,2.3522),"Paris, France"),
            new UserGeoLocation(new GeographicCoordinate(45.1885,5.7245),"Grenoble, France"),
            new UserGeoLocation(new GeographicCoordinate(55.6761,12.5683),"Copenhagen, Denmark"),
            new UserGeoLocation(new GeographicCoordinate(52.5200,13.4050),"Berlin, Germany"),
            new UserGeoLocation(new GeographicCoordinate(59.3293,18.0686),"Stockholm, Sweden"),
            new UserGeoLocation(new GeographicCoordinate(54.8985,23.9036),"Kaunas, Lithuania"),
            new UserGeoLocation(new GeographicCoordinate(60.1699,24.9384),"Helsinki, Finland"),
            new UserGeoLocation(new GeographicCoordinate(54.6872,25.2797),"Vilnius, Lithuania"),
            new UserGeoLocation(new GeographicCoordinate(1.3521,103.8198),"Singapore, Singapore"),
            new UserGeoLocation(new GeographicCoordinate(37.5665,126.9780),"Seoul, South Korea"),
            new UserGeoLocation(new GeographicCoordinate(31.2304,121.4737),"Shanghai, China"),
            new UserGeoLocation(new GeographicCoordinate(35.6804,139.7690),"Tokyo, Japan")
        };

        [SerializeField]
        [Tooltip("Collection of UserGeoLocation for selection in the GeoLocationModule")]
        UserGeoLocation[] m_UserGeoLocations = k_DefaultLocations;

        /// <summary>
        /// Collection of <c>UserGeoLocation</c> for selection in the <c>GeoLocationModule</c>
        /// </summary>
        public UserGeoLocation[] UserGeoLocations => m_UserGeoLocations;

        void OnValidate()
        {
            if (m_UserGeoLocations.Length == 0)
                m_UserGeoLocations = k_DefaultLocations;
        }
    }

    /// <summary>
    /// Data that represents a geo location coordinate and data for displaying it in the GUI
    /// </summary>
    [Serializable]
    [MovedFrom("Unity.MARS")]
    public sealed class UserGeoLocation
    {
        /// <summary>
        /// Default user geo location at 0 lat 0 long. This is where the Prime Meridian and the Equator intersect
        /// and is referred to as Null Island.
        /// </summary>
        public static readonly UserGeoLocation NullIsland = new UserGeoLocation(
            new GeographicCoordinate(k_DefaultLatitude, k_DefaultLongitude), k_NullIslandName);

        const string k_NullIslandName = "Null Island, Middle of Nowhere";
        // default simulated coordinates are @ Null Island
        const float k_DefaultLatitude = 0f;
        const float k_DefaultLongitude = 0f;

        [SerializeField]
        [Tooltip("Location in Latitude and Longitude")]
        GeographicCoordinate m_Location;

        [SerializeField]
        [Tooltip("Name of the Location")]
        string m_Name;

        /// <summary>
        /// Location in Latitude and Longitude
        /// </summary>
        public GeographicCoordinate Location => m_Location;

        /// <summary>
        /// Name of the Location
        /// </summary>
        public string Name => m_Name;

        /// <summary>
        /// Create a new <c>UserGeoLocation</c> with the default value of <c>NullIsland</c>
        /// </summary>
        public UserGeoLocation()
        {
            m_Location = NullIsland.Location;
            m_Name = string.Empty;
        }

        /// <summary>
        /// Create a new <c>UserGeoLocation</c>
        /// </summary>
        /// <param name="location">Location in Latitude and Longitude</param>
        /// <param name="name">Name of the Location</param>
        public UserGeoLocation(GeographicCoordinate location, string name)
        {
            m_Location = location;
            m_Name = name;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, Location.ToString());
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 397) ^ Location.GetHashCode();
        }
    }
}

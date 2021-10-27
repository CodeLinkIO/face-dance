using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// A common list of trait names for consistency
    /// This is not an exhaustive list of all possible traits, but simply provides a reference of traits that can be
    /// easily renamed and universally agreed-upon. It is quite possible to use trait names that are not specified here.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class TraitNames
    {
        /// <summary>
        /// Pose trait
        /// </summary>
        public const string Pose = "pose";
        /// <summary>
        /// Point trait
        /// </summary>
        public const string Point = "point";
        /// <summary>
        /// Bounds2D trait
        /// </summary>
        public const string Bounds2D = "bounds2d";
        /// <summary>
        /// Alignment trait
        /// </summary>
        public const string Alignment = "alignment";
        /// <summary>
        /// Geolocation trait
        /// </summary>
        public const string Geolocation = "geolocation";
        /// <summary>
        /// Height above floor trait
        /// </summary>
        public const string HeightAboveFloor = "heightAboveFloor";
        /// <summary>
        /// Display flat trait
        /// </summary>
        public const string DisplayFlat = "displayFlat";
        /// <summary>
        /// Display spatial trait
        /// </summary>
        public const string DisplaySpatial = "displaySpatial";
        /// <summary>
        /// Tracking trait
        /// </summary>
        public const string TrackingState = "trackingState";

        // Semantic tag traits
        /// <summary>
        /// Plane trait
        /// </summary>
        public const string Plane = "plane";
        /// <summary>
        /// Face trait
        /// </summary>
        public const string Face = "face";
        /// <summary>
        /// Floor trait
        /// </summary>
        public const string Floor = "floor";
        /// <summary>
        /// Environment trait
        /// </summary>
        public const string Environment = "environment";
        /// <summary>
        /// User trait
        /// </summary>
        public const string User = "user";
        /// <summary>
        /// In view trait
        /// </summary>
        public const string InView = "inView";
        /// <summary>
        /// Marker trait
        /// </summary>
        public const string Marker = "marker";
        /// <summary>
        /// Marker Id trait
        /// </summary>
        public const string MarkerId = "markerId";

        /// <summary>
        /// A tracked human body trait
        /// </summary>
        public const string Body = "body";
    }

    /// <summary>
    /// A common list of trait definitions for consistency
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public static class TraitDefinitions
    {
        /// <summary>
        /// Pose trait definition
        /// </summary>
        public static readonly TraitDefinition Pose = new TraitDefinition(TraitNames.Pose, typeof(Pose));
        /// <summary>
        /// Point trait definition
        /// </summary>
        public static readonly TraitDefinition Point = new TraitDefinition(TraitNames.Point, typeof(Vector3));
        /// <summary>
        /// Bounds2D trait definition
        /// </summary>
        public static readonly TraitDefinition Bounds2D = new TraitDefinition(TraitNames.Bounds2D, typeof(Vector2));
        /// <summary>
        /// Alignment trait definition
        /// </summary>
        public static readonly TraitDefinition Alignment = new TraitDefinition(TraitNames.Alignment, typeof(int));
        /// <summary>
        /// Geolocation trait definition
        /// </summary>
        public static readonly TraitDefinition GeoCoordinate = new TraitDefinition(TraitNames.Geolocation, typeof(Vector2));
        /// <summary>
        /// Height above floor trait definition
        /// </summary>
        public static readonly TraitDefinition HeightAboveFloor = new TraitDefinition(TraitNames.HeightAboveFloor, typeof(float));

        // Semantic tag traits
        /// <summary>
        /// Plane trait definition
        /// </summary>
        public static readonly TraitDefinition Plane = new TraitDefinition(TraitNames.Plane, typeof(bool));
        /// <summary>
        /// Face trait definition
        /// </summary>
        public static readonly TraitDefinition Face = new TraitDefinition(TraitNames.Face, typeof(bool));
        /// <summary>
        /// Floor trait definition
        /// </summary>
        public static readonly TraitDefinition Floor = new TraitDefinition(TraitNames.Floor, typeof(bool));
        /// <summary>
        /// Environment trait definition
        /// </summary>
        public static readonly TraitDefinition Environment = new TraitDefinition(TraitNames.Environment, typeof(bool));
        /// <summary>
        /// User trait definition
        /// </summary>
        public static readonly TraitDefinition User = new TraitDefinition(TraitNames.User, typeof(bool));
        /// <summary>
        /// In view trait definition
        /// </summary>
        public static readonly TraitDefinition InView = new TraitDefinition(TraitNames.InView, typeof(bool));
        /// <summary>
        /// Display flat trait definition
        /// </summary>
        public static readonly TraitDefinition DisplayFlat = new TraitDefinition(TraitNames.DisplayFlat, typeof(bool));
        /// <summary>
        /// Display spatial trait definition
        /// </summary>
        public static readonly TraitDefinition DisplaySpatial = new TraitDefinition(TraitNames.DisplaySpatial, typeof(bool));
        /// <summary>
        /// Marker trait definition
        /// </summary>
        public static readonly TraitDefinition Marker = new TraitDefinition(TraitNames.Marker, typeof(bool));
        /// <summary>
        /// Marker Id trait definition
        /// </summary>
        public static readonly TraitDefinition MarkerId = new TraitDefinition(TraitNames.MarkerId, typeof(string));
        /// <summary>
        /// Tracking state trait definition
        /// </summary>
        public static readonly TraitDefinition TrackingState = new TraitDefinition(TraitNames.TrackingState, typeof(int));

        /// <summary>
        /// A tracked human body trait definition
        /// </summary>
        public static readonly TraitDefinition Body = new TraitDefinition(TraitNames.Body, typeof(bool));
    }
}

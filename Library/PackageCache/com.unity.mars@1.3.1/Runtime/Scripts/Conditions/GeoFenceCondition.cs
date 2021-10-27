using Unity.MARS.Attributes;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the user's geolocation
    /// </summary>
    [HelpURL(DocumentationConstants.GeofenceConditionDocs)]
    [ComponentTooltip("Requires the object to be inside or outside of the specified geolocation.")]
    [MonoBehaviourComponentMenu(typeof(GeoFenceCondition), "Condition/GeoFence")]
    [MovedFrom("Unity.MARS")]
    public class GeoFenceCondition : Condition<Vector2>
    {
        /// <summary>
        /// Used to determine whether our condition is true if
        /// the object is inside or outside the geo fence.
        /// </summary>
        public enum GeoFenceRule
        {
            /// <summary>
            /// Object should be inside the geo fence
            /// </summary>
            Inside,

            /// <summary>
            /// Object should be outside the geo fence
            /// </summary>
            Outside
        }

        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.GeoCoordinate };

#pragma warning disable 649
        [SerializeField]
        GeographicBoundingBox m_BoundingBox;

        [SerializeField]
        [Tooltip("Whether the condition relies on the user being inside or outside the fence")]
        GeoFenceRule m_Rule;
#pragma warning restore 649

        /// <summary>
        /// Gets/Sets the bounding box for our geo fence.
        /// </summary>
        public GeographicBoundingBox BoundingBox
        {
            get => m_BoundingBox;
            set => m_BoundingBox = value;
        }

        /// <summary>
        /// Gets/Sets the bounding rule for our geo fence.
        /// </summary>
        public GeoFenceRule Rule
        {
            get => m_Rule;
            set => m_Rule = value;
        }

#if UNITY_EDITOR
        public override void OnValidate()
        {
            base.OnValidate();
            m_BoundingBox.center.latitude = MathUtility.Clamp(m_BoundingBox.center.latitude, -GeoLocationModule.MaxLatitude, GeoLocationModule.MaxLatitude);
            m_BoundingBox.center.longitude = MathUtility.Clamp(m_BoundingBox.center.longitude, -GeoLocationModule.MaxLongitude, GeoLocationModule.MaxLongitude);

            // the 5th decimal place is worth ~1.1m in length at the equator, and trends toward 0m closer to a pole.
            // This was chosen as the minimum extents due to better resolution with phone / headset GPS being unlikely.
            // https://en.wikipedia.org/wiki/Decimal_degrees
            const double minimumExtents = 0.00001;
            m_BoundingBox.latitudeExtents = MathUtility.Clamp(m_BoundingBox.latitudeExtents, minimumExtents, GeoLocationModule.MaxLatitude);
            m_BoundingBox.longitudeExtents = MathUtility.Clamp(m_BoundingBox.longitudeExtents, minimumExtents, GeoLocationModule.MaxLongitude);
        }
#endif

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public override float RateDataMatch(ref Vector2 data)
        {
            if (m_Rule == GeoFenceRule.Inside)
                return IsInside(data) ? 1f : 0f;

            return IsInside(data) ? 0f : 1f;
        }

        bool IsInside(Vector2 data)
        {
            var latitudeDistance = MathUtility.ShortestAngleDistance(
                m_BoundingBox.center.latitude, data.x, GeoLocationModule.MaxLatitude, 180f);
            var longitudeDistance = MathUtility.ShortestAngleDistance(
                m_BoundingBox.center.longitude, data.y, GeoLocationModule.MaxLongitude, 360f);

            return (latitudeDistance < 0 ? -latitudeDistance : latitudeDistance) < m_BoundingBox.latitudeExtents &&
                (longitudeDistance < 0 ? -longitudeDistance : longitudeDistance) < m_BoundingBox.longitudeExtents;
        }
    }
}

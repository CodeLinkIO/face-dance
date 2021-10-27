using System;
using Unity.MARS.Attributes;
using UnityEngine;
using Unity.MARS.Data;
using Unity.MARS.Query;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Represents a situation that depends on the quality of a tracked objects' tracking data
    /// </summary>
    [HelpURL(DocumentationConstants.TrackingStateConditionDocs)]
    [DisallowMultipleComponent]
    [ComponentTooltip("Requires the trackable object to have a minimum tracking quality.")]
    [MonoBehaviourComponentMenu(typeof(TrackingStateCondition), "Condition/Tracking State")]
    public class TrackingStateCondition : Condition<int>
    {
        static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.TrackingState };

#pragma warning disable 649
        [SerializeField]
        [Tooltip("The minimum quality of object tracking needed to maintain this Proxy's match")]
        MARSTrackingState m_MinimumTrackingState = MARSTrackingState.Limited;
#pragma warning restore 649

        public MARSTrackingState MinimumState { get => m_MinimumTrackingState; set => m_MinimumTrackingState = value; }

        /// <inheritdoc />
        public override TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

        /// <inheritdoc />
        public override float RateDataMatch(ref int data)
        {
            var dataState = ((MARSTrackingState) data);
            if ((dataState == m_MinimumTrackingState)
                || (dataState == MARSTrackingState.Tracking)
                || (m_MinimumTrackingState == MARSTrackingState.Unknown))
                return 1f;
            if (m_MinimumTrackingState == MARSTrackingState.Limited)
                return ((dataState == MARSTrackingState.Limited) ? 1f : 0f);
            return 0f;
        }
    }
}

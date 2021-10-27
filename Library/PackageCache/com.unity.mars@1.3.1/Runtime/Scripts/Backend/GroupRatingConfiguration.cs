using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Defines how a group's match rating components will be reduced to a single rating
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public struct GroupRatingConfiguration
    {
        /*
            We want to prevent extreme weights for child matches.
            If the weight of child matches is too small, the match will optimize only for the
            relations, even if the matches for all children are close to failing.
            The opposite happens if the weight of child matches is too large.
        */
        const float k_MinimumWeight = 0.1f;
        const float k_DefaultWeight = 0.5f;
        const float k_MaximumWeight = 0.9f;

        /// <summary>
        /// The percentage of the group's match rating that is determined by the ratings of child matches
        /// </summary>
        public readonly float MemberMatchWeight;

        /// <summary>
        /// Defines how a group's match rating components will be reduced to a single rating
        /// </summary>
        /// <param name="membersWeight">The percentage of the group's match rating that is determined by the ratings of child matches</param>
        public GroupRatingConfiguration(float membersWeight = k_DefaultWeight)
        {
            MemberMatchWeight = Mathf.Clamp(membersWeight, k_MinimumWeight, k_MaximumWeight);
        }
    }
}

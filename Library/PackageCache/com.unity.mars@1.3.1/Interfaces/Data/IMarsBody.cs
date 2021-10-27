using System.Collections.Generic;
using UnityEngine;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides a template for tracked body data
    /// </summary>
    public interface IMarsBody : IMRTrackable
    {
        /// <summary>
        /// The Mecanim muscle data for this body
        /// </summary>
        HumanPose BodyPose { get; }

        /// <summary>
        /// Height of the body in meters
        /// </summary>
        float Height { get; }

        /// <summary>
        /// (Optional) Lengths of each bone of this body, corresponding to the Mecanim humanoid
        /// </summary>
        List<float> BoneLengths { get; }
    }
}

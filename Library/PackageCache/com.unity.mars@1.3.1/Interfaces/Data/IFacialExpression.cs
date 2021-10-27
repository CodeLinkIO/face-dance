using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Represents the standard way of interacting with a facial expression
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IFacialExpression
    {
        /// <summary>
        /// The named expression expressed by this instance
        /// </summary>
        MRFaceExpression Name { get; }

        /// <summary>
        /// A number from 0 to 1 indicating how much the given expression is shown
        /// </summary>
        float Coefficient { get; }

        /// <summary>
        /// The coefficient value at which engaged / disengaged events will happen
        /// </summary>
        float Threshold { get; set; }

        /// <summary>
        /// What happens when the expression is engaged
        /// </summary>
        event Action<float> Engaged;

        /// <summary>
        /// What happens when the expression is disengaged
        /// </summary>
        event Action<float> Disengaged;
    }
}

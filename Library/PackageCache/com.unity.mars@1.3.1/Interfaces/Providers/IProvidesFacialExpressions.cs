using System;
using Unity.MARS.Data;
using Unity.XRTools.ModuleLoader;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Providers
{
    /// <summary>
    /// Defines the API for a facial expression provider
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IProvidesFacialExpressions : IFunctionalityProvider
    {
        /// <summary>
        /// Register for events associated with a given facial expression
        /// </summary>
        /// <param name="expression">The named facial expression to subscribe to</param>
        /// <param name="engaged">What happens when the facial expression is shown</param>
        /// <param name="disengaged">What happens when the facial expression stops being shown</param>
        void SubscribeToExpression(MRFaceExpression expression, Action<float> engaged, Action<float> disengaged);

        /// <summary>
        /// Unregister for events associated with a given facial expression
        /// </summary>
        /// <param name="expression">The named facial expression to unsubscribe from</param>
        /// <param name="engaged">The engaged action to remove from the event handler</param>
        /// <param name="disengaged">The disengaged action to remove from the event handler</param>
        void UnsubscribeToExpression(MRFaceExpression expression, Action<float> engaged, Action<float> disengaged);
    }
}

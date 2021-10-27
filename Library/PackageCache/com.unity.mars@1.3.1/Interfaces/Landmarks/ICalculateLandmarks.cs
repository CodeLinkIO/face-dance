using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Landmarks
{
    /// <summary>
    /// Components that implement this interface can define landmarks
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ICalculateLandmarks
    {
        /// <summary>
        /// A list of landmark definitions that this class can support.
        /// </summary>
        List<LandmarkDefinition> AvailableLandmarkDefinitions { get; }

        /// <summary>
        /// Called when a landmark is set to reference this source, or when the definition is changed.
        /// The source can use this to set the default starting properties and location for the landmark.
        /// </summary>
        /// <param name="landmark"> The landmark to setup.</param>
        void SetupLandmark(ILandmarkController landmark);

        /// <summary>
        /// Get an action that calculates a landmark with the given definition. If the landmark
        /// does not have the proper settings or output set up, it should return null
        /// </summary>
        /// <param name="definition"> The landmark definition to get the calculation for</param>
        /// <returns></returns>
        Action<ILandmarkController> GetLandmarkCalculation(LandmarkDefinition definition);

        /// <summary>
        /// This event can be invoked by the landmark source to indicate the source data has changed.
        /// By default, landmarks referencing this source will subscribe to this event and update.
        /// </summary>
        event Action<ICalculateLandmarks> dataChanged;
    }
}

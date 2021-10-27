using System;
using Unity.MARS.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Interface for a condition that can be created from data.
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ICreateFromData
    {
        /// <summary>
        /// Modifies the properties so that the data is the optimal data for this condition
        /// </summary>
        /// <param name="data">The data that should be optimal for the condition after this method is called</param>
        void OptimizeForData(TraitDataSnapshot data);

        /// <summary>
        /// Modifies the properties so that the data is acceptable for this condition
        /// </summary>
        /// <param name="data">The data that should pass this condition after this method is called</param>
        void IncludeData(TraitDataSnapshot data);

        /// <summary>
        /// Formats data into a string that is human-readable and appropriate for the condition
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The formatted string</returns>
        string FormatDataString(TraitDataSnapshot data);

        /// <summary>
        /// Return the rating this condition has for the given data snapshot
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The result of the condition's data rate matching method</returns>
        float GetConditionRatingForData(TraitDataSnapshot data);
    }

    /// <summary>
    /// Interface for a relation that can be created from 2 pieces of data and added to a set with 2 children
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ICreateFromDataPair
    {
        /// <summary>
        /// Modifies the properties so that the data is the optimal data for this relation
        /// </summary>
        /// <param name="child1Data">The data that should be optimal for child 1 after this method is called</param>
        /// <param name="child2Data">The data that should be optimal for child 2 after this method is called</param>
        void OptimizeForData(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data);

        /// <summary>
        /// Modifies the properties so that the data is acceptable for this relation
        /// </summary>
        /// <param name="child1Data">The data for child 1 that should pass this relation after this method is called</param>
        /// <param name="child2Data">The data for child 2 that should pass this relation after this method is called</param>
        void ConformToData(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data);

        /// <summary>
        /// Formats data into a string that is human-readable and appropriate for the relation
        /// </summary>
        /// <param name="child1Data">The data for child 1</param>
        /// <param name="child2Data">The data for child 2</param>
        /// <returns>The formatted string</returns>
        string FormatDataString(TraitDataSnapshot child1Data, TraitDataSnapshot child2Data);
    }

    /// <summary>
    /// Attribute for classes that implement ICreateFromData. The attribute indicates 1. that this class should be included in lists of
    /// suggested components, 2. whether they are added by default, and 3. what order to use when sorting suggested components
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MovedFrom("Unity.MARS")]
    public class CreateFromDataOptions : Attribute
    {
        /// <summary>
        /// If true, this component will be added by default when suggested.
        /// </summary>
        public bool AddByDefault { get; set; }

        /// <summary>
        /// The relative order of this component in a sorted list of components, where a lower number is comes before a higher number
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Constructs the Create From Data options attribute
        /// </summary>
        /// <param name="order">The component's sort order</param>
        /// <param name="addByDefault">Whether this component will be added by default</param>
        public CreateFromDataOptions(int order, bool addByDefault)
        {
            Order = order;
            AddByDefault = addByDefault;
        }
    }
}

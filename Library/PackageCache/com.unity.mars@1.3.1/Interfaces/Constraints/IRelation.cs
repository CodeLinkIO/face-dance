using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    public interface IRelationBase : IConditionBase
    {
        /// <summary>
        /// The first child object of this relation
        /// </summary>
        IMRObject child1 { get; }

        /// <summary>
        /// The second child object of this relation
        /// </summary>
        IMRObject child2 { get; }
    }

    /// <summary>
    /// Used for collecting components with this interface, implement the templated version
    /// </summary>
    public interface IRelation : IRelationBase, IRequiresTraits { }

    /// <summary>
    /// A constraint between two MR objects that is used to filter data in a query
    /// </summary>
    /// <typeparam name="T">The type of data to filter against</typeparam>
    public interface IRelation<T> : IRelation, IRequiresTraits<T>
    {
        /// <summary>
        /// The trait to test against for the first child
        /// </summary>
        string child1TraitName { get; }

        /// <summary>
        /// The trait to test against for the second child
        /// </summary>
        string child2TraitName { get; }

        /// <summary>
        /// Compares the given trait data to the filter function
        /// </summary>
        /// <param name="child1Data">The data being filtered against for the first child</param>
        /// <param name="child2Data">The data being filtered against for the second child</param>
        /// <returns>A number from 0 to 1 indicating how well a set of data matches</returns>
        float RateDataMatch(ref T child1Data, ref T child2Data);
    }

    public static class IRelationGenericMethods
    {
        /// <summary>
        /// Collapses a relation's match rating into a pass/fail.
        /// </summary>
        /// <param name="relation">The relation to evaluate</param>
        /// <param name="value">The data being filtered against</param>
        /// <typeparam name="T">The type of data the relation uses</typeparam>
        /// <returns>True if the given trait data passes the filter function, false otherwise</returns>
        public static bool PassesRelation<T>(this IRelation<T> relation, ref T child1Value, ref T child2Value)
        {
            return relation.RateDataMatch(ref child1Value, ref child2Value) > 0f;
        }
    }

}

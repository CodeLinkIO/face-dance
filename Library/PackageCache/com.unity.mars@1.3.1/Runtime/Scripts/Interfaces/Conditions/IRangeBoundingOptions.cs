using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Conditions
{
    /// <summary>
    /// Standard options for conditions that work with a bounded range of data
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IRangeBoundingOptions
    {
        /// <summary>
        /// Whether the data must be at least a certain value
        /// </summary>
        bool minBounded { get; set; }

        /// <summary>
        /// Whether the data must be at most a certain value
        /// </summary>
        bool maxBounded { get; set; }
    }

    public interface IRangeBoundingOptions<T> : IRangeBoundingOptions
    {
        /// <summary>
        /// The value at the bottom end of a condition's acceptable range
        /// </summary>
        T minimum { get; set; }

        /// <summary>
        /// The value at the top end of a condition's acceptable range
        /// </summary>
        T maximum { get; set; }
    }
}

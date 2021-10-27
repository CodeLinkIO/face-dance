using UnityEngine;

namespace Unity.MARS
{
    interface IReducibleRating
    {
        /// <summary>
        /// Combine all component match ratings at this level into a single scalar value
        /// </summary>
        /// <returns></returns>
        float Reduce();
    }
}

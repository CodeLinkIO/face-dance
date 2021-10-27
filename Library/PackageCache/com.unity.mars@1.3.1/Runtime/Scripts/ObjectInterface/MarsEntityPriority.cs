using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Describes how important getting a match for a MARS Entity is, relative to other entities
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public enum MarsEntityPriority : sbyte
    {
        Minimum = sbyte.MinValue,
        Low = -1,
        Normal = 0,
        High = 1,
        Maximum = sbyte.MaxValue
    }

}

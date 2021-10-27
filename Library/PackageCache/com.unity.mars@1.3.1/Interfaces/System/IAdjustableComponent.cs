using System;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Authoring
{
    /// <summary>
    /// Interface for MARS components that have an adjusting state
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface IAdjustableComponent
    {
        /// <summary>
        /// Whether the component is in the adjusting state
        /// </summary>
        bool Adjusting { get; set; }

        /// <summary>
        /// Invoked when the adjusting state changes. Passes the new adjusting state.
        /// </summary>
        event Action<bool> AdjustingChanged;
    }
}

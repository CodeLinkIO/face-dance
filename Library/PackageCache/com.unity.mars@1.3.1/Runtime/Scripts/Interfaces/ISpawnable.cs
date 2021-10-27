using Unity.MARS.Query;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Provides access to callbacks from Replicator
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public interface ISpawnable : IMatchAcquireHandler, IMatchUpdateHandler, IMatchLossHandler
    {
    }
}

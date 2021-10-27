using Unity.MARS.Simulation;
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// Common base class for all MARS Proxy types (including Replicator)
    /// </summary>
    [DisallowMultipleComponent]
    [SelectionBase]
    public abstract class MARSEntity : MonoBehaviour, ISimulatable { }
}

using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Represents all traits required by the Conditions and Actions on a single Proxy
    /// </summary>
    [MovedFrom("Unity.MARS")]
    public class ProxyTraitRequirements : HashSet<TraitRequirement>
    {
        /// <summary>
        /// Represents all traits required by the Conditions and Actions on a single Proxy
        /// </summary>
        /// <param name="requirements">Trait requirements</param>
        public ProxyTraitRequirements(IEnumerable<TraitRequirement> requirements)
        {
            foreach (var r in requirements)
            {
                Add(r);
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Contains information about which data is used for each child in a set match.
    /// </summary>
    [MovedFrom("Unity.MARS.Data")]
    public class SetMatchData
    {
        public Dictionary<IMRObject, int> dataAssignments;
        public Dictionary<IMRObject, Exclusivity> exclusivities;
    }
}

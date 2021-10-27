#if UNITY_EDITOR
using System.Collections.Generic;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS
{
    static class QueryObjectMapping
    {
        internal static readonly Dictionary<QueryMatchID, GameObject> Map = new Dictionary<QueryMatchID, GameObject>();

        internal static readonly Dictionary<QueryMatchID, GameObject> Sets = new Dictionary<QueryMatchID, GameObject>();
    }
}
#endif

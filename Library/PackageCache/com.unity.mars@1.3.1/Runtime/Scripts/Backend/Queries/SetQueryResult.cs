using System;
using System.Collections.Generic;
using Unity.MARS.Data;

namespace Unity.MARS.Query
{
    /// <summary>
    /// Data returned from a particular set query
    /// </summary>
    public class SetQueryResult
    {
        public QueryMatchID queryMatchId;

        /// <summary>
        /// Data returned for each child involved in the set query
        /// </summary>
        public readonly Dictionary<IMRObject, QueryResult> childResults = new Dictionary<IMRObject, QueryResult>();

        /// <summary>
        /// Children that are not required to maintain the query match, which lost their data in this update
        /// </summary>
        public readonly HashSet<IMRObject> nonRequiredChildrenLost = new HashSet<IMRObject>();

        /// <summary>
        /// Backup list of children involved in the set query for proper copying/restoration
        /// </summary>
        readonly HashSet<IMRObject> m_AllChildren = new HashSet<IMRObject>();

        public void SetChildren<T>(T children) where T : class, IEnumerable<IMRObject>
        {
            foreach (var child in children)
            {
                childResults[child] = new QueryResult(queryMatchId);
                m_AllChildren.Add(child);
            }
        }

        public void SetChildren(Dictionary<IMRObject, QueryResult> children)
        {
            foreach (var kvp in children)
            {
                childResults[kvp.Key] = kvp.Value;
                m_AllChildren.Add(kvp.Key);
            }
        }

        public SetQueryResult(QueryMatchID id, IEnumerable<IMRObject> children)
        {
            queryMatchId = id;
            SetChildren(children);
        }

        public SetQueryResult(QueryMatchID id)
        {
            queryMatchId = id;
        }

        public void RestoreResults()
        {
            foreach (var child in m_AllChildren)
            {
                if (!childResults.ContainsKey(child))
                {
                    childResults[child] = new QueryResult(queryMatchId);
                }
            }
        }

        /// <summary>
        /// (Obsolete) Reset is not supported and will be removed in a future version.
        /// </summary>
        [Obsolete("Reset is not supported and will be removed in a future version.")]
        public void Reset()
        {
            foreach (var kvp in childResults)
            {
                kvp.Value.Reset();
            }

            queryMatchId = QueryMatchID.NullQuery;
        }

        internal bool AllMemberMatchesInvalid()
        {
            foreach (var kvp in childResults)
            {
                var childResult = kvp.Value;
                if (childResult.DataID != (int) ReservedDataIDs.Invalid)
                    return false;
            }

            return true;
        }
    }
}

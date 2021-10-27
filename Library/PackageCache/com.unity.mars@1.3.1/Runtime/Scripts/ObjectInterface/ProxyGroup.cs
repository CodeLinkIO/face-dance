using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Authoring;
using Unity.MARS.Conditions;
using Unity.MARS.Data.Reasoning;
using Unity.MARS.Query;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Unity.MARS
{
    /// <summary>
    /// A MARS Entity representing a grouping of related proxies to match simultaneously
    /// </summary>
    [DisallowMultipleComponent]
    [HelpURL(DocumentationConstants.ProxyGroupDocs)]
    [ComponentTooltip("Represents a grouping of related proxies to match simultaneously")]
    [MonoBehaviourComponentMenu(typeof(ProxyGroup), "Proxy Group")]
    public class ProxyGroup : MARSEntity, IUsesSetQueryResults, IHasEditorColor
    {
        [Serializable]
        struct GroupMemberMetaData
        {
            public Proxy arObject;
            public bool required;
        }

        [SerializeField]
        [Tooltip("A color that will be associated with this group in the editor.")]
        [HideInInspector] // Will be drawn by the custom editor
        Color m_Color;

        [SerializeField]
        [HideInInspector]
        int m_ColorIndex;

        [SerializeField]
        [Tooltip("Behavior around timing and recovery of queries")]
        CommonQueryData m_CommonQueryData;

        [SerializeField]
        [HideInInspector]
        [Tooltip("The list of AR objects that are considered part of this group.")]
        List<GroupMemberMetaData> m_ChildObjects = new List<GroupMemberMetaData>();

        /// <summary>
        /// Occurs when the result of this proxy group changes, can be null to indicate no match.
        /// </summary>
        public event Action<SetQueryResult> MatchChanged;

        readonly List<ISetMatchAcquireHandler> m_AcquireHandlers = new List<ISetMatchAcquireHandler>();
        readonly List<ISetMatchUpdateHandler> m_UpdateHandlers = new List<ISetMatchUpdateHandler>();
        readonly List<ISetMatchLossHandler> m_LossHandlers = new List<ISetMatchLossHandler>();
        readonly List<ISetMatchTimeoutHandler> m_TimeoutHandlers = new List<ISetMatchTimeoutHandler>();

        Relations m_Relations;
        Dictionary<IMRObject, SetChildArgs> m_Children = new Dictionary<IMRObject, SetChildArgs>();
        Dictionary<Proxy, QueryArgs> m_ChildrenQueryArgs = new Dictionary<Proxy, QueryArgs>();
        int m_TrackedInstancesCount;
        QueryState m_QueryState = QueryState.Unknown;
        internal Replicator AssociatedReplicator { get; set; }
        SetQueryArgs m_QueryArgs;

        static readonly List<Proxy> k_ChildObjects = new List<Proxy>();
        static readonly List<Relation> k_Relations = new List<Relation>();
        static readonly List<MultiRelationBase> k_MultiRelations = new List<MultiRelationBase>();

        /// <summary>
        /// A color that will be associated with this object in the editor.
        /// </summary>
        public Color color { get { return m_Color; } set { m_Color = value; } }

        public int colorIndex
        {
            get { return m_ColorIndex; }
            set { m_ColorIndex = value; }
        }

        /// <summary>
        /// How important is this group matching
        /// </summary>
        public MarsEntityPriority Priority
        {
            get => m_CommonQueryData.priority;
            set => m_CommonQueryData.priority = value;
        }

        /// <summary>
        /// Should the group attempt to re-acquire on tracking loss?
        /// </summary>
        public bool ReacquireOnLoss
        {
            get => m_CommonQueryData.reacquireOnLoss;
            set => m_CommonQueryData.reacquireOnLoss = value;
        }

        /// <summary>
        /// What part of the query lifecycle this group is in
        /// </summary>
        public QueryState queryState { get { return m_QueryState; } }

        /// <summary>
        /// The identifier for this Object's query
        /// </summary>
        public QueryMatchID queryID { get; private set; }

        /// <summary>
        /// The number of children this group currently has in its list. Call RepopulateChildList before getting this value
        /// to ensure it is most updated.
        /// </summary>
        /// <value> Number of child objects of the group</value>
        public int childCount { get { return m_ChildObjects.Count; } }

        /// <summary>
        /// Finds the index of a child in the child list
        /// </summary>
        /// <param name="child">The child object</param>
        /// <returns>The index of the child if it's in the group's list. If the child is not found in the list, returns -1</returns>
        public int IndexOfChild(Proxy child)
        {
            for (var i = 0; i < m_ChildObjects.Count; i++)
            {
                if (m_ChildObjects[i].arObject == child)
                    return i;
            }

            return -1;
        }

        void Reset()
        {
            m_CommonQueryData.reacquireOnLoss = true;
            this.SetNewColorIfDefault();
        }

#if UNITY_EDITOR
        public void OnValidate()
        {
            RepopulateChildList();
        }
#endif


        public void GetChildList(List<Proxy> children)
        {
            children.Clear();
            var needRepopulate = false;
            foreach (var currentChild in m_ChildObjects)
            {
                if (currentChild.arObject != null)
                {
                    children.Add(currentChild.arObject);
                }
                else
                {
                    needRepopulate = true;
                    break;
                }
            }

            if (needRepopulate)
            {
                RepopulateChildList();
                GetChildList(children);
            }
        }

        public void RepopulateChildList()
        {
            k_ChildObjects.Clear();
            GetComponentsInChildren(k_ChildObjects);

            // Remove invalid entries
            var childCounter = 0;
            while (childCounter < m_ChildObjects.Count)
            {
                var currentChild = m_ChildObjects[childCounter];
                if (currentChild.arObject == null)
                {
                    m_ChildObjects.RemoveAt(childCounter);
                }
                else
                {
                    var currentChildGo = currentChild.arObject.gameObject;
                    if (!currentChildGo.transform.IsChildOf(transform))
                    {
                        m_ChildObjects.RemoveAt(childCounter);
                    }
                    else
                    {
                        k_ChildObjects.Remove(currentChild.arObject);
                        childCounter++;
                    }
                }
            }

            // Add new entries
            foreach (var newChild in k_ChildObjects)
            {
                m_ChildObjects.Add(new GroupMemberMetaData { arObject = newChild, required = false });
            }
            k_ChildObjects.Clear();
        }

        public void SetChildRequired(Proxy child, bool required)
        {
            RepopulateChildList();
            for (var i = 0; i < m_ChildObjects.Count; ++i)
            {
                if (m_ChildObjects[i].arObject == child)
                {
                    m_ChildObjects[i] = new GroupMemberMetaData { arObject = child, required = required };
                    return;
                }
            }

            Debug.LogWarningFormat("Proxy '{0}' is not a child of this group.", child.name);
        }

        /// <summary>
        /// Request the MARS scene this proxy group is in to be evaluated for matches
        /// </summary>
        /// <param name="onEvaluationComplete">An optional callback, executed when the evaluation process completes</param>
        /// <returns>A description of the system's response to the request</returns>
        public MarsSceneEvaluationRequestResponse RequestEvaluation(Action onEvaluationComplete = null)
        {
            return this.RequestSceneEvaluation(onEvaluationComplete);
        }

        /// <summary>
        /// Called when this ProxyGroup is manually un-matched, but not in the event of data loss leading to unmatching
        /// </summary>
        public Action<QueryMatchID, bool> OnUnmatched;

        void OnEnable()
        {
            if (!AssociatedReplicator)
            {
                // sometimes the exemplar ProxyGroup within a replicator enables before it is disabled.
                if (GetComponentInParent<Replicator>())
                    return;
            }

            Initialize();
            PerformQuery(QueryMatchID.NullQuery);
        }

        internal void Initialize(bool forceRepopulate = false)
        {
            // We don't double-query if we're already tracking
            if (m_QueryState != QueryState.Unavailable && m_QueryState != QueryState.Unknown
                && m_QueryState != QueryState.Resuming)
            {
                Debug.LogError($"{name} is already tracking, cannot query again!");
                return;
            }
            UpdateQueryState(queryState, null, true);

            // if we're dynamically creating this ProxyGroup,
            // we need to support collecting children during OnEnable
            if(m_ChildObjects.Count == 0 | forceRepopulate)
                RepopulateChildList();
        }

        static bool MultiRelationChildrenValid(List<MultiRelationBase> multiRelations)
        {
            foreach (var relation in multiRelations)
            {
                IMRObject child1 = null, child2 = null;
                foreach(var iRelation in relation.HostedComponents)
                {
                    if (!(iRelation is SubRelation subRelation))
                        return false;

                    if (child1 == null)
                        child1 = subRelation.child1;
                    if (child2 == null)
                        child2 = subRelation.child2;

                    // all sub-relations in a multi-relation must refer to the same child context objects
                    if (subRelation.child1 != child1 || subRelation.child2 != child2)
                        return false;
                }
            }

            return true;
        }

        internal SetQueryArgs PerformQuery(QueryMatchID reservedID)
        {
            if (m_QueryArgs != null && !queryID.IsNullQuery())
            {
                for (var i = 0; i < m_ChildObjects.Count; ++i)
                {
                    m_ChildObjects[i].arObject.Initialize();
                }
                this.RegisterSetQuery(queryID, m_QueryArgs);
                return m_QueryArgs;
            }

            GetComponentsInChildren(m_AcquireHandlers);
            GetComponentsInChildren(m_UpdateHandlers);
            GetComponentsInChildren(m_LossHandlers);
            GetComponentsInChildren(m_TimeoutHandlers);

#if UNITY_EDITOR
            if (HasInvalidRelations())
                return null;
#endif

            BuildChildArgs(true);

            m_Relations = new Relations(gameObject, m_Children);
            var queryArgs = new SetQueryArgs
            {
                commonQueryData = m_CommonQueryData,
                relations = m_Relations,
                // We always need acquire and loss events, in order to update tracking state
                onAcquire = OnMatchAcquire,
                onLoss = OnMatchLoss
            };

            m_QueryArgs = queryArgs;

            if (m_UpdateHandlers.Count > 0 || GetComponentInChildren<IMatchUpdateHandler>() != null) // Children could still need regular updates
                queryArgs.onMatchUpdate = OnMatchUpdate;

            if (m_CommonQueryData.currentTimeOut > 0)
                queryArgs.onTimeout = OnMatchTimeout;

            if (queryID.IsNullQuery() && !reservedID.IsNullQuery())
                queryID = reservedID;

            if (queryID.IsNullQuery())
                queryID = this.RegisterSetQuery(queryArgs);
            else
                this.RegisterSetQuery(queryID, queryArgs);

            // set member's match IDs equal to this group's
            foreach (var data in m_ChildObjects)
            {
                data.arObject.OverrideQueryID(queryID);
            }

            if (AssociatedReplicator != null)
                AssociatedReplicator.AddReplicatorCallbacksGroup(this, queryArgs);

#if UNITY_EDITOR
            QueryObjectMapping.Sets[queryID] = gameObject;
#endif
            return queryArgs;
        }

#if UNITY_EDITOR
        bool HasInvalidRelations()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return false;

            RepopulateChildList();
            GetComponents(k_Relations);
            GetComponents(k_MultiRelations);

            if (!MultiRelationChildrenValid(k_MultiRelations))
                return true;

            foreach (var relation in k_Relations)
            {
                relation.EnsureChildClients();
                if (relation.child1 != null && relation.child2 != null)
                    continue;

                Debug.LogWarning($"{relation.GetType().Name} in ProxyGroup '{name}' has an invalid child reference");
                k_Relations.Clear();
                return true;
            }

            k_Relations.Clear();

            return false;
        }
#endif

        void ReInitialize()
        {
            Unmatch(false);

            m_Relations.children.Clear();
            m_Children.Clear();
            m_ChildrenQueryArgs.Clear();
            m_AcquireHandlers.Clear();
            m_UpdateHandlers.Clear();
            m_LossHandlers.Clear();
            m_TimeoutHandlers.Clear();

            Initialize(true);

            // Build child args will handle the
            // other half of member re-initialization
            foreach (var childObject in m_ChildObjects)
            {
                childObject.arObject.ClearState();
            }
        }

        /// <summary>
        /// Informs the DB of changes to this ProxyGroup's conditions and relations after activation.
        /// </summary>
        /// <param name="updateReasoning">Pass false if you plan to call UpdateReasoning manually, such as doing changes to multiple ProxyGroups at once</param>
        public void SyncModifications(bool updateReasoning = true)
        {
            if(queryID.IsNullQuery() || !isActiveAndEnabled)
                return;

            Unmatch(false);

            ReInitialize();

            GetComponentsInChildren(m_AcquireHandlers);
            GetComponentsInChildren(m_UpdateHandlers);
            GetComponentsInChildren(m_LossHandlers);
            GetComponentsInChildren(m_TimeoutHandlers);

#if UNITY_EDITOR
            if (HasInvalidRelations())
                return;
#endif

            BuildChildArgs(true);

            m_Relations = new Relations(gameObject, m_Children);
            var queryArgs = new SetQueryArgs
            {
                commonQueryData = m_CommonQueryData,
                relations = m_Relations,
                // We always need acquire and loss events, in order to update tracking state
                onAcquire = OnMatchAcquire,
                onLoss = OnMatchLoss
            };

            m_QueryArgs = queryArgs;

            if (m_UpdateHandlers.Count > 0 || GetComponentInChildren<IMatchUpdateHandler>() != null) // Children could still need regular updates
                queryArgs.onMatchUpdate = OnMatchUpdate;

            if (m_CommonQueryData.currentTimeOut > 0)
                queryArgs.onTimeout = OnMatchTimeout;

            this.ModifySetQuery(queryID, queryArgs);

            // set member's match IDs equal to this group's
            foreach (var data in m_ChildObjects)
            {
                data.arObject.OverrideQueryID(queryID);
            }

            if(AssociatedReplicator != null)
                AssociatedReplicator.AddReplicatorCallbacksGroup(this, queryArgs);

            UpdateReasoning();
        }

        /// <summary>
        /// Notifies the session and reasoning module
        /// to re-check the capabilities and add any reasoning APIs
        /// that may now be required after changing conditions and
        /// relationships on ProxyGroups
        /// If performing multiple
        /// </summary>
        public static void UpdateReasoning()
        {
            MARSSession.Instance.CheckCapabilities();
            ReasoningModule.instance.ResetReasoningAPIs();
        }

        internal Dictionary<IMRObject, SetChildArgs> BuildChildArgs(bool performQuery = false)
        {
            for (var i = 0; i < m_ChildObjects.Count; ++i)
            {
                var child = m_ChildObjects[i].arObject;
                if (child == null)
                {
                    Debug.LogWarning($"Child object {i} is null for ProxyGroup {name}", this);
                    return null;
                }

                if(performQuery)
                    child.Initialize();
                else
                    child.InitializeWithoutState();

                var required = m_ChildObjects[i].required;
                m_Children[child] = new SetChildArgs(child.conditions, child.exclusivity, required, child.GetRequirements());

                m_ChildrenQueryArgs[child] = new QueryArgs
                {
                    exclusivity = child.exclusivity,
                    commonQueryData = m_CommonQueryData,
                    conditions = child.conditions
                };
            }

            return m_Children;
        }

        /// <summary>
        /// Cause this proxy group to give up its match, without removing it from the system.
        /// </summary>
        /// <param name="searchForNewMatch">
        /// If true, the system will search for a different match automatically.
        /// If false, the system will not search for a new match automatically.
        /// </param>
        /// <returns>True if this group already had a match, and that was given up.  False otherwise.</returns>
        public bool Unmatch(bool searchForNewMatch = true)
        {
            OnUnmatched?.Invoke(queryID, searchForNewMatch);
            return this.UnmatchGroup(queryID, searchForNewMatch);
        }

        // Not intended for users - They should call Unmatch() on the member Proxy, which calls this under the hood.
        internal bool UnmatchMember(Proxy member, bool searchForNewMatch = false)
        {
            foreach (var childObject in m_ChildObjects)
            {
                if (childObject.arObject == member)
                {
                    // if this member was required for the group match, we need to un-match the whole group
                    return childObject.required ? this.UnmatchGroup(queryID, searchForNewMatch)
                        // otherwise we are free to un-match only this proxy
                                                : this.UnmatchNonRequiredMember(queryID, member);
                }
            }

            return false;
        }

        void OnDisable()
        {
            if (!queryID.IsNullQuery())
            {
                this.UnregisterSetQuery(queryID, true);
                m_QueryState = QueryState.Unavailable;  // We do this manually so we do not accidentally toggle all the active states off
            }

            m_AcquireHandlers.Clear();
            m_UpdateHandlers.Clear();
            m_LossHandlers.Clear();
            m_TimeoutHandlers.Clear();

#if UNITY_EDITOR
            QueryObjectMapping.Sets.Remove(queryID);
#endif
        }

        /// <summary>
        /// Called when a query match has been found.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryData">Data associated with this event</param>
        void OnMatchAcquire(SetQueryResult queryData)
        {
            if (!isActiveAndEnabled)
            {
                Unmatch();
                UpdateQueryState(QueryState.Unavailable);
                return;
            }

            m_TrackedInstancesCount++;
            UpdateQueryState(QueryState.Tracking, queryData);

            foreach (var childData in m_ChildObjects)
            {
                var child = childData.arObject;
                child.OnClientMatchAcquire(queryData.childResults[child]);
            }

            foreach (var handler in m_AcquireHandlers)
            {
#if UNITY_EDITOR
                try
                {
#endif
                    handler.OnSetMatchAcquire(queryData);
#if UNITY_EDITOR
                }
                catch (Exception e)
                {
                    Debug.LogError("Caught exception in Set: " + e.Message + "\n" + e.StackTrace);
                }
#endif
            }
        }

        /// <summary>
        /// Called when a query match's data has updated.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// If any non-required children have been lost in this update, they will receive loss events.
        /// </summary>
        /// <param name="queryData">Data associated with this event</param>
        void OnMatchUpdate(SetQueryResult queryData)
        {
            var nonRequiredChildrenLost = queryData.nonRequiredChildrenLost;
            foreach (var childData in m_ChildObjects)
            {
                var child = childData.arObject;
                // Non-required children could be missing from child results if they were previously lost.
                QueryResult childResult;
                if (queryData.childResults.TryGetValue(child, out childResult))
                {
                    if (nonRequiredChildrenLost.Contains(child))
                        child.OnClientMatchLoss(childResult);
                    else
                        child.OnClientMatchUpdate(childResult);
                }
            }

            foreach (var handler in m_UpdateHandlers)
            {
                handler.OnSetMatchUpdate(queryData);
            }

            CheckGroupMatchChanged(queryData);
        }

        /// <summary>
        /// Called when a query match has been lost.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryData">Data associated with this event</param>
        void OnMatchLoss(SetQueryResult queryData)
        {
            m_TrackedInstancesCount--;
            if (m_TrackedInstancesCount == 0)
                UpdateQueryState(m_CommonQueryData.reacquireOnLoss ? QueryState.Resuming : QueryState.Unavailable);

            foreach (var childData in m_ChildObjects)
            {
                var child = childData.arObject;
                // Non-required children could be missing from child results if they were previously lost.
                QueryResult childResult;
                if (queryData.childResults.TryGetValue(child, out childResult))
                    child.OnClientMatchLoss(childResult);
            }

            foreach (var handler in m_LossHandlers)
            {
                handler.OnSetMatchLoss(queryData);
            }

            CheckGroupMatchChanged(null);
        }

        /// <summary>
        /// Called when no query match has been found in time.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryArgs">The original query associated with this object</param>
        void OnMatchTimeout(SetQueryArgs queryArgs)
        {
            UpdateQueryState(QueryState.Unavailable);

            foreach (var childData in m_ChildObjects)
            {
                var child = childData.arObject;
                child.OnClientMatchTimeout(m_ChildrenQueryArgs[child]);
            }

            foreach (var handler in m_TimeoutHandlers)
            {
                handler.OnSetMatchTimeout(queryArgs);
            }
        }

        internal void UpdateQueryState(QueryState state, SetQueryResult queryData = null, bool forceUpdate = false)
        {
            if (m_QueryState != state || forceUpdate)
            {
                m_QueryState = state;

                CheckGroupMatchChanged(queryData);
            }
        }

        void CheckGroupMatchChanged(SetQueryResult queryData)
        {
            MatchChanged?.Invoke(queryData);
        }

        /// <summary>
        /// Sets if a proxy is required by the relevant relations.
        /// </summary>
        /// <param name="proxy">The target proxy, which must be a child of this group.</param>
        /// <param name="isRequired">Whether or not the proxy is required.</param>
        public void SetRequired(Proxy proxy, bool isRequired)
        {
            for (var i = 0; i < m_ChildObjects.Count; i++)
            {
                var data = m_ChildObjects[i];
                if (data.arObject != proxy)
                    continue;

                data.required = isRequired;
                m_ChildObjects[i] = data;
                break;
            }
        }

        /// <summary>
        /// Returns true if the proxy child is required for matching.
        /// </summary>
        /// <param name="proxy">The proxy to check against.</param>
        /// <returns>True if required, false if optional.</returns>
        public bool GetRequired(Proxy proxy)
        {
            for (var i = 0; i < m_ChildObjects.Count; i++)
            {
                var data = m_ChildObjects[i];
                if (data.arObject == proxy)
                    return data.required;
            }

            return false;
        }

        /// <summary>
        /// Should only be used before this first enables/initializes
        /// </summary>
        internal void OverrideGroupQueryID(QueryMatchID queryMatchID) { queryID = queryMatchID; }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Attributes;
using Unity.MARS.Authoring;
using Unity.MARS.Data;
using UnityEngine;
using Unity.MARS.Query;
using Unity.XRTools.Utils;
using UnityEngine.Assertions;

namespace Unity.MARS
{
    /// <summary>
    /// Represents a link between one real-world object and a Unity GameObject
    /// </summary>
    [DisallowMultipleComponent]
    [HelpURL(DocumentationConstants.ProxyDocs)]
    [ComponentTooltip("Represents a link between one real-world object and a Unity GameObject")]
    [MonoBehaviourComponentMenu(typeof(Proxy), "Proxy")]
    public class Proxy : MARSEntity, IUsesQueryResults, IUsesDevQueryResults, IMRObject, IHasEditorColor
    {
        /// <summary>
        /// Holds cached visibility data about a single child object
        /// </summary>
        internal struct ObjectVisibilityInfo
        {
            /// <summary>
            /// Initial visibility state.
            /// </summary>
            public bool initialState;

            /// <summary>
            /// Disable call depth.
            /// </summary>
            public int disableCalls;
        }

        // Local method use only -- created here to reduce garbage collection
        static readonly List<GameObject> k_EnableList = new List<GameObject>();
        static readonly List<GameObject> k_DisableList = new List<GameObject>();
        static readonly List<IRequiresTraits> k_TraitRequirers = new List<IRequiresTraits>();
        static readonly List<IComponentHost<ICondition>> k_MultiConditionRequirers = new List<IComponentHost<ICondition>>();
        static readonly List<TraitRequirement> k_AccumulatedRequirements = new List<TraitRequirement>();

        [SerializeField]
        [Tooltip("A color that will be associated with this object in the editor.")]
        [HideInInspector] // Will be drawn by the custom editor
        Color m_Color;

        [SerializeField]
        [HideInInspector]
        int m_ColorIndex;

        [SerializeField]
        [Tooltip("Behavior around timing and recovery of queries")]
        CommonQueryData m_CommonQueryData;

        [SerializeField]
        [Tooltip("Sets how data used in this query should be reserved")]
        Exclusivity m_Exclusivity = Exclusivity.Reserved;

        /// <summary>
        /// Occurs when the result of this proxy changes, can be null to indicate no match.
        /// </summary>
        public event Action<QueryResult> MatchChanged;

        QueryResult m_PreviousMatch;

        // All active conditions on the object
        ProxyConditions m_Conditions;

        // Original state of child objects for activation/deactivation
        readonly Dictionary<GameObject, ObjectVisibilityInfo> m_VisibilityStates = new Dictionary<GameObject, ObjectVisibilityInfo>();
        bool m_VisibilityChanges;

        QueryState m_QueryState = QueryState.Unknown;

        // Whether or not this object makes its own queries or is controlled by a greater construct
        bool m_ControlsQueryLifeCycle = true;
        bool m_IsGroupMember;
        internal Replicator AssociatedReplicator { get; set; }

        /// <summary>
        /// Mapping of this proxy's child objects to their associated visibility state data.
        /// </summary>
        internal Dictionary<GameObject, ObjectVisibilityInfo> VisibilityStates => m_VisibilityStates;

        // All actions the Proxy will take, categorized by event
        readonly List<IMatchAcquireHandler> m_AcquireHandlers = new List<IMatchAcquireHandler>();
        readonly List<IMatchUpdateHandler> m_UpdateHandlers = new List<IMatchUpdateHandler>();
        readonly List<IMatchLossHandler> m_LossHandlers = new List<IMatchLossHandler>();
        readonly List<IMatchTimeoutHandler> m_TimeoutHandlers = new List<IMatchTimeoutHandler>();
        readonly List<IMatchVisibilityHandler> m_VisibilityHandlers = new List<IMatchVisibilityHandler>();

        /// <summary>
        /// A color that will be associated with this object in the editor.
        /// </summary>
        public Color color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        /// <inheritdoc />
        public int colorIndex
        {
            get { return m_ColorIndex; }
            set { m_ColorIndex = value; }
        }

        /// <summary>
        /// What part of the query lifecycle this Proxy is in
        /// </summary>
        public QueryState queryState { get { return m_QueryState; } }

        /// <summary>
        /// The identifier for this Object's query
        /// </summary>
        public QueryMatchID queryID { get; private set; }

        /// <summary>
        /// The current query result data
        /// </summary>
        public QueryResult currentData { get; private set; }

        /// <summary>
        /// Can the data captured by this Proxy be used by another Proxy?
        /// </summary>
        public Exclusivity exclusivity
        {
            get { return m_Exclusivity; }
            set { m_Exclusivity = value; }
        }

        /// <summary>
        /// How important is this Proxy matching
        /// </summary>
        public MarsEntityPriority Priority
        {
            get => m_CommonQueryData.priority;
            set => m_CommonQueryData.priority = value;
        }

        /// <summary>
        /// Should the proxy attempt to re-acquire on tracking loss?
        /// </summary>
        public bool ReacquireOnLoss
        {
            get => m_CommonQueryData.reacquireOnLoss;
            set => m_CommonQueryData.reacquireOnLoss = value;
        }

        /// <summary>
        /// Data filters for this Object's query
        /// </summary>
        public ProxyConditions conditions
        {
            get
            {
                if (m_Conditions == null)
                    m_Conditions = new ProxyConditions(this);

                return m_Conditions;
            }
        }

        /// <summary>
        /// Called when this Proxy is manually un-matched, but not in the event of data loss leading to unmatching
        /// </summary>
        public Action<QueryMatchID, bool> OnUnmatched;

        void Awake()
        {
            m_IsGroupMember = GetComponentInParent<ProxyGroup>() != null;
            m_ControlsQueryLifeCycle = !m_IsGroupMember;
        }

        void OnEnable()
        {
            if (m_ControlsQueryLifeCycle == false || m_QueryState == QueryState.Resuming)
                return;

            if (MARSSession.Instance == null) {
                Debug.LogError("Proxy requires a MARSSession in the scene.");
                return;
            }
            Initialize();
            PerformQuery(QueryMatchID.NullQuery);
        }

        void OnDisable()
        {
            // Disabling the object releases the query, if it has one
            if (m_ControlsQueryLifeCycle && !queryID.IsNullQuery())
            {
                this.UnregisterQuery(queryID);
            }

            UpdateQueryState(QueryState.Unknown);

#if UNITY_EDITOR
            QueryObjectMapping.Map.Remove(queryID);
#endif
            RestoreChildStates();
            m_VisibilityStates.Clear();
            m_AcquireHandlers.Clear();
            m_UpdateHandlers.Clear();
            m_LossHandlers.Clear();
            m_TimeoutHandlers.Clear();
            m_VisibilityHandlers.Clear();
        }

        void Reset()
        {
            m_CommonQueryData.reacquireOnLoss = true;
            m_CommonQueryData.priority = MarsEntityPriority.Normal;
            this.SetNewColorIfDefault();
        }

        internal void Initialize()
        {
            InitializeWithoutState();
            UpdateQueryState(queryState, null, true);
        }

        internal void InitializeWithoutState()
        {
            // We don't double-query if we're already tracking
            if (!CanSubmitQuery())
            {
                Debug.LogError(string.Format("{0} is already tracking, cannot query again!", name));
                return;
            }

            // Cache all the actions that will be called
            using (var componentFilter = new CachedComponentFilter<IAction, Proxy>(this, includeDisabled: false))
            {
                componentFilter.StoreMatchingComponents(m_AcquireHandlers);
                componentFilter.StoreMatchingComponents(m_UpdateHandlers);
                componentFilter.StoreMatchingComponents(m_LossHandlers);
                componentFilter.StoreMatchingComponents(m_TimeoutHandlers);
                componentFilter.StoreMatchingComponents(m_VisibilityHandlers);
            }
        }

        /// <summary>
        /// Request the MARS scene this proxy is in to be evaluated for matches
        /// </summary>
        /// <param name="onEvaluationComplete">An optional callback, executed when the evaluation process completes</param>
        /// <returns>A description of the system's response to the request</returns>
        public MarsSceneEvaluationRequestResponse RequestEvaluation(Action onEvaluationComplete = null)
        {
            return this.RequestSceneEvaluation(onEvaluationComplete);
        }

        /// <summary>
        /// Get the trait requirements for this Proxy
        /// </summary>
        /// <returns></returns>
        public ProxyTraitRequirements GetRequirements()
        {
            k_TraitRequirers.Clear();
            // Cache all the trait requirements for actions
            using (var componentFilter = new CachedComponentFilter<IRequiresTraits, Proxy>(this, includeDisabled: false))
            {
                componentFilter.StoreMatchingComponents(k_TraitRequirers);
            }

            // gather requirements from multi-conditions
            k_MultiConditionRequirers.Clear();
            using (var componentFilter = new CachedComponentFilter<IComponentHost<ICondition>, Proxy>(this, includeDisabled: false))
            {
                componentFilter.StoreMatchingComponents(k_MultiConditionRequirers);
            }

            foreach (var host in k_MultiConditionRequirers)
            {
                k_TraitRequirers.AddRange(host.HostedComponents);
            }

            k_AccumulatedRequirements.Clear();
            foreach (var requirer in k_TraitRequirers)
            {
                k_AccumulatedRequirements.AddRange(requirer.GetRequiredTraits());
            }

            return new ProxyTraitRequirements(k_AccumulatedRequirements);
        }

        internal QueryArgs PerformQuery(QueryMatchID reservedID)
        {
            if (!reservedID.IsNullQuery())
            {
                if (queryID.IsNullQuery())
                    queryID = reservedID;
            }

            var queryArgs = new QueryArgs
            {
                exclusivity = exclusivity,
                commonQueryData = m_CommonQueryData,
                conditions = conditions,
                traitRequirements = GetRequirements(),
                onAcquire = OnClientMatchAcquire,
                onLoss = OnClientMatchLoss
            };

            if (m_UpdateHandlers.Count > 0)
                queryArgs.onMatchUpdate = OnClientMatchUpdate;
            if (m_CommonQueryData.currentTimeOut > 0)
                queryArgs.onTimeout = OnClientMatchTimeout;

            if (queryID.IsNullQuery())
                queryID = this.RegisterQuery(queryArgs);
            else
                this.RegisterQuery(queryID, queryArgs);

            if (AssociatedReplicator != null)
                AssociatedReplicator.AddReplicatorCallbacksProxy(this, queryArgs);

#if UNITY_EDITOR
            QueryObjectMapping.Map[queryID] = gameObject;
#endif

            // Return the query args used in case the caller wants to tweak it more
            return queryArgs;
        }

        internal void ClearState()
        {
            Unmatch(false);
            RestoreChildStates();

            m_VisibilityStates.Clear();
            m_AcquireHandlers.Clear();
            m_LossHandlers.Clear();
            m_TimeoutHandlers.Clear();
            m_UpdateHandlers.Clear();
            m_VisibilityHandlers.Clear();
        }

        internal void ReInitialize()
        {
            ClearState();

            InitializeWithoutState();
            UpdateQueryState(QueryState.Unknown, null, true);
        }

        /// <summary>
        /// Informs the DB of changes to this proxy's conditions after activation.
        /// </summary>
        public void SyncModifications()
        {
            if(queryID.IsNullQuery() || !isActiveAndEnabled)
                return;

            if (m_IsGroupMember)
            {
                var group = GetComponentInParent<ProxyGroup>();
                Assert.IsNotNull(group,
                    "We're a group member, so Proxy Group should not be null!");

                group.SyncModifications();
                return;
            }

            ReInitialize();

            m_Conditions = new ProxyConditions(this);

            var queryArgs = new QueryArgs
            {
                exclusivity = exclusivity,
                commonQueryData = m_CommonQueryData,
                conditions = conditions,
                traitRequirements = GetRequirements(),
                onAcquire = OnClientMatchAcquire,
                onLoss = OnClientMatchLoss
            };

            if (m_UpdateHandlers.Count > 0)
                queryArgs.onMatchUpdate = OnClientMatchUpdate;
            if (m_CommonQueryData.currentTimeOut > 0)
                queryArgs.onTimeout = OnClientMatchTimeout;

            if(AssociatedReplicator != null)
                AssociatedReplicator.AddReplicatorCallbacksProxy(this, queryArgs);

            this.ModifyQuery(queryID, queryArgs);
        }

        /// <summary>
        /// Called when a query match has been found.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryData">Data associated with this event</param>
        internal void OnClientMatchAcquire(QueryResult queryData)
        {
            // if the Proxy has been destroyed or disabled by the time the match arrives, immediately reject it.
            // this will reset data state as if this proxy was never matched.
            if (!this || !isActiveAndEnabled)
            {
                Unmatch(false);
                return;
            }

            currentData = queryData;
            UpdateQueryState(QueryState.Acquiring, queryData);

            foreach (var handler in m_AcquireHandlers)
            {
#if UNITY_EDITOR
                try
                {
                    handler.OnMatchAcquire(queryData);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
#else
                handler.OnMatchAcquire(queryData);
#endif
            }

            UpdateQueryState(QueryState.Tracking, queryData);
        }

        /// <summary>
        /// Called when a query match's data has updated.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryData">Data associated with this event</param>
        internal void OnClientMatchUpdate(QueryResult queryData)
        {
            currentData = queryData;
            foreach (var handler in m_UpdateHandlers)
            {
                handler.OnMatchUpdate(queryData);
            }
            UpdateQueryState(queryState, queryData, true);
        }

        /// <summary>
        /// Called when a query match has been lost.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryData">Data associated with this event</param>
        internal void OnClientMatchLoss(QueryResult queryData)
        {
            currentData = null;
            foreach (var handler in m_LossHandlers)
            {
                handler.OnMatchLoss(queryData);
            }

            UpdateQueryState(m_CommonQueryData.reacquireOnLoss ? QueryState.Resuming : QueryState.Unavailable);
        }

        /// <summary>
        /// Called when no query match has been found in time.
        /// This also forwards the event to the appropriate event handlers for this client.
        /// </summary>
        /// <param name="queryArgs">The original query associated with this object</param>
        internal void OnClientMatchTimeout(QueryArgs queryArgs)
        {
            UpdateQueryState(QueryState.Unavailable);

            foreach (var handler in m_TimeoutHandlers)
            {
                handler.OnMatchTimeout(queryArgs);
            }
        }

        internal void UpdateQueryState(QueryState state, QueryResult queryData = null, bool forceUpdate = false)
        {
            if (m_QueryState != state || forceUpdate)
            {
                m_QueryState = state;

                // Go through each active handler
                // Get which objects are having their activation state explicitly changed
                foreach (var handler in m_VisibilityHandlers)
                {
                    try
                    {
                        handler.FilterVisibleObjects(state, queryData, k_EnableList, k_DisableList);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                // Update reference counts
                // If object was not in dictionary before, store its initial state
                foreach (var currentObject in k_DisableList)
                {
                    ObjectVisibilityInfo activationData;
                    if (!m_VisibilityStates.TryGetValue(currentObject, out activationData))
                        m_VisibilityStates.Add(currentObject, new ObjectVisibilityInfo { initialState = currentObject.activeSelf, disableCalls = 1 });
                    else
                    {
                        activationData.disableCalls++;
                        m_VisibilityStates[currentObject] = activationData;
                    }
                }
                foreach (var currentObject in k_EnableList)
                {
                    ObjectVisibilityInfo activationData;
                    if (!m_VisibilityStates.TryGetValue(currentObject, out activationData))
                        m_VisibilityStates.Add(currentObject, new ObjectVisibilityInfo { initialState = currentObject.activeSelf, disableCalls = -1 });
                    else
                    {
                        activationData.disableCalls--;
                        m_VisibilityStates[currentObject] = activationData;
                    }
                }

                if (k_EnableList.Count > 0 || k_DisableList.Count > 0)
                    m_VisibilityChanges = true;

                k_EnableList.Clear();
                k_DisableList.Clear();

                UpdateChildStates();

                CheckMatchChanged(queryData);
            }
        }

        void CheckMatchChanged(QueryResult queryData)
        {
            if (queryData != m_PreviousMatch || queryData != null && queryData.DataID != m_PreviousMatch.DataID)
            {
                m_PreviousMatch = queryData;
                MatchChanged?.Invoke(queryData);
            }
        }

        void UpdateChildStates()
        {
            if (m_VisibilityChanges)
            {
                // Go through dictionary and set visibility as needed
                foreach (var currentObjectPair in m_VisibilityStates)
                {
                    var currentObject = currentObjectPair.Key;
                    // Skip destroyed objects
                    if (currentObject == null)
                        continue;

                    try
                    {
                        var activationData = currentObjectPair.Value;
                        currentObject.SetActive(activationData.disableCalls <= 0 && activationData.initialState);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                m_VisibilityChanges = false;
            }
        }

        void RestoreChildStates()
        {
            foreach (var currentObjectPair in m_VisibilityStates)
            {
                var currentObject = currentObjectPair.Key;
                if (currentObject == null)
                    continue;

                currentObject.SetActive(currentObjectPair.Value.initialState);
            }
        }

        bool CanSubmitQuery()
        {
            switch (m_QueryState)
            {
                case QueryState.Unknown:
                case QueryState.Unavailable:
                case QueryState.Resuming:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Cause this proxy to give up its match, without removing it from the system.
        /// If this Proxy is in a ProxyGroup, the effect depends on whether this proxy is marked as required by the group.
        /// Un-matching a Proxy that is required by a group will result in the loss of the entire ProxyGroup's match.
        /// Un-matching a Proxy that is in a group, but not required by it, will only lose the match for that Proxy.
        /// </summary>
        /// <param name="searchForNewMatch">
        /// If true, the system will search for a different match automatically.
        /// If false, the system will not search for a new match automatically.
        /// Ignored when this Proxy is in a Group, but not required by it.
        /// </param>
        /// <returns>True if this proxy already had a match, and that was given up.  False otherwise.</returns>
        public bool Unmatch(bool searchForNewMatch = true)
        {
            if (this == null)
                return true;

            OnUnmatched?.Invoke(queryID, searchForNewMatch);

            if (m_IsGroupMember)
            {
                // When in a group, the group controls the un-matching behavior, because we need to
                // take different actions based on whether or not this proxy is required by the group.
                var group = GetComponentInParent<ProxyGroup>();
                return group != null && group.UnmatchMember(this, searchForNewMatch);
            }

            var success = this.UnmatchProxy(queryID, searchForNewMatch);
            if (success)
                m_QueryState = QueryState.Unavailable;

            return success;
        }

        /// <summary>
        /// Manually match this Proxy to a data ID
        /// </summary>
        /// <param name="newDataId">The data ID to match</param>
        /// <param name="matchConditions">
        /// If true, all Conditions on the Proxy must be met by the new data.
        /// If false, the data only has to have all the traits required by the Proxy.
        /// </param>
        /// <returns></returns>
        public bool AssignMatch(int newDataId, bool matchConditions = true)
        {
            // manually assigning matches for group members is not yet supported
            return !m_IsGroupMember && this.AssignQueryMatch(queryID, newDataId, matchConditions);
        }

        /// <summary>
        /// Should only be used by ProxyGroup or before the Proxy first enables/initializes
        /// </summary>
        internal void OverrideQueryID(QueryMatchID queryMatchID) { queryID = queryMatchID; }
    }
}

using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Data.Reasoning;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Query
{
    [ModuleBehaviorCallbackOrder(ModuleOrders.BackendBehaviorOrder)]
    [ModuleUnloadOrder(ModuleOrders.BackendUnloadOrder)]
    [ModuleOrder(ModuleOrders.BackendLoadOrder)]
    [MovedFrom("Unity.MARS")]
    public partial class MARSQueryBackend : IModuleBehaviorCallbacks, IModuleMarsUpdate, IModuleSceneCallbacks,
        IModuleDependency<MARSDatabase>, IModuleDependency<ReasoningModule>, IModuleDependency<QueryPipelinesModule>,
        IUsesDatabaseQuerying
    {
        /// <summary>
        /// Used to buffer updates (register/remove) to the queries/groups
        /// </summary>
        struct BufferedAction
        {
            public enum ActionKind : byte
            {
                AddSingle,
                RemoveSingle,
                AddGroup,
                RemoveGroup,
                ModifySingle,
                ModifyGroup,
            }

            public ActionKind Kind;
            public bool IsTimeout;
            public bool IsRemoveAll;
            public QueryMatchID QueryId;
            public QueryArgs SingleArgs;
            public SetQueryArgs GroupArgs;

            BufferedAction(ActionKind kind)
            {
                Kind = kind;
                IsTimeout = false;
                IsRemoveAll = false;
                QueryId = QueryMatchID.NullQuery;
                SingleArgs = null;
                GroupArgs = null;
            }

            public BufferedAction(ActionKind kind, QueryMatchID id) : this(kind)
            {
                QueryId = id;
            }

            public BufferedAction(bool isAdd, QueryMatchID id, QueryArgs args) : this(isAdd ? ActionKind.AddSingle : ActionKind.RemoveSingle)
            {
                QueryId = id;
                SingleArgs = args;
            }

            public BufferedAction(bool isAdd, QueryMatchID id, SetQueryArgs args) : this(isAdd ? ActionKind.AddGroup : ActionKind.RemoveGroup)
            {
                QueryId = id;
                GroupArgs = args;
            }

            public BufferedAction(QueryMatchID id, QueryArgs args) : this(ActionKind.ModifySingle)
            {
                QueryId = id;
                SingleArgs = args;
            }

            public BufferedAction(QueryMatchID id, SetQueryArgs args) : this(ActionKind.ModifyGroup)
            {
                QueryId = id;
                GroupArgs = args;
            }
        };

        internal const int InvalidDataId = (int) ReservedDataIDs.Invalid;
        static readonly List<int> k_UpdateCheckKeys = new List<int>();

        ReasoningModule m_ReasoningModule;
        MARSDatabase m_Database;

        internal StandaloneQueryPipeline Pipeline;     // internal for tests

        readonly Queue<BufferedAction> m_QueryUpdates = new Queue<BufferedAction>();

        readonly Dictionary<int, Queue<int>> m_ReacquireQueues = new Dictionary<int, Queue<int>>();
        readonly Dictionary<int, float> m_LastUpdateCheckTimes = new Dictionary<int, float>();

        /// <summary>
        /// All standalone match indices that have been manually un-matched through UnmatchProxy, but are not yet seeking a new match
        /// </summary>
        internal HashSet<int> UnsetStandaloneMatchIndices { get; } = new HashSet<int>();

        /// <summary>
        /// All group match indices that have been manually un-matched through UnsetGroupQueryMatch, but are not yet seeking a new match
        /// </summary>
        internal HashSet<int> UnsetGroupMatchIndices { get; } = new HashSet<int>();

        QueryPipelinesModule m_PipelinesModule;

#pragma warning disable 67
        public event Action<QueryMatchID, int> onQueryMatchFound;
        public event Action<QueryMatchID, Dictionary<int, float>> onQueryMatchesFound;
        public event Action<QueryMatchID, Dictionary<IMRObject, int>> onSetQueryMatchFound;
#pragma warning restore 67

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly HashSet<int> k_NeedsReAcquireSet = new HashSet<int>();
        static readonly HashSet<int> k_SetsThatNeedsReAcquire = new HashSet<int>();
        static readonly List<IMRObject> k_NonRequiredMembersUnMatching = new List<IMRObject>(1) { null };

        /// <inheritdoc />
        void IModuleDependency<QueryPipelinesModule>.ConnectDependency(QueryPipelinesModule dependency)
        {
            m_PipelinesModule = dependency;
        }

        /// <inheritdoc />
        void IModuleDependency<MARSDatabase>.ConnectDependency(MARSDatabase dependency)
        {
            m_Database = dependency;
        }

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            SetupQueryManagement();
            IUsesQueryResultsMethods.RegisterQuery = RegisterQuery;
            IUsesQueryResultsMethods.ModifyQuery = ModifyQuery;
            IUsesDevQueryResultsMethods.RegisterOverrideQuery = RegisterQuery;
            IUsesQueryResultsMethods.UnregisterQuery = UnregisterQuery;
            IUsesQueryResultsMethods.AssignQueryMatch = TryAssignStandaloneMatch;
            IUsesQueryResultsMethods.UnmatchStandaloneProxy = UnsetStandaloneMatchPublic;
            ISetQueryResultsMethods.RegisterSetQuery = RegisterSetQuery;
            ISetQueryResultsMethods.RegisterSetOverrideQuery = RegisterSetQuery;
            ISetQueryResultsMethods.UnregisterSetQuery = UnregisterSetQuery;
            ISetQueryResultsMethods.UnmatchGroupQuery = UnsetGroupMatch;
            ISetQueryResultsMethods.UnmatchNonRequiredMember = UnmatchNonRequiredMember;
            ISetQueryResultsMethods.ModifySetQuery = ModifySetQuery;
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            TearDownQueryManagement();
            Pipeline = null;
            IUsesQueryResultsMethods.RegisterQuery = null;
            IUsesQueryResultsMethods.ModifyQuery = ModifyQueryNoop;
            IUsesQueryResultsMethods.UnregisterQuery = UnregisterQueryNoop;
            IUsesQueryResultsMethods.UnmatchStandaloneProxy = (id, match) => false;
            IUsesQueryResultsMethods.AssignQueryMatch = (id, matchId, conditions) => false;
            IUsesDevQueryResultsMethods.RegisterOverrideQuery = null;
            ISetQueryResultsMethods.RegisterSetQuery = null;
            ISetQueryResultsMethods.RegisterSetOverrideQuery = null;
            ISetQueryResultsMethods.UnregisterSetQuery = UnregisterQueryNoop;
            ISetQueryResultsMethods.UnmatchGroupQuery = (id, match) => false;
            ISetQueryResultsMethods.UnmatchNonRequiredMember = (id, proxy) => false;
            ISetQueryResultsMethods.ModifySetQuery = ModifySetQueryNoop;
        }

        /// <inheritdoc />
        void IModuleDependency<ReasoningModule>.ConnectDependency(ReasoningModule dependency)
        {
            m_ReasoningModule = dependency;
        }

        void SetupQueryManagement()
        {
            Pipeline = m_PipelinesModule.StandalonePipeline;
            Pipeline.onTimeout += OnStandaloneQueryTimeouts;
            m_PipelinesModule.GroupPipeline.OnTimeout += OnSetTimeouts;

            QueryMatchID.ResetCounter();
        }

        internal void ResetQueryManagement()
        {
            m_Database.ClearQueryData();
            SetupQueryManagement();
            TearDownQueryManagement();
        }

        void TearDownQueryManagement()
        {
            if (Pipeline != null)
            {
                Pipeline.onTimeout -= OnStandaloneQueryTimeouts;
            }

            if (m_PipelinesModule != null)
            {
                m_PipelinesModule.GroupPipeline.OnTimeout -= OnSetTimeouts;
                m_PipelinesModule.Clear();
            }

            m_QueryUpdates.Clear();
            m_ReacquireQueues.Clear();

            m_Database.StopUpdateBuffering();
        }

        internal QueryMatchID RegisterQuery(QueryArgs queryArgs)
        {
            var queryMatchID = QueryMatchID.Generate();
            RegisterQuery(queryMatchID, queryArgs);
            return queryMatchID;
        }

        void RegisterQuery(QueryMatchID queryMatchID, QueryArgs queryArgs)
        {
            AddQuery(queryMatchID, queryArgs);
        }

        void EnqueueUpdate(BufferedAction action)
        {
            m_QueryUpdates.Enqueue(action);
        }

        void AddQuery(QueryMatchID queryMatchID, QueryArgs args)
        {
            EnqueueUpdate(new BufferedAction(true, queryMatchID, args));
        }

        void RemoveQuery(QueryMatchID queryMatchID)
        {
            EnqueueUpdate(new BufferedAction(BufferedAction.ActionKind.RemoveSingle, queryMatchID));
        }

        internal void ModifyQuery(QueryMatchID id, QueryArgs args)
        {
            EnqueueUpdate(new BufferedAction(id, args));
        }

        internal void ModifySetQuery(QueryMatchID id, SetQueryArgs args)
        {
            EnqueueUpdate(new BufferedAction(id, args));
        }

        public QueryMatchID RegisterSetQuery(SetQueryArgs queryArgs)
        {
            var queryMatchID = QueryMatchID.Generate();
            EnqueueUpdate(new BufferedAction(true, queryMatchID, queryArgs));
            return queryMatchID;
        }

        void RegisterSetQuery(QueryMatchID queryMatchID, SetQueryArgs queryArgs)
        {
            EnqueueUpdate(new BufferedAction(true, queryMatchID, queryArgs));
        }

        // This dummy function is used to prevent errors from happening if a query tries to unregister after unload
        static bool UnregisterQueryNoop(QueryMatchID queryMatchID, bool allMatches) { return false; }

        static void ModifyQueryNoop(QueryMatchID queryMatchID, QueryArgs queryArgs) { }

        static void ModifySetQueryNoop(QueryMatchID queryMatchID, SetQueryArgs queryArgs) { }

        void RemoveSetQuery(QueryMatchID queryMatchID, bool allMatches)
        {
            EnqueueUpdate(new BufferedAction(BufferedAction.ActionKind.RemoveGroup, queryMatchID) {IsRemoveAll = allMatches} );
        }

        void OnStandaloneQueryTimeouts(HashSet<QueryMatchID> timeoutMatchIds)
        {
            foreach (var id in timeoutMatchIds)
            {
                EnqueueUpdate(new BufferedAction(BufferedAction.ActionKind.RemoveSingle, id) { IsTimeout = true });
            }
        }

        void OnSetTimeouts(HashSet<QueryMatchID> timeoutMatchIds)
        {
            foreach (var id in timeoutMatchIds)
            {
                EnqueueUpdate(new BufferedAction(BufferedAction.ActionKind.RemoveGroup, id) {IsTimeout =  true});
            }
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() {}

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable()
        {
            SetAllLastUpdateTimes(MarsTime.Time);
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() {}

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() {}

        /// <inheritdoc />
        void IModuleMarsUpdate.OnMarsUpdate()
        {
            if (MARSCore.instance.paused)
                return;

            SyncQueryBuffers();
        }

        internal void SyncQueryBuffers()
        {
            if (m_PipelinesModule.State != QueryPipelinesModule.AcquireCycleState.UpdatesOnly)
                return;

            foreach (var update in m_QueryUpdates)
            {
                switch (update.Kind)
                {
                    case BufferedAction.ActionKind.AddSingle:
                        Pipeline.Data.Register(update.QueryId, update.SingleArgs);
                        break;
                    case BufferedAction.ActionKind.RemoveSingle:
                        RemoveAssociatedDataStandalone(update.QueryId);
                        if (update.IsTimeout)
                            Pipeline.Data.RemoveAndTimeout(update.QueryId);
                        else
                            Pipeline.Data.Remove(update.QueryId);
                        break;
                    case BufferedAction.ActionKind.AddGroup:
                        m_PipelinesModule.GroupPipeline.Register(update.QueryId, update.GroupArgs);
                        break;
                    case BufferedAction.ActionKind.RemoveGroup:
                        RemoveAssociatedDataGroup(update.QueryId, update.IsRemoveAll);
                        if (update.IsTimeout)
                            m_PipelinesModule.GroupPipeline.RemoveAndTimeout(update.QueryId);
                        else
                            m_PipelinesModule.GroupPipeline.Remove(update.QueryId);
                        break;
                    case BufferedAction.ActionKind.ModifySingle:
                        Pipeline.Data.Modify(update.QueryId, update.SingleArgs);
                        break;
                    case BufferedAction.ActionKind.ModifyGroup:
                        m_PipelinesModule.GroupPipeline.Modify(update.QueryId, update.GroupArgs);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            m_QueryUpdates.Clear();
        }

        internal bool RunAllQueries()
        {
            SyncQueryBuffers();
            // make sure we get all the traits we require from reasoning APIs first
            m_ReasoningModule.UpdateReasoningAPIData();
            m_ReasoningModule.ProcessReasoningAPIScenes();

            bool anyNewSetMatches;
            var setPipe = m_PipelinesModule.GroupPipeline;
            anyNewSetMatches = setPipe.ForceEvaluation();

            // force-run all queries in the standalone pipeline
            var pipe = m_PipelinesModule.StandalonePipeline;
            var anyNewMatches = pipe.ForceEvaluation();
            if (anyNewMatches)
            {
                if (onQueryMatchFound != null)
                {
                    var answeredIndices = pipe.Data.DefiniteMatchAcquireIndices;
                    var queryMatchIds = pipe.Data.QueryMatchIds;
                    var dataMatchIds = pipe.Data.BestMatchDataIds;
                    foreach (var i in answeredIndices)
                    {
                        onQueryMatchFound(queryMatchIds[i], dataMatchIds[i]);
                    }
                }
                if (onQueryMatchesFound != null)
                {
                    var answeredIndices = pipe.Data.DefiniteMatchAcquireIndices;
                    var queryMatchIds = pipe.Data.QueryMatchIds;
                    var reducedRatings = pipe.Data.ReducedConditionRatings;
                    foreach (var i in answeredIndices)
                    {
                        onQueryMatchesFound(queryMatchIds[i], reducedRatings[i]);
                    }
                }
            }

            return anyNewMatches || anyNewSetMatches;
        }

        internal void RunMatchUpdates(ParallelQueryData data)
        {
            k_NeedsReAcquireSet.Clear();

            var time = MarsTime.Time;
            foreach (var i in data.UpdatingIndices)
            {
                if (m_LastUpdateCheckTimes.TryGetValue(i, out var lastTime))
                {
                    var interval = data.UpdateMatchInterval[i];
                    if (time - lastTime < interval)
                        continue;
                }

                PipelineMatchUpdate(i,
                    data.QueryMatchIds,
                    data.BestMatchDataIds,
                    data.Conditions,
                    data.TraitRequirements,
                    data.QueryResults,
                    data.UpdateHandlers,
                    data.LossHandlers);

                m_LastUpdateCheckTimes[i] = time;
            }
        }

        void SetAllLastUpdateTimes(float time)
        {
            k_UpdateCheckKeys.Clear();
            foreach (var key in m_LastUpdateCheckTimes.Keys)
            {
                k_UpdateCheckKeys.Add(key);
            }

            foreach (var key in k_UpdateCheckKeys)
            {
                m_LastUpdateCheckTimes[key] = time;
            }

            var setData = m_PipelinesModule.GroupPipeline.Data;
            var lastSetUpdates = setData.LastUpdateCheckTime;
            foreach (var setIndex in setData.UpdatingIndices)
            {
                lastSetUpdates[setIndex] = time;
            }
        }

        internal void RunSetMatchUpdates(ParallelGroupData groupData)
        {
            var time = MarsTime.Time;
            foreach (var i in groupData.UpdatingIndices)
            {
                var lastTime = groupData.LastUpdateCheckTime[i];
                var interval = groupData.UpdateMatchInterval[i];
                if (time - lastTime < interval)
                    continue;

                SetPipelineMatchUpdate(i,
                    groupData.QueryMatchIds,
                    groupData.SetMatchData,
                    groupData.Relations,
                    groupData.QueryResults,
                    groupData.ReAcquireOnLoss,
                    groupData.LastUpdateCheckTime,
                    groupData.SetMatchData,
                    groupData.UpdateHandlers,
                    groupData.LossHandlers);

                groupData.LastUpdateCheckTime[i] = time;
            }
        }

        internal void PipelineMatchUpdate(int index,
            QueryMatchID[] queryMatchIds,
            int[] dataIds,
            ProxyConditions[] conditions,
            ProxyTraitRequirements[] traitRequirements,
            QueryResult[] results,
            Action<QueryResult>[] onMatchUpdateHandlers,
            Action<QueryResult>[] onMatchLossHandlers)
        {
            var queryMatchId = queryMatchIds[index];
            // Check if any of the object's queried data is dirty.  If so, try to get the updated data
            if (this.QueryDataDirty(queryMatchId))
            {
                var result = results[index];
                var dataId = dataIds[index];
                var queryConditions = conditions[index];
                result.queryMatchId = queryMatchId;

                if (this.TryUpdateQueryMatchData(dataId, queryConditions, traitRequirements[index], result))
                {
                    onMatchUpdateHandlers[index]?.Invoke(result);
                }
                else
                {
                    UnmatchStandaloneIndex(index);
                    onMatchLossHandlers[index]?.Invoke(result);
                }
            }

            m_LastUpdateCheckTimes[index] = MarsTime.Time;
        }

        internal void UnmatchStandaloneIndex(int index, bool forceRematch = false)
        {
            var data = m_PipelinesModule.StandalonePipeline.Data;
            var queryMatchId = data.QueryMatchIds[index];
            // If looking for all matches for a query, we should not try to reacquire for this query match
            // since we are already looking for another match.
            if (!data.ReAcquireOnLoss[index] && !forceRematch)
                RemoveQuery(queryMatchId);
            else
            {
                m_LastUpdateCheckTimes.Remove(index);
                k_NeedsReAcquireSet.Add(index);
            }

            this.UnmarkDataUsedForUpdates(queryMatchId);
        }

        internal void UnmatchGroupIndex(int index, bool forceRematch = false)
        {
            var data = m_PipelinesModule.GroupPipeline.Data;

            // If looking for all matches for a query, we should not try to reacquire for this query match
            // since we are already looking for another match.
            if (!data.ReAcquireOnLoss[index] && !forceRematch)
                RemoveSetQuery(data.QueryMatchIds[index], true);
            else
            {
                data.QueryResults[index].RestoreResults();
                k_SetsThatNeedsReAcquire.Add(index);
            }

            this.UnmarkSetDataUsedForUpdates(data.QueryMatchIds[index]);

            data.SetMatchData[index]?.dataAssignments.Clear();
        }

        internal void SetPipelineMatchUpdate(int index,
            QueryMatchID[] queryMatchIds,
            SetMatchData[] matchData,
            Relations[] relations,
            SetQueryResult[] results,
            bool[] reAcquireSettings,
            float[] lastUpdateCheckTimes,
            SetMatchData[] allSetMatchData,
            Action<SetQueryResult>[] onMatchUpdateHandlers,
            Action<SetQueryResult>[] onMatchLossHandlers)
        {
            var queryMatchId = queryMatchIds[index];
            // Check if any of the object's queried data is dirty.  If so, try to get the updated data
            if (this.IsSetQueryDataDirty(queryMatchId))
            {
                var result = results[index];
                result.queryMatchId = queryMatchId;

                if (this.TryUpdateSetQueryMatchData(matchData[index], relations[index], result))
                {
                    // If there are any non-required children that have been lost, we should free up their data.
                    var nonRequiredChildrenLost = result.nonRequiredChildrenLost;
                    if (nonRequiredChildrenLost.Count > 0)
                    {
                        foreach (var lost in nonRequiredChildrenLost)
                        {
                            if (result.childResults.TryGetValue(lost, out var lostChildResult))
                            {
                                lostChildResult.SetDataId(InvalidDataId);
                                break;
                            }
                        }

                        this.UnmarkPartialSetDataUsedForUpdates(queryMatchId, nonRequiredChildrenLost);
                    }

                    if (result.AllMemberMatchesInvalid())
                    {
                        if (reAcquireSettings[index])
                        {
                            this.UnmarkSetDataUsedForUpdates(queryMatchId);
                            k_SetsThatNeedsReAcquire.Add(index);
                        }
                        else
                        {
                            RemoveSetQuery(queryMatchId, false);
                        }

                        // this member loss has resulted in all group members having no match,
                        // so we trigger loss for the proxy group as a whole
                        onMatchLossHandlers[index]?.Invoke(result);
                    }
                    else
                    {
                        onMatchUpdateHandlers[index]?.Invoke(result);
                    }
                }
                else
                {
                    // If looking for all matches for a query, we should not try to reacquire for this query match
                    // since we are already looking for another match.
                    if (!reAcquireSettings[index])
                        RemoveSetQuery(queryMatchId, true);
                    else
                    {
                        result.RestoreResults();
                        k_SetsThatNeedsReAcquire.Add(index);
                    }

                    this.UnmarkSetDataUsedForUpdates(queryMatchId);

                    var setMatchData = allSetMatchData[index];
                    setMatchData?.dataAssignments.Clear();

                    onMatchLossHandlers[index]?.Invoke(result);
                }
            }

            lastUpdateCheckTimes[index] = MarsTime.Time;
        }

        internal void SyncNeedsAcquireSet()
        {
            var pipelineData = Pipeline.Data;
            foreach (var index in k_NeedsReAcquireSet)
            {
                pipelineData.UpdatingIndices.Remove(index);

                // If the query is reserved then it's OK to look for multiple matches at a time,
                // since the pipeline handles reserved data conflicts
                if (pipelineData.Exclusivities[index] == Exclusivity.Reserved)
                {
                    pipelineData.AcquiringIndices.Add(index);
                    continue;
                }

                // The pipeline does not support finding multiple matches at a time for a shared or read-only query.
                // If there is already an acquiring query with a certain query ID, we queue up queries with that same ID
                // that want to reacquire.
                var matchIDs = pipelineData.QueryMatchIds;
                var reacquireQueryId = matchIDs[index].queryID;
                if (m_ReacquireQueues.TryGetValue(reacquireQueryId, out var reacquireQueue))
                {
                    reacquireQueue.Enqueue(index);
                    continue;
                }

                var canReacquire = true;
                var acquiringIndices = pipelineData.AcquiringIndices;
                foreach (var acquiring in acquiringIndices)
                {
                    if (matchIDs[acquiring].queryID == reacquireQueryId)
                    {
                        canReacquire = false;
                        reacquireQueue = new Queue<int>();
                        reacquireQueue.Enqueue(index);
                        m_ReacquireQueues[reacquireQueryId] = reacquireQueue;
                        pipelineData.AcquireHandlers[acquiring] += OnBlockingQueryAcquired;
                        break;
                    }
                }

                if (canReacquire)
                    acquiringIndices.Add(index);
            }

            var setData = m_PipelinesModule.GroupPipeline.Data;
            foreach (var index in k_SetsThatNeedsReAcquire)
            {
                setData.UpdatingIndices.Remove(index);

                var matchIDs = setData.QueryMatchIds;
                var reacquireQueryId = matchIDs[index].queryID;
                if (m_ReacquireQueues.TryGetValue(reacquireQueryId, out var reacquireQueue))
                {
                    reacquireQueue.Enqueue(index);
                    continue;
                }

                var canReacquire = true;
                var acquiringIndices = setData.AcquiringIndices;
                foreach (var acquiring in acquiringIndices)
                {
                    if (matchIDs[acquiring].queryID == reacquireQueryId)
                    {
                        canReacquire = false;
                        reacquireQueue = new Queue<int>();
                        reacquireQueue.Enqueue(index);
                        m_ReacquireQueues[reacquireQueryId] = reacquireQueue;
                        setData.AcquireHandlers[acquiring] += OnBlockingSetQueryAcquired;
                        break;
                    }
                }

                if (canReacquire)
                    acquiringIndices.Add(index);
            }

            k_SetsThatNeedsReAcquire.Clear();
        }

        void OnBlockingQueryAcquired(QueryResult queryData)
        {
            var pipelineData = Pipeline.Data;
            var blockingQueryMatchID = queryData.queryMatchId;
            var blockingQueryIndex = pipelineData.MatchIdToIndex[blockingQueryMatchID];
            pipelineData.AcquireHandlers[blockingQueryIndex] -= OnBlockingQueryAcquired;

            var queryID = blockingQueryMatchID.queryID;
            var reacquireQueue = m_ReacquireQueues[queryID];
            var reacquireIndex = reacquireQueue.Dequeue();
            Pipeline.Data.AcquiringIndices.Add(reacquireIndex);

            // If there are still more queries that want to reacquire, then we need to know when this query has acquired a match
            if (reacquireQueue.Count > 0)
                pipelineData.AcquireHandlers[reacquireIndex] += OnBlockingQueryAcquired;
            else
                m_ReacquireQueues.Remove(queryID);
        }

        void OnBlockingSetQueryAcquired(SetQueryResult queryData)
        {
            var setData = m_PipelinesModule.GroupPipeline.Data;
            var blockingQueryMatchId = queryData.queryMatchId;
            var blockingQueryIndex = setData.MatchIdToIndex[blockingQueryMatchId];
            setData.AcquireHandlers[blockingQueryIndex] -= OnBlockingSetQueryAcquired;

            var queryId = blockingQueryMatchId.queryID;
            var reacquireQueue = m_ReacquireQueues[queryId];
            var reacquireIndex = reacquireQueue.Dequeue();
            setData.AcquiringIndices.Add(reacquireIndex);

            // If there are still more queries that want to reacquire, then we need to know when this query has acquired a match
            if (reacquireQueue.Count > 0)
                setData.AcquireHandlers[reacquireIndex] += OnBlockingSetQueryAcquired;
            else
                m_ReacquireQueues.Remove(queryId);
        }

        internal bool UnsetStandaloneMatchPublic(QueryMatchID queryMatchId, bool seekNewMatch)
        {
            return UnsetStandaloneMatch(queryMatchId, seekNewMatch);
        }

        internal bool UnsetStandaloneMatch(QueryMatchID queryMatchId, bool seekNewMatch, bool callLossHandler = true)
        {
            var data = m_PipelinesModule.StandalonePipeline.Data;
            if (!data.MatchIdToIndex.TryGetValue(queryMatchId, out var index))
                return false;

            var alreadyMatched = data.UpdatingIndices.Contains(index);
            if (!alreadyMatched)
                return false;

            // stop updating
            data.UpdatingIndices.Remove(index);
            // un-set the proxy's match
            data.BestMatchDataIds[index] = (int) ReservedDataIDs.Invalid;
            m_Database.UnmarkDataUsedForUpdates(queryMatchId);

            // to seek another automatic match for this query instance, add it to the standalone re-acquire set
            if (seekNewMatch)
                k_NeedsReAcquireSet.Add(index);
            else
                UnsetStandaloneMatchIndices.Add(index);

            if(callLossHandler)
                data.LossHandlers[index]?.Invoke(data.QueryResults[index]);

            return true;
        }

        internal bool UnsetGroupMatch(QueryMatchID queryMatchId, bool seekNewMatch)
        {
            var data = m_PipelinesModule.GroupPipeline.Data;
            if (!data.MatchIdToIndex.TryGetValue(queryMatchId, out var groupIndex))
                return false;

            var alreadyMatched = data.UpdatingIndices.Contains(groupIndex);
            if (!alreadyMatched)
                return false;

            // stop updating
            data.UpdatingIndices.Remove(groupIndex);

            // un-set the proxy group's matches
            data.SetMatchData[groupIndex].dataAssignments.Clear();

            var memberData = m_PipelinesModule.GroupPipeline.MemberData;
            foreach (var memberIndex in data.MemberIndices[groupIndex])
            {
                memberData.BestMatchDataIds[memberIndex] = (int) ReservedDataIDs.Invalid;
            }

            m_Database.UnmarkSetDataUsedForUpdates(queryMatchId);

            // to seek another automatic match for this query instance, add it to the group re-acquire set
            if(seekNewMatch)
                k_SetsThatNeedsReAcquire.Add(groupIndex);
            else
                UnsetGroupMatchIndices.Add(groupIndex);

            // call the loss handler for this group if present
            data.LossHandlers[groupIndex]?.Invoke(data.QueryResults[groupIndex]);
            return true;
        }

        bool UnmatchNonRequiredMember(QueryMatchID queryMatchId, IMRObject memberProxy)
        {
            var groupData = m_PipelinesModule.GroupPipeline.Data;
            // fail if this match id doesn't belong to a registered Group
            if(!groupData.MatchIdToIndex.TryGetValue(queryMatchId, out var groupIndex))
                return false;

            // fail if this match id is not actually assigned any data
            if (!groupData.UpdatingIndices.Contains(groupIndex))
                return false;

            var memberIndices = groupData.MemberIndices[groupIndex];
            var memberData = m_PipelinesModule.GroupPipeline.MemberData;

            foreach (var mi in memberIndices)
            {
                if (memberData.ObjectReferences[mi] == memberProxy)
                {
                    // fail if it turns out that this member is actually required
                    if (memberData.Required[mi])
                        return false;

                    // unmark the data previously used by this proxy
                    k_NonRequiredMembersUnMatching[0] = memberProxy;
                    this.UnmarkPartialSetDataUsedForUpdates(queryMatchId, k_NonRequiredMembersUnMatching);

                    // remove all trait values from the member result
                    memberData.QueryResults[mi].Clear();
                    memberData.BestMatchDataIds[mi] = InvalidDataId;

                    // let the group itself know about the match loss for this proxy
                    var groupResult = groupData.QueryResults[groupIndex];
                    groupResult.nonRequiredChildrenLost.Clear();
                    groupResult.nonRequiredChildrenLost.Add(memberProxy);

                    // group update handlers will respond to non-required member match loss
                    groupData.UpdateHandlers[groupIndex]?.Invoke(groupResult);
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        void IModuleSceneCallbacks.OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SetAllLastUpdateTimes(MarsTime.Time);
        }

        /// <inheritdoc />
        void IModuleSceneCallbacks.OnSceneUnloaded(Scene scene) { }

        /// <inheritdoc />
        void IModuleSceneCallbacks.OnActiveSceneChanged(Scene oldScene, Scene newScene) { }

#if UNITY_EDITOR
        /// <inheritdoc />
        void IModuleSceneCallbacks.OnNewSceneCreated(Scene scene, NewSceneSetup setup, NewSceneMode mode) { }

        /// <inheritdoc />
        void IModuleSceneCallbacks.OnSceneOpening(string path, OpenSceneMode mode) { }

        /// <inheritdoc />
        void IModuleSceneCallbacks.OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            SetAllLastUpdateTimes(0f);
        }
#endif
    }
}

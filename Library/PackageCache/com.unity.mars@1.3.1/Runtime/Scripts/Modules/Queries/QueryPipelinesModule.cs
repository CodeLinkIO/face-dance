using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.MARSUtils;
using Unity.MARS.Providers;
using Unity.XRTools.ModuleLoader;
using UnityEngine;

namespace Unity.MARS.Query
{
    [ModuleOrder(ModuleOrders.PipelinesLoadOrder)]
    [ModuleUnloadOrder(ModuleOrders.PipelinesUnloadOrder)]
    public class QueryPipelinesModule : IModuleDependency<MARSDatabase>, IModuleDependency<MARSQueryBackend>,
        IModuleBehaviorCallbacks, IModuleMarsUpdate, IUsesCameraOffset
    {
        internal enum AcquireCycleState : byte
        {
            UpdatesOnly,
            RunningSets,
            RunningStandalone
        }

        MARSDatabase m_Database;
        MARSQueryBackend m_QueryBackend;
        SlowTaskModule m_SlowTaskModule;

        AcquireCycleState m_State = AcquireCycleState.UpdatesOnly;

        internal AcquireCycleState State => m_State;

        internal StandaloneQueryPipeline StandalonePipeline { get; set; }
        internal GroupQueryPipeline GroupPipeline { get; set; }

        public event Action OnSceneEvaluationComplete;

        /// <inheritdoc />
        IProvidesCameraOffset IFunctionalitySubscriber<IProvidesCameraOffset>.provider { get; set; }

        /// <inheritdoc />
        void IModuleDependency<MARSDatabase>.ConnectDependency(MARSDatabase dependency) => m_Database = dependency;

        /// <inheritdoc />
        void IModuleDependency<MARSQueryBackend>.ConnectDependency(MARSQueryBackend dependency) => m_QueryBackend = dependency;

        /// <inheritdoc />
        void IModule.LoadModule()
        {
            StandalonePipeline = new StandaloneQueryPipeline(m_Database);
            GroupPipeline = new GroupQueryPipeline(m_Database);

            // the query results must have their poses offset by the camera pose
            StandalonePipeline.ResultFillStage.Transformation.applyOffsetToPose = this.ApplyOffsetToPose;
            GroupPipeline.MemberResultFillStage.Transformation.applyOffsetToPose = this.ApplyOffsetToPose;

#if UNITY_EDITOR
            EditorOnlyEvents.onTemporalSimulationStart += StandalonePipeline.ClearData;
#endif
        }

        /// <inheritdoc />
        void IModule.UnloadModule()
        {
            if (StandalonePipeline != null)
            {
                Pose IdentityPoseMethod(Pose p) => p;
                StandalonePipeline.ResultFillStage.Transformation.applyOffsetToPose = IdentityPoseMethod;
                GroupPipeline.MemberResultFillStage.Transformation.applyOffsetToPose = IdentityPoseMethod;
#if UNITY_EDITOR
                EditorOnlyEvents.onTemporalSimulationStart -= StandalonePipeline.ClearData;
#endif
                StandalonePipeline.ClearData();
            }

            GroupPipeline?.Clear();

            StandalonePipeline = null;
            GroupPipeline = null;
        }

        internal void StartCycle()
        {
            // we run the set pipeline first, and after it's done the standalone one gets run
            m_State = AcquireCycleState.RunningSets;
            GroupPipeline.StartCycle();
        }

        public void Clear()
        {
            StandalonePipeline.ClearData();
            GroupPipeline.Clear();
        }

        /// <inheritdoc />
        void IModuleMarsUpdate.OnMarsUpdate()
        {
            m_QueryBackend.SyncNeedsAcquireSet();

            switch (m_State)
            {
                case AcquireCycleState.UpdatesOnly:
                    RunMatchUpdates();
                    return;
                case AcquireCycleState.RunningSets:
                {
                    GroupPipeline.OnUpdate();
                    if (GroupPipeline.IsReadyForTraitDataBufferSync)
                        m_Database.StopUpdateBuffering();

                    /*
                        We call RunMatchUpdates() after the check for buffering, so that on the
                        same frame we stop buffering, update checks can cause any events that need to happen because
                        of buffered data changes. This will be the frame immediately before acquire events.

                        We previously stopped buffering on the same frame as acquire handling, immediately after it.
                        We also relied on the update check the frame after acquire for query changes to propagate.
                        In comparison, this method has 2 less frames of latency between
                        buffering a change and the change's effect on proxies.
                    */
                    RunMatchUpdates();

                    if (!GroupPipeline.CurrentlyActive)
                    {
                        m_State = AcquireCycleState.RunningStandalone;
                        StandalonePipeline.StartCycle();
                    }

                    break;
                }
                case AcquireCycleState.RunningStandalone:
                    StandalonePipeline.OnUpdate();
                    if (StandalonePipeline.IsReadyForTraitDataBufferSync)
                        m_Database.StopUpdateBuffering();

                    RunMatchUpdates();
                    if (!StandalonePipeline.CurrentlyActive)
                    {
                        m_State = AcquireCycleState.UpdatesOnly;
                        OnSceneEvaluationComplete?.Invoke();
                    }

                    break;
            }
        }

        void RunMatchUpdates()
        {
            m_QueryBackend.RunSetMatchUpdates(GroupPipeline.Data);
            m_QueryBackend.RunMatchUpdates(StandalonePipeline.Data);
        }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorAwake() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorEnable() { m_State = AcquireCycleState.UpdatesOnly; }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorStart() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorUpdate() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDisable() { }

        /// <inheritdoc />
        void IModuleBehaviorCallbacks.OnBehaviorDestroy() { }

        public void GetConditionRatingsForProxy(Proxy proxy, out Dictionary<int, float> conditionRatings)
        {
            conditionRatings = default;

            var group = proxy.GetComponentInParent<ProxyGroup>();
            if (group != null)
            {
                var childMemberIndex = group.IndexOfChild(proxy);
                if (childMemberIndex >= 0)
                {
                    GetConditionRatingsForGroupMember(group.queryID, childMemberIndex, out conditionRatings);
                }
            }
            else
            {
                GetConditionRatingsForProxy(proxy.queryID, out conditionRatings);
            }
        }

        void GetConditionRatingsForProxy(QueryMatchID queryMatchID, out Dictionary<int, float> conditionRatings)
        {
            conditionRatings = default;

            var queryData = StandalonePipeline.Data;
            if (queryData.MatchIdToIndex.TryGetValue(queryMatchID, out var queryDataIndex))
            {
                conditionRatings = queryData.ReducedConditionRatings[queryDataIndex];
            }
        }

        void GetConditionRatingsForGroupMember(QueryMatchID queryMatchID, int childMemberIndex, out Dictionary<int, float> dictionary)
        {
            dictionary = default;
            if (GroupPipeline.MemberData.MatchIdToIndex.TryGetValue(queryMatchID, out var childQueryDataIndices))
            {
                if (childQueryDataIndices.Count > childMemberIndex)
                {
                    var queryDataIndex = childQueryDataIndices[childMemberIndex];
                    dictionary = GroupPipeline.MemberData.ReducedConditionRatings[queryDataIndex];
                }
            }
        }
    }
}

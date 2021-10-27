using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Assertions;

namespace Unity.MARS.Query
{
    class QueryPipelineBase
    {
        protected static readonly HashSet<int> k_TimeoutIndexes = new HashSet<int>();
        protected static readonly HashSet<QueryMatchID> k_TimeoutIds = new HashSet<QueryMatchID>();

        protected MARSDatabase m_Database;

        protected int m_ElapsedFramesForCurrentStage;

        /// <summary>
        /// The active run configuration for the pipeline
        /// </summary>
        public QueryPipelineConfiguration Configuration;

        public bool CurrentlyActive { get; protected set; }

        internal float LastCycleStartTime { get; set; }
        internal float CycleDeltaTime { get; set; }
    }

    /// <summary>
    /// Connects data about Sets with the data about their members, as well as
    /// connecting all of that data with all query stages used to solve for Set's answers
    /// </summary>
    partial class GroupQueryPipeline : QueryPipelineBase
    {
        static readonly Dictionary<int, RelationMembership[]> k_RelationMemberships =
            new Dictionary<int, RelationMembership[]>();

        static readonly Dictionary<IMRObject, QueryResult> k_TempChildResults = new Dictionary<IMRObject, QueryResult>();

        int m_CurrentRunGroupIndex;
        int m_LastCompletedFence;

        ProfilerMarker m_ForceEvaluationMarker = new ProfilerMarker("ForceGroupEvaluation");

        internal List<QueryStage> Stages = new List<QueryStage>();

        internal CacheTraitReferencesStage MemberTraitCacheStage;
        internal CacheRelationTraitReferencesStage RelationTraitCacheStage;
        internal ConditionMatchRatingStage MemberConditionRatingStage;
        internal IncompleteGroupFilterStage IncompleteGroupFilterStage;
        internal FindMatchProposalsStage MemberMatchIntersectionStage;
        internal SetDataAvailabilityCheckStage MemberDataAvailabilityStage;
        internal TraitRequirementFilterStage MemberTraitRequirementStage;
        internal MatchReductionStage MemberMatchReductionStage;
        // relation stages run after reducing member matches
        internal RelationRatingStage GroupRelationRatingStage;
        internal FilterRelationMemberMatchesStage FilterRelationMembersStage;
        internal GroupMatchSearchStage MatchSearchStage;

        internal MarkSetUsedStage MarkDataUsedStage;
        internal ResultFillStage MemberResultFillStage;
        internal GroupResultFillStage GroupResultFillStage;
        internal GroupAcquireHandlingStage AcquireHandlingStage;

        /// <summary>
        /// Stores all data that exists on a per-Set basis
        /// </summary>
        internal ParallelGroupData Data;

        /// <summary>
        /// Stores all data that exists on a per-Member basis
        /// </summary>
        internal ParallelGroupMemberData MemberData;

        // Local method use only -- created here to reduce garbage collection. Collections must be cleared before use
        static readonly List<int> k_SetMemberIndices = new List<int>();
        static readonly List<RelationDataPair> k_RelationIndexPairs = new List<RelationDataPair>();
        static readonly HashSet<int> k_TimeoutIndices = new HashSet<int>();
        static readonly List<KnownMember> k_KnownMembers = new List<KnownMember>();

        struct KnownMember
        {
            public IMRObject Reference;
            public int DataIndex;

            public KnownMember(IMRObject reference, int dataIndex)
            {
                DataIndex = dataIndex;
                Reference = reference;
            }
        }

        internal event Action onStageGroupCompletion;

        internal event Action<HashSet<QueryMatchID>> OnTimeout;

        public GroupQueryPipeline(MARSDatabase db)
        {
            m_Database = db;
            SetupData();
        }

        internal void Register(QueryMatchID id, SetQueryArgs args)
        {
            if (Data.MatchIdToIndex.ContainsKey(id))
            {
                return; // query is already registered
            }

            RegisterRelationChildren(id, args);

            GetIndexPairs(id, args);

            // the index arrays for group & relation members are so small that we create new ones
            // on registration, instead of using pooled Lists
            var memberIndices = k_SetMemberIndices.ToArray();
            var relationIndexPairs = k_RelationIndexPairs.ToArray();
            var groupIndex = Data.Register(id, memberIndices, relationIndexPairs, args);

            k_TempChildResults.Clear();
            foreach (var i in memberIndices)
            {
                k_TempChildResults.Add(MemberData.ObjectReferences[i], MemberData.QueryResults[i]);
            }

            Data.QueryResults[groupIndex].SetChildren(k_TempChildResults);

            // for each group member, store a representation of which relations it belongs to.
            Data.GetRelationMemberships(groupIndex, k_RelationMemberships);
            foreach (var kvp in k_RelationMemberships)
            {
                var memberIndex = kvp.Key;
                MemberData.RelationMemberships[memberIndex] = kvp.Value;
            }

            // calculate the solve order weighting for this group
            var weights = QueryPipelineConfiguration.instance.SolveOrderWeighting;
            var order = GetGroupOrderWeight(memberIndices, relationIndexPairs.Length, MemberData.Exclusivities, weights);
            Data.OrderWeights[groupIndex] = order;

            Data.InitializeSearchData(groupIndex, MemberData.ReducedConditionRatings);
        }

        internal void Modify(QueryMatchID id, SetQueryArgs args)
        {
            if (!Data.MatchIdToIndex.TryGetValue(id, out var groupIndex))
                return;

            Assert.IsTrue(Data.QueryMatchIds[groupIndex].Equals(id),
                $"Mismatch between QueryMatchId {id} and group index {groupIndex}");

            k_SetMemberIndices.Clear();
            k_KnownMembers.Clear();

            var hasMembers = MemberData.MatchIdToIndex.TryGetValue(id, out var memberIndices);

            if (hasMembers)
            {
                // collect data on known members to facilitate remove / update
                for (var orderIndex = 0; orderIndex < memberIndices.Count; orderIndex++)
                {
                    var memberIndex = memberIndices[orderIndex];
                    var mrObject = MemberData.ObjectReferences[memberIndex];
                    k_KnownMembers.Add(new KnownMember(mrObject, memberIndex));
                }

                var children = args.relations.children;

                // remove members that are gone
                for (var i = k_KnownMembers.Count - 1; i >= 0; i--)
                {
                    var knownMember = k_KnownMembers[i];
                    if (children.ContainsKey(knownMember.Reference))
                        continue;

                    MemberData.Remove(id, knownMember.DataIndex);
                    // Data child removal will happen with Data.Modify
                    // as that will reconstruct all data buffers / structures
                    // and re-associate with the current set of relations
                    k_KnownMembers.RemoveAt(i);
                }

                // add or update
                foreach (var kvp in children)
                {
                    var knownIndex = -1;
                    for (var i = 0; i < k_KnownMembers.Count; i++)
                    {
                        var knownMember = k_KnownMembers[i];
                        if (!ReferenceEquals(knownMember.Reference, kvp.Key))
                            continue;

                        knownIndex = i;
                        break;
                    }

                    if (knownIndex >= 0)
                    {
                        // update
                        var knownMember = k_KnownMembers[knownIndex];

                        MemberData.Modify(id, knownMember.DataIndex, kvp.Value);
                        k_KnownMembers.RemoveAt(knownIndex);
                    }
                    else
                    {
                        // register
                        MemberData.Register(id, kvp.Key, kvp.Value);
                    }
                }

                k_KnownMembers.Clear();
            }
            else
            {
                RegisterRelationChildren(id, args);

                MemberData.MatchIdToIndex.TryGetValue(id, out memberIndices);
            }

            GetIndexPairs(id, args);

            // the index arrays for group & relation members are so small that we create new ones
            // on registration, instead of using pooled Lists
            var memberIndicesArray = memberIndices.ToArray();
            var relationIndexPairs = k_RelationIndexPairs.ToArray();
            Data.Modify(groupIndex, memberIndicesArray, relationIndexPairs, args);

            k_TempChildResults.Clear();
            foreach (var i in memberIndices)
            {
                k_TempChildResults.Add(MemberData.ObjectReferences[i], MemberData.QueryResults[i]);
            }

            Data.QueryResults[groupIndex].SetChildren(k_TempChildResults);

            // for each group member, store a representation of which relations it belongs to.
            Data.GetRelationMemberships(groupIndex, k_RelationMemberships);
            foreach (var kvp in k_RelationMemberships)
            {
                var memberIndex = kvp.Key;
                MemberData.RelationMemberships[memberIndex] = kvp.Value;
            }

            // calculate the solve order weighting for this group
            var weights = QueryPipelineConfiguration.instance.SolveOrderWeighting;
            var order = GetGroupOrderWeight(memberIndicesArray, relationIndexPairs.Length, MemberData.Exclusivities, weights);
            Data.OrderWeights[groupIndex] = order;

            Data.InitializeSearchData(groupIndex, MemberData.ReducedConditionRatings);
        }

        void RegisterRelationChildren(QueryMatchID id, SetQueryArgs args)
        {
            k_SetMemberIndices.Clear();
            foreach (var kvp in args.relations.children)
            {
                var childArgs = kvp.Value;
                // register each group member in the member data and get its index into those collections
                var memberIndex = MemberData.Register(id, kvp.Key, childArgs);
                k_SetMemberIndices.Add(memberIndex);
            }
        }

        internal bool Remove(QueryMatchID id)
        {
            if (!Data.MatchIdToIndex.ContainsKey(id))
                return false;

            Data.Remove(id);
            MemberData.Remove(id);
            return true;
        }

        internal bool RemoveAndTimeout(QueryMatchID id)
        {
            if (!Data.MatchIdToIndex.TryGetValue(id, out var index))
                return false;

            Data.TimeoutHandlers[index]?.Invoke(Data.SetQueryArgs[index]);
            Data.Remove(id);
            MemberData.Remove(id);
            return true;
        }

        internal void SetGroupToAcquire(int groupIndex)
        {
            if (!Data.AcquiringIndices.Contains(groupIndex))
                Data.AcquiringIndices.Add(groupIndex);
        }

        void GetIndexPairs(QueryMatchID id, SetQueryArgs args)
        {
            k_RelationIndexPairs.Clear();
            var relations = args.relations;

            GetAllIndexPairs(id, relations);
        }

        void GetAllIndexPairs(object queryMatchId, object relations) { }

        void GetIndexPairs<T>(QueryMatchID id, IRelation<T>[] relations)
        {
            foreach (var relation in relations)
            {
                int one, two;
                if (MemberData.TryGetRelationMemberIndices(id, relation.child1, relation.child2, out one, out two))
                    k_RelationIndexPairs.Add(new RelationDataPair(one, two));
            }
        }

        /// <summary>
        /// Calculate the weight that determines which of the active Groups get solved first, for a single Group.
        /// </summary>
        /// <param name="memberIndices">The member indices for the Group</param>
        /// <param name="relationCount">The number of relations in the Group</param>
        /// <param name="memberExclusivities">The global container for all group members' Exclusivity value</param>
        /// <param name="weights">The configured weights that determine how important each contribution is</param>
        /// <returns>The order weighting for the Group - higher numbers go before lower ones</returns>
        internal static float GetGroupOrderWeight(int[] memberIndices, int relationCount,
            Exclusivity[] memberExclusivities, GroupOrderWeights weights)
        {
            var score = relationCount * weights.RelationWeight;
            foreach (var memberIndex in memberIndices)
            {
                switch (memberExclusivities[memberIndex])
                {
                    case Exclusivity.Reserved:
                        score += weights.ReservedMemberWeight;
                        break;
                    case Exclusivity.Shared:
                        score += weights.SharedMemberWeight;
                        break;
                }
            }

            return score;
        }


        internal void HandleTimeouts()
        {
            CheckTimeouts(Data.AcquiringIndices, Data.TimeOuts, CycleDeltaTime, k_TimeoutIndices);
            foreach (var index in k_TimeoutIndices)
            {
                k_TimeoutIds.Add(Data.QueryMatchIds[index]);
            }

            if (OnTimeout != null)
                OnTimeout(k_TimeoutIds);

            k_TimeoutIds.Clear();
        }

        internal static void CheckTimeouts(List<int> workingIndexes, float[] timeoutsRemaining, float deltaTime,
            HashSet<int> indexesToRemove)
        {
            indexesToRemove.Clear();
            foreach (var i in workingIndexes)
            {
                var remaining = timeoutsRemaining[i];
                // no timeout - ignore this one
                if (remaining <= 0f)
                    continue;

                remaining -= deltaTime;
                if(remaining <= 0f)
                    indexesToRemove.Add(i);
                else
                    timeoutsRemaining[i] = remaining;
            }
        }

        internal void CycleStart()
        {
            Data.ClearCycleIndices();

            // make sure that group members' acquiring indices are always synced to groups' acquiring indices
            MemberData.AcquiringIndices.Clear();
            foreach (var groupAcquiringIndex in Data.AcquiringIndices)
            {
                foreach (var mi in Data.MemberIndices[groupAcquiringIndex])
                {
                    MemberData.AcquiringIndices.Add(mi);
                }
            }

            MemberData.ClearCycleIndices();

            MemberTraitCacheStage.CycleStart();
            RelationTraitCacheStage.CycleStart();
            MemberConditionRatingStage.CycleStart();
            MemberMatchIntersectionStage.CycleStart();
            MemberTraitRequirementStage.CycleStart();
            MemberDataAvailabilityStage.CycleStart();
            MemberMatchReductionStage.CycleStart();
            GroupRelationRatingStage.CycleStart();
            MemberResultFillStage.CycleStart();
            GroupResultFillStage.CycleStart();
            FilterRelationMembersStage.CycleStart();
            MatchSearchStage.CycleStart();
            AcquireHandlingStage.CycleStart();
        }

        public void StartCycle()
        {
            var time = MarsTime.Time;
            CycleDeltaTime = time - LastCycleStartTime;
            LastCycleStartTime = time;
            HandleTimeouts();

            m_Database.StartUpdateBuffering();
            m_LastCompletedFence = 1;
            CurrentlyActive = true;

            CycleStart();
        }

        internal void SetupData()
        {
            Configuration = QueryPipelineConfiguration.instance;

            var memoryOptions = MARSMemoryOptions.instance;
            Data = new ParallelGroupData(memoryOptions.QueryDataCapacity);
            // make sure that we refresh references to arrays when they have been resized behind the scenes
            Data.OnResize += WireStages;

            var memberCapacityMultiplier = memoryOptions.SetMemberCapacityMultiplier;
            MemberData = new ParallelGroupMemberData(memoryOptions.QueryDataCapacity * memberCapacityMultiplier);
            MemberData.OnResize += WireStages;

            // insert a blank stage to represent the idle part of the cycle
            Stages.Add(null);

            MemberTraitCacheStage = SetupMemberTraitCacheStage();
            RelationTraitCacheStage = SetupRelationTraitCacheStage();
            MemberConditionRatingStage = SetupMemberMatchRating();
            IncompleteGroupFilterStage = SetupIncompleteGroupFilter();
            MemberMatchIntersectionStage = SetupMatchIntersection();
            MemberTraitRequirementStage = SetupTraitFilterStage();
            MemberDataAvailabilityStage = SetupAvailabilityCheckStage();
            MemberMatchReductionStage = SetupMatchReduction();
            GroupRelationRatingStage = SetupRelationRatingStage();
            FilterRelationMembersStage = SetupFilterRelationMembersStage();
            MatchSearchStage = SetupMatchSearchStage();
            MarkDataUsedStage = SetupMarkUsedStage();
            MemberResultFillStage = SetupQueryResultFill();
            GroupResultFillStage = SetupSetQueryResultFill();

            AcquireHandlingStage = SetupAcquireHandlingStage();
        }

        void WireStages()
        {
            WireMemberTraitCacheStage(MemberTraitCacheStage);
            WireRelationTraitCacheStage(RelationTraitCacheStage);
            WireConditionMatchRatingStage(MemberConditionRatingStage);
            WireRelationRatingStage(GroupRelationRatingStage);
            WireMatchProposalsStage(MemberMatchIntersectionStage);
            WireFilterRelationMembersStage(FilterRelationMembersStage);
            WireIncompleteGroupFilterStage(IncompleteGroupFilterStage);
            WireMatchReductionStage(MemberMatchReductionStage);
            WireMatchSearchStage(MatchSearchStage);
            WireMarkUsedStage(MarkDataUsedStage);
            WireMemberResultFillStage(MemberResultFillStage);
            WireSetQueryResultFillStage(GroupResultFillStage);
            WireAcquireHandlingStage(AcquireHandlingStage);
            WireGroupAvailabilityCheckStage(MemberDataAvailabilityStage);
            WireTraitFilterStage(MemberTraitRequirementStage);
        }

        internal CacheTraitReferencesStage SetupMemberTraitCacheStage()
        {
            var dataTransform = new TraitRefTransform(m_Database.CacheTraitReferences)
            {
                WorkingIndices = MemberData.AcquiringIndices,
                Input1 = MemberData.FilteredAcquiringIndices,
            };

            var stage = new CacheTraitReferencesStage(dataTransform);
            WireMemberTraitCacheStage(stage);

            Stages.Add(stage);
            return stage;
        }

        void WireMemberTraitCacheStage(CacheTraitReferencesStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = MemberData.Conditions;
            transform.Output = MemberData.CachedTraits;
        }

        internal CacheRelationTraitReferencesStage SetupRelationTraitCacheStage()
        {
            var stage = new CacheRelationTraitReferencesStage(new RelationTraitRefTransform(m_Database.CacheTraitReferences));
            WireRelationTraitCacheStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireRelationTraitCacheStage(CacheRelationTraitReferencesStage stage)
        {
            var transform = stage.Transformation;
            transform.WorkingIndices = Data.AcquiringIndices;
            transform.Input1 = Data.FilteredAcquiringIndices;
            transform.Input2 = Data.Relations;
            transform.Output = Data.CachedTraits;
        }

        internal ConditionMatchRatingStage SetupMemberMatchRating()
        {
            var stage = new ConditionMatchRatingStage(new MatchRatingDataTransform());
            WireConditionMatchRatingStage(stage);
            Stages.Add(stage);
            return stage;
        }

        internal IncompleteGroupFilterStage SetupIncompleteGroupFilter()
        {
            var dataTransform = new IncompleteGroupFilterTransform()
            {
                WorkingIndices = MemberData.FilteredAcquiringIndices,
                Input1 = Data.AcquiringIndices,
                Input2 = Data.MemberIndices,
                Output = Data.FilteredAcquiringIndices
            };

            var stage = new IncompleteGroupFilterStage(dataTransform);
            Stages.Add(stage);
            return stage;
        }

        void WireIncompleteGroupFilterStage(IncompleteGroupFilterStage stage)
        {
            IncompleteGroupFilterStage.Transformation.Input2 = Data.MemberIndices;
        }

        void WireConditionMatchRatingStage(ConditionMatchRatingStage stage)
        {
            var transform = stage.Transformation;
            transform.WorkingIndices = MemberData.FilteredAcquiringIndices;
            transform.Input1 = MemberData.Conditions;
            transform.Input2 = MemberData.CachedTraits;
            transform.Output = MemberData.ConditionRatings;
        }

        internal FindMatchProposalsStage SetupMatchIntersection()
        {
            var transform = new FindMatchProposalsTransform()
            {
                WorkingIndices = MemberData.FilteredAcquiringIndices,
                Input1 = MemberData.PotentialMatchAcquiringIndices
            };

            var stage = new FindMatchProposalsStage(transform);
            WireMatchProposalsStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireMatchProposalsStage(FindMatchProposalsStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = MemberData.ConditionRatings;
            transform.Output = MemberData.ConditionMatchSets;
        }

        internal SetDataAvailabilityCheckStage SetupAvailabilityCheckStage()
        {
            var dataTransform = new CheckSetDataAvailabilityTransform()
            {
                WorkingIndices = Data.FilteredAcquiringIndices,
                Input1 = Data.MemberIndices,
                Input2 = m_Database.DataUsedByQueries,
                Input3 = m_Database.ReservedData,
                Input4 = m_Database.SharedDataUsersCounter,
            };

            var stage = new SetDataAvailabilityCheckStage(dataTransform);
            WireGroupAvailabilityCheckStage(stage);

            Stages.Add(stage);
            return stage;
        }

        void WireGroupAvailabilityCheckStage(SetDataAvailabilityCheckStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = Data.MemberIndices;
            transform.Input5 = MemberData.QueryMatchIds;
            transform.Input6 = MemberData.Exclusivities;
            transform.Output = MemberData.ConditionMatchSets;
        }

        internal TraitRequirementFilterStage SetupTraitFilterStage()
        {
            var dataTransform = new TraitRequirementFilterTransform()
            {
                WorkingIndices = MemberData.PotentialMatchAcquiringIndices,
                Input1 = m_Database.TypeToFilterAction,
            };

            var stage = new TraitRequirementFilterStage(dataTransform);
            WireTraitFilterStage(stage);

            Stages.Add(stage);
            return stage;
        }

        void WireTraitFilterStage(TraitRequirementFilterStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = MemberData.TraitRequirements;
            transform.Output = MemberData.ConditionMatchSets;
        }

        internal MatchReductionStage SetupMatchReduction()
        {
            var dataTransform = new MatchReductionTransform
            {
                WorkingIndices = MemberData.PotentialMatchAcquiringIndices,
            };

            var stage = new MatchReductionStage(dataTransform);
            WireMatchReductionStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireMatchReductionStage(MatchReductionStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = MemberData.ConditionRatings;
            transform.Input2 = MemberData.ConditionMatchSets;
            transform.Output = MemberData.ReducedConditionRatings;
        }

        internal RelationRatingStage SetupRelationRatingStage()
        {
            var dataTransform = new RelationRatingTransform()
            {
                WorkingIndices = Data.FilteredAcquiringIndices,
                Input1 = Data.PotentialMatchAcquiringIndices,
                Input2 = Data.RelationIndexPairs,
                Input3 = Data.Relations,
                Input4 = Data.CachedTraits,
                Input5 = MemberData.ReducedConditionRatings,
                Output = Data.RelationRatings,
            };

            var stage = new RelationRatingStage(dataTransform);
            Stages.Add(stage);
            return stage;
        }

        void WireRelationRatingStage(RelationRatingStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = Data.RelationIndexPairs;
            transform.Input3 = Data.Relations;
            transform.Input4 = Data.CachedTraits;
            transform.Input5 = MemberData.ReducedConditionRatings;
            transform.Output = Data.RelationRatings;
        }

        internal FilterRelationMemberMatchesStage SetupFilterRelationMembersStage()
        {
            var dataTransform = new FilterRelationMemberMatchesTransform()
            {
                WorkingIndices = Data.PotentialMatchAcquiringIndices,
            };

            var stage = new FilterRelationMemberMatchesStage(dataTransform);
            WireFilterRelationMembersStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireFilterRelationMembersStage(FilterRelationMemberMatchesStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = Data.RelationRatings;
            transform.Input1 = Data.MemberIndices;
            transform.Input3 = MemberData.RelationMemberships;
            transform.Output = MemberData.ReducedConditionRatings;
        }

        internal GroupMatchSearchStage SetupMatchSearchStage()
        {
            var transform = new GroupMatchSearchTransform()
            {
                SearchSpacePortionCurve = QueryPipelineConfiguration.instance.SearchSpacePortionCurve,
                SetMatchIds = Data.QueryMatchIds,
                PreviousMatches = m_Database.SetDataUsedByQueries,
                WorkingIndices = Data.PotentialMatchAcquiringIndices,
                Input1 = Data.DefiniteMatchAcquireIndices,
            };

            var stage = new GroupMatchSearchStage(transform);
            WireMatchSearchStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireMatchSearchStage(GroupMatchSearchStage stage)
        {
            var transform = stage.Transformation;
            transform.SetMatchIds = Data.QueryMatchIds;
            transform.AllGroupPriorities = Data.Priorities;
            transform.Input2 = Data.MemberIndices;
            transform.Input3 = Data.LocalRelationIndexPairs;
            transform.Input4 = Data.RelationRatings;
            transform.Input5 = Data.OrderWeights;
            transform.Input6 = Data.SearchData;
            transform.Input7 = MemberData.RelationMemberships;
            transform.Input8 = MemberData.Exclusivities;
            transform.Input9 = MemberData.ReducedConditionRatings;
            transform.Output = MemberData.BestMatchDataIds;
        }

        internal MarkSetUsedStage SetupMarkUsedStage()
        {
            var markUsed = new MarkGroupDataUsedTransform
            {
                Process = m_Database.MarkGroupDataUsedAction,
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
            };

            var updateWorkingMembers = new SetWorkingMembersTransform()
            {
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
                Output = MemberData.DefiniteMatchAcquireIndices
            };

            var stage = new MarkSetUsedStage(markUsed, updateWorkingMembers);
            WireMarkUsedStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireMarkUsedStage(MarkSetUsedStage stage)
        {
            var markUsedTransform = stage.Transformation1;
            markUsedTransform.Input1 = Data.MemberIndices;
            markUsedTransform.Input2 = Data.QueryMatchIds;
            markUsedTransform.Input3 = Data.UsedByMatch;
            markUsedTransform.Input4 = Data.SetMatchData;
            markUsedTransform.Input5 = MemberData.BestMatchDataIds;
            markUsedTransform.Input6 = MemberData.ObjectReferences;
            markUsedTransform.Output = MemberData.Exclusivities;

            var setMembersTransform = stage.Transformation2;
            setMembersTransform.Input1 = Data.MemberIndices;
        }

        internal ResultFillStage SetupQueryResultFill()
        {
            var dataTransform = new ResultFillTransform
            {
                WorkingIndices = MemberData.DefiniteMatchAcquireIndices,
                FillRequiredTraitsAction = m_Database.FillQueryResultRequirements
            };

            var stage = new ResultFillStage(dataTransform);
            WireMemberResultFillStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireMemberResultFillStage(ResultFillStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = MemberData.BestMatchDataIds;
            transform.Input2 = MemberData.Conditions;
            transform.Input3 = MemberData.CachedTraits;
            transform.Input4 = MemberData.TraitRequirements;
            transform.Input5 = MemberData.QueryMatchIds;
            transform.Output = MemberData.QueryResults;
        }

        internal GroupResultFillStage SetupSetQueryResultFill()
        {
            var dataTransform = new SetResultFillTransform()
            {
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
            };

            var stage = new GroupResultFillStage(dataTransform);
            WireSetQueryResultFillStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireSetQueryResultFillStage(GroupResultFillStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = Data.MemberIndices;
            transform.Input2 = Data.QueryMatchIds;
            transform.Input3 = MemberData.QueryResults;
            transform.Input4 = MemberData.ObjectReferences;
            transform.Output = Data.QueryResults;
        }

        GroupAcquireHandlingStage SetupAcquireHandlingStage()
        {
            var dataTransform = new GroupAcquireHandlingTransform()
            {
                Pipeline = this,
                QueryBackend = ModuleLoaderCore.instance.GetModule<MARSQueryBackend>(),
                WorkingIndices = Data.DefiniteMatchAcquireIndices
            };

            var indicesTransform = new ManageIndicesTransform()
            {
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
                Input1 = Data.UpdatingIndices,
                Output = Data.AcquiringIndices
            };

            var memberIndicesTransform = new ManageGroupIndicesTransform()
            {
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
                Input2 = MemberData.UpdatingIndices,
                Output = MemberData.AcquiringIndices
            };

            var stage = new GroupAcquireHandlingStage(dataTransform, indicesTransform, memberIndicesTransform);
            WireAcquireHandlingStage(stage);
            Stages.Add(stage);
            return stage;
        }

        void WireAcquireHandlingStage(GroupAcquireHandlingStage stage)
        {
            stage.Transformation1.Input1 = Data.QueryResults;
            stage.Transformation1.Output = Data.AcquireHandlers;
            stage.Transformation3.Input1 = Data.MemberIndices;
        }


        /// <summary>
        /// Tests if the query at the given index still has valid data
        /// </summary>
        /// <returns>True if valid, false if the data has become invalid</returns>
        internal bool QueryAnswerAtIndexIsStillValid(int index)
        {
            return m_Database.TryUpdateSetQueryMatchData(Data.SetMatchData[index], Data.Relations[index], Data.QueryResults[index], true);
        }

        internal void Clear()
        {
            Data.Clear();
            MemberData.Clear();
        }

        public bool IsReadyForTraitDataBufferSync { get; private set; }

        internal bool ForceEvaluation()
        {
            m_ForceEvaluationMarker.Begin();
            CycleStart();

            MemberTraitCacheStage.Complete();
            RelationTraitCacheStage.Complete();
            MemberConditionRatingStage.Complete();
            IncompleteGroupFilterStage.Complete();
            MemberMatchIntersectionStage.Complete();
            MemberDataAvailabilityStage.Complete();
            MemberTraitRequirementStage.Complete();
            MemberMatchReductionStage.Complete();
            GroupRelationRatingStage.Complete();
            FilterRelationMembersStage.Complete();
            MatchSearchStage.Complete();
            MarkDataUsedStage.Complete();
            MemberResultFillStage.Complete();
            GroupResultFillStage.Complete();

            m_ForceEvaluationMarker.End();
            // acquire handling comes after the profiler label because we've already found the answer
            AcquireHandlingStage.Complete();

            onStageGroupCompletion?.Invoke();
            // Return whether we had any matches this iteration
            return Data.DefiniteMatchAcquireIndices.Count > 0;
        }

        public void OnUpdate()
        {
            var budgets = Configuration.SetFrameBudgets;
            if (budgets.Length == 0)
                return;

            if(budgets.Length != Stages.Count)
                Debug.LogErrorFormat("group stage frame budgets length {0}, but we have {1} stages",
                    budgets.Length, Stages.Count);

            var workingStage = Stages[m_LastCompletedFence];
            if (workingStage == null)
                return;

            var stageBudget = budgets[m_LastCompletedFence];
            workingStage.FrameBudget = stageBudget;

            // adjacent stages with a budget of 0 get run on the same frame as each other
            while (stageBudget == 0)
            {
                workingStage.Complete();

                onStageGroupCompletion?.Invoke();
                m_LastCompletedFence++;
                if (m_LastCompletedFence == Stages.Count)
                {
                    m_LastCompletedFence = 1;
                    CurrentlyActive = false;
                    return;
                }

                workingStage = Stages[m_LastCompletedFence];
                stageBudget = budgets[m_LastCompletedFence];
                workingStage.FrameBudget = stageBudget;
            }

            if (m_ElapsedFramesForCurrentStage >= stageBudget)
                workingStage.Complete();
            else
                workingStage.Tick();

            if (workingStage.IsComplete)
            {
                m_ElapsedFramesForCurrentStage = 0;
                onStageGroupCompletion?.Invoke();
                m_LastCompletedFence++;

                if (m_LastCompletedFence == Stages.Count - 1)
                {
                    // after the stage before acquire handling is complete, it's OK to sync buffered trait data changes.
                    IsReadyForTraitDataBufferSync = true;
                }
                else if (m_LastCompletedFence == Stages.Count)
                {
                    m_LastCompletedFence = 1;
                    CurrentlyActive = false;
                    IsReadyForTraitDataBufferSync = false;
                }
            }
            else
            {
                m_ElapsedFramesForCurrentStage++;
            }
        }
    }
}

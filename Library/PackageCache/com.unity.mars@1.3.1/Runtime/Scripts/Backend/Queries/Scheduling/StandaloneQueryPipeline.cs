using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.MARS.Simulation;
using Unity.XRTools.ModuleLoader;
using Unity.Profiling;
using UnityEngine;

namespace Unity.MARS.Query
{
    internal class StandaloneQueryPipeline : QueryPipelineBase
    {
        internal QueryStage[] Stages;

        int m_CurrentRunGroupIndex;
        int m_LastCompletedFence;

        ProfilerMarker m_ForceEvaluationMarker = new ProfilerMarker("ForceEvaluation");

        internal CacheTraitReferencesStage CacheTraitReferencesStage;
        internal ConditionMatchRatingStage ConditionRatingStage;
        internal FindMatchProposalsStage FindMatchProposalsStage;
        internal DataAvailabilityCheckStage DataAvailabilityStage;
        internal TraitRequirementFilterStage TraitFilterStage;
        internal MatchReductionStage MatchReductionStage;
        internal FindBestStandaloneMatchStage BestStandaloneMatchStage;
        internal ResultFillStage ResultFillStage;
        internal MarkUsedStage MarkUsedStage;
        internal AcquireHandlingStage AcquireHandlingStage;

        /// <summary>
        /// Stores all data that exists for each standalone context / query
        /// </summary>
        internal ParallelQueryData Data;

        internal event Action<HashSet<QueryMatchID>> onTimeout;
        internal event Action onStageGroupCompletion;

        /// <summary>
        /// The active run configuration for the pipeline
        /// </summary>
        public QueryPipelineConfiguration configuration;

        public StandaloneQueryPipeline(MARSDatabase db)
        {
            m_Database = db;
            SetupData();
            SetupStageArray();
        }

        public bool IsReadyForTraitDataBufferSync { get; private set; }

        void SetupStageArray()
        {
            Stages = new QueryStage[]
            {
                // the null stage represents the idle part of the cycle
                null,
                CacheTraitReferencesStage,
                ConditionRatingStage,
                FindMatchProposalsStage,
                DataAvailabilityStage,
                TraitFilterStage,
                MatchReductionStage,
                BestStandaloneMatchStage,
                ResultFillStage,
                MarkUsedStage,
                AcquireHandlingStage
            };
        }

        internal void SetupData()
        {
            configuration = QueryPipelineConfiguration.instance;
            Data = new ParallelQueryData(MARSMemoryOptions.instance.QueryDataCapacity);
            Data.OnResize += WireStages;

            CacheTraitReferencesStage = SetupTraitCacheStage();
            ConditionRatingStage = SetupMatchRating();
            FindMatchProposalsStage = SetupMatchIntersection();
            DataAvailabilityStage = SetupAvailabilityCheckStage();
            TraitFilterStage = SetupTraitFilterStage();
            MatchReductionStage = SetupMatchReduction();
            BestStandaloneMatchStage = SetupBestStandaloneMatchStage();
            ResultFillStage = SetupQueryResultFill();
            MarkUsedStage = SetupMarkUsedStage();
            AcquireHandlingStage = SetupAcquireHandlingStage();
        }

        void WireStages()
        {
            WireTraitCacheStage(CacheTraitReferencesStage);
            WireMatchRatingStage(ConditionRatingStage);
            WireMatchIntersectionStage(FindMatchProposalsStage);
            WireAvailabilityCheckStage(DataAvailabilityStage);
            WireTraitFilterStage(TraitFilterStage);
            WireMatchReductionStage(MatchReductionStage);
            WireBestMatchStage(BestStandaloneMatchStage);
            WireResultFillStage(ResultFillStage);
            WireMarkUsedStage(MarkUsedStage);
            WireAcquireHandlingStage(AcquireHandlingStage);
        }

        internal void ClearData()
        {
            Data.Clear();
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

        void CycleStart()
        {
            Data.ClearCycleIndices();
            BestStandaloneMatchStage.CycleStart();
            CacheTraitReferencesStage.CycleStart();
            ConditionRatingStage.CycleStart();
            FindMatchProposalsStage.CycleStart();
            DataAvailabilityStage.CycleStart();
            TraitFilterStage.CycleStart();
            MatchReductionStage.CycleStart();
            BestStandaloneMatchStage.CycleStart();
            ResultFillStage.CycleStart();
            MarkUsedStage.CycleStart();
            AcquireHandlingStage.CycleStart();
        }

        internal bool ForceEvaluation()
        {
            m_ForceEvaluationMarker.Begin();

            CycleStart();
            AcquireHandlingStage.OnCycleStart();
            BestStandaloneMatchStage.CycleStart();

            CacheTraitReferencesStage.Complete();
            ConditionRatingStage.Complete();

            FindMatchProposalsStage.Complete();
            DataAvailabilityStage.Complete();
            TraitFilterStage.Complete();
            MatchReductionStage.Complete();
            BestStandaloneMatchStage.Complete();

            ResultFillStage.Transformation.applyOffsetToPose = m_Database.ApplyOffsetToPose;
            ResultFillStage.Complete();
            MarkUsedStage.Complete();

            m_ForceEvaluationMarker.End();
            // acquire handling usually takes longer than any other stage by far and we already have the answers
            AcquireHandlingStage.Complete();

            if(onStageGroupCompletion != null)
                onStageGroupCompletion();

            CurrentlyActive = false;
            // Return whether we had any matches this iteration
            return Data.DefiniteMatchAcquireIndices.Count > 0;
        }

        internal CacheTraitReferencesStage SetupTraitCacheStage()
        {
            var dataTransform = new TraitRefTransform(m_Database.CacheTraitReferences)
            {
                WorkingIndices = Data.AcquiringIndices,
                Input1 = Data.FilteredAcquiringIndices,
            };

            var stage = new CacheTraitReferencesStage(dataTransform);
            WireTraitCacheStage(stage);
            return stage;
        }

        void WireTraitCacheStage(CacheTraitReferencesStage stage)
        {
            stage.Transformation.Input2 = Data.Conditions;
            stage.Transformation.Output = Data.CachedTraits;
        }

        internal ConditionMatchRatingStage SetupMatchRating()
        {
            var dataTransform = new MatchRatingDataTransform
            {
                WorkingIndices = Data.FilteredAcquiringIndices,
            };

            var stage = new ConditionMatchRatingStage(dataTransform);
            WireMatchRatingStage(stage);
            return stage;
        }

        void WireMatchRatingStage(ConditionMatchRatingStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = Data.Conditions;
            transform.Input2 = Data.CachedTraits;
            transform.Output = Data.ConditionRatings;
        }

        internal FindMatchProposalsStage SetupMatchIntersection()
        {
            var dataTransform = new FindMatchProposalsTransform
            {
                WorkingIndices = Data.FilteredAcquiringIndices,
                Input1 = Data.PotentialMatchAcquiringIndices,
            };

            var stage = new FindMatchProposalsStage(dataTransform);
            WireMatchIntersectionStage(stage);
            return stage;
        }

        void WireMatchIntersectionStage(FindMatchProposalsStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = Data.ConditionRatings;
            transform.Output = Data.ConditionMatchSets;
        }

        internal DataAvailabilityCheckStage SetupAvailabilityCheckStage()
        {
            var dataTransform = new DataAvailabilityTransform()
            {
                WorkingIndices = Data.PotentialMatchAcquiringIndices,
                Input1 = m_Database.DataUsedByQueries,
                Input2 = m_Database.ReservedData,
                Input3 = m_Database.SharedDataUsersCounter,
                Input4 = Data.QueryMatchIds,
                Input5 = Data.Exclusivities,
                Output = Data.ConditionMatchSets
            };

            var stage = new DataAvailabilityCheckStage(dataTransform);
            WireAvailabilityCheckStage(stage);
            return stage;
        }

        void WireAvailabilityCheckStage(DataAvailabilityCheckStage stage)
        {
            var transform = stage.Transformation;
            transform.Input4 = Data.QueryMatchIds;
            transform.Input5 = Data.Exclusivities;
            transform.Output = Data.ConditionMatchSets;
        }

        internal TraitRequirementFilterStage SetupTraitFilterStage()
        {
            var dataTransform = new TraitRequirementFilterTransform()
            {
                WorkingIndices = Data.PotentialMatchAcquiringIndices,
                Input1 = m_Database.TypeToFilterAction,
            };

            var stage = new TraitRequirementFilterStage(dataTransform);
            WireTraitFilterStage(stage);
            return stage;
        }

        void WireTraitFilterStage(TraitRequirementFilterStage stage)
        {
            stage.Transformation.Input2 = Data.TraitRequirements;
            stage.Transformation.Output = Data.ConditionMatchSets;
        }

        internal MatchReductionStage SetupMatchReduction()
        {
            var dataTransform = new MatchReductionTransform
            {
                WorkingIndices = Data.PotentialMatchAcquiringIndices,
            };

            var stage = new MatchReductionStage(dataTransform);
            WireMatchReductionStage(stage);
            return stage;
        }

        void WireMatchReductionStage(MatchReductionStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = Data.ConditionRatings;
            transform.Input2 = Data.ConditionMatchSets;
            transform.Output = Data.ReducedConditionRatings;
        }

        internal FindBestStandaloneMatchStage SetupBestStandaloneMatchStage()
        {
            var dataIdCollection = Data.BestMatchDataIds;
            // assign all match Ids to an invalid value when we initialize the pipeline,
            // so that we do not get queries matching against ID 0 by mistake.
            const int invalidId = (int)ReservedDataIDs.Invalid;
            for (var i = 0; i < dataIdCollection.Length; i++)
            {
                dataIdCollection[i] = invalidId;
            }

            var transformation = new FindBestMatchTransform(MARSMemoryOptions.instance.QueryDataCapacity)
            {
                WorkingIndices = Data.PotentialMatchAcquiringIndices,
                Input1 = Data.DefiniteMatchAcquireIndices,
            };

            var stage = new FindBestStandaloneMatchStage(transformation);
            WireBestMatchStage(stage);
            return stage;
        }

        void WireBestMatchStage(FindBestStandaloneMatchStage stage)
        {
            var transform = stage.Transformation;
            transform.Input2 = Data.ReducedConditionRatings;
            transform.Input3 = Data.Exclusivities;
            transform.Input4 = Data.Priority;
            transform.Output = Data.BestMatchDataIds;
        }

        internal ResultFillStage SetupQueryResultFill()
        {
            var dataTransform = new ResultFillTransform
            {
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
                FillRequiredTraitsAction = m_Database.FillQueryResultRequirements
            };

            var stage = new ResultFillStage(dataTransform);
            WireResultFillStage(stage);
            return stage;
        }

        void WireResultFillStage(ResultFillStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = Data.BestMatchDataIds;
            transform.Input2 = Data.Conditions;
            transform.Input3 = Data.CachedTraits;
            transform.Input4 = Data.TraitRequirements;
            transform.Input5 = Data.QueryMatchIds;
            transform.Output = Data.QueryResults;
        }

        internal MarkUsedStage SetupMarkUsedStage()
        {
            var transform = new MarkDataUsedTransform
            {
                Process = m_Database.MarkDataUsedAction,
                WorkingIndices = Data.DefiniteMatchAcquireIndices,
            };

            var stage = new MarkUsedStage(transform);
            WireMarkUsedStage(stage);
            return stage;
        }

        void WireMarkUsedStage(MarkUsedStage stage)
        {
            var transform = stage.Transformation;
            transform.Input1 = Data.BestMatchDataIds;
            transform.Input2 = Data.QueryMatchIds;
            transform.Output = Data.Exclusivities;
        }

        internal AcquireHandlingStage SetupAcquireHandlingStage()
        {
            var handlerTransform = new AcquireHandlingTransform
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

            var stage = new AcquireHandlingStage(handlerTransform, indicesTransform);
            WireAcquireHandlingStage(stage);
            return stage;
        }

        void WireAcquireHandlingStage(AcquireHandlingStage stage)
        {
            stage.Transformation1.Input1 = Data.QueryResults;
            stage.Transformation1.Output = Data.AcquireHandlers;
        }

        // handling timeouts is documented as query stage just like the rest, but since it
        // removes query matches, it is handled specially.
        internal void HandleTimeouts()
        {
            CheckTimeouts(Data.AcquiringIndices, Data.TimeOuts, CycleDeltaTime, k_TimeoutIndexes);
            foreach (var index in k_TimeoutIndexes)
            {
                k_TimeoutIds.Add(Data.QueryMatchIds[index]);
            }

            onTimeout?.Invoke(k_TimeoutIds);
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
        
        
        /// <summary>
        /// Tests if the query at the given index still has valid data
        /// </summary>
        /// <returns>True if valid, false if the data has become invalid</returns>
        internal bool QueryAnswerAtIndexIsStillValid(int index)
        {
            var traitRequirements = Data.TraitRequirements[index];
            var result = Data.QueryResults[index];
            return m_Database.TryUpdateQueryMatchData(result.DataID, Data.Conditions[index], traitRequirements, result);
        }

        public void OnUpdate()
        {
            var budgets = configuration.FrameBudgets;
            if (budgets.Length == 0)
                return;

            if(budgets.Length != Stages.Length)
                Debug.LogErrorFormat("standalone frame budgets length {0}, but we have {1} stages",
                    budgets.Length, Stages.Length);

            var workingStage = Stages[m_LastCompletedFence];
            var stageBudget = budgets[m_LastCompletedFence];
            
            if (workingStage == null)
            {
                m_LastCompletedFence++;
                workingStage = Stages[m_LastCompletedFence];
                stageBudget = QueryPipelineConfiguration.instance.FrameBudgets[m_LastCompletedFence];
            }

            workingStage.FrameBudget = stageBudget;
            while (stageBudget == 0)
            {
                workingStage.Complete();
                onStageGroupCompletion?.Invoke();
                m_LastCompletedFence++;
                if (m_LastCompletedFence == Stages.Length)
                {
                    m_LastCompletedFence = 1;
                    CurrentlyActive = false;
                    return;
                }

                workingStage = Stages[m_LastCompletedFence];
                stageBudget = QueryPipelineConfiguration.instance.FrameBudgets[m_LastCompletedFence];
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

                var nextStageIsAcquireHandling = m_LastCompletedFence == Stages.Length - 1;
                if (nextStageIsAcquireHandling)
                {
                    // Since we're done accessing raw trait values after ResultFillStage, it's safe to sync buffered trait changes
                    IsReadyForTraitDataBufferSync = true;
                }
                else if (m_LastCompletedFence == Stages.Length)
                {
                    // if we've just finished the last stage, mark the pipeline inactive and reset state
                    IsReadyForTraitDataBufferSync = false;
                    CurrentlyActive = false;
                    m_LastCompletedFence = 1;
                }
            }
            else
            {
                m_ElapsedFramesForCurrentStage++;
            }
        }
    }
}

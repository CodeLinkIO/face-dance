using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using UnityEngine;

namespace Unity.MARS.Query
{
    partial class ResultFillTransform : DataTransform<int[], ProxyConditions[],
        CachedTraitCollection[], ProxyTraitRequirements[],
        QueryMatchID[], QueryResult[]>
    {
        internal Func<Pose, Pose> applyOffsetToPose = p => p;

        internal Action<int, ProxyTraitRequirements, QueryResult> FillRequiredTraitsAction;

        public ResultFillTransform()
        {
            Process = FillQueryResult;
        }

        internal void FillQueryResult(List<int> indexes, int[] bestMatchIds,
            ProxyConditions[] conditions,
            CachedTraitCollection[] traits,
            ProxyTraitRequirements[] allRequirements,
            QueryMatchID[] matchIds,
            ref QueryResult[] results)
        {
            foreach (var i in indexes)
            {
                FillQueryResult(bestMatchIds[i], conditions[i], traits[i], allRequirements[i], matchIds[i], results[i]);
            }
        }

        internal void FillQueryResult(int dataId, ProxyConditions conditions, CachedTraitCollection traits,
            ProxyTraitRequirements requirements, QueryMatchID matchId, QueryResult result)
        {
            result.queryMatchId = matchId;
            result.SetDataId(dataId);

            FillRequiredTraitsAction(dataId, requirements, result);

            FillQueryResultInternal(dataId, conditions, traits, matchId, result);

            conditions.TryGetType(out ICondition<Pose>[] poseConditions);
            traits.TryGetType(out List<Dictionary<int, Pose>> poseCollections);

            for (var i = 0; i < poseConditions.Length; i++)
            {
                var poseCollection = poseCollections[i];
                var nonOffsetValue = poseCollection[dataId];
                var poseValue = applyOffsetToPose(nonOffsetValue);
                var refiner = poseConditions[i] as IPoseRefiner;
                if (refiner != null)
                {
                    poseValue = refiner.RefinePose(poseValue, true);
                }
                result.SetTrait(poseConditions[i].traitName, poseValue);
            }

            if(!conditions.TryGetType(out ISemanticTagCondition[] semanticTagConditions))
                return;

            // tags can take a shortcut with query filling - they're really just a test for presence or absence,
            // so if that test has already been passed, we can just assign a bool representing the result
            foreach (var condition in semanticTagConditions)
            {
                var isExcluding = condition.matchRule == SemanticTagMatchRule.Exclude;
                result.SetTrait(condition.traitName, !isExcluding);
            }
        }

        // ReSharper disable once UnusedMember.Local
        void FillQueryResultInternal(int dataId, object conditions, object traits,
            QueryMatchID matchId, QueryResult result) { }

        internal static void FillQueryResult<T>(int dataId,
            ICondition<T>[] typeConditions,
            List<Dictionary<int, T>> traits,
            QueryResult result)
        {
            for (var i = 0; i < typeConditions.Length; i++)
            {
                var condition = typeConditions[i];
                var traitCollection = traits[i];
                if (condition == null || traitCollection == null)
                {
                    Debug.Log("null traits while filling type " + typeof(T).Name);
                    continue;
                }

                if (traitCollection.TryGetValue(dataId, out var value))
                {
                    result.SetTrait(condition.traitName, value);
                }
                else
                {
                    Debug.LogErrorFormat("missing id {0} of trait {1}, type {2} !",
                        dataId, condition.traitName, typeof(T).Name);
                }
            }
        }
    }

    class ResultFillStage : QueryStage<ResultFillTransform>
    {
        public ResultFillStage(ResultFillTransform transformation)
             : base("Standalone Context Result Filling", transformation)
        {
        }
    }
}

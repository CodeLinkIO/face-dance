using System;
using System.Collections.Generic;
using Unity.MARS.Data;
using Unity.MARS.Settings;

namespace Unity.MARS.Query
{
    class MatchComparer : IComparer<KeyValuePair<int, float>>
    {
        public int Compare(KeyValuePair<int, float> x, KeyValuePair<int, float> y)
        {
            if (x.Value < y.Value)
                return 1;

            return x.Value > y.Value ? -1 : 0;
        }
    }

    class MatchReductionTransform : DataTransform<
        ConditionRatingsData[],
        HashSet<int>[],
        Dictionary<int, float>[]>
    {
        static KeyValuePair<int, float>[] s_RatingPairBuffer =
            new KeyValuePair<int, float>[MARSMemoryOptions.SortBufferSize];

        static readonly MatchComparer k_Comparer = new MatchComparer();

        static int s_Counter;

        public MatchReductionTransform()
        {
            Process = ReduceRatings;
        }

        internal static void ReduceRatings(List<int> indices, ConditionRatingsData[] rawRatings,
            HashSet<int>[] matchSets, ref Dictionary<int, float>[] flatRatings)
        {
            foreach (var i in indices)
            {
                var matchSet = matchSets[i];
                if(s_RatingPairBuffer.Length < matchSet.Count)
                    Array.Resize(ref s_RatingPairBuffer, matchSet.Count + MARSMemoryOptions.ResizeHeadroom);

                Execute(rawRatings[i], matchSet, flatRatings[i]);
            }
        }

        internal static void Execute(ConditionRatingsData rawRatings,
            HashSet<int> matchSet, Dictionary<int, float> flatRatings)
        {
            s_Counter = 0;
            foreach (var dataId in matchSet)
            {
                s_RatingPairBuffer[s_Counter] = new KeyValuePair<int, float>(dataId, rawRatings.RatingForId(dataId));
                s_Counter++;
            }

            // later stages will assume that the dictionary of ratings is sorted by value, so we sort here.
            // this call will only sort the members of the array up to s_Counter, because we're only using those.
            Array.Sort(s_RatingPairBuffer, 0, s_Counter, k_Comparer);

            flatRatings.Clear();
            for (var i = 0; i < s_Counter; i++)
            {
                var kvp = s_RatingPairBuffer[i];
                flatRatings.Add(kvp.Key, kvp.Value);
            }
        }
    }

    class MatchReductionStage : QueryStage<MatchReductionTransform>
    {
        public MatchReductionStage(MatchReductionTransform transformation)
            : base("Match Rating Reduction", transformation)
        {
        }
    }
 }

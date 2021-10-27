using System;
using System.Collections.Generic;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data
{
    /// <summary>
    /// Stores unfiltered match rating results for a single query's conditions
    /// </summary>
    partial class ConditionRatingsData
    {
        public List<SemanticTagMatchRule> MatchRuleIndexes = new List<SemanticTagMatchRule>();

        internal Dictionary<Type, int> TypeToIndex = new Dictionary<Type, int>();
        public readonly List<List<Dictionary<int, float>>> AllRatings = new List<List<Dictionary<int, float>>>();

        float m_ReductionPower;
#pragma warning disable 649
        int m_Count;
#pragma warning restore 649

        // The generated FromConditions function will set this value if any semantic tag conditions are present
        int m_SemanticTagListIndex;

        public int totalConditionCount => m_Count;

        /// <summary>Access the list of rating dictionaries for the given type</summary>
        public List<Dictionary<int, float>> this[Type type] =>
            TypeToIndex.TryGetValue(type, out var index) ? AllRatings[index] : null;

        /// <summary>
        /// Pre-allocate the storage for match ratings for a condition set.
        /// </summary>
        /// <param name="conditions">The set of conditions to store the results for</param>
        public ConditionRatingsData(ProxyConditions conditions)
        {
            Initialize(conditions);
        }

        public ConditionRatingsData()
        {
            m_SemanticTagListIndex = -1;
            AllRatings.Clear();
        }

        public ConditionRatingsData Initialize(ProxyConditions conditions)
        {
            m_SemanticTagListIndex = -1;
            AllRatings.Clear();
            MatchRuleIndexes.Clear();
            TypeToIndex.Clear();
            FromConditions(conditions);
            m_ReductionPower = 1f / m_Count;
            return this;
        }

        public void FromConditions(object conditions) { }

        public float RatingForId(int dataId)
        {
            var combinedRating = 1f;
            for (var i = 0; i < AllRatings.Count; i++)
            {
                var typeList = AllRatings[i];
                if (i == m_SemanticTagListIndex)
                {
                    foreach (var tagRatings in typeList)
                    {
                        if (!tagRatings.TryGetValue(dataId, out var tagRating))
                        {
                            // this was an exclusive tag, which matches by absence
                            tagRating = 1f;
                        }

                        combinedRating *= tagRating;
                    }
                }
                else
                {
                    foreach (var typeRatings in typeList)
                    {
                        // at this point, the data ID we're given is guaranteed to be present, so we do not use TryGetValue
                        combinedRating *= typeRatings[dataId];
                    }
                }
            }

            return Mathf.Pow(combinedRating, m_ReductionPower);
        }

        public void Clear()
        {
            foreach (var list in AllRatings)
            {
                foreach (var dictionary in list)
                {
                    dictionary.Clear();
                }
            }
        }

        void ClearOuter()
        {
            foreach (var list in AllRatings)
            {
                list.Clear();
            }
        }

        public void Recycle()
        {
            foreach (var list in AllRatings)
            {
                foreach (var dictionary in list)
                {
                    Pools.Ratings.Recycle(dictionary);
                }
            }

            ClearOuter();
        }
    }
}

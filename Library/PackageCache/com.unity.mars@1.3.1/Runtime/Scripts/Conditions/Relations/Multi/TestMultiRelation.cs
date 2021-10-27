using System;
using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Data;
using Unity.MARS.Query;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.MARS.Tests
{
    /// <summary>
    /// Relation that ensures two contexts have the same alignment and similar bounds sizes
    /// </summary>
    [DisallowMultipleComponent]
    [MonoBehaviourComponentMenu(typeof(TestMultiRelation), "Relation/Test Multi-Relation")]
    [MovedFrom("Unity.MARS")]
    public class TestMultiRelation : MultiRelation<TestMultiRelation.SimilarBoundsSizeRelation, TestMultiRelation.SameAlignmentRelation>
    {
        [Serializable]
        public class SimilarBoundsSizeRelation : SubRelation, IRelation<Vector2>
        {
            static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Bounds2D, TraitDefinitions.Bounds2D };

            [Tooltip("the minimum ratio of bounds size from child 1 to child 2")]
            public float MinRatio = 0.5f;
            [Tooltip("the maximum ratio of bounds size from child 1 to child 2")]
            public float MaxRatio = 1.5f;

            public string child1TraitName => k_RequiredTraits[0].TraitName;
            public string child2TraitName => k_RequiredTraits[1].TraitName;

            /// <inheritdoc />
            public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

            public float RateDataMatch(ref Vector2 child1Data, ref Vector2 child2Data)
            {
                var magnitudeRatio = child1Data.sqrMagnitude / child2Data.sqrMagnitude;
                if (magnitudeRatio < MinRatio || magnitudeRatio > MaxRatio)
                    return 0f;

                var middle = MinRatio + MaxRatio * 0.5f;
                var range = MaxRatio - MinRatio;
                var signedMiddleDiff = magnitudeRatio - middle;
                var middleDiff = signedMiddleDiff > 0 ? signedMiddleDiff : -signedMiddleDiff;
                var lerpFactor = range - middleDiff;

                var rating = 1f + MARSDatabase.MinimumRatingMinusOne * lerpFactor;
                if (rating > 1f)
                    rating = 1f;

                return rating;
            }
        }

        [Serializable]
        public class SameAlignmentRelation : SubRelation, IRelation<int>
        {
            static readonly TraitRequirement[] k_RequiredTraits = { TraitDefinitions.Alignment, TraitDefinitions.Alignment };

            public string child1TraitName => k_RequiredTraits[0].TraitName;
            public string child2TraitName => k_RequiredTraits[1].TraitName;

            /// <inheritdoc />
            public TraitRequirement[] GetRequiredTraits() { return k_RequiredTraits; }

            public float RateDataMatch(ref int child1Data, ref int child2Data)
            {
                return child1Data == child2Data ? 1f : 0f;
            }
        }

#if UNITY_EDITOR
        public override void OnValidate()
        {
            const float minimumMinimumRatio = 0.1f;
            if (Mathf.Approximately(m_Relation1.MinRatio, 0f))
                m_Relation1.MinRatio = minimumMinimumRatio;

            if (m_Relation1.MaxRatio < m_Relation1.MinRatio)
                m_Relation1.MaxRatio = m_Relation1.MinRatio;

            if(m_Relation1.child1 == null || m_Relation1.child2 == null)
                m_Relation1.SetChildren(child1Proxy, child2Proxy);

            if(m_Relation2.child1 == null || m_Relation2.child2 == null)
                m_Relation2.SetChildren(child1Proxy, child2Proxy);
        }
#endif
    }
}

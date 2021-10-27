using Unity.MARS.Attributes;
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    static class TestConditions
    {
        const string k_TraitNamePrefix = "Trait";

        [ExcludeInMARSEditor]
        internal class TestSemanticTagCondition : SemanticTagCondition
        {
            public void Initialize(int traitIndex)
            {
                SetTraitName(TraitNameForIndex(traitIndex));
            }
        }

        [ExcludeInMARSEditor]
        internal abstract class TestCondition<T> : MonoBehaviour, ITestCondition<T, float>
        {
            protected static readonly TraitRequirement[] k_RequiredTraits = null;

            public string traitName { get; set; }

            public float value { get; set; }

            public virtual void Initialize(int traitIndex)
            {
                traitName = DatabaseTestData.TraitNameForIndex<T>(traitIndex);
            }

            public TraitRequirement[] GetRequiredTraits() { return new[] { new TraitRequirement(traitName, typeof(T)) }; }

            public abstract float RateDataMatch(ref T data);
        }

        [ExcludeInMARSEditor]
        internal class Int : TestCondition<int>
        {
            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                value = traitIndex;
            }

            public override float RateDataMatch(ref int data)
            {
                return data > value ? 1f : 0f;
            }
        }

        [ExcludeInMARSEditor]
        internal class Float : TestCondition<float>
        {
            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                value = traitIndex;
            }

            public override float RateDataMatch(ref float data)
            {
                return Mathf.Clamp01(data - value);
            }
        }

        [ExcludeInMARSEditor]
        internal class Vector2 : TestCondition<UnityEngine.Vector2>
        {
            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                value = traitIndex;
            }

            public override float RateDataMatch(ref UnityEngine.Vector2 data)
            {
                return Mathf.Clamp01(data.x - value);
            }
        }

        [ExcludeInMARSEditor]
        internal class Vector3 : TestCondition<UnityEngine.Vector3>
        {
            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                value = traitIndex;
            }

            public override float RateDataMatch(ref UnityEngine.Vector3 data)
            {
                return Mathf.Clamp01(data.x - value);
            }
        }

        [ExcludeInMARSEditor]
        internal class String : TestCondition<string>
        {
            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                value = traitIndex;
            }

            public override float RateDataMatch(ref string data)
            {
                return Mathf.Clamp01(float.Parse(data) - value);
            }
        }

        [ExcludeInMARSEditor]
        internal class Pose : TestCondition<UnityEngine.Pose>
        {
            public override void Initialize(int traitIndex)
            {
                base.Initialize(traitIndex);
                value = traitIndex;
            }

            public override float RateDataMatch(ref UnityEngine.Pose data)
            {
                return Mathf.Clamp01(data.position.x - value);
            }
        }

        internal static float MatchingFloatForIndex(int index)
        {
            return index + 1;
        }

        internal static UnityEngine.Vector2 MatchingVector2ForIndex(int index)
        {
            return UnityEngine.Vector2.right * (index + 1);
        }

        internal static string TraitNameForIndex(int index)
        {
            return k_TraitNamePrefix + index;
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using Unity.MARS.Conditions;
using Unity.MARS.Query;
using UnityEngine;

namespace Unity.MARS.Data.Tests
{
    static class ExtensionMethods
    {
        internal static TestConditions.Float AddTestFloatCondition(this GameObject go,
            string traitName, float value = 0f)
        {
            var condition = go.AddComponent<TestConditions.Float>();
            condition.traitName = traitName;
            condition.value = value;
            return condition;
        }

        internal static TestConditions.Float AddTestFloatCondition(this GameObject go,
            int traitIndex = 0, float value = 0f)
        {
            return AddTestCondition<TestConditions.Float, float>(go, traitIndex, value);
        }

        internal static TCondition AddTestCondition<TCondition, TData>(GameObject go,
            int traitIndex = 0, float value = 0f)
            where TCondition : Component, ITestCondition<TData, float>
        {
            var condition = go.AddComponent<TCondition>();
            condition.traitName = DatabaseTestData.TraitNameForIndex<TData>(traitIndex);
            condition.value = value;
            return condition;
        }

        internal static TestConditions.Vector2 AddTestVector2Condition(this GameObject go,
            string traitName, float xGreaterThanValue = 0f)
        {
            var condition = go.AddComponent<TestConditions.Vector2>();
            condition.traitName = traitName;
            condition.value = xGreaterThanValue;
            return condition;
        }

        internal static TestConditions.Vector2 AddTestVector2Condition(this GameObject go,
            float value = 0f, int traitIndex = 0)
        {
            return AddTestCondition<TestConditions.Vector2, Vector2>(go, traitIndex, value);
        }

        // this one adds a real tag condition, not one of the mocked ones.
        // mostly this is because a tag condition is very simple already and there are tests for them.
        internal static SemanticTagCondition AddSemanticTagCondition(this GameObject go,
            string traitName = "", SemanticTagMatchRule rule = SemanticTagMatchRule.Match)
        {
            var condition = go.AddComponent<SemanticTagCondition>();
            condition.SetTraitName(traitName);
            condition.matchRule = rule;
            return condition;
        }

        internal static TryBestMatchArguments GetMatchArgs(this GameObject go,
            Exclusivity exclusivity = Exclusivity.ReadOnly)
        {
            var conditionsRoot = go.GetComponent<TestMRObject>();
            var conditions = ProxyConditions.FromGenericIMRObject(conditionsRoot);
            return new TryBestMatchArguments(conditions, exclusivity);
        }

        // ReSharper disable once CoVariantArrayConversion
        internal static void AssertCollectionsCreated<T>(this ICollection<T>[] collections)
        {
            foreach (var collection in collections)
            {
                Assert.NotNull(collection);
            }
        }

        internal static void AssertCollectionsCreated<T>(this List<Dictionary<int, T>> collections)
        {
            foreach (var collection in collections)
            {
                Assert.NotNull(collection);
            }
        }
    }
}
